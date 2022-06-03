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
    public partial class DashBoard : Form
    {
        string query;
       

        public DashBoard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order ord = new Order();
            ord.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addEmployee adEmp = new addEmployee();
            adEmp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "Data Source = LAPTOP-HL5QHKF9;" +
                "Initial Catalog = master;" +
                "Integrated Security=true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from Orders";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string final = "Phone Number" + "\t" + "Item Number" + "\t\t" + "Total Bill" +"\t\t " + "Payment" + "\n";
            while (reader.Read())
            {
                string output = reader.GetValue(0) + "\t\t" + reader.GetValue(1) + "\t\t" + reader.GetValue(2) + "\t\t" + reader.GetValue(3) + "\n";
                final += output;
            }
            richTextBox1.Text = final;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "Data Source = LAPTOP-HL5QHKF9;" +
               "Initial Catalog = master;" +
               "Integrated Security=true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from customers";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string final = "Name" + "\t" + "Phone" + "\t\t" + "City" + "\t\t" + "Street" + "\n";
            while (reader.Read())
            {
                string output = reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3) + "\n";
                final += output;
            }
            richTextBox1.Text = final;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connection = "Data Source = LAPTOP-HL5QHKF9;" +
               "Initial Catalog = master;" +
               "Integrated Security=true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from employee";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string final = "ID" + "\t " + "Name" + "\t " + "Desg" + "\t " + "DOB" + "\t\t\t" + "Phone"+ "\n";
            while (reader.Read())
            {
                string output = reader.GetValue(0) + "\t " + reader.GetValue(1) + "\t " + reader.GetValue(2) + "\t " + reader.GetValue(3) + "\t " + reader.GetValue(4) + "\n";
                final += output;
            }
            richTextBox1.Text = final;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connection = "Data Source = LAPTOP-HL5QHKF9;" +
                "Initial Catalog = master;" +
                "Integrated Security=true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from branch";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string final = "ID" + "\t\t" + "Name" + "\t\t" + "Block" + "\t" + "\n";
            while (reader.Read())
            {
                string output = reader.GetValue(0) + "\t\t" + reader.GetValue(1) + "\t\t" + reader.GetValue(2) + "\n";
                final += output;
            }
            richTextBox1.Text = final;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
