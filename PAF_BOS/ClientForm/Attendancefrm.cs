using Microsoft.Reporting.WinForms;
using PAF_BOS;
using System; 
using System.Data; 
using System.Windows.Forms;

namespace AttendanceSystem.Reports
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
                FillClientComboCadets(); 
                FromDate.Value = DateTime.Now;
                ToDate.Value = DateTime.Now; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            DisplayReport();
        }

        private void DisplayReport()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (comboBoxCadet.SelectedValue == null)
                    return;

                int CadetID = int.Parse(comboBoxCadet.SelectedValue.ToString());
                DataTable dt = MainClass.MngPAFBOS.GetAttendanceReport(CadetID, FromDate.Value, ToDate.Value, out Status, out StatusDetails);
                if (Status)
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.ReportPath = "Reports/ReportAttandance.rdlc";
                    ReportDataSource Rds = new ReportDataSource();
                    Rds.Name = "AttendanceReport";
                    Rds.Value = dt;
                    reportViewer1.LocalReport.DataSources.Add(Rds);
                    reportViewer1.RefreshReport();
                }
                else
                    MessageBox.Show(StatusDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboCadets()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = MainClass.MngPAFBOS.GetCadetIdAndName();
                DataRow TopItem = dt.NewRow();
                TopItem["CadetID"] = 0;
                TopItem["CadetName"] = "All";
                dt.Rows.InsertAt(TopItem, 0); 

                comboBoxCadet.DataSource = dt;
                comboBoxCadet.ValueMember = "CadetID";
                comboBoxCadet.DisplayMember = "CadetName";
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
    }
}
