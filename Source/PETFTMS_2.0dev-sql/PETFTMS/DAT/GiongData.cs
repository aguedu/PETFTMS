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
    class GiongData
    {
        Connect db = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM GIONG";
            return db.QuerySQL(sql);
        }

        public void Them(GiongInfo info)
        {
            string sql = "INSERT INTO GIONG(MAGIONG, TENGIONG, CAOTB, NANGTB) VALUES('" + info.MaGiong + "', N'" + info.TenGiong + "'," + info.CaoTB + "," + info.NangTB + ")";
            db.ExecuteSQL(sql);
        }

        public void Sua(GiongInfo info, string maGiong)
        {
            string sql = "UPDATE GIONG SET MAGIONG = '" + info.MaGiong + "', TENGIONG = N'" + info.TenGiong + "', CAOTB = " + info.CaoTB + ", NANGTB = " + info.NangTB + " WHERE MAGIONG = '" + maGiong + "'";
            db.ExecuteSQL(sql);
        }

        public void Xoa(GiongInfo info)
        {
            string sql = "DELETE FROM GIONG WHERE MAGIONG = '" + info.MaGiong + "'";
            db.ExecuteSQL(sql);
        }
    }
}