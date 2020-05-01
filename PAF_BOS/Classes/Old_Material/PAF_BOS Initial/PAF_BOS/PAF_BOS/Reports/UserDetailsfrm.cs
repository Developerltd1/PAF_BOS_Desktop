using Microsoft.Reporting.WinForms;
using System; 
using System.Data; 
using System.Windows.Forms;

namespace PAF_BOS.Reports
{
    public partial class UserDetailsfrm : DevComponents.DotNetBar.Office2007Form
    {
        public UserDetailsfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void UserDetailsfrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void UserDetailsfrm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClientComboClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ClientID = 0;

                if (!MainClass.IsAdmin)
                    ClientID = MainClass.UserClientID;

                if (comboBoxClient.Text == "System.Data.DataRowView")
                    return;
                else
                {
                    if (comboBoxClient.SelectedValue.ToString() == "System.Data.DataRowView")
                    {
                        DisplayReport(ClientID);
                    }
                    else
                    {
                        ClientID = (int)comboBoxClient.SelectedValue;
                        DisplayReport(ClientID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayReport(int clientID)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = MainClass.GetUserDetailsByClientIDReport(clientID);


                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = "Reports/UserDetailsfrmReport.rdlc";
                ReportDataSource Rds = new ReportDataSource();
                Rds.Name = "UserDetails";
                Rds.Value = dt;
                reportViewer1.LocalReport.DataSources.Add(Rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboClients()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetClients();


                    DataRow TopItem = dt.NewRow();
                    TopItem["ClientID"] = 0;
                    TopItem["ClientName"] = "-- ALL Clients --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxClient.DataSource = dt;
                    comboBoxClient.DisplayMember = "ClientName";
                    comboBoxClient.ValueMember = "ClientID";
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetClientByClientID(MainClass.UserClientID);

                    comboBoxClient.DataSource = dt;
                    comboBoxClient.DisplayMember = "ClientName";
                    comboBoxClient.ValueMember = "ClientID";
                    comboBoxClient.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}