using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S03P05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int loopStart;
            int loopEnd;
            int multipleOf;

            bool isNumber;

            isNumber = int.TryParse(textBox1.Text, out loopStart);
            if(!isNumber)
            {
                MessageBox.Show("Please Enter a valid number!");
                return;
            }

            isNumber = int.TryParse(textBox2.Text, out loopEnd);
            if (!isNumber)
            {
                MessageBox.Show("Please Enter a valid number!");
                return;
            }

            isNumber = int.TryParse(textBox3.Text, out multipleOf);
            if (!isNumber)
            {
                MessageBox.Show("Please Enter a valid number!");
                return;
            }

            int ans = 0;

            listBox1.Items.Clear();

            for (int i = loopStart; i <= loopEnd; i++)
            {
                ans = i * multipleOf;
                listBox1.Items.Add(i + " times " + multipleOf + " = " + ans);
            }
        }
    }
}
