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
    public partial class Form2 : Form
    {
        public Form2(string username)
        {
            InitializeComponent();
            label2.Text = username;
            FillCombo();
        }
        public string MyProperty { get; set; }

        void FillCombo()
        {
            string constring = "server = localhost; user id = root; password = 260499; database = online_library";
            string Query = "select * from category";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while(myReader.Read())
                {
                    string sName = myReader.GetString("cat_name");
                    comboBox1.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_libraryDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.online_libraryDataSet.products);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=260499;database=online_library");
            if (checkBox1.CheckState == CheckState.Checked)
            {
                try
                {
                    sqlcon.Open();
                    DataTable dtDiscount = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand("select * from discountview",sqlcon))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        dtDiscount.Load(reader);
                    }
                    dataGridView1.DataSource = dtDiscount;
                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("Connection error");
                }
            }
            else
            {
                try
                {
                    sqlcon.Open();
                    DataTable dtProducts = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT p.description,p.price FROM productcategory pc INNER JOIN products p ON  pc.id_prd = p.id_prod INNER JOIN category c ON pc.id_cat = c.id_category where c.cat_name = '" + comboBox1.Text + "' order by description; ", sqlcon))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        dtProducts.Load(reader);
                    }
                    dataGridView1.DataSource = dtProducts;
                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("Connection error");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection("server=localhost;user id=root;password=260499;database=online_library");
            try
            {
                sqlcon.Open();
                DataTable dtOrder = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("SELECT products.description,payment.mode,orders.cantity,orders.order_date FROM orders INNER JOIN products ON  orders.id_P = products.id_prod INNER JOIN payment ON orders.id_Pay = payment.id_payment INNER JOIN customers on orders.id_C = customers.id_cust where customers.Username = '" + MyProperty + "' ; ", sqlcon))
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
