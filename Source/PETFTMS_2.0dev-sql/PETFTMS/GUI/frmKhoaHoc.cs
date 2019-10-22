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
    public partial class frmKhoaHoc : Form
    {
        private bool isThem = false;
        private string maKhoa = ""; // Mã khóa học cũ
        KhoaHocBus petBus = new KhoaHocBus();

        public frmKhoaHoc()
        {
            InitializeComponent();
        }

        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dGV.AutoGenerateColumns = false;
            petBus.HienThiVaoComboBox(cboHLV, cboPet);
            petBus.HienThiVaoDGV(bN, dGV, txtMaKhoa, txtTenKhoa, cboLoai, dtpNgayBD, txtThoiLuong, txtDonGia, cboHLV, cboPet, "");
        }

        public void BatTat(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;
            txtMaKhoa.Enabled = giaTri;
            txtTenKhoa.Enabled = giaTri;
            cboLoai.Enabled = giaTri;
            dtpNgayBD.Enabled = giaTri;
            txtDonGia.Enabled = giaTri;
            txtThoiLuong.Enabled = giaTri;
            cboHLV.Enabled = giaTri;
            cboPet.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            cboLoai.SelectedIndex = 0;
            dtpNgayBD.Value = DateTime.Now;
            txtDonGia.Text = "";
            txtThoiLuong.Text = "";
            txtMaKhoa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maKhoa = txtMaKhoa.Text;
            // maNV = dGV.Rows[dGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtTenKhoa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khóa học " + txtTenKhoa.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                KhoaHocInfo info = new KhoaHocInfo();
                info.MaKhoa = txtMaKhoa.Text;
                petBus.Xoa(info);
            }

            // Tải lại lưới
            frmKhoaHoc_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            cboLoai.SelectedIndex = 0;
            dtpNgayBD.Value = DateTime.Now;
            txtDonGia.Text = "";
            txtThoiLuong.Text = "";
            BatTat(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text.Trim() == "")
                MessageBox.Show("Mã khóa học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMaKhoa.Text.Length > 8)
                MessageBox.Show("Mã khóa học không vượt quá 8 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenKhoa.Text.Trim() == "")
                MessageBox.Show("Tên khóa học không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenKhoa.Text.Length > 100)
                MessageBox.Show("Tên khóa học không vượt quá 100 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboLoai.Text.Trim() == "")
                MessageBox.Show("Chưa chọn loại khóa học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboLoai.Text.Length > 20)
                MessageBox.Show("Loại khóa học không vượt quá 20 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDonGia.Text.Trim() == "")
                MessageBox.Show("Đơn giá không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtThoiLuong.Text.Trim() == "")
                MessageBox.Show("Thời lượng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboHLV.Text.Trim() == "")
                MessageBox.Show("Chưa chọn huấn luyện viên phụ trách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboPet.Text.Trim() == "")
                MessageBox.Show("Chưa chọn học viên Pet!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                KhoaHocInfo info = new KhoaHocInfo();
                info.MaKhoa = txtMaKhoa.Text.Trim();
                info.TenKhoa = txtTenKhoa.Text.Trim();
                info.NgayBD = dtpNgayBD.Value;
                info.Loai = cboLoai.Text;
                info.ThoiLuong = double.Parse(txtThoiLuong.Text.Trim());
                info.DonGia = double.Parse(txtDonGia.Text.Trim());
                info.HLV.MaHLV = cboHLV.SelectedValue.ToString();
                info.Pet.MaPet = cboPet.SelectedValue.ToString();
                if (isThem)
                    petBus.Them(info);
                else
                    petBus.Sua(info, maKhoa);

                // Tải lại lưới
                frmKhoaHoc_Load(sender, e);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            petBus.HienThiVaoDGV(bN, dGV, txtMaKhoa, txtTenKhoa, cboLoai, dtpNgayBD, txtThoiLuong, txtDonGia, cboHLV, cboPet, txtTuKhoa.Text);
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
                    KhoaHocBus petBus = new KhoaHocBus();
                    KhoaHocInfo pet = new KhoaHocInfo();
                    pet.MaKhoa = sheet.Cells[cellRowIndex, 1].Value;
                    pet.TenKhoa = sheet.Cells[cellRowIndex, 2].Value;
                    pet.NgayBD = String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 3].Value);
                    pet.ThoiLuong = sheet.Cells[cellRowIndex, 4].Value;
                    pet.Loai = sheet.Cells[cellRowIndex, 5].Value.ToString();
                    pet.DonGia = sheet.Cells[cellRowIndex, 6].Value;
                    pet.HLV.MaHLV = sheet.Cells[cellRowIndex, 7 + 2].Value.ToString();
                    pet.Pet.MaPet = sheet.Cells[cellRowIndex, 8 + 2].Value.ToString();
                    petBus.Them(pet);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmKhoaHoc_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSKhoaHoc";

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
            frmKhoaHoc_Load(sender, e);
        }
    }
}