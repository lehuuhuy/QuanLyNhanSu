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
        // Gọi các service
        QLNS_ServiceClient ss = new QLNS_ServiceClient();
        Cls_NhanVien nv = new Cls_NhanVien();
        Cls_ChucVu cv = new Cls_ChucVu();
        Cls_PhongBan pb = new Cls_PhongBan();
        Cls_HopDong hd = new Cls_HopDong();
        Cls_CTHopDong cthd = new Cls_CTHopDong();
        Cls_TrinhDo td = new Cls_TrinhDo();
        Cls_CTTrinhDo cttd = new Cls_CTTrinhDo();
        public frmMain()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------LOAD TẤT CẢ BẢNG----------------------------------------------------------------//
        protected void Form1_Load(object sender, EventArgs e)
        {
            gridNhanVien(); //Bảng nhân viên
            gridChucVu(); //Bảng chức vụ
            gridPhongBan(); //Bảng phòng ban
            gridHopDong(); //Bảng hợp đồng
            gridCTHD(); //Bảng chi tiết hợp đồng
            gridTrinhDo(); //Bảng trình độ
            gridCTTD(); //Bảng chi tiết trình độ
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
            DataSet ds = ss.Load_CTHopDong("Tb_CTHopDong");
            dgridCTHD.DataSource = ds.Tables[0];
            Enabled_Them_CTHD(true);
            btnKhongThemCTHD.Enabled = false;
            btnSaveCTHD.Enabled = false;
            Enabled_Sua_CTHD(true);
            btnKhongSuaCTHD.Enabled = false;
            btnSaveCTHD_Sua.Enabled = false;
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
        private void Enabled_Sua_CTHD(bool Mo)
        {
            txtSoHD_Sua.Enabled = !Mo;
            cboMaLoaiHD_Sua.Enabled = !Mo;
            cboMaNV_Sua.Enabled = !Mo;
            dpkNgayBD_Sua.Enabled = !Mo;
            dpkNgayKT_Sua.Enabled = !Mo;
            txtLuongCB_Sua.Enabled = !Mo;
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
            try
            {
                int hang = e.RowIndex;
                txtSoHD_Sua.Text = dgridCTHD.Rows[hang].Cells[0].Value.ToString();
                cboMaLoaiHD_Sua.Text = dgridCTHD.Rows[hang].Cells[1].Value.ToString();
                cboMaNV_Sua.Text = dgridCTHD.Rows[hang].Cells[2].Value.ToString();
                dpkNgayBD_Sua.Text = dgridCTHD.Rows[hang].Cells[3].Value.ToString();
                dpkNgayKT_Sua.Text = dgridCTHD.Rows[hang].Cells[4].Value.ToString();
                txtLuongCB_Sua.Text = dgridCTHD.Rows[hang].Cells[5].Value.ToString();
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

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            if(txtSoHD_Sua.Text == "")
            {
                MessageBox.Show("Chưa chọn 'Số hợp đồng'");
            }
            else
            {
                DataSet dsHD = ss.Load_HopDong("Tb_HopDong");
                cboMaLoaiHD_Sua.DataSource = dsHD.Tables[0];
                cboMaLoaiHD_Sua.ValueMember = "MaLoaiHD";
                cboMaLoaiHD_Sua.DisplayMember = "MaLoaiHD";
                DataSet dsNV = ss.Load_NhanVien("Tb_NhanVien");
                cboMaNV_Sua.DataSource = dsNV.Tables[0];
                cboMaNV_Sua.ValueMember = "MaNV";
                cboMaNV_Sua.DisplayMember = "MaNV";

                Enabled_Sua_CTHD(false);
                txtSoHD_Sua.Enabled = false;
                btnSuaCTHD.Enabled = false;
                btnKhongSuaCTHD.Enabled = true;
                btnSaveCTHD_Sua.Enabled = true;
                btnXoaCTHD.Enabled = false;
            }
        }

        private void btnKhongSuaCTHD_Click(object sender, EventArgs e)
        {
            Enabled_Sua_CTHD(true);
            btnSuaCTHD.Enabled = true;
            btnKhongSuaCTHD.Enabled = false;
            btnSaveCTHD_Sua.Enabled = false;
            btnXoaCTHD.Enabled = true;
        }

        private void btnSaveCTHD_Sua_Click(object sender, EventArgs e)
        {
            DateTime ngaykt = Convert.ToDateTime(dpkNgayKT_Sua.Text);
            DateTime ngaybd = Convert.ToDateTime(dpkNgayBD_Sua.Text);
            int kq = DateTime.Compare(ngaybd, ngaykt);
            float n = 0;
            if (string.IsNullOrWhiteSpace(txtSoHD_Sua.Text) || string.IsNullOrWhiteSpace(cboMaLoaiHD_Sua.Text) || string.IsNullOrWhiteSpace(cboMaNV_Sua.Text) || string.IsNullOrWhiteSpace(dpkNgayBD_Sua.Text) || string.IsNullOrWhiteSpace(dpkNgayKT_Sua.Text) || string.IsNullOrWhiteSpace(txtLuongCB_Sua.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (kq == 1 || kq == 0)
                {
                    MessageBox.Show("'Ngày kết thúc' phải lớn hơn 'Ngày bắt đầu'");
                }
                else
                {
                    if (float.TryParse(this.txtLuongCB_Sua.Text, out n))
                    {
                        cthd.sohd = txtSoHD_Sua.Text;
                        cthd.maloaihd = cboMaLoaiHD_Sua.Text;
                        cthd.manv = cboMaNV_Sua.Text;
                        cthd.ngaybatdau = Convert.ToDateTime(dpkNgayBD_Sua.Text);
                        cthd.ngayketthuc = Convert.ToDateTime(dpkNgayKT_Sua.Text);
                        cthd.luongcb = float.Parse(txtLuongCB_Sua.Text);
                        ss.Update_CTHopDong(cthd);
                        gridCTHD();
                        MessageBox.Show("Sửa '" + txtSoHD.Text + "' thành công!");
                        btnSuaCTHD.Enabled = true;
                        btnXoaCTHD.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("'Lương cơ bản' phải là kiểu số.");
                    }
                }
            }
        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            if(txtSoHD_Sua.Text == "")
            {
                MessageBox.Show("Chưa chọn 'Số hợp đồng'");
            }
            else
            {
                cthd.sohd = txtSoHD_Sua.Text;
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa '" + txtSoHD_Sua.Text + "'không?", "Đã xóa", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ss.Delete_CTHopDong(cthd);
                    gridCTHD();
                }
                else if (dr == DialogResult.No)
                {
                    //do something else
                }
            }
        }
        //-----------------------------------------------------------------------------FORM TRÌNH ĐỘ----------------------------------------------------------------//
        private void gridTrinhDo()
        {
            //Load sanh sách các trình độ lên datagridview 
            DataSet ds = ss.Load_TrinhDo("Tb_TrinhDo");
            dgridTrinhDo.DataSource = ds.Tables[0];
            // Ẩn các button của tab thêm
            btnKhongThemTD.Enabled = false;
            btnSaveThemTD.Enabled = false;
            Enabled_Them_TD(true); //Ẩn các textbox của tab thêm
            //Ẩn các button bên tab sửa
            btnKhongSuaTD.Enabled = false;
            btnSaveSuaTD.Enabled = false;
            Enabled_Sua_TD(true); //ẩn các textbox của tab sửa

        }
        //điều kiện mở các textbox của tab thêm
        private void Enabled_Them_TD(bool Mo)
        {
            txtMaTD.Enabled = !Mo;
            txtTenTD.Enabled = !Mo;
        }
        //điều kiện mở các textbox của tab sửa
        private void Enabled_Sua_TD(bool Mo)
        {
            txtMaTD_Sua.Enabled = !Mo;
            txtTenTD_Sua.Enabled = !Mo;
        }
        //Reset tất cả các giá trị của textbox
        private void Empty_TD()
        {
            txtMaTD.ResetText();
            txtTenTD.ResetText();
        }
        //Load thông tin từ datagridview lên các textbox
        private void dgridTrinhDo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //của tab thêm
            try
            {
                int hang = e.RowIndex;
                txtMaTD.Text = dgridTrinhDo.Rows[hang].Cells[0].Value.ToString();
                txtTenTD.Text = dgridTrinhDo.Rows[hang].Cells[1].Value.ToString();
            }
            catch
            { }
            //của tab sửa
            try
            {
                int hang = e.RowIndex;
                txtMaTD_Sua.Text = dgridTrinhDo.Rows[hang].Cells[0].Value.ToString();
                txtTenTD_Sua.Text = dgridTrinhDo.Rows[hang].Cells[1].Value.ToString();
            }
            catch
            { }
        }
        //Xử lý sự kiện button ThemTD
        private void btnThemTD_Click(object sender, EventArgs e)
        {
            Enabled_Them_TD(false); //Mở các textbox
            Empty_TD(); //Reset các textbox
            btnThemTD.Enabled = false; // ẩn button ThemTD
            btnKhongThemTD.Enabled = true; //mở button KhongThemTD
            btnSaveThemTD.Enabled = true; //mở button SaveThemTD
        }
        //Xử lý sự kiện button KhongThemTD
        private void btnKhongThemTD_Click(object sender, EventArgs e)
        {
            Enabled_Them_TD(true);
            Empty_TD();
            btnThemTD.Enabled = true;
            btnKhongThemTD.Enabled = false;
            btnSaveThemTD.Enabled = false;
        }
        //Xử lý sự kiện button SaveThemTD
        private void btnSaveThemTD_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtMaTD.Text) || string.IsNullOrWhiteSpace(txtTenTD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                td.matd = txtMaTD.Text;
                td.tentd = txtTenTD.Text;
                ss.Add_TrinhDo(td);
                gridTrinhDo();
                MessageBox.Show("Thêm '" + txtMaTD.Text + "' thành công!");
                btnThemTD.Enabled = true;
                btnKhongThemTD.Enabled = false;
                btnSaveThemTD.Enabled = false;

            }
        }
        //xử lý sự kiện button SuaTD
        private void btnSuaTD_Click(object sender, EventArgs e)
        {
            if(txtMaTD_Sua.Text == "")
            {
                MessageBox.Show("Chưa chọn 'Mã trình độ'");
            }
            else
            {
                Enabled_Sua_TD(false); //mở các textbox của tab sửa
                txtMaTD_Sua.Enabled = false;
                btnSuaTD.Enabled = false;
                btnXoaTD.Enabled = false;
                btnKhongSuaTD.Enabled = true;
                btnSaveSuaTD.Enabled = true;
            }
        }
        //xử lý sự kiện button KhongSuaTD
        private void btnKhongSuaTD_Click(object sender, EventArgs e)
        {
            Enabled_Sua_TD(true);
            btnSuaTD.Enabled = true;
            btnXoaTD.Enabled = true;
            btnKhongSuaTD.Enabled = false;
            btnSaveSuaTD.Enabled = false;
        }
        //xử lý sự kiện button SaveSuaTD
        private void btnSaveSuaTD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTD_Sua.Text) || string.IsNullOrWhiteSpace(txtTenTD_Sua.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                td.matd = txtMaTD_Sua.Text;
                td.tentd = txtTenTD_Sua.Text;
                ss.Update_TrinhDo(td);
                gridTrinhDo();
                MessageBox.Show("Sửa '" + txtMaTD_Sua.Text + "' thành công!");
                btnSuaTD.Enabled = true;
                btnXoaTD.Enabled = true;
                btnKhongSuaTD.Enabled = false;
                btnSaveSuaTD.Enabled = false;

            }
        }
        //xử lý sự kiện button XoaTD
        private void btnXoaTD_Click(object sender, EventArgs e)
        {
            if (txtMaTD_Sua.Text == "")
            {
                MessageBox.Show("Chưa chọn 'Mã trình độ'");
            }
            else
            {
                td.matd = txtMaTD_Sua.Text;
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa '" + txtMaTD_Sua.Text + "'không?", "Đã xóa", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ss.Delete_TrinhDo(td);
                    gridTrinhDo();
                }
                else if (dr == DialogResult.No)
                {
                    //do something else
                }
            }
        }
        //-----------------------------------------------------------------------------FORM CHI TIẾT TRÌNH ĐỘ----------------------------------------------------------------//
        private void gridCTTD()
        {
            DataSet ds = ss.Load_CTTrinhDo("Tb_CTTrinhDo");
            dgridCTTD.DataSource = ds.Tables[0];
            btnKhongThemCTTD.Enabled = false;
            btnSaveCTTD.Enabled = false;
            Enabled_Them_CTTD(true);

            btnKhongSuaCTTD.Enabled = false;
            btnSaveCTTD_Sua.Enabled = false;
            Enabled_Sua_CTTD(true);
        }
        private void Enabled_Them_CTTD(bool Mo)
        {
            txtMaCTTD.Enabled = !Mo;
            cboMaTD.Enabled = !Mo;
            cboMaNV_CTTD.Enabled = !Mo;
            txtChuyenMon.Enabled = !Mo;
            dpkNgayCap.Enabled = !Mo;
            txtTruong.Enabled = !Mo;
        }
        private void Enabled_Sua_CTTD(bool Mo)
        {
            txtMaCTTD_Sua.Enabled = !Mo;
            cboMaTD_Sua.Enabled = !Mo;
            cboMaNV_CTTD_Sua.Enabled = !Mo;
            txtChuyenMon_Sua.Enabled = !Mo;
            dpkNgayCap_Sua.Enabled = !Mo;
            txtTruong_Sua.Enabled = !Mo;
        }
        private void Empty_CTTD()
        {
            txtMaCTTD.ResetText();
            cboMaTD.ResetText();
            cboMaNV_CTTD.ResetText();
            txtChuyenMon.ResetText();
            dpkNgayCap.ResetText();
            txtTruong.ResetText();
        }
        private void dgridCTTD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtMaCTTD.Text = dgridCTTD.Rows[hang].Cells[0].Value.ToString();
                cboMaTD.Text = dgridCTTD.Rows[hang].Cells[1].Value.ToString();
                cboMaNV_CTTD.Text = dgridCTTD.Rows[hang].Cells[2].Value.ToString();
                txtChuyenMon.Text = dgridCTTD.Rows[hang].Cells[3].Value.ToString();
                dpkNgayCap.Text = dgridCTTD.Rows[hang].Cells[4].Value.ToString();
                txtTruong.Text = dgridCTTD.Rows[hang].Cells[5].Value.ToString();
            }
            catch
            { }
            try
            {
                int hang = e.RowIndex;
                txtMaCTTD_Sua.Text = dgridCTTD.Rows[hang].Cells[0].Value.ToString();
                cboMaTD_Sua.Text = dgridCTTD.Rows[hang].Cells[1].Value.ToString();
                cboMaNV_CTTD_Sua.Text = dgridCTTD.Rows[hang].Cells[2].Value.ToString();
                txtChuyenMon_Sua.Text = dgridCTTD.Rows[hang].Cells[3].Value.ToString();
                dpkNgayCap_Sua.Text = dgridCTTD.Rows[hang].Cells[4].Value.ToString();
                txtTruong_Sua.Text = dgridCTTD.Rows[hang].Cells[5].Value.ToString();
            }
            catch
            { }
        }

        private void btnThemCTTD_Click(object sender, EventArgs e)
        {
            Enabled_Them_CTTD(false);

            DataSet dsTD = ss.Load_TrinhDo("Tb_TrinhDo");
            cboMaTD.DataSource = dsTD.Tables[0];
            cboMaTD.ValueMember = "MaTD";
            cboMaTD.DisplayMember = "MaTD";

            DataSet dsNV = ss.Load_NhanVien("Tb_NhanVien");
            cboMaNV_CTTD.DataSource = dsNV.Tables[0];
            cboMaNV_CTTD.ValueMember = "MaNV";
            cboMaNV_CTTD.DisplayMember = "MaNV";

            Empty_CTTD();
            btnThemCTTD.Enabled = false;
            btnKhongThemCTTD.Enabled = true;
            btnSaveCTTD.Enabled = true;
        }

        private void btnKhongThemCTTD_Click(object sender, EventArgs e)
        {
            Enabled_Them_CTTD(true);
            Empty_CTTD();
            btnThemCTTD.Enabled = true;
            btnKhongThemCTTD.Enabled = false;
            btnSaveCTTD.Enabled = false;
        }

        private void btnSaveCTTD_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime ngaycap = Convert.ToDateTime(dpkNgayCap.Text);
            int kq = DateTime.Compare(ngaycap, today);
            if(string.IsNullOrWhiteSpace(txtMaCTTD.Text) || string.IsNullOrWhiteSpace(cboMaTD.Text) || string.IsNullOrWhiteSpace(cboMaNV_CTTD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if(kq == 1)
                {
                    MessageBox.Show("'Ngày cấp' không được lớn hơn ngày hiện tại!");
                }
                else
                {
                    cttd.macttd = txtMaCTTD.Text;
                    cttd.matd = cboMaTD.Text;
                    cttd.manv = cboMaNV_CTTD.Text;
                    cttd.chuyenmon = txtChuyenMon.Text;
                    cttd.ngaycap = Convert.ToDateTime(dpkNgayCap.Text);
                    cttd.truong = txtTruong.Text;
                    ss.Add_CTTrinhDo(cttd);
                    gridCTTD();
                    MessageBox.Show("Thêm '" + txtMaCTTD.Text + "' thành công!");
                    Enabled_Them_CTTD(true);
                    btnThemCTTD.Enabled = true;
                    btnKhongThemCTTD.Enabled = false;
                    btnSaveCTTD.Enabled = false;
                }
            }
        }

        private void btnSuaCTTD_Click(object sender, EventArgs e)
        {
            if(txtMaCTTD_Sua.Text == "")
            {
                MessageBox.Show("Chưa chọn 'Mã CTTD'");
            }
            else
            {
                Enabled_Sua_CTTD(false);
                txtMaCTTD_Sua.Enabled = false;
                btnSuaCTTD.Enabled = false;
                btnXoaCTTD.Enabled = false;
                btnKhongSuaCTTD.Enabled = true;
                btnSaveCTTD_Sua.Enabled = true;

                DataSet dsTD = ss.Load_TrinhDo("Tb_TrinhDo");
                cboMaTD_Sua.DataSource = dsTD.Tables[0];
                cboMaTD_Sua.ValueMember = "MaTD";
                cboMaTD_Sua.DisplayMember = "MaTD";

                DataSet dsNV = ss.Load_NhanVien("Tb_NhanVien");
                cboMaNV_CTTD_Sua.DataSource = dsNV.Tables[0];
                cboMaNV_CTTD_Sua.ValueMember = "MaNV";
                cboMaNV_CTTD_Sua.DisplayMember = "MaNV";

                Empty_CTTD();
                btnThemCTTD.Enabled = false;
                btnKhongThemCTTD.Enabled = true;
                btnSaveCTTD.Enabled = true;
            }
        }

        private void btnKhongSuaCTTD_Click(object sender, EventArgs e)
        {
            Enabled_Sua_CTTD(true);
            btnSuaCTTD.Enabled = true;
            btnXoaCTTD.Enabled = true;
            btnKhongSuaCTTD.Enabled = false;
            btnSaveCTTD_Sua.Enabled = false;
        }

        private void btnSaveCTTD_Sua_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime ngaycap = Convert.ToDateTime(dpkNgayCap_Sua.Text);
            int kq = DateTime.Compare(ngaycap, today);
            if (string.IsNullOrWhiteSpace(txtMaCTTD_Sua.Text) || string.IsNullOrWhiteSpace(cboMaTD_Sua.Text) || string.IsNullOrWhiteSpace(cboMaNV_CTTD_Sua.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (kq == 1)
                {
                    MessageBox.Show("'Ngày cấp' không được lớn hơn ngày hiện tại!");
                }
                else
                {
                    cttd.macttd = txtMaCTTD_Sua.Text;
                    cttd.matd = cboMaTD_Sua.Text;
                    cttd.manv = cboMaNV_CTTD_Sua.Text;
                    cttd.chuyenmon = txtChuyenMon_Sua.Text;
                    cttd.ngaycap = Convert.ToDateTime(dpkNgayCap_Sua.Text);
                    cttd.truong = txtTruong_Sua.Text;
                    ss.Update_CTTrinhDo(cttd);
                    gridCTTD();
                    MessageBox.Show("Sửa '" + txtMaCTTD_Sua.Text + "' thành công!");
                    Enabled_Sua_CTTD(true);
                    btnSuaCTTD.Enabled = true;
                    btnXoaCTTD.Enabled = true;
                    btnKhongSuaCTTD.Enabled = false;
                    btnSaveCTTD_Sua.Enabled = false;
                }
            }
        }
    }
}