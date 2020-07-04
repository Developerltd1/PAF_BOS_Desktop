using AQDBFramwork.Messageboxes;
using Student_Management_System.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class CadetSearchPermissiontfrm : DevComponents.DotNetBar.Office2007Form
    {
        bool Status = false;
        string StatusDetails = null; 
        public CadetSearchPermissiontfrm()
        {
            InitializeComponent();
            
        } 
        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            udm_Combo();
            udf_GridView();
            this.WindowState = FormWindowState.Maximized; 
        }
        private void udf_GridView()
        {

            //Checking Combo Values
            if (cbSQN.SelectedValue == null || cbSQN.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            else if (cbCourse.SelectedValue == null || cbCourse.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            else if (cbTape.SelectedValue == null || cbTape.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            else if (cbSearchPermission.SelectedValue == null || cbSearchPermission.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            //Show All Data
            int UserID = Convert.ToInt32(cbSearchPermission.SelectedValue.ToString());
            DataTable DtCadetsByTapeAndCourseID = MainClass.GetCadetsByTapeAndCourseIDandSQN(UserID,(int)cbCourse.SelectedValue, (int)cbTape.SelectedValue, (int)cbSQN.SelectedValue, out Status, out StatusDetails);
            if (Status)
            {
                gdvSearchCadet.Rows.Clear();
               // gdvSearchCadet.DataSource = DtCadetsByTapeAndCourseID;
                foreach (DataRow r in DtCadetsByTapeAndCourseID.Rows)
                {
                    gdvSearchCadet.Rows.Add(false, 
                        r["CadetID"].ToString(), r["CadetName"].ToString(), r["PAKNumber"].ToString(), r["CNIC"].ToString(), r["SQN"].ToString(), r["TapeName"].ToString(), r["CourseName"].ToString());
                } 
            }
            else
            {
                JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
            }
        } 
        private void udm_Combo()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable DtSeniorOfficer = MainClass.MngPAFBOS.usp_GetSeniorOfficerByUserID(out Status, out StatusDetails);
            DataTable DtCadetCourses = MainClass.MngPAFBOS.GetCadetCourses(out Status, out StatusDetails);
            DataTable DtCadetTapes = MainClass.MngPAFBOS.GetCadetTapes(out Status, out StatusDetails);
            DataTable DtCadetSQN = MainClass.MngPAFBOS.GetCadetSQN(out Status, out StatusDetails);
            if (Status)
            {
                ListData.AutoSuggession_With_ComboBox(DtSeniorOfficer, "FullName", cbSearchPermission, "UserID", "FullName");
                ListData.AutoSuggession_With_ComboBox(DtCadetCourses, "CourseName", cbCourse, "CourseID", "CourseName");
                ListData.AutoSuggession_With_ComboBox(DtCadetTapes, "TapeName", cbTape, "TapeID", "TapeName");
                ListData.AutoSuggession_With_ComboBox(DtCadetSQN, "FullName", cbSQN, "UserID", "FullName");
            }
        }      
        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gdvSearchCadet.Rows)
            {
                if(row.Visible == true)
                row.Cells["SelectCadet"].Value = cbAll.Checked;
            }
        } 
       
        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(cbSearchPermission.SelectedValue) == 0) || cbSearchPermission.Text == "-- Select Officer --")
                {
                    JIMessageBox.ShowInformationMessage("Please Select Officer \nThank You");
                }
                else
                {
                    int UserID = Convert.ToInt32(cbSearchPermission.SelectedValue.ToString()); 
                    foreach (DataGridViewRow row in gdvSearchCadet.Rows)
                    { 
                        if ((bool)row.Cells[0].Value)
                        {
                            MainClass.MngPAFBOS.AddCadetPermission(UserID, int.Parse(row.Cells["CadetID"].Value.ToString()), out Status, out StatusDetails);
                            if (Status == false)
                            {
                                MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                    if (Status)
                    {
                        FillAssignedCadetsGridView();
                        JIMessageBox.ShowInformationMessage("Permission Assigned Sucessfully !"); 
                    }
                    else
                        JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails);
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex.Message);
            }
        } 
        private void ckAssign_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewAllowedCadets.Rows)
            {
                if (row.Visible == true)
                    row.Cells[0].Value = ckAssign.Checked;
            }
        } 
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(cbSearchPermission.SelectedValue) == 0) || cbSearchPermission.Text == "-- Select Officer --")
                {
                    JIMessageBox.ShowInformationMessage("Please Select Officer \nThank You");
                }
                else
                {
                    int OfficerID = Convert.ToInt32(cbSearchPermission.SelectedValue.ToString()); 
                    foreach (DataGridViewRow row in dataGridViewAllowedCadets.Rows)
                    { 
                        if ((bool)row.Cells[0].Value)
                        { 
                            MainClass.MngPAFBOS.RemoveCadetPermission(OfficerID,int.Parse(row.Cells["AllowedCadetID"].Value.ToString()), out Status, out StatusDetails);
                            if (Status == false)
                            { 
                                MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                    if (Status)
                    {
                        FillAssignedCadetsGridView(); 
                        JIMessageBox.ShowInformationMessage("Permission Remove Successfully \n Thank You");
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails + "= " + ex);
            }
        } 
        private void cbTape_SelectedIndexChanged(object sender, EventArgs e)
        {
            udf_GridView();
        } 
        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            udf_GridView();
        } 
        private void cbSQN_SelectedIndexChanged(object sender, EventArgs e)
        {
            udf_GridView();
        }

     
        private void cbSearchPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAssignedCadetsGridView(); 
        }

        private void FillAssignedCadetsGridView()
        {
            if (cbSearchPermission.SelectedValue == null || cbSearchPermission.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable DtRoleAssigntoUser = new DataTable();
                DtRoleAssigntoUser = null;
                DtRoleAssigntoUser = MainClass.MngPAFBOS.GetAssignFormsPermissionToUser(Convert.ToInt32(cbSearchPermission.SelectedValue), out Status, out StatusDetails);
                if (Status)
                {
                    dataGridViewAllowedCadets.Rows.Clear();
                    foreach (DataRow r in DtRoleAssigntoUser.Rows)
                    {
                        dataGridViewAllowedCadets.Rows.Add(false,
                            r["CadetID"].ToString(), r["CadetName"].ToString(), r["PAKNumber"].ToString(), r["CNIC"].ToString(), r["SQN"].ToString(), r["TapeName"].ToString(), r["CourseName"].ToString());
                    } 
                }
                udf_GridView();
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex.Message);
            }
        }

        private void textBoxCNIC_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CNIC", textBoxCNIC.Text);
        }

        private void tbCadetName_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CadetName", tbCadetName.Text);
        }

        private void tbPak_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("PAKNumber", tbPak.Text);
        }

        private void SearchFilter(string Cell, string Criteria)
        {
            foreach (DataGridViewRow row in gdvSearchCadet.Rows)
            {
                if (row.Cells[Cell].Value.ToString().ToLower().Contains(Criteria.ToLower()))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }
    }
}
