using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        const int OP_UND = 0;
        const int OP_ADD = 1;
        const int OP_SUB = 2;
        const int OP_MUL = 3;
        const int OP_DIV = 4;

        double answer = 0;
        int operating = OP_UND;

        bool hasPoint = false;
        bool hasInit = false;
        bool isWaitingNew = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            replaceIfZero("0");
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            replaceIfZero("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            replaceIfZero("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            replaceIfZero("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            replaceIfZero("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            replaceIfZero("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            replaceIfZero("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            replaceIfZero("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            replaceIfZero("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            replaceIfZero("9");
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (!hasPoint)
            {
                txtDisplay.Text += ".";
                hasPoint = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            txtDisplay.Text = "0";
            answer = 0;
            hasPoint = false;
            operating = OP_UND;
            hasInit = false;
            isWaitingNew = true;
        }

        private void replaceIfZero(string val)
        {
            if(txtDisplay.Text == "0" || isWaitingNew == true)
            {
                if(isWaitingNew) isWaitingNew = false;
                txtDisplay.Text = val;
            } else
            {
                txtDisplay.Text += val;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double n = double.Parse(txtDisplay.Text);
            switch (operating)
            {
                case OP_ADD:
                    answer += n;
                    break;
                case OP_SUB:
                    answer -= n;
                    break;
                case OP_MUL:
                    answer *= n;
                    break;
                case OP_DIV:
                    if (n == 0)
                    {
                        clearAll();
                        txtDisplay.Text = "Undefined Division by Zero!";
                    }
                    answer /= n;
                    break;
                case OP_UND:
                    answer = n;
                    break;
            }
            isWaitingNew = true;
            hasPoint = false;
            txtDisplay.Text = answer.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operating = OP_ADD;
            if (!hasInit)
            {
                double n = double.Parse(txtDisplay.Text);
                hasInit = true;
                answer = n;
            }
            isWaitingNew = true;
            hasPoint = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            operating = OP_SUB;
            if (!hasInit)
            {
                double n = double.Parse(txtDisplay.Text);
                hasInit = true;
                answer = n;
            }
            isWaitingNew = true;
            hasPoint = false;
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            operating = OP_MUL;
            if (!hasInit)
            {
                double n = double.Parse(txtDisplay.Text);
                hasInit = true;
                answer = n;
            }
            isWaitingNew = true;
            hasPoint = false;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            operating = OP_DIV;
            if (!hasInit)
            {
                double n = double.Parse(txtDisplay.Text);
                hasInit = true;
                answer = n;
            }
            isWaitingNew = true;
            hasPoint = false;
        }
    }
}
