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
    public partial class FormPCPB : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUFLAP-HVT;Initial Catalog=Publication;Integrated Security=True");
        public FormPCPB()
        {
            InitializeComponent();
        }
        public void display()
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
            
            
            //for(int i = 0; i < dtb.Rows.Count; i++)
            //{
              //  MessageBox.Show(dtb.Rows[i][5].ToString());
            //}

            con.Close();
        }

        private void FormPCPB_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT COUNT(*) FROM REVIEW WHERE article_ID LIKE '" + textBox3.Text + "' ";
            int articleIDcount = (int)sqlCommand.ExecuteScalar();
            if (articleIDcount > 0)
            {
                MessageBox.Show("Bài phản biện đã tồn tại!");
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into REVIEW(article_ID,reviewer_ID) values('" + textBox3.Text + "','" + textBox2.Text + "');";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from REVIEW";
                cmd.ExecuteNonQuery();
                DataTable dtb = new DataTable();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dtb);
                cmd.CommandText = "update ARTICLE SET review_ID = '" + dtb.Rows[0][0] +"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insert Success!");
            }
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            display();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE REVIEW SET reviewer_ID = '"+ textBox2.Text +"' WHERE review_ID = '"+ textBox1.Text +"' ";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            display();
            MessageBox.Show("Update success!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " UPDATE REVIEW SET reviewer_ID = NULL WHERE review_ID = '" + textBox1.Text + "'  ";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            display();
            MessageBox.Show("Delete success!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from REVIEW where review_ID ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }
    }
}
