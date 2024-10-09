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

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            checkThem = false;
            voHieuHoaControl();
            LoadSanPham();
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
                        foreach (var sp in loaiSanPham)
                        {
                            sanPhamList.Add(new SanPham
                            {
                                MaSanPham = sp["MaSanPham"].AsString,
                                TenSanPham = sp["TenSanPham"].AsString,
                                DonGia = ConvertToDecimal(sp["DonGia"]),
                                SoLuongTon = sp["SoLuongTon"].ToInt32(),
                                MoTa = sp["MoTa"].AsString
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


        private void gridSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridSanPham.SelectedRows.Count == 0)
            {
                return;
            }
            indexGrid = gridSanPham.SelectedRows[0].Index;
            enableCacControl();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            checkThem = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            voHieuHoaControl();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            voHieuHoaControl();
        }
    }
}
