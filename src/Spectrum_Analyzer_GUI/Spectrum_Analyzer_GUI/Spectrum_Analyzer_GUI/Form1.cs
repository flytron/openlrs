using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spectrum_Analyzer_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // just make the window big enough to fit this graph...
            this.Width = 500;
            this.Height = 350;

            // add 5 so the bars fit properly
            int x = 240; // the position of the X axis
            int y = 0; // the position of the Y axis

            Bitmap bmp = new Bitmap(360, 290);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(new Pen(Color.Red, 2), 5, 5, 5, 250);
            g.DrawLine(new Pen(Color.Red, 2), 5, 250, 300, 250);
            // let's draw a coordinate equivalent to (20,30) (20 up, 30 across)
            g.DrawString("X", new Font("Calibri", 12), new SolidBrush(Color.Black), y + 30, x - 20);

            PictureBox display = new PictureBox();
            display.Width = 360;
            display.Height = 290;
            this.Controls.Add(display);
            display.Image = bmp;
        }
    }
}
