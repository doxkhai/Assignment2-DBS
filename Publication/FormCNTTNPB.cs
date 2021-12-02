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
    public partial class FormCNTTNPB : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUFLAP-HVT;Initial Catalog=Publication;Integrated Security=True");
        public FormCNTTNPB()
        {
            InitializeComponent();
        }

        private void CNTT_Load(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from REVIEWER";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (textBox6.Text == "") cmd.CommandText = "insert into REVIEWER values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "',NULL)";
            else cmd.CommandText = "insert into REVIEWER values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            display();
            MessageBox.Show("Insert Success!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from REVIEWER where author_ID = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            display();
            MessageBox.Show("Delete Success!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update REVIEWER set author_ID = '" + textBox1.Text + "', author_email = '" + textBox2.Text + "', a_address = '" + textBox3.Text + "', dept = '" + textBox4.Text + "', job = '" + textBox5.Text + "', reviewer_ID ='" + textBox6.Text + "' where author_ID = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            display();
            MessageBox.Show("Update Success!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from REVIEWER where author_ID ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
            NguoiPhanBien npb = new NguoiPhanBien();
            npb.Show();
            this.Hide();
        }

        
    }
}
