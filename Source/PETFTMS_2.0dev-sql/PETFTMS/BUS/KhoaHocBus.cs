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
    class KhoaHocBus
    {
        KhoaHocData data = new KhoaHocData();
        HuanLuyenVienData hlvData = new HuanLuyenVienData();
        PetData petData = new PetData();

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
            
            if(tuKhoa == "")
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

        public void HienThiVaoComboBox(ComboBox cboHLV, ComboBox cboPet)
        {
            cboHLV.DataSource = hlvData.DanhSach();
            cboHLV.ValueMember = "MAHLV";
            cboHLV.DisplayMember = "TENHLV";

            cboPet.DataSource = petData.DanhSach();
            cboPet.ValueMember = "MAPET";
            cboPet.DisplayMember = "TENPET";
        }

        public void Them(KhoaHocInfo info)
        {
            data.Them(info);
        }

        public void Sua(KhoaHocInfo info, string maKhoaHoc)
        {
            data.Sua(info, maKhoaHoc);
        }

        public void Xoa(KhoaHocInfo info)
        {
            data.Xoa(info);
        }
    }
}