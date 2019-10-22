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
    class HuanLuyenVienBus
    {
        HuanLuyenVienData data = new HuanLuyenVienData();

        public void HienThiVaoDGV(BindingNavigator bN, 
                                  DataGridView dGV, 
                                  TextBox txtMaHLV, 
                                  TextBox txtTenHLV,
                                  DateTimePicker dtpNgaySinh,
                                  CheckBox chkGioiTinh,
                                  TextBox txtCMND,
                                  TextBox txtSDT,
                                  TextBox txtDiaChi,
                                  DateTimePicker dtpNgayVaoLam,
                                  TextBox txtHsLuong,
                                  string tuKhoa)
        {
            BindingSource bS = new BindingSource();
            
            if(tuKhoa == "")
                bS.DataSource = data.DanhSach();
            else
                bS.DataSource = data.DanhSach(tuKhoa);

            txtMaHLV.DataBindings.Clear();
            txtMaHLV.DataBindings.Add("Text", bS, "MAHLV", false, DataSourceUpdateMode.Never);

            txtTenHLV.DataBindings.Clear();
            txtTenHLV.DataBindings.Add("Text", bS, "TENHLV", false, DataSourceUpdateMode.Never);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", bS, "NGAYSINH", false, DataSourceUpdateMode.Never);

            chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "GIOITINH", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "F";
            };
            chkGioiTinh.DataBindings.Add(gt);

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", bS, "CMND", false, DataSourceUpdateMode.Never);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bS, "SDT", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "DIACHI", false, DataSourceUpdateMode.Never);

            dtpNgayVaoLam.DataBindings.Clear();
            dtpNgayVaoLam.DataBindings.Add("Value", bS, "NGAYVAOLAM", false, DataSourceUpdateMode.Never);

            txtHsLuong.DataBindings.Clear();
            txtHsLuong.DataBindings.Add("Text", bS, "HSLUONG", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboNhanVien)
        {
            cboNhanVien.DataSource = data.DanhSach();
            cboNhanVien.ValueMember = "MAHLV";
            cboNhanVien.DisplayMember = "TENHLV";
        }

        public void Them(HuanLuyenVienInfo info)
        {
            data.Them(info);
        }

        public void Sua(HuanLuyenVienInfo info, string maHLV)
        {
            data.Sua(info, maHLV);
        }

        public void Xoa(HuanLuyenVienInfo info)
        {
            data.Xoa(info);
        }
    }
}