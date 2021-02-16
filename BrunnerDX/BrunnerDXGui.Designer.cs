
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
            this.groupBoxFirmware = new System.Windows.Forms.GroupBox();
            this.detectPorts = new System.Windows.Forms.Button();
            this.upload = new System.Windows.Forms.Button();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logger = new System.Windows.Forms.RichTextBox();
            this.groupBoxLogging = new System.Windows.Forms.GroupBox();
            this.clearLog = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBoxFirmware.SuspendLayout();
            this.groupBoxLogging.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFirmware
            // 
            this.groupBoxFirmware.Controls.Add(this.progressBar1);
            this.groupBoxFirmware.Controls.Add(this.detectPorts);
            this.groupBoxFirmware.Controls.Add(this.upload);
            this.groupBoxFirmware.Controls.Add(this.comboPorts);
            this.groupBoxFirmware.Controls.Add(this.label1);
            this.groupBoxFirmware.Location = new System.Drawing.Point(13, 13);
            this.groupBoxFirmware.Name = "groupBoxFirmware";
            this.groupBoxFirmware.Size = new System.Drawing.Size(468, 124);
            this.groupBoxFirmware.TabIndex = 0;
            this.groupBoxFirmware.TabStop = false;
            this.groupBoxFirmware.Text = "Arduino Firmware";
            // 
            // detectPorts
            // 
            this.detectPorts.Location = new System.Drawing.Point(202, 41);
            this.detectPorts.Name = "detectPorts";
            this.detectPorts.Size = new System.Drawing.Size(75, 24);
            this.detectPorts.TabIndex = 3;
            this.detectPorts.Text = "Detect Ports";
            this.detectPorts.UseVisualStyleBackColor = true;
            this.detectPorts.Click += new System.EventHandler(this.detectPorts_Click);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(284, 41);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(122, 24);
            this.upload.TabIndex = 2;
            this.upload.Text = "Upload Firmware";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // comboPorts
            // 
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(60, 41);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(121, 24);
            this.comboPorts.TabIndex = 1;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // logger
            // 
            this.logger.Location = new System.Drawing.Point(6, 38);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(763, 111);
            this.logger.TabIndex = 2;
            this.logger.Text = "";
            // 
            // groupBoxLogging
            // 
            this.groupBoxLogging.Controls.Add(this.clearLog);
            this.groupBoxLogging.Controls.Add(this.logger);
            this.groupBoxLogging.Location = new System.Drawing.Point(13, 280);
            this.groupBoxLogging.Name = "groupBoxLogging";
            this.groupBoxLogging.Size = new System.Drawing.Size(775, 158);
            this.groupBoxLogging.TabIndex = 3;
            this.groupBoxLogging.TabStop = false;
            this.groupBoxLogging.Text = "Logging";
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(694, 9);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(75, 23);
            this.clearLog.TabIndex = 3;
            this.clearLog.Text = "Clear Log";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(423, 19);
            this.progressBar1.TabIndex = 4;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.textBox2);
            this.groupBoxOptions.Controls.Add(this.textBox1);
            this.groupBoxOptions.Controls.Add(this.label3);
            this.groupBoxOptions.Controls.Add(this.label2);
            this.groupBoxOptions.Location = new System.Drawing.Point(487, 13);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(255, 124);
            this.groupBoxOptions.TabIndex = 5;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CLS2Sim IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "CLS2Sim UDP port";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "127.0.0.1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "15090";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BrunnerDXGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxLogging);
            this.Controls.Add(this.groupBoxFirmware);
            this.Name = "BrunnerDXGui";
            this.Text = "BrunnerDX";
            this.Load += new System.EventHandler(this.BrunnerDXGui_Load);
            this.groupBoxFirmware.ResumeLayout(false);
            this.groupBoxFirmware.PerformLayout();
            this.groupBoxLogging.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFirmware;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox logger;
        private System.Windows.Forms.GroupBox groupBoxLogging;
        private System.Windows.Forms.Button clearLog;
        private System.Windows.Forms.Button detectPorts;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

