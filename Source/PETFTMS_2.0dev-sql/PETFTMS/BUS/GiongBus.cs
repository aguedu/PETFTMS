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
    class GiongBus
    {
        GiongData data = new GiongData();

        public void HienThiVaoDGV(DataGridView dGV, 
                                  BindingNavigator bN,
                                  TextBox txtMaGiong,
                                  TextBox txtTenGiong,
                                  TextBox txtCaoTB,
                                  TextBox txtNangTB)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaGiong.DataBindings.Clear();
            txtMaGiong.DataBindings.Add("Text", bS, "MAGIONG", false, DataSourceUpdateMode.Never);

            txtTenGiong.DataBindings.Clear();
            txtTenGiong.DataBindings.Add("Text", bS, "TENGIONG", false, DataSourceUpdateMode.Never);

            txtCaoTB.DataBindings.Clear();
            txtCaoTB.DataBindings.Add("Text", bS, "CAOTB", false, DataSourceUpdateMode.Never);

            txtNangTB.DataBindings.Clear();
            txtNangTB.DataBindings.Add("Text", bS, "NANGTB", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void Them(GiongInfo info)
        {
            data.Them(info);
        }

        public void Sua(GiongInfo info, string maGiong)
        {
            data.Sua(info, maGiong);
        }

        public void Xoa(GiongInfo info)
        {
            data.Xoa(info);
        }
    }
}
