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

        private void Attendancefrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Attendancefrm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClientComboClients();
                FillClientComboUsers();
                FromDateTime.Value = DateTime.Now;
                ToDateTime.Value = DateTime.Now;
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
            try
            {
                if (comboBoxUsers.SelectedValue == null)
                    return;

                int ClientID = (int)comboBoxClient.SelectedValue;
                int UserID = (int)comboBoxUsers.SelectedValue;

                DataTable dt = new DataTable();

                dt = MainClass.GetClientUsersAttendanceByClientIDReport(ClientID, UserID, FromDateTime.Value, ToDateTime.Value);


                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = "Reports/AttendancefrmReport.rdlc";
                ReportDataSource Rds = new ReportDataSource();
                Rds.Name = "UserAttendance";
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
                    TopItem["ClientName"] = "-- Select Client --";
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


        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (CheckClientCombo())
                {
                    FillClientComboUsers();
                }
                else if (comboBoxClient.Text == "-- Select Client --")
                {
                    DataTable dt = new DataTable();
                    comboBoxUsers.DataSource = dt;
                    comboBoxUsers.DisplayMember = "";
                    comboBoxUsers.ValueMember = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboUsers()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    if (CheckClientCombo())
                    {
                        DataTable dt = new DataTable();

                        dt = MainClass.GetUsersByClientID((int)comboBoxClient.SelectedValue);


                        DataRow TopItem = dt.NewRow();
                        TopItem["UserID"] = 0;
                        TopItem["UserName"] = "-- All Users --";
                        dt.Rows.InsertAt(TopItem, 0);

                        comboBoxUsers.DataSource = dt;
                        comboBoxUsers.DisplayMember = "UserName";
                        comboBoxUsers.ValueMember = "UserID";
                    }
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetUsersByClientID(MainClass.UserClientID);


                    DataRow TopItem = dt.NewRow();
                    TopItem["UserID"] = 0;
                    TopItem["UserName"] = "-- All Users --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxUsers.DataSource = dt;
                    comboBoxUsers.DisplayMember = "UserName";
                    comboBoxUsers.ValueMember = "UserID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckClientCombo()
        {
            if (comboBoxClient.Text == "System.Data.DataRowView")
                return false;
            else if (comboBoxClient.SelectedValue.ToString() == "System.Data.DataRowView")
                return false;
            if (comboBoxClient.Text == "-- Select Client --")
                return false;
            else
                return true;
        }
    }
}