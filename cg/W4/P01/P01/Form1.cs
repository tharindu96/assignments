using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P01
{
    public partial class Form1 : Form
    {
        Graphics gG;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawPoint(float x, float y)
        {
            gG.DrawLine(Pens.Black, x, pnlMain.Height - y, x + 0.1f, pnlMain.Height - y);
        }

        private void DrawLine(float x1, float y1, float x2, float y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                DrawPoint(x1, y1);
            }
            else
            {
                gG.DrawLine(Pens.Black, x1, pnlMain.Height - y1, x2, pnlMain.Height - y2);
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

            try
            {
                DrawLine(float.Parse(txtXs.Text), float.Parse(txtYs.Text), float.Parse(txtXe.Text), float.Parse(txtYe.Text));
            }
            catch
            {
                MessageBox.Show("Please Enter Numbers!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pnlMain.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gG = pnlMain.CreateGraphics();
        }
    }
}
