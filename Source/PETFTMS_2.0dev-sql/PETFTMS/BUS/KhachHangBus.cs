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
    class KhachHangBus
    {
        KhachHangData data = new KhachHangData();

        public void HienThiVaoDGV(BindingNavigator bN, 
                                  DataGridView dGV, 
                                  TextBox txtMaHLV, 
                                  TextBox txtTenHLV,
                                  DateTimePicker dtpNgaySinh,
                                  CheckBox chkGioiTinh,
                                  TextBox txtCMND,
                                  TextBox txtSDT,
                                  TextBox txtDiaChi,
                                  string tuKhoa)
        {
            BindingSource bS = new BindingSource();
            
            if(tuKhoa == "")
                bS.DataSource = data.DanhSach();
            else
                bS.DataSource = data.DanhSach(tuKhoa);

            txtMaHLV.DataBindings.Clear();
            txtMaHLV.DataBindings.Add("Text", bS, "MAKHACH", false, DataSourceUpdateMode.Never);

            txtTenHLV.DataBindings.Clear();
            txtTenHLV.DataBindings.Add("Text", bS, "TENKHACH", false, DataSourceUpdateMode.Never);

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

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboNhanVien)
        {
            cboNhanVien.DataSource = data.DanhSach();
            cboNhanVien.ValueMember = "MAKHACH";
            cboNhanVien.DisplayMember = "TENKHACH";
        }

        public void Them(KhachHangInfo info)
        {
            data.Them(info);
        }

        public void Sua(KhachHangInfo info, string maKhach)
        {
            data.Sua(info, maKhach);
        }

        public void Xoa(KhachHangInfo info)
        {
            data.Xoa(info);
        }
    }
}