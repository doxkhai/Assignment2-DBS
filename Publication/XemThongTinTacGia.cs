﻿using System;
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
    public partial class XemThongTinTacGia : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Publication;Integrated Security=True");
        public XemThongTinTacGia()
        {
            InitializeComponent();
        }

        private void XemThongTinTacGia_Load(object sender, EventArgs e)
        {
            display();
        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from WRITING";
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
            cmd.CommandText = "select author_ID from WRITING where article_ID ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dtb);
            dataGridView1.DataSource = dtb;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tacgia newForm = new Tacgia();
            newForm.Show();
            this.Hide();
        }
    }
}
