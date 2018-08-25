using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace line_intersection
{
    public partial class Form1 : Form
    {

        float x1, y1, x2, y2, x3, y3, x4, y4;

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

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                x1 = float.Parse(txtX1.Text);
                y1 = float.Parse(txtY1.Text);
                x2 = float.Parse(txtX2.Text);
                y2 = float.Parse(txtY2.Text);
                x3 = float.Parse(txtX3.Text);
                y3 = float.Parse(txtY3.Text);
                x4 = float.Parse(txtX4.Text);
                y4 = float.Parse(txtY4.Text);

                DisplayLine(x1, y1, x2, y2);
                DisplayLine(x3, y3, x4, y4);
            }
            catch
            {
                MessageBox.Show("Enter Only Numbers!");
            }
        }

        private bool onSegment(float x1, float y1, float x2, float y2, float x, float y)
        {
            float ux = Math.Max(x1, x2);
            float lx = Math.Min(x1, x2);
            float uy = Math.Max(y1, y2);
            float ly = Math.Max(y1, y2);
            if (x <= ux && x >= lx && y <= uy && y >= ly)
                return true;
            return false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            float t1, t2, t3, t4;

            t1 = getT(x1, y1, x2, y2, x3, y3);
            t2 = getT(x1, y1, x2, y2, x4, y4);

            t3 = getT(x3, y3, x4, y4, x1, y1);
            t4 = getT(x3, y3, x4, y4, x2, y2);

            if (t1 * t2 <= 0 && t3 * t4 <= 0)
            {
                lblStatus.Text = "Intersects!";
                return;
            }
             
            if (t1 == 0 && onSegment(x1, y1, x2, y2, x3, y3))
            {
                lblStatus.Text = "Intersects!";
                return;
            }

            if (t2 == 0 && onSegment(x1, y1, x2, y2, x4, y4))
            {
                lblStatus.Text = "Intersects!";
                return;
            }

            if (t3 == 0 && onSegment(x3, y3, x4, y4, x1, y1))
            {
                lblStatus.Text = "Intersects!";
                return;
            }

            if (t4 == 0 && onSegment(x3, y3, x4, y4, x2, y2))
            {
                lblStatus.Text = "Intersects!";
                return;
            }

            lblStatus.Text = "Doesn't Intersect";
        }

        private float getT(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            return x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
        }

    }
}
