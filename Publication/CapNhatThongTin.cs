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
    public partial class CapNhatThongTin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Publication;Integrated Security=True");
        public CapNhatThongTin()
        {
            InitializeComponent();
        }

        private void CapNhatThongTin_Load(object sender, EventArgs e)
        {
            display();
        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from AUTHOR";
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
            if (textBox6.Text == "") cmd.CommandText = "insert into AUTHOR values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "',NULL)";
            else cmd.CommandText = "insert into AUTHOR values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
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
            cmd.CommandText = "delete from AUTHOR where author_ID = '" + textBox1.Text + "'";
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
            cmd.CommandText = "update AUTHOR set author_ID = '" + textBox1.Text + "', author_email = '" + textBox2.Text + "', a_address = '" + textBox3.Text + "', dept = '" + textBox4.Text + "', job = '" + textBox5.Text + "', reviewer_ID ='" + textBox6.Text + "' where author_ID = '" + textBox1.Text + "'";
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
            cmd.CommandText = "select * from AUTHOR where author_ID ='" + textBox1.Text + "'";
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
