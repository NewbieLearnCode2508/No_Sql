using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GiaoDien
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            txtTenDangNhap.Click += TxtTenDangNhap_Click;
            txtMatKhau.Click += TxtMatKhau_Click;
           
        }

        private void TxtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
        }

        private void TxtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy frm = new frmDangKy();
            frm.ShowDialog();
            
        }
    }
}
