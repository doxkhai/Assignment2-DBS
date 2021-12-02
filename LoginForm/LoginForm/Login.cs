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

namespace LoginForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Publication;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from [USER] where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            
            if (dt.Rows.Count > 0) {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString() == cmbItemValue) {
                        
                        if (comboBox1.SelectedIndex == 0)
                        {
                            MessageBox.Show("You are login as " + dt.Rows[i][2]);
                            Author newForm = new Author();
                            newForm.Show();
                            this.Hide();
                        }

                        else if (comboBox1.SelectedIndex == 1)
                        {
                            MessageBox.Show("You are login as " + dt.Rows[i][2]);
                            Ban_Bien_Tap newForm = new Ban_Bien_Tap();
                            newForm.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("You are login as " + dt.Rows[i][2]);
                            Nguoi_Phan_Bien newForm = new Nguoi_Phan_Bien();
                            newForm.Show();
                            this.Hide();
                        }
                    }
                }

            }
            else {
                MessageBox.Show("Account doesn't exist!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
