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
namespace GiaoDien.MenuTab
{
    public partial class frmSanPham : Form
    {

        public frmSanPham()
        {
            InitializeComponent();
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
            if(indexGrid != -1)
            {
                btnSua.Enabled=true;
                btnXoa.Enabled=true;
                checkThem = false;
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            checkThem = false;
            voHieuHoaControl();

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
