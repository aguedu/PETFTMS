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
    public partial class frmHuanLuyenVien : Form
    {
        private bool isThem = false;
        private string maHLV = ""; // Mã huấn luyện viên cũ
        HuanLuyenVienBus hlvBus = new HuanLuyenVienBus();

        public frmHuanLuyenVien()
        {
            InitializeComponent();
        }

        private void frmHuanLuyenVien_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dGV.AutoGenerateColumns = false;
            hlvBus.HienThiVaoDGV(bN, dGV, txtMaHLV, txtTenHLV, dtpNgaySinh, chkGioiTinh, txtCMND, txtSDT, txtDiaChi, dtpNgayVaoLam, txtHsLuong, "");
        }

        public void BatTat(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;
            txtMaHLV.Enabled = giaTri;
            txtTenHLV.Enabled = giaTri;
            chkGioiTinh.Enabled = giaTri;
            dtpNgaySinh.Enabled = giaTri;
            txtCMND.Enabled = giaTri;
            dtpNgayVaoLam.Enabled = giaTri;
            txtHsLuong.Enabled = giaTri;
            txtSDT.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaHLV.Text = "";
            txtTenHLV.Text = "";
            chkGioiTinh.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
            txtCMND.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtHsLuong.Text = "";
            txtMaHLV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maHLV = txtMaHLV.Text;
            // maNV = dGV.Rows[dGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtTenHLV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa huấn luyện viên " + txtTenHLV.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                HuanLuyenVienInfo info = new HuanLuyenVienInfo();
                info.MaHLV = txtMaHLV.Text;
                hlvBus.Xoa(info);
            }

            // Tải lại lưới
            frmHuanLuyenVien_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaHLV.Text = "";
            txtTenHLV.Text = "";
            chkGioiTinh.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
            txtCMND.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtHsLuong.Text = "";
            BatTat(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHLV.Text.Trim() == "")
                MessageBox.Show("Mã huấn luyện viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMaHLV.Text.Length > 5)
                MessageBox.Show("Mã huấn luyện viên không vượt quá 5 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenHLV.Text.Trim() == "")
                MessageBox.Show("Tên huấn luyện viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenHLV.Text.Length > 50)
                MessageBox.Show("Tên huấn luyện viên không vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtCMND.Text.Trim() == "")
                MessageBox.Show("Số CMND không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtCMND.Text.Length < 9 || txtCMND.Text.Length > 12)
                MessageBox.Show("Số CMND phải từ 9 đến 12 ký tự số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Trim() == "")
                MessageBox.Show("Số điện thoại không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Length > 10)
                MessageBox.Show("Số điện thoại không vượt quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDiaChi.Text.Trim() == "")
                MessageBox.Show("Địa chỉ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDiaChi.Text.Length > 100)
                MessageBox.Show("Địa chỉ không vượt quá 100 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtHsLuong.Text.Trim() == "")
                MessageBox.Show("Hệ số lương không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                HuanLuyenVienInfo info = new HuanLuyenVienInfo();
                info.MaHLV = txtMaHLV.Text.Trim();
                info.TenHLV = txtTenHLV.Text.Trim();
                info.NgaySinh = dtpNgaySinh.Value;
                info.GioiTinh = chkGioiTinh.Checked ? "F" : "M";
                info.CMND = txtCMND.Text.Trim();
                info.SDT = txtSDT.Text.Trim();
                info.DiaChi = txtDiaChi.Text.Trim();
                info.NgayVaoLam = dtpNgayVaoLam.Value;
                info.HsLuong = double.Parse(txtHsLuong.Text.Trim());

                if (isThem)
                    hlvBus.Them(info);
                else
                    hlvBus.Sua(info, maHLV);

                // Tải lại lưới
                frmHuanLuyenVien_Load(sender, e);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dGV.Columns[e.ColumnIndex].Name == "colGioiTinh")
            {
                if ((string)e.Value == "F")
                    e.Value = "Nữ";
                else
                    e.Value = "Nam";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            hlvBus.HienThiVaoDGV(bN, dGV, txtMaHLV, txtTenHLV, dtpNgaySinh, chkGioiTinh, txtCMND, txtSDT, txtDiaChi, dtpNgayVaoLam, txtHsLuong, txtTuKhoa.Text);
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _Application excel = new Microsoft.Office.Interop.Excel.Application();
                _Workbook workbook = excel.Workbooks.Open(file.FileName);
                _Worksheet sheet = workbook.ActiveSheet;

                // Dòng bắt đầu là dòng 2 (trừ tiêu đề)
                int cellRowIndex = 2;
                do
                {
                    HuanLuyenVienBus hlvBus = new HuanLuyenVienBus();
                    HuanLuyenVienInfo hlv = new HuanLuyenVienInfo();
                    hlv.MaHLV = sheet.Cells[cellRowIndex, 1].Value;
                    hlv.TenHLV = sheet.Cells[cellRowIndex, 2].Value;
                    hlv.NgaySinh = String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 3].Value);
                    hlv.CMND = sheet.Cells[cellRowIndex, 4].Value.ToString();
                    hlv.GioiTinh = sheet.Cells[cellRowIndex, 5].Value;
                    hlv.SDT = sheet.Cells[cellRowIndex, 6].Value.ToString();
                    hlv.DiaChi = sheet.Cells[cellRowIndex, 7].Value;
                    hlv.NgayVaoLam = String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 8].Value);
                    hlv.HsLuong = sheet.Cells[cellRowIndex, 9].Value;
                    hlvBus.Them(hlv);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmHuanLuyenVien_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSHuanLuyenVien";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dGV.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dGV.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            int cellRowIndex = 2;
            int cellColIndex = 1;
            for (int d = 0; d < dGV.Rows.Count; d++)
            {
                for (int c = 0; c < dGV.Columns.Count; c++)
                {
                    sheet.Cells[cellRowIndex, cellColIndex] = dGV.Rows[d].Cells[c].Value.ToString();
                    cellColIndex++;
                }
                cellColIndex = 1;
                cellRowIndex++;
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Danh sách đã được xuất ra tập tin Excel!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmHuanLuyenVien_Load(sender, e);
        }
    }
}