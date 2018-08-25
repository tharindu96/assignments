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

namespace AnalogClock
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

        private void drawPoint(Vertex v)
        {
            mGraphics.DrawLine(Pens.Black, (float)v.x, (float)(pnlMain.Height - v.y), (float)(v.x + 0.1F), (float)(pnlMain.Height - v.y));
        }

        private void drawPoint(Vertex v, Pen pen)
        {
            mGraphics.DrawLine(pen, (float)v.x, (float)(pnlMain.Height - v.y), (float)(v.x + 0.1F), (float)(pnlMain.Height - v.y));
        }

        private void drawLine(Vertex v1, Vertex v2, Pen pen)
        {
            if ((v1.x == v2.x) && (v1.y == v2.y))
            {
                drawPoint(v1, pen);
            }
            else
            {
                mGraphics.DrawLine(pen, (float)v1.x, (float)(pnlMain.Height - v1.y), (float)v2.x, (float)(pnlMain.Height - v2.y));
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
                mGraphics.DrawLine(Pens.Black, (float)v1.x, (float)(pnlMain.Height - v1.y), (float)v2.x, (float)(pnlMain.Height - v2.y));
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

        private void fillPolygon(Polygon polygon)
        {
            mGraphics.FillPolygon(Brushes.Black, polygon.getPoints(pnlMain.Height));
        }

        private void drawCircle(Circle circle)
        {
            Pen pen = new Pen(circle.getColor());
            Vertex center = circle.getCenter();
            double radius = circle.getRadius();
            mGraphics.DrawEllipse(pen, (float)(center.x - radius), (float)(pnlMain.Height - (center.y + radius)), 2 * (float)radius, 2 * (float)radius);
        }

        private void drawString(DrawString str)
        {
            SizeF size = mGraphics.MeasureString(str.getString(), str.getFont());
            float x = (float)str.getPosition().x;
            float y = (float)str.getPosition().y;
            x -= size.Width / 2;
            y += size.Height / 2;
            mGraphics.DrawString(str.getString(), str.getFont(), Brushes.Black, x, pnlMain.Height - y);
        }

        private void runAnimation()
        {

            Rectangle outerBox = new Rectangle(50, 50, 250, 400);
            Rectangle innerBox = new Rectangle(60, 60, 240, 210);
            Circle clockFace = new Circle(150, 300, 80);

            RectangleF innerBoxBound = new RectangleF(60, pnlMain.Height - 210,  180, 150);

            string[] clockNumbers = new string[] {
                "12", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"
            };

            DrawString[] strs = new DrawString[12];

            for (int k = 0; k < 12; k++)
            {
                strs[k] = new DrawString(clockNumbers[k], clockFace.getCenter().x, clockFace.getCenter().y);
                strs[k].translate(0, clockFace.getRadius() - 10.0f);
                strs[k].fixedRotate(-(Math.PI * 2.0f * ( k / 12.0f )), clockFace.getCenter());
            }

            ClockHand hourHand = new ClockHand(clockFace.getCenter().x, clockFace.getCenter().y, 50, 10);
            ClockHand minuteHand = new ClockHand(clockFace.getCenter().x, clockFace.getCenter().y, 70, 7.5);
            ClockHand secondHand = new ClockHand(clockFace.getCenter().x, clockFace.getCenter().y, 70, 5);

            double theta = -Math.PI / 10.0f;
            const float gravity = 10.0f;
            const float pendConst = 70.0f;

            Pendulum pendulum = new Pendulum(clockFace.getCenter().x, clockFace.getCenter().y, 200, 10, 20, Color.Black);
            pendulum.rotate(theta);

            float angularAcceleration = - (gravity / 200.0f) * (float)Math.Sin(theta);
            float angularVelocity = 0;

            float dT = 1.0f / 10.0f;
            int frameRate = (int)(dT * 1000.0f);

            float dS = -(float)(2 * Math.PI) / 60;
            float dM = -(float)(2 * Math.PI) / (60 * 60);
            float dH = -(float)(2 * Math.PI) / (60 * 60 * 12);
            float dHH = -(float)(2 * Math.PI) / 12;

            int hh = DateTime.Now.Hour;
            if (hh > 12)
            {
                hh -= 12;
            }
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            secondHand.rotate(ss * dS);
            minuteHand.rotate(mm * dS + ss * dM);
            hourHand.rotate(hh * dHH + (mm * ss) * dH);

            bool dir = true;

            while (mDrawing)
            {

                mGraphics.Clear(SystemColors.Control);

                drawPolygon(outerBox);
                drawPolygon(innerBox);
                drawCircle(clockFace);

                drawPoint(clockFace.getCenter());

                fillPolygon(hourHand);
                fillPolygon(minuteHand);
                fillPolygon(secondHand);

                mGraphics.SetClip(innerBoxBound);
                fillPolygon(pendulum);
                mGraphics.ResetClip();

                for (int k = 0; k < 12; k++)
                {
                    drawString(strs[k]);
                }

                secondHand.rotate(dS * dT);
                minuteHand.rotate(dM * dT);
                hourHand.rotate(dH * dT);

                angularVelocity += angularAcceleration * dT;
                theta += angularVelocity * dT * pendConst;

                pendulum.rotate(angularVelocity * dT * pendConst);

                angularAcceleration = -(gravity / 200.0f) * (float)Math.Sin(theta);
                // omega = (float)Math.Sqrt(10.0f / (200.0f * Math.Cos(Math.Abs(theta))));

                Console.WriteLine(angularAcceleration + " " + angularVelocity + " " + theta);


                Thread.Sleep(frameRate);
            }
        }

        private void clearScreen()
        {
            Thread.Sleep(100);
            mGraphics.Clear(SystemColors.Control);
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            mDrawing = true;
            await Task.Run(() => runAnimation());
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            mDrawing = false;
            await Task.Run(() => clearScreen());
        }
    }

    class DrawString
    {
        private string mStr;
        private Vertex mPos;
        private Font mFont;

        public DrawString(string str, double x, double y, Font font)
        {
            mStr = str;
            mPos = new Vertex(x, y);
            mFont = font;
        }

        public DrawString(string str, double x, double y)
        {
            mStr = str;
            mPos = new Vertex(x, y);
            mFont = SystemFonts.DefaultFont;
        }

        public Vertex getPosition()
        {
            return mPos;
        }

        public string getString()
        {
            return mStr;
        }

        public Font getFont()
        {
            return mFont;
        }

        public void translate(double Tx, double Ty)
        {
            mPos.translate(Tx, Ty);
        }

        public void fixedRotate(double theta, Vertex point)
        {
            mPos.fixedRotate(theta, point);
            
        }

    }

    class Pendulum : Polygon
    {
        private Vertex mCenter;

        public Pendulum(double cx, double cy, double length, double width, double radius, Color color) :
            base(new List<Vertex>
            {
                new Vertex(cx - width/2, cy + 2.0f),
                new Vertex(cx + width/2, cy + 2.0f),
                new Vertex(cx + width/2, cy - length),
                new Vertex(cx + width, cy - length - radius / 3),
                new Vertex(cx + width, cy - length - ((2 * radius) / 3)),
                new Vertex(cx + width/2, cy - length - radius),
                new Vertex(cx - width/2, cy - length - radius),
                new Vertex(cx - width, cy - length - ((2 * radius) / 3)),
                new Vertex(cx - width, cy - length - radius / 3),
                new Vertex(cx - width/2, cy - length)
            }, color)
        {
            mCenter = new Vertex(cx, cy);
        }

        override protected Vertex getCenter()
        {
            return mCenter;
        }
    }

    class ClockHand : Polygon
    {
        private Vertex mCenter;

        public ClockHand(double cx, double cy, double length, double width, Color color) :
            base(new List<Vertex>
            {
                new Vertex(cx, cy - 5.0f),
                new Vertex(cx + width / 2.0f, cy),
                new Vertex(cx, cy + length),
                new Vertex(cx - width / 2.0f, cy)
            }, color)
        {
            mCenter = new Vertex(cx, cy);
        }

        public ClockHand(double cx, double cy, double length, double width) :
            base(new List<Vertex>
            {
                new Vertex(cx, cy - 5.0f),
                new Vertex(cx + width / 2.0f, cy),
                new Vertex(cx, cy + length),
                new Vertex(cx - width / 2.0f, cy)
            }, Color.Black)
        {
            mCenter = new Vertex(cx, cy);
        }

        override protected Vertex getCenter()
        {
            return mCenter;
        }
    }

    class Rectangle : Polygon
    {

        public Rectangle(double lx, double ly, double hx, double hy, Color color) :
            base(new List<Vertex> {
                new Vertex(lx, ly),
                new Vertex(lx, hy),
                new Vertex(hx, hy),
                new Vertex(hx, ly)
            }, color)
        {

        }

        public Rectangle(double lx, double ly, double hx, double hy) : 
            base(new List<Vertex> {
                new Vertex(lx, ly),
                new Vertex(lx, hy),
                new Vertex(hx, hy),
                new Vertex(hx, ly)
            })
        {

        }
        
    }

    class Circle
    {
        private Vertex mCenter;
        private double mRadius;
        private Color mColor;

        public Circle(double centerX, double centerY, double radius)
        {
            mCenter = new Vertex(centerX, centerY);
            mRadius = radius;
            mColor = Color.Black;
        }

        public Circle(double centerX, double centerY, double radius, Color color)
        {
            mCenter = new Vertex(centerX, centerY);
            mRadius = radius;
            mColor = color;
        }

        public Circle(Vertex center, double radius)
        {
            mCenter = center;
            mRadius = radius;
            mColor = Color.Black;
        }

        public Circle(Vertex center, double radius, Color color)
        {
            mCenter = center;
            mRadius = radius;
            mColor = color;
        }

        public Color getColor()
        {
            return mColor;
        }

        public Vertex getCenter()
        {
            return mCenter;
        }

        public double getRadius()
        {
            return mRadius;
        }

        public void translate(double Tx, double Ty)
        {
            mCenter.translate(Tx, Ty);
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
