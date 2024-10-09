using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiaoDien.MenuTab;

namespace GiaoDien
{
    public partial class frmTrangChu : Form
    {
        private Form TrangCon;
        public frmTrangChu()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lblTime.Text = datetime.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void motrangcon(Form trangcon)
        {
            if (TrangCon != null)
            {
                TrangCon.Close();

            }
            TrangCon = trangcon;
            trangcon.TopLevel = false;
            trangcon.FormBorderStyle = FormBorderStyle.None;
            trangcon.Dock = DockStyle.Fill;
            pnlGiaoDienChucNang.Controls.Add(trangcon);
            pnlGiaoDienChucNang.Tag = trangcon;
            trangcon.BringToFront();
            trangcon.Show();
            //labelcon.Text = trangcon.Text;
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            motrangcon(new frmSanPham());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmDangNhap formDangNhap = new frmDangNhap();
            formDangNhap.Show();

        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            motrangcon(new frmKhachHang());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            motrangcon(new frmNhanVien());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            motrangcon(new frmDonHang());
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            motrangcon(new frmPhieuNhap());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            motrangcon(new frmThongKe());
        }
    }
}
