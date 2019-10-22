using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETFTMS.INF
{
    class HuanLuyenVienInfo
    {
        /*
            MAHLV VARCHAR(5) NOT NULL,
	        TENHLV VARCHAR(50) NOT NULL,
	        NGAYSINH DATE NOT NULL,
	        GIOITINH CHAR(1) NOT NULL,
	        CMND VARCHAR(12) NOT NULL,
	        SDT VARCHAR(10) NOT NULL,
	        DIACHI VARCHAR(100) NOT NULL,
	        NGAYVAOLAM DATE NOT NULL,
	        HSLUONG DOUBLE NOT NULL,
	        CONSTRAINT PK_HLV PRIMARY KEY(MAHLV),
	        CONSTRAINT CK_GT_HLV CHECK(GIOITINH IN('F', 'M')),
	        CONSTRAINT CK_CMND_HLV CHECK(LENGTH(CMND) >= 9)
         */

        private string maHLV;
        public string MaHLV
        {
            get { return maHLV; } 
            set {  maHLV = value; } 
        }

        private string tenHLV;
        public string TenHLV
        {
            get { return tenHLV; } 
            set {  tenHLV = value; } 
        }

        private DateTime ngaySinh;
        public DateTime NgaySinh
        {
            get { return ngaySinh; } 
            set {  ngaySinh = value; } 
        }

        private string gioiTinh;
        public string GioiTinh
        {
            get { return gioiTinh; }
            set {  gioiTinh = value; }
        }

        private string cmnd;
        public string CMND
        {
            get { return cmnd; }
            set {  cmnd = value; }
        }

        private string sdt;
        public string SDT
        {
            get { return sdt; }
            set {  sdt = value; }
        }

        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set {  diaChi = value; }
        }

        private DateTime ngayVaoLam;
        public DateTime NgayVaoLam
        {
            get { return ngayVaoLam; }
            set {  ngayVaoLam = value; }
        }
   
        private double hsLuong;
        public double HsLuong
        {
            get { return hsLuong; }
            set {  hsLuong = value; }
        }
    }
}