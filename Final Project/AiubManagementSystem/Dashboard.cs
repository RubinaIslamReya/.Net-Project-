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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=AKIBRAHMAN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        private void Dashboard_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from StudentTbl", connection);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            lblStudent.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from StudentTbl", connection);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            lblAccount.Text = "TK "+Convert.ToInt32(dt1.Rows[0][0].ToString())*65000;

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from TeacherTbl", connection);
            DataTable dt2 = new DataTable();
            sda3.Fill(dt2);
            lblTeacher.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda4 = new SqlDataAdapter("select count(*) from StaffTbl", connection);
            DataTable dt3 = new DataTable();
            sda4.Fill(dt3);
            lblStaff.Text = dt3.Rows[0][0].ToString();

            SqlDataAdapter sda5 = new SqlDataAdapter("select count(*) from DeptTable", connection);
            DataTable dt4 = new DataTable();
            sda5.Fill(dt4);
            lblDept.Text = dt4.Rows[0][0].ToString();
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
