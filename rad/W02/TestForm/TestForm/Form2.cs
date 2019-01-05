using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form2 : Form
    {

        private string msg = "";

        public Form2(string msg)
        {
            InitializeComponent();

            this.msg = msg;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblMsg.Text = msg;
        }
    }
}
