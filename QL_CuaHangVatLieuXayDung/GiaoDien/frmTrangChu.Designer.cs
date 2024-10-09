namespace GiaoDien
{
    partial class frmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDangXuat = new FontAwesome.Sharp.IconButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnNhanVien = new FontAwesome.Sharp.IconButton();
            this.btnTrangChu = new FontAwesome.Sharp.IconButton();
            this.btnThongKe = new FontAwesome.Sharp.IconButton();
            this.btnPhieuNhap = new FontAwesome.Sharp.IconButton();
            this.btnDonHang = new FontAwesome.Sharp.IconButton();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnSanPham = new FontAwesome.Sharp.IconButton();
            this.pnlGiaoDienChucNang = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnDangXuat);
            this.pnlMenu.Controls.Add(this.lblTime);
            this.pnlMenu.Controls.Add(this.btnNhanVien);
            this.pnlMenu.Controls.Add(this.btnTrangChu);
            this.pnlMenu.Controls.Add(this.btnThongKe);
            this.pnlMenu.Controls.Add(this.btnPhieuNhap);
            this.pnlMenu.Controls.Add(this.btnDonHang);
            this.pnlMenu.Controls.Add(this.btnKhachHang);
            this.pnlMenu.Controls.Add(this.btnSanPham);
            this.pnlMenu.Location = new System.Drawing.Point(3, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(224, 620);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnDangXuat.IconColor = System.Drawing.Color.White;
            this.btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 556);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(221, 61);
            this.btnDangXuat.TabIndex = 9;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(36, 60);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(73, 20);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "00:00:00";
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnNhanVien.IconColor = System.Drawing.Color.White;
            this.btnNhanVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 205);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(221, 61);
            this.btnNhanVien.TabIndex = 7;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Enabled = false;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.btnTrangChu.IconColor = System.Drawing.Color.White;
            this.btnTrangChu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 3);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(221, 61);
            this.btnTrangChu.TabIndex = 6;
            this.btnTrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrangChu.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.IconChar = FontAwesome.Sharp.IconChar.TachometerAltFast;
            this.btnThongKe.IconColor = System.Drawing.Color.White;
            this.btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(0, 388);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(221, 61);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuNhap.ForeColor = System.Drawing.Color.White;
            this.btnPhieuNhap.IconChar = FontAwesome.Sharp.IconChar.ArrowUpFromGroundWater;
            this.btnPhieuNhap.IconColor = System.Drawing.Color.White;
            this.btnPhieuNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhieuNhap.Location = new System.Drawing.Point(0, 327);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(221, 61);
            this.btnPhieuNhap.TabIndex = 4;
            this.btnPhieuNhap.Text = "Phiếu Nhập";
            this.btnPhieuNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhieuNhap.UseVisualStyleBackColor = true;
            this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonHang.ForeColor = System.Drawing.Color.White;
            this.btnDonHang.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.btnDonHang.IconColor = System.Drawing.Color.White;
            this.btnDonHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDonHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHang.Location = new System.Drawing.Point(0, 266);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(221, 61);
            this.btnDonHang.TabIndex = 3;
            this.btnDonHang.Text = "Đơn Hàng";
            this.btnDonHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDonHang.UseVisualStyleBackColor = true;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btnKhachHang.IconColor = System.Drawing.Color.White;
            this.btnKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 144);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(221, 61);
            this.btnKhachHang.TabIndex = 2;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.ForeColor = System.Drawing.Color.White;
            this.btnSanPham.IconChar = FontAwesome.Sharp.IconChar.Magento;
            this.btnSanPham.IconColor = System.Drawing.Color.White;
            this.btnSanPham.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.Location = new System.Drawing.Point(0, 83);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(221, 61);
            this.btnSanPham.TabIndex = 0;
            this.btnSanPham.Text = "Sản Phẩm";
            this.btnSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // pnlGiaoDienChucNang
            // 
            this.pnlGiaoDienChucNang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGiaoDienChucNang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGiaoDienChucNang.Location = new System.Drawing.Point(233, 2);
            this.pnlGiaoDienChucNang.Name = "pnlGiaoDienChucNang";
            this.pnlGiaoDienChucNang.Size = new System.Drawing.Size(890, 620);
            this.pnlGiaoDienChucNang.TabIndex = 1;
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1125, 623);
            this.Controls.Add(this.pnlGiaoDienChucNang);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmTrangChu";
            this.Text = "TRANG CHỦ";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private FontAwesome.Sharp.IconButton btnSanPham;
        private System.Windows.Forms.Panel pnlGiaoDienChucNang;
        private FontAwesome.Sharp.IconButton btnDonHang;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnPhieuNhap;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private FontAwesome.Sharp.IconButton btnTrangChu;
        private FontAwesome.Sharp.IconButton btnNhanVien;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private FontAwesome.Sharp.IconButton btnDangXuat;
    }
}