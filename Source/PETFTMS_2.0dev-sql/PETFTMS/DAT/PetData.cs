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
    class PetData
    {
        Connect db = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT P.*, G.MAGIONG, G.TENGIONG, K.MAKHACH, K.TENKHACH FROM PET P, GIONG G, KHACHHANG K WHERE P.MAGIONG = G.MAGIONG AND P.MAKHACH = K.MAKHACH";
            return db.QuerySQL(sql);
        }

        public DataTable DanhSach(string tuKhoa)
        {
            string sql = "SELECT P.*, G.TENGIONG, K.TENKHACH FROM PET P, GIONG G, KHACHHANG K WHERE P.MAGIONG = G.MAGIONG AND P.MAKHACH = K.MAKHACH AND TENPET LIKE '%" + tuKhoa + "%'";
            return db.QuerySQL(sql);
        }

        public void Them(PetInfo info)
        {
            string sql = "INSERT INTO PET(MAPET, TENPET, NGAYSINH, GIOITINH, MAU, CANNANG, CHIEUCAO, MAGIONG, MAKHACH) VALUES('" + info.MaPet + "', N'" + info.TenPet + "', '" + info.NgaySinh + "', '" + info.GioiTinh + "', N'" + info.Mau + "', " + info.CanNang + ", " + info.ChieuCao + ", '" + info.Giong.MaGiong + "', '" + info.Khach.MaKhach + "')";
            db.ExecuteSQL(sql);
        }

        public void Sua(PetInfo info, string maPet)
        {
            string sql = "UPDATE PET SET MAPET = '" + info.MaPet + "', TENPET = N'" + info.TenPet + "', NGAYSINH = '" + info.NgaySinh + "', GIOITINH = '" + info.GioiTinh + "', MAU = N'" + info.Mau + "', CANNANG = " + info.CanNang + ", CHIEUCAO = " + info.ChieuCao + ", MAGIONG = '" + info.Giong.MaGiong + "', MAKHACH = '" + info.Khach.MaKhach + "' WHERE MAPET = '" + maPet + "'";
            db.ExecuteSQL(sql);
        }

        public void Xoa(PetInfo info)
        {
            string sql = "DELETE FROM PET WHERE MAPET = '" + info.MaPet + "'";
            db.ExecuteSQL(sql);
        }
    }
}