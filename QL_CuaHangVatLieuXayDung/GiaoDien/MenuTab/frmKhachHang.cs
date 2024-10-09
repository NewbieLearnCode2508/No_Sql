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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace GiaoDien.MenuTab
{
   
    public partial class frmKhachHang : Form
    {
      
      
        public frmKhachHang()
        {
            InitializeComponent();
            var client = new MongoClient("mongodb://localhost:27017"); 
            var database = client.GetDatabase("QuanLyVLXD"); 
            MessageBox.Show("Kết nối thành công", "Thông báo");

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
            bool isConnected = false;
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("QuanLyVLXD");
            var collection = database.GetCollection<BsonDocument>("KhachHang");
            isConnected = true;

            var filter = Builders<BsonDocument>.Filter.Eq("MaKhachHang", txtMaKhachHang.Text);
            var document = collection.Find(filter).FirstOrDefault();
            string maKhachHang = "";
            if (document != null)
                maKhachHang = document.GetValue("MaKhachHang").AsString;
            else
            { document = new BsonDocument {
                { "MaKhachHang", "" },
                { "TenKhachHang", "" },
                { "DiaChi", "" },
                { "SoDienThoai","" },
                { "Email", ""},
                {
                "DonHang", new BsonDocument
                { } } };
            }

            if (isConnected == false)
            {
                MessageBox.Show("Kết nối thất bại", "Thông báo");
            }


           

            if (txtMaKhachHang.Text.Equals(maKhachHang.ToString()))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại", "Thông báo");
                txtMaKhachHang.Clear();
                txtMaKhachHang.Focus();
                return;
            }
          
            if(!kiemTraSoDienThoai(txtSoDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo");
                txtSoDienThoai.Clear();
                txtSoDienThoai.Focus();
                return;
            }    

            if(!kiemTraEMail(txtEMail.Text))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo");
                txtEMail.Clear();
                txtEMail.Focus();
                return;
            }    
                

            var doccument = new BsonDocument
            {
                {"MaKhachHang", txtMaKhachHang.Text },
                {"TenKhachHang", txtTenKhachHang.Text },
                {"DiaChi", txtDiaChi.Text },
                {"SoDienThoai",txtSoDienThoai.Text },
                { "Email", txtEMail.Text},
                {"DonHang", new BsonDocument
                { } }
            };
            collection.InsertOne(doccument);
            MessageBox.Show("Thêm thành công", "Thông báo");
        }
        static bool kiemTraSoDienThoai(string soDienThoai)
        {
           
            string pattern = @"^(09|03|07|08|05)\d{8}$";
            Regex regex = new Regex(pattern);

            
            return regex.IsMatch(soDienThoai);
        }

        static bool kiemTraEMail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

    }
}
