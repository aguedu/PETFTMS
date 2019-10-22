using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PETFTMS.BUS;
using PETFTMS.INF;

namespace PETFTMS.GUI
{
    public partial class frmGiong : Form
    {
        private bool isThem = false;
        private GiongBus giongBus = new GiongBus();
        private string maGiong;

        public frmGiong()
        {
            InitializeComponent();
        }

        private void frmGiong_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dGV.AutoGenerateColumns = false;
            giongBus.HienThiVaoDGV(dGV, bN, txtMaGiong, txtTenGiong, txtCaoTB, txtNangTB);
        }

        private void BatTat(bool giaTri)
        {
            txtMaGiong.Enabled = giaTri;
            txtTenGiong.Enabled = giaTri;
            txtCaoTB.Enabled = giaTri;
            txtNangTB.Enabled = giaTri;
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaGiong.Text = "";
            txtTenGiong.Text = "";
            txtCaoTB.Text = "";
            txtNangTB.Text = "";
            txtMaGiong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maGiong = txtMaGiong.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa giống " + txtTenGiong.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GiongInfo info = new GiongInfo();
                info.MaGiong = dGV.CurrentRow.Cells[0].Value.ToString();
                giongBus.Xoa(info);
            }

            // Tải lại lưới
            frmGiong_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaGiong.Text.Trim() == "")
                MessageBox.Show("Mã giống không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenGiong.Text.Trim() == "")
                MessageBox.Show("Tên giống không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                GiongInfo giong = new GiongInfo();
                giong.MaGiong = txtMaGiong.Text.Trim();
                giong.TenGiong = txtTenGiong.Text.Trim();
                giong.CaoTB = (txtCaoTB.Text.Trim() != "") ? double.Parse(txtCaoTB.Text.Trim()) : 0;
                giong.NangTB = (txtNangTB.Text.Trim() != "") ? double.Parse(txtNangTB.Text.Trim()) : 0;

                if (isThem)
                    giongBus.Them(giong);
                else
                {
                    giong.MaGiong = dGV.CurrentRow.Cells[0].Value.ToString();
                    giongBus.Sua(giong, maGiong);
                }

                // Tải lại lưới
                frmGiong_Load(sender, e);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmGiong_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaGiong.Text = "";
            txtTenGiong.Text = "";
            txtCaoTB.Text = "";
            txtNangTB.Text = "";
            BatTat(false);
        }

        private void dGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dGV.Columns[e.ColumnIndex].Name == "colCaoTB" || dGV.Columns[e.ColumnIndex].Name == "colNangTB")
                if (e.Value.ToString() == "0") e.Value = "Chưa xác định";
        }
    }
}