using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PETFTMS.GUI;
using PETFTMS.BUS;

namespace PETFTMS
{
    public partial class frmMain : Form
    {
        frmHuanLuyenVien fHLV = null;
        frmKhachHang fKhach = null;
        frmGiong fGiong = null;
        frmPet fPet = null;
        frmKhoaHoc fKhoa = null;
        frmTaiKhoan fTK = null;
        frmDangNhap fDN = null;
        frmThanhToan fThT = null;
        frmThongTin fTT = new frmThongTin();

        const int Quyen_Khach = -1;
        const int Quyen_QuanLy = 0;
        const int Quyen_NhanVien = 1;

        public static string hoVaTen = "";
        public static int quyenHan = -1;

        public frmMain()
        {
            InitializeComponent();
            Text =  fTT.AssemblyProduct + " " + fTT.AssemblyVersion;
        }

        private void btnHuanLuyenVien_Click(object sender, EventArgs e)
        {
            if (fHLV == null || fHLV.IsDisposed)
            {
                fHLV = new frmHuanLuyenVien();
                fHLV.MdiParent = this;
                fHLV.Show();
            }
            else
                fHLV.Activate();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (fKhach == null || fKhach.IsDisposed)
            {
                fKhach = new frmKhachHang();
                fKhach.MdiParent = this;
                fKhach.Show();
            }
            else
                fKhach.Activate();
        }

        private void btnGiong_Click(object sender, EventArgs e)
        {
            if (fGiong == null || fGiong.IsDisposed)
            {
                fGiong = new frmGiong();
                fGiong.MdiParent = this;
                fGiong.Show();
            }
            else
                fGiong.Activate();
        }

        private void btnPET_Click(object sender, EventArgs e)
        {
            if (fPet == null || fPet.IsDisposed)
            {
                fPet = new frmPet();
                fPet.MdiParent = this;
                fPet.Show();
            }
            else
                fPet.Activate();
        }

        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            if (fKhoa == null || fKhoa.IsDisposed)
            {
                fKhoa = new frmKhoaHoc();
                fKhoa.MdiParent = this;
                fKhoa.Show();
            }
            else
                fKhoa.Activate();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (fTK == null || fTK.IsDisposed)
            {
                fTK = new frmTaiKhoan();
                fTK.MdiParent = this;
                fTK.Show();
            }
            else
                fTK.Activate();
        }

        private void mniHuanLuyenVien_Click(object sender, EventArgs e)
        {
            btnHuanLuyenVien_Click(sender, e);
        }

        private void mniTaiKhoan_Click(object sender, EventArgs e)
        {
            btnTaiKhoan_Click(sender, e);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (fDN == null || fDN.IsDisposed)
                fDN = new frmDangNhap();
            if (fDN.ShowDialog() == DialogResult.OK)
                if (fDN.txtTenDangNhap.Text.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDangNhap_Click(sender, e);
                }
                else if (fDN.txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDangNhap_Click(sender, e);
                }
                else
                {
                    TaiKhoanBus tKBus = new TaiKhoanBus();
                    if (tKBus.DangNhap(fDN.txtTenDangNhap.Text.Trim(), fDN.txtMatKhau.Text))
                    {
                        // Đăng nhập thành công
                        if (quyenHan == Quyen_QuanLy)
                        {
                            setVaiTro(Quyen_QuanLy);
                            fDN.txtMatKhau.Clear();
                        }
                        else if (quyenHan == Quyen_NhanVien)
                        {
                            setVaiTro(Quyen_NhanVien);
                            fDN.txtMatKhau.Clear();
                        }
                        else
                            setVaiTro(Quyen_Khach);
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnDangNhap_Click(sender, e);
                    }
                }
        }

        private void setVaiTro(int vaitro)
        {
            switch (vaitro)
            {
                    // Khách đã được cài đặt dưới default;
                case Quyen_QuanLy:
                    // Đăng nhập vai trò quản lý
                    btnDangNhap.Enabled = false;
                    mniDangNhap.Enabled = false;

                    btnDangXuat.Enabled = true;
                    btnKhachHang.Enabled = true;
                    btnHuanLuyenVien.Enabled = true;
                    btnTaiKhoan.Enabled = true;
                    btnPET.Enabled = true;
                    mniDangXuat.Enabled = true;
                    mniHuanLuyenVien.Enabled = true;
                    mniKhachHang.Enabled = true;
                    mniTaiKhoan.Enabled = true;
                    mniGiong.Enabled = true;
                    mniPET.Enabled = true;
                    mniKhoaHoc.Enabled = true;
                    mniThanhToan.Enabled = true;
                    btnGiong.Enabled = true;
                    btnKhoaHoc.Enabled = true;
                    btnThanhToan.Enabled = true;

                    lblTrangThai.Text = "Quản lý: " + hoVaTen;
                    break;
                case Quyen_NhanVien:
                    // Đăng nhập vai trò nhân viên
                    btnDangNhap.Enabled = false;
                    mniDangNhap.Enabled = false;
                    btnTaiKhoan.Enabled = false;
                    mniTaiKhoan.Enabled = false;

                    btnDangXuat.Enabled = true;
                    btnKhachHang.Enabled = true;
                    btnHuanLuyenVien.Enabled = true;
                    btnPET.Enabled = true;
                    mniDangXuat.Enabled = true;
                    mniHuanLuyenVien.Enabled = true;
                    mniKhachHang.Enabled = true;
                    mniGiong.Enabled = true;
                    mniPET.Enabled = true;
                    mniKhoaHoc.Enabled = true;
                    mniThanhToan.Enabled = true;
                    btnGiong.Enabled = true;
                    btnKhoaHoc.Enabled = true;
                    btnThanhToan.Enabled = true;

                    lblTrangThai.Text = "Nhân viên: " + hoVaTen;
                    break;
                default:
                    // Chưa đăng nhập
                    btnDangNhap.Enabled = true;
                    mniDangNhap.Enabled = true;

                    btnDangXuat.Enabled = false;
                    btnKhachHang.Enabled = false;
                    btnHuanLuyenVien.Enabled = false;
                    btnTaiKhoan.Enabled = false;
                    btnPET.Enabled = false;
                    btnGiong.Enabled = false;
                    btnKhoaHoc.Enabled = false;
                    btnThanhToan.Enabled = false;
                    mniDangXuat.Enabled = false;
                    mniHuanLuyenVien.Enabled = false;
                    mniKhachHang.Enabled = false;
                    mniTaiKhoan.Enabled = false;
                    mniGiong.Enabled = false;
                    mniPET.Enabled = false;
                    mniKhoaHoc.Enabled = false;
                    mniThanhToan.Enabled = false;

                    lblTrangThai.Text = "Vui lòng đăng nhập!";
                    hoVaTen = "";
                    quyenHan = Quyen_Khach;
                    break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            setVaiTro(Quyen_Khach);
            btnDangNhap_Click(sender, e);
        }

        private void mniDangNhap_Click(object sender, EventArgs e)
        {
            btnDangNhap_Click(sender, e);
        }

        private void mniDangXuat_Click(object sender, EventArgs e)
        {
            btnDangXuat_Click(sender, e);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng các form đang làm việc trước khi đăng xuất
            foreach (Form odfrm in MdiChildren)
            {
                odfrm.Close();
            }

            setVaiTro(Quyen_Khach);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            fTT.ShowDialog();
        }

        private void mniThongTin_Click(object sender, EventArgs e)
        {
            btnThongTin_Click(sender, e);
        }

        private void mniThoat_Click(object sender, EventArgs e)
        {
            btnThoat_Click(sender, e);
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            if (File.Exists("HuongDan.chm"))
                System.Diagnostics.Process.Start("HuongDan.chm");
            else
                MessageBox.Show("Không tìm thấy tập tin hướng dẫn sử dụng 'HuongDan.chm'\r\nVui lòng cài đặt lại phần mềm hoặc liên hệ bộ phận hỗ trợ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mniHuongDan_Click(object sender, EventArgs e)
        {
            btnHuongDan_Click(sender, e);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (fThT == null || fThT.IsDisposed)
            {
                fThT = new frmThanhToan();
                fThT.MdiParent = this;
                fThT.Show();
            }
            else
                fThT.Activate();
        }

        private void mniThanhToan_Click(object sender, EventArgs e)
        {
            btnThanhToan_Click(sender, e);
        }
    }
}
