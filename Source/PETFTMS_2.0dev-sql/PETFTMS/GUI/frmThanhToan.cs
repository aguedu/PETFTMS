using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PETFTMS.BUS;
using PETFTMS.INF;

namespace PETFTMS.GUI
{
    public partial class frmThanhToan : Form
    {
        ThanhToanBus thanhToanBus = new ThanhToanBus();

        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void btnThanhToan_KhoaHoc_Click(object sender, EventArgs e)
        {
            frmRepThanhToan rpt = new frmRepThanhToan();
            List<string> lstMaKhoa = new List<string>();
            if (dGV.Rows.Count > 0)
            {
                for (int i = 0; i < dGV.Rows.Count; i++)
                {
                    string maKhoa = dGV[0,i].Value.ToString();
                    lstMaKhoa.Add(maKhoa);
                }
                rpt.ViewList(lstMaKhoa);
                rpt.Show();
            }
            else
            {
                MessageBox.Show("Trong danh sách không có khóa học cần thanh toán.\nVui lòng lọc lại danh sách!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            dGV.AutoGenerateColumns = false;
            // Phải hiển thị ComboBox trước khi hiển thị DGV, để không bị lọc theo Mã
            thanhToanBus.HienThiVaoComboBox(cboMaKhoa, txtTenKhoa);
            thanhToanBus.HienThiVaoComboBox_Pet(cboMaPet, txtTenPet);
            thanhToanBus.HienThiVaoDGV(dGV);
            thanhToanBus.HienThiVaoDGV(dGV_Khach);
            thanhToanBus.HienThiVaoDGV(dGV_Pet);
            txtTenKhoa.Focus();
        }

        private void btnLoc_KhoaHoc_Click(object sender, EventArgs e)
        {
            cboMaKhoa.Text = "";
            thanhToanBus.LocTheoTenKhoa(dGV, txtTenKhoa.Text);
        }

        private void cboMaKhoa_TextChanged(object sender, EventArgs e)
        {
            thanhToanBus.LocTheoMaKhoa(dGV, cboMaKhoa.Text);
        }

        private void btnLoc_KhachHang_Click(object sender, EventArgs e)
        {
            thanhToanBus.LocTheoKhachHang(dGV_Khach, txtMaKhach, txtTenKhach, txtCMND, txtSDT, dtpNgaySinh);
        }

        private void btnLoc_Pet_Click(object sender, EventArgs e)
        {
            thanhToanBus.LocTheoPet(dGV_Pet, cboMaPet, txtTenPet);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDong_Khach_Click(object sender, EventArgs e)
        {
            btnDong_Click(sender, e);
        }

        private void btnDong_Pet_Click(object sender, EventArgs e)
        {
            btnDong_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach( DataGridViewRow r in dGV.SelectedRows)
            {
                dGV.Rows.RemoveAt(r.Index);
            }
        }

        private void btnXoa_Khach_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dGV_Khach.SelectedRows)
            {
                dGV_Khach.Rows.RemoveAt(r.Index);
            }
        }

        private void btnXoa_Pet_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dGV_Pet.SelectedRows)
            {
                dGV_Pet.Rows.RemoveAt(r.Index);
            }
        }

        private void btnThanhToan_KhachHang_Click(object sender, EventArgs e)
        {
            frmRepThanhToan rpt = new frmRepThanhToan();
            List<string> lstMaKhoa = new List<string>();
            if (dGV_Khach.Rows.Count > 0)
            {
                for (int i = 0; i < dGV_Khach.Rows.Count; i++)
                {
                    string maKhoa = dGV_Khach[0, i].Value.ToString();
                    lstMaKhoa.Add(maKhoa);
                }
                rpt.ViewList(lstMaKhoa);
                rpt.Show();
            }
            else
            {
                MessageBox.Show("Trong danh sách không có khóa học cần thanh toán.\nVui lòng lọc lại danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Pet_Click(object sender, EventArgs e)
        {
            frmRepThanhToan rpt = new frmRepThanhToan();
            List<string> lstMaKhoa = new List<string>();
            if (dGV_Pet.Rows.Count > 0)
            {
                for (int i = 0; i < dGV_Pet.Rows.Count; i++)
                {
                    string maKhoa = dGV_Pet[0, i].Value.ToString();
                    lstMaKhoa.Add(maKhoa);
                }
                rpt.ViewList(lstMaKhoa);
                rpt.Show();
            }
            else
            {
                MessageBox.Show("Trong danh sách không có khóa học cần thanh toán.\nVui lòng lọc lại danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
