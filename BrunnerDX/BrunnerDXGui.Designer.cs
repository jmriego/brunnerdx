
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.groupBoxFirmware = new System.Windows.Forms.GroupBox();
            this.uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.detectPorts = new System.Windows.Forms.Button();
            this.upload = new System.Windows.Forms.Button();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.consoleLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxLogging = new System.Windows.Forms.GroupBox();
            this.clearLog = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
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
            this.groupBoxFirmware.SuspendLayout();
            this.groupBoxLogging.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delaySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceSlider)).BeginInit();
            this.groupBoxConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cls2SimStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arduinoStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFirmware
            // 
            this.groupBoxFirmware.Controls.Add(this.uploadProgressBar);
            this.groupBoxFirmware.Controls.Add(this.detectPorts);
            this.groupBoxFirmware.Controls.Add(this.upload);
            this.groupBoxFirmware.Controls.Add(this.comboPorts);
            this.groupBoxFirmware.Controls.Add(this.portLabel);
            this.groupBoxFirmware.Location = new System.Drawing.Point(10, 11);
            this.groupBoxFirmware.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxFirmware.Name = "groupBoxFirmware";
            this.groupBoxFirmware.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxFirmware.Size = new System.Drawing.Size(391, 101);
            this.groupBoxFirmware.TabIndex = 0;
            this.groupBoxFirmware.TabStop = false;
            this.groupBoxFirmware.Text = "Arduino Firmware";
            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.Location = new System.Drawing.Point(14, 67);
            this.uploadProgressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new System.Drawing.Size(363, 15);
            this.uploadProgressBar.TabIndex = 4;
            this.uploadProgressBar.Visible = false;
            // 
            // detectPorts
            // 
            this.detectPorts.Location = new System.Drawing.Point(142, 23);
            this.detectPorts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.detectPorts.Name = "detectPorts";
            this.detectPorts.Size = new System.Drawing.Size(85, 40);
            this.detectPorts.TabIndex = 3;
            this.detectPorts.Text = "Detect Ports";
            this.detectPorts.UseVisualStyleBackColor = true;
            this.detectPorts.Click += new System.EventHandler(this.detectPorts_Click);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(232, 23);
            this.upload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(92, 40);
            this.upload.TabIndex = 2;
            this.upload.Text = "Upload Firmware";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // comboPorts
            // 
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(45, 33);
            this.comboPorts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(92, 21);
            this.comboPorts.TabIndex = 1;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(11, 33);
            this.portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port";
            // 
            // consoleLog
            // 
            this.consoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleLog.Location = new System.Drawing.Point(4, 44);
            this.consoleLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.consoleLog.Name = "consoleLog";
            this.consoleLog.Size = new System.Drawing.Size(656, 150);
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
            this.groupBoxLogging.Location = new System.Drawing.Point(10, 220);
            this.groupBoxLogging.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLogging.Name = "groupBoxLogging";
            this.groupBoxLogging.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLogging.Size = new System.Drawing.Size(664, 198);
            this.groupBoxLogging.TabIndex = 3;
            this.groupBoxLogging.TabStop = false;
            this.groupBoxLogging.Text = "Logging";
            // 
            // clearLog
            // 
            this.clearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearLog.Location = new System.Drawing.Point(565, 12);
            this.clearLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(94, 28);
            this.clearLog.TabIndex = 3;
            this.clearLog.Text = "Clear Log";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.delayValue);
            this.groupBoxOptions.Controls.Add(this.delaySlider);
            this.groupBoxOptions.Controls.Add(this.delayLabel);
            this.groupBoxOptions.Controls.Add(this.forceValue);
            this.groupBoxOptions.Controls.Add(this.autoConnectCheck);
            this.groupBoxOptions.Controls.Add(this.autoConnectLabel);
            this.groupBoxOptions.Controls.Add(this.forceSlider);
            this.groupBoxOptions.Controls.Add(this.forceLabel);
            this.groupBoxOptions.Controls.Add(this.portOption);
            this.groupBoxOptions.Controls.Add(this.ipOption);
            this.groupBoxOptions.Controls.Add(this.udpLabel);
            this.groupBoxOptions.Controls.Add(this.ipLabel);
            this.groupBoxOptions.Location = new System.Drawing.Point(405, 11);
            this.groupBoxOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOptions.Size = new System.Drawing.Size(268, 206);
            this.groupBoxOptions.TabIndex = 5;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // delayValue
            // 
            this.delayValue.AutoSize = true;
            this.delayValue.Location = new System.Drawing.Point(167, 174);
            this.delayValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.delayValue.Name = "delayValue";
            this.delayValue.Size = new System.Drawing.Size(38, 13);
            this.delayValue.TabIndex = 11;
            this.delayValue.Text = "0 secs";
            this.delayValue.Visible = false;
            // 
            // delaySlider
            // 
            this.delaySlider.LargeChange = 2;
            this.delaySlider.Location = new System.Drawing.Point(114, 150);
            this.delaySlider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delaySlider.Maximum = 6;
            this.delaySlider.Name = "delaySlider";
            this.delaySlider.Size = new System.Drawing.Size(126, 45);
            this.delaySlider.TabIndex = 10;
            this.toolTip.SetToolTip(this.delaySlider, "Movement delay. Helps during the axis mappings in some games\r\nForces will be deac" +
        "tivated while using this");
            this.delaySlider.Scroll += new System.EventHandler(this.delaySlider_Scroll);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(72, 150);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(34, 13);
            this.delayLabel.TabIndex = 9;
            this.delayLabel.Text = "Delay";
            // 
            // forceValue
            // 
            this.forceValue.AutoSize = true;
            this.forceValue.Location = new System.Drawing.Point(167, 132);
            this.forceValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forceValue.Name = "forceValue";
            this.forceValue.Size = new System.Drawing.Size(19, 13);
            this.forceValue.TabIndex = 8;
            this.forceValue.Text = "30";
            // 
            // autoConnectCheck
            // 
            this.autoConnectCheck.AutoSize = true;
            this.autoConnectCheck.Location = new System.Drawing.Point(148, 81);
            this.autoConnectCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autoConnectCheck.Name = "autoConnectCheck";
            this.autoConnectCheck.Size = new System.Drawing.Size(15, 14);
            this.autoConnectCheck.TabIndex = 7;
            this.toolTip.SetToolTip(this.autoConnectCheck, "Connect on program start");
            this.autoConnectCheck.UseVisualStyleBackColor = true;
            this.autoConnectCheck.CheckedChanged += new System.EventHandler(this.autoConnectCheck_CheckedChanged);
            // 
            // autoConnectLabel
            // 
            this.autoConnectLabel.AutoSize = true;
            this.autoConnectLabel.Location = new System.Drawing.Point(54, 80);
            this.autoConnectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoConnectLabel.Name = "autoConnectLabel";
            this.autoConnectLabel.Size = new System.Drawing.Size(72, 13);
            this.autoConnectLabel.TabIndex = 6;
            this.autoConnectLabel.Text = "Auto Connect";
            // 
            // forceSlider
            // 
            this.forceSlider.LargeChange = 10;
            this.forceSlider.Location = new System.Drawing.Point(114, 109);
            this.forceSlider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.forceSlider.Maximum = 150;
            this.forceSlider.Name = "forceSlider";
            this.forceSlider.Size = new System.Drawing.Size(126, 45);
            this.forceSlider.TabIndex = 5;
            this.forceSlider.TickFrequency = 10;
            this.toolTip.SetToolTip(this.forceSlider, "Force strength");
            this.forceSlider.Value = 30;
            this.forceSlider.Scroll += new System.EventHandler(this.forceSlider_Scroll);
            // 
            // forceLabel
            // 
            this.forceLabel.AutoSize = true;
            this.forceLabel.Location = new System.Drawing.Point(77, 109);
            this.forceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forceLabel.Name = "forceLabel";
            this.forceLabel.Size = new System.Drawing.Size(34, 13);
            this.forceLabel.TabIndex = 4;
            this.forceLabel.Text = "Force";
            // 
            // portOption
            // 
            this.portOption.Location = new System.Drawing.Point(148, 50);
            this.portOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.portOption.Name = "portOption";
            this.portOption.Size = new System.Drawing.Size(76, 20);
            this.portOption.TabIndex = 3;
            this.portOption.Text = "15090";
            this.portOption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.portOption.TextChanged += new System.EventHandler(this.portOption_TextChanged);
            // 
            // ipOption
            // 
            this.ipOption.Location = new System.Drawing.Point(148, 23);
            this.ipOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ipOption.Name = "ipOption";
            this.ipOption.Size = new System.Drawing.Size(76, 20);
            this.ipOption.TabIndex = 2;
            this.ipOption.Text = "127.0.0.1";
            this.ipOption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ipOption.TextChanged += new System.EventHandler(this.ipOption_TextChanged);
            // 
            // udpLabel
            // 
            this.udpLabel.AutoSize = true;
            this.udpLabel.Location = new System.Drawing.Point(19, 52);
            this.udpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.udpLabel.Name = "udpLabel";
            this.udpLabel.Size = new System.Drawing.Size(97, 13);
            this.udpLabel.TabIndex = 1;
            this.udpLabel.Text = "CLS2Sim UDP port";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(64, 25);
            this.ipLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(63, 13);
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
            this.groupBoxConnect.Location = new System.Drawing.Point(10, 116);
            this.groupBoxConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxConnect.Size = new System.Drawing.Size(391, 101);
            this.groupBoxConnect.TabIndex = 6;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "Connect";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(312, 81);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(44, 13);
            this.positionLabel.TabIndex = 8;
            this.positionLabel.Text = "Position";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // positionChart
            // 
            chartArea9.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea9.AxisX.IsLabelAutoFit = false;
            chartArea9.AxisX.LabelStyle.Enabled = false;
            chartArea9.AxisX.MajorGrid.Enabled = false;
            chartArea9.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea9.AxisX.MajorTickMark.Enabled = false;
            chartArea9.AxisX.Maximum = 32767D;
            chartArea9.AxisX.Minimum = -32767D;
            chartArea9.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea9.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea9.AxisY.IsLabelAutoFit = false;
            chartArea9.AxisY.LabelStyle.Enabled = false;
            chartArea9.AxisY.MajorGrid.Enabled = false;
            chartArea9.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea9.AxisY.MajorTickMark.Enabled = false;
            chartArea9.AxisY.Maximum = 32767D;
            chartArea9.AxisY.Minimum = -32767D;
            chartArea9.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea9.Name = "ChartArea1";
            this.positionChart.ChartAreas.Add(chartArea9);
            legend9.Enabled = false;
            legend9.Name = "Legend1";
            this.positionChart.Legends.Add(legend9);
            this.positionChart.Location = new System.Drawing.Point(302, 14);
            this.positionChart.Name = "positionChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series9.IsVisibleInLegend = false;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            series9.Points.Add(dataPoint9);
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.positionChart.Series.Add(series9);
            this.positionChart.Size = new System.Drawing.Size(64, 64);
            this.positionChart.TabIndex = 7;
            this.positionChart.Text = "chart1";
            // 
            // forcesLabel
            // 
            this.forcesLabel.AutoSize = true;
            this.forcesLabel.Location = new System.Drawing.Point(229, 81);
            this.forcesLabel.Name = "forcesLabel";
            this.forcesLabel.Size = new System.Drawing.Size(39, 13);
            this.forcesLabel.TabIndex = 6;
            this.forcesLabel.Text = "Forces";
            this.forcesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // forceChart
            // 
            chartArea10.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea10.AxisX.IsLabelAutoFit = false;
            chartArea10.AxisX.LabelStyle.Enabled = false;
            chartArea10.AxisX.MajorGrid.Enabled = false;
            chartArea10.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea10.AxisX.MajorTickMark.Enabled = false;
            chartArea10.AxisX.Maximum = 10000D;
            chartArea10.AxisX.Minimum = -10000D;
            chartArea10.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea10.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea10.AxisY.IsLabelAutoFit = false;
            chartArea10.AxisY.LabelStyle.Enabled = false;
            chartArea10.AxisY.MajorGrid.Enabled = false;
            chartArea10.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea10.AxisY.MajorTickMark.Enabled = false;
            chartArea10.AxisY.Maximum = 10000D;
            chartArea10.AxisY.Minimum = -10000D;
            chartArea10.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea10.Name = "ChartArea1";
            this.forceChart.ChartAreas.Add(chartArea10);
            legend10.Enabled = false;
            legend10.Name = "Legend1";
            this.forceChart.Legends.Add(legend10);
            this.forceChart.Location = new System.Drawing.Point(216, 14);
            this.forceChart.Name = "forceChart";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series10.IsVisibleInLegend = false;
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            series10.Points.Add(dataPoint10);
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series10.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.forceChart.Series.Add(series10);
            this.forceChart.Size = new System.Drawing.Size(64, 64);
            this.forceChart.TabIndex = 5;
            this.forceChart.Text = "chart1";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(105, 28);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(84, 37);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // cls2SimStatus
            // 
            this.cls2SimStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cls2SimStatus.Location = new System.Drawing.Point(76, 51);
            this.cls2SimStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cls2SimStatus.Name = "cls2SimStatus";
            this.cls2SimStatus.Size = new System.Drawing.Size(13, 14);
            this.cls2SimStatus.TabIndex = 3;
            this.cls2SimStatus.TabStop = false;
            // 
            // clsLabel
            // 
            this.clsLabel.AutoSize = true;
            this.clsLabel.Location = new System.Drawing.Point(20, 52);
            this.clsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.clsLabel.Name = "clsLabel";
            this.clsLabel.Size = new System.Drawing.Size(50, 13);
            this.clsLabel.TabIndex = 2;
            this.clsLabel.Text = "CLS2Sim";
            this.clsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // arduinoStatus
            // 
            this.arduinoStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arduinoStatus.Location = new System.Drawing.Point(76, 28);
            this.arduinoStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.arduinoStatus.Name = "arduinoStatus";
            this.arduinoStatus.Size = new System.Drawing.Size(13, 14);
            this.arduinoStatus.TabIndex = 1;
            this.arduinoStatus.TabStop = false;
            // 
            // arduinoLabel
            // 
            this.arduinoLabel.AutoSize = true;
            this.arduinoLabel.Location = new System.Drawing.Point(27, 28);
            this.arduinoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.arduinoLabel.Name = "arduinoLabel";
            this.arduinoLabel.Size = new System.Drawing.Size(43, 13);
            this.arduinoLabel.TabIndex = 0;
            this.arduinoLabel.Text = "Arduino";
            this.arduinoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // BrunnerDXGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 432);
            this.Controls.Add(this.groupBoxConnect);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxLogging);
            this.Controls.Add(this.groupBoxFirmware);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BrunnerDXGui";
            this.Text = "BrunnerDX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrunnerDXGui_FormClosing);
            this.Load += new System.EventHandler(this.BrunnerDXGui_Load);
            this.groupBoxFirmware.ResumeLayout(false);
            this.groupBoxFirmware.PerformLayout();
            this.groupBoxLogging.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delaySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceSlider)).EndInit();
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cls2SimStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arduinoStatus)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBoxOptions;
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
    }
}

