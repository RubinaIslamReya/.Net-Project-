using DataAccessLayer.Entities;
using DataAccessLayer.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiubManagementSystem
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }
        private void Department_Load(object sender, EventArgs e)
        {
            ODepartment oDepartment = new ODepartment();
            SqlDataAdapter sqlDataAdapter = oDepartment.Show();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridViewDepartment.DataSource = dataTable;
        }

        private void btnDAdd_Click(object sender, EventArgs e)
        {
            EDepartment eDepartment = new EDepartment();
            eDepartment.DName = txtDName.Text;
            eDepartment.DDuration = txtDDuration.Text;

            ODepartment oDepartment = new ODepartment();
            oDepartment.Add(eDepartment);

            //for auto showing in girdview
            SqlDataAdapter sqlDataAdapter = oDepartment.Show();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridViewDepartment.DataSource = dataTable;

            try
            {
                if (eDepartment.DName == "" || eDepartment.DDuration == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    MessageBox.Show("Department Successfully Added");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void btnDEdit_Click(object sender, EventArgs e)
        {
            EDepartment eDepartment = new EDepartment();
            eDepartment.DName = txtDName.Text;
            eDepartment.DDuration = txtDDuration.Text;

            ODepartment oDepartment = new ODepartment();
            oDepartment.Edit(eDepartment);

            //for auto showing in girdview
             SqlDataAdapter sqlDataAdapter = oDepartment.Show();
             DataTable dataTable = new DataTable();
             sqlDataAdapter.Fill(dataTable);
             dataGridViewDepartment.DataSource = dataTable;

            try
            {
                if (eDepartment.DName == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    MessageBox.Show("Department Updated Successfully");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void btnDDelete_Click(object sender, EventArgs e)
        {
            EDepartment eDepartment = new EDepartment();
            eDepartment.DName = txtDName.Text;
            eDepartment.DDuration = txtDDuration.Text;

            ODepartment oDepartment = new ODepartment();
            oDepartment.Delete(eDepartment);

            //for auto showing in girdview
            SqlDataAdapter sqlDataAdapter = oDepartment.Show();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridViewDepartment.DataSource = dataTable;

            try
            {
                if (eDepartment.DName == "")
                {
                    MessageBox.Show("Enter Department Name");
                }
                else
                {
                    MessageBox.Show("Department deleted Successfully");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSback_Click(object sender, EventArgs e)
        {

            MainForm home = new MainForm();
            home.Show();
            this.Hide();
        }
    }
}
