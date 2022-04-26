using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;

using NLog;
using NLog.Config;
using NLog.Windows.Forms;
using NLog.Targets.Wrappers;

using System.Windows.Forms.DataVisualization.Charting;

using ArduinoUploader;
using ArduinoUploader.Hardware;

using Octokit;

using BrunnerDX;

namespace BrunnerDX
{


    public partial class BrunnerDXGui : Form
    {
        static string GITHUB_USER = "jmriego";
        static string GITHUB_REPO = "brunnerdx";
        static string RELEASES_URL = $"https://github.com/jmriego/brunnerdx/releases";
        static string CHANGELOG_URL = "https://github.com/jmriego/brunnerdx/blob/master/CHANGELOG.md";
        private static NLog.Logger logger;

        BrunnerDXGuiOptions options = new BrunnerDXGuiOptions();
        BrunnerDX brunnerDX = new BrunnerDX();

        // button mapping variables
        private string waitingForMappingState = "";
        private Button waitingForMappingButton = null;
        private bool[] prevButtonsPressed;

        private long connectCountdownTicks = -1;
        private object lockObject = new object();

        public BrunnerDXGui()
        {
            InitializeComponent();
            this.consoleLog.ReadOnly = true;
            this.UpdateGUIFromOptions();
            this.refreshComPorts();
            this.options.hasFinishedInitializing = true;

            if (this.options.autoOpenCLS2Sim)
            {
                CLS2SimAutomation simWindow = new CLS2SimAutomation(this.options.CLS2SimPath);
                simWindow.Open(returnFocus: Process.GetCurrentProcess());
            }

            // if AutoConnect is enabled and we just opened the app start the connection in 3s
            if (this.options.autoConnect)
            {
                connectCountdownTicks = (3000 / refreshTimer.Interval) + 1;
                if (!refreshTimer.Enabled)
                {
                    refreshTimer.Start();
                }
            }
        }

        private void UpdateGUIFromOptions()
        {
            this.ipOption.Text = this.options.ip;
            this.portOption.Text = this.options.port.ToString();
            this.autoConnectCheck.Checked = this.options.autoConnect;
            this.checkDefaultSpring.Checked = this.options.defaultSpring;
            this.comboPorts.Text = this.options.comPort;

            this.forceSlider.Value = this.options.forceMultiplier;
            this.barTrimStrengthXY.Value = this.options.trimStrengthXY;
            this.barTrimStrengthZ.Value = this.options.trimStrengthZ;

            this.forceValue.Text = this.options.forceMultiplier.ToString(); // TODO: shouldn't repeat this code
            this.AutoCLSOpenCheckBox.Checked = this.options.autoOpenCLS2Sim;
            this.TextCLS2SimPath.Text = this.options.CLS2SimPath;

            this.btnDecTrimX.Text = this.options.DecTrimXMapping == -1 ? "?" : this.options.DecTrimXMapping.ToString();
            this.btnIncTrimX.Text = this.options.IncTrimXMapping == -1 ? "?" : this.options.IncTrimXMapping.ToString();
            this.btnDecTrimY.Text = this.options.DecTrimYMapping == -1 ? "?" : this.options.DecTrimYMapping.ToString();
            this.btnIncTrimY.Text = this.options.IncTrimYMapping == -1 ? "?" : this.options.IncTrimYMapping.ToString();
            this.btnCenterTrim.Text = this.options.CenterTrimMapping == -1 ? "?" : this.options.CenterTrimMapping.ToString();
            this.btnReleaseTrim.Text = this.options.ReleaseTrimMapping == -1 ? "?" : this.options.ReleaseTrimMapping.ToString();
        }

        private int parseTextToInt(string s, int defaultValue)
        {
            try
            {
                return int.Parse(s);
            } catch (FormatException)
            {
                return defaultValue;
            }
        }

        private void refreshComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            var comparer = new StringIntsComparer();
            Array.Sort(ports, comparer);

            this.comboPorts.Items.Clear();
            bool selectedPortFound = false;
            foreach (string port in ports)
            {
                this.comboPorts.Items.Add(port);
                if (port == this.options.comPort)
                {
                    this.comboPorts.SelectedItem = this.options.comPort;
                    selectedPortFound = true;
                }
            }

            if (!selectedPortFound)
            { 
                this.comboPorts.SelectedIndex = ports.Length - 1;
            }
        }

        public async void CheckBrunnerDXVersion()
        {
            Version lastReleaseVersion = null;
            try
            {
                var client = new GitHubClient(new ProductHeaderValue(GITHUB_REPO));
                var releases = await client.Repository.Release.GetAll(GITHUB_USER, GITHUB_REPO);
                lastReleaseVersion = new Version(releases[0].TagName.TrimStart('v'));
            }
            catch (Exception ex) when (ex is System.Net.WebException || ex is System.Net.Http.HttpRequestException)
            {
                logger.Warn("Couldn't check for updates");
                return;
            }

            var assemblyVersion = typeof(BrunnerDX).Assembly.GetName().Version;
            Version brunnerDXVersion = new Version($"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Revision}");
            switch (brunnerDXVersion.CompareTo(lastReleaseVersion))
            {
                case -1:
                    logger.Warn($"There's an update available");
                    this.consoleLog.AppendText($"\nDOWNLOAD: {RELEASES_URL}\nCHANGELOG: {CHANGELOG_URL}\n\n");
                    break;
                case 0:
                    logger.Info($"You have the latest version");
                    break;
            }
        }

        delegate void SetProgressCallback(double progress);

        public void UpdateProgress(double progress)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.uploadProgressBar.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(UpdateProgress);
                this.Invoke(d, new object[] { progress });
            }
            else
            {
                int as_pct = (int)Math.Round(progress * 100);
                this.uploadProgressBar.Value = as_pct;
            }
        }

        private void BrunnerDXGui_Load(object sender, EventArgs e)
        {
            if (logger == null) logger = LogManager.GetCurrentClassLogger();
            RichTextBoxTarget.ReInitializeAllTextboxes(this);
            this.consoleLog.DetectUrls = true;
            logger.Info("Init");
            CheckBrunnerDXVersion();
        }

        private void ConnectToggleBrunnerDX()
        {
            this.connectCountdownTicks = 0;
            brunnerDX.cls2SimHost = this.options.ip;
            brunnerDX.cls2SimPort = this.options.port;
            brunnerDX.arduinoPortName = this.options.comPort;
            brunnerDX.defaultSpring = this.options.defaultSpring;
            brunnerDX.forceMultiplier.pct = this.options.forceMultiplier;

            brunnerDX.trimForceMultiplierXY.pct = this.options.trimStrengthXY;
            brunnerDX.trimForceMultiplierZ.pct = this.options.trimStrengthZ;
            brunnerDX.mapping["DecTrimX"] = this.options.DecTrimXMapping;
            brunnerDX.mapping["IncTrimX"] = this.options.IncTrimXMapping;
            brunnerDX.mapping["DecTrimY"] = this.options.DecTrimYMapping;
            brunnerDX.mapping["IncTrimY"] = this.options.IncTrimYMapping;
            brunnerDX.mapping["CenterTrim"] = this.options.CenterTrimMapping;
            brunnerDX.mapping["ReleaseTrim"] = this.options.ReleaseTrimMapping;

            if (brunnerDX.isArduinoConnected)
            {
                brunnerDX.stopExecuting = true;
            }
            else
            {
                refreshTimer.Start();
                var thread = new Thread(() =>
                {
                    try
                    {
                        brunnerDX.loop();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, ex.Message);
                    }
                });
                thread.Start();
            }
        }

        private void RemapBrunnerDXButton()
        {
            string bindingName = this.waitingForMappingButton.Name.Replace("btn", "");
            int bindingMapping = -1;
            if (this.waitingForMappingState == "CANCEL")
            {
                logger.Info($"Cancelled mapping for {bindingName}");
                this.waitingForMappingButton.Text = "?";
                this.waitingForMappingState = "";
                this.waitingForMappingButton = null;
            }
            else if (this.prevButtonsPressed != null)
            {
                for (int i = 0; i < this.brunnerDX.buttons.Length; i++)
                {
                    if (!this.prevButtonsPressed[i] && this.brunnerDX.buttons[i])
                    {
                        logger.Info($"Remapped {bindingName} to button {i}");
                        bindingMapping = i;
                        this.waitingForMappingButton.Text = i.ToString();
                        this.waitingForMappingState = "";
                        this.waitingForMappingButton = null;
                    }
                }
            }

            this.brunnerDX.mapping[bindingName] = bindingMapping;
            this.options.GetType().GetProperty(bindingName + "Mapping").SetValue(this.options, bindingMapping);

        }

        private void upload_Click(object sender, EventArgs e)
        {
            this.uploadProgressBar.Visible = true;

            var progress = new Progress<double>(
                p => UpdateProgress(p));
            var options = new ArduinoSketchUploaderOptions() {
                FileName = Path.Combine(AppContext.BaseDirectory, "Fino.ino.hex"),
                PortName = this.options.comPort,
                ArduinoModel = ArduinoModel.Micro
            };

            var uploader = new ArduinoSketchUploader(
                options,
                new FormArduinoUploaderLogger(logger),
                progress);

            var thread = new Thread(() =>
            {
                try
                {
                    uploader.UploadSketch();
                    logger.Info("Uploaded to Arduino. Please click on 'Detect Ports' just in case the Arduino device has changed ports");
                }
                catch (Exception ex)
                {
                    logger.Error(ex, ex.Message);
                }
            });
            thread.Start();
        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            this.consoleLog.Clear();
        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.options.comPort = this.comboPorts.Text.Trim();
        }

        private void detectPorts_Click(object sender, EventArgs e)
        {
            this.refreshComPorts();
        }

        private void forceSlider_Scroll(object sender, EventArgs e)
        {
            this.forceValue.Text = this.forceSlider.Value.ToString();
            this.options.forceMultiplier = this.forceSlider.Value;
            this.brunnerDX.forceMultiplier.pct = this.forceSlider.Value;
        }

        private void barTrimStrengthXY_Scroll(object sender, EventArgs e)
        {
            this.options.trimStrengthXY = this.barTrimStrengthXY.Value;
            this.brunnerDX.trimForceMultiplierXY.pct = this.barTrimStrengthXY.Value;
            this.brunnerDX.defaultSpring = this.checkDefaultSpring.Checked && this.barTrimStrengthXY.Value == 0;
        }

        private void barTrimStrengthZ_Scroll(object sender, EventArgs e)
        {
            this.options.trimStrengthZ = this.barTrimStrengthZ.Value;
            this.brunnerDX.trimForceMultiplierZ.pct = this.barTrimStrengthZ.Value;
        }

        private void delaySlider_Scroll(object sender, EventArgs e)
        {
            this.delayValue.Text = $"{this.delaySlider.Value} secs";
            brunnerDX.delaySeconds = this.delaySlider.Value;
        }

        private void ipOption_TextChanged(object sender, EventArgs e)
        {
            this.options.ip = this.ipOption.Text;
        }

        private void portOption_TextChanged(object sender, EventArgs e)
        {
            this.options.port = int.Parse(this.portOption.Text);
        }

        private void autoConnectCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.options.autoConnect = this.autoConnectCheck.Checked;
            if (!this.autoConnectCheck.Checked)
            {
                connectCountdownTicks = -1;
            }
        }

        private void checkDefaultSpring_CheckedChanged(object sender, EventArgs e)
        {
            this.options.defaultSpring = this.checkDefaultSpring.Checked;
            this.brunnerDX.defaultSpring = this.checkDefaultSpring.Checked && this.barTrimStrengthXY.Value == 0;
        }

        private void AutoCLSOpenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.options.hasFinishedInitializing)
            {
                if (this.AutoCLSOpenCheckBox.Checked)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = this.options.CLS2SimPath;
                        openFileDialog.Filter = "Executable|CLS2Sim.exe";
                        //openFileDialog.FilterIndex = 2;
                        //openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            var dir = Path.GetDirectoryName(openFileDialog.FileName);
                            this.options.CLS2SimPath = dir;
                            this.TextCLS2SimPath.Text = dir;
                            CLS2SimAutomation simWindow = new CLS2SimAutomation(dir);
                            simWindow.Open(returnFocus: Process.GetCurrentProcess());
                        }
                        else
                        {
                            this.TextCLS2SimPath.Text = "";
                            this.AutoCLSOpenCheckBox.Checked = false;
                        }
                    }
                }
                this.options.autoOpenCLS2Sim = this.AutoCLSOpenCheckBox.Checked;
            }

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectToggleBrunnerDX();
        }

        private void consoleLog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void btnTrimMapping_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == this.waitingForMappingButton)
            {
                this.waitingForMappingState = "CANCEL";
            } else if (!this.brunnerDX.isBrunnerConnected)
            {
                logger.Info("Please connect to CLS2Sim for remapping this control");
            }
            else
            {
                logger.Info("Waiting for button press. Or click on this again to cancel mapping");
                this.waitingForMappingState = "WAITING";
            }
            this.waitingForMappingButton = btn;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (Monitor.TryEnter(lockObject))
            {
                if (this.forceChart.Series[0].Points.Count > 1)
                    this.forceChart.Series[0].Points.RemoveAt(1);
                if (this.positionChart.Series[0].Points.Count > 1)
                    this.positionChart.Series[0].Points.RemoveAt(1);

                if (brunnerDX.isArduinoConnected)
                {
                    this.arduinoStatus.BackColor = Color.Green;
                    this.forceChart.Series[0].Points.AddXY(brunnerDX.force[0], (double)-brunnerDX.force[1]);
                    this.connectButton.Text = "Disconnect";
                    if (this.waitingForMappingState != "") RemapBrunnerDXButton();
                    this.prevButtonsPressed = brunnerDX.buttons;
                }
                else
                {
                    this.arduinoStatus.BackColor = brunnerDX.stopExecuting ? Color.Transparent : Color.Red;
                    this.connectButton.Text = "Connect";
                }

                if (brunnerDX.isBrunnerConnected)
                {
                    this.cls2SimStatus.BackColor = Color.Green;
                    var brunnerPosition = brunnerDX.position;
                    this.positionChart.Series[0].Points.AddXY(brunnerPosition[0], (double)-brunnerPosition[1]);
                }
                else
                {
                    this.cls2SimStatus.BackColor = brunnerDX.stopExecuting ? Color.Transparent : Color.Red;
                }

                if (connectCountdownTicks > 0)
                {
                    --connectCountdownTicks;
                    if (connectCountdownTicks == 0)
                    {
                        ConnectToggleBrunnerDX();
                    }
                }

                if (brunnerDX.stopExecuting &&
                    connectCountdownTicks < 0 &&
                    !brunnerDX.isArduinoConnected)
                {
                    refreshTimer.Enabled = false;
                }
            }

            
        }

        private void BrunnerDXGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            brunnerDX.stopExecuting = true;
        }
    }
}
