using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayXanhForm
{
    public partial class frmphieudidoi : Form
    {
        public frmphieudidoi()
        {
            InitializeComponent();
        }

        private void frmphieudidoi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LichSuCay.HienThi();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LichSuCay lsc = new LichSuCay(txtTuNoi.Text, txtDenNoi.Text, txtKQ.Text);
            lsc.Them();
            dataGridView1.DataSource = LichSuCay.HienThi();
            MessageBox.Show("Them thanh cong");
            txtMa.Clear();
            txtTuNoi.Clear();
            txtDenNoi.Clear();
            txtKQ.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LichSuCay lsc = new LichSuCay(txtMa.Text , txtTuNoi.Text, txtDenNoi.Text, txtKQ.Text);
            lsc.Sua();
            dataGridView1.DataSource = LichSuCay.HienThi();
            MessageBox.Show("Sua thanh cong");

            txtMa.Clear();
            txtTuNoi.Clear();
            txtDenNoi.Clear();
            txtKQ.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LichSuCay lsc = new LichSuCay(txtMa.Text,txtTuNoi.Text, txtDenNoi.Text, txtKQ.Text);
            lsc.Xoa();
            dataGridView1.DataSource = LichSuCay.HienThi();
            MessageBox.Show("Xoa thanh cong");
            txtMa.Clear();
            txtTuNoi.Clear();
            txtDenNoi.Clear();
            txtKQ.Clear();
        }

        private void txtTuNoi_TextChanged(object sender, EventArgs e)
        {
            txtKQ.Text = txtTuNoi.Text + " -> " + txtDenNoi.Text;
        }

        private void txtDenNoi_TextChanged(object sender, EventArgs e)
        {
            txtKQ.Text = txtTuNoi.Text + " -> " + txtDenNoi.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTuNoi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDenNoi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtKQ.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem.Text=="")
            {
                dataGridView1.DataSource = LichSuCay.HienThi();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LichSuCay.TimKiem(txtTimKiem.Text);
        }
    }
}
