using Microsoft.Reporting.WinForms;
using PAF_BOS;
using System; 
using System.Data; 
using System.Windows.Forms;

namespace ClientForm
{
    public partial class SingleCadetAttendancefrm : DevComponents.DotNetBar.Office2007Form
    {
        public SingleCadetAttendancefrm()
        {
            InitializeComponent();
        } 
        private void SingleCadetAttendancefrm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            try
            {
               FillClientComboCadets();
                // FromDate.Value = DateTime.Now;
                //ToDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.reportViewer02.RefreshReport();
        }
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (comboBoxCadet.SelectedValue == null)
                    return;

                int CadetID = int.Parse(comboBoxCadet.SelectedValue.ToString());
                DataTable dt = MainClass.MngPAFBOS.usp_GetCadetAttendanceReportByCadetID(CadetID, out Status, out StatusDetails);
                if (Status)
                {
                    reportViewer02.LocalReport.DataSources.Clear();
                    reportViewer02.LocalReport.ReportPath = "Reports/SingleCadetReportAttandance.rdlc";
                    ReportDataSource Rds = new ReportDataSource();
                    Rds.Name = "DataSet1";
                    Rds.Value = dt;
                    reportViewer02.LocalReport.DataSources.Add(Rds);
                    reportViewer02.RefreshReport();
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
                dt = MainClass.MngPAFBOS.GetCadetIdAndPakNo();
                DataRow TopItem = dt.NewRow();
                TopItem["CadetID"] = 0;
                TopItem["PAKNumber"] = "All";
                dt.Rows.InsertAt(TopItem, 0); 

                comboBoxCadet.DataSource = dt;
                comboBoxCadet.ValueMember = "CadetID";
                comboBoxCadet.DisplayMember = "PAKNumber";
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    }
}
