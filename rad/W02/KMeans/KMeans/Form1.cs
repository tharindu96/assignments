using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeans
{
    public partial class Form1 : Form
    {

        private const int MAX_CLUSTERS = 5;
        private const float POINT_SIZE = 5.0f;
        private const float CLUSTER_POINT_SIZE = 8.0f;

        private enum APP_STATE
        {
            ADD_DATA_POINTS,
            ADD_CLUSTER_POINTS,
            RUN_CLUSTERING,
            DONE
        }

        private Graphics graphics;
        private APP_STATE state = APP_STATE.ADD_DATA_POINTS;
        private List<Point> dataPoints = new List<Point>();
        private List<Cluster> clusterPoints = new List<Cluster>();
        private int iteration = 0;

        private void drawPoint(Point v)
        {
            graphics.FillEllipse(Brushes.Black, (float)v.x - POINT_SIZE/2, (float)(pnlMain.Height - v.y) - POINT_SIZE/2, POINT_SIZE, POINT_SIZE);
        }

        private void drawPoint(Point v, Brush brush)
        {
            graphics.FillEllipse(brush, (float)v.x - POINT_SIZE / 2, (float)(pnlMain.Height - v.y) - POINT_SIZE / 2, POINT_SIZE, POINT_SIZE);
        }

        private void drawLine(Point a, Point b, Pen pen)
        {
            graphics.DrawLine(pen, (float)a.x, pnlMain.Height - (float)a.y, (float)b.x, pnlMain.Height - (float)b.y);
        }

        private void drawPolygon(List<Point> points, Pen pen)
        {
            for(int i = 0; i < points.Count; i++)
            {
                int j = (i + 1) % points.Count;
                drawLine(points[i], points[j], pen);
            }
        }

        private void drawClusterPoint(Point v, Brush brush)
        {
            graphics.FillRectangle(brush, (float)v.x - CLUSTER_POINT_SIZE / 2, (float)(pnlMain.Height - v.y) - CLUSTER_POINT_SIZE / 2, CLUSTER_POINT_SIZE, CLUSTER_POINT_SIZE);
        }

        private void setInitState()
        {
            lblStatus.Text = "Click on the panel to add points or load from file";
            state = APP_STATE.ADD_DATA_POINTS;
            dataPoints.Clear();
            clusterPoints.Clear();
            updateNextBtn();
            graphics.Clear(Color.White);
            iteration = 0;
        }

        private void setSecondState()
        {
            lblStatus.Text = "Click on the panel to add cluster points";
            state = APP_STATE.ADD_CLUSTER_POINTS;
            updateNextBtn();
        }

        private void runClustering()
        {
            ++iteration;
            lblStatus.Text = "Running Iteration: " + iteration;
            foreach (Cluster c in clusterPoints)
            {
                c.clearPoints();
            }
            foreach(Point p in dataPoints)
            {
                int i = getCluster(p);
                clusterPoints[i].addPoint(p);
            }
            foreach (Cluster c in clusterPoints)
            {
                if (c.getPoints().Count > 0) continue;
                foreach (Cluster d in clusterPoints)
                {
                    if (c == d || d.getPoints().Count == 0) continue;

                    int k = d.getPoints().Count;

                    Point t = d.getPoints()[k - 1];
                    d.getPoints().RemoveAt(k - 1);

                    c.addPoint(t);
                }
            }
            updateClustering();
        }

        private void updateClustering()
        {
            graphics.Clear(Color.White);
            foreach (Cluster c in clusterPoints)
            {
                c.updateMean();
                drawPolygon(c.getBoundary(), Pens.Black);
                foreach (Point p in c.getPoints())
                {
                    drawPoint(p, c.getBrush());
                }
                drawClusterPoint(c.getMean(), c.getBrush());
            }
        }

        private int getCluster(Point p)
        {
            int j = 0;
            double min = p.distance(clusterPoints[j].getMean());
            for(int i = 1; i < clusterPoints.Count; i++)
            {
                double x = p.distance(clusterPoints[i].getMean());
                if (min > x)
                {
                    min = x;
                    j = i;
                }
            }
            return j;
        }

        private void updateNextBtn()
        {
            if (state == APP_STATE.ADD_DATA_POINTS)
            {
                btnNext.Enabled = (dataPoints.Count > 0);
            }
            else if (state == APP_STATE.ADD_CLUSTER_POINTS)
            {
                btnNext.Enabled = (clusterPoints.Count > 0);
            }
            else if (state == APP_STATE.RUN_CLUSTERING)
            {
                btnNext.Enabled = true;
            } else
            {
                btnNext.Enabled = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = pnlMain.CreateGraphics();
            setInitState();
        }

        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, pnlMain.Height - e.Y);
            if (state == APP_STATE.ADD_DATA_POINTS)
            {
                dataPoints.Add(p);
                drawPoint(p);
            }
            else if (state == APP_STATE.ADD_CLUSTER_POINTS)
            {
                if (clusterPoints.Count < dataPoints.Count)
                {
                    clusterPoints.Add(new Cluster(p, Brushes.Black));
                    drawClusterPoint(p, Brushes.Black);
                } else
                {
                    MessageBox.Show("Should not have more cluster points than data points");
                }
            }


            updateNextBtn();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            setInitState();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (state == APP_STATE.ADD_DATA_POINTS)
            {
                setSecondState();
            } else if (state == APP_STATE.ADD_CLUSTER_POINTS) {
                state = APP_STATE.RUN_CLUSTERING;
                runClustering();
            } else if (state == APP_STATE.RUN_CLUSTERING)
            {
                runClustering();
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (state != APP_STATE.ADD_DATA_POINTS) return;

            ofdLoadFile.InitialDirectory = "c:\\";
            ofdLoadFile.Filter = "txt files (*.txt)|*.txt";
            ofdLoadFile.CheckFileExists = true;
            ofdLoadFile.ShowDialog();

            string[] lines = System.IO.File.ReadAllLines(ofdLoadFile.FileName);
            double x, y;

            foreach(string l in lines)
            {
                string[] c = l.Split(',');

                if (!double.TryParse(c[0], out x) || !double.TryParse(c[1], out y))
                {
                    MessageBox.Show("Cannot Parse File!");
                    return;
                }

                Point p = new Point(x, y);
                dataPoints.Add(p);
                drawPoint(p);
            }
        }
    }

    class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double distance(Point p)
        {
            // return Math.Abs(p.x - x) + Math.Abs(p.y - y);

            return Math.Sqrt(Math.Pow(p.x - x, 2) + Math.Pow(p.y - y, 2));
        }

        public static int orientation(Point p, Point q, Point r)
        {
            int val = (int)((q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y));
            if (val == 0) return 0;  // colinear
            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }

        public static PointF[] getPointArray(List<Point> points)
        {
            int n = points.Count;
            PointF[] x = new PointF[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = new PointF((float)points[i].x, (float)points[i].y);
            }

            return x;
        }
    }

    class Cluster
    {
        private Point mean;
        private List<Point> points = new List<Point>();
        private Brush brush;

        public Cluster(Point p, Brush b)
        {
            mean = new Point(p.x, p.y);
            brush = b;
        }

        public Cluster(double x, double y, Brush b)
        {
            mean = new Point(x, y);
            brush = b;
        }

        public Point getMean()
        {
            return mean;
        }

        public void clearPoints()
        {
            points.Clear();
        }

        public void addPoint(Point p)
        {
            points.Add(p);
        }
        
        public void updateMean()
        {
            double x = 0;
            double y = 0;

            foreach(Point p in points)
            {
                x += p.x;
                y += p.y;
            }

            mean.x = x / points.Count;
            mean.y = y / points.Count;
        }

        public List<Point> getPoints()
        {
            return points;
        }

        public List<Point> getBoundary()
        {
            List<Point> b = new List<Point>();

            int l = getLeftMost();
            int n = points.Count;

            if (n == 0) return b;

            int p = l;
            int q;
            do
            {
                b.Add(points[p]);

                q = (p + 1) % n;

                for (int i = 0; i < n; i++)
                {
                    if (Point.orientation(points[p], points[i], points[q]) == 2)
                        q = i;
                }

                p = q;
            } while (p != l);

            return b;
        }


        private int getLeftMost()
        {
            if (points.Count == 0) return -1;
            double x = points[0].x;
            int i = 0;
            for(int j = 1; j < points.Count; j++)
            {
                if (points[j].x < x)
                {
                    x = points[j].x;
                    i = j;
                }
            }
            return i;
        }

        public Brush getBrush()
        {
            return brush;
        }

    }

}
