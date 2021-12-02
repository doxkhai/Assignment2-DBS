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
    public partial class CapNhatBaiBao : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Publication;Integrated Security=True");
        public CapNhatBaiBao()
        {
            InitializeComponent();
        }

        private void CapNhatBaiBao_Load(object sender, EventArgs e)
        {
            display();
        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ARTICLE where sent_status = 0";
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
            cmd.CommandText = "insert into ARTICLE values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "', '" + textBox6.Text + "' , '" + textBox7.Text + "' , '" + textBox8.Text + "')";
            MessageBox.Show(textBox8.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            display();
            MessageBox.Show("Insert Success!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ARTICLE where article_ID = '" + textBox1.Text + "'";
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
            cmd.CommandText = "update ARTICLE set article_ID = '" + textBox1.Text + "', summary = '" + textBox2.Text + "', file_bb = '" + textBox3.Text + "', p_status = '" + textBox4.Text + "', title = '" + textBox5.Text + "' , keyword = '" + textBox6.Text + "' , send_date = '" + textBox7.Text + "' , cAuthor_ID = '" + textBox8.Text + "' where article_ID = '" + textBox1.Text + "' where sent_status = 0";
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
            cmd.CommandText = "select * from ARTICLE where article_ID ='" + textBox1.Text + "' and sent_status = 0";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tacgia newForm = new Tacgia();
            newForm.Show();
            this.Hide();
        }
    }
}
