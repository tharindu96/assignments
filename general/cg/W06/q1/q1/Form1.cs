using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace q1
{
    public partial class Form1 : Form
    {

        float x1, x2, x3, y1, y2, y3;
        float x, y;

        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayPoint(float x, float y)
        {
            Graphics g = pnlMain.CreateGraphics();
            g.DrawLine(Pens.Black, x, pnlMain.Height - y, x + 0.1F, pnlMain.Height - y);
        }

        private void DisplayLine(float x1, float y1, float x2, float y2)
        {
            Graphics g = pnlMain.CreateGraphics();
            if ((x1 == x2) && (y1 == y2))
            {
                DisplayPoint(x1, y1);
            }
            else
            {
                g.DrawLine(Pens.Black, x1, pnlMain.Height - y1, x2, pnlMain.Height - y2);
            }
        }



        private void btnDrawT_Click(object sender, EventArgs e)
        {
            try
            {
                x1 = float.Parse(txtX1.Text);
                x2 = float.Parse(txtX2.Text);
                x3 = float.Parse(txtX3.Text);
                y1 = float.Parse(txtY1.Text);
                y2 = float.Parse(txtY2.Text);
                y3 = float.Parse(txtY3.Text);

                DisplayLine(x1, y1, x2, y2);
                DisplayLine(x2, y2, x3, y3);
                DisplayLine(x3, y3, x1, y1);
            }
            catch
            {
                MessageBox.Show("Please enter numbers!");
            }
        }

        private void btnDrawP_Click(object sender, EventArgs e)
        {
            try
            {
                x = float.Parse(txtX.Text);
                y = float.Parse(txtY.Text);

                DisplayPoint(x, y);
            }
            catch
            {
                MessageBox.Show("Please enter numbers!");
            }
        }

        private float getT(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            return x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            float t, t1, t2, t3;
            t = getT(x1, y1, x2, y2, x3, y3);

            t1 = getT(x1, y1, x2, y2, x, y);
            if (t * t1 <= 0)
            {
                lblStatus.Text = "Outside";
                return;
            }

            t2 = getT(x3, y3, x1, y1, x, y);
            if (t * t2 <= 0)
            {
                lblStatus.Text = "Outside";
                return;
            }

            t3 = getT(x2, y2, x3, y3, x, y);
            if (t * t3 <= 0)
            {
                lblStatus.Text = "Outside";
                return;
            }

            lblStatus.Text = "Inside";
        }
    }
}
