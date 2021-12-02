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
    public partial class LoginFORM : Form
    {
        public LoginFORM()
        {
            InitializeComponent();
        }

        private void LoginFORM_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=TUFLAP-HVT;Initial Catalog=Publication;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from USERINFO where username = '" + textBox1.Text + "' and pass = '" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString() == cmbItemValue)
                    {

                        if (comboBox1.SelectedIndex == 0)
                        {
                            MessageBox.Show("Bạn đã đăng nhập với tư cách là " + dt.Rows[i][2]);
                            Tacgia newForm = new Tacgia();
                            newForm.Show();
                            this.Hide();
                        }

                        else if (comboBox1.SelectedIndex == 1)
                        {
                            MessageBox.Show("Bạn đã đăng nhập với tư cách là " + dt.Rows[i][2]);
                            BBT newForm = new BBT();
                            newForm.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Bạn đã đăng nhập với tư cách là " + dt.Rows[i][2]);
                            NguoiPhanBien newForm = new NguoiPhanBien();
                            newForm.Show();
                            this.Hide();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thoát chương trình ?");
            Application.Exit();
        }
    }
}
