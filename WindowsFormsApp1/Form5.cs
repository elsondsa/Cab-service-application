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
    public partial class Form5 : Form
    {
        private const string Conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\dell\\source\\repos\\WindowsFormsApp1 - Copy\\WindowsFormsApp1\\Database1.mdf;Integrated Security=True";
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = "WELCOME " + Form1.s;
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select areaname1,areaname2,drivername,fare from BookingDetails where username=@u", con);
            cmd2.Parameters.AddWithValue("@u", Form1.s);
            SqlDataAdapter adap = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
