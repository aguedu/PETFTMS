using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PETFTMS.BUS;
using PETFTMS.INF;

namespace PETFTMS.GUI
{
    public partial class frmTaiKhoan : Form
    {
        private bool isThem = false;
        private TaiKhoanBus tkBus = new TaiKhoanBus();

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dGV.AutoGenerateColumns = false;
            tkBus.HienThiVaoDGV(dGV, bN, txtTenDangNhap, txtTenNV, cboQuyenHan, txtMatKhau);
        }

        private void BatTat(bool giaTri)
        {
            txtTenDangNhap.Enabled = giaTri;
            txtTenNV.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtTenDangNhap.Text = "";
            txtTenNV.Text = "";
            cboQuyenHan.Text = "";
            txtMatKhau.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản " + txtTenDangNhap.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                TaiKhoanInfo info = new TaiKhoanInfo();
                info.ID = Convert.ToInt32(dGV.CurrentRow.Cells[0].Value.ToString());
                tkBus.Xoa(info);
            }

            // Tải lại lưới
            frmTaiKhoan_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() == "")
                MessageBox.Show("Chưa chọn nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenNV.Text.Trim() == "")
                MessageBox.Show("Tên nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cboQuyenHan.Text == "")
                MessageBox.Show("Chưa chọn quyền hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMatKhau.Text == "")
                MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                TaiKhoanInfo tk = new TaiKhoanInfo();
                tk.TenDangNhap = txtTenDangNhap.Text.Trim();
                tk.TenNV = txtTenNV.Text.Trim();
                tk.MatKhau = txtMatKhau.Text;
                tk.Quyen = cboQuyenHan.SelectedIndex;

                if (isThem)
                    tkBus.Them(tk);
                else
                {
                    tk.ID = Convert.ToInt32(dGV.CurrentRow.Cells[0].Value.ToString());
                    tkBus.Sua(tk);
                }

                // Tải lại lưới
                frmTaiKhoan_Load(sender, e);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmTaiKhoan_Load(sender, e);
        }

        private void dataGridViewTK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(dGV.Columns[e.ColumnIndex].Name == "colMatKhau")
            {
                e.Value = "••••••";
            }

            if (dGV.Columns[e.ColumnIndex].Name == "colQuyenHan")
            {
                if (e.Value.ToString() == "0")
                    e.Value = "Quản lý";
                else
                    e.Value = "Nhân viên";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
            txtTenNV.Text = "";
            cboQuyenHan.Text = "";
            txtMatKhau.Text = "";
            BatTat(false);
        }
    }
}