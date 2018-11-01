using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioCheckbox
{
    public partial class Form1 : Form
    {

        List<CheckBox> selectedMovies = new List<CheckBox>();
        List<RadioButton> favMovies = new List<RadioButton>();

        private void initLists()
        {
            selectedMovies.Add(chkComedy);
            selectedMovies.Add(chkAction);
            selectedMovies.Add(chkScienceFiction);
            selectedMovies.Add(chkRomance);
            selectedMovies.Add(chkAnimation);

            favMovies.Add(rdoComedy);
            favMovies.Add(rdoAction);
            favMovies.Add(rdoScienceFiction);
            favMovies.Add(rdoRomance);
            favMovies.Add(rdoAnimation);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectedMovies_Click(object sender, EventArgs e)
        {
            if (selectedMovies.Count() == 0 && favMovies.Count() == 0)
            {
                initLists();
            }

            string movies = "";
            
            foreach(CheckBox b in selectedMovies) {
                if (b.Checked)
                {
                    movies += b.Text + "\r\n";
                }
            }

            MessageBox.Show(movies);

        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            if (selectedMovies.Count() == 0 && favMovies.Count() == 0)
            {
                initLists();
            }
            foreach (RadioButton b in favMovies)
            {
                if (b.Checked)
                {
                    MessageBox.Show("Your favourite movies are of type: " + b.Text + "\r\n");
                    break;
                }
            }
        }
    }
}
