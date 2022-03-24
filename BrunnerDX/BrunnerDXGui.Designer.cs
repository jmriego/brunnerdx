
namespace BrunnerDX
{
    partial class BrunnerDXGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.groupBoxFirmware = new System.Windows.Forms.GroupBox();
            this.uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.detectPorts = new System.Windows.Forms.Button();
            this.upload = new System.Windows.Forms.Button();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.consoleLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxLogging = new System.Windows.Forms.GroupBox();
            this.clearLog = new System.Windows.Forms.Button();
            this.delayValue = new System.Windows.Forms.Label();
            this.delaySlider = new System.Windows.Forms.TrackBar();
            this.delayLabel = new System.Windows.Forms.Label();
            this.forceValue = new System.Windows.Forms.Label();
            this.autoConnectCheck = new System.Windows.Forms.CheckBox();
            this.autoConnectLabel = new System.Windows.Forms.Label();
            this.forceSlider = new System.Windows.Forms.TrackBar();
            this.forceLabel = new System.Windows.Forms.Label();
            this.portOption = new System.Windows.Forms.TextBox();
            this.ipOption = new System.Windows.Forms.TextBox();
            this.udpLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.groupBoxConnect = new System.Windows.Forms.GroupBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.forcesLabel = new System.Windows.Forms.Label();
            this.forceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.connectButton = new System.Windows.Forms.Button();
            this.cls2SimStatus = new System.Windows.Forms.PictureBox();
            this.clsLabel = new System.Windows.Forms.Label();
            this.arduinoStatus = new System.Windows.Forms.PictureBox();
            this.arduinoLabel = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkDefaultSpring = new System.Windows.Forms.CheckBox();
            this.AutoCLSOpenCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.profileTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionTab = new System.Windows.Forms.TabPage();
            this.TextCLS2SimPath = new System.Windows.Forms.Label();
            this.labelAutoCLSOpen = new System.Windows.Forms.Label();
            this.trimTab = new System.Windows.Forms.TabPage();
            this.barTrimX = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.ctnCenterTrimX = new System.Windows.Forms.Button();
            this.btnIncTrimX = new System.Windows.Forms.Button();
            this.btnDecTrimX = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDecTrimY = new System.Windows.Forms.Button();
            this.btnIncTrimY = new System.Windows.Forms.Button();
            this.ctnCenterTrimY = new System.Windows.Forms.Button();
            this.barTrimY = new System.Windows.Forms.TrackBar();
            this.btnDecTrimZ = new System.Windows.Forms.Button();
            this.btnIncTrimZ = new System.Windows.Forms.Button();
            this.ctnCenterTrimZ = new System.Windows.Forms.Button();
            this.barTrimZ = new System.Windows.Forms.TrackBar();
            this.checkboxTrim = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxFirmware.SuspendLayout();
            this.groupBoxLogging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delaySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceSlider)).BeginInit();
            this.groupBoxConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cls2SimStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arduinoStatus)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.profileTab.SuspendLayout();
            this.connectionTab.SuspendLayout();
            this.trimTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimZ)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFirmware
            // 
            this.groupBoxFirmware.Controls.Add(this.uploadProgressBar);
            this.groupBoxFirmware.Controls.Add(this.detectPorts);
            this.groupBoxFirmware.Controls.Add(this.upload);
            this.groupBoxFirmware.Controls.Add(this.comboPorts);
            this.groupBoxFirmware.Controls.Add(this.portLabel);
            this.groupBoxFirmware.Location = new System.Drawing.Point(20, 22);
            this.groupBoxFirmware.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxFirmware.Name = "groupBoxFirmware";
            this.groupBoxFirmware.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxFirmware.Size = new System.Drawing.Size(782, 194);
            this.groupBoxFirmware.TabIndex = 0;
            this.groupBoxFirmware.TabStop = false;
            this.groupBoxFirmware.Text = "Arduino Firmware";
            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.Location = new System.Drawing.Point(28, 128);
            this.uploadProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new System.Drawing.Size(726, 28);
            this.uploadProgressBar.TabIndex = 4;
            this.uploadProgressBar.Visible = false;
            // 
            // detectPorts
            // 
            this.detectPorts.Location = new System.Drawing.Point(284, 44);
            this.detectPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.detectPorts.Name = "detectPorts";
            this.detectPorts.Size = new System.Drawing.Size(170, 77);
            this.detectPorts.TabIndex = 3;
            this.detectPorts.Text = "Detect Ports";
            this.detectPorts.UseVisualStyleBackColor = true;
            this.detectPorts.Click += new System.EventHandler(this.detectPorts_Click);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(464, 44);
            this.upload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(184, 77);
            this.upload.TabIndex = 2;
            this.upload.Text = "Upload Firmware";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // comboPorts
            // 
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(90, 64);
            this.comboPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(180, 33);
            this.comboPorts.TabIndex = 1;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(22, 64);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(51, 25);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port";
            // 
            // consoleLog
            // 
            this.consoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleLog.Location = new System.Drawing.Point(8, 84);
            this.consoleLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.consoleLog.Name = "consoleLog";
            this.consoleLog.Size = new System.Drawing.Size(1385, 313);
            this.consoleLog.TabIndex = 2;
            this.consoleLog.Text = "";
            this.consoleLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.consoleLog_LinkClicked);
            // 
            // groupBoxLogging
            // 
            this.groupBoxLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLogging.Controls.Add(this.clearLog);
            this.groupBoxLogging.Controls.Add(this.consoleLog);
            this.groupBoxLogging.Location = new System.Drawing.Point(20, 435);
            this.groupBoxLogging.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxLogging.Name = "groupBoxLogging";
            this.groupBoxLogging.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxLogging.Size = new System.Drawing.Size(1405, 409);
            this.groupBoxLogging.TabIndex = 3;
            this.groupBoxLogging.TabStop = false;
            this.groupBoxLogging.Text = "Logging";
            // 
            // clearLog
            // 
            this.clearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearLog.Location = new System.Drawing.Point(1207, 23);
            this.clearLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(188, 53);
            this.clearLog.TabIndex = 3;
            this.clearLog.Text = "Clear Log";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // delayValue
            // 
            this.delayValue.AutoSize = true;
            this.delayValue.Location = new System.Drawing.Point(306, 234);
            this.delayValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.delayValue.Name = "delayValue";
            this.delayValue.Size = new System.Drawing.Size(75, 25);
            this.delayValue.TabIndex = 11;
            this.delayValue.Text = "0 secs";
            this.delayValue.Visible = false;
            // 
            // delaySlider
            // 
            this.delaySlider.LargeChange = 2;
            this.delaySlider.Location = new System.Drawing.Point(182, 189);
            this.delaySlider.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.delaySlider.Maximum = 6;
            this.delaySlider.Name = "delaySlider";
            this.delaySlider.Size = new System.Drawing.Size(252, 90);
            this.delaySlider.TabIndex = 10;
            this.toolTip.SetToolTip(this.delaySlider, "Movement delay. Helps during the axis mappings in some games\r\nForces will be deac" +
        "tivated while using this");
            this.delaySlider.Scroll += new System.EventHandler(this.delaySlider_Scroll);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(96, 208);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(67, 25);
            this.delayLabel.TabIndex = 9;
            this.delayLabel.Text = "Delay";
            // 
            // forceValue
            // 
            this.forceValue.AutoSize = true;
            this.forceValue.Location = new System.Drawing.Point(306, 108);
            this.forceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forceValue.Name = "forceValue";
            this.forceValue.Size = new System.Drawing.Size(36, 25);
            this.forceValue.TabIndex = 8;
            this.forceValue.Text = "30";
            // 
            // autoConnectCheck
            // 
            this.autoConnectCheck.AutoSize = true;
            this.autoConnectCheck.Location = new System.Drawing.Point(326, 248);
            this.autoConnectCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.autoConnectCheck.Name = "autoConnectCheck";
            this.autoConnectCheck.Size = new System.Drawing.Size(28, 27);
            this.autoConnectCheck.TabIndex = 7;
            this.toolTip.SetToolTip(this.autoConnectCheck, "Connect on program start");
            this.autoConnectCheck.UseVisualStyleBackColor = true;
            this.autoConnectCheck.CheckedChanged += new System.EventHandler(this.autoConnectCheck_CheckedChanged);
            // 
            // autoConnectLabel
            // 
            this.autoConnectLabel.AutoSize = true;
            this.autoConnectLabel.Location = new System.Drawing.Point(140, 248);
            this.autoConnectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoConnectLabel.Name = "autoConnectLabel";
            this.autoConnectLabel.Size = new System.Drawing.Size(142, 25);
            this.autoConnectLabel.TabIndex = 6;
            this.autoConnectLabel.Text = "Auto Connect";
            // 
            // forceSlider
            // 
            this.forceSlider.LargeChange = 10;
            this.forceSlider.Location = new System.Drawing.Point(182, 64);
            this.forceSlider.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.forceSlider.Maximum = 150;
            this.forceSlider.Name = "forceSlider";
            this.forceSlider.Size = new System.Drawing.Size(252, 90);
            this.forceSlider.TabIndex = 5;
            this.forceSlider.TickFrequency = 10;
            this.toolTip.SetToolTip(this.forceSlider, "Force strength");
            this.forceSlider.Value = 30;
            this.forceSlider.Scroll += new System.EventHandler(this.forceSlider_Scroll);
            // 
            // forceLabel
            // 
            this.forceLabel.AutoSize = true;
            this.forceLabel.Location = new System.Drawing.Point(106, 83);
            this.forceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forceLabel.Name = "forceLabel";
            this.forceLabel.Size = new System.Drawing.Size(67, 25);
            this.forceLabel.TabIndex = 4;
            this.forceLabel.Text = "Force";
            // 
            // portOption
            // 
            this.portOption.Location = new System.Drawing.Point(326, 120);
            this.portOption.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.portOption.Name = "portOption";
            this.portOption.Size = new System.Drawing.Size(148, 31);
            this.portOption.TabIndex = 3;
            this.portOption.Text = "15090";
            this.portOption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.portOption.TextChanged += new System.EventHandler(this.portOption_TextChanged);
            // 
            // ipOption
            // 
            this.ipOption.Location = new System.Drawing.Point(326, 62);
            this.ipOption.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ipOption.Name = "ipOption";
            this.ipOption.Size = new System.Drawing.Size(148, 31);
            this.ipOption.TabIndex = 2;
            this.ipOption.Text = "127.0.0.1";
            this.ipOption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ipOption.TextChanged += new System.EventHandler(this.ipOption_TextChanged);
            // 
            // udpLabel
            // 
            this.udpLabel.AutoSize = true;
            this.udpLabel.Location = new System.Drawing.Point(88, 130);
            this.udpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.udpLabel.Name = "udpLabel";
            this.udpLabel.Size = new System.Drawing.Size(194, 25);
            this.udpLabel.TabIndex = 1;
            this.udpLabel.Text = "CLS2Sim UDP port";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(158, 70);
            this.ipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(126, 25);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "CLS2Sim IP";
            // 
            // groupBoxConnect
            // 
            this.groupBoxConnect.Controls.Add(this.positionLabel);
            this.groupBoxConnect.Controls.Add(this.positionChart);
            this.groupBoxConnect.Controls.Add(this.forcesLabel);
            this.groupBoxConnect.Controls.Add(this.forceChart);
            this.groupBoxConnect.Controls.Add(this.connectButton);
            this.groupBoxConnect.Controls.Add(this.cls2SimStatus);
            this.groupBoxConnect.Controls.Add(this.clsLabel);
            this.groupBoxConnect.Controls.Add(this.arduinoStatus);
            this.groupBoxConnect.Controls.Add(this.arduinoLabel);
            this.groupBoxConnect.Location = new System.Drawing.Point(20, 223);
            this.groupBoxConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxConnect.Size = new System.Drawing.Size(782, 212);
            this.groupBoxConnect.TabIndex = 6;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "Connect";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(624, 156);
            this.positionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(89, 25);
            this.positionLabel.TabIndex = 8;
            this.positionLabel.Text = "Position";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // positionChart
            // 
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisX.Maximum = 32767D;
            chartArea3.AxisX.Minimum = -32767D;
            chartArea3.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.AxisY.Maximum = 32767D;
            chartArea3.AxisY.Minimum = -32767D;
            chartArea3.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.positionChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.positionChart.Legends.Add(legend3);
            this.positionChart.Location = new System.Drawing.Point(604, 27);
            this.positionChart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.positionChart.Name = "positionChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.DodgerBlue;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series3.Name = "Series1";
            dataPoint3.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataPoint3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series3.Points.Add(dataPoint3);
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.positionChart.Series.Add(series3);
            this.positionChart.Size = new System.Drawing.Size(128, 123);
            this.positionChart.TabIndex = 7;
            this.positionChart.Text = "chart1";
            // 
            // forcesLabel
            // 
            this.forcesLabel.AutoSize = true;
            this.forcesLabel.Location = new System.Drawing.Point(458, 156);
            this.forcesLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.forcesLabel.Name = "forcesLabel";
            this.forcesLabel.Size = new System.Drawing.Size(78, 25);
            this.forcesLabel.TabIndex = 6;
            this.forcesLabel.Text = "Forces";
            this.forcesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // forceChart
            // 
            chartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisX.Maximum = 10000D;
            chartArea4.AxisX.Minimum = -10000D;
            chartArea4.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Enabled = false;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.AxisY.Maximum = 10000D;
            chartArea4.AxisY.Minimum = -10000D;
            chartArea4.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.forceChart.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.forceChart.Legends.Add(legend4);
            this.forceChart.Location = new System.Drawing.Point(432, 27);
            this.forceChart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.forceChart.Name = "forceChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.MarkerColor = System.Drawing.Color.DodgerBlue;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series4.Name = "Series1";
            dataPoint4.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataPoint4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series4.Points.Add(dataPoint4);
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.forceChart.Series.Add(series4);
            this.forceChart.Size = new System.Drawing.Size(128, 123);
            this.forceChart.TabIndex = 5;
            this.forceChart.Text = "chart1";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(210, 53);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(168, 72);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // cls2SimStatus
            // 
            this.cls2SimStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cls2SimStatus.Location = new System.Drawing.Point(152, 98);
            this.cls2SimStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cls2SimStatus.Name = "cls2SimStatus";
            this.cls2SimStatus.Size = new System.Drawing.Size(22, 23);
            this.cls2SimStatus.TabIndex = 3;
            this.cls2SimStatus.TabStop = false;
            // 
            // clsLabel
            // 
            this.clsLabel.AutoSize = true;
            this.clsLabel.Location = new System.Drawing.Point(40, 100);
            this.clsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clsLabel.Name = "clsLabel";
            this.clsLabel.Size = new System.Drawing.Size(101, 25);
            this.clsLabel.TabIndex = 2;
            this.clsLabel.Text = "CLS2Sim";
            this.clsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // arduinoStatus
            // 
            this.arduinoStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arduinoStatus.Location = new System.Drawing.Point(152, 53);
            this.arduinoStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.arduinoStatus.Name = "arduinoStatus";
            this.arduinoStatus.Size = new System.Drawing.Size(22, 23);
            this.arduinoStatus.TabIndex = 1;
            this.arduinoStatus.TabStop = false;
            // 
            // arduinoLabel
            // 
            this.arduinoLabel.AutoSize = true;
            this.arduinoLabel.Location = new System.Drawing.Point(54, 53);
            this.arduinoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.arduinoLabel.Name = "arduinoLabel";
            this.arduinoLabel.Size = new System.Drawing.Size(86, 25);
            this.arduinoLabel.TabIndex = 0;
            this.arduinoLabel.Text = "Arduino";
            this.arduinoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // checkDefaultSpring
            // 
            this.checkDefaultSpring.AutoSize = true;
            this.checkDefaultSpring.Location = new System.Drawing.Point(196, 303);
            this.checkDefaultSpring.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkDefaultSpring.Name = "checkDefaultSpring";
            this.checkDefaultSpring.Size = new System.Drawing.Size(28, 27);
            this.checkDefaultSpring.TabIndex = 3;
            this.toolTip.SetToolTip(this.checkDefaultSpring, "Start a centering spring effect when there\'s no sim running and BrunnerDX is conn" +
        "ected");
            this.checkDefaultSpring.UseVisualStyleBackColor = true;
            this.checkDefaultSpring.CheckedChanged += new System.EventHandler(this.checkDefaultSpring_CheckedChanged);
            // 
            // AutoCLSOpenCheckBox
            // 
            this.AutoCLSOpenCheckBox.AutoSize = true;
            this.AutoCLSOpenCheckBox.Location = new System.Drawing.Point(326, 189);
            this.AutoCLSOpenCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AutoCLSOpenCheckBox.Name = "AutoCLSOpenCheckBox";
            this.AutoCLSOpenCheckBox.Size = new System.Drawing.Size(28, 27);
            this.AutoCLSOpenCheckBox.TabIndex = 12;
            this.toolTip.SetToolTip(this.AutoCLSOpenCheckBox, "Open CLS2Sim on External Control mode on program start");
            this.AutoCLSOpenCheckBox.UseVisualStyleBackColor = true;
            this.AutoCLSOpenCheckBox.CheckedChanged += new System.EventHandler(this.AutoCLSOpenCheckBox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.profileTab);
            this.tabControl1.Controls.Add(this.connectionTab);
            this.tabControl1.Controls.Add(this.trimTab);
            this.tabControl1.Location = new System.Drawing.Point(810, 22);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 413);
            this.tabControl1.TabIndex = 7;
            // 
            // profileTab
            // 
            this.profileTab.BackColor = System.Drawing.Color.Transparent;
            this.profileTab.Controls.Add(this.delayValue);
            this.profileTab.Controls.Add(this.checkDefaultSpring);
            this.profileTab.Controls.Add(this.forceLabel);
            this.profileTab.Controls.Add(this.delaySlider);
            this.profileTab.Controls.Add(this.label1);
            this.profileTab.Controls.Add(this.forceValue);
            this.profileTab.Controls.Add(this.forceSlider);
            this.profileTab.Controls.Add(this.delayLabel);
            this.profileTab.Location = new System.Drawing.Point(8, 39);
            this.profileTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.profileTab.Size = new System.Drawing.Size(599, 355);
            this.profileTab.TabIndex = 1;
            this.profileTab.Text = "Profile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 302);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Default Spring";
            // 
            // connectionTab
            // 
            this.connectionTab.BackColor = System.Drawing.Color.Transparent;
            this.connectionTab.Controls.Add(this.TextCLS2SimPath);
            this.connectionTab.Controls.Add(this.labelAutoCLSOpen);
            this.connectionTab.Controls.Add(this.AutoCLSOpenCheckBox);
            this.connectionTab.Controls.Add(this.ipLabel);
            this.connectionTab.Controls.Add(this.udpLabel);
            this.connectionTab.Controls.Add(this.ipOption);
            this.connectionTab.Controls.Add(this.portOption);
            this.connectionTab.Controls.Add(this.autoConnectCheck);
            this.connectionTab.Controls.Add(this.autoConnectLabel);
            this.connectionTab.Location = new System.Drawing.Point(8, 39);
            this.connectionTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectionTab.Name = "connectionTab";
            this.connectionTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectionTab.Size = new System.Drawing.Size(599, 355);
            this.connectionTab.TabIndex = 0;
            this.connectionTab.Text = "Connection";
            // 
            // TextCLS2SimPath
            // 
            this.TextCLS2SimPath.AutoSize = true;
            this.TextCLS2SimPath.Location = new System.Drawing.Point(362, 189);
            this.TextCLS2SimPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TextCLS2SimPath.Name = "TextCLS2SimPath";
            this.TextCLS2SimPath.Size = new System.Drawing.Size(625, 25);
            this.TextCLS2SimPath.TabIndex = 14;
            this.TextCLS2SimPath.Text = "C:\\Program Files (x86)\\Brunner Elektronik AG\\CLS2Sim\\Settings";
            this.TextCLS2SimPath.Visible = false;
            // 
            // labelAutoCLSOpen
            // 
            this.labelAutoCLSOpen.AutoSize = true;
            this.labelAutoCLSOpen.Location = new System.Drawing.Point(123, 189);
            this.labelAutoCLSOpen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAutoCLSOpen.Name = "labelAutoCLSOpen";
            this.labelAutoCLSOpen.Size = new System.Drawing.Size(159, 25);
            this.labelAutoCLSOpen.TabIndex = 13;
            this.labelAutoCLSOpen.Text = "Open CLS2Sim";
            // 
            // trimTab
            // 
            this.trimTab.BackColor = System.Drawing.Color.Transparent;
            this.trimTab.Controls.Add(this.label4);
            this.trimTab.Controls.Add(this.button1);
            this.trimTab.Controls.Add(this.checkboxTrim);
            this.trimTab.Controls.Add(this.btnDecTrimZ);
            this.trimTab.Controls.Add(this.btnIncTrimZ);
            this.trimTab.Controls.Add(this.ctnCenterTrimZ);
            this.trimTab.Controls.Add(this.barTrimZ);
            this.trimTab.Controls.Add(this.btnDecTrimY);
            this.trimTab.Controls.Add(this.btnIncTrimY);
            this.trimTab.Controls.Add(this.ctnCenterTrimY);
            this.trimTab.Controls.Add(this.barTrimY);
            this.trimTab.Controls.Add(this.label3);
            this.trimTab.Controls.Add(this.btnDecTrimX);
            this.trimTab.Controls.Add(this.btnIncTrimX);
            this.trimTab.Controls.Add(this.ctnCenterTrimX);
            this.trimTab.Controls.Add(this.label2);
            this.trimTab.Controls.Add(this.barTrimX);
            this.trimTab.Location = new System.Drawing.Point(8, 39);
            this.trimTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trimTab.Name = "trimTab";
            this.trimTab.Size = new System.Drawing.Size(599, 366);
            this.trimTab.TabIndex = 2;
            this.trimTab.Text = "Trim";
            // 
            // barTrimX
            // 
            this.barTrimX.LargeChange = 1000;
            this.barTrimX.Location = new System.Drawing.Point(134, 79);
            this.barTrimX.Maximum = 10000;
            this.barTrimX.Minimum = -10000;
            this.barTrimX.Name = "barTrimX";
            this.barTrimX.Size = new System.Drawing.Size(265, 90);
            this.barTrimX.SmallChange = 100;
            this.barTrimX.TabIndex = 0;
            this.barTrimX.TickFrequency = 1000;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Center";
            // 
            // ctnCenterTrimX
            // 
            this.ctnCenterTrimX.Location = new System.Drawing.Point(25, 79);
            this.ctnCenterTrimX.Name = "ctnCenterTrimX";
            this.ctnCenterTrimX.Size = new System.Drawing.Size(103, 62);
            this.ctnCenterTrimX.TabIndex = 2;
            this.ctnCenterTrimX.Text = "Roll";
            this.ctnCenterTrimX.UseVisualStyleBackColor = true;
            // 
            // btnIncTrimX
            // 
            this.btnIncTrimX.Location = new System.Drawing.Point(496, 79);
            this.btnIncTrimX.Name = "btnIncTrimX";
            this.btnIncTrimX.Size = new System.Drawing.Size(85, 62);
            this.btnIncTrimX.TabIndex = 3;
            this.btnIncTrimX.Text = "?";
            this.btnIncTrimX.UseVisualStyleBackColor = true;
            // 
            // btnDecTrimX
            // 
            this.btnDecTrimX.Location = new System.Drawing.Point(405, 79);
            this.btnDecTrimX.Name = "btnDecTrimX";
            this.btnDecTrimX.Size = new System.Drawing.Size(85, 62);
            this.btnDecTrimX.TabIndex = 4;
            this.btnDecTrimX.Text = "?";
            this.btnDecTrimX.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Button - / +\r\n";
            // 
            // btnDecTrimY
            // 
            this.btnDecTrimY.Location = new System.Drawing.Point(405, 150);
            this.btnDecTrimY.Name = "btnDecTrimY";
            this.btnDecTrimY.Size = new System.Drawing.Size(85, 62);
            this.btnDecTrimY.TabIndex = 9;
            this.btnDecTrimY.Text = "?";
            this.btnDecTrimY.UseVisualStyleBackColor = true;
            // 
            // btnIncTrimY
            // 
            this.btnIncTrimY.Location = new System.Drawing.Point(496, 150);
            this.btnIncTrimY.Name = "btnIncTrimY";
            this.btnIncTrimY.Size = new System.Drawing.Size(85, 62);
            this.btnIncTrimY.TabIndex = 8;
            this.btnIncTrimY.Text = "?";
            this.btnIncTrimY.UseVisualStyleBackColor = true;
            // 
            // ctnCenterTrimY
            // 
            this.ctnCenterTrimY.Location = new System.Drawing.Point(25, 150);
            this.ctnCenterTrimY.Name = "ctnCenterTrimY";
            this.ctnCenterTrimY.Size = new System.Drawing.Size(103, 62);
            this.ctnCenterTrimY.TabIndex = 7;
            this.ctnCenterTrimY.Text = "Pitch";
            this.ctnCenterTrimY.UseVisualStyleBackColor = true;
            // 
            // barTrimY
            // 
            this.barTrimY.LargeChange = 1000;
            this.barTrimY.Location = new System.Drawing.Point(134, 150);
            this.barTrimY.Maximum = 10000;
            this.barTrimY.Minimum = -10000;
            this.barTrimY.Name = "barTrimY";
            this.barTrimY.Size = new System.Drawing.Size(265, 90);
            this.barTrimY.SmallChange = 100;
            this.barTrimY.TabIndex = 6;
            this.barTrimY.TickFrequency = 1000;
            // 
            // btnDecTrimZ
            // 
            this.btnDecTrimZ.Location = new System.Drawing.Point(405, 222);
            this.btnDecTrimZ.Name = "btnDecTrimZ";
            this.btnDecTrimZ.Size = new System.Drawing.Size(85, 62);
            this.btnDecTrimZ.TabIndex = 13;
            this.btnDecTrimZ.Text = "?";
            this.btnDecTrimZ.UseVisualStyleBackColor = true;
            // 
            // btnIncTrimZ
            // 
            this.btnIncTrimZ.Location = new System.Drawing.Point(496, 222);
            this.btnIncTrimZ.Name = "btnIncTrimZ";
            this.btnIncTrimZ.Size = new System.Drawing.Size(85, 62);
            this.btnIncTrimZ.TabIndex = 12;
            this.btnIncTrimZ.Text = "?";
            this.btnIncTrimZ.UseVisualStyleBackColor = true;
            // 
            // ctnCenterTrimZ
            // 
            this.ctnCenterTrimZ.Location = new System.Drawing.Point(25, 222);
            this.ctnCenterTrimZ.Name = "ctnCenterTrimZ";
            this.ctnCenterTrimZ.Size = new System.Drawing.Size(103, 62);
            this.ctnCenterTrimZ.TabIndex = 11;
            this.ctnCenterTrimZ.Text = "Yaw";
            this.ctnCenterTrimZ.UseVisualStyleBackColor = true;
            // 
            // barTrimZ
            // 
            this.barTrimZ.LargeChange = 1000;
            this.barTrimZ.Location = new System.Drawing.Point(134, 222);
            this.barTrimZ.Maximum = 10000;
            this.barTrimZ.Minimum = -10000;
            this.barTrimZ.Name = "barTrimZ";
            this.barTrimZ.Size = new System.Drawing.Size(265, 90);
            this.barTrimZ.SmallChange = 100;
            this.barTrimZ.TabIndex = 10;
            this.barTrimZ.TickFrequency = 1000;
            // 
            // checkboxTrim
            // 
            this.checkboxTrim.AutoSize = true;
            this.checkboxTrim.Location = new System.Drawing.Point(25, 308);
            this.checkboxTrim.Name = "checkboxTrim";
            this.checkboxTrim.Size = new System.Drawing.Size(159, 29);
            this.checkboxTrim.TabIndex = 15;
            this.checkboxTrim.Text = "Enable Trim";
            this.checkboxTrim.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 62);
            this.button1.TabIndex = 16;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Button Center";
            // 
            // BrunnerDXGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 856);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBoxConnect);
            this.Controls.Add(this.groupBoxLogging);
            this.Controls.Add(this.groupBoxFirmware);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BrunnerDXGui";
            this.Text = "BrunnerDX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrunnerDXGui_FormClosing);
            this.Load += new System.EventHandler(this.BrunnerDXGui_Load);
            this.groupBoxFirmware.ResumeLayout(false);
            this.groupBoxFirmware.PerformLayout();
            this.groupBoxLogging.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.delaySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceSlider)).EndInit();
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cls2SimStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arduinoStatus)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.profileTab.ResumeLayout(false);
            this.profileTab.PerformLayout();
            this.connectionTab.ResumeLayout(false);
            this.connectionTab.PerformLayout();
            this.trimTab.ResumeLayout(false);
            this.trimTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimZ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFirmware;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.RichTextBox consoleLog;
        private System.Windows.Forms.GroupBox groupBoxLogging;
        private System.Windows.Forms.Button clearLog;
        private System.Windows.Forms.Button detectPorts;
        private System.Windows.Forms.ProgressBar uploadProgressBar;
        private System.Windows.Forms.TextBox portOption;
        private System.Windows.Forms.TextBox ipOption;
        private System.Windows.Forms.Label udpLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.CheckBox autoConnectCheck;
        private System.Windows.Forms.Label autoConnectLabel;
        private System.Windows.Forms.TrackBar forceSlider;
        private System.Windows.Forms.Label forceLabel;
        private System.Windows.Forms.GroupBox groupBoxConnect;
        private System.Windows.Forms.Label forceValue;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.PictureBox cls2SimStatus;
        private System.Windows.Forms.Label clsLabel;
        private System.Windows.Forms.PictureBox arduinoStatus;
        private System.Windows.Forms.Label arduinoLabel;
        private System.Windows.Forms.Label delayValue;
        private System.Windows.Forms.TrackBar delaySlider;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart forceChart;
        private System.Windows.Forms.Label forcesLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart positionChart;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage connectionTab;
        private System.Windows.Forms.TabPage profileTab;
        private System.Windows.Forms.CheckBox checkDefaultSpring;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAutoCLSOpen;
        private System.Windows.Forms.CheckBox AutoCLSOpenCheckBox;
        private System.Windows.Forms.Label TextCLS2SimPath;
        private System.Windows.Forms.TabPage trimTab;
        private System.Windows.Forms.Button btnDecTrimZ;
        private System.Windows.Forms.Button btnIncTrimZ;
        private System.Windows.Forms.Button ctnCenterTrimZ;
        private System.Windows.Forms.TrackBar barTrimZ;
        private System.Windows.Forms.Button btnDecTrimY;
        private System.Windows.Forms.Button btnIncTrimY;
        private System.Windows.Forms.Button ctnCenterTrimY;
        private System.Windows.Forms.TrackBar barTrimY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDecTrimX;
        private System.Windows.Forms.Button btnIncTrimX;
        private System.Windows.Forms.Button ctnCenterTrimX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar barTrimX;
        private System.Windows.Forms.CheckBox checkboxTrim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

