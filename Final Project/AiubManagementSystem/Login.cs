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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        SqlConnection connection = new SqlConnection("Data Source=AKIBRAHMAN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from UserTbl where UserName = '" + txtUser.Text + "'and password = '" + txtPassword.Text + "'", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (txtUser.Text=="" || txtPassword.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                if ( cmbRole.SelectedIndex>-1)
                {
                    if(cmbRole.SelectedItem.ToString() == "Administration")
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            MainForm Home = new MainForm();
                            Home.Show();
                            this.Hide();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                    }
                    else
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Dashboard d = new Dashboard();
                            d.Show();
                            this.Hide();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                    }
                }
            }
            
            connection.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
