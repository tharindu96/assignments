using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S02P14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            int firstTextBoxNumber;
            int secondTextBoxNumber;
            int thirdTextBoxNumber;
            int answer;

            firstTextBoxNumber = int.Parse(tbFirstNumber.Text);
            secondTextBoxNumber = int.Parse(tbSecondNumber.Text);
            thirdTextBoxNumber = int.Parse(tbThirdNumber.Text);

            string op1V = op1.Text;
            string op2V = op2.Text;

            answer = firstTextBoxNumber;

            switch (op1V)
            {
                case "+":
                    answer += secondTextBoxNumber;
                    break;
                case "-":
                    answer -= secondTextBoxNumber;
                    break;
                case "*":
                    answer *= secondTextBoxNumber;
                    break;
                case "/":
                    if (secondTextBoxNumber != 0)
                    {
                        answer /= secondTextBoxNumber;
                    }
                    break;
            }

            switch (op2V)
            {
                case "+":
                    answer += thirdTextBoxNumber;
                    break;
                case "-":
                    answer -= thirdTextBoxNumber;
                    break;
                case "*":
                    answer *= thirdTextBoxNumber;
                    break;
                case "/":
                    if (thirdTextBoxNumber != 0)
                    {
                        answer /= thirdTextBoxNumber;
                    }
                    break;
            }

            MessageBox.Show(answer.ToString());
        }
    }
}
