using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETFTMS.INF
{
    class KhachHangInfo
    {
        /*
            MAKHACH VARCHAR(5) NOT NULL,
	        TENKHACH VARCHAR(50) NOT NULL,
	        NGAYSINH DATE NOT NULL,
            GIOITINH CHAR(1) NOT NULL,
	        CMND VARCHAR(12) NOT NULL,
            SDT VARCHAR(10) NOT NULL,
	        DIACHI VARCHAR(50),
	        CONSTRAINT PK_KHACH PRIMARY KEY(MAKHACH),
	        CONSTRAINT CK_GT_KHACH CHECK(GIOITINH IN('F', 'M')),
	        CONSTRAINT CK_CMND_KHACH CHECK(LENGTH(CMND) >= 9)
         */

        private string maKhach;
        public string MaKhach
        {
            get { return maKhach; }
            set { maKhach = value; } 
        }

        private string tenKhach;
        public string TenKhach
        {
            get { return tenKhach; } 
            set { tenKhach = value; } 
        }

        private DateTime ngaySinh;
        public DateTime NgaySinh
        {
            get { return ngaySinh; } 
            set { ngaySinh = value; } 
        }

        private string gioiTinh;
        public string GioiTinh
        {
            get { return gioiTinh; } 
            set { gioiTinh = value; } 
        }

        private string cmnd;
        public string CMND
        {
            get { return cmnd; } 
            set { cmnd = value; } 
        }

        private string sdt;
        public string SDT
        {
            get { return sdt; } 
            set { sdt = value; } 
        }


        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; } 
            set { diaChi = value; } 
        }
    }
}