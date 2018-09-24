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

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private const string Conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=c:\\users\\dell\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\Database1.mdf;Integrated Security=True";
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Conn);
            String k = textBox1.Text;
            String s = textBox2.Text;
            String u = textBox3.Text;
            if (u == s)
            {
                SqlCommand cmd6 = new SqlCommand("insert into USERNAME(username,password) values(@us,@ps)", con);
                cmd6.Parameters.AddWithValue("us", k);
                cmd6.Parameters.AddWithValue("ps", s);
                con.Open();
                int i = cmd6.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registered Successfully,LOG IN!!");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Passwords dont match");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
