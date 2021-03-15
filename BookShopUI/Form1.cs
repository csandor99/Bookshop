using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace BookShopUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=260499;database=online_library");
            if (comboBox1.Text == "Customer")
            {
                string query = "Select * from customers Where Username = '" + textBox1.Text.Trim() + "' and Pass = '" + textBox2.Text.Trim() + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                try
                {
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count >= 1)
                    {
                        MessageBox.Show("Login successfully");
                        this.Hide();
                        Form2 f2 = new Form2("Welcome to your account: " + textBox1.Text);
                        f2.MyProperty = textBox1.Text;
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("User or password incorrect");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(comboBox1.Text == "Employee")
            {
                string query = "Select * from employees Where Username = '" + textBox1.Text.Trim() + "' and Pass = '" + textBox2.Text.Trim() + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                try
                {
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count >= 1)
                    {
                        MessageBox.Show("Login successfully");
                        Form3 f3 = new Form3();
                        this.Hide();
                        f3.Show();
                    }
                    else
                    {
                        MessageBox.Show("User or password incorrect");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please choose the type of the account");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
