using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETFTMS.INF
{
    class PetInfo
    {
        /*
            MAPET VARCHAR(5) NOT NULL,
	        TENPET VARCHAR(50) NOT NULL,
	        NGAYSINH DATE NOT NULL,
	        GIOITINH CHAR(1) NOT NULL,
	        MAU VARCHAR(10) NOT NULL,
	        CANNANG DOUBLE NOT NULL,
	        CHIEUCAO DOUBLE NOT NULL,
	        MAGIONG VARCHAR(5) NOT NULL,
	        MAKHACH VARCHAR(5) NOT NULL,
	        CONSTRAINT PK_PET PRIMARY KEY(MAPET),
            CONSTRAINT CK_GT_PET CHECK(GIOITINH IN('F', 'M')),
	        CONSTRAINT FK_PET_KHACH FOREIGN KEY(MAKHACH) REFERENCES PETFTMS.KHACHHANG(MAKHACH)
        */

        public PetInfo()
        {
            Giong = new GiongInfo();
            Khach = new KhachHangInfo();
        }

        private string maPet;
        public string MaPet
        {
            get { return maPet; }
            set { maPet = value; }
        }

        private string tenPet;
        public string TenPet
        {
            get { return  tenPet; }
            set { tenPet = value; }
        }

        private string ngaySinh;
        public string NgaySinh
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

        private string mau; // Color
        public string Mau
        {
            get { return mau; }
            set { mau = value; }
        }

        private double canNang;
        public double CanNang
        {
            get { return canNang; }
            set { canNang = value; }
        }

        private double chieuCao;
        public double ChieuCao
        {
            get { return chieuCao; }
            set { chieuCao = value; }
        }

        private GiongInfo giong; // Type
        internal GiongInfo Giong
        {
            get { return giong; }
            set { giong = value; }
        }

        private KhachHangInfo khach; // Owner
        internal KhachHangInfo Khach
        {
            get { return khach; }
            set { khach = value; }
        }
    }
}