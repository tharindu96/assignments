using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S03P04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            int firstNumber;
            int secondNumber;

            firstNumber = int.Parse(txtBox1.Text);
            secondNumber = int.Parse(txtBox2.Text);

            if (firstNumber > secondNumber)
            {
                MessageBox.Show("first number is greater than second number");
            } else
            {
                MessageBox.Show("first number is less than second number");
            }
        }
    }
}
