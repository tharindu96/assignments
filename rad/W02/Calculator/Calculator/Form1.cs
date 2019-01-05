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
    public partial class Form1 : Form, CalculatorWindow
    {
        Calculator calculator;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calculator = new Calculator(this);
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calculator.clear();
        }

        private void btnNum00_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('0');
        }

        private void btnNum01_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('1');
        }

        private void btnNum02_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('2');
        }

        private void btnNum03_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('3');
        }

        private void btnNum04_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('4');
        }

        private void btnNum05_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('5');
        }

        private void btnNum06_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('6');
        }

        private void btnNum07_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('7');
        }

        private void btnNum08_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('8');
        }

        private void btnNum09_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('9');
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            calculator.insertDigit('.');
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            calculator.insertOP(Calculator.OPERATION.NEG);
        }

        public void onCurrentValueChange(string value)
        {
            lblCurrent.Text = value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calculator.insertOP(Calculator.OPERATION.ADD);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            calculator.insertOP(Calculator.OPERATION.SUB);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            calculator.insertOP(Calculator.OPERATION.DIV);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calculator.insertOP(Calculator.OPERATION.EQUAL);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            calculator.insertOP(Calculator.OPERATION.MUL);
        }
    }
}
