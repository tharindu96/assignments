using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P02
{
    public partial class Form1 : Form
    {
        Graphics gG;

        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayPoint(float x, float y)
        {
            gG.DrawLine(Pens.Black, x, pnlMain.Height - y, x + 0.1f, pnlMain.Height - y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gG = pnlMain.CreateGraphics();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int points = 0;

            try
            {
                points = int.Parse(txtPoints.Text);
            }
            catch
            {
                MessageBox.Show("Must be an integer!");
                txtPoints.Clear();
                txtPoints.Focus();
            }

            if (points <= 0)
                return;
            int x, y;
            for (int i = 0; i < points; i++)
            {
                x = r.Next(0, pnlMain.Width);
                y = r.Next(0, pnlMain.Height);
                DisplayPoint(x, y);
            }
        }
    }
}
