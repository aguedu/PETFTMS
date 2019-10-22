using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PETFTMS.INF;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PETFTMS.DAT
{
    class KhachHangData
    {
		Connect data = new Connect();

        public DataTable DanhSach()
        {
			string sql = "SELECT * FROM KHACHHANG";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach(string tuKhoa)
        {
            string sql = "SELECT * FROM KHACHHANG WHERE TENKHACH LIKE '%" + tuKhoa + "%'";
            return data.QuerySQL(sql);
        }

        public void Them(KhachHangInfo info)
        {
            string sql = "INSERT INTO KHACHHANG(MAKHACH, TENKHACH, NGAYSINH, GIOITINH, CMND, SDT, DIACHI) VALUES('" + info.MaKhach + "', N'" + info.TenKhach + "', '" + info.NgaySinh.ToString("yyyy-MM-dd") + "', '" + info.GioiTinh + "', '" + info.CMND + "', '" + info.SDT + "', N'" + info.DiaChi + "')";
            data.ExecuteSQL(sql);
        }

        public void Sua(KhachHangInfo info, string maKhach)
        {
            string sql = "UPDATE KHACHHANG SET MAKHACH = '" + info.MaKhach + "', TENKHACH = N'" + info.TenKhach + "', NGAYSINH = '" + info.NgaySinh.ToString("yyyy-MM-dd") + "', GIOITINH = '" + info.GioiTinh + "', CMND = '" + info.CMND + "', SDT = '" + info.SDT + "', DIACHI = N'" + info.DiaChi + "' WHERE MAKHACH = '" + maKhach + "'";
            data.ExecuteSQL(sql);
        }

        public void Xoa(KhachHangInfo info)
        {
            string sql = "DELETE FROM KHACHHANG WHERE MAKHACH = '" + info.MaKhach + "'";
            data.ExecuteSQL(sql);
        }
    }
}
