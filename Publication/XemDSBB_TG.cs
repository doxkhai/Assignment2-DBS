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
    public partial class XemDSBB_TG : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ILBOEHR\KHAI;Initial Catalog=Publication;Integrated Security=True");
        public XemDSBB_TG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BBT bBT = new BBT();
            this.Hide();
            bBT.Show();
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

        private void XemDSBB_TG_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType= CommandType.Text;
            cmd.CommandText = " select * from ARTICLE where cAuthor_ID = '"+ textBox1.Text +"' and p_status = '"+ comboBox1.SelectedItem.ToString() +"' ";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }
    }
}
