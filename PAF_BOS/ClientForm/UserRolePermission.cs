using AQDBFramwork.Messageboxes;
using Student_Management_System.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PAF_BOS.AdminForms
{
    public partial class UserRolePermission : DevComponents.DotNetBar.Office2007Form
    {

        public UserRolePermission()
        {
            InitializeComponent();
        }

        private void UserRolePermission_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Application.DoEvents();

            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DtRoles = MainClass.MngPAFBOS.GetRoles(out Status, out StatusDetails);
                if (Status)
                {
                    ListData.AutoSuggession_With_ComboBox(DtRoles, 1, cbRoles, "RoleID", "Role");
                    FillGridViewAllForms();
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex.Message);
            }
        }

        private void FillGridViewAllForms()
        {
            try
            {
                bool Status = false;
                string StatusDetails = null;
                DataTable DtAllForms = MainClass.MngPAFBOS.GetForms(out Status, out StatusDetails);
                gdvAllForms.Rows.Clear();
                if (Status)
                {
                    foreach (DataRow row in DtAllForms.Rows)
                    {
                        gdvAllForms.Rows.Add(false, row["FormID"].ToString(), row["Form Name"].ToString(), row["Detail"].ToString());
                    }
                }
                else
                    JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails);
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex.Message);
            }
        }

        private void FillGridViewAllFormsRemove()
        {
            try
            {
                FillGridViewAllForms();
                foreach (DataGridViewRow R in dataGridViewGrantedPermissions.Rows)
                {
                    foreach (DataGridViewRow RR in gdvAllForms.Rows)
                    {
                        if (RR.Cells["FormID"].Value.ToString() == R.Cells["FormIDG"].Value.ToString())
                        {
                            gdvAllForms.Rows.Remove(RR);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex.Message);
            }
        }
         
        private void checkBoxALL_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gdvAllForms.Rows)
            {
                row.Cells[0].Value = checkBoxALL.Checked;
            }
        }

        private void checkBoxALLG_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewGrantedPermissions.Rows)
            {
                row.Cells[0].Value = checkBoxALLG.Checked;
            }
        }

        private void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoles.SelectedValue == null || cbRoles.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            FillGridViewAssignedForms();
        }

        private void FillGridViewAssignedForms()
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable AssignedRolesDT = new DataTable();
                AssignedRolesDT = MainClass.MngPAFBOS.GetAssignForms(Convert.ToInt32(cbRoles.SelectedValue), out Status, out StatusDetails);
                if (Status)
                {
                    dataGridViewGrantedPermissions.Rows.Clear();
                    foreach (DataRow row in AssignedRolesDT.Rows)
                    {
                        dataGridViewGrantedPermissions.Rows.Add(false, row["Form_ID"].ToString(), row["Form Name"].ToString(), row["Detail"].ToString());
                    }

                    FillGridViewAllFormsRemove();
                }
                else
                    JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails);
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex.Message);
            }
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if ((Convert.ToInt32(cbRoles.SelectedValue) == 0) || cbRoles.Text == "-- Select Role --")
                {
                    JIMessageBox.ShowInformationMessage("Please Select Role \nThank You");
                }
                else
                {
                    int RoleID = Convert.ToInt32(cbRoles.SelectedValue.ToString());

                    foreach (DataGridViewRow row in gdvAllForms.Rows)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            MainClass.MngPAFBOS.InsertRolesPermission(int.Parse(row.Cells["FormID"].Value.ToString()), RoleID, out Status, out StatusDetails);
                            if (Status == false)
                            {
                                MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                    if (Status)
                    {
                        JIMessageBox.ShowInformationMessage("Roles Assign Successfully \n Thank You");
                        FillGridViewAssignedForms();

                        #region DisableForms
                        Mainfrm obj = new Mainfrm();
                        obj.udf_FormsButtonDisable();
                        Application.DoEvents();
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails);
            }
        }

        private void btnRemovePermission_Click(object sender, EventArgs e)
        {
            try
            {
                bool Status = false;
                string StatusDetails = null;

                if ((Convert.ToInt32(cbRoles.SelectedValue) == 0) || cbRoles.Text == "-- Select Role --")
                {
                    JIMessageBox.ShowInformationMessage("Please Select Role \nThank You");
                }
                else
                {
                    int RoleID = Convert.ToInt32(cbRoles.SelectedValue.ToString());
                    foreach (DataGridViewRow row in dataGridViewGrantedPermissions.Rows)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            MainClass.MngPAFBOS.RemoveRolesPermission(int.Parse(row.Cells["FormIDG"].Value.ToString()), RoleID, out Status, out StatusDetails);
                            if (Status == false)
                            {
                                MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                    if (Status)
                    {
                        JIMessageBox.ShowInformationMessage("Roles Remove Successfully \n Thank You");
                        FillGridViewAssignedForms();
                        #region DisableForms
                        Mainfrm obj = new Mainfrm();
                        obj.udf_FormsButtonDisable();
                        Application.DoEvents();
                        #endregion
                    }
                }

            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex);
            }
        }

        private void dataGridViewGrantedPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
