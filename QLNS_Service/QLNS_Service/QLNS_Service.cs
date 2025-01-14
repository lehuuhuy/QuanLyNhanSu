﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace QLNS_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "QLNS_Service" in both code and config file together.
    public class QLNS_Service : IQLNS_Service
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        private string strConnection = ConfigurationManager.ConnectionStrings["Dbconnection"].ToString();
        public SqlConnection cnn = new SqlConnection("Data Source=(local);Initial Catalog=DB_QLNS;Integrated Security=True");
        public void myconnect()
        {
            cnn.Open();
        }
        //-------------------------------------------------------NHÂN VIÊN-----------------------------------------//
        public DataSet Load_NhanVien(string tenbang)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                DataSet ds = new DataSet(tenbang);
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang, conn);
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_NhanVien(Cls_NhanVien nv)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("set dateformat dmy insert into Tb_NhanVien (MaNV,HoTen,GioiTinh,NgaySinh,SoCMND,NoiSinh,TonGiao,DanToc,MaPB,MaCV,DienThoai,HoKhau,NgayVaoLam,ChoOHienNay,SoBHYT,SoTheATM) values(@MANV,@HOTEN,@GIOITINH,@NGAYSINH,@SOCMND,@NOISINH,@TONGIAO,@DANTOC,@MAPB,@MACV,@DIENTHOAI,@HOKHAU,@NGAYVAOLAM,@CHOOHIENNAY,@SOBHYT,@SOTHEATM)", conn);
                cmd.Parameters.AddWithValue("@MANV", nv.manv);
                cmd.Parameters.AddWithValue("@HOTEN", nv.hoten);
                cmd.Parameters.AddWithValue("@GIOITINH", nv.gioitinh);
                cmd.Parameters.AddWithValue("@NGAYSINH", nv.ngaysinh);
                cmd.Parameters.AddWithValue("@NOISINH", nv.noisinh);
                cmd.Parameters.AddWithValue("@SOCMND", nv.socmnd);
                cmd.Parameters.AddWithValue("@DANTOC", nv.dantoc);
                cmd.Parameters.AddWithValue("@TONGIAO", nv.tongiao);
                cmd.Parameters.AddWithValue("@MAPB", nv.mapb);
                cmd.Parameters.AddWithValue("@MACV", nv.macv);
                cmd.Parameters.AddWithValue("@DIENTHOAI", nv.dienthoai);
                cmd.Parameters.AddWithValue("@HOKHAU", nv.hokhau);
                cmd.Parameters.AddWithValue("@NGAYVAOLAM", nv.ngayvaolam);
                cmd.Parameters.AddWithValue("@CHOOHIENNAY", nv.choohiennay);
                cmd.Parameters.AddWithValue("@SOBHYT", nv.sobhyt);
                cmd.Parameters.AddWithValue("@SOTHEATM", nv.sotheatm);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nv.manv + " đã thêm thành công!";
                }
                else
                {
                    strMessage = nv.manv + " thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_NhanVien(Cls_NhanVien nv)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("set dateformat dmy update Tb_NhanVien set HoTen=@HOTEN,GioiTinh=@GIOITINH,NgaySinh=@NGAYSINH,NoiSinh=@NOISINH,SoCMND=@SOCMND,TonGiao=@TONGIAO,DanToc=@DANTOC,MaPB=@MAPB,MaCV=@MACV,DienThoai=@DIENTHOAI,HoKhau=@HOKHAU,NgayVaoLam=@NGAYVAOLAM,ChoOHienNay=@CHOOHIENNAY,SoBHYT=@SOBHYT,SoTheATM=@SOTHEATM where MaNV=@MANV", conn);
                cmd.Parameters.AddWithValue("@MANV", nv.manv);
                cmd.Parameters.AddWithValue("@HOTEN", nv.hoten);
                cmd.Parameters.AddWithValue("@GIOITINH", nv.gioitinh);
                cmd.Parameters.AddWithValue("@NGAYSINH", nv.ngaysinh);
                cmd.Parameters.AddWithValue("@NOISINH", nv.noisinh);
                cmd.Parameters.AddWithValue("@SOCMND", nv.socmnd);
                cmd.Parameters.AddWithValue("@DANTOC", nv.dantoc);
                cmd.Parameters.AddWithValue("@TONGIAO", nv.tongiao);
                cmd.Parameters.AddWithValue("@MAPB", nv.mapb);
                cmd.Parameters.AddWithValue("@MACV", nv.macv);
                cmd.Parameters.AddWithValue("@DIENTHOAI", nv.dienthoai);
                cmd.Parameters.AddWithValue("@HOKHAU", nv.hokhau);
                cmd.Parameters.AddWithValue("@NGAYVAOLAM", nv.ngayvaolam);
                cmd.Parameters.AddWithValue("@CHOOHIENNAY", nv.choohiennay);
                cmd.Parameters.AddWithValue("@SOBHYT", nv.sobhyt);
                cmd.Parameters.AddWithValue("@SOTHEATM", nv.sotheatm);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nv.manv + " đã update thành công!";
                }
                else
                {
                    strMessage = nv.manv + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_NhanVien(Cls_NhanVien nv)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_NhanVien where MaNV=@MANV", conn);
                cmd.Parameters.AddWithValue("@MANV", nv.manv);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nv.manv + " đã delete thành công!";
                }
                else
                {
                    strMessage = nv.manv + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------TRÌNH ĐỘ-----------------------------------------//
        public DataSet Load_TrinhDo(string tenbang)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                DataSet ds = new DataSet(tenbang);
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang, conn);
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_TrinhDo(Cls_TrinhDo td)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_TrinhDo (MaTD,TenTD) values(@MATD,@TENTD)", conn);
                cmd.Parameters.AddWithValue("@MATD", td.matd);
                cmd.Parameters.AddWithValue("@TENTD", td.tentd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = td.matd + " đã thêm thành công!";
                }
                else
                {
                    strMessage = td.matd + " thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_TrinhDo(Cls_TrinhDo td)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_TrinhDo set TenTD=@TENTD where MaTD=@MATD", conn);
                cmd.Parameters.AddWithValue("@MATD", td.matd);
                cmd.Parameters.AddWithValue("@TENTD", td.tentd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = td.matd + " đã update thành công!";
                }
                else
                {
                    strMessage = td.matd + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_TrinhDo(Cls_TrinhDo td)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_TrinhDo where MaTD=@MATD", conn);
                cmd.Parameters.AddWithValue("@MATD", td.matd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = td.matd + " đã delete thành công!";
                }
                else
                {
                    strMessage = td.matd + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------CHI TIẾT TRÌNH ĐỘ-----------------------------------------//
        public DataSet Load_CTTrinhDo(string tenbang)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                DataSet ds = new DataSet(tenbang);
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang, conn);
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_CTTrinhDo(Cls_CTTrinhDo cttd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("set dateformat dmy insert into Tb_CTTrinhDo (MaCTTD,MaNV,MaTD,ChuyenMon,NgayCap,Truong) values(@MACTTD,@MANV,@MATD,@CHUYENMON,@NGAYCAP,@TRUONG)", conn);
                cmd.Parameters.AddWithValue("@MACTTD", cttd.macttd);
                cmd.Parameters.AddWithValue("@MANV", cttd.manv);
                cmd.Parameters.AddWithValue("@MATD", cttd.matd);
                cmd.Parameters.AddWithValue("@CHUYENMON", cttd.chuyenmon);
                cmd.Parameters.AddWithValue("@NGAYCAP", cttd.ngaycap);
                cmd.Parameters.AddWithValue("@TRUONG", cttd.truong);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cttd.macttd + " đã thêm thành công!";
                }
                else
                {
                    strMessage = cttd.macttd + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_CTTrinhDo(Cls_CTTrinhDo cttd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("set dateformat dmy update Tb_CTTrinhDo set MaNV=@MANV,MaTD=@MATD,ChuyenMon=@CHUYENMON,NgayCap=@NGAYCAP,Truong=@TRUONG where MaCTTD=@MACTTD", conn);
                cmd.Parameters.AddWithValue("@MACTTD", cttd.macttd);
                cmd.Parameters.AddWithValue("@MANV", cttd.manv);
                cmd.Parameters.AddWithValue("@MATD", cttd.matd);
                cmd.Parameters.AddWithValue("@CHUYENMON", cttd.chuyenmon);
                cmd.Parameters.AddWithValue("@NGAYCAP", cttd.ngaycap);
                cmd.Parameters.AddWithValue("@TRUONG", cttd.truong);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cttd.macttd + " đã update thành công!";
                }
                else
                {
                    strMessage = cttd.macttd + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_CTTrinhDo(Cls_CTTrinhDo cttd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_CTTrinhDo where MaCTTD=@MACTTD", conn);
                cmd.Parameters.AddWithValue("@MACTTD", cttd.macttd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cttd.macttd + " đã delete thành công!";
                }
                else
                {
                    strMessage = cttd.macttd + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------NGOẠI NGỮ-----------------------------------------//
        public DataSet Load_NgoaiNgu()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_NgoaiNgu", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_NgoaiNgu(Cls_NgoaiNgu nn)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_NgoaiNgu (MaNN,TenNN) values(@MANN,@TENNN)", conn);
                cmd.Parameters.AddWithValue("@MANN", nn.mann);
                cmd.Parameters.AddWithValue("@TENNN", nn.tennn); ;

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nn.mann + " đã thêm thành công!";
                }
                else
                {
                    strMessage = nn.mann + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_NgoaiNgu(Cls_NgoaiNgu nn)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_NgoaiNgu set TenNN=@TENNN where MaNN=@MANN", conn);
                cmd.Parameters.AddWithValue("@MANN", nn.mann);
                cmd.Parameters.AddWithValue("@TENNN", nn.tennn); ;

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nn.mann + " đã update thành công!";
                }
                else
                {
                    strMessage = nn.mann + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_NgoaiNgu(Cls_NgoaiNgu nn)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_NgoaiNgu where MaNN=@MANN", conn);
                cmd.Parameters.AddWithValue("@MANN", nn.mann);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nn.mann + " đã delete thành công!";
                }
                else
                {
                    strMessage = nn.mann + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------CHI TIẾT NGOẠI NGỮ-----------------------------------------//
        public DataSet Load_CTNgoaiNgu()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_CTNgoaiNgu", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_CTNgoaiNgu(Cls_CTNgoaiNgu ctnn)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_CTNgoaiNgu (MaCTNN,MaNN,MaNV,TrinhDo,NgayCap,NoiCap) values(@MACTNN,@MANN,@MANV,@TRINHDO,@NGAYCAP,@NOICAP)", conn);
                cmd.Parameters.AddWithValue("@MACTNN", ctnn.mactnn);
                cmd.Parameters.AddWithValue("@MANN", ctnn.mann);
                cmd.Parameters.AddWithValue("@MANV", ctnn.manv);
                cmd.Parameters.AddWithValue("@TRINHDO", ctnn.trinhdo);
                cmd.Parameters.AddWithValue("@NGAYCAP", ctnn.ngaycap);
                cmd.Parameters.AddWithValue("@NOICAP", ctnn.noicap);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctnn.mactnn + " đã thêm thành công!";
                }
                else
                {
                    strMessage = ctnn.mactnn + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_CTNgoaiNgu(Cls_CTNgoaiNgu ctnn)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_CTNgoaiNgu set MaNN=@MANN,MaNV=@MANV,TrinhDo=@TRINHDO,NgayCap=@NGAYCAP,NoiCap=@NOICAP where MaCTNN=@MACTNN", conn);
                cmd.Parameters.AddWithValue("@MACTNN", ctnn.mactnn);
                cmd.Parameters.AddWithValue("@MANN", ctnn.mann);
                cmd.Parameters.AddWithValue("@MANV", ctnn.manv);
                cmd.Parameters.AddWithValue("@TRINHDO", ctnn.trinhdo);
                cmd.Parameters.AddWithValue("@NGAYCAP", ctnn.ngaycap);
                cmd.Parameters.AddWithValue("@NOICAP", ctnn.noicap);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctnn.mactnn + " đã update thành công!";
                }
                else
                {
                    strMessage = ctnn.mactnn + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_CTNgoaiNgu(Cls_CTNgoaiNgu ctnn)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_CTNgoaiNgu where MaCTNN=@MACTNN", conn);
                cmd.Parameters.AddWithValue("@MACTNN", ctnn.mactnn);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctnn.mactnn + " đã delete thành công!";
                }
                else
                {
                    strMessage = ctnn.mactnn + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------PHÒNG BAN-----------------------------------------//
        public DataSet Load_PhongBan(string tenbang)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                DataSet ds = new DataSet(tenbang);
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang , conn);
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_PhongBan(Cls_PhongBan pb)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_PhongBan (MaPB,TenPB,DienThoai,Fax) values(@MAPB,@TENPB,@DIENTHOAI,@FAX)", conn);
                cmd.Parameters.AddWithValue("@MAPB", pb.mapb);
                cmd.Parameters.AddWithValue("@TENPB", pb.tenpb);
                cmd.Parameters.AddWithValue("@DIENTHOAI", pb.dienthoai);
                cmd.Parameters.AddWithValue("@FAX", pb.fax);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = pb.mapb + " đã thêm thành công!";
                }
                else
                {
                    strMessage = pb.mapb + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_PhongBan(Cls_PhongBan pb)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_PhongBan set TenPB=@TENPB,DienThoai=@DIENTHOAI,Fax=@FAX where MaPB=@MAPB", conn);
                cmd.Parameters.AddWithValue("@MAPB", pb.mapb);
                cmd.Parameters.AddWithValue("@TENPB", pb.tenpb);
                cmd.Parameters.AddWithValue("@DIENTHOAI", pb.dienthoai);
                cmd.Parameters.AddWithValue("@FAX", pb.fax);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = pb.mapb + " đã update thành công!";
                }
                else
                {
                    strMessage = pb.mapb + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_PhongBan(Cls_PhongBan pb)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_PhongBan where MaPB=@MAPB", conn);
                cmd.Parameters.AddWithValue("@MAPB", pb.mapb);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = pb.mapb + " đã delete thành công!";
                }
                else
                {
                    strMessage = pb.mapb + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------CHỨC VỤ-----------------------------------------//
        public DataSet Load_ChucVu( string tenbang)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                DataSet ds = new DataSet(tenbang);
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang, conn);
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_ChucVu(Cls_ChucVu cv)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_ChucVu (MaCV,TenCV,LuongCB) values(@MACV,@TENCV,@LUONGCB)", conn);
                cmd.Parameters.AddWithValue("@MACV", cv.macv);
                cmd.Parameters.AddWithValue("@TENCV", cv.tencv);
                cmd.Parameters.AddWithValue("@LUONGCB", cv.luongcb);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cv.macv + " đã thêm thành công!";
                }
                else
                {
                    strMessage = cv.macv + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_ChucVu(Cls_ChucVu cv)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_ChucVu set TenCV=@TENCV,LuongCB=@LUONGCB where MaCV=@MACV", conn);
                cmd.Parameters.AddWithValue("@MACV", cv.macv);
                cmd.Parameters.AddWithValue("@TENCV", cv.tencv);
                cmd.Parameters.AddWithValue("@LUONGCB", cv.luongcb);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cv.macv + " đã update thành công!";
                }
                else
                {
                    strMessage = cv.macv + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_ChucVu(Cls_ChucVu cv)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_ChucVu where MaCV=@MACV", conn);
                cmd.Parameters.AddWithValue("@MACV", cv.macv);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cv.macv + " đã delete thành công!";
                }
                else
                {
                    strMessage = cv.macv + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------THAI SẢN-----------------------------------------//
        public DataSet Load_ThaiSan()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_ThaiSan", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_ThaiSan(Cls_ThaiSan ts)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_ThaiSan (MaTS,MaNV,NgayNghiSinh,NgayTroLai,TroCapCongTy) values(@MATS,@MANV,@NGAYNGHISINH,@NGAYTROLAI,@TROCAPCONGTY)", conn);
                cmd.Parameters.AddWithValue("@MATS", ts.mats);
                cmd.Parameters.AddWithValue("@MANV", ts.manv);
                cmd.Parameters.AddWithValue("@NGAYNGHISINH", ts.ngaynghisinh);
                cmd.Parameters.AddWithValue("@NGAYTROLAI", ts.ngaytrolai);
                cmd.Parameters.AddWithValue("@TROCAPCONGTY", ts.trocapcongty);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ts.mats + " đã thêm thành công!";
                }
                else
                {
                    strMessage = ts.mats + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_ThaiSan(Cls_ThaiSan ts)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_ThaiSan set MaNV=@MANV,NgayNghiSinh=@NGAYNGHISINH,NgayTroLai=@NGAYTROLAI,TroCapCongTy=@TROCAPCONGTY where MaTS=@MATS", conn);
                cmd.Parameters.AddWithValue("@MATS", ts.mats);
                cmd.Parameters.AddWithValue("@MANV", ts.manv);
                cmd.Parameters.AddWithValue("@NGAYNGHISINH", ts.ngaynghisinh);
                cmd.Parameters.AddWithValue("@NGAYTROLAI", ts.ngaytrolai);
                cmd.Parameters.AddWithValue("@TROCAPCONGTY", ts.trocapcongty);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ts.mats + " đã update thành công!";
                }
                else
                {
                    strMessage = ts.mats + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_ThaiSan(Cls_ThaiSan ts)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_ThaiSan where MaTS=@MATS", conn);
                cmd.Parameters.AddWithValue("@MATS", ts.mats);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ts.mats + " đã delete thành công!";
                }
                else
                {
                    strMessage = ts.mats + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------HỢP ĐỒNG-----------------------------------------//
        public DataSet Load_HopDong(string tenbang)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                DataSet ds = new DataSet(tenbang);
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang, conn);
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_HopDong(Cls_HopDong hd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_HopDong (MaLoaiHD,TenHD) values(@MALOAIHD,@TENHD)", conn);
                cmd.Parameters.AddWithValue("@MALOAIHD", hd.maloaihd);
                cmd.Parameters.AddWithValue("@TENHD", hd.tenhd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = hd.maloaihd + " đã thêm thành công!";
                }
                else
                {
                    strMessage = hd.tenhd + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_HopDong(Cls_HopDong hd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_HopDong set TenHD=@TENHD where MaLoaiHD=@MALOAIHD", conn);
                cmd.Parameters.AddWithValue("@MALOAIHD", hd.maloaihd);
                cmd.Parameters.AddWithValue("@TENHD", hd.tenhd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = hd.maloaihd + " đã update thành công!";
                }
                else
                {
                    strMessage = hd.maloaihd + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_HopDong(Cls_HopDong hd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_HopDong where MaLoaiHD=@MALOAIHD", conn);
                cmd.Parameters.AddWithValue("@MALOAIHD", hd.maloaihd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = hd.maloaihd + " đã delete thành công!";
                }
                else
                {
                    strMessage = hd.maloaihd + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------CHI TIẾT HỢP ĐỒNG-----------------------------------------//
        public DataSet Load_CTHopDong(string tenbang)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                DataSet ds = new DataSet(tenbang);
                SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang, conn);
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_CTHopDong(Cls_CTHopDong cthd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("set dateformat dmy insert into Tb_CTHopDong (SoHD,MaLoaiHD,MaNV,NgayBatDau,NgayKetThuc,LuongCB) values(@SOHD,@MALOAIHD,@MANV,@NGAYBATDAU,@NGAYKETTHUC,@LUONGCB)", conn);
                cmd.Parameters.AddWithValue("@SOHD", cthd.sohd);
                cmd.Parameters.AddWithValue("@MALOAIHD", cthd.maloaihd);
                cmd.Parameters.AddWithValue("@MANV", cthd.manv);
                cmd.Parameters.AddWithValue("@NGAYBATDAU", cthd.ngaybatdau);
                cmd.Parameters.AddWithValue("@NGAYKETTHUC", cthd.ngayketthuc);
                cmd.Parameters.AddWithValue("@LUONGCB", cthd.luongcb);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cthd.sohd + " đã thêm thành công!";
                }
                else
                {
                    strMessage = cthd.sohd + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_CTHopDong(Cls_CTHopDong cthd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("set dateformat dmy update Tb_CTHopDong set MaLoaiHD=@MALOAIHD,MaNV=@MANV,NgayBatDau=@NGAYBATDAU,NgayKetThuc=@NGAYKETTHUC,LuongCB=@LUONGCB where SoHD=@SOHD", conn);
                cmd.Parameters.AddWithValue("@SOHD", cthd.sohd);
                cmd.Parameters.AddWithValue("@MALOAIHD", cthd.maloaihd);
                cmd.Parameters.AddWithValue("@MANV", cthd.manv);
                cmd.Parameters.AddWithValue("@NGAYBATDAU", cthd.ngaybatdau);
                cmd.Parameters.AddWithValue("@NGAYKETTHUC", cthd.ngayketthuc);
                cmd.Parameters.AddWithValue("@LUONGCB", cthd.luongcb);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cthd.sohd + " đã update thành công!";
                }
                else
                {
                    strMessage = cthd.sohd + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_CTHopDong(Cls_CTHopDong cthd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_CTHopDong where SoHD=@SOHD", conn);
                cmd.Parameters.AddWithValue("@SOHD", cthd.sohd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cthd.sohd + " đã delete thành công!";
                }
                else
                {
                    strMessage = cthd.sohd + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------PHÂN QUYỀN-----------------------------------------//
        public DataSet Load_PhanQuyen()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_PhanQuyen", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_PhanQuyen(Cls_PhanQuyen pq)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_PhanQuyen (MaPQ,TenPQ) values(@MAPQ,@TENPQ)", conn);
                cmd.Parameters.AddWithValue("@MAPQ", pq.mapq);
                cmd.Parameters.AddWithValue("@TENPQ", pq.tenpq);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = pq.mapq + " đã thêm thành công!";
                }
                else
                {
                    strMessage = pq.tenpq + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_PhanQuyen(Cls_PhanQuyen pq)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_PhanQuyen set TenPQ=@TENPQ where MaPQ=@MAPQ", conn);
                cmd.Parameters.AddWithValue("@MAPQ", pq.mapq);
                cmd.Parameters.AddWithValue("@TENPQ", pq.tenpq);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = pq.mapq + " đã update thành công!";
                }
                else
                {
                    strMessage = pq.mapq + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_PhanQuyen(Cls_PhanQuyen pq)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_PhanQuyen where MaPQ=@MAPQ", conn);
                cmd.Parameters.AddWithValue("@MAPQ", pq.mapq);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = pq.mapq + " đã delete thành công!";
                }
                else
                {
                    strMessage = pq.mapq + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------NGƯỜI DÙNG-----------------------------------------//
        public DataSet Load_NguoiDung()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_NguoiDung", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_NguoiDung(Cls_NguoiDung nd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_NguoiDung (TenDN,MatKhau,MaNV,MaPQ) values(@TENDN,@MATKHAU,@MANV,@MAPQ)", conn);
                cmd.Parameters.AddWithValue("@TENDN", nd.tendn);
                cmd.Parameters.AddWithValue("@MATKHAU", nd.matkhau);
                cmd.Parameters.AddWithValue("@MANV", nd.manv);
                cmd.Parameters.AddWithValue("@MAPQ", nd.mapq);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nd.tendn + " đã thêm thành công!";
                }
                else
                {
                    strMessage = nd.tendn + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_NguoiDung(Cls_NguoiDung nd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_NguoiDung set MatKhau=@MATKHAU,MaNV=@MANV,MaPQ=@MAPQ where TenDN=@TENDN", conn);
                cmd.Parameters.AddWithValue("@TENDN", nd.tendn);
                cmd.Parameters.AddWithValue("@MATKHAU", nd.matkhau);
                cmd.Parameters.AddWithValue("@MANV", nd.manv);
                cmd.Parameters.AddWithValue("@MAPQ", nd.mapq);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nd.tendn + " đã update thành công!";
                }
                else
                {
                    strMessage = nd.tendn + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_NguoiDung(Cls_NguoiDung nd)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_NguoiDung where TenDN=@TENDN", conn);
                cmd.Parameters.AddWithValue("@TENDN", nd.tendn);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = nd.tendn + " đã delete thành công!";
                }
                else
                {
                    strMessage = nd.tendn + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------KĨ LUẬT-----------------------------------------//
        public DataSet Load_KiLuat()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_KiLuat", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_KiLuat(Cls_KiLuat kl)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_KiLuat (MaKL,TenKL) values(@MAKL,@TENKL)", conn);
                cmd.Parameters.AddWithValue("@MAKL", kl.makl);
                cmd.Parameters.AddWithValue("@TENKL", kl.tenkl);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = kl.makl + " đã thêm thành công!";
                }
                else
                {
                    strMessage = kl.tenkl + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_KiLuat(Cls_KiLuat kl)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_KiLuat set TenKL=@TENKL where MaKL=@MAKL", conn);
                cmd.Parameters.AddWithValue("@MAKL", kl.makl);
                cmd.Parameters.AddWithValue("@TENKL", kl.tenkl);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = kl.makl + " đã update thành công!";
                }
                else
                {
                    strMessage = kl.makl + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_KiLuat(Cls_KiLuat kl)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_KiLuat where MaKL=@MAKL", conn);
                cmd.Parameters.AddWithValue("@MAKL", kl.makl);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = kl.makl + " đã delete thành công!";
                }
                else
                {
                    strMessage = kl.makl + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------CHI TIẾT KĨ LUẬT-----------------------------------------//
        public DataSet Load_CTKiLuat()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_CTKiLuat", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_CTKiLuat(Cls_CTKiLuat ctkl)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_CTKiLuat (MaCTKL,MaKL,MaNV,NgayKL,HinhThuc,NguyenNhan) values(@MACTKL,@MAKL,@MANV,@NGAYKL,@HINHTHUC,@NGUYENNHAN)", conn);
                cmd.Parameters.AddWithValue("@MACTKL", ctkl.mactkl);
                cmd.Parameters.AddWithValue("@MAKL", ctkl.makl);
                cmd.Parameters.AddWithValue("@MANV", ctkl.manv);
                cmd.Parameters.AddWithValue("@NGAYKL", ctkl.ngaykl);
                cmd.Parameters.AddWithValue("@HINHTHUC", ctkl.hinhthuc);
                cmd.Parameters.AddWithValue("@NGUYENNHAN", ctkl.nguyennhan);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctkl.mactkl + " đã thêm thành công!";
                }
                else
                {
                    strMessage = ctkl.mactkl + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_CTKiLuat(Cls_CTKiLuat ctkl)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_CTKiLuat set MaKL=@MAKL,MaNV=@MANV,NgayKL=@NGAYKL,HinhThuc=@HINHTHUC,NguyenNhan=@NGUYENNHAN where MaCTKL=@MACTKL", conn);
                cmd.Parameters.AddWithValue("@MACTKL", ctkl.mactkl);
                cmd.Parameters.AddWithValue("@MAKL", ctkl.makl);
                cmd.Parameters.AddWithValue("@MANV", ctkl.manv);
                cmd.Parameters.AddWithValue("@NGAYKL", ctkl.ngaykl);
                cmd.Parameters.AddWithValue("@HINHTHUC", ctkl.hinhthuc);
                cmd.Parameters.AddWithValue("@NGUYENNHAN", ctkl.nguyennhan);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctkl.mactkl + " đã update thành công!";
                }
                else
                {
                    strMessage = ctkl.mactkl + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_CTKiLuat(Cls_CTKiLuat ctkl)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_CTKiLuat where MaCTKL=@MACTKL", conn);
                cmd.Parameters.AddWithValue("@MACTKL", ctkl.mactkl);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctkl.mactkl + " đã delete thành công!";
                }
                else
                {
                    strMessage = ctkl.mactkl + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------KHEN THƯỞNG-----------------------------------------//
        public DataSet Load_KhenThuong()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_KhenThuong", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_KhenThuong(Cls_KhenThuong kt)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_KhenThuong (MaLoai,TenLoai) values(@MALOAI,@TENLOAI)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MALOAI", kt.maloai);
                cmd.Parameters.AddWithValue("@TENLOAI", kt.tenloai);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = kt.maloai + " đã thêm thành công!";
                }
                else
                {
                    strMessage = kt.maloai + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_KhenThuong(Cls_KhenThuong kt)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_KhenThuong set TenLoai=@TENLOAI where MaLoai=@MALOAI", conn);
                cmd.Parameters.AddWithValue("@MALOAI", kt.maloai);
                cmd.Parameters.AddWithValue("@TENLOAI", kt.tenloai);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = kt.maloai + " đã update thành công!";
                }
                else
                {
                    strMessage = kt.maloai + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_KhenThuong(Cls_KhenThuong kt)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_KhenThuong where MaLoai=@MALOAI", conn);
                cmd.Parameters.AddWithValue("@MALOAI", kt.maloai);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = kt.maloai + " đã delete thành công!";
                }
                else
                {
                    strMessage = kt.maloai + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------CHI TIẾT KHEN THƯỞNG-----------------------------------------//
        public DataSet Load_CTKhenThuong()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_CTKhenThuong", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_CTKhenThuong(Cls_CTKhenThuong ctkt)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_CTKhenThuong (SoQD,MaNV,NgayQD,MaLoai,NoiDung,HinhThuc) values(@SOQD,@MANV,@NGAYQD,@MALOAI,@NOIDUNG,@HINHTHUC)", conn);
                cmd.Parameters.AddWithValue("@SOQD", ctkt.soqd);
                cmd.Parameters.AddWithValue("@MANV", ctkt.manv);
                cmd.Parameters.AddWithValue("@NGAYQD", ctkt.ngayqd);
                cmd.Parameters.AddWithValue("@MALOAI", ctkt.maloai);
                cmd.Parameters.AddWithValue("@NOIDUNG", ctkt.noidung);
                cmd.Parameters.AddWithValue("@HINHTHUC", ctkt.hinhthuc);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctkt.soqd + " đã thêm thành công!";
                }
                else
                {
                    strMessage = ctkt.soqd + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_CTKhenThuong(Cls_CTKhenThuong ctkt)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_CTKhenThuong set MaNV=@MANV,NgayQD=@NGAYQD,MaLoai=@MALOAI,NoiDung=@NOIDUNG,HinhThuc=@HINHTHUC where SoQD=@SOQD", conn);
                cmd.Parameters.AddWithValue("@SOQD", ctkt.soqd);
                cmd.Parameters.AddWithValue("@MANV", ctkt.manv);
                cmd.Parameters.AddWithValue("@NGAYQD", ctkt.ngayqd);
                cmd.Parameters.AddWithValue("@MALOAI", ctkt.maloai);
                cmd.Parameters.AddWithValue("@NOIDUNG", ctkt.noidung);
                cmd.Parameters.AddWithValue("@HINHTHUC", ctkt.hinhthuc);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctkt.soqd + " đã update thành công!";
                }
                else
                {
                    strMessage = ctkt.soqd + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_CTKhenThuong(Cls_CTKhenThuong ctkt)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_CTKhenThuong where SoQD=@SOQD", conn);
                cmd.Parameters.AddWithValue("@SOQD", ctkt.soqd);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = ctkt.soqd + " đã delete thành công!";
                }
                else
                {
                    strMessage = ctkt.soqd + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------CHUYỂN CÔNG TÁC-----------------------------------------//
        public DataSet Load_ChuyenCongTac()
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Tb_ChuyenCongTac", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public string Add_ChuyenCongTac(Cls_ChuyenCongTac cct)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tb_ChuyenCongTac (MaChuyen,MaNV,NgayChuyen,MaCVCu,MaPBCu,MaCVMoi,MaPBMoi) values(@MACHUYEN,@MANV,@NGAYCHUYEN,@MACVCU,@MAPBCU,@MACVMOI,@MAPBMOI)", conn);
                cmd.Parameters.AddWithValue("@MACHUYEN", cct.machuyen);
                cmd.Parameters.AddWithValue("@MANV", cct.manv);
                cmd.Parameters.AddWithValue("@NGAYCHUYEN", cct.ngaychuyen);
                cmd.Parameters.AddWithValue("@MACVCU", cct.macvcu);
                cmd.Parameters.AddWithValue("@MAPBCU", cct.mapbcu);
                cmd.Parameters.AddWithValue("@MACVMOI", cct.macvmoi);
                cmd.Parameters.AddWithValue("@MAPBMOI", cct.mapbmoi);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cct.machuyen + " đã thêm thành công!";
                }
                else
                {
                    strMessage = cct.machuyen + " đã thêm không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Update_ChuyenCongTac(Cls_ChuyenCongTac cct)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Tb_ChuyenCongTac set MaNV=@MANV,NgayChuyen=@NGAYCHUYEN,MaCVCu=@MACVCU,MaPBCu=@MAPBCU,MaCVMoi=@MACMOI,MaPBMoi=@MAPBMOI where MaChuyen=@MACHUYEN", conn);
                cmd.Parameters.AddWithValue("@MACHUYEN", cct.machuyen);
                cmd.Parameters.AddWithValue("@MANV", cct.manv);
                cmd.Parameters.AddWithValue("@NGAYCHUYEN", cct.ngaychuyen);
                cmd.Parameters.AddWithValue("@MACVCU", cct.macvcu);
                cmd.Parameters.AddWithValue("@MAPBCU", cct.mapbcu);
                cmd.Parameters.AddWithValue("@MACVMOI", cct.macvmoi);
                cmd.Parameters.AddWithValue("@MAPBMOI", cct.mapbmoi);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cct.machuyen + " đã update thành công!";
                }
                else
                {
                    strMessage = cct.machuyen + " update không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        public string Delete_ChuyenCongTac(Cls_ChuyenCongTac cct)
        {
            string strMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Tb_ChuyenCongTac where MaChuyen=@MACHUYEN", conn);
                cmd.Parameters.AddWithValue("@MACHUYEN", cct.machuyen);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    strMessage = cct.machuyen + " đã delete thành công!";
                }
                else
                {
                    strMessage = cct.machuyen + " delete không thành công!";
                }
                conn.Close();
            }
            return strMessage;
        }
        //-------------------------------------------------------ĐĂNG NHẬP-----------------------------------------//
    }
}
