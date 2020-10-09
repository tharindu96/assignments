using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotateScale
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private bool mCleared = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void drawPoint(Vertex v)
        {
            graphics.DrawLine(Pens.Black, (float)v.x, (float)(pnlMain.Height - v.y), (float)(v.x + 0.1F), (float)(pnlMain.Height - v.y));
        }

        private void drawPoint(Vertex v, Pen pen)
        {
            graphics.DrawLine(pen, (float)v.x, (float)(pnlMain.Height - v.y), (float)(v.x + 0.1F), (float)(pnlMain.Height - v.y));
        }

        private void drawLine(Vertex v1, Vertex v2, Pen pen)
        {
            if ((v1.x == v2.x) && (v1.y == v2.y))
            {
                drawPoint(v1, pen);
            }
            else
            {
                graphics.DrawLine(pen, (float)v1.x, (float)(pnlMain.Height - v1.y), (float)v2.x, (float)(pnlMain.Height - v2.y));
            }
        }

        private void drawLine(Vertex v1, Vertex v2)
        {
            if ((v1.x == v2.x) && (v1.y == v2.y))
            {
                drawPoint(v1);
            }
            else
            {
                graphics.DrawLine(Pens.Black, (float)v1.x, (float)(pnlMain.Height - v1.y), (float)v2.x, (float)(pnlMain.Height - v2.y));
            }
        }

        private void drawPolygon(Polygon polygon)
        {
            Pen pen = new Pen(polygon.getColor());
            List<Vertex> vertices = polygon.getVertices();
            for (int i = 0; i < vertices.Count; i++)
            {
                drawLine(vertices[i], vertices[(i + 1) % vertices.Count], pen);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = pnlMain.CreateGraphics();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            mCleared = false;
            await Task.Run(() => runAnimation());
        }

        private void runAnimation()
        {
            Polygon p1 = new Polygon();
            p1.addVertex(new Vertex(100, 100));
            p1.addVertex(new Vertex(100, 200));
            p1.addVertex(new Vertex(200, 200));
            p1.addVertex(new Vertex(200, 100));

            Polygon p2 = new Polygon();
            p2.addVertex(new Vertex(100, 100));
            p2.addVertex(new Vertex(100, 200));
            p2.addVertex(new Vertex(200, 200));
            p2.addVertex(new Vertex(200, 100));
            p2.translate(200, 200);

            for (int i = 0; i < 1000; i++)
            {
                if (mCleared == true)
                {
                    break;
                }

                graphics.Clear(SystemColors.Control);

                p1.rotate(-0.01);
                p1.scale(1.001, 1.001);

                p2.rotate(0.01);
                p2.scale(1.002, 1.002);

                drawPolygon(p1);
                drawPolygon(p2);
                Thread.Sleep(1000 / 60);
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            mCleared = true;
            await Task.Run(() => clearScreen());
        }

        private void clearScreen()
        {
            Thread.Sleep(100);
            graphics.Clear(SystemColors.Control);
        }
    }

    class Polygon
    {
        private List<Vertex> mVertices;
        private Color mColor;

        public Polygon(List<Vertex> vertices, Color color)
        {
            mVertices = vertices;
            mColor = color;
        }

        public Polygon(List<Vertex> vertices)
        {
            mVertices = vertices;
            mColor = Color.Black;
        }

        public Polygon(Color color)
        {
            mVertices = new List<Vertex>();
            mColor = color;
        }

        public Polygon()
        {
            mVertices = new List<Vertex>();
            mColor = Color.Black;
        }

        public void addVertex(int pos, Vertex vertex)
        {
            mVertices.Insert(pos, vertex);
        }

        public void addVertex(Vertex vertex)
        {
            mVertices.Add(vertex);
        }

        public void removeVertex(int pos)
        {
            mVertices.RemoveAt(pos);
        }

        public List<Vertex> getVertices()
        {
            return mVertices;
        }

        public Color getColor()
        {
            return mColor;
        }

        public void translate(double Tx, double Ty)
        {
            foreach (Vertex v in mVertices)
            {
                v.translate(Tx, Ty);
            }
        }

        public void rotate(double theta)
        {
            Vertex center = getCenter();
            foreach (Vertex v in mVertices)
            {
                v.fixedRotate(theta, center);
            }
        }

        public void scale(double Sx, double Sy)
        {
            Vertex center = getCenter();
            foreach (Vertex v in mVertices)
            {
                v.fixedScale(Sx, Sy, center);
            }
        }

        private Vertex getCenter()
        {
            Vertex c = new Vertex(0, 0);
            foreach (Vertex v in mVertices)
            {
                c.x += v.x;
                c.y += v.y;
            }
            c.x /= mVertices.Count;
            c.y /= mVertices.Count;
            return c;
        }
    }

    class Vertex
    {
        public double x;
        public double y;

        public Vertex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void translate(double Tx, double Ty)
        {
            x += Tx;
            y += Ty;
        }

        public void translate(Vertex dv)
        {
            x += dv.x;
            y += dv.y;
        }

        public void rotate(double theta)
        {
            double ox = x;
            double oy = y;
            x = ox * Math.Cos(theta) - oy * Math.Sin(theta);
            y = ox * Math.Sin(theta) + oy * Math.Cos(theta);
        }

        public void scale(double Sx, double Sy)
        {
            x *= Sx;
            y *= Sy;
        }

        public void scale(Vertex dv)
        {
            x *= dv.x;
            y *= dv.y;
        }

        public void fixedRotate(double theta, Vertex point)
        {
            translate(-point.x, -point.y);
            rotate(theta);
            translate(point);
        }

        public void fixedScale(double Sx, double Sy, Vertex point)
        {
            translate(-point.x, -point.y);
            scale(Sx, Sy);
            translate(point);
        }
    }

}
