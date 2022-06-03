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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        int token = 1001;
        string payment = "";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "Data Source = LAPTOP-HL5QHKF9;" +
                "Initial Catalog = master;" +
                "Integrated Security=true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from menu_items";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string final = "Item No." + "\t " + "Name" + "\t\t" + "Stock" + "\t " + "\n";
            while (reader.Read())
            {
                string output = reader.GetValue(0) + "\t " + reader.GetValue(3) + "\t\t" + reader.GetValue(2) + "\n";
                final += output;
            }
            richTextBox1.Text = final;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String phone = textBox2.Text;
            string selected_Item = comboBox1.SelectedItem.ToString();
            if(radioButton1.Checked == true)
            {
                payment = "UPI";
            }else if(radioButton2.Checked == true)
            {
                payment = "Cash";
            }
            string connection = "Data Source = LAPTOP-HL5QHKF9;" +
               "Initial Catalog = master;" +
               "Integrated Security=true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from menu_items where item_name = "+ "'" + selected_Item + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            bool isAvailable = true;
            int price = 0;
            int stock = 0;

            while (reader.Read())
            {
                price = Convert.ToInt32(reader.GetValue(1));
                stock = Convert.ToInt32(reader.GetValue(2));
            }
            
            if(stock < 1)
            {
                MessageBox.Show("Item Out of stock", "Item Unavailable");
            }
            else
            {
                con.Close();
                string final_bill = "Name: " + name +"\n"+
                     "Phone No: " + phone + "\n" +
                      "Token: " + token + "\n" +
                      "Item: " + selected_Item + "\n"+
                       "Total Bill: " + price + "\n";
                token++;
                stock = stock - 1;

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("order_in", con);

                    SqlCommand cmd2 = new SqlCommand("customer_in", con);
                    int i;

                try
                {
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@cname", name);
                    cmd2.Parameters.AddWithValue("@phno", phone);
                    cmd2.Parameters.AddWithValue("@city", "Manipal");
                    cmd2.Parameters.AddWithValue("@street", "Main Road");

                    i = cmd2.ExecuteNonQuery();

                    if (i != 0)
                    {
                        MessageBox.Show("Customer Insertion Successful!", "Captions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Customer Already Exists", "Captions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Customer Already Exists", "Captions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    


                    //To execute a stored procedure

                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@phno", phone);
                    cmd1.Parameters.AddWithValue("@itemNo", comboBox1.SelectedIndex + 1);
                    cmd1.Parameters.AddWithValue("@bill_amt", price);
                    cmd1.Parameters.AddWithValue("@payment", payment);

                    i = cmd1.ExecuteNonQuery();

                    if (i != 0)
                    {
                        MessageBox.Show("Order Insertion Successful!", "Captions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Order Insertion Failed", "Captions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show(final_bill, "Bill");
                con.Close();

                con.Open();
                SqlCommand cmd3 = new SqlCommand("stock_update", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@stock", stock);
                cmd3.Parameters.AddWithValue("@item", selected_Item);
                i = cmd3.ExecuteNonQuery();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
