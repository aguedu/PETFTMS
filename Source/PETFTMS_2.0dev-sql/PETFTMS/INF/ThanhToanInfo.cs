using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETFTMS.INF
{
    public class ThanhToanInfo
    {
        string maKhoa;
        public string MaKhoa
        {
            get { return maKhoa; }
            set { maKhoa = value; }
        }

        string tenKhoa;
        public string TenKhoa
        {
            get { return tenKhoa; }
            set { tenKhoa = value; }
        }

        string loai;
        public string Loai
        {
            get { return loai; }
            set { loai = value; }
        }

        string tenHocVien;
        public string TenHocVien
        {
            get { return tenHocVien; }
            set { tenHocVien = value; }
        }

        double gia;
        public double Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        string tenKhachHang;
        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }
    }
}
