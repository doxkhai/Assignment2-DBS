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
    public partial class FormDSBB : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ILBOEHR\KHAI;Initial Catalog=Publication;Integrated Security=True");
        public FormDSBB()
        {
            InitializeComponent();
        }

        private void FormDSBB_Load(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            if(comboBox1.SelectedIndex == 0)
            {
                if(comboBox2.SelectedIndex == 0) cmd.CommandText = "select * from RESEARCH full outer join ARTICLE on ARTICLE.article_ID = RESEARCH.article_ID where ARTICLE.p_status is null and ARTICLE.a_type = 'RESEARCH';";
                else cmd.CommandText = "select * from ARTICLE full outer join RESEARCH on ARTICLE.article_ID = RESEARCH.article_ID where ARTICLE.p_status = '"+ comboBox2.SelectedItem.ToString() + "' and ARTICLE.a_type = 'RESEARCH';";
                cmd.ExecuteNonQuery();
                DataTable dtb = new DataTable();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dtb);
                dataGridView1.DataSource = dtb;
            }
            else if(comboBox1.SelectedIndex == 1) 
            {
                if (comboBox2.SelectedIndex == 0) cmd.CommandText = "select * from BOOK_REVIEW full outer join ARTICLE on ARTICLE.article_ID = BOOK_REVIEW.article_ID where ARTICLE.p_status is null and ARTICLE.a_type = 'BOOK_REVIEW';";
                else cmd.CommandText = "select * from BOOK_REVIEW full outer join ARTICLE on ARTICLE.article_ID = BOOK_REVIEW.article_ID where ARTICLE.p_status = '" + comboBox2.SelectedItem.ToString() + "' and ARTICLE.a_type = 'BOOK_REVIEW';";
                cmd.ExecuteNonQuery();
                DataTable dtb = new DataTable();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dtb);
                dataGridView1.DataSource = dtb;
            }
            else
            {
                if (comboBox2.SelectedIndex == 0) cmd.CommandText = "select * from OVERVIEW full outer join ARTICLE on ARTICLE.article_ID = OVERVIEW.article_ID where ARTICLE.p_status is null and ARTICLE.a_type = 'OVERVIEW';";
                else cmd.CommandText = "select * from OVERVIEW full outer join ARTICLE on ARTICLE.article_ID = OVERVIEW.article_ID where ARTICLE.p_status = '" + comboBox2.SelectedItem.ToString() + "' and ARTICLE.a_type = 'OVERVIEW';";
                cmd.ExecuteNonQuery();
                DataTable dtb = new DataTable();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dtb);
                dataGridView1.DataSource = dtb;
            }

            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            BBT bBT = new BBT();
            bBT.Show();
        }
    }
}
