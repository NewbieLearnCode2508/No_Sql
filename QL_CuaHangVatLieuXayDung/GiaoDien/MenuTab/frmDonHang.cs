using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GiaoDien.MenuTab
{
    public partial class frmDonHang : Form
    {
        private IMongoCollection<NhanVien> _nhanVienCollection;
        private IMongoCollection<SanPham> _sanPhamCollection;
        private IMongoCollection<KhachHang> _khachHangCollection;

        private List<string> selectedProductIds = new List<string>(); 
        private Dictionary<string, int> selectedQuantities = new Dictionary<string, int>(); 

        private int currentTotal;

        public frmDonHang()
        {
            InitializeComponent();
            ConnectToMongoDB();
            LoadNhanVien();
            LoadSanPham();
            LoadKhachHang();
            InitializeFields();

            currentTotal = 0;

            buttonThemDonHang.Click += buttonThemDonHang_Click;
            dataGridViewSanPham.CellValueChanged += dataGridViewSanPham_CellValueChanged;
            dataGridViewSanPham.CurrentCellDirtyStateChanged += dataGridViewSanPham_CurrentCellDirtyStateChanged;
        }

        private void ConnectToMongoDB()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("QL_VLXD"); 
            _nhanVienCollection = database.GetCollection<NhanVien>("NhanVien");
            _sanPhamCollection = database.GetCollection<SanPham>("SanPham");
            _khachHangCollection = database.GetCollection<KhachHang>("KhachHang");
        }

        private void LoadNhanVien()
        {
            var nhanViens = _nhanVienCollection.Find(FilterDefinition<NhanVien>.Empty).ToList();
            comboBoxNhanVien.DataSource = nhanViens;
            comboBoxNhanVien.DisplayMember = "TenNhanVien";
            comboBoxNhanVien.ValueMember = "MaNhanVien";
        }

        private void LoadSanPham()
        {
            var sanPhams = _sanPhamCollection.Find(FilterDefinition<SanPham>.Empty).ToList();
            var sanPhamItems = sanPhams.SelectMany(sp => sp.DSSanPham).ToList();

            var dataTable = new DataTable();
            dataTable.Columns.Add("Selected", typeof(bool)); 
            dataTable.Columns.Add("MaSanPham", typeof(string));
            dataTable.Columns.Add("TenSanPham", typeof(string));
            dataTable.Columns.Add("DonGia", typeof(decimal));
            dataTable.Columns.Add("SoLuong", typeof(int));

            foreach (var item in sanPhamItems)
            {
                dataTable.Rows.Add(false, item.MaSanPham, item.TenSanPham, item.DonGia, 1);
            }

            dataGridViewSanPham.DataSource = dataTable;

            dataGridViewSanPham.Columns["SoLuong"].ReadOnly = false; 
            dataGridViewSanPham.Columns["MaSanPham"].Visible = false; 
        }

        private void LoadKhachHang() 
        {
            var khachHangs = _khachHangCollection.Find(FilterDefinition<KhachHang>.Empty).ToList();
            comboBoxKhachHang.DataSource = khachHangs;
            comboBoxKhachHang.DisplayMember = "TenKhachHang"; 
            comboBoxKhachHang.ValueMember = "MaKhachHang"; 
        }

        private void InitializeFields()
        {
            textBoxMaDonHang.Text = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");
            textBoxNgayLap.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBoxTongTien.Text = "0";
        }

        private void buttonThemDonHang_Click(object sender, EventArgs e)
        {
            var selectedNhanVien = (NhanVien)comboBoxNhanVien.SelectedItem;
            var selectedKhachHang = (KhachHang)comboBoxKhachHang.SelectedItem;

            var chiTietDonHangList = GetSelectedProducts(); 

            if (chiTietDonHangList == null)
            {
                MessageBox.Show("Thêm thất bại.");
                return;
            }

            if (chiTietDonHangList.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào được thêm vào đơn hàng.");
                return; 
            }

            

            var donHang = new DonHang
            {
                MaDonHang = textBoxMaDonHang.Text,
                NgayLap = DateTime.Now,
                TongTien = currentTotal, 
                NhanVien = selectedNhanVien,
                ChiTietDonHang = chiTietDonHangList
            };

            if (selectedKhachHang != null)
            {
                selectedKhachHang.DonHang.Add(donHang);
                _khachHangCollection.ReplaceOne(kh => kh.MaKhachHang == selectedKhachHang.MaKhachHang, selectedKhachHang);
                MessageBox.Show("Đơn hàng đã được thêm thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
            }
        }

        private int CalculateTotal()
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridViewSanPham.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selected"].Value)) 
                {
                    int quantity = Convert.ToInt32(row.Cells["SoLuong"].Value); 
                    decimal price = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    total += (int)(quantity * price);
                }
            }
            return total;
        }



        private List<ChiTietDonHang> GetSelectedProducts()
        {
            var chiTietDonHangList = new List<ChiTietDonHang>();

            foreach (DataGridViewRow row in dataGridViewSanPham.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selected"].Value)) 
                {
                    var maSanPham = row.Cells["MaSanPham"].Value.ToString();
                    int selectedQuantity = Convert.ToInt32(row.Cells["SoLuong"].Value);

                    var sanPhamItem = _sanPhamCollection.Find(sp => sp.DSSanPham.Any(item => item.MaSanPham == maSanPham))
                        .FirstOrDefault();

                    if (sanPhamItem != null)
                    {
                        var product = sanPhamItem.DSSanPham.First(item => item.MaSanPham == maSanPham);

                        if (selectedQuantity > product.SoLuongTon)
                        {
                            MessageBox.Show($"Số lượng cho sản phẩm '{product.TenSanPham}' vượt quá số lượng tồn ({product.SoLuongTon}). Vui lòng điều chỉnh lại.");
                            return null;
                        }

                        var chiTiet = new ChiTietDonHang
                        {
                            MaSanPham = maSanPham,
                            TenSanPham = row.Cells["TenSanPham"].Value.ToString(),
                            DonGia = Convert.ToInt32(row.Cells["DonGia"].Value),
                            SoLuong = selectedQuantity
                        };

                        chiTietDonHangList.Add(chiTiet);
                    }
                }
            }
            return chiTietDonHangList;
        }


        private void dataGridViewSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewSanPham.Columns["SoLuong"].Index || e.ColumnIndex == dataGridViewSanPham.Columns["Selected"].Index)
            {
                UpdateTotalPrice();
            }
        }

        private void dataGridViewSanPham_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.IsCurrentCellDirty)
            {
                dataGridViewSanPham.CommitEdit(DataGridViewDataErrorContexts.Commit); 
            }
        }


        private void SaveSelectedProductState()
        {
            selectedProductIds.Clear();
            selectedQuantities.Clear();

            foreach (DataGridViewRow row in dataGridViewSanPham.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selected"].Value))
                {
                    string productId = row.Cells["MaSanPham"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    selectedProductIds.Add(productId);
                    selectedQuantities[productId] = quantity;
                }
            }
        }

        private void UpdateTotalPrice()
        {
            textBoxTongTien.Text = CalculateTotal().ToString();
        }

        private void textBoxTimKiemSanPham_TextChanged(object sender, EventArgs e)
        {
            SaveSelectedProductState();

            string searchTerm = textBoxTimKiemSanPham.Text.ToLower();
            var sanPhams = _sanPhamCollection.Find(FilterDefinition<SanPham>.Empty).ToList();

            var filteredProducts = sanPhams.SelectMany(sp => sp.DSSanPham)
                .Where(item => item.TenSanPham.ToLower().Contains(searchTerm))
                .ToList();

            var dataTable = new DataTable();
            dataTable.Columns.Add("Selected", typeof(bool));
            dataTable.Columns.Add("MaSanPham", typeof(string));
            dataTable.Columns.Add("TenSanPham", typeof(string));
            dataTable.Columns.Add("DonGia", typeof(decimal));
            dataTable.Columns.Add("SoLuong", typeof(int));

            foreach (var item in filteredProducts)
            {
                bool isSelected = selectedProductIds.Contains(item.MaSanPham);
                int quantity = isSelected ? selectedQuantities[item.MaSanPham] : 1;
                dataTable.Rows.Add(isSelected, item.MaSanPham, item.TenSanPham, item.DonGia, quantity);
            }

            dataGridViewSanPham.DataSource = dataTable;

            UpdateTotalPrice();
        }

        public class NhanVien
        {
            public ObjectId _id { get; set; }
            public string MaNhanVien { get; set; }
            public string TenNhanVien { get; set; }
            public string DiaChi { get; set; }
            public string Email { get; set; }
            public string SoDienThoai { get; set; }
            public string ChucVu { get; set; }
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
        }

        public class SanPham
        {
            public ObjectId _id { get; set; }
            public string MaLoaiSanPham { get; set; }
            public string TenLoaiSanPham { get; set; }
            public string DonViTinh { get; set; }

            [BsonElement("SanPham")] 
            public List<SanPhamItem> DSSanPham { get; set; } 

            public HangSanXuat HangSanXuat { get; set; }
        }

        public class SanPhamItem
        {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuongTon { get; set; }
            public string MoTa { get; set; }
            public List<PhieuNhap1> PhieuNhap { get; set; } 
        }

        public class HangSanXuat
        {
            public string MaHangSanXuat { get; set; }
            public string TenHangSanXuat { get; set; }
            public string DiaChi { get; set; }
            public string SoDienThoai { get; set; }
            public string Email { get; set; }
        }

        public class KhachHang
        {
            public ObjectId _id { get; set; } 
            public string MaKhachHang { get; set; }
            public string TenKhachHang { get; set; }
            public string DiaChi { get; set; }
            public string SoDienThoai { get; set; }
            public string Email { get; set; }
            public List<DonHang> DonHang { get; set; } = new List<DonHang>(); 
        }

        public class DonHang
        {
            public string MaDonHang { get; set; }
            public DateTime NgayLap { get; set; }
            public int TongTien { get; set; }
            public NhanVien NhanVien { get; set; }
            public List<ChiTietDonHang> ChiTietDonHang { get; set; }
        }

        public class ChiTietDonHang
        {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int DonGia { get; set; }
            public int SoLuong { get; set; }
        }

        public class PhieuNhap1
        {
            public string PhieuNhap { get; set; }
            public DateTime NgayNhap { get; set; }
            public int TongTien { get; set; }
            public int SoLuong { get; set; }
            public NhanVien NhanVien { get; set; }
        }
    }
}
