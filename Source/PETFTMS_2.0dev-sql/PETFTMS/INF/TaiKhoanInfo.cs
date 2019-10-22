using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETFTMS.INF
{
    class TaiKhoanInfo
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string tenDangNhap;
        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        private string tenNV;
        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

        private string matKhau;
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        private int quyen;
        public int Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }
    }
}