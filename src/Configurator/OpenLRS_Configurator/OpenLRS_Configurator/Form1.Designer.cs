namespace OpenLRS_Configurator
{
    partial class Form1
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Logbox = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.frequency_box = new System.Windows.Forms.TextBox();
            this.hoplist1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoplist2 = new System.Windows.Forms.ComboBox();
            this.hoplist3 = new System.Windows.Forms.ComboBox();
            this.PortNames = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rf_header = new System.Windows.Forms.TextBox();
            this.stepsize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.telemetry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.ParityReplace = ((byte)(67));
            this.serialPort1.ReadBufferSize = 128;
            this.serialPort1.WriteBufferSize = 128;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Logbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(554, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Logbox
            // 
            this.Logbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logbox.Location = new System.Drawing.Point(3, 3);
            this.Logbox.Multiline = true;
            this.Logbox.Name = "Logbox";
            this.Logbox.ReadOnly = true;
            this.Logbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logbox.Size = new System.Drawing.Size(548, 300);
            this.Logbox.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage1.Controls.Add(this.telemetry);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.stepsize);
            this.tabPage1.Controls.Add(this.rf_header);
            this.tabPage1.Controls.Add(this.frequency_box);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.PortNames);
            this.tabPage1.Controls.Add(this.hoplist3);
            this.tabPage1.Controls.Add(this.hoplist2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.hoplist1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(573, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Main Frequency";
            // 
            // frequency_box
            // 
            this.frequency_box.Location = new System.Drawing.Point(112, 63);
            this.frequency_box.MaxLength = 6;
            this.frequency_box.Name = "frequency_box";
            this.frequency_box.Size = new System.Drawing.Size(46, 20);
            this.frequency_box.TabIndex = 18;
            this.frequency_box.Text = "40000";
            this.frequency_box.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.frequency_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // hoplist1
            // 
            this.hoplist1.FormattingEnabled = true;
            this.hoplist1.Location = new System.Drawing.Point(112, 86);
            this.hoplist1.Name = "hoplist1";
            this.hoplist1.Size = new System.Drawing.Size(101, 21);
            this.hoplist1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Hopping Channels";
            // 
            // hoplist2
            // 
            this.hoplist2.FormattingEnabled = true;
            this.hoplist2.Location = new System.Drawing.Point(219, 86);
            this.hoplist2.Name = "hoplist2";
            this.hoplist2.Size = new System.Drawing.Size(101, 21);
            this.hoplist2.TabIndex = 21;
            // 
            // hoplist3
            // 
            this.hoplist3.FormattingEnabled = true;
            this.hoplist3.Location = new System.Drawing.Point(326, 86);
            this.hoplist3.Name = "hoplist3";
            this.hoplist3.Size = new System.Drawing.Size(101, 21);
            this.hoplist3.TabIndex = 22;
            // 
            // PortNames
            // 
            this.PortNames.FormattingEnabled = true;
            this.PortNames.Location = new System.Drawing.Point(113, 18);
            this.PortNames.Name = "PortNames";
            this.PortNames.Size = new System.Drawing.Size(121, 21);
            this.PortNames.TabIndex = 23;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(468, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(73, 23);
            this.button5.TabIndex = 27;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "RF Header (ID)";
            // 
            // rf_header
            // 
            this.rf_header.Location = new System.Drawing.Point(113, 113);
            this.rf_header.MaxLength = 4;
            this.rf_header.Name = "rf_header";
            this.rf_header.Size = new System.Drawing.Size(45, 20);
            this.rf_header.TabIndex = 29;
            this.rf_header.Text = "OLRS";
            // 
            // stepsize
            // 
            this.stepsize.FormattingEnabled = true;
            this.stepsize.Items.AddRange(new object[] {
            "0kHz",
            "10kHz",
            "20kHz",
            "30kHz",
            "40kHz",
            "50kHz",
            "60kHz",
            "70kHz",
            "80kHz",
            "90kHz",
            "100kHz"});
            this.stepsize.Location = new System.Drawing.Point(468, 86);
            this.stepsize.Name = "stepsize";
            this.stepsize.Size = new System.Drawing.Size(75, 21);
            this.stepsize.TabIndex = 31;
            this.stepsize.SelectedIndexChanged += new System.EventHandler(this.stepsize_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Step";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Com Port Name";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 34;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 209);
            this.tabControl1.TabIndex = 14;
            // 
            // telemetry
            // 
            this.telemetry.FormattingEnabled = true;
            this.telemetry.Items.AddRange(new object[] {
            "Disabled",
            "OpenLRS Telemetry (RSSI and others)",
            "Serial Bridge Mode (max. 750 bytes per seconds)",
            "War Mode 1"});
            this.telemetry.Location = new System.Drawing.Point(113, 139);
            this.telemetry.Name = "telemetry";
            this.telemetry.Size = new System.Drawing.Size(314, 21);
            this.telemetry.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(14, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Telemetry Mode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 209);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "OpenLRS Configurator v1.11";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox Logbox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stepsize;
        private System.Windows.Forms.TextBox rf_header;
        private System.Windows.Forms.TextBox frequency_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox PortNames;
        private System.Windows.Forms.ComboBox hoplist3;
        private System.Windows.Forms.ComboBox hoplist2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hoplist1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox telemetry;
        private System.Windows.Forms.Label label8;
    }
}

