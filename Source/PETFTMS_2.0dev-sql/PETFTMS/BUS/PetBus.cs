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
    class PetBus
    {
        PetData data = new PetData();
        GiongData giongData = new GiongData();
        KhachHangData khachData = new KhachHangData();

        public void HienThiVaoDGV(BindingNavigator bN, 
                                  DataGridView dGV, 
                                  TextBox txtMaPet, 
                                  TextBox txtTenPet,
                                  DateTimePicker dtpNgaySinh,
                                  CheckBox chkGioiTinh,
                                  TextBox txtMau,
                                  TextBox txtCanNang,
                                  TextBox txtChieuCao,
                                  ComboBox cboGiong,
                                  ComboBox cboKhach,
                                  string tuKhoa)
        {
            BindingSource bS = new BindingSource();
            
            if(tuKhoa == "")
                bS.DataSource = data.DanhSach();
            else
                bS.DataSource = data.DanhSach(tuKhoa);

            txtMaPet.DataBindings.Clear();
            txtMaPet.DataBindings.Add("Text", bS, "MAPET", false, DataSourceUpdateMode.Never);

            txtTenPet.DataBindings.Clear();
            txtTenPet.DataBindings.Add("Text", bS, "TENPET", false, DataSourceUpdateMode.Never);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", bS, "NGAYSINH", false, DataSourceUpdateMode.Never);

            txtMau.DataBindings.Clear();
            txtMau.DataBindings.Add("Text", bS, "MAU", false, DataSourceUpdateMode.Never);

            chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "GIOITINH", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "F";
            };
            chkGioiTinh.DataBindings.Add(gt);

            txtCanNang.DataBindings.Clear();
            txtCanNang.DataBindings.Add("Text", bS, "CANNANG", false, DataSourceUpdateMode.Never);

            txtChieuCao.DataBindings.Clear();
            txtChieuCao.DataBindings.Add("Text", bS, "CHIEUCAO", false, DataSourceUpdateMode.Never);

            cboGiong.DataBindings.Clear();
            cboGiong.DataBindings.Add("SelectedValue", bS, "MAGIONG", false, DataSourceUpdateMode.Never);

            cboKhach.DataBindings.Clear();
            cboKhach.DataBindings.Add("SelectedValue", bS, "MAKHACH", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboGiong, ComboBox cboKhach)
        {
            cboGiong.DataSource = giongData.DanhSach();
            cboGiong.ValueMember = "MAGIONG";
            cboGiong.DisplayMember = "TENGIONG";

            cboKhach.DataSource = khachData.DanhSach();
            cboKhach.ValueMember = "MAKHACH";
            cboKhach.DisplayMember = "TENKHACH";
        }

        public void Them(PetInfo info)
        {
            data.Them(info);
        }

        public void Sua(PetInfo info, string maPet)
        {
            data.Sua(info, maPet);
        }

        public void Xoa(PetInfo info)
        {
            data.Xoa(info);
        }
    }
}