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

namespace MIT_Cafeteria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string connection = "Data Source = LAPTOP-HL5QHKF9;" +
               "Initial Catalog = master;" +
               "Integrated Security=true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from employee where empname='" + username+ "'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int pwd = 0;

            while (reader.Read())
            {
                pwd = Convert.ToInt32(reader.GetValue(0));
            }

            if (pwd == Convert.ToInt32(password))
            {
                this.Hide();
                DashBoard frm = new DashBoard();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Wrong Password", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
