using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.ObjectModel;


namespace GiaoDien.MenuTab
{
    public partial class frmSanPham : Form
    {

        public class SanPham
        {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuongTon { get; set; }
            public string MoTa { get; set; }
            public string MaLoaiSanPham { get; set; } // Thêm thuộc tính mã loại sản phẩm
            public string TenLoaiSanPham { get; set; } // Thêm thuộc tính tên loại sản phẩm
        }

        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        public frmSanPham()
        {
            InitializeComponent();
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("QL_VLXD");
            collection = database.GetCollection<BsonDocument>("SanPham");
        }
        bool checkThem;
        int indexGrid;
        void voHieuHoaControl()
        {
            checkThem = false;
            indexGrid = -1;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            txtDonGia.Enabled = false;
            txtMaSP.Enabled = false;    
            txtMoTa.Enabled = false;    
            txtSoLuongTon.Enabled = false;
            txtTenSP.Enabled = false;   
        }
        void enableText()
        {
            txtDonGia.Enabled = true;
            txtMaSP.Enabled = true;
            txtMoTa.Enabled = true;
            txtSoLuongTon.Enabled = true;
            txtTenSP.Enabled = true;
        }
        void clearText()
        {
            txtDonGia.Text = string.Empty;
            txtMaSP.Text = string.Empty;
            txtMoTa.Text = string.Empty;
            txtSoLuongTon.Text = string.Empty;
            txtTenSP.Text = string.Empty;
        }
        void enableCacControl()
        {
            if (indexGrid != -1)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                checkThem = false;
                
            }
        }
        Dictionary<string, string> loaisp = new Dictionary<string, string>();
        void loadcboLoaiSP()
        {
            try
            {
                // Lấy tất cả tài liệu từ collection
                var documents = collection.Find(new BsonDocument()).ToList();

                // Tạo một danh sách các loại sản phẩm (MaLoaiSanPham + TenLoaiSanPham)
                foreach (var document in documents)
                {
                    string maLoaiSanPham = document["MaLoaiSanPham"].AsString;
                    string tenLoaiSanPham = document["TenLoaiSanPham"].AsString;
                    loaisp.Add(maLoaiSanPham, tenLoaiSanPham);
                    // Hiển thị dữ liệu dưới dạng "MaLoaiSanPham - TenLoaiSanPham" trong ComboBox
                    
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = loaisp;

                cboLoaiSP.DataSource = bs;
                cboLoaiSP.DisplayMember = "Value";  // Hiển thị TenLoaiSanPham
                cboLoaiSP.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu loại sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            checkThem = false;
            voHieuHoaControl();
            LoadSanPham();
            loadcboLoaiSP();
        }

        private void LoadSanPham()
        {
            try
            {
                var sanPhamList = new List<SanPham>();
                var documents = collection.Find(new BsonDocument()).ToList();

                foreach (var document in documents)
                {
                    if (document.Contains("SanPham") && document["SanPham"].IsBsonArray)
                    {
                        var loaiSanPham = document["SanPham"].AsBsonArray;
                        var maLoaiSanPham = document["MaLoaiSanPham"].AsString; // Lấy mã loại sản phẩm
                        var tenLoaiSanPham = document["TenLoaiSanPham"].AsString; // Lấy tên loại sản phẩm

                        foreach (var sp in loaiSanPham)
                        {
                            sanPhamList.Add(new SanPham
                            {
                                MaSanPham = sp["MaSanPham"].AsString,
                                TenSanPham = sp["TenSanPham"].AsString,
                                DonGia = ConvertToDecimal(sp["DonGia"]),
                                SoLuongTon = sp["SoLuongTon"].ToInt32(),
                                MoTa = sp["MoTa"].AsString,
                                MaLoaiSanPham = maLoaiSanPham, // Thêm mã loại sản phẩm
                                TenLoaiSanPham = tenLoaiSanPham // Thêm tên loại sản phẩm
                            });
                        }
                    }
                }

                gridSanPham.DataSource = sanPhamList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal ConvertToDecimal(BsonValue value)
        {

            if (value.IsDecimal128)
            {
                decimal asDecimal128 = (decimal)value.AsDecimal128;
                return asDecimal128;
            }
            else if (value.IsDouble)
            {
                return Convert.ToDecimal(value.AsDouble);
            }
            else if (value.IsInt32)
            {
                return Convert.ToDecimal(value.AsInt32);
            }
            else if (value.IsInt64)
            {
                return Convert.ToDecimal(value.AsInt64);
            }
            else
            {
                throw new InvalidCastException("Unable to cast the value to decimal.");
            }
        }

        void hienDuLieuKhiClick()
        {
            if (gridSanPham.SelectedRows.Count > 0)
            {
                // Lấy hàng đã chọn
                var selectedRow = gridSanPham.SelectedRows[0];

                // Gán giá trị vào các control

                txtMaSP.Text = selectedRow.Cells["MaSanPham"].Value.ToString();
                txtTenSP.Text = selectedRow.Cells["TenSanPham"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                txtSoLuongTon.Text = selectedRow.Cells["SoLuongTon"].Value.ToString();
                txtMoTa.Text = selectedRow.Cells["MoTa"].Value.ToString();
                cboLoaiSP.SelectedValue = selectedRow.Cells["MaLoaiSanPham"].Value.ToString();
                // Gán loại sản phẩm cho ComboBox (cần đảm bảo rằng giá trị tương ứng tồn tại trong cboLoaiSP)
                 // Thay "LoaiSP" bằng tên cột trong DataGridView nếu cần
            }
        }
        private void gridSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexGrid = e.RowIndex;
            enableCacControl();
            hienDuLieuKhiClick();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            checkThem = true;
            enableText();
            clearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            enableText();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkThem) // Nếu đang trong chế độ thêm sản phẩm
                {
                    // Lấy thông tin sản phẩm từ các TextBox
                    string maSanPham = txtMaSP.Text;
                    string tenSanPham = txtTenSP.Text;
                    decimal donGia = decimal.Parse(txtDonGia.Text);
                    int soLuongTon = int.Parse(txtSoLuongTon.Text);
                    string moTa = txtMoTa.Text;
                    string maLoaiSanPham = cboLoaiSP.SelectedValue.ToString(); // Lấy mã loại sản phẩm từ ComboBox

                    // Tạo tài liệu BSON cho sản phẩm mới
                    var newSanPham = new BsonDocument
            {
                { "MaSanPham", maSanPham },
                { "TenSanPham", tenSanPham },
                { "DonGia", donGia },
                { "SoLuongTon", soLuongTon },
                { "MoTa", moTa }
            };

                    // Tạo bộ lọc để tìm tài liệu theo MaLoaiSanPham
                    var filter = Builders<BsonDocument>.Filter.Eq("MaLoaiSanPham", maLoaiSanPham);

                    // Đẩy sản phẩm mới vào mảng "SanPham" của tài liệu tìm được
                    var update = Builders<BsonDocument>.Update.Push("SanPham", newSanPham);

                    // Thực hiện cập nhật
                    collection.UpdateOne(filter, update);

                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset các trường thông tin sau khi lưu
                    txtMaSP.Clear();
                    txtTenSP.Clear();
                    txtDonGia.Clear();
                    txtSoLuongTon.Clear();
                    txtMoTa.Clear();

                    // Tải lại dữ liệu sản phẩm sau khi thêm mới
                    LoadSanPham();
                }
                else
                {
                    // Lấy thông tin sản phẩm từ các TextBox
                    string maSanPham = txtMaSP.Text; // Mã sản phẩm hiện tại (đã chọn từ grid)
                    string tenSanPham = txtTenSP.Text;
                    decimal donGia = decimal.Parse(txtDonGia.Text);
                    int soLuongTon = int.Parse(txtSoLuongTon.Text);
                    string moTa = txtMoTa.Text;

                    // Tìm sản phẩm trong mảng "SanPham" để sửa
                    var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonDocument>(
                        "SanPham", Builders<BsonDocument>.Filter.Eq("MaSanPham", maSanPham));

                    // Cập nhật thông tin sản phẩm
                    var update = Builders<BsonDocument>.Update
                        .Set("SanPham.$.TenSanPham", tenSanPham)
                        .Set("SanPham.$.DonGia", donGia)
                        .Set("SanPham.$.SoLuongTon", soLuongTon)
                        .Set("SanPham.$.MoTa", moTa);

                    var result = collection.UpdateOne(filter, update);

                    if (result.ModifiedCount > 0)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearText(); // Reset các trường thông tin sau khi lưu
                        LoadSanPham(); // Tải lại dữ liệu sản phẩm sau khi sửa
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Vô hiệu hóa các nút sau khi hoàn thành
                voHieuHoaControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            voHieuHoaControl();
        }

        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
