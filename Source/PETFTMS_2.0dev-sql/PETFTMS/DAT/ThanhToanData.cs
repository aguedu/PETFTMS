using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PETFTMS.INF;

namespace PETFTMS.DAT
{
    class ThanhToanData
    {
        Connect data = new Connect();

        public object DanhSach(List<string> lstMaKhoaHoc)
        {
            // Xử lý điều kiện tìm kiếm
            string dieuKien = "";
            foreach(string ma in lstMaKhoaHoc)
            {
                
                dieuKien += "K.MAKHOA = '" + ma +"' OR ";
            }
            dieuKien = dieuKien.Substring(0, dieuKien.Length - 4); // trừ " 0R " cuối cùng;
            // Kết thúc xử lý điều kiện tìm kiếm
            string sql = "SELECT K.MAKHOA, K.TENKHOA, K.LOAI, P.TENPET, K.DONGIA FROM KHOAHOC K INNER JOIN PET P ON K.MAPET = P.MAPET WHERE "+dieuKien;
            DataTable dt = data.QuerySQL(sql);
            if (dt.Rows.Count > 0)
            {
                List<ThanhToanInfo> lstThanhToan = new List<ThanhToanInfo>();
                foreach (DataRow r in dt.Rows)
                {
                    ThanhToanInfo thanhToan = new ThanhToanInfo();
                    thanhToan.MaKhoa = r.Field<string>("MAKHOA");
                    thanhToan.TenKhoa = r.Field<string>("TENKHOA");
                    thanhToan.Loai = r.Field<string>("LOAI");
                    thanhToan.TenHocVien = r.Field<string>("TENPET");
                    thanhToan.Gia = r.Field<double>("DONGIA");
                    lstThanhToan.Add(thanhToan);
                }
                return lstThanhToan;
            }
            else
            {
                return null;
            }
        }
    }
}
