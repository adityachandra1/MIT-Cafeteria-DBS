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
    public partial class addEmployee : Form
    {
        public addEmployee()
        {
            InitializeComponent();
        }
        string name;
        string designation;
        string phno;
        DateTime DOB;
        int empNo = 5000;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            phno = textBox4.Text;
            designation = textBox2.Text;
            DOB = dateTimePicker1.Value;
            int EmpID = empNo++;

            string show = "Name: " + name + "\n" +
                     "Phone No: " + phno + "\n" +
                      "Designation: " + designation + "\n" +
                      "DOB: " + DOB.ToString() + "\n" +
                       "Password: " + EmpID + "\n";
            try
            {
                string connection = "Data Source = LAPTOP-HL5QHKF9;" +
              "Initial Catalog = master;" +
              "Integrated Security=true";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("employee_in", con);


                //To execute a stored procedure

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", EmpID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@designation", designation);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@phno", phno);
                cmd.Parameters.AddWithValue("@worksat", "A001");

                int i = cmd.ExecuteNonQuery();

                if (i != 0)
                {
                    MessageBox.Show("Employee Insertion Successful!", "Captions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Employee Insertion Failed", "Captions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show(show, "Employee Created!");

            }catch( Exception )
            {
                MessageBox.Show("Already Exists", "Error");
            }
        }
    }
}
