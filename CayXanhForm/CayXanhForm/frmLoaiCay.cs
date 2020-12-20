using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayXanhForm
{
    public partial class frmloaicay : Form
    {
        public frmloaicay()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmCay frm = new frmCay();
            frm.Show();
        }

        private void frmloaicay_Load(object sender, EventArgs e)
        {
            ClassLoaiCay lc = new ClassLoaiCay();
            dataGridView1.DataSource = lc.HienThi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLoaiCay lc = new ClassLoaiCay(txtMa.Text, txtTen.Text, txtGhiChu.Text);
                lc.Them();
                MessageBox.Show("Them thanh cong");
                dataGridView1.DataSource = lc.HienThi();
                txtMa.Clear();
                txtTen.Clear();
                txtGhiChu.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClassLoaiCay lc = new ClassLoaiCay(txtMa.Text, txtTen.Text, txtGhiChu.Text);
                lc.Sua();
                MessageBox.Show("Sua thanh cong");
                dataGridView1.DataSource = lc.HienThi();
                txtMa.Clear();
                txtTen.Clear();
                txtGhiChu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClassLoaiCay lc = new ClassLoaiCay(txtMa.Text, txtTen.Text, txtGhiChu.Text);
                lc.Xoa();
                MessageBox.Show("Xoa thanh cong");
                dataGridView1.DataSource = lc.HienThi();
                txtMa.Clear();
                txtTen.Clear();
                txtGhiChu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                ClassLoaiCay lc = new ClassLoaiCay();
                dataGridView1.DataSource = lc.HienThi();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ClassLoaiCay lc = new ClassLoaiCay();
            dataGridView1.DataSource =  lc.TimKiem(txtTimKiem.Text);

        }
    }
}
