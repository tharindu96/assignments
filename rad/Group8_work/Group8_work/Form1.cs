using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group8_work
{
    public partial class Form1 : Form
    {
        bool keepClustering = true;
        int MAX_CLUSTERS = 10;
        int MAX_ITERATIONS = 50;

        bool loaded = false;
        int mHeight, mWidth;
        List<Point> mPoints = new List<Point>();
        List<Cluster> mClusters = new List<Cluster>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            DialogResult rs = ofd_image.ShowDialog();
            if (rs != DialogResult.OK)
                return;
            pb01.ImageLocation = ofd_image.FileName;
            loadImage(ofd_image.FileName);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            initClustering();
            runClustering();
            drawBitmap();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!loaded) return;

            mPoints.Clear();
            mClusters.Clear();
            pb01.Image = null;
            pb02.Image = null;

            btnClear.Enabled = false;
            btnConvert.Enabled = false;
            btnLoadImage.Enabled = true;
            loaded = false;
            keepClustering = false;
        }

        private void initClustering()
        {
            if (!loaded) return;
            mClusters.Clear();
            HashSet<Point> mSet = new HashSet<Point>();
            Random rand = new Random();
            for (int i = 0; i < MAX_CLUSTERS; i++)
            {
                Point p = mPoints[rand.Next(0, mPoints.Count)];
                while (mSet.Contains(p))
                {
                    p = mPoints[rand.Next(0, mPoints.Count)];
                }
                mClusters.Add(new Cluster(p.r, p.g, p.b));
            }
            keepClustering = true;
        }

        private void runClustering()
        {
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                if (!keepClustering) break;
                runOneClusteringStep();
            }
        }

        private void runOneClusteringStep()
        {
            Cluster c;

            foreach (Cluster k in mClusters)
            {
                k.clearPoints();
            }

            foreach (Point p in mPoints)
            {
                c = getClosestCluster(p);
                c.addPoint(p);
            }


            bool shouldQuit = true;

            foreach(Cluster k in mClusters)
            {
                if (k.updateMean())
                    shouldQuit = false;
            }

            if (shouldQuit)
                keepClustering = false;
        }

        private Cluster getClosestCluster(Point p)
        {
            Cluster closest = mClusters[0];
            double d = p.distance(closest.getMean());
            double t;
            Cluster tc;
            for (int i = 1; i < mClusters.Count; i++)
            {
                tc = mClusters[i];
                t = p.distance(tc.getMean());
                if (t < d)
                {
                    d = t;
                    closest = tc;
                }
            }
            return closest;
        }

        private void loadImage(string filename)
        {
            if (loaded) return;
            Bitmap bmap = new Bitmap(ofd_image.FileName);
            mPoints.Clear();
            mClusters.Clear();
            mHeight = bmap.Height;
            mWidth = bmap.Width;
            for (int i = 0; i < mWidth; i++)
            {
                for (int j = 0; j < mHeight; j++)
                {
                    Color pixel = bmap.GetPixel(i, j);
                    mPoints.Add(new Point(pixel.R, pixel.G, pixel.B, i, j));
                }
            }
            btnLoadImage.Enabled = false;
            btnClear.Enabled = true;
            btnConvert.Enabled = true;
            loaded = true;
            keepClustering = true;
            drawBitmap();
        }

        private void drawBitmap()
        {
            if (!loaded) return;

            Bitmap bmap = new Bitmap(mWidth, mHeight);

            foreach (Cluster k in mClusters)
            {
                if (k.getPoints().Count <= 0) continue;
                Color color = k.getMean().getColor();
                foreach (Point p in k.getPoints())
                {
                    bmap.SetPixel(p.x, p.y, color);
                }
            }
            
            pb02.Image = bmap;
        }
    }

    class Point
    {
        public float r;
        public float g;
        public float b;
        public int x;
        public int y;

        public Point(float r, float g, float b, int x, int y)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.x = x;
            this.y = y;
        }

        public double distance(Point p)
        {
            return Math.Abs(p.r - r) + Math.Abs(p.g - g) + Math.Abs(p.b - b);
            // return Math.Sqrt(Math.Pow(p.r - r, 2) + Math.Pow(p.g - g, 2) + Math.Pow(p.b - b, 2));
        }

        public Color getColor()
        {
            return Color.FromArgb((int)r, (int)g, (int)b);
        }
    }

    class Cluster
    {
        private static float DIFF = 0.01f;
        private Point mean;
        private List<Point> points = new List<Point>();

        public Cluster(float r, float g, float b)
        {
            mean = new Point(r, g, b, 0, 0);
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

        public bool updateMean()
        {
            float or = mean.r, og = mean.g, ob = mean.b;

            float r = 0, g = 0, b = 0;

            foreach (Point p in points)
            {
                r += p.r;
                g += p.g;
                b += p.b;
            }

            mean.r = r / points.Count;
            mean.g = g / points.Count;
            mean.b = b / points.Count;

            if (Math.Abs(mean.r - or) > DIFF || Math.Abs(mean.g - og) > DIFF || Math.Abs(mean.b - ob) > DIFF)
                return true;
            return false;
        }

        public List<Point> getPoints()
        {
            return points;
        }

    }
}
