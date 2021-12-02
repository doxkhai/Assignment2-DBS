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
    public partial class BBT : Form
    {
        public BBT()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPCPB pcpb = new FormPCPB();
            pcpb.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDSBB dsbb = new FormDSBB();
            dsbb.Show();
            this.Hide();
        }
    }
}
