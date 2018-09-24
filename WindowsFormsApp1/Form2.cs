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
    public partial class Form2 : Form
    {
        public static int m;
        public static int initialnumber;
        public static float initialrate;
        public static string cab;
        string[] area = new string[10];
        private const string Conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=c:\\users\\dell\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\Database1.mdf;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand("select AREANAMES from areadata", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            //Connection open here
            int j = 0;

            while (reader.Read())
            {
    
                area[j] = reader.GetString(0);
                j++;
            }
            int i = 0;
            while(i<=j)
            {
                if (area[i] != null)
                {
                    comboBox1.Items.Add(area[i]);
                    comboBox2.Items.Add(area[i]);
                }
                i++;
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string s = Form1.s;
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand("select * from FARE where AREANAME1=@ar1 and AREANAME2=@ar2 union select * from FARE where AREANAME1=@ar2 and AREANAME2=@ar1",con);
            cmd.Parameters.AddWithValue("@ar1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ar2", comboBox2.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            //Connection open here
            int n = 0;
            while (reader.Read())
            {
                n = reader.GetInt32(2);
            }
            con.Close();
            con.Open();
            SqlCommand cmd5 = new SqlCommand("select * from USERNAME where username=@user", con);
            cmd5.Parameters.AddWithValue("user", s);
            SqlDataReader reader2 = cmd5.ExecuteReader();
            while(reader2.Read())
            {
                m = reader2.GetInt32(3);
            }
            con.Close();
            con.Open();
            SqlCommand cmd6 = new SqlCommand("select * from DISCOUNT where @m>TRIPS", con);
            cmd6.Parameters.AddWithValue("m", m);
            SqlDataReader reader4 = cmd6.ExecuteReader();
            int r=0;
            while(reader4.Read())
            {
                r = reader4.GetInt32(1);
            }
            con.Close();
            float f = n - (((float)r) / 100) * ((float)n);
            label1.Text = f.ToString();
            float k = float.Parse(comboBox3.Text);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select *  from DRIVER where AREA=@ar3 and RATING>@ra", con);
            cmd2.Parameters.AddWithValue("@ar3", comboBox1.Text);
            cmd2.Parameters.AddWithValue("@ra", k);
            SqlDataAdapter adap = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select *  from DRIVER where AREA=@ar4 and RATING>@r", con);
            cmd3.Parameters.AddWithValue("@ar4", comboBox1.Text);
            cmd3.Parameters.AddWithValue("@r", k);
            SqlDataReader reader1 = cmd3.ExecuteReader();
            while (reader1.Read())
            {
                comboBox4.Items.Add(reader1.GetString(1));

            }
            
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cab = comboBox4.Text;
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand("update USERNAME set trips=@t where username=@name", con);
            cmd.Parameters.AddWithValue("t",m+1);
            cmd.Parameters.AddWithValue("name",Form1.s);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
    }

