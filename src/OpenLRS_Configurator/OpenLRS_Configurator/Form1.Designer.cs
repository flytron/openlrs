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
            this.button3 = new System.Windows.Forms.Button();
            this.telemetry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stepsize = new System.Windows.Forms.ComboBox();
            this.rf_header = new System.Windows.Forms.TextBox();
            this.frequency_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PortNames = new System.Windows.Forms.ComboBox();
            this.hoplist3 = new System.Windows.Forms.ComboBox();
            this.hoplist2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoplist1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.ParityReplace = ((byte)(67));
            this.serialPort1.ReadBufferSize = 128;
            this.serialPort1.WriteBufferSize = 128;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(480, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 54;
            this.button3.Text = "Set Defaults";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // telemetry
            // 
            this.telemetry.FormattingEnabled = true;
            this.telemetry.Items.AddRange(new object[] {
            "Disabled",
            "OpenLRS Telemetry (RSSI and others)",
            "Serial Bridge Mode (max. 750 bytes per seconds)",
            "War Mode 1"});
            this.telemetry.Location = new System.Drawing.Point(125, 155);
            this.telemetry.Name = "telemetry";
            this.telemetry.Size = new System.Drawing.Size(314, 21);
            this.telemetry.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(26, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Telemetry Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Com Port Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Step";
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
            this.stepsize.Location = new System.Drawing.Point(480, 102);
            this.stepsize.Name = "stepsize";
            this.stepsize.Size = new System.Drawing.Size(75, 21);
            this.stepsize.TabIndex = 49;
            this.stepsize.SelectedIndexChanged += new System.EventHandler(this.stepsize_SelectedIndexChanged);
            this.stepsize.TabIndexChanged += new System.EventHandler(this.stepsize_SelectedIndexChanged);
            // 
            // rf_header
            // 
            this.rf_header.Location = new System.Drawing.Point(125, 129);
            this.rf_header.MaxLength = 4;
            this.rf_header.Name = "rf_header";
            this.rf_header.Size = new System.Drawing.Size(45, 20);
            this.rf_header.TabIndex = 48;
            this.rf_header.Text = "OLRS";
            // 
            // frequency_box
            // 
            this.frequency_box.Location = new System.Drawing.Point(124, 79);
            this.frequency_box.MaxLength = 6;
            this.frequency_box.Name = "frequency_box";
            this.frequency_box.Size = new System.Drawing.Size(46, 20);
            this.frequency_box.TabIndex = 41;
            this.frequency_box.Text = "40000";
            this.frequency_box.TextChanged += new System.EventHandler(this.frequency_box_TextChanged);
            this.frequency_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "RF Header (ID)";
            // 
            // PortNames
            // 
            this.PortNames.FormattingEnabled = true;
            this.PortNames.Location = new System.Drawing.Point(125, 34);
            this.PortNames.Name = "PortNames";
            this.PortNames.Size = new System.Drawing.Size(121, 21);
            this.PortNames.TabIndex = 46;
            // 
            // hoplist3
            // 
            this.hoplist3.FormattingEnabled = true;
            this.hoplist3.Location = new System.Drawing.Point(338, 102);
            this.hoplist3.Name = "hoplist3";
            this.hoplist3.Size = new System.Drawing.Size(101, 21);
            this.hoplist3.TabIndex = 45;
            // 
            // hoplist2
            // 
            this.hoplist2.FormattingEnabled = true;
            this.hoplist2.Location = new System.Drawing.Point(231, 102);
            this.hoplist2.Name = "hoplist2";
            this.hoplist2.Size = new System.Drawing.Size(101, 21);
            this.hoplist2.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Hopping Channels";
            // 
            // hoplist1
            // 
            this.hoplist1.FormattingEnabled = true;
            this.hoplist1.Location = new System.Drawing.Point(124, 102);
            this.hoplist1.Name = "hoplist1";
            this.hoplist1.Size = new System.Drawing.Size(101, 21);
            this.hoplist1.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Main Frequency";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 209);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.telemetry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stepsize);
            this.Controls.Add(this.rf_header);
            this.Controls.Add(this.frequency_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PortNames);
            this.Controls.Add(this.hoplist3);
            this.Controls.Add(this.hoplist2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hoplist1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "OpenLRS Configurator v1.01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox telemetry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stepsize;
        private System.Windows.Forms.TextBox rf_header;
        private System.Windows.Forms.TextBox frequency_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PortNames;
        private System.Windows.Forms.ComboBox hoplist3;
        private System.Windows.Forms.ComboBox hoplist2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hoplist1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

