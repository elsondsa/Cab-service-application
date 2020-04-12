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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=c:\\users\\dell\\source\\repos\\WindowsFormsApp1 - Copy\\WindowsFormsApp1\\Database1.mdf;Integrated Security=True";
        public static string s;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt = new DataTable();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("procedure", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@param1", SqlDbType.VarChar);
                param1.Value = textBox1.Text;

                SqlParameter param2 = new SqlParameter("@param2", SqlDbType.Int);
                param2.Value = Convert.ToInt32(textBox2.Text);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                // cmd.Parameters.Add(param2);....

                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            con.Close();

            if (dt.Rows.Count > 0)
            {
                s = textBox1.Text;
                MessageBox.Show("Successfully logged in");
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter Correct Username and Password");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}


