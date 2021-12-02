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
    public partial class Tacgia : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Publication;Integrated Security=True");
        public Tacgia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapNhatThongTin newForm = new CapNhatThongTin();
            newForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapNhatBaiBao newForm = new CapNhatBaiBao();
            newForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XemThongTinTacGia newForm = new XemThongTinTacGia();
            newForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrangThaiBaiBao newForm = new TrangThaiBaiBao();
            newForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XemKetQuaPhanBien newForm = new XemKetQuaPhanBien();
            newForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginFORM newForm = new LoginFORM();
            MessageBox.Show("Bạn đã đăng xuât");
            newForm.Show();
            this.Hide();
        }
    }
}
