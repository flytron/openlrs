using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO.Ports;

namespace ZedGraphSample
{
	public partial class Form1 : Form
	{
        Bitmap DrawArea;

        byte[] spectrum = new byte[100000];
        long read_counter = 0;
        int spectrum_done = 0;

        public Form1()
		{
			InitializeComponent();

            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = DrawArea;
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			foreach (string s in SerialPort.GetPortNames())
            {
                PortNames.Items.Add(s);
            }
            if (PortNames.Items.Count > 0) PortNames.SelectedIndex = 0;

            Graphics g;
            g = Graphics.FromImage(DrawArea);

            Pen mypen = new Pen(Brushes.Black);
            g.DrawLine(mypen, 0, 0, 200, 200);
            g.Clear(Color.White);
            g.Dispose();
		}

		

		private void Form1_Resize( object sender, EventArgs e )
		{
		}


        private void zg1_Load(object sender, EventArgs e)
        {

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


        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = serialPort1.BytesToRead;
            byte[] rx_buffer = new byte[count];
            serialPort1.Read(rx_buffer, 0, count);
            //now buf contains the bytes that were read.

            for (uint i = 0; i < count; i++)
            {
                if (rx_buffer[i] == 255)
                {
                    read_counter = 0;
                    spectrum_done = 1;

                }
                spectrum[read_counter++] = rx_buffer[i];
            }
               
        }

        


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (spectrum_done == 1)
            {
                Graphics g;
                g = Graphics.FromImage(DrawArea);

                SolidBrush WhiteBrush = new SolidBrush(Color.White);

                Pen mypen = new Pen(Color.Black);

                g.FillRectangle(WhiteBrush, 0, 0, 700, 700);

                for (uint i = 0; i < 820; i++)
                {
                    g.DrawLine(mypen, i, 300 - spectrum[i], i + 1, 300 - spectrum[i + 1]); ;
                }
                pictureBox1.Image = DrawArea;

                g.Dispose();
                spectrum_done = 0;
            }
        }
	}
}