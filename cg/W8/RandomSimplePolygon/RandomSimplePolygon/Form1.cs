using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomSimplePolygon
{
    public partial class Form1 : Form
    {

        List<Vertex> mVertices = new List<Vertex>();
        int mVertexCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtVertexCount.Text, out mVertexCount))
            {
                MessageBox.Show("Must enter an integer");
                return;
            }

            if (mVertexCount < 3)
            {
                MessageBox.Show("Must be greater than 3");
                return;
            }

            generateRandomVertices();

            drawPolygon();

            gbGenerate.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mVertexCount = 0;
            mVertices.Clear();
            txtVertexCount.Clear();
            gbGenerate.Enabled = true;
            pnlMain.Invalidate();
        }

        private void drawPolygon()
        {
            Vertex v1, v2;
            for (int i = 0; i < mVertices.Count; i++)
            {
                v1 = mVertices[i % mVertices.Count];
                v2 = mVertices[(i + 1) % mVertices.Count];
                drawLine(v1, v2);
            }
        }
        private void drawPoint(Vertex v)
        {
            Graphics g = pnlMain.CreateGraphics();
            g.DrawLine(Pens.Black, v.x, pnlMain.Height - v.y, v.x + 0.1F, pnlMain.Height - v.y);
        }

        private void drawPoint(Vertex v, Pen pen)
        {
            Graphics g = pnlMain.CreateGraphics();
            g.DrawLine(pen, v.x, pnlMain.Height - v.y, v.x + 0.1F, pnlMain.Height - v.y);
        }

        private void drawLine(Vertex v1, Vertex v2, Pen pen)
        {
            Graphics g = pnlMain.CreateGraphics();
            if ((v1.x == v2.x) && (v1.y == v2.y))
            {
                drawPoint(v1, pen);
            }
            else
            {
                g.DrawLine(pen, v1.x, pnlMain.Height - v1.y, v2.x, pnlMain.Height - v2.y);
            }
        }

        private void drawLine(Vertex v1, Vertex v2)
        {
            Graphics g = pnlMain.CreateGraphics();
            if ((v1.x == v2.x) && (v1.y == v2.y))
            {
                drawPoint(v1);
            }
            else
            {
                g.DrawLine(Pens.Black, v1.x, pnlMain.Height - v1.y, v2.x, pnlMain.Height - v2.y);
            }
        }

        private int getT(Vertex v1, Vertex v2, Vertex v3)
        {
            float s = v1.x * (v2.y - v3.y) + v2.x * (v3.y - v1.y) + v3.x * (v1.y - v2.y);
            if (s > 0) return 1;
            if (s < 0) return -1;
            return 0;
        }

        private void generateRandomVertices()
        {
            Random rand = new Random();
            Vertex v;
            Vertex v0, v1, v2, v3;

            bool found = false;
            bool innerFind = false;

            while (!found)
            {
                mVertices.Clear();

                for (int i = 0; i < mVertexCount; i++)
                {
                    v = new Vertex();
                    v.x = (float)(rand.NextDouble() * pnlMain.Width);
                    v.y = (float)(rand.NextDouble() * pnlMain.Height);
                    mVertices.Add(v);
                }

                innerFind = true;

                for (int i = 0; i < mVertexCount; i++)
                {
                    v0 = mVertices[i];
                    v1 = mVertices[(i + 1) % mVertexCount];

                    for (int j = 0; j < mVertexCount - 2; j++)
                    {
                        v2 = mVertices[(i + 2 + j) % mVertexCount];
                        v3 = mVertices[(i + 3 + j) % mVertexCount];

                        if (getT(v0, v1, v2) * getT(v0, v1, v3) == 1 && getT(v2, v3, v0) * getT(v2, v3, v1) == 1)
                        {
                            innerFind = false;
                            break;
                        }

                    }
                }

                Console.WriteLine(innerFind);

                if (innerFind)
                {
                    found = true;
                    break;
                }

            }
        }
    }

    class Vertex
    {
        public float x;
        public float y;
    }
}
