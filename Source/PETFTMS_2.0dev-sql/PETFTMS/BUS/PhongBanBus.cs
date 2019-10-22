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
    class PhongBanBus
    {
        PetData data = new PetData();

        public void HienThiVaoDGV(BindingNavigator bN, DataGridView dGV, TextBox txtMaPhong, TextBox txtTenPhong)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaPhong.DataBindings.Clear();
            txtMaPhong.DataBindings.Add("Text", bS, "MAPHONG", false, DataSourceUpdateMode.Never);

            txtTenPhong.DataBindings.Clear();
            txtTenPhong.DataBindings.Add("Text", bS, "TENPHONG", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboPhongBan)
        {
            cboPhongBan.DataSource = data.DanhSach();
            cboPhongBan.ValueMember = "MAPHONG";
            cboPhongBan.DisplayMember = "TENPHONG";
        }

        public void Them(PetInfo info)
        {
            data.Them(info);
        }

        public void Sua(PetInfo info, string maPhong)
        {
            data.Sua(info, maPhong);
        }

        public void Xoa(PetInfo info)
        {
            data.Xoa(info);
        }
    }
}
