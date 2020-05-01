using AQDBFramwork.Messageboxes;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAF_BOS.Reports
{
    public partial class Attendancefrm : DevComponents.DotNetBar.Office2007Form
    {
        public Attendancefrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Attendancefrm_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Application.DoEvents();
                FillCadetCombo();
                DisplayReport(0); // All Cadet Report
                dtFrom.Value = DateTime.Now;
                dtTo.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillCadetCombo()
        {
            try
            {
                cbCadet.DataSource = MainClass.MngPAFBOS.GetCadetIdAndName(); ;
                cbCadet.ValueMember = "CadetID";
                cbCadet.DisplayMember = "CadetName";
                cbCadet.Enabled = false;
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        }
        private bool CheckClientCombo()
        {
            if (cbCadet.Text == "System.Data.DataRowView")
                return false;
            else if (cbCadet.SelectedValue.ToString() == "System.Data.DataRowView")
                return false;
            if (cbCadet.Text == "-- Select Client --")
                return false;
            else
                return true;
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            DisplayReport();
        }
       
        private void DisplayReport(int CadetID)
        {
            bool status = false;
            string statusDetails = null;
            try
            {
                int ClientID = (int)cbCadet.SelectedValue;
                DataTable dt = MainClass.MngPAFBOS.GetAttendanceForReportByCheckINcheckOUT(CadetID, out status, out statusDetails);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = "Reports/ReportAttandance.rdlc";
                ReportDataSource Rds = new ReportDataSource();
                Rds.Name = "usp_GetAttendanceForReportByCheckINcheckOUT";
                Rds.Value = dt;
                reportViewer1.LocalReport.DataSources.Add(Rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //by CadetID
        private void DisplayReport()
        {
            bool status = false;
            string statusDetails = null;
            try
            {
                DataTable dt = MainClass.MngPAFBOS.GetAttendanceForReportByCheckINcheckOUT(int.Parse(cbCadet.SelectedValue.ToString()), dtFrom.Value, dtTo.Value, out status, out statusDetails);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = "Reports/ReportAttandance.rdlc";
                ReportDataSource Rds = new ReportDataSource();
                Rds.Name = "usp_GetAttendanceForReportByCheckINcheckOUT";
                Rds.Value = dt;
                reportViewer1.LocalReport.DataSources.Add(Rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  //by CadetID & FromTo-Date

        private void cbCadet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayReport(int.Parse(cbCadet.SelectedValue.ToString())); //One Cadet Report
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}