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
    public partial class Form3 : Form
    {
        private const string Conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=c:\\users\\dell\\source\\repos\\WindowsFormsApp1 - Copy\\WindowsFormsApp1\\Database1.mdf;Integrated Security=True";
        double netrate;
        int rate = 0;
        double initialrate;
        int initialnumber;
        string cab;
        public Form3()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                rate = 5;
            else if (radioButton2.Checked)
                rate = 4;
            else if (radioButton3.Checked)
                rate = 3;
            else if (radioButton4.Checked)
                rate = 2;
            else if (radioButton5.Checked)
                rate = 1;
            netrate = (initialrate * initialnumber + rate) / (initialnumber + 1);
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand("update DRIVER set RATING=@r where DNAME=@ar1", con);
            cmd.Parameters.AddWithValue("ar1", cab);
            cmd.Parameters.AddWithValue("r", netrate);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
                MessageBox.Show("RATE SAVED SUCCESSFULLY, HOPE YOU ENJOYED THE TRIP");
            SqlCommand cmd7 = new SqlCommand("select tid from BookingDetails", con);
            con.Open();
            SqlDataReader reader = cmd7.ExecuteReader();
            //Connection open here
            int tid = 0;
            while (reader.Read())
            {
                tid = reader.GetInt32(0);
            }
            tid = tid + 1;
            con.Close();
            SqlCommand cmd6 = new SqlCommand("insert into BookingDetails(tid,username,drivername,areaname1,areaname2,fare) values(@qs,@us,@ps,@ph,@an,@fn)", con);
            cmd6.Parameters.AddWithValue("qs", tid);
            cmd6.Parameters.AddWithValue("us", Form1.s);
            cmd6.Parameters.AddWithValue("ps", Form2.cab);
            cmd6.Parameters.AddWithValue("ph", Form2.areaname1);
            cmd6.Parameters.AddWithValue("an", Form2.areaname2);
            cmd6.Parameters.AddWithValue("fn", Form2.f);
            con.Open();
            i = cmd6.ExecuteNonQuery();
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cab = Form2.cab;
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd5 = new SqlCommand("select RATING,NUMBERS from DRIVER where DNAME=@cab", con);
            cmd5.Parameters.AddWithValue("cab", cab);
            con.Open();
            SqlDataReader reader1 = cmd5.ExecuteReader();
            while (reader1.Read())
            {
                initialrate = reader1.GetDouble(0);
                initialnumber = reader1.GetInt32(1);
            }
            con.Close();
            con.Open();
            SqlCommand cmd6 = new SqlCommand("update DRIVER set NUMBERS=@numb where DNAME=@cabs", con);
            int k = initialnumber + 1;
            cmd6.Parameters.AddWithValue("numb", k);
            cmd6.Parameters.AddWithValue("cabs", cab);
            int i = cmd6.ExecuteNonQuery();
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
