using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookShopUI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=260499;database=online_library");
            try
            {
                sqlcon.Open();
                DataTable dtCust = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("select * from customers", sqlcon)) 
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtCust.Load(reader);
                }
                dataGridView1.DataSource = dtCust;
                sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("Connection error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=260499;database=online_library");
            try
            {
                sqlcon.Open();
                DataTable dtOrder = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("select * from ordersview", sqlcon))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtOrder.Load(reader);
                }
                dataGridView1.DataSource = dtOrder;
                sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("Connection error");
            }
        }
    }
}
