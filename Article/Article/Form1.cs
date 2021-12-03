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

namespace Article
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ILBOEHR\KHAI;Initial Catalog=Publication;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (textBox8.Text == "") textBox8.Text = null;
            cmd.CommandText = "insert into ARTICLE values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "', '"+textBox6.Text+"' , '"+textBox7.Text+"' , '"+textBox8.Text+"' , '"+textBox9.Text+"')";
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
            textBox9.Text = "";
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
            cmd.CommandText = "update ARTICLE set article_ID = '" + textBox1.Text + "', summary = '" + textBox2.Text + "', file_bb = '" + textBox3.Text + "', p_status = '" + textBox4.Text + "', title = '" + textBox5.Text + "' , keyword = '"+textBox6.Text+"' , send_date = '"+textBox7.Text+"' , cAuthor_ID = '"+textBox8.Text+"' , review_ID = '"+textBox9.Text+"' where article_ID = '" + textBox1.Text + "'";
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
            cmd.CommandText = "select * from ARTICLE where article_ID ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }
    }
}
