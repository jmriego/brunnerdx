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

namespace BrunnerDX
{


    public partial class BrunnerDXGui : Form
    {
        static string GITHUB_USER = "jmriego";
        static string GITHUB_REPO = "brunnerdx";
        static string RELEASES_URL = $"https://github.com/jmriego/brunnerdx/releases";
        static string CHANGELOG_URL = "https://github.com/jmriego/brunnerdx/blob/master/CHANGELOG.md";
        private static NLog.Logger logger;

        string arduinoPortName = "";
        string cls2SimHost;
        string cls2SimPath;
        int cls2SimPort;
        double forceMultiplier;

        private bool isStarting = false;
        long writeOptionsCountdownTicks = -1;
        long connectCountdownTicks = -1;

        BrunnerDX brunnerDX = new BrunnerDX();

        private object lockObject = new object();

        public BrunnerDXGui()
        {
            InitializeComponent();
            this.consoleLog.ReadOnly = true;
            this.ReadOptions();
            this.refreshComPorts();


            if (this.AutoCLSOpenCheckBox.Checked)
            {
                CLS2SimAutomation simWindow = new CLS2SimAutomation(cls2SimPath);
                simWindow.Open(returnFocus: Process.GetCurrentProcess());
            }

            // if AutoConnect is enabled and we just opened the app start the connection in 3s
            if (this.autoConnectCheck.Checked)
            {
                connectCountdownTicks = (3000 / refreshTimer.Interval) + 1;
                if (!refreshTimer.Enabled)
                {
                    refreshTimer.Start();
                }
            }
        }

        private void ReadOptions()
        {
            isStarting = true;
            this.ipOption.Text = Properties.Settings.Default.IP;
            this.portOption.Text = Properties.Settings.Default.Port.ToString();
            this.autoConnectCheck.Checked = Properties.Settings.Default.AutoConnect;
            this.checkDefaultSpring.Checked = Properties.Settings.Default.DefaultSpring;
            this.comboPorts.Text = Properties.Settings.Default.ComPort;

            try
            {
                this.forceSlider.Value = (int)Properties.Settings.Default.Force;
            }
            catch (Exception ex) { }

            this.forceValue.Text = this.forceSlider.Value.ToString(); // TODO: shouldn't repeat this code
            this.AutoCLSOpenCheckBox.Checked = Properties.Settings.Default.AutoOpenCLS2Sim;
            this.TextCLS2SimPath.Text = Properties.Settings.Default.AutoOpenCLS2SimPath;
            ConfirmOptions();
            isStarting = false;
        }

        private void WriteOptions()
        {
            Properties.Settings.Default.IP = cls2SimHost;
            Properties.Settings.Default.Port = cls2SimPort;
            Properties.Settings.Default.Force = forceMultiplier;
            Properties.Settings.Default.AutoConnect = this.autoConnectCheck.Checked;
            Properties.Settings.Default.DefaultSpring = this.checkDefaultSpring.Checked;
            Properties.Settings.Default.ComPort = arduinoPortName;
            Properties.Settings.Default.AutoOpenCLS2Sim = this.AutoCLSOpenCheckBox.Checked;
            Properties.Settings.Default.AutoOpenCLS2SimPath = this.TextCLS2SimPath.Text;
            Properties.Settings.Default.Save();
        }

        private void ConfirmOptions(bool startWriteCountdown=false)
        {
            cls2SimHost = this.ipOption.Text;
            brunnerDX.cls2SimHost = cls2SimHost;

            cls2SimPort = int.Parse(this.portOption.Text);
            brunnerDX.cls2SimPort = cls2SimPort;

            arduinoPortName = this.comboPorts.Text;

            forceMultiplier = this.forceSlider.Value;
            brunnerDX.forceMultiplier = (double)forceMultiplier / 100.0;
            brunnerDX.trimForceMultiplierXY = (double)this.barTrimStrengthXY.Value / (double)this.barTrimStrengthXY.Maximum;
            brunnerDX.trimForceMultiplierZ = (double)this.barTrimStrengthZ.Value / (double)this.barTrimStrengthZ.Maximum;

            this.cls2SimPath = this.TextCLS2SimPath.Text;

            if (startWriteCountdown)
            {
                writeOptionsCountdownTicks = (2000 / refreshTimer.Interval) + 1;
                if (!refreshTimer.Enabled)
                {
                    refreshTimer.Start();
                }
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
                if (port == arduinoPortName)
                {
                    this.comboPorts.SelectedItem = arduinoPortName;
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
            try
            {
                var client = new GitHubClient(new ProductHeaderValue(GITHUB_REPO));
                var releases = await client.Repository.Release.GetAll(GITHUB_USER, GITHUB_REPO);
                var lastReleaseVersion = new Version(releases[0].TagName.TrimStart('v'));

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
            catch (System.Net.WebException)
            {
                logger.Warn("Couldn't check for updates");
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

        private void upload_Click(object sender, EventArgs e)
        {
            this.uploadProgressBar.Visible = true;

            var progress = new Progress<double>(
                p => UpdateProgress(p));
            var options = new ArduinoSketchUploaderOptions() {
                FileName = Path.Combine(AppContext.BaseDirectory, "Fino.ino.hex"),
                PortName = this.arduinoPortName,
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
            //this.consoleLog.SelectAll();
            //this.consoleLog.Copy();
            this.consoleLog.Clear();
        }

        private void BrunnerDXGui_Load(object sender, EventArgs e)
        {
            if (logger == null) logger = LogManager.GetCurrentClassLogger();
            RichTextBoxTarget.ReInitializeAllTextboxes(this);
            this.consoleLog.DetectUrls = true;
            logger.Info("Init");
            CheckBrunnerDXVersion();
        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
        }

        private void detectPorts_Click(object sender, EventArgs e)
        {
            this.refreshComPorts();
        }

        private void forceSlider_Scroll(object sender, EventArgs e)
        {
            this.forceValue.Text = this.forceSlider.Value.ToString();
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
        }

        private void barTrimStrengthXY_Scroll(object sender, EventArgs e)
        {
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
        }

        private void barTrimStrengthZ_Scroll(object sender, EventArgs e)
        {
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
        }

        private void delaySlider_Scroll(object sender, EventArgs e)
        {
            string delayText = $"{this.delaySlider.Value} secs";
            this.delayValue.Text = delayText;
            brunnerDX.delaySeconds = this.delaySlider.Value;
        }

        private void ipOption_TextChanged(object sender, EventArgs e)
        {
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
        }

        private void portOption_TextChanged(object sender, EventArgs e)
        {
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
        }

        private void autoConnectCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
            if (!this.autoConnectCheck.Checked)
            {
                connectCountdownTicks = -1;
            }
        }

        private void checkDefaultSpring_CheckedChanged(object sender, EventArgs e)
        {
            if (!isStarting) ConfirmOptions(startWriteCountdown: true);
            brunnerDX.defaultSpring = this.checkDefaultSpring.Checked;
        }

        private void AutoCLSOpenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isStarting)
            {
                if (AutoCLSOpenCheckBox.Checked)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = this.cls2SimPath;
                        openFileDialog.Filter = "Executable|CLS2Sim.exe";
                        //openFileDialog.FilterIndex = 2;
                        //openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            var dir = Path.GetDirectoryName(openFileDialog.FileName);
                            this.cls2SimPath = dir;
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

                ConfirmOptions(startWriteCountdown: true);
            }

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectBrunnerDX();
        }

        private void ConnectBrunnerDX()
        {
            brunnerDX.cls2SimHost = cls2SimHost;
            brunnerDX.cls2SimPort = cls2SimPort;
            brunnerDX.arduinoPortName = arduinoPortName;
            brunnerDX.defaultSpring = this.checkDefaultSpring.Checked;

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
                        ConnectBrunnerDX();
                    }
                }

                if (writeOptionsCountdownTicks > 0)
                {
                    --writeOptionsCountdownTicks;
                    if (writeOptionsCountdownTicks == 0)
                    {
                        WriteOptions();
                    }
                }

                if (brunnerDX.stopExecuting &&
                    writeOptionsCountdownTicks < 0 &&
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

        private void consoleLog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
