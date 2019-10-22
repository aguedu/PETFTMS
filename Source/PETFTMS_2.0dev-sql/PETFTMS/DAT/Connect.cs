using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PETFTMS.DAT
{
    class Connect : DataTable
    {
		// Database connection
		private static string connString = @"Data Source=.\SQL2014EXPRESS;Initial Catalog=PETFTMS;Persist Security Info=True;User ID=sa;Password=sql2014";
        private static SqlConnection conn = null;

        public Connect()
        {
			conn = new SqlConnection(connString);
            conn.Open();
        }

        public static bool OpenConnect()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                return false;
            }
            else
                return true;
        }
		
        public static void CloseConnect()
        {
            conn.Close();
        }

		public DataTable QuerySQL(string sql)
		{
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
		}
		
		public void ExecuteSQL(string sql)
		{
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
		}
    }
}
