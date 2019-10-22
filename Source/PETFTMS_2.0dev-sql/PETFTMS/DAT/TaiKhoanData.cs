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
    class TaiKhoanData
    {
		private Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM TAIKHOAN";
            return data.QuerySQL(sql);
        }

        public DataTable ChiTiet(string tenDangNhap, string matKhau)
        {
			string sql = "SELECT * FROM TAIKHOAN WHERE TENDANGNHAP = '" + tenDangNhap + "' AND MATKHAU = '" + matKhau + "'";
            return data.QuerySQL(sql);
        }

        public void Them(TaiKhoanInfo info)
        {
            string sql = "INSERT INTO TAIKHOAN(TENDANGNHAP, TENNV, MATKHAU, QUYEN) VALUES('" + info.TenDangNhap + "', N'" + info.TenNV + "', '" + info.MatKhau + "', " + info.Quyen + ")";
            data.ExecuteSQL(sql);
        }

        public void Sua(TaiKhoanInfo info)
        {
            string sql = "UPDATE TAIKHOAN SET TENDANGNHAP = '" + info.TenDangNhap + "', TENNV = N'" + info.TenNV + "', MATKHAU = '" + info.MatKhau + "', QUYEN = " + info.Quyen + " WHERE ID = " + info.ID;
            data.ExecuteSQL(sql);
        }

        public void Xoa(TaiKhoanInfo info)
        {
			string sql = "DELETE FROM TAIKHOAN WHERE ID = " + info.ID;
            data.ExecuteSQL(sql);
        }
    }
}
