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
    public partial class frmMain : Form
    {
        QLNS_ServiceClient ss = new QLNS_ServiceClient();
        Cls_NhanVien nv = new Cls_NhanVien();
        Cls_ChucVu cv = new Cls_ChucVu();
        Cls_PhongBan pb = new Cls_PhongBan();
        Cls_HopDong hd = new Cls_HopDong();
        Cls_CTHopDong cthd = new Cls_CTHopDong();
        public frmMain()
        {
            InitializeComponent();
        }
        protected void Form1_Load(object sender, EventArgs e)
        {
            gridNhanVien();
            gridChucVu();
            gridPhongBan();
            gridHopDong();
            gridCTHD();
        }
        //-----------------------------------------------------------------------------FORM NHÂN VIÊN----------------------------------------------------------------//
        private void gridNhanVien()
        {
            btnKhongThem.Enabled = false;
            btnSave.Enabled = false;
            btnKhongSua_1.Enabled = false;
            btnSave_1.Enabled = false;
            Enabled_Them(true);
            Enabled_SuaXoa(true);
            DataSet ds = ss.Load_NhanVien("Tb_NhanVien");
            dgridNhanVien.DataSource = ds.Tables[0];
        }
        private void btnKhongSua1_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnKhongSua_1.Enabled = false;
            btnSave_1.Enabled = false;
            btnXoa.Enabled = true;
            Enabled_SuaXoa(true);
        }
        private void MaTuDongTang()
        {
            /*
            ss.myconnect();
            DataSet dsNV = ss.Load_NhanVien("Tb_NhanVien");
            string s = "";
            if(dsNV.Tables[0].Rows.Count < 0)
            {
                s = "NV001";
            }
            else
            {
                int k;
                s = "NV";
                k = Convert.ToInt32(dsNV.Tables[0].Rows[dsNV.Tables[0].Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                    s = s + "0";
                else if (k < 100)
                    s = s + "00";
                s = s + k.ToString();
            }
            txtMaNV.Text = s;
             * */
        }
        private void dgridNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ss.myconnect();
            DataSet dsPB = ss.Load_PhongBan("Tb_PhongBan");
            DataSet dsCV = ss.Load_NhanVien("Tb_ChucVu");
            try
            {
                int hang = e.RowIndex;
                txtMaNV.Text = dgridNhanVien.Rows[hang].Cells[0].Value.ToString();
                txtHoTen.Text = dgridNhanVien.Rows[hang].Cells[1].Value.ToString();
                txtGioiTinh.Text = dgridNhanVien.Rows[hang].Cells[2].Value.ToString();
                dpkNgaySinh.Value = Convert.ToDateTime(dgridNhanVien.Rows[hang].Cells[3].Value.ToString());
                txtNoiSinh.Text = dgridNhanVien.Rows[hang].Cells[4].Value.ToString();
                txtSoCMND.Text = dgridNhanVien.Rows[hang].Cells[5].Value.ToString();
                txtTonGiao.Text = dgridNhanVien.Rows[hang].Cells[6].Value.ToString();
                txtDanToc.Text = dgridNhanVien.Rows[hang].Cells[7].Value.ToString();
                cboMaCV.DataSource = dsCV.Tables[0];
                cboMaCV.ValueMember = "MaCV";
                cboMaCV.DisplayMember = "MaCV";
                cboMaPB.Text = dgridNhanVien.Rows[hang].Cells[8].Value.ToString();
                cboMaPB.DataSource = dsPB.Tables[0];
                cboMaPB.ValueMember = "MaPB";
                cboMaPB.DisplayMember = "MaPB";
                cboMaCV.Text = dgridNhanVien.Rows[hang].Cells[9].Value.ToString();
                txtDienThoai.Text = dgridNhanVien.Rows[hang].Cells[10].Value.ToString();
                txtHoKhau.Text = dgridNhanVien.Rows[hang].Cells[11].Value.ToString();
                txtChoOHienNay.Text = dgridNhanVien.Rows[hang].Cells[12].Value.ToString();
                dpkNgayVaoLam.Value = Convert.ToDateTime(dgridNhanVien.Rows[hang].Cells[13].Value.ToString());
                txtSoBHYT.Text = dgridNhanVien.Rows[hang].Cells[14].Value.ToString();
                txtSoTheATM.Text = dgridNhanVien.Rows[hang].Cells[15].Value.ToString();
            }
            catch
            {

            }
            try
            {
                int hang = e.RowIndex;
                txtMaNV_1.Text = dgridNhanVien.Rows[hang].Cells[0].Value.ToString();
                txtHoTen_1.Text = dgridNhanVien.Rows[hang].Cells[1].Value.ToString();
                txtGioiTinh_1.Text = dgridNhanVien.Rows[hang].Cells[2].Value.ToString();
                dpkNgaySinh_1.Text = dgridNhanVien.Rows[hang].Cells[3].Value.ToString();
                txtNoiSinh_1.Text = dgridNhanVien.Rows[hang].Cells[4].Value.ToString();
                txtSoCMND_1.Text = dgridNhanVien.Rows[hang].Cells[5].Value.ToString();
                txtTonGiao_1.Text = dgridNhanVien.Rows[hang].Cells[6].Value.ToString();
                txtDanToc_1.Text = dgridNhanVien.Rows[hang].Cells[7].Value.ToString();
                cboMaPB_1.DataSource = dsPB.Tables[0];
                cboMaPB_1.ValueMember = "MaPB";
                cboMaPB_1.DisplayMember = "MaPB";
                cboMaCV_1.DataSource = dsCV.Tables[0];
                cboMaCV_1.ValueMember = "MaCV";
                cboMaCV_1.DisplayMember = "MaCV";
                txtDienThoai_1.Text = dgridNhanVien.Rows[hang].Cells[10].Value.ToString();
                txtHoKhau_1.Text = dgridNhanVien.Rows[hang].Cells[11].Value.ToString();
                txtChoOHienNay_1.Text = dgridNhanVien.Rows[hang].Cells[12].Value.ToString();
                dpkNgayVaoLam_1.Text = dgridNhanVien.Rows[hang].Cells[13].Value.ToString();
                txtSoBHYT_1.Text = dgridNhanVien.Rows[hang].Cells[14].Value.ToString();
                txtSoTheATM_1.Text = dgridNhanVien.Rows[hang].Cells[15].Value.ToString();
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
            cboMaPB.ResetText();
            cboMaCV.ResetText();
            txtDienThoai.Clear();
            txtHoKhau.Clear();
            txtChoOHienNay.Clear();
            dpkNgayVaoLam.ResetText();
            txtSoBHYT.Clear();
            txtSoTheATM.Clear();
        }
        private void Enabled_SuaXoa(bool Mo)
        {
            txtMaNV_1.Enabled = !Mo;
            txtHoTen_1.Enabled = !Mo;
            txtGioiTinh_1.Enabled = !Mo;
            dpkNgaySinh_1.Enabled = !Mo;
            txtNoiSinh_1.Enabled = !Mo;
            txtSoCMND_1.Enabled = !Mo;
            txtTonGiao_1.Enabled = !Mo;
            txtDanToc_1.Enabled = !Mo;
            cboMaPB_1.Enabled = !Mo;
            cboMaCV_1.Enabled = !Mo;
            txtDienThoai_1.Enabled = !Mo;
            txtHoKhau_1.Enabled = !Mo;
            txtChoOHienNay_1.Enabled = !Mo;
            dpkNgayVaoLam_1.Enabled = !Mo;
            txtSoBHYT_1.Enabled = !Mo;
            txtSoTheATM_1.Enabled = !Mo;
        }
        private void Enabled_Them(bool Mo)
        {
            txtMaNV.Enabled = !Mo;
            txtHoTen.Enabled = !Mo;
            txtGioiTinh.Enabled = !Mo;
            dpkNgaySinh.Enabled = !Mo;
            txtNoiSinh.Enabled = !Mo;
            txtSoCMND.Enabled = !Mo;
            txtTonGiao.Enabled = !Mo;
            txtDanToc.Enabled = !Mo;
            cboMaPB.Enabled = !Mo;
            cboMaCV.Enabled = !Mo;
            txtDienThoai.Enabled = !Mo;
            txtHoKhau.Enabled = !Mo;
            txtChoOHienNay.Enabled = !Mo;
            dpkNgayVaoLam.Enabled = !Mo;
            txtSoBHYT.Enabled = !Mo;
            txtSoTheATM.Enabled = !Mo;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MaTuDongTang();
            ss.myconnect();
            DataSet dsCV = ss.Load_NhanVien("Tb_ChucVu");
            cboMaCV.DataSource = dsCV.Tables[0];
            cboMaCV.ValueMember = "MaCV";
            cboMaCV.DisplayMember = "MaCV";

            DataSet dsPB = ss.Load_PhongBan("Tb_PhongBan");
            cboMaPB.DataSource = dsPB.Tables[0];
            cboMaPB.ValueMember = "MaPB";
            cboMaPB.DisplayMember = "MaPB";
            btnKhongThem.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            Enabled_Them(false);
            Empty();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime ngaysinh = Convert.ToDateTime(dpkNgaySinh.Text);
            DateTime ngayvaolam = Convert.ToDateTime(dpkNgayVaoLam.Text);
            int kq1 = DateTime.Compare(ngaysinh, today);
            int kq2 = DateTime.Compare(ngaysinh, ngayvaolam);
            int kq3 = DateTime.Compare(ngayvaolam, today);
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(cboMaCV.Text) || string.IsNullOrWhiteSpace(cboMaPB.Text))
            {
                MessageBox.Show("Các thông tin (*) là bắt buộc!");
            }
            else
            {
                if(kq1 == 1 || kq1 == 0)
                {
                    MessageBox.Show("'Ngày sinh' phải nhỏ hơn ngày hiên tại!");
                }
                else
                {
                    if (kq2 == 1 || kq2 == 0)
                        MessageBox.Show("'Ngày vào làm' phải lớn hơn 'Ngày sinh'");
                    else
                    {
                        if(kq3 == 1)
                        {
                            MessageBox.Show("'Ngày vào làm' phải lớn hơn hoặc bằng ngày hiện tại!");
                        }
                        else
                        {
                            nv.manv = txtMaNV.Text;
                            nv.hoten = txtHoTen.Text;
                            nv.gioitinh = txtGioiTinh.Text;
                            nv.ngaysinh = Convert.ToDateTime(dpkNgaySinh.Text);
                            nv.noisinh = txtNoiSinh.Text;
                            nv.socmnd = txtSoCMND.Text;
                            nv.tongiao = txtTonGiao.Text;
                            nv.dantoc = txtDanToc.Text;
                            nv.mapb = cboMaPB.Text;
                            nv.macv = cboMaCV.Text;
                            nv.dienthoai = txtDienThoai.Text;
                            nv.hokhau = txtHoKhau.Text;
                            nv.choohiennay = txtChoOHienNay.Text;
                            nv.ngayvaolam = Convert.ToDateTime(dpkNgayVaoLam.Text);
                            nv.sobhyt = txtSoBHYT.Text;
                            nv.sotheatm = txtSoTheATM.Text;

                            ss.Add_NhanVien(nv);
                            gridNhanVien();
                            MessageBox.Show("Thêm " + txtMaNV.Text + " thành công!");
                            btnAdd.Enabled = true;
                            btnKhongThem.Enabled = false;
                            btnSave.Enabled = false;
                            Enabled_Them(true);
                            Empty();
                        }
                    }
                }
            }
        }

        private void btnKhongThem_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnKhongThem.Enabled = false;
            btnSave.Enabled = false;
            Enabled_Them(true);
            Empty();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            btnKhongSua_1.Enabled = true;
            btnSave_1.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            Enabled_SuaXoa(false);
            txtMaNV_1.Enabled = false;
        }

        private void btnSave_1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV_1.Text) || string.IsNullOrWhiteSpace(cboMaCV_1.Text) || string.IsNullOrWhiteSpace(cboMaPB_1.Text))
            {
                MessageBox.Show("Các thông tin (*) là bắt buộc!");
            }
            else
            {
                nv.manv = txtMaNV_1.Text;
                nv.hoten = txtHoTen_1.Text;
                nv.gioitinh = txtGioiTinh_1.Text;
                nv.ngaysinh = Convert.ToDateTime(dpkNgaySinh_1.Text);
                nv.noisinh = txtNoiSinh_1.Text;
                nv.socmnd = txtSoCMND_1.Text;
                nv.tongiao = txtTonGiao_1.Text;
                nv.dantoc = txtDanToc_1.Text;
                nv.mapb = cboMaPB_1.Text;
                nv.macv = cboMaCV_1.Text;
                nv.dienthoai = txtDienThoai_1.Text;
                nv.hokhau = txtHoKhau_1.Text;
                nv.choohiennay = txtChoOHienNay_1.Text;
                nv.ngayvaolam = Convert.ToDateTime(dpkNgayVaoLam_1.Text);
                nv.sobhyt = txtSoBHYT_1.Text;
                nv.sotheatm = txtSoTheATM_1.Text;

                ss.Update_NhanVien(nv);
                gridNhanVien();
                MessageBox.Show("Sửa " + txtMaNV_1.Text + " thành công!");
                btnSua.Enabled = true;
                btnKhongSua_1.Enabled = false;
                btnSave_1.Enabled = false;
                btnXoa.Enabled = true;    
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            nv.manv = txtMaNV_1.Text;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa " + txtMaNV_1.Text + " không?", "Đã xóa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ss.Delete_NhanVien(nv);
                gridNhanVien();
            }
            else if (dr == DialogResult.No)
            {
                //do something else
            }
        }
        private void radTimMaPB_CheckedChanged(object sender, EventArgs e)
        {
            if (radTimMaPB.Checked == true)
            {
                txtTimMaNV.Enabled = true;
                txtTimMaPB.Enabled = false;
                txtTimMaCV.Enabled = false;
                grpDKTim.Enabled = false;
                int ThuTuXem = 1;
            }
        }
        private void radTimMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (radTimMaNV.Checked == true)
            {
                txtTimMaNV.Enabled = false;
                txtTimMaPB.Enabled = true;
                txtTimMaCV.Enabled = false;
                grpDKTim.Enabled = false;
                int ThuTuXem = 2;
            }
        }

        private void radTimMaCV_CheckedChanged(object sender, EventArgs e)
        {
            if (radTimMaCV.Checked == true)
            {
                txtTimMaNV.Enabled = false;
                txtTimMaPB.Enabled = false;
                txtTimMaCV.Enabled = true;
                grpDKTim.Enabled = false;
                int ThuTuXem = 3;
            }
        }

        private void radTimTheoDK_CheckedChanged(object sender, EventArgs e)
        {
            if (radTimTheoDK.Checked == true)
            {
                txtTimMaNV.Enabled = false;
                txtTimMaPB.Enabled = false;
                txtTimMaCV.Enabled = false;
                grpDKTim.Enabled = true;
                int ThuTuXem = 4;
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void txtTimMaPB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimMaNV_TextChanged(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------------FORM CHỨC VỤ - PHÒNG BAN----------------------------------------------------------------//

        //---PHÒNG BAN---//
        private void gridChucVu()
        {
            btnThemCV.Enabled = true;
            btnKhongThemCV.Enabled = false;
            btnSaveCV.Enabled = false;
            btnKhongSuaCV.Enabled = false;
            btnSaveCV_3.Enabled = false;
            Enabled_Them_CV(true);
            Enabled_Sua_CV(true);
            DataSet ds = ss.Load_ChucVu("Tb_ChucVu");
            dgridChucVu.DataSource = ds.Tables[0];

        }
        private void Enabled_Them_CV(bool Mo)
        {
            txtMaCV_2.Enabled = !Mo;
            txtTenCV_2.Enabled = !Mo;
            txtLuongCB_2.Enabled = !Mo;
        }
        private void Enabled_Sua_CV(bool Mo)
        {
            txtMaCV_3.Enabled = !Mo;
            txtTenCV_3.Enabled = !Mo;
            txtLuongCB_3.Enabled = !Mo;
        }
        private void Empty_CV()
        {
            txtMaCV_2.ResetText();
            txtTenCV_2.ResetText();
            txtLuongCB_2.ResetText();
        }
        private void dgridChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtMaCV_2.Text = dgridChucVu.Rows[hang].Cells[0].Value.ToString();
                txtTenCV_2.Text = dgridChucVu.Rows[hang].Cells[1].Value.ToString();
                txtLuongCB_2.Text = dgridChucVu.Rows[hang].Cells[2].Value.ToString();
            }
            catch
            {

            }
            try
            {
                int hang = e.RowIndex;
                txtMaCV_3.Text = dgridChucVu.Rows[hang].Cells[0].Value.ToString();
                txtTenCV_3.Text = dgridChucVu.Rows[hang].Cells[1].Value.ToString();
                txtLuongCB_3.Text = dgridChucVu.Rows[hang].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            btnThemCV.Enabled = false;
            btnKhongThemCV.Enabled = true;
            btnSaveCV.Enabled = true;
            Enabled_Them_CV(false);
            Empty_CV();
        }

        private void btnKhongThemCV_Click(object sender, EventArgs e)
        {
            Enabled_Them_CV(true);
            Empty_CV();
            btnThemCV.Enabled = true;
            btnKhongThemCV.Enabled = false;
            btnSaveCV.Enabled = false;
        }
        private void btnSaveCV_Click(object sender, EventArgs e)
        {
            float n = 0;
            if (txtMaCV_2.Text.Trim() == "" || txtMaCV_2.TextLength == 0 || txtTenCV_2.Text.Trim() == "" || txtTenCV_2.TextLength == 0 || txtLuongCB_2.TextLength == 0 || txtLuongCB_2.Text.Trim() == "0")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (float.TryParse(this.txtLuongCB_2.Text, out n))
                {
                    cv.macv = txtMaCV_2.Text;
                    cv.tencv = txtTenCV_2.Text;
                    cv.luongcb = float.Parse(txtLuongCB_2.Text);

                    ss.Add_ChucVu(cv);
                    gridChucVu();
                    MessageBox.Show("Thêm " + txtMaCV_2.Text + " thành công!");
                }
                else
                {
                    MessageBox.Show("Lương cơ bản phải là kiểu số!");
                }
            }
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            btnSuaCV.Enabled = false;
            btnKhongSuaCV.Enabled = true;
            btnSaveCV_3.Enabled = true;
            btnXoaCV.Enabled = false;
            Enabled_Sua_CV(false);
            txtMaCV_3.Enabled = false;
        }

        private void btnKhongSuaCV_Click(object sender, EventArgs e)
        {
            Enabled_Sua_CV(true);
            btnSuaCV.Enabled = true;
            btnXoaCV.Enabled = true;
            btnKhongSuaCV.Enabled = false;
            btnSaveCV_3.Enabled = false;
        }

        private void btnSaveCV_3_Click(object sender, EventArgs e)
        {
            float n = 0;
            if (txtMaCV_3.Text.Trim() == "" || txtMaCV_3.TextLength == 0 || txtTenCV_3.Text.Trim() == "" || txtTenCV_3.TextLength == 0 || txtLuongCB_3.TextLength == 0 || txtLuongCB_3.Text.Trim() == "0")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (float.TryParse(this.txtLuongCB_3.Text, out n))
                {
                    cv.macv = txtMaCV_3.Text;
                    cv.tencv = txtTenCV_3.Text;
                    cv.luongcb = float.Parse(txtLuongCB_3.Text);

                    ss.Update_ChucVu(cv);
                    gridChucVu();
                    MessageBox.Show("Thêm " + txtMaCV_3.Text + " thành công!");
                    btnSuaCV.Enabled = true;
                    btnXoaCV.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Lương cơ bản phải là kiểu số!");
                }
            }
            
        }

        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            cv.macv = txtMaCV_3.Text;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa " + txtMaCV_3.Text + " không?", "Đã xóa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ss.Delete_ChucVu(cv);
                gridChucVu();
            }
            else if (dr == DialogResult.No)
            {
                //do something else
            }
        }

        //---PHÒNG BAN---//
        private void gridPhongBan()
        {
            DataSet ds = ss.Load_PhongBan("Tb_PhongBan");
            dgridPhongBan.DataSource = ds.Tables[0];
            btnKhongThemPB.Enabled = false;
            btnSavePB.Enabled = false;
            Enabled_Them_PB(true);
            btnKhongSuaPB.Enabled = false;
            btnSavePB_3.Enabled = false;
            Enabled_Sua_PB(true);
        }
        private void Enabled_Them_PB(bool Mo)
        {
            txtMaPB_2.Enabled = !Mo;
            txtTenPB_2.Enabled = !Mo;
            txtDienThoai_2.Enabled = !Mo;
            txtFax_2.Enabled = !Mo;
        }
        private void Enabled_Sua_PB(bool Mo)
        {
            txtMaPB_3.Enabled = !Mo;
            txtTenPB_3.Enabled = !Mo;
            txtDienThoai_3.Enabled = !Mo;
            txtFax_3.Enabled = !Mo;
        }
        private void Empty_PB()
        {
            txtMaPB_2.ResetText();
            txtTenPB_2.ResetText();
            txtDienThoai_2.ResetText();
            txtFax_2.ResetText();
        }
        private void dgridPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtMaPB_2.Text = dgridPhongBan.Rows[hang].Cells[0].Value.ToString();
                txtTenPB_2.Text = dgridPhongBan.Rows[hang].Cells[1].Value.ToString();
                txtDienThoai_2.Text = dgridPhongBan.Rows[hang].Cells[2].Value.ToString();
                txtFax_2.Text = dgridPhongBan.Rows[hang].Cells[3].Value.ToString();
            }
            catch
            { }
            try
            {
                int hang = e.RowIndex;
                txtMaPB_3.Text = dgridPhongBan.Rows[hang].Cells[0].Value.ToString();
                txtTenPB_3.Text = dgridPhongBan.Rows[hang].Cells[1].Value.ToString();
                txtDienThoai_3.Text = dgridPhongBan.Rows[hang].Cells[2].Value.ToString();
                txtFax_3.Text = dgridPhongBan.Rows[hang].Cells[2].Value.ToString();
            }
            catch
            { }
        }

        private void btnThemPB_Click(object sender, EventArgs e)
        {
            Empty_PB();
            btnThemPB.Enabled = false;
            Enabled_Them_PB(false);
            btnKhongThemPB.Enabled = true;
            btnSavePB.Enabled = true;
        }

        private void btnKhongThemPB_Click(object sender, EventArgs e)
        {
            Empty_PB();
            Enabled_Them_PB(true);
            btnThemPB.Enabled = true;
            btnKhongThemPB.Enabled = false;
            btnSavePB.Enabled = false;
        }

        private void btnSavePB_Click(object sender, EventArgs e)
        {
            if (txtMaPB_2.Text.Trim() == "" && txtMaPB_2.TextLength == 0 && txtTenPB_2.Text.Trim() == "" && txtTenPB_2.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (txtMaPB_2.Text.Trim() == "" || txtMaPB_2.TextLength == 0)
                {
                    MessageBox.Show("Vui lòng nhập 'Mã phòng ban' ");

                }
                else
                {
                    if (txtTenPB_2.Text.Trim() == "" || txtTenPB_2.TextLength == 0)
                    {
                        MessageBox.Show("Vui lòng nhập 'Tên phòng ban'");
                    }
                    else
                    {
                        pb.mapb = txtMaPB_2.Text;
                        pb.tenpb = txtTenPB_2.Text;
                        pb.dienthoai = txtDienThoai_2.Text;
                        pb.fax = txtFax_2.Text;
                        ss.Add_PhongBan(pb);
                        gridPhongBan();
                        btnThemPB.Enabled = true;
                        btnKhongThemPB.Enabled = false;
                        btnSavePB.Enabled = false;
                        MessageBox.Show("Thêm '" + txtMaPB_2.Text + "' thành công!");
                    }
                }
                
            }
        }

        private void btnSuaPB_Click(object sender, EventArgs e)
        {
            Enabled_Sua_PB(false);
            txtMaPB_3.Enabled = false;
            btnSuaPB.Enabled = false;
            btnKhongSuaPB.Enabled = true;
            btnSavePB_3.Enabled = true;
            btnXoaPB.Enabled = false;

        }

        private void btnKhongSuaPB_Click(object sender, EventArgs e)
        {
            Enabled_Sua_PB(true);
            btnSuaPB.Enabled = true;
            btnKhongSuaPB.Enabled = false;
            btnSavePB_3.Enabled = false;
            btnXoaPB.Enabled = true;
        }

        private void btnSavePB_3_Click(object sender, EventArgs e)
        {
            if(txtTenPB_3.Text.Trim() == "" || txtTenPB_3.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập 'Tên phòng ban'");
            }
            else
            {
                pb.mapb = txtMaPB_3.Text;
                pb.tenpb = txtTenPB_3.Text;
                pb.dienthoai = txtDienThoai_3.Text;
                pb.fax = txtFax_3.Text;
                ss.Update_PhongBan(pb);
                gridPhongBan();
                MessageBox.Show("Sửa '" + txtMaPB_3.Text + "' thành công!");
                btnKhongSuaPB.Enabled = false;
                btnSuaPB.Enabled = false;
                btnSuaPB.Enabled = true;
                btnXoaPB.Enabled = true;
            }
        }

        private void btnXoaPB_Click(object sender, EventArgs e)
        {
            pb.mapb = txtMaPB_3.Text;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa " + txtMaPB_3.Text + " không?", "Đã xóa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ss.Delete_PhongBan(pb);
                gridPhongBan();
            }
            else if (dr == DialogResult.No)
            {
                //do something else
            }
        }
        //-----------------------------------------------------------------------------FORM HỢP ĐỒNG----------------------------------------------------------------//
        private void gridHopDong()
        {
            btnKhongThemHD.Enabled = false;
            btnSaveHD.Enabled = false;

            btnKhongSuaHD.Enabled = false;
            btnSaveHD_Sua.Enabled = false;
            Enabled_Them_HopDong(true);
            Enabled_Sua_HopDong(true);
            DataSet ds = ss.Load_HopDong("Tb_HopDong");
            dgridHopDong.DataSource = ds.Tables[0];
        }
        private void Enabled_Them_HopDong(bool Mo)
        {
            txtMaLoaiHD.Enabled = !Mo;
            txtTenHD.Enabled = !Mo;
        }
        private void Enabled_Sua_HopDong(bool Mo)
        {
            txtMaLoaiHD_Sua.Enabled = !Mo;
            txtTenHD_Sua.Enabled = !Mo;
        }
        private void Empty_HopDong()
        {
            txtMaLoaiHD.ResetText();
            txtTenHD.ResetText();
        }
        private void dgridHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtMaLoaiHD.Text = dgridHopDong.Rows[hang].Cells[0].Value.ToString();
                txtTenHD.Text = dgridHopDong.Rows[hang].Cells[1].Value.ToString();
            }
            catch
            { }
            try
            {
                int hang = e.RowIndex;
                txtMaLoaiHD_Sua.Text = dgridHopDong.Rows[hang].Cells[0].Value.ToString();
                txtTenHD_Sua.Text = dgridHopDong.Rows[hang].Cells[1].Value.ToString();
            }
            catch
            { }
        }
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            btnThemHD.Enabled = false;
            btnKhongThemHD.Enabled = true;
            btnSaveHD.Enabled = true;
            Empty_HopDong();
            Enabled_Them_HopDong(false);
        }

        private void btnKhongThemHD_Click(object sender, EventArgs e)
        {
            btnThemHD.Enabled = true;
            btnKhongThemHD.Enabled = false;
            btnSaveHD.Enabled = false;
            Empty_HopDong();
            Enabled_Them_HopDong(true);
        }

        private void btnSaveHD_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiHD.Text.Trim() == "" && txtTenHD.TextLength == 0 && txtTenHD.Text.Trim() == "" && txtTenHD.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập 'Mã loại HD' và 'Tên hợp đồng'");
            }
            else
            {
                if(txtMaLoaiHD.Text.Trim() == "" || txtMaLoaiHD.TextLength == 0)
                {
                    MessageBox.Show("Vui lòng nhập 'Mã loại HD'");
                }
                else
                {
                    if(txtTenHD.Text.Trim() == "" || txtTenHD.TextLength == 0)
                    {
                        MessageBox.Show("Vui lòng nhập 'Tên hợp đồng'");
                    }
                    else
                    {
                        hd.maloaihd = txtMaLoaiHD.Text;
                        hd.tenhd = txtTenHD.Text;
                        ss.Add_HopDong(hd);
                        gridHopDong();
                        btnThemHD.Enabled = true;
                        btnKhongThemHD.Enabled = false;
                        btnSaveHD.Enabled = false;
                        MessageBox.Show("Thêm '" + txtMaLoaiHD.Text + "' thành công");
                    }
                }
            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            Enabled_Sua_HopDong(false);
            txtMaLoaiHD_Sua.Enabled = false;
            btnKhongSuaHD.Enabled = true;
            btnSaveHD_Sua.Enabled = true;
            btnXoaHD.Enabled = false;
            btnSuaHD.Enabled = false;
        }

        private void btnKhongSuaHD_Click(object sender, EventArgs e)
        {
            Enabled_Sua_HopDong(true);
            btnKhongSuaHD.Enabled = false;
            btnSaveHD_Sua.Enabled = false;
            btnSuaHD.Enabled = true;
            btnXoaHD.Enabled = true;
        }

        private void btnSaveHD_Sua_Click(object sender, EventArgs e)
        {
            if(txtTenHD_Sua.Text.Trim() == "" || txtTenHD_Sua.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập 'Tên hợp đồng'");
            }
            else
            {
                hd.maloaihd = txtMaLoaiHD_Sua.Text;
                hd.tenhd = txtTenHD_Sua.Text;
                ss.Update_HopDong(hd);
                gridHopDong();
                MessageBox.Show("Sửa '" + txtMaLoaiHD_Sua.Text + "'thành công!");
                btnSuaHD.Enabled = true;
                btnXoaHD.Enabled = true;
                btnKhongSuaHD.Enabled = false;
                btnSaveHD_Sua.Enabled = false;
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            hd.maloaihd = txtMaLoaiHD_Sua.Text;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa '" + txtMaLoaiHD_Sua.Text + "'không?", "Đã xóa", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ss.Delete_HopDong(hd);
                gridHopDong();
            }
            else if (dr == DialogResult.No)
            {
                //do something else
            }
        }
        //-----------------------------------------------------------------------------FORM CHI TIẾT HỢP ĐỒNG----------------------------------------------------------------//
        private void gridCTHD()
        {
            DataSet ds = ss.Load_CTHopDong();
            dgridCTHD.DataSource = ds.Tables[0];
            Enabled_Them_CTHD(true);
            btnKhongThemCTHD.Enabled = false;
            btnSaveCTHD.Enabled = false;
        }
        private void Enabled_Them_CTHD(bool Mo)
        {
            txtSoHD.Enabled = !Mo;
            cboMaLoaiHD.Enabled = !Mo;
            cboMaNV.Enabled = !Mo;
            dpkNgayBD.Enabled = !Mo;
            dpkNgayKT.Enabled = !Mo;
            txtLuongCB.Enabled = !Mo;
        }
        private void Empty_CTHD()
        {
            txtSoHD.ResetText();
            cboMaLoaiHD.ResetText();
            cboMaNV.ResetText();
            dpkNgayBD.ResetText();
            dpkNgayKT.ResetText();
            txtLuongCB.ResetText();
        }
        private void dgridCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtSoHD.Text = dgridCTHD.Rows[hang].Cells[0].Value.ToString();
                cboMaLoaiHD.Text = dgridCTHD.Rows[hang].Cells[1].Value.ToString();
                cboMaNV.Text = dgridCTHD.Rows[hang].Cells[2].Value.ToString();
                dpkNgayBD.Text = dgridCTHD.Rows[hang].Cells[3].Value.ToString();
                dpkNgayKT.Text = dgridCTHD.Rows[hang].Cells[4].Value.ToString();
                txtLuongCB.Text = dgridCTHD.Rows[hang].Cells[5].Value.ToString();
            }
            catch
            { }
        }
        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            DataSet dsHD = ss.Load_HopDong("Tb_HopDong");
            cboMaLoaiHD.DataSource = dsHD.Tables[0];
            cboMaLoaiHD.ValueMember = "MaLoaiHD";
            cboMaLoaiHD.DisplayMember = "MaLoaiHD";
            DataSet dsNV = ss.Load_NhanVien("Tb_NhanVien");
            cboMaNV.DataSource = dsNV.Tables[0];
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.DisplayMember = "MaNV";

            Enabled_Them_CTHD(false);
            Empty_CTHD();
            btnThemCTHD.Enabled = false;
            btnKhongThemCTHD.Enabled = true;
            btnSaveCTHD.Enabled = true;
        }

        private void btnKhongThemCTHD_Click(object sender, EventArgs e)
        {
            Enabled_Them_CTHD(true);
            Empty_CTHD();
            btnThemCTHD.Enabled = true;
            btnKhongThemCTHD.Enabled = false;
            btnSaveCTHD.Enabled = false;
        }

        private void btnSaveCTHD_Click(object sender, EventArgs e)
        {
            DateTime ngaykt = Convert.ToDateTime(dpkNgayKT.Text);
            DateTime ngaybd = Convert.ToDateTime(dpkNgayBD.Text);
            int kq = DateTime.Compare(ngaybd, ngaykt);
            float n = 0;
            if(string.IsNullOrWhiteSpace(txtSoHD.Text) || string.IsNullOrWhiteSpace(cboMaLoaiHD.Text) || string.IsNullOrWhiteSpace(cboMaNV.Text) || string.IsNullOrWhiteSpace(dpkNgayBD.Text) || string.IsNullOrWhiteSpace(dpkNgayKT.Text) || string.IsNullOrWhiteSpace(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if(kq == 1 || kq == 0)
                {
                    MessageBox.Show("'Ngày kết thúc' phải lớn hơn 'Ngày bắt đầu'");
                }
                else
                {
                    if(float.TryParse(this.txtLuongCB.Text, out n))
                    {
                        cthd.sohd = txtSoHD.Text;
                        cthd.maloaihd = cboMaLoaiHD.Text;
                        cthd.manv = cboMaNV.Text;
                        cthd.ngaybatdau = Convert.ToDateTime(dpkNgayBD.Text);
                        cthd.ngayketthuc = Convert.ToDateTime(dpkNgayKT.Text);
                        cthd.luongcb = float.Parse(txtLuongCB.Text);
                        ss.Add_CTHopDong(cthd);
                        gridCTHD();
                        MessageBox.Show("Thêm '" + txtSoHD.Text + "' thành công!");
                        btnThemCTHD.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("'Lương cơ bản' phải là kiểu số.");
                    }
                }
            }
        }

        
    }
}