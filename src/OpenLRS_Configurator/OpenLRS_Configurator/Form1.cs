using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace OpenLRS_Configurator
{
    public partial class Form1 : Form
    {
       int read_counter = -1;
       int write_counter = -1;
       byte[] conf_buffer = new byte[250];
       int reading = 0;
       int writing = 0;


       private void Write_to_Fields()
       {
           frequency_box.Text = (400000 + (int)(conf_buffer[0] * 256) + (int)conf_buffer[1]).ToString();
           stepsize.SelectedIndex = conf_buffer[2] ;

           rf_header.Text = ""+(char)conf_buffer[6] + (char)conf_buffer[7] + (char)conf_buffer[8] + (char)conf_buffer[9];
           
           telemetry.SelectedIndex = conf_buffer[11];

           Freq_calculate();

           Logbox.AppendText("###########Reading STARTED###########" + "\r\n");
           for (uint i = 0; i < 100; i++)
               Logbox.AppendText(i + ":" +conf_buffer[i] + "\r\n");
           Logbox.AppendText("###########Reading DONE###########" + "\r\n");

       }

       private void Freq_calculate()
       {
           hoplist1.Items.Clear();
           hoplist2.Items.Clear();
           hoplist3.Items.Clear();
           String frekans_text;
           for (uint i = 0; i < 256; i++)
           {
               frekans_text = i + " - " + String.Format("{0:0,0}", (Int32.Parse(frequency_box.Text) + (i * 10 * stepsize.SelectedIndex))) + "Mhz";
               hoplist1.Items.Add(frekans_text);
               hoplist2.Items.Add(frekans_text);
               hoplist3.Items.Add(frekans_text);
           }
           hoplist1.SelectedIndex = conf_buffer[3];
           hoplist2.SelectedIndex = conf_buffer[4];
           hoplist3.SelectedIndex = conf_buffer[5];
       }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
                    {
                        serialPort1.PortName = PortNames.Text;
                        serialPort1.Open();
                        serialPort1.Encoding = System.Text.Encoding.GetEncoding(28591); //ISO 8859-1.
                    }
            serialPort1.DtrEnable = true;
            System.Threading.Thread.Sleep(10);
            serialPort1.DtrEnable = false;
            System.Threading.Thread.Sleep(10);

            Logbox.Clear();
            read_counter = 0;
            reading = -1;
            button1.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (frequency_box.Text.Length == 6)
                {
                    Freq_calculate();

                }
            }
        }

        private void hoplist1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            foreach (string s in SerialPort.GetPortNames())
            {
                PortNames.Items.Add(s);
            }
            if (PortNames.Items.Count>0) PortNames.SelectedIndex = 0;
 
        }

        private void PortNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = serialPort1.BytesToRead;
            byte[] rx_buffer = new byte[count];
            serialPort1.Read(rx_buffer,0, count);
            //now buf contains the bytes that were read.

            if (reading == 1)
            {
                for (uint i = 0; i < count; i++)
                    conf_buffer[read_counter++] = rx_buffer[i];
                if (read_counter > 100) //100 byte received
                {
                    try
                    {
                    Invoke((MethodInvoker)delegate()
                    {
                        Write_to_Fields();
                        button1.Enabled = true;
                    });
                    }
                    catch (Exception ex)
                    {
                    }
                    serialPort1.DtrEnable = true;
                    System.Threading.Thread.Sleep(10);
                    serialPort1.DtrEnable = false;
                    System.Threading.Thread.Sleep(10);
                    serialPort1.Close();
                    reading = 0;
                }
            }

            if (rx_buffer.Length == 3)
            {

                if ((rx_buffer[0] == 'W') && (rx_buffer[1] == '4') && (rx_buffer[2] == 'E'))
                {
                    serialPort1.Write("R4T");
                    System.Threading.Thread.Sleep(500);
                    if (reading == -1)
                    {
                        read_counter = 0;
                        reading = 1;
                        serialPort1.Write("RRR");
                    }
                    if (writing == -1)
                    {
                        serialPort1.Write("WWW");
                        for (uint i = 0; i < 100; i++)
                            {
                            serialPort1.Write((char)conf_buffer[i] + "");
                            System.Threading.Thread.Sleep(1);
                            }
                        
    
                        writing = 0;
                        try
                        {
                        Invoke((MethodInvoker)delegate()
                        { 
                            button2.Enabled = true; });
                            Logbox.AppendText("###########Writing STARTED###########" + "\r\n");
                            for (uint i = 0; i < 100; i++)
                            Logbox.AppendText(i + ":" + conf_buffer[i] + "\r\n");
                            Logbox.AppendText("###########Writing DONE###########" + "\r\n");
                        }
                        catch (Exception ex)
                        {
                        }
                        serialPort1.DtrEnable = true;
                        System.Threading.Thread.Sleep(10);
                        serialPort1.DtrEnable = false;
                        System.Threading.Thread.Sleep(10);
                        serialPort1.Close();
                    }
                }

                /*
                try
                {
                    Invoke((MethodInvoker)delegate()
                    {

                        if (rx_buffer[0] == 'D')
                            {
                                string Data_Pack = (byte)rx_buffer[1] + ":" + (byte)rx_buffer[2] + "\r\n";
                                //textBox2.AppendText(Data_Pack);
                                conf_buffer[(byte)rx_buffer[1]] = (byte)rx_buffer[2];
                            }
                    });
                }
                catch (Exception ex)
                {
                }
                 */
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //channels
            conf_buffer[0] = (byte)((Int32.Parse(frequency_box.Text) - 400000) / 256);
            conf_buffer[1] = (byte)((Int32.Parse(frequency_box.Text) - 400000) % 256);
            conf_buffer[2] = (byte)stepsize.SelectedIndex;
            //hopping
            conf_buffer[3] = (byte)hoplist1.SelectedIndex;
            conf_buffer[4] = (byte)hoplist2.SelectedIndex;
            conf_buffer[5] = (byte)hoplist3.SelectedIndex;

            //RF Header
            conf_buffer[6] = (byte)rf_header.Text[0];
            conf_buffer[7] = (byte)rf_header.Text[1];
            conf_buffer[8] = (byte)rf_header.Text[2];
            conf_buffer[9] = (byte)rf_header.Text[3];

            //telemetry
            conf_buffer[11] = (byte)telemetry.SelectedIndex;

            for (uint i = 100; i < 250; i++)
                conf_buffer[i] = 0;


            if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = PortNames.Text;
                serialPort1.Open();
                serialPort1.Encoding = System.Text.Encoding.GetEncoding(28591); //ISO 8859-1.
            }
            serialPort1.DtrEnable = true;
            System.Threading.Thread.Sleep(10);
            serialPort1.DtrEnable = false;
            System.Threading.Thread.Sleep(10);

            write_counter = 0;
            writing = -1;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = PortNames.Text;
                serialPort1.Open();
                serialPort1.Encoding = System.Text.Encoding.GetEncoding(28591); //ISO 8859-1.
            }
            serialPort1.DtrEnable = true;
            System.Threading.Thread.Sleep(10);
            serialPort1.DtrEnable = false;
            System.Threading.Thread.Sleep(10);
            serialPort1.Close();
        }



        private void stepsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Freq_calculate();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        
    }
}
