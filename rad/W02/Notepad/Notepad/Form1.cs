using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {

        private string currentFileName = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void updateUndoEnable()
        {
            mnuUndo.Enabled = txtMain.CanUndo;
        }

        private void updateSelection()
        {
            if (txtMain.SelectionLength > 0)
            {
                mnuCut.Enabled = true;
                mnuCopy.Enabled = true;
                mnuDelete.Enabled = true;
            }
            else
            {
                mnuCut.Enabled = false;
                mnuCopy.Enabled = false;
                mnuDelete.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateSelection();
            updateUndoEnable();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            ofdMain.ShowDialog();
            currentFileName = ofdMain.FileName;
            if (currentFileName == null || currentFileName == "")
            {
                currentFileName = null;
                return;
            }

            txtMain.Text = System.IO.File.ReadAllText(currentFileName);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (currentFileName == null)
            {
                sfdMain.ShowDialog();
                currentFileName = sfdMain.FileName;
                if (currentFileName == null || currentFileName == null)
                {
                    return;
                }
                return;
            }
            System.IO.File.WriteAllText(currentFileName, txtMain.Text);
        }

        private void mnuSaveAS_Click(object sender, EventArgs e)
        {
            sfdMain.ShowDialog();
            currentFileName = sfdMain.FileName;
            if (currentFileName == null || currentFileName == null)
            {
                return;
            }
            System.IO.File.WriteAllText(currentFileName, txtMain.Text);
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (currentFileName != null)
            {
                mnuSave_Click(sender, e);
            }
            currentFileName = null;
            txtMain.Text = "";
        }

        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            updateUndoEnable();
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            txtMain.Undo();
        }

        private void txtMain_MouseClick(object sender, MouseEventArgs e)
        {
            updateSelection();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            txtMain.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            txtMain.Copy();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            string x = Clipboard.GetText();
            txtMain.Cut();
            Clipboard.SetText(x);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            txtMain.Paste();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            txtMain.SelectAll();
        }

        private void mnuTimeDate_Click(object sender, EventArgs e)
        {
            txtMain.SelectedText = DateTime.Now.ToString("HH:mm tt MM/dd/yyyy");
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}
