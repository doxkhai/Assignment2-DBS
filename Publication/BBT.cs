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
namespace Publication
{
    public partial class BBT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ILBOEHR\KHAI;Initial Catalog=Publication;Integrated Security=True");
        public BBT()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPCPB pcpb = new FormPCPB();
            pcpb.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDSBB dsbb = new FormDSBB();
            dsbb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            U_TTXL u_TTXL = new U_TTXL();
            u_TTXL.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            U_KQPB u_KQPB  = new U_KQPB();
            u_KQPB.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XemDSBB_TG xemDSBB_TG = new XemDSBB_TG();
            xemDSBB_TG.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(article_ID) AS ToTalEach, p_status FROM ARTICLE GROUP BY p_status ORDER BY ToTalEach DESC ;  ";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ARTICLE";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from REVIEW";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginFORM loginFORM = new LoginFORM();
            this.Hide();
            loginFORM.Show();
        }
    }
}
