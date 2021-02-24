using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;

using NLog;
using NLog.Config;
using NLog.Windows.Forms;
using NLog.Targets.Wrappers;

using System.Windows.Forms.DataVisualization.Charting;

using ArduinoUploader;
using ArduinoUploader.Hardware;


namespace BrunnerDX
{


    public partial class BrunnerDXGui : Form
    {
        private static NLog.Logger logger;

        string arduinoPortName = "";
        string cls2SimHost;
        int cls2SimPort;
        double forceMultiplier;

        private bool isBusy = false;
        long writeOptionsCountdownTicks = -1;

        BrunnerDX brunnerDX = new BrunnerDX();

        private object lockObject = new object();

        public BrunnerDXGui()
        {
            InitializeComponent();
            this.consoleLog.ReadOnly = true;
            this.ReadOptions();
            this.refreshComPorts();
        }

        private void ReadOptions()
        {
            isBusy = true;
            this.ipOption.Text = Properties.Settings.Default.IP;
            this.portOption.Text = Properties.Settings.Default.Port.ToString();
            try
            {

                this.forceSlider.Value = (int)Properties.Settings.Default.Force;
            }
            catch (Exception ex) { }
            this.forceLabel.Text = this.forceSlider.Value.ToString(); // TODO: shouldn't repeat this code
            ConfirmOptions();
            isBusy = false;
        }

        private void WriteOptions()
        {
            Properties.Settings.Default.IP = cls2SimHost;
            Properties.Settings.Default.Port = cls2SimPort;
            Properties.Settings.Default.Force = forceMultiplier;
            Properties.Settings.Default.Save();
        }

        private void ConfirmOptions(bool startWriteCountdown=false)
        {
            cls2SimHost = this.ipOption.Text;
            brunnerDX.cls2SimHost = cls2SimHost;

            cls2SimPort = int.Parse(this.portOption.Text);
            brunnerDX.cls2SimPort = cls2SimPort;

            forceMultiplier = this.forceSlider.Value;
            brunnerDX.forceMultiplier = (double)forceMultiplier / 100.0;

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
            foreach (string port in ports)
            {
                this.comboPorts.Items.Add(port);
            }
            this.comboPorts.SelectedIndex = ports.Length - 1;
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
            logger = LogManager.GetCurrentClassLogger();
            logger.Info("Init");
            RichTextBoxTarget.ReInitializeAllTextboxes(this);
        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.arduinoPortName = comboPorts.SelectedItem.ToString();
        }

        private void detectPorts_Click(object sender, EventArgs e)
        {
            this.refreshComPorts();
        }

        private void forceSlider_Scroll(object sender, EventArgs e)
        {
            this.forceLabel.Text = this.forceSlider.Value.ToString();
            if (!isBusy) ConfirmOptions(startWriteCountdown: true);
        }

        private void delaySlider_Scroll(object sender, EventArgs e)
        {
            string delayText = $"{this.delaySlider.Value} secs";
            this.delayLabel.Text = delayText;
        }

        private void ipOption_TextChanged(object sender, EventArgs e)
        {
            if (!isBusy) ConfirmOptions(startWriteCountdown: true);
        }

        private void portOption_TextChanged(object sender, EventArgs e)
        {
            if (!isBusy) ConfirmOptions(startWriteCountdown: true);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            brunnerDX.cls2SimHost = cls2SimHost;
            brunnerDX.cls2SimPort = cls2SimPort;
            brunnerDX.arduinoPortName = arduinoPortName;

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
                this.forceChart.Series[0].Points.Clear();
                this.positionChart.Series[0].Points.Clear();

                if (brunnerDX.isArduinoConnected)
                {
                    this.arduinoStatus.BackColor = Color.Green;
                    this.forceChart.Series[0].Points.AddXY(brunnerDX.force[0], (double)brunnerDX.force[1]);
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
                    this.positionChart.Series[0].Points.AddXY(brunnerDX.position[0], (double)-brunnerDX.position[1]);
                }
                else
                {
                    this.cls2SimStatus.BackColor = brunnerDX.stopExecuting ? Color.Transparent : Color.Red;
                }

                if (writeOptionsCountdownTicks > 0)
                {
                    --writeOptionsCountdownTicks;
                    if (writeOptionsCountdownTicks == 0)
                    {
                        WriteOptions();
                    }
                }

                if (brunnerDX.stopExecuting && writeOptionsCountdownTicks < 0 && !brunnerDX.isArduinoConnected)
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