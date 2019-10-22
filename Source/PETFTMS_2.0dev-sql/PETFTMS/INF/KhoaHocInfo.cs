using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETFTMS.INF
{
    class KhoaHocInfo
    {
        /*
            MAKHOA VARCHAR(8) NOT NULL,
	        TENKHOA VARCHAR(4) NOT NULL,
	        LOAI VARCHAR(20) NOT NULL,
            NGAYBATDAU DATE NOT NULL,
	        THOILUONG DOUBLE NOT NULL,
	        DONGIA DOUBLE NOT NULL,
	        MAHLV VARCHAR(5) NOT NULL,
	        MAPET VARCHAR(5) NOT NULL,
	        CONSTRAINT PK_KHOA PRIMARY KEY(MAKHOA),
	        CONSTRAINT FK_KHOA_HLV FOREIGN KEY(MAHLV) REFERENCES PETFTMS.HLV(MAHLV),
	        CONSTRAINT FK_KHOA_PET FOREIGN KEY(MAPET) REFERENCES PETFTMS.PET(MAPET)
        */

        public KhoaHocInfo()
        {
            HLV = new HuanLuyenVienInfo();
            Pet = new PetInfo();
        }

        private string maKhoa;
        public string MaKhoa
        {
            get { return maKhoa; }
            set {  maKhoa = value; }
        }

        private string tenKhoa;
        public string TenKhoa
        {
            get { return tenKhoa; }
            set {  tenKhoa = value; }
        }

        private string loai; // 'The luc' or 'Nghiep vu'
        public string Loai
        {
            get { return loai; }
            set {  loai = value; }
        }

        private DateTime ngayBD;
        public DateTime NgayBD
        {
            get { return ngayBD; }
            set {  ngayBD = value; }
        }

        private double thoiLuong;
        public double ThoiLuong
        {
            get { return thoiLuong; }
            set {  thoiLuong = value; }
        }

        private double donGia;
        public double DonGia
        {
            get { return donGia; }
            set {  donGia = value; }
        }

        private HuanLuyenVienInfo hlv;
        internal HuanLuyenVienInfo HLV
        {
            get { return hlv; }
            set {  hlv = value; }
        }

        private PetInfo pet;
        internal PetInfo Pet
        {
            get { return pet; }
            set {  pet = value; }
        }
    }
}
