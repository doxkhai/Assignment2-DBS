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
    public partial class U_KQPB : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ILBOEHR\KHAI;Initial Catalog=Publication;Integrated Security=True");
        public U_KQPB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BBT bBT = new BBT();
            this.Close();
            bBT.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE REVIEW SET REVIEW.noti_date ='"+ DateTime.Parse(dateTimePicker1.Text) +"' , REVIEW.other_detail ='"+ textBox2.Text +"' ,REVIEW.result ='"+ comboBox2.SelectedItem.ToString() +"' FROM REVIEW INNER JOIN ARTICLE ON ARTICLE.article_ID = REVIEW.article_ID WHERE ARTICLE.p_status ='"+comboBox1.SelectedItem.ToString()+"' and ARTICLE.article_ID = '"+int.Parse(textBox1.Text)+"' ; ";
            cmd.ExecuteNonQuery();
            con.Close();
            display();
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
            con.Close();
        }

        private void U_KQPB_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
