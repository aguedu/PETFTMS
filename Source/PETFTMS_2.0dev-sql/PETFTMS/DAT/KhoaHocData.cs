using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PETFTMS.INF;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PETFTMS.DAT
{
    class KhoaHocData
    {
		Connect data = new Connect();

        public DataTable DanhSach()
        {
			string sql = "SELECT K.*, H.TENHLV, P.TENPET FROM KHOAHOC K, HLV H, PET P WHERE K.MAHLV = H.MAHLV AND K.MAPET = P.MAPET";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach(string tuKhoa)
        {
            string sql = "SELECT K.*, H.TENHLV, P.TENPET FROM KHOAHOC K, HLV H, PET P WHERE K.MAHLV = H.MAHLV AND K.MAPET = P.MAPET AND TENKHOA LIKE N'%" + tuKhoa + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_Ma(string maKhoa)
        {
            string sql = "SELECT K.*, H.TENHLV, P.TENPET FROM KHOAHOC K, HLV H, PET P WHERE K.MAHLV = H.MAHLV AND K.MAPET = P.MAPET AND MAKHOA LIKE N'%" + maKhoa + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_Khach(string maKhach, string tenKhach, string cMND, string sDT, string ngaySinh)
        {
            string sql = "SELECT K.*, H.TENHLV, P.TENPET FROM KHOAHOC K INNER JOIN HLV H ON K.MAHLV = H.MAHLV INNER JOIN PET P ON K.MAPET = P.MAPET INNER JOIN KHACHHANG KH ON P.MAKHACH = KH.MAKHACH WHERE KH.MAKHACH = N'" + maKhach + "' OR TENKHACH LIKE N'%" + tenKhach + "%' OR KH.CMND = N'" + cMND + "' OR KH.SDT = '" + sDT + "' OR KH.NGAYSINH = '" + ngaySinh + "'";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_Pet(string maPet, string tenPet)
        {
            string sql = "SELECT K.*, H.TENHLV, P.TENPET FROM KHOAHOC K INNER JOIN HLV H ON K.MAHLV = H.MAHLV INNER JOIN PET P ON K.MAPET = P.MAPET WHERE K.MAPET = '" + maPet + "' OR P.TENPET LIKE N'%" + tenPet + "%'";
            return data.QuerySQL(sql);
        }

        public void Them(KhoaHocInfo info)
        {
            string sql = "INSERT INTO KHOAHOC(MAKHOA, TENKHOA, LOAI, NGAYBATDAU, THOILUONG, DONGIA, MAHLV, MAPET) VALUES('" + info.MaKhoa + "', N'" + info.TenKhoa + "', N'" + info.Loai + "', '" + info.NgayBD.ToString("yyyy-MM-dd") + "', " + info.ThoiLuong + "," + info.DonGia + ", '" + info.HLV.MaHLV + "', '" + info.Pet.MaPet + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(KhoaHocInfo info, string maKhoa)
        {
            string sql = "UPDATE KHOAHOC SET MAKHOA = '" + info.MaKhoa + "', TENKHOA = N'" + info.TenKhoa + "', LOAI = N'" + info.Loai + "', NGAYBATDAU = '" + info.NgayBD.ToString("yyyy-MM-dd") + "', THOILUONG = " + info.ThoiLuong + ", DONGIA = " + info.DonGia + ", MAHLV = '" + info.HLV.MaHLV + "', MAPET = '" + info.Pet.MaPet + "' WHERE MAKHOA = '" + maKhoa + "'";
            data.ExecuteSQL(sql);
        }

        public void Xoa(KhoaHocInfo info)
        {
            string sql = "DELETE FROM KHOAHOC WHERE MAKHOA = '" + info.MaKhoa + "'";
            data.ExecuteSQL(sql);
        }
    }
}
