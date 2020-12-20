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
    public partial class frmCay : Form
    {
        public frmCay()
        {
            InitializeComponent();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmloaicay frm = new frmloaicay();
            frm.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmloaicay frm = new frmloaicay();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmphieudidoi frm = new frmphieudidoi();
            frm.Show();
        }
        private void VoidLoad()
        {
            dataGridView1.DataSource = Cay.HienThi();

            cbbLoaicay.DataSource = Cay.HienThiCBB("select *from LoaiCay");
            cbbLoaicay.DisplayMember = "TenLoai";
            cbbLoaicay.ValueMember = "MaLoai";


            cbbLichSu.DataSource = Cay.HienThiCBB("select *from LichSuCay");
            cbbLichSu.DisplayMember = "KetQua";
            cbbLichSu.ValueMember = "MaLichSu";
        }
        private void frmCay_Load(object sender, EventArgs e)
        {

            VoidLoad();

        }

        private void brnThem_Click(object sender, EventArgs e)
        {
            Cay c = new Cay(txtMaCay.Text, txtTenCay.Text, txtTuoi.Text,cbbLoaicay.SelectedValue.ToString(), cbbLichSu.SelectedValue.ToString(), dtpNgayTrong.Value.ToString("MM/dd/yyyy"),txtGhiChu.Text);
            c.Them();
            VoidLoad();
            MessageBox.Show("Them thanh cong");
            txtMaCay.Clear();
            txtTenCay.Clear();
            txtTuoi.Clear();
            txtGhiChu.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCay.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenCay.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTuoi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dtpNgayTrong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbbLoaicay.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbbLichSu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtGhiChu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Cay c = new Cay(txtMaCay.Text, txtTenCay.Text, txtTuoi.Text, cbbLoaicay.SelectedValue.ToString(), cbbLichSu.SelectedValue.ToString(), dtpNgayTrong.Value.ToString("MM/dd/yyyy"), txtGhiChu.Text);
            c.Sua();
            VoidLoad();
            MessageBox.Show("Sua thanh cong");
            txtMaCay.Clear();
            txtTenCay.Clear();
            txtTuoi.Clear();
            txtGhiChu.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            Cay c = new Cay(txtMaCay.Text, txtTenCay.Text, txtTuoi.Text, cbbLoaicay.SelectedValue.ToString(), cbbLichSu.SelectedValue.ToString(), dtpNgayTrong.Value.ToString("MM/dd/yyyy"), txtGhiChu.Text);
            c.Xoa();
            VoidLoad();
            MessageBox.Show("Xoa thanh cong");
            txtMaCay.Clear();
            txtTenCay.Clear();
            txtTuoi.Clear();
            txtGhiChu.Clear();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimkiem.Text == "")
            {
                VoidLoad();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Cay.TimKiem(txtTimkiem.Text);
        }
    }
}
