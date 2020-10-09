using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P03
{
    public partial class Form1 : Form
    {

        Graphics gG;

        bool onHold = false;

        private void DisplayPoint(float x, float y)
        {
            gG.DrawLine(Pens.Black, x, y, x + 0.1f, y);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (!onHold)
            {
                onHold = true;
                DisplayPoint(e.X, e.Y);
                lsbCoords.Items.Add("(Down) x:" + e.X + " y:" + e.Y);
            }
        }

        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (onHold)
            {
                onHold = false;
                DisplayPoint(e.X, e.Y);
                lsbCoords.Items.Add("(Up) x:" + e.X + " y:" + e.Y);
            }
        }

        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (onHold)
            {
                DisplayPoint(e.X, e.Y);
                lsbCoords.Items.Add("(Move) x:" + e.X + " y:" + e.Y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gG = pnlMain.CreateGraphics();
        }
    }
}
