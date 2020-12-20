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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string usename = textBox1.Text;
            string password = textBox2.Text;
            if (usename == "admin" && password == "admin")
            {
                FormHeThong frm = new FormHeThong();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn nhập sai tài khoản hoặc mật khẩu", "Sai tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
