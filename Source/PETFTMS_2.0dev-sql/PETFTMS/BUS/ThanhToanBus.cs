using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PETFTMS.DAT;
using PETFTMS.INF;

namespace PETFTMS.BUS
{
    class ThanhToanBus
    {
        KhoaHocData data = new KhoaHocData();
        ThanhToanData thtData = new ThanhToanData();
        HuanLuyenVienData hlvData = new HuanLuyenVienData();
        PetData petData = new PetData();

        public void LocTheoTenKhoa(DataGridView dGV, string tenKhoa)
        {
            dGV.DataSource = data.DanhSach(tenKhoa);
        }

        public void LocTheoMaKhoa(DataGridView dGV, string maKhoa)
        {
            dGV.DataSource = data.DanhSach_Ma(maKhoa);
        }

        public void LocTheoKhachHang(DataGridView dGV,
                                     TextBox txtMaKhach,
                                     TextBox txtTenKhach,
                                     TextBox txtCMND,
                                     TextBox txtSDT,
                                     DateTimePicker dtpNgaySinh)
        {
            dGV.DataSource = data.DanhSach_Khach(txtMaKhach.Text, txtTenKhach.Text, txtCMND.Text, txtSDT.Text, dtpNgaySinh.Value.ToString("yyyy-MM-dd"));
        }

        public void LocTheoPet(DataGridView dGV, ComboBox cboMaPet, TextBox txtTenPet)
        {
            dGV.DataSource = data.DanhSach_Pet(cboMaPet.Text, txtTenPet.Text);
        }

        public void HienThiVaoDGV(DataGridView dGV)
        {
            dGV.DataSource = data.DanhSach();
        }

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaKhoa,
                                  TextBox txtTenKhoa,
                                  ComboBox cboLoai,
                                  DateTimePicker dtpNgayBD,
                                  TextBox txtThoiLuong,
                                  TextBox txtDonGia,
                                  ComboBox cboHLV,
                                  ComboBox cboPet,
                                  string tuKhoa)
        {
            BindingSource bS = new BindingSource();

            if (tuKhoa == "")
                bS.DataSource = data.DanhSach();
            else
                bS.DataSource = data.DanhSach(tuKhoa);

            txtMaKhoa.DataBindings.Clear();
            txtMaKhoa.DataBindings.Add("Text", bS, "MAKHOA", false, DataSourceUpdateMode.Never);

            txtTenKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Add("Text", bS, "TENKHOA", false, DataSourceUpdateMode.Never);

            dtpNgayBD.DataBindings.Clear();
            dtpNgayBD.DataBindings.Add("Value", bS, "NGAYBATDAU", false, DataSourceUpdateMode.Never);

            txtThoiLuong.DataBindings.Clear();
            txtThoiLuong.DataBindings.Add("Text", bS, "THOILUONG", false, DataSourceUpdateMode.Never);

            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", bS, "DONGIA", false, DataSourceUpdateMode.Never);

            cboLoai.DataBindings.Clear();
            cboLoai.DataBindings.Add("Text", bS, "LOAI", false, DataSourceUpdateMode.Never);

            cboHLV.DataBindings.Clear();
            cboHLV.DataBindings.Add("SelectedValue", bS, "MAHLV", false, DataSourceUpdateMode.Never);

            cboPet.DataBindings.Clear();
            cboPet.DataBindings.Add("SelectedValue", bS, "MAPET", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboMaKhoa, TextBox txtTenKhoa)
        {
            cboMaKhoa.DataSource = data.DanhSach();
            cboMaKhoa.ValueMember = "MAKHOA";
            cboMaKhoa.DisplayMember = "MAKHOA";
            BindingSource bS = new BindingSource();
            txtTenKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Add("Text", data.DanhSach(), "TENKHOA", false, DataSourceUpdateMode.Never);
        }

        public void HienThiVaoComboBox_Pet(ComboBox cboMaPet, TextBox txtTenPet)
        {
            cboMaPet.DataSource = data.DanhSach();
            cboMaPet.DisplayMember = "MAPET";
            cboMaPet.ValueMember = "MAPET";
            BindingSource bS = new BindingSource();
            txtTenPet.DataBindings.Clear();
            txtTenPet.DataBindings.Add("Text", data.DanhSach(), "TENPET", false, DataSourceUpdateMode.Never);
        }

        public void HienThiVaoComboBox(ComboBox cboHLV, ComboBox cboPet)
        {
            cboHLV.DataSource = hlvData.DanhSach();
            cboHLV.ValueMember = "MAHLV";
            cboHLV.DisplayMember = "TENHLV";

            cboPet.DataSource = petData.DanhSach();
            cboPet.ValueMember = "MAPET";
            cboPet.DisplayMember = "TENPET";
        }

        public object getDataSourceFromList(List<string> lstMaKhoa)
        {
            return thtData.DanhSach(lstMaKhoa);
        }
    }
}
