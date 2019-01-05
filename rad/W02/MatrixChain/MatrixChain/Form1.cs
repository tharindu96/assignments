using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixChain
{
    public partial class Form1 : Form
    {
        List<Matrix> mMatrices = new List<Matrix>();
        int mCurrentMatrix = -1;

        private void setLabel(int i)
        {
            if (i == 0)
            {
                lblMatrix.Text = "";
            }
            else
            {
                lblMatrix.Text = i.ToString();
            }
        }

        private void displayMatrix(Matrix A)
        {
            txtNum11.Text = A.GetCell(0, 0).ToString();
            txtNum12.Text = A.GetCell(0, 1).ToString();
            txtNum13.Text = A.GetCell(0, 2).ToString();
            txtNum21.Text = A.GetCell(1, 0).ToString();
            txtNum22.Text = A.GetCell(1, 1).ToString();
            txtNum23.Text = A.GetCell(1, 2).ToString();
            txtNum31.Text = A.GetCell(2, 0).ToString();
            txtNum32.Text = A.GetCell(2, 1).ToString();
            txtNum33.Text = A.GetCell(2, 2).ToString();
        }

        private void displayAnswerMatrix(Matrix A)
        {
            txtAns11.Text = A.GetCell(0, 0).ToString();
            txtAns12.Text = A.GetCell(0, 1).ToString();
            txtAns13.Text = A.GetCell(0, 2).ToString();
            txtAns21.Text = A.GetCell(1, 0).ToString();
            txtAns22.Text = A.GetCell(1, 1).ToString();
            txtAns23.Text = A.GetCell(1, 2).ToString();
            txtAns31.Text = A.GetCell(2, 0).ToString();
            txtAns32.Text = A.GetCell(2, 1).ToString();
            txtAns33.Text = A.GetCell(2, 2).ToString();
        }

        private void clearDisplayMatrix()
        {
            txtNum11.Text = "";
            txtNum12.Text = "";
            txtNum13.Text = "";
            txtNum21.Text = "";
            txtNum22.Text = "";
            txtNum23.Text = "";
            txtNum31.Text = "";
            txtNum32.Text = "";
            txtNum33.Text = "";
        }

        private void enableDisplayMatrix(bool enable)
        {
            txtNum11.Enabled = enable;
            txtNum12.Enabled = enable;
            txtNum13.Enabled = enable;
            txtNum21.Enabled = enable;
            txtNum22.Enabled = enable;
            txtNum23.Enabled = enable;
            txtNum31.Enabled = enable;
            txtNum32.Enabled = enable;
            txtNum33.Enabled = enable;
        }

        private void clearDisplayAnswerMatrix()
        {
            txtAns11.Text = "";
            txtAns12.Text = "";
            txtAns13.Text = "";
            txtAns21.Text = "";
            txtAns22.Text = "";
            txtAns23.Text = "";
            txtAns31.Text = "";
            txtAns32.Text = "";
            txtAns33.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearDisplayMatrix();
            clearDisplayAnswerMatrix();
            setLabel(0);
            enableDisplayMatrix(false);
            mMatrices.Clear();
            mCurrentMatrix = -1;
            btnClear.Enabled = false;
            btnDeleteMatrix.Enabled = false;
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            btnMultiply.Enabled = false;
        }

        private void btnNewMatrix_Click(object sender, EventArgs e)
        {
            Matrix A = new Matrix();
            mMatrices.Add(A);
            mCurrentMatrix = mMatrices.Count - 1;
            setLabel(mMatrices.Count);
            displayMatrix(A);
            enableDisplayMatrix(true);

            btnMultiply.Enabled = true;
            btnClear.Enabled = true;
            btnDeleteMatrix.Enabled = true;

            btnPrev.Enabled = (mCurrentMatrix > 0);
            btnNext.Enabled = (mCurrentMatrix < mMatrices.Count - 1);
        }

        private void btnMatrix_TextChange(object sender, EventArgs e)
        {
            if (mCurrentMatrix == -1) return;

            TextBox t = (TextBox)sender;

            int val;
            try
            {
                val = int.Parse(t.Text);
            } catch(Exception)
            {
                val = 0;
            }

            string s = t.Name.Substring("txtNum".Length);
            int i = int.Parse(s[0].ToString()) - 1;
            int j = int.Parse(s[1].ToString()) - 1;

            mMatrices[mCurrentMatrix].SetCell(i, j, val);
        }

        private void btnMatrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (mCurrentMatrix >= mMatrices.Count - 1) return;

            mCurrentMatrix++;
            displayMatrix(mMatrices[mCurrentMatrix]);
            setLabel(mCurrentMatrix + 1);

            btnPrev.Enabled = (mCurrentMatrix > 0);
            btnNext.Enabled = (mCurrentMatrix < mMatrices.Count - 1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (mCurrentMatrix <= 0) return;

            mCurrentMatrix--;
            displayMatrix(mMatrices[mCurrentMatrix]);
            setLabel(mCurrentMatrix + 1);

            btnPrev.Enabled = (mCurrentMatrix > 0);
            btnNext.Enabled = (mCurrentMatrix < mMatrices.Count - 1);
        }

        private void btnDeleteMatrix_Click(object sender, EventArgs e)
        {
            if (mCurrentMatrix == -1) return;
            mMatrices.RemoveAt(mCurrentMatrix);
            if (mMatrices.Count == 0)
            {
                mCurrentMatrix = -1;
                btnClear_Click(sender, e);
                return;
            }

            if (mMatrices.Count - 1 <= mCurrentMatrix)
            {
                mCurrentMatrix = mMatrices.Count - 1;
            }

            displayMatrix(mMatrices[mCurrentMatrix]);
            setLabel(mCurrentMatrix + 1);

            btnPrev.Enabled = (mCurrentMatrix > 0);
            btnNext.Enabled = (mCurrentMatrix < mMatrices.Count - 1);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Matrix A = new Matrix(new int[3,3] {
                {1, 0, 0 },
                {0, 1, 0 },
                {0, 0, 1 }
            });

            for (int i = 0; i < mMatrices.Count; i++)
            {
                A = Matrix.Multiply(A, mMatrices[i]);
            }

            displayAnswerMatrix(A);
        }
    }

    class Matrix
    {
        private int[,] mData = new int[3,3];

        public Matrix(int[,] data)
        {
            mData = data;
        }

        public Matrix()
        {

        }

        public void SetCell(int i, int j, int v)
        {
            mData[i, j] = v;
        }

        public int GetCell(int i, int j)
        {
            return mData[i, j];
        }

        public static Matrix Multiply(Matrix A, Matrix B)
        {
            Matrix ret = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ret.SetCell(i, j, multiplyCell(A, B, i, j));
                }
            }
            return ret;
        }

        private static int multiplyCell(Matrix A, Matrix B, int i, int j)
        {
            int ret = 0;
            for (int k = 0; k < 3; k++)
            {
                ret += A.GetCell(i, k) * B.GetCell(k, j);
            }
            return ret;
        }

    }

}
