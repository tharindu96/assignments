using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Group8_work
{
    public partial class Form1 : Form
    {
        bool keepClustering = true;
        int MAX_ITERATIONS = 100;
        int MAX_CLUSTERS = 20;
        int MAX_THREADS = Environment.ProcessorCount * 4;

        bool loaded = false;
        int mHeight, mWidth;

        Bitmap mBitmap;

        List<Cluster> mClusters = new List<Cluster>();
        List<ColorPoint> mColorPoints = null;
        Dictionary<ColorPoint, List<PixelPoint>> mColorPointDict = new Dictionary<ColorPoint, List<PixelPoint>>();

        List<Workload> mClusteringWorkload = new List<Workload>();

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
            pbProgress.Value = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!loaded) return;

            mColorPointDict.Clear();
            mClusters.Clear();
            pb01.Image = null;
            pb02.Image = null;

            btnClear.Enabled = false;
            btnConvert.Enabled = false;
            btnLoadImage.Enabled = true;
            btnSaveImage.Enabled = false;
            loaded = false;
            keepClustering = false;
            mBitmap = null;
            pbProgress.Value = 0;
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (!loaded) return;
            if (mBitmap == null) return;

            DialogResult r = sfd_image.ShowDialog();
            if (r == DialogResult.Cancel) return;

            string fname = sfd_image.FileName;

            if (!fname.EndsWith(".jpg"))
                fname += ".jpg";
            
            mBitmap.Save(@fname, ImageFormat.Jpeg);
        }

        private void updateClusteringWorkload()
        {
            mClusteringWorkload.Clear();
            int w = mColorPoints.Count / MAX_THREADS;
            for (int i = 0; i < MAX_THREADS - 1; i++)
            {
                mClusteringWorkload.Add(new Workload(i * w, (i + 1) * w - 1));
            }
            mClusteringWorkload.Add(new Workload(w * (MAX_THREADS - 1), mColorPoints.Count - 1));
        }

        private void initClustering()
        {
            if (!loaded) return;
            
            mClusters.Clear();
            HashSet<ColorPoint> mSet = new HashSet<ColorPoint>();
            Random rand = new Random();

            for (int i = 0; i < MAX_CLUSTERS; i++)
            {
                ColorPoint p = mColorPoints[rand.Next(0, mColorPoints.Count)];
                while (mSet.Contains(p))
                {
                    p = mColorPoints[rand.Next(0, mColorPoints.Count)];
                }
                mClusters.Add(new Cluster(p.r, p.g, p.b));
            }

            updateClusteringWorkload();

            keepClustering = true;
        }

        private void runClustering()
        {
            pbProgress.Maximum = MAX_ITERATIONS;
            pbProgress.Value = 0;
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                if (!keepClustering) break;
                runOneClusteringStep();
                pbProgress.Value += 1;
            }
            pbProgress.Value = MAX_ITERATIONS;
        }

        private void runClusteringThread(Workload workload)
        {

            Cluster c;
            ColorPoint p;
            for (int i = workload.start; i <= workload.end; i++)
            {
                p = mColorPoints[i];
                c = getClosestCluster(p);
                c.addPoint(p);
            }
        }

        private void runOneClusteringStep()
        {
            foreach (Cluster k in mClusters)
            {
                k.clearPoints();
            }

            List<Thread> lt = new List<Thread>();

            foreach(Workload w in mClusteringWorkload)
            {
                Thread t = new Thread(() => runClusteringThread(w));
                t.Start();
                lt.Add(t);
            }

            foreach(Thread t in lt)
            {
                t.Join();
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

        private Cluster getClosestCluster(ColorPoint p)
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

            mColorPoints = null;
            mClusters.Clear();
            mColorPointDict.Clear();

            mHeight = bmap.Height;
            mWidth = bmap.Width;

            pbProgress.Maximum = mWidth * mHeight;
            pbProgress.Value = 0;

            for (int i = 0; i < mHeight; i++)
            {
                for (int j = 0; j < mWidth; j++)
                {
                    Color pixel = bmap.GetPixel(j, i);
                    ColorPoint cp = new ColorPoint(pixel.R, pixel.G, pixel.B);
                    List<PixelPoint> lpp;
                    if (mColorPointDict.ContainsKey(cp))
                    {
                        lpp = mColorPointDict[cp];
                    }
                    else
                    {
                        lpp = new List<PixelPoint>();
                        mColorPointDict[cp] = lpp;
                    }
                    PixelPoint pp = new PixelPoint(j, i);
                    lpp.Add(pp);
                    pbProgress.Value += 1;
                }
            }

            mColorPoints = mColorPointDict.Keys.ToList();

            btnLoadImage.Enabled = false;
            btnClear.Enabled = true;
            btnConvert.Enabled = true;
            loaded = true;
            keepClustering = true;
            drawBitmap();

            pbProgress.Value = 0;
        }

        private void drawBitmap()
        {
            if (!loaded) return;

            Bitmap bmap = new Bitmap(mWidth, mHeight);

            foreach (Cluster k in mClusters)
            {
                if (k.getPoints().Count <= 0) continue;

                Color color = k.getMean().getColor();

                foreach (ColorPoint cp in k.getPoints())
                {
                    foreach (PixelPoint p in mColorPointDict[cp])
                    {
                        bmap.SetPixel(p.x, p.y, color);
                    }
                }
            }

            mBitmap = bmap;
            pb02.Image = bmap;

            btnSaveImage.Enabled = true;
        }
    }

    class Workload
    {
        public int start = 0;
        public int end = 0;
        public Workload(int s, int e)
        {
            start = s;
            end = e;
        }
    }

    class ColorPoint : IEquatable<ColorPoint>
    {
        public int r;
        public int g;
        public int b;
        public List<PixelPoint> points;

        public ColorPoint(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            points = new List<PixelPoint>();
        }

        public double distance(ColorPoint p)
        {
            return Math.Abs(p.r - r) + Math.Abs(p.g - g) + Math.Abs(p.b - b);
            // return Math.Sqrt(Math.Pow(p.r - r, 2) + Math.Pow(p.g - g, 2) + Math.Pow(p.b - b, 2));
        }

        public Color getColor()
        {
            return Color.FromArgb(r, g, b);
        }

        public bool Equals(ColorPoint other)
        {
            return (other.r == r && other.g == g && other.b == b);
        }

        public override int GetHashCode()
        {

            return r * 0xff00 + g * 0xff + b;
        }
    }

    class PixelPoint
    {
        public int x;
        public int y;

        public PixelPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Cluster
    {
        private static float DIFF = 0.1f;
        private ColorPoint mean;
        private List<ColorPoint> points = new List<ColorPoint>();
        private Mutex mutexPoints = new Mutex();

        public Cluster(int r, int g, int b)
        {
            mean = new ColorPoint(r, g, b);
        }
        
        public ColorPoint getMean()
        {
            return mean;
        }

        public void clearPoints()
        {
            points.Clear();
        }

        public void addPoint(ColorPoint p)
        {
            mutexPoints.WaitOne();
            points.Add(p);
            mutexPoints.ReleaseMutex();
        }

        public bool updateMean()
        {
            float or = mean.r, og = mean.g, ob = mean.b;

            float r = 0, g = 0, b = 0;

            foreach (ColorPoint p in points)
            {
                r += p.r;
                g += p.g;
                b += p.b;
            }

            mean.r = (int)(r / points.Count);
            mean.g = (int)(g / points.Count);
            mean.b = (int)(b / points.Count);

            if (mean.r < 0) mean.r = 0;
            if (mean.g < 0) mean.g = 0;
            if (mean.b < 0) mean.b = 0;

            if (mean.r > 255) mean.r = 255;
            if (mean.g > 255) mean.g = 255;
            if (mean.b > 255) mean.b = 255;

            if (Math.Abs(mean.r - or) > DIFF || Math.Abs(mean.g - og) > DIFF || Math.Abs(mean.b - ob) > DIFF)
                return true;

            return false;
        }

        public List<ColorPoint> getPoints()
        {
            return points;
        }

    }
}
