
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
            this.label1 = new System.Windows.Forms.Label();
            this.consoleLog = new System.Windows.Forms.RichTextBox();
            this.groupBoxLogging = new System.Windows.Forms.GroupBox();
            this.clearLog = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.delaySlider = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.forceLabel = new System.Windows.Forms.Label();
            this.autoConnectCheck = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.forceSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.portOption = new System.Windows.Forms.TextBox();
            this.ipOption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.positionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            this.forceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.connectButton = new System.Windows.Forms.Button();
            this.cls2SimStatus = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.arduinoStatus = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxFirmware.SuspendLayout();
            this.groupBoxLogging.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delaySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forceSlider)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.groupBoxFirmware.Controls.Add(this.label1);
            this.groupBoxFirmware.Location = new System.Drawing.Point(10, 11);
            this.groupBoxFirmware.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxFirmware.Name = "groupBoxFirmware";
            this.groupBoxFirmware.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxFirmware.Size = new System.Drawing.Size(391, 101);
            this.groupBoxFirmware.TabIndex = 0;
            this.groupBoxFirmware.TabStop = false;
            this.groupBoxFirmware.Text = "Arduino Firmware";
            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.Location = new System.Drawing.Point(14, 67);
            this.uploadProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new System.Drawing.Size(363, 15);
            this.uploadProgressBar.TabIndex = 4;
            this.uploadProgressBar.Visible = false;
            // 
            // detectPorts
            // 
            this.detectPorts.Location = new System.Drawing.Point(142, 23);
            this.detectPorts.Margin = new System.Windows.Forms.Padding(2);
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
            this.upload.Margin = new System.Windows.Forms.Padding(2);
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
            this.comboPorts.Margin = new System.Windows.Forms.Padding(2);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(92, 21);
            this.comboPorts.TabIndex = 1;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // consoleLog
            // 
            this.consoleLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleLog.Location = new System.Drawing.Point(4, 44);
            this.consoleLog.Margin = new System.Windows.Forms.Padding(2);
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
            this.groupBoxLogging.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxLogging.Name = "groupBoxLogging";
            this.groupBoxLogging.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxLogging.Size = new System.Drawing.Size(664, 198);
            this.groupBoxLogging.TabIndex = 3;
            this.groupBoxLogging.TabStop = false;
            this.groupBoxLogging.Text = "Logging";
            // 
            // clearLog
            // 
            this.clearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearLog.Location = new System.Drawing.Point(565, 12);
            this.clearLog.Margin = new System.Windows.Forms.Padding(2);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(94, 28);
            this.clearLog.TabIndex = 3;
            this.clearLog.Text = "Clear Log";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.delayLabel);
            this.groupBoxOptions.Controls.Add(this.delaySlider);
            this.groupBoxOptions.Controls.Add(this.label9);
            this.groupBoxOptions.Controls.Add(this.forceLabel);
            this.groupBoxOptions.Controls.Add(this.autoConnectCheck);
            this.groupBoxOptions.Controls.Add(this.label5);
            this.groupBoxOptions.Controls.Add(this.forceSlider);
            this.groupBoxOptions.Controls.Add(this.label4);
            this.groupBoxOptions.Controls.Add(this.portOption);
            this.groupBoxOptions.Controls.Add(this.ipOption);
            this.groupBoxOptions.Controls.Add(this.label3);
            this.groupBoxOptions.Controls.Add(this.label2);
            this.groupBoxOptions.Location = new System.Drawing.Point(405, 11);
            this.groupBoxOptions.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxOptions.Size = new System.Drawing.Size(268, 206);
            this.groupBoxOptions.TabIndex = 5;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(167, 174);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(38, 13);
            this.delayLabel.TabIndex = 11;
            this.delayLabel.Text = "0 secs";
            this.delayLabel.Visible = false;
            // 
            // delaySlider
            // 
            this.delaySlider.LargeChange = 2;
            this.delaySlider.Location = new System.Drawing.Point(114, 150);
            this.delaySlider.Margin = new System.Windows.Forms.Padding(2);
            this.delaySlider.Maximum = 6;
            this.delaySlider.Name = "delaySlider";
            this.delaySlider.Size = new System.Drawing.Size(126, 45);
            this.delaySlider.TabIndex = 10;
            this.delaySlider.Visible = false;
            this.delaySlider.Scroll += new System.EventHandler(this.delaySlider_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 150);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Delay";
            this.label9.Visible = false;
            // 
            // forceLabel
            // 
            this.forceLabel.AutoSize = true;
            this.forceLabel.Location = new System.Drawing.Point(167, 132);
            this.forceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forceLabel.Name = "forceLabel";
            this.forceLabel.Size = new System.Drawing.Size(19, 13);
            this.forceLabel.TabIndex = 8;
            this.forceLabel.Text = "30";
            // 
            // autoConnectCheck
            // 
            this.autoConnectCheck.AutoSize = true;
            this.autoConnectCheck.Location = new System.Drawing.Point(148, 81);
            this.autoConnectCheck.Margin = new System.Windows.Forms.Padding(2);
            this.autoConnectCheck.Name = "autoConnectCheck";
            this.autoConnectCheck.Size = new System.Drawing.Size(15, 14);
            this.autoConnectCheck.TabIndex = 7;
            this.autoConnectCheck.UseVisualStyleBackColor = true;
            this.autoConnectCheck.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Auto Connect";
            this.label5.Visible = false;
            // 
            // forceSlider
            // 
            this.forceSlider.LargeChange = 10;
            this.forceSlider.Location = new System.Drawing.Point(114, 109);
            this.forceSlider.Margin = new System.Windows.Forms.Padding(2);
            this.forceSlider.Maximum = 80;
            this.forceSlider.Name = "forceSlider";
            this.forceSlider.Size = new System.Drawing.Size(126, 45);
            this.forceSlider.TabIndex = 5;
            this.forceSlider.TickFrequency = 10;
            this.forceSlider.Value = 30;
            this.forceSlider.Scroll += new System.EventHandler(this.forceSlider_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Force";
            // 
            // portOption
            // 
            this.portOption.Location = new System.Drawing.Point(148, 50);
            this.portOption.Margin = new System.Windows.Forms.Padding(2);
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
            this.ipOption.Margin = new System.Windows.Forms.Padding(2);
            this.ipOption.Name = "ipOption";
            this.ipOption.Size = new System.Drawing.Size(76, 20);
            this.ipOption.TabIndex = 2;
            this.ipOption.Text = "127.0.0.1";
            this.ipOption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ipOption.TextChanged += new System.EventHandler(this.ipOption_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "CLS2Sim UDP port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CLS2Sim IP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.positionChart);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.forceChart);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.cls2SimStatus);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.arduinoStatus);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(10, 116);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(391, 101);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(312, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Position";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            series3.Name = "Series1";
            series3.Points.Add(dataPoint3);
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.positionChart.Series.Add(series3);
            this.positionChart.Size = new System.Drawing.Size(64, 64);
            this.positionChart.TabIndex = 7;
            this.positionChart.Text = "chart1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(229, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Forces";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            series4.Name = "Series1";
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
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
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
            this.cls2SimStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cls2SimStatus.Name = "cls2SimStatus";
            this.cls2SimStatus.Size = new System.Drawing.Size(13, 14);
            this.cls2SimStatus.TabIndex = 3;
            this.cls2SimStatus.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "CLS2Sim";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // arduinoStatus
            // 
            this.arduinoStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arduinoStatus.Location = new System.Drawing.Point(76, 28);
            this.arduinoStatus.Margin = new System.Windows.Forms.Padding(2);
            this.arduinoStatus.Name = "arduinoStatus";
            this.arduinoStatus.Size = new System.Drawing.Size(13, 14);
            this.arduinoStatus.TabIndex = 1;
            this.arduinoStatus.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Arduino";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxLogging);
            this.Controls.Add(this.groupBoxFirmware);
            this.Margin = new System.Windows.Forms.Padding(2);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox consoleLog;
        private System.Windows.Forms.GroupBox groupBoxLogging;
        private System.Windows.Forms.Button clearLog;
        private System.Windows.Forms.Button detectPorts;
        private System.Windows.Forms.ProgressBar uploadProgressBar;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.TextBox portOption;
        private System.Windows.Forms.TextBox ipOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox autoConnectCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar forceSlider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label forceLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.PictureBox cls2SimStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox arduinoStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.TrackBar delaySlider;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart forceChart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataVisualization.Charting.Chart positionChart;
    }
}

