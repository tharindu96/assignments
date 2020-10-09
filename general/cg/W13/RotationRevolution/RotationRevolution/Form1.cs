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

namespace RotationRevolution
{
    public partial class Form1 : Form
    {

        private Graphics mGraphics;
        private bool mDrawing = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mGraphics = pnlMain.CreateGraphics();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            mDrawing = true;
            await Task.Run(() => runAnimation());
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            mDrawing = false;
            await Task.Run(() => clearScreen());
        }

        private void clearScreen()
        {
            Thread.Sleep(100);
            mGraphics.Clear(SystemColors.Control);
        }

        private void runAnimation()
        {

            float dT = 1.0f / 60.0f;
            int frameRate = (int)(dT * 1000.0f);
            Renderer renderer = new Renderer(mGraphics, pnlMain);

            
            Star star = new Star(new Vertex(250, 80), 40.0, Color.Black);

            while (mDrawing)
            {
                mGraphics.Clear(SystemColors.Control);

                star.draw(renderer);

                star.rotate(0.05);
                star.fixedRotate(0.005, new Vertex(250, 250));

                Thread.Sleep(frameRate);
            }
        }
    }

    class Renderer
    {

        Graphics mGraphics;
        Panel mPnlMain;

        public Renderer(Graphics graphics, Panel panel)
        {
            mGraphics = graphics;
            mPnlMain = panel;
        }

        private void drawPoint(Vertex v)
        {
            mGraphics.DrawLine(Pens.Black, (float)v.x, (float)(mPnlMain.Height - v.y), (float)(v.x + 0.1F), (float)(mPnlMain.Height - v.y));
        }

        private void drawPoint(Vertex v, Pen pen)
        {
            mGraphics.DrawLine(pen, (float)v.x, (float)(mPnlMain.Height - v.y), (float)(v.x + 0.1F), (float)(mPnlMain.Height - v.y));
        }

        private void drawLine(Vertex v1, Vertex v2, Pen pen)
        {
            if ((v1.x == v2.x) && (v1.y == v2.y))
            {
                drawPoint(v1, pen);
            }
            else
            {
                mGraphics.DrawLine(pen, (float)v1.x, (float)(mPnlMain.Height - v1.y), (float)v2.x, (float)(mPnlMain.Height - v2.y));
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
                mGraphics.DrawLine(Pens.Black, (float)v1.x, (float)(mPnlMain.Height - v1.y), (float)v2.x, (float)(mPnlMain.Height - v2.y));
            }
        }

        public void drawPolygon(Polygon polygon)
        {
            Pen pen = new Pen(polygon.getColor());
            List<Vertex> vertices = polygon.getVertices();
            for (int i = 0; i < vertices.Count; i++)
            {
                drawLine(vertices[i], vertices[(i + 1) % vertices.Count], pen);
            }
        }

        public void fillPolygon(Polygon polygon)
        {
            mGraphics.FillPolygon(Brushes.Black, polygon.getPoints(mPnlMain.Height));
        }

        public void fillPolygon(Polygon polygon, Brush brush)
        {
            mGraphics.FillPolygon(brush, polygon.getPoints(mPnlMain.Height));
        }
    }

    class Star
    {
        private Polygon[] mPoly;
        const double DEGREE_TO_RAD = Math.PI / 180.0;

        public Star(Vertex center, double size, Color color)
        {
            Vertex v1 = new Vertex(center.x, center.y + size);
            Vertex v2 = new Vertex(center.x - size * Math.Cos(30.0 * DEGREE_TO_RAD), center.y - size * Math.Sin(30.0 * DEGREE_TO_RAD));
            Vertex v3 = new Vertex(center.x + size * Math.Cos(30.0 * DEGREE_TO_RAD), center.y - size * Math.Sin(30.0 * DEGREE_TO_RAD));

            mPoly = new Polygon[] {
                new Polygon(new List<Vertex>
                {
                    new Vertex(v1),
                    new Vertex(v2),
                    new Vertex(v3)
                }),
                new Polygon(new List<Vertex>
                {
                    new Vertex(v1),
                    new Vertex(v2),
                    new Vertex(v3)
                })
            };

            mPoly[1].rotate(180.0 * DEGREE_TO_RAD);
            
        }

        public void draw(Renderer renderer)
        {
            renderer.fillPolygon(mPoly[0], Brushes.Black);
            renderer.fillPolygon(mPoly[1], Brushes.Blue);
        }

        public void rotate(double theta)
        {
            mPoly[0].rotate(theta);
            mPoly[1].rotate(-theta);
        }

        public void fixedRotate(double theta, Vertex center)
        {
            mPoly[0].fixedRotate(theta, center);
            mPoly[1].fixedRotate(theta, center);
        }
    }

    class Test : Polygon
    {
        public Test(Vertex center)
        {
            mVertices = new List<Vertex> {
                new Vertex(center.x - 5, center.y - 5),
                new Vertex(center.x - 5, center.y + 5),
                new Vertex(center.x + 5, center.y + 5),
                new Vertex(center.x + 5, center.y - 5)
            };
            mColor = Color.Black;
        }
    }

    class Polygon
    {
        protected List<Vertex> mVertices;
        protected Color mColor;

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

        public PointF[] getPoints(double height)
        {
            PointF[] ret = new PointF[mVertices.Count];

            for (int i = 0; i < mVertices.Count; i++)
            {
                ret[i] = new PointF();
                ret[i].X = (float)mVertices[i].x;
                ret[i].Y = (float)(height - mVertices[i].y);
            }

            return ret;
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

        public void fixedRotate(double theta, Vertex center)
        {
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

        virtual protected Vertex getCenter()
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

        public Vertex(Vertex v)
        {
            this.x = v.x;
            this.y = v.y;
        }

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
