using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using PETFTMS.BUS;
using PETFTMS.INF;

namespace PETFTMS.GUI
{
    public partial class frmRepThanhToan : Form
    {
        ThanhToanBus thanhToanBus = new ThanhToanBus();

        public frmRepThanhToan()
        {
            InitializeComponent();
        }

        public void ViewList(List<string> lstMaKhoa)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"Z:\Private\Code\VS\LTQL\PETFTMS\PETFTMS_2.0dev-sql\PETFTMS\CrystalReport1.rpt");
            reportDocument.SetDataSource(thanhToanBus.getDataSourceFromList(lstMaKhoa));
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.RefreshReport();
            // dataGridView1.DataSource = thanhToanBus.getDataSourceFromList(lstMaKhoa);
            // TODO Hiển thị Report theo danh sách Mã khóa học cho trước
            // TODO Thêm ReportViewer, BindingSource và xử lý
            // ReportViewer repView = new ReportViewer();
            // repView.DataSource = thanhToanBus.getDataSourceFromList(lstMaKhoa);
            // repView.RefreshReport();
            // repView.Refresh();
        }
    }
}
