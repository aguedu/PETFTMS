using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PETFTMS.DAT;
using PETFTMS.INF;
using PETFTMS.GUI;

namespace PETFTMS.BUS
{
    class TaiKhoanBus
    {
        TaiKhoanData data = new TaiKhoanData();

        public void HienThiVaoDGV(DataGridView dGV, 
                                  BindingNavigator bN,
                                  TextBox txtTenDangNhap,
                                  TextBox txtTenNV,
                                  ComboBox cboQuyen,
                                  TextBox txtMatKhau)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", bS, "MATKHAU", false, DataSourceUpdateMode.Never);

            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", bS, "TENDANGNHAP", false, DataSourceUpdateMode.Never);

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", bS, "TENNV", false, DataSourceUpdateMode.Never);

            cboQuyen.DataBindings.Clear();
            cboQuyen.DataBindings.Add("SelectedIndex", bS, "QUYEN", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public bool DangNhap(string tenDangNhap, string matKhau)
        {
            var tK = data.ChiTiet(tenDangNhap, matKhau);
            if (tK.Rows.Count > 0)
            {
                frmMain.hoVaTen = tK.Rows[0]["TENNV"].ToString();
                frmMain.quyenHan = int.Parse(tK.Rows[0]["QUYEN"].ToString());
                return true;
            }
            else
                return false;
        }

        public void Them(TaiKhoanInfo info)
        {
            data.Them(info);
        }

        public void Sua(TaiKhoanInfo info)
        {
            data.Sua(info);
        }

        public void Xoa(TaiKhoanInfo info)
        {
            data.Xoa(info);
        }
    }
}
