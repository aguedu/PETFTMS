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
    public partial class frmPet : Form
    {
        private bool isThem = false;
        private string maPet = ""; // Mã thú cưng viên cũ
        PetBus petBus = new PetBus();

        public frmPet()
        {
            InitializeComponent();
        }

        private void frmPet_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dGV.AutoGenerateColumns = false;
            petBus.HienThiVaoComboBox(cboGiong, cboKhach);
            petBus.HienThiVaoDGV(bN, dGV, txtMaPet, txtTenPet, dtpNgaySinh, chkGioiTinh, txtMau, txtCanNang, txtChieuCao, cboGiong, cboKhach, "");
        }

        public void BatTat(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;
            txtMaPet.Enabled = giaTri;
            txtTenPet.Enabled = giaTri;
            chkGioiTinh.Enabled = giaTri;
            dtpNgaySinh.Enabled = giaTri;
            txtMau.Enabled = giaTri;
            txtCanNang.Enabled = giaTri;
            txtChieuCao.Enabled = giaTri;
            cboGiong.Enabled = giaTri;
            cboKhach.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaPet.Text = "";
            txtTenPet.Text = "";
            chkGioiTinh.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            txtMau.Text = "";
            txtChieuCao.Text = "";
            txtCanNang.Text = "";
            txtMaPet.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maPet = txtMaPet.Text;
            // maNV = dGV.Rows[dGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtTenPet.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thú cưng " + txtTenPet.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                PetInfo info = new PetInfo();
                info.MaPet = txtMaPet.Text;
                petBus.Xoa(info);
            }

            // Tải lại lưới
            frmPet_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaPet.Text = "";
            txtTenPet.Text = "";
            chkGioiTinh.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            txtMau.Text = "";
            txtChieuCao.Text = "";
            txtCanNang.Text = "";
            BatTat(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPet.Text.Trim() == "")
                MessageBox.Show("Mã thú cưng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMaPet.Text.Length > 5)
                MessageBox.Show("Mã thú cưng không vượt quá 5 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenPet.Text.Trim() == "")
                MessageBox.Show("Tên thú cưng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenPet.Text.Length > 50)
                MessageBox.Show("Tên thú cưng không vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMau.Text.Trim() == "")
                MessageBox.Show("Màu sắc lông thú cưng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtMau.Text.Length > 10)
                MessageBox.Show("Màu sắc lông thú cưng không vượt quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtChieuCao.Text.Trim() == "")
                MessageBox.Show("Chiều cao không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtCanNang.Text.Trim() == "")
                MessageBox.Show("Cân nặng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboGiong.Text.Trim() == "")
                MessageBox.Show("Chưa chọn giống loài!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboKhach.Text.Trim() == "")
                MessageBox.Show("Chưa chọn thân chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PetInfo info = new PetInfo();
                info.MaPet = txtMaPet.Text.Trim();
                info.TenPet = txtTenPet.Text.Trim();
                info.NgaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                info.GioiTinh = chkGioiTinh.Checked ? "F" : "M";
                info.Mau = txtMau.Text.Trim();
                info.ChieuCao = double.Parse(txtChieuCao.Text.Trim());
                info.CanNang = double.Parse(txtCanNang.Text.Trim());
                info.Giong.MaGiong = cboGiong.SelectedValue.ToString();
                info.Khach.MaKhach = cboKhach.SelectedValue.ToString();

                if (isThem)
                    petBus.Them(info);
                else
                    petBus.Sua(info, maPet);

                // Tải lại lưới
                frmPet_Load(sender, e);
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
                    e.Value = "Cái";
                else
                    e.Value = "Đực";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            petBus.HienThiVaoDGV(bN, dGV, txtMaPet, txtTenPet, dtpNgaySinh, chkGioiTinh, txtMau, txtCanNang, txtChieuCao, cboGiong, cboKhach, txtTuKhoa.Text);
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
                    PetBus petBus = new PetBus();
                    PetInfo pet = new PetInfo();
                    pet.MaPet = sheet.Cells[cellRowIndex, 1].Value;
                    pet.TenPet = sheet.Cells[cellRowIndex, 2].Value;
                    pet.NgaySinh = String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 3].Value);
                    pet.Mau = sheet.Cells[cellRowIndex, 4].Value.ToString();
                    pet.GioiTinh = sheet.Cells[cellRowIndex, 5].Value;
                    pet.CanNang = sheet.Cells[cellRowIndex, 6].Value;
                    pet.ChieuCao = sheet.Cells[cellRowIndex, 7].Value;
                    pet.Giong.MaGiong = sheet.Cells[cellRowIndex, 8 + 2].Value.ToString();
                    pet.Khach.MaKhach = sheet.Cells[cellRowIndex, 9 + 2].Value.ToString();
                    petBus.Them(pet);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmPet_Load(sender, e);
                MessageBox.Show("Đã nhập thành công dữ liệu từ tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSPet";

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
                MessageBox.Show("Danh sách đã được xuất ra tập tin Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmPet_Load(sender, e);
        }
    }
}