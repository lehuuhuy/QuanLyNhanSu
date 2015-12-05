using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLNS_WinForm.QLNS_ServiceReference;

namespace QLNS_WinForm
{
    public partial class frmNhanVien : Form
    {
        QLNS_WinForm.QLNS_ServiceReference.QLNS_ServiceClient ss = new QLNS_WinForm.QLNS_ServiceReference.QLNS_ServiceClient();
        QLNS_WinForm.QLNS_ServiceReference.Cls_NhanVien nv = new Cls_NhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void MoDKThemNhanVien(bool Mo)
        {
            
        }
        private void MoDKSuaNhanVien(bool Mo)
        {
            
        }
        private void XoaND1()
        {
            
        }
        private void grid()
        {
            btnKhongThem.Enabled = false;
            btnSave.Enabled = false;
            txtMaNV.ReadOnly = true;
            DataSet ds = ss.Load_NhanVien();
            dgridNhanVien.DataSource = ds.Tables[0];
        }
        protected void Form1_Load(object sender, EventArgs e)
        {
            grid();
        }
        private void btnThemMoi1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnKhongThem1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLuuThem1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnKhongSua1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLuuSua1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgridNhanVien1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            
        }

        private void radTimTatCaNhanVien1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radTimTheoPhongBan1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radTimTheoMaNhanVien1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radTimTheoPhanLoaiNhanVien1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radTimTheoDieuKien1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTim1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgridNhanVien1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboChucVu1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgridNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtMaNV.Text = dgridNhanVien.Rows[hang].Cells[0].Value.ToString();
                txtHoTen.Text = dgridNhanVien.Rows[hang].Cells[1].Value.ToString();
                txtGioiTinh.Text = dgridNhanVien.Rows[hang].Cells[2].Value.ToString();
                dpkNgaySinh.Text = dgridNhanVien.Rows[hang].Cells[3].Value.ToString();
                txtNoiSinh.Text = dgridNhanVien.Rows[hang].Cells[4].Value.ToString();
                txtSoCMND.Text = dgridNhanVien.Rows[hang].Cells[5].Value.ToString();
                txtTonGiao.Text = dgridNhanVien.Rows[hang].Cells[6].Value.ToString();
                txtDanToc.Text = dgridNhanVien.Rows[hang].Cells[7].Value.ToString();
                txtMaPB.Text = dgridNhanVien.Rows[hang].Cells[8].Value.ToString();
                txtMaCV.Text = dgridNhanVien.Rows[hang].Cells[9].Value.ToString();
                txtDienThoai.Text = dgridNhanVien.Rows[hang].Cells[10].Value.ToString();
                txtHoKhau.Text = dgridNhanVien.Rows[hang].Cells[11].Value.ToString();
                txtChoOHienNay.Text = dgridNhanVien.Rows[hang].Cells[12].Value.ToString();
                dpkNgayVaoLam.Text = dgridNhanVien.Rows[hang].Cells[13].Value.ToString();
                txtSoBHYT.Text = dgridNhanVien.Rows[hang].Cells[14].Value.ToString();
                txtSoTheATM.Text = dgridNhanVien.Rows[hang].Cells[15].Value.ToString();
            }
            catch
            {
                
            }
        }
        private void Empty()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtGioiTinh.ResetText();
            dpkNgaySinh.ResetText();
            txtNoiSinh.Clear();
            txtSoCMND.Clear();
            txtTonGiao.ResetText();
            txtDanToc.ResetText();
            txtMaPB.ResetText();
            txtMaCV.ResetText();
            txtDienThoai.Clear();
            txtHoKhau.Clear();
            txtChoOHienNay.Clear();
            dpkNgayVaoLam.ResetText();
            txtSoBHYT.Clear();
            txtSoTheATM.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnKhongThem.Enabled = true;
            txtMaNV.ReadOnly = false;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            Empty();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            nv.manv = txtMaNV.Text;
            nv.hoten = txtHoTen.Text;
            nv.gioitinh = txtGioiTinh.Text;
            nv.ngaysinh = dpkNgaySinh.Text;
            nv.noisinh = txtNoiSinh.Text;
            nv.socmnd = txtSoCMND.Text;
            nv.tongiao = txtTonGiao.Text;
            nv.dantoc = txtDanToc.Text;
            nv.mapb = txtMaPB.Text;
            nv.macv = txtMaCV.Text;
            nv.dienthoai = txtDienThoai.Text;
            nv.hokhau = txtHoKhau.Text;
            nv.choohiennay = txtChoOHienNay.Text;
            nv.ngayvaolam = dpkNgayVaoLam.Text;
            nv.sobhyt = txtSoBHYT.Text;
            nv.sotheatm = txtSoTheATM.Text;
            if(txtMaNV.Text.Trim() == "" || txtMaNV.TextLength == 0 || txtMaPB.Text.Trim() == "" || txtMaPB.TextLength == 0 || txtMaCV.Text.Trim() == "" || txtMaCV.TextLength == 0)
            {
                MessageBox.Show("Các thông tin (*) là bắt buộc!");
            }
            else
            {
                ss.Add_NhanVien(nv);
                MessageBox.Show("Thêm " + txtMaNV.Text + " thành công!");
                grid();
                btnAdd.Enabled = true;
                btnKhongThem.Enabled = false;
                btnSave.Enabled = false;
                txtMaNV.ReadOnly = true;
                Empty();
            }
        }

        private void btnKhongThem_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnKhongThem.Enabled = false;
            btnSave.Enabled = false;
            txtMaNV.ReadOnly = true;
            Empty();
        }
    }
}