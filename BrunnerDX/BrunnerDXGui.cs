using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

using ArduinoUploader;
using ArduinoUploader.Hardware;


namespace BrunnerDX
{


    public partial class BrunnerDXGui : Form
    {
        string selectedPort = "";

        public BrunnerDXGui()
        {
            InitializeComponent();
            this.logger.ReadOnly = true;
            this.refreshComPorts();
        }

        public void refreshComPorts()
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

        delegate void SetTextCallback(string text, Color color);

        public void ConsoleLogText(string text, Color color)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.logger.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ConsoleLogText);
                this.Invoke(d, new object[] { text, color });
            }
            else
            {
                text += Environment.NewLine;
                int length = this.logger.TextLength;  // at end of text
                this.logger.AppendText(text);
                this.logger.SelectionStart = length;
                this.logger.SelectionLength = text.Length;
                this.logger.SelectionColor = color;
                // scroll to bottom
                this.logger.SelectionStart = this.logger.TextLength;
                this.logger.ScrollToCaret();
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            var uploader = new ArduinoSketchUploader(
                new ArduinoSketchUploaderOptions()
                {
                    FileName = @"C:\Users\josem\brunnerdx\build\arduino.avr.micro\brunnerdx.ino.hex",
                    PortName = this.selectedPort,
                    ArduinoModel = ArduinoModel.Micro,
                    
                },
                new FormArduinoUploaderLogger(this));

            try
            {
                uploader.UploadSketch();
            }
            catch (Exception ex)
            {
                this.ConsoleLogText($"UNEXPECTED EXCEPTION: {ex.Message}!", Color.Red);
            }
        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            this.logger.Clear();
        }

        private void BrunnerDXGui_Load(object sender, EventArgs e)
        {

        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedPort = comboPorts.SelectedItem.ToString();
        }

        private void detectPorts_Click(object sender, EventArgs e)
        {
            this.refreshComPorts();
        }
    }
}