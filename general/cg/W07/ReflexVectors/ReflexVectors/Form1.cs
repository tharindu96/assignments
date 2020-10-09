using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflexVectors
{

    public partial class Form1 : Form
    {

        int mVertexCount = 0;
        List<Vertex> mVertices = new List<Vertex>();
        bool mDrawing = true;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //mVertexCount = 3;
            //mCurrentVertices = 3;
            //Vertex v = new Vertex();
            //v.x = 10;
            //v.y = 10;
            //mVertices.Add(v);
            //v = new Vertex();
            //v.x = 110;
            //v.y = 10;
            //mVertices.Add(v);
            //v = new Vertex();
            //v.x = 110;
            //v.y = 110;
            //mVertices.Add(v);
            //v = new Vertex();
            //v.x = 210;
            //v.y = 250;
            //mVertices.Add(v);
            //gbVertexCount.Enabled = false;
            //gbReflexVertices.Enabled = true;
        }

        private void btnSetVertexCount_Click(object sender, EventArgs e)
        {
            if (mVertexCount < 3)
            {
                MessageBox.Show("Must have atleast 3 vertices!");
                return;
            }
            drawLine(mVertices[mVertexCount - 1], mVertices[0]);
            mDrawing = false;
            gbDoneDrawing.Enabled = false;
            gbReflexVertices.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pnlMain.CreateGraphics().Clear(Color.White);
            mDrawing = true;
            mVertexCount = 0;
            gbDoneDrawing.Enabled = true;
            gbReflexVertices.Enabled = false;
            mVertices.Clear();
        }

        private void btnCalculateReflexVertices_Click(object sender, EventArgs e)
        {
            drawPolygon();

            List<Vertex> reflexVertices = new List<Vertex>();

            Vertex v, a, b;
            int S = 0;
            int s = 0;

            int i = getLowestCoords();
            int start = i;
            int j;
            bool started = false;

            for (; (i - start) < mVertices.Count; i++)
            {
                Console.WriteLine(i - start);
                v = mVertices[i % mVertices.Count];
                a = mVertices[(i + 1) % mVertices.Count];
                j = i - 1;
                if (j < 0)
                {
                    j = mVertexCount - 1;
                }
                else
                {
                    j = (i - 1) % mVertices.Count;
                }
                b = mVertices[j];
                s = getT(b, v, a);
                if (!started)
                {
                    S = s;
                    started = true;
                }
                else
                {
                    if (s != S)
                    {
                        reflexVertices.Add(v);
                    }
                }
            }

            for (i = 0; i < reflexVertices.Count; i++)
            {
                v = reflexVertices[i];
                drawCircle(v, 10.0f, Pens.Red);
            }

        }

        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mDrawing) return;
            Vertex v = new Vertex
            {
                x = e.X,
                y = pnlMain.Height - e.Y
            };
            mVertices.Add(v);
            mVertexCount++;
            if (mVertexCount > 1)
            {
                drawLine(mVertices[mVertexCount - 1], mVertices[mVertexCount - 2]);
            }
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

        private void drawCircle(Vertex v, float size, Pen pen)
        {
            Graphics g = pnlMain.CreateGraphics();
            g.DrawEllipse(pen, v.x - (size / 2), (pnlMain.Height - v.y - (size / 2)), size, size);
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

        private int getLowestCoords()
        {
            if (mVertexCount <= 0)
                return -1;
            int l = 0;
            float minY = mVertices[0].y;
            for (int i = 1; i < mVertexCount; i++)
            {
                if (minY > mVertices[i].y)
                {
                    minY = mVertices[i].y;
                    l = i;
                }
            }
            return l;
        }
    }

    class Vertex
    {
        public float x;
        public float y;
    }
}
