using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesDatabase
{
    public partial class Form1 : Form
    {

        DatabaseConnection objConnect;
        string conString;

        DataSet ds;
        DataRow dRow;

        int MaxRows;
        int inc = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new DatabaseConnection();
                conString = Properties.Settings.Default.EmployeeConnectionString;

                objConnect.connection_string = conString;
                objConnect.Sql = Properties.Settings.Default.SELECT_ALL;

                ds = objConnect.GetConnection;
                MaxRows = ds.Tables[0].Rows.Count;

                showEntry(inc);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void showEntry(int i)
        {
            txtFname.Text = ds.Tables[0].Rows[i].ItemArray.GetValue(1).ToString();
            txtLname.Text = ds.Tables[0].Rows[i].ItemArray.GetValue(2).ToString();
            txtJob.Text = ds.Tables[0].Rows[i].ItemArray.GetValue(3).ToString();
            txtDep.Text = ds.Tables[0].Rows[i].ItemArray.GetValue(4).ToString();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (inc <= 0) return;
            showEntry(--inc);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc >= MaxRows - 1) return;
            showEntry(++inc);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            row[1] = txtFname.Text;
            row[2] = txtLname.Text;
            row[3] = txtJob.Text;
            row[4] = txtDep.Text;

            ds.Tables[0].Rows.Add(row);

            try
            {
                objConnect.UpdateTable(ds);
                MaxRows += 1;
                inc = MaxRows - 1;
                MessageBox.Show("Updated!");
            } catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
