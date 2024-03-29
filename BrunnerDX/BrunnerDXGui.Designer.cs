﻿
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
            this.btnDecTrimY = new System.Windows.Forms.Button();
            this.btnIncTrimY = new System.Windows.Forms.Button();
            this.btnDecTrimX = new System.Windows.Forms.Button();
            this.btnIncTrimX = new System.Windows.Forms.Button();
            this.btnCenterTrim = new System.Windows.Forms.Button();
            this.btnReleaseTrim = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.profileTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionTab = new System.Windows.Forms.TabPage();
            this.TextCLS2SimPath = new System.Windows.Forms.Label();
            this.labelAutoCLSOpen = new System.Windows.Forms.Label();
            this.trimTab = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.barTrimStrengthZ = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.barTrimStrengthXY = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.barTrimStrengthZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimStrengthXY)).BeginInit();
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
            this.consoleLog.Size = new System.Drawing.Size(769, 202);
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
            this.groupBoxLogging.Location = new System.Drawing.Point(10, 234);
            this.groupBoxLogging.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLogging.Name = "groupBoxLogging";
            this.groupBoxLogging.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLogging.Size = new System.Drawing.Size(777, 250);
            this.groupBoxLogging.TabIndex = 3;
            this.groupBoxLogging.TabStop = false;
            this.groupBoxLogging.Text = "Logging";
            // 
            // clearLog
            // 
            this.clearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearLog.Location = new System.Drawing.Point(678, 12);
            this.clearLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(94, 28);
            this.clearLog.TabIndex = 3;
            this.clearLog.Text = "Clear Log";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // delayValue
            // 
            this.delayValue.AutoSize = true;
            this.delayValue.Location = new System.Drawing.Point(302, 108);
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
            this.delaySlider.Location = new System.Drawing.Point(91, 98);
            this.delaySlider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delaySlider.Maximum = 6;
            this.delaySlider.Name = "delaySlider";
            this.delaySlider.Size = new System.Drawing.Size(206, 45);
            this.delaySlider.TabIndex = 10;
            this.toolTip.SetToolTip(this.delaySlider, "Movement delay. Helps during the axis mappings in some games\r\nForces will be deac" +
        "tivated while using this");
            this.delaySlider.Scroll += new System.EventHandler(this.delaySlider_Scroll);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(48, 108);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(34, 13);
            this.delayLabel.TabIndex = 9;
            this.delayLabel.Text = "Delay";
            // 
            // forceValue
            // 
            this.forceValue.AutoSize = true;
            this.forceValue.Location = new System.Drawing.Point(302, 43);
            this.forceValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forceValue.Name = "forceValue";
            this.forceValue.Size = new System.Drawing.Size(19, 13);
            this.forceValue.TabIndex = 8;
            this.forceValue.Text = "30";
            // 
            // autoConnectCheck
            // 
            this.autoConnectCheck.AutoSize = true;
            this.autoConnectCheck.Location = new System.Drawing.Point(163, 129);
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
            this.autoConnectLabel.Location = new System.Drawing.Point(70, 129);
            this.autoConnectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoConnectLabel.Name = "autoConnectLabel";
            this.autoConnectLabel.Size = new System.Drawing.Size(72, 13);
            this.autoConnectLabel.TabIndex = 6;
            this.autoConnectLabel.Text = "Auto Connect";
            // 
            // forceSlider
            // 
            this.forceSlider.LargeChange = 10;
            this.forceSlider.Location = new System.Drawing.Point(91, 33);
            this.forceSlider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.forceSlider.Maximum = 150;
            this.forceSlider.Name = "forceSlider";
            this.forceSlider.Size = new System.Drawing.Size(206, 45);
            this.forceSlider.TabIndex = 5;
            this.forceSlider.TickFrequency = 10;
            this.toolTip.SetToolTip(this.forceSlider, "Force strength");
            this.forceSlider.Value = 30;
            this.forceSlider.Scroll += new System.EventHandler(this.forceSlider_Scroll);
            // 
            // forceLabel
            // 
            this.forceLabel.AutoSize = true;
            this.forceLabel.Location = new System.Drawing.Point(53, 43);
            this.forceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forceLabel.Name = "forceLabel";
            this.forceLabel.Size = new System.Drawing.Size(34, 13);
            this.forceLabel.TabIndex = 4;
            this.forceLabel.Text = "Force";
            // 
            // portOption
            // 
            this.portOption.Location = new System.Drawing.Point(163, 63);
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
            this.ipOption.Location = new System.Drawing.Point(163, 32);
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
            this.udpLabel.Location = new System.Drawing.Point(44, 67);
            this.udpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.udpLabel.Name = "udpLabel";
            this.udpLabel.Size = new System.Drawing.Size(97, 13);
            this.udpLabel.TabIndex = 1;
            this.udpLabel.Text = "CLS2Sim UDP port";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(79, 37);
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
            this.groupBoxConnect.Size = new System.Drawing.Size(391, 118);
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
            this.positionChart.Location = new System.Drawing.Point(302, 14);
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
            this.forceChart.Location = new System.Drawing.Point(216, 14);
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
            // checkDefaultSpring
            // 
            this.checkDefaultSpring.AutoSize = true;
            this.checkDefaultSpring.Location = new System.Drawing.Point(98, 158);
            this.checkDefaultSpring.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkDefaultSpring.Name = "checkDefaultSpring";
            this.checkDefaultSpring.Size = new System.Drawing.Size(15, 14);
            this.checkDefaultSpring.TabIndex = 3;
            this.toolTip.SetToolTip(this.checkDefaultSpring, "Start a centering spring effect when there\'s no sim running and BrunnerDX is conn" +
        "ected");
            this.checkDefaultSpring.UseVisualStyleBackColor = true;
            this.checkDefaultSpring.CheckedChanged += new System.EventHandler(this.checkDefaultSpring_CheckedChanged);
            // 
            // AutoCLSOpenCheckBox
            // 
            this.AutoCLSOpenCheckBox.AutoSize = true;
            this.AutoCLSOpenCheckBox.Location = new System.Drawing.Point(163, 98);
            this.AutoCLSOpenCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AutoCLSOpenCheckBox.Name = "AutoCLSOpenCheckBox";
            this.AutoCLSOpenCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoCLSOpenCheckBox.TabIndex = 12;
            this.toolTip.SetToolTip(this.AutoCLSOpenCheckBox, "Open CLS2Sim on External Control mode on program start");
            this.AutoCLSOpenCheckBox.UseVisualStyleBackColor = true;
            this.AutoCLSOpenCheckBox.CheckedChanged += new System.EventHandler(this.AutoCLSOpenCheckBox_CheckedChanged);
            // 
            // btnDecTrimY
            // 
            this.btnDecTrimY.Location = new System.Drawing.Point(149, 67);
            this.btnDecTrimY.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecTrimY.Name = "btnDecTrimY";
            this.btnDecTrimY.Size = new System.Drawing.Size(43, 28);
            this.btnDecTrimY.TabIndex = 9;
            this.btnDecTrimY.Text = "?";
            this.toolTip.SetToolTip(this.btnDecTrimY, "Map button to trim nose up");
            this.btnDecTrimY.UseVisualStyleBackColor = true;
            this.btnDecTrimY.Click += new System.EventHandler(this.btnTrimMapping_Click);
            // 
            // btnIncTrimY
            // 
            this.btnIncTrimY.Location = new System.Drawing.Point(149, 3);
            this.btnIncTrimY.Margin = new System.Windows.Forms.Padding(2);
            this.btnIncTrimY.Name = "btnIncTrimY";
            this.btnIncTrimY.Size = new System.Drawing.Size(43, 28);
            this.btnIncTrimY.TabIndex = 8;
            this.btnIncTrimY.Text = "?";
            this.toolTip.SetToolTip(this.btnIncTrimY, "Map button to trim nose down");
            this.btnIncTrimY.UseVisualStyleBackColor = true;
            this.btnIncTrimY.Click += new System.EventHandler(this.btnTrimMapping_Click);
            // 
            // btnDecTrimX
            // 
            this.btnDecTrimX.Location = new System.Drawing.Point(104, 35);
            this.btnDecTrimX.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecTrimX.Name = "btnDecTrimX";
            this.btnDecTrimX.Size = new System.Drawing.Size(43, 28);
            this.btnDecTrimX.TabIndex = 4;
            this.btnDecTrimX.Text = "?";
            this.toolTip.SetToolTip(this.btnDecTrimX, "Map button to trim roll left");
            this.btnDecTrimX.UseVisualStyleBackColor = true;
            this.btnDecTrimX.Click += new System.EventHandler(this.btnTrimMapping_Click);
            // 
            // btnIncTrimX
            // 
            this.btnIncTrimX.Location = new System.Drawing.Point(195, 35);
            this.btnIncTrimX.Margin = new System.Windows.Forms.Padding(2);
            this.btnIncTrimX.Name = "btnIncTrimX";
            this.btnIncTrimX.Size = new System.Drawing.Size(43, 28);
            this.btnIncTrimX.TabIndex = 3;
            this.btnIncTrimX.Text = "?";
            this.toolTip.SetToolTip(this.btnIncTrimX, "Map button to trim roll right");
            this.btnIncTrimX.UseVisualStyleBackColor = true;
            this.btnIncTrimX.Click += new System.EventHandler(this.btnTrimMapping_Click);
            // 
            // btnCenterTrim
            // 
            this.btnCenterTrim.Location = new System.Drawing.Point(324, 8);
            this.btnCenterTrim.Margin = new System.Windows.Forms.Padding(2);
            this.btnCenterTrim.Name = "btnCenterTrim";
            this.btnCenterTrim.Size = new System.Drawing.Size(43, 28);
            this.btnCenterTrim.TabIndex = 22;
            this.btnCenterTrim.Text = "?";
            this.toolTip.SetToolTip(this.btnCenterTrim, "Map button to center trimming");
            this.btnCenterTrim.UseVisualStyleBackColor = true;
            this.btnCenterTrim.Click += new System.EventHandler(this.btnTrimMapping_Click);
            // 
            // btnReleaseTrim
            // 
            this.btnReleaseTrim.Location = new System.Drawing.Point(324, 58);
            this.btnReleaseTrim.Margin = new System.Windows.Forms.Padding(2);
            this.btnReleaseTrim.Name = "btnReleaseTrim";
            this.btnReleaseTrim.Size = new System.Drawing.Size(43, 28);
            this.btnReleaseTrim.TabIndex = 24;
            this.btnReleaseTrim.Text = "?";
            this.toolTip.SetToolTip(this.btnReleaseTrim, "Map button to release trimming");
            this.btnReleaseTrim.UseVisualStyleBackColor = true;
            this.btnReleaseTrim.Click += new System.EventHandler(this.btnTrimMapping_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.profileTab);
            this.tabControl1.Controls.Add(this.connectionTab);
            this.tabControl1.Controls.Add(this.trimTab);
            this.tabControl1.Location = new System.Drawing.Point(405, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 223);
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
            this.profileTab.Location = new System.Drawing.Point(4, 22);
            this.profileTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.profileTab.Size = new System.Drawing.Size(376, 197);
            this.profileTab.TabIndex = 1;
            this.profileTab.Text = "Profile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
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
            this.connectionTab.Location = new System.Drawing.Point(4, 22);
            this.connectionTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectionTab.Name = "connectionTab";
            this.connectionTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectionTab.Size = new System.Drawing.Size(376, 197);
            this.connectionTab.TabIndex = 0;
            this.connectionTab.Text = "Connection";
            // 
            // TextCLS2SimPath
            // 
            this.TextCLS2SimPath.AutoSize = true;
            this.TextCLS2SimPath.Location = new System.Drawing.Point(181, 98);
            this.TextCLS2SimPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextCLS2SimPath.Name = "TextCLS2SimPath";
            this.TextCLS2SimPath.Size = new System.Drawing.Size(312, 13);
            this.TextCLS2SimPath.TabIndex = 14;
            this.TextCLS2SimPath.Text = "C:\\Program Files (x86)\\Brunner Elektronik AG\\CLS2Sim\\Settings";
            // 
            // labelAutoCLSOpen
            // 
            this.labelAutoCLSOpen.AutoSize = true;
            this.labelAutoCLSOpen.Location = new System.Drawing.Point(62, 98);
            this.labelAutoCLSOpen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAutoCLSOpen.Name = "labelAutoCLSOpen";
            this.labelAutoCLSOpen.Size = new System.Drawing.Size(79, 13);
            this.labelAutoCLSOpen.TabIndex = 13;
            this.labelAutoCLSOpen.Text = "Open CLS2Sim";
            // 
            // trimTab
            // 
            this.trimTab.BackColor = System.Drawing.Color.Transparent;
            this.trimTab.Controls.Add(this.label6);
            this.trimTab.Controls.Add(this.btnReleaseTrim);
            this.trimTab.Controls.Add(this.label4);
            this.trimTab.Controls.Add(this.btnCenterTrim);
            this.trimTab.Controls.Add(this.barTrimStrengthZ);
            this.trimTab.Controls.Add(this.label2);
            this.trimTab.Controls.Add(this.barTrimStrengthXY);
            this.trimTab.Controls.Add(this.label5);
            this.trimTab.Controls.Add(this.btnDecTrimY);
            this.trimTab.Controls.Add(this.btnIncTrimY);
            this.trimTab.Controls.Add(this.label3);
            this.trimTab.Controls.Add(this.btnDecTrimX);
            this.trimTab.Controls.Add(this.btnIncTrimX);
            this.trimTab.Location = new System.Drawing.Point(4, 22);
            this.trimTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trimTab.Name = "trimTab";
            this.trimTab.Size = new System.Drawing.Size(376, 197);
            this.trimTab.TabIndex = 2;
            this.trimTab.Text = "Trim";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Trim release";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Trim center";
            // 
            // barTrimStrengthZ
            // 
            this.barTrimStrengthZ.LargeChange = 10;
            this.barTrimStrengthZ.Location = new System.Drawing.Point(149, 152);
            this.barTrimStrengthZ.Margin = new System.Windows.Forms.Padding(2);
            this.barTrimStrengthZ.Maximum = 100;
            this.barTrimStrengthZ.Name = "barTrimStrengthZ";
            this.barTrimStrengthZ.Size = new System.Drawing.Size(218, 45);
            this.barTrimStrengthZ.TabIndex = 21;
            this.barTrimStrengthZ.TickFrequency = 10;
            this.toolTip.SetToolTip(this.barTrimStrengthZ, "Percentage of the main force setting to be used in returning to center");
            this.barTrimStrengthZ.Scroll += new System.EventHandler(this.barTrimStrengthZ_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rudder Centering Strength";
            // 
            // barTrimStrengthXY
            // 
            this.barTrimStrengthXY.LargeChange = 10;
            this.barTrimStrengthXY.Location = new System.Drawing.Point(149, 104);
            this.barTrimStrengthXY.Margin = new System.Windows.Forms.Padding(2);
            this.barTrimStrengthXY.Maximum = 100;
            this.barTrimStrengthXY.Name = "barTrimStrengthXY";
            this.barTrimStrengthXY.Size = new System.Drawing.Size(218, 45);
            this.barTrimStrengthXY.TabIndex = 19;
            this.barTrimStrengthXY.TickFrequency = 10;
            this.toolTip.SetToolTip(this.barTrimStrengthXY, "Percentage of the main force setting to be used in returning to center");
            this.barTrimStrengthXY.Scroll += new System.EventHandler(this.barTrimStrengthXY_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Roll/Pitch Strength";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Button Mapping";
            // 
            // BrunnerDXGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 491);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBoxConnect);
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
            ((System.ComponentModel.ISupportInitialize)(this.barTrimStrengthZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTrimStrengthXY)).EndInit();
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
        private System.Windows.Forms.Button btnDecTrimY;
        private System.Windows.Forms.Button btnIncTrimY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDecTrimX;
        private System.Windows.Forms.Button btnIncTrimX;
        private System.Windows.Forms.TrackBar barTrimStrengthXY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar barTrimStrengthZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCenterTrim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReleaseTrim;
        private System.Windows.Forms.Label label4;
    }
}

