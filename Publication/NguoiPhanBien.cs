using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Publication
{
    public partial class NguoiPhanBien : Form
    {
        public NguoiPhanBien()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCNTTNPB cntt = new FormCNTTNPB();
            cntt.Show();
            this.Hide();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormCNPBNPB cnpb = new FormCNPBNPB();
            cnpb.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormXDSBBTML xdsbbtml = new FormXDSBBTML();
            xdsbbtml.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormXDSBBTG xdsbbtg = new FormXDSBBTG();
            xdsbbtg.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FormXDSTGNBBPBN xdstgnbbpbn = new FormXDSTGNBBPBN();
            xdstgnbbpbn.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FormXKQPBBBNN xkqpbbbnn = new FormXKQPBBBNN();
            xkqpbbbnn.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FormX3BB x3bb = new FormX3BB();
            x3bb.Show();
            this.Hide();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FormXTBBB5N xtbbb5n = new FormXTBBB5N();
            xtbbb5n.Show();
            this.Hide();
        }
    }
}
