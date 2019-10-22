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
    class HuanLuyenVienData
    {
		Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM HLV";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach(string tuKhoa)
        {
            string sql = "SELECT * FROM HLV WHERE TENHLV LIKE '%" + tuKhoa + "%'";
            return data.QuerySQL(sql);
        }

        public void Them(HuanLuyenVienInfo info)
        {
            string sql = "INSERT INTO HLV(MAHLV, TENHLV, NGAYSINH, GIOITINH, CMND, SDT, DIACHI, NGAYVAOLAM, HSLUONG) VALUES('" + info.MaHLV + "', N'" + info.TenHLV + "', '" + info.NgaySinh.ToString("yyyy-MM-dd") + "', '" + info.GioiTinh + "', '" + info.CMND + "', '" + info.SDT + "', N'" + info.DiaChi + "', '" + info.NgayVaoLam.ToString("yyyy-MM-dd") + "', " + info.HsLuong + ")";
            data.ExecuteSQL(sql);
        }

        /// <summary>
        /// Cập nhật thông tin Huấn luyện viên
        /// </summary>
        /// <param name="info">Thông tin mới</param>
        /// <param name="maHLV">Mã nhân viên cũ</param>
        public void Sua(HuanLuyenVienInfo info, string maHLV)
        {
            string sql = "UPDATE HLV SET MAHLV = '" + info.MaHLV + "', TENHLV = N'" + info.TenHLV + "', NGAYSINH = '" + info.NgaySinh.ToString("yyyy-MM-dd") + "', GIOITINH = '" + info.GioiTinh + "', CMND = '" + info.CMND + "', SDT = '" + info.SDT + "', DIACHI = N'" + info.DiaChi + "', NGAYVAOLAM = '" + info.NgayVaoLam.ToString("yyyy-MM-dd") + "', HSLUONG = " + info.HsLuong + " WHERE MAHLV = '" + maHLV + "'";
            data.ExecuteSQL(sql);
        }

        public void Xoa(HuanLuyenVienInfo info)
        {
			string sql = "DELETE FROM HLV WHERE MAHLV = '" + info.MaHLV + "'";
            data.ExecuteSQL(sql);
        }
    }
}
