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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=260499;database=online_library");
            try
            {
                sqlcon.Open();
                string Query = "update online_library.stock set cantity= " + this.textBox2.Text + " where id_stock = " + this.textBox1.Text + ";";
                MySqlCommand cmdInsert = new MySqlCommand(Query, sqlcon);
                MySqlDataReader reader = cmdInsert.ExecuteReader();
                MessageBox.Show("Updated");
                while (reader.Read())
                { }
                sqlcon.Close();
            }
            catch
            {
                    MessageBox.Show("Connection error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=260499;database=online_library");
            try
            {
                sqlcon.Open();
                DataTable dtOrder = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * from stockview", sqlcon))
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
