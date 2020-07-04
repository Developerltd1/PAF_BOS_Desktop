using AQDBFramwork.Messageboxes;
using Student_Management_System.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class UserRegistrationfrm : DevComponents.DotNetBar.Office2007Form
    {
        public UserRegistrationfrm()
        { 
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbFullName.Text))
                {
                    MessageBox.Show("Please Type User Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (string.IsNullOrEmpty(cbDesignation.Text))
                {
                    MessageBox.Show("Please Type Password", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string FullName = tbFullName.Text;
                string Designation = Convert.ToString(cbDesignation.SelectedValue);
                string PakNo = tbPAKNo.Text;
                string UserName = tbUserName.Text;
                string Password = tbPassword.Text;
                bool issActive = true;
                
                int SeniorOfficerID = Convert.ToInt32(cbSeniorOfficer.SelectedValue);
                int Role = Convert.ToInt32(cbRole.SelectedValue);
                string Photo = ImageClass.GetBase64StringFromImage(Imager.Resize(pictureBoxPhoto.Image, 50, 80, true)); //Resize & Convert to String

                bool Status = false;
                string StatusDetails = null;
                MainClass.MngPAFBOS.InsertRegistrationUser(FullName,Designation,PakNo,UserName,Password, issActive, SeniorOfficerID, Photo, Role, out Status, out StatusDetails);
                if (Status)
                {
                    tbFullName.Text = "";
                    //cbDesignation.SelectedValue = 0;
                    tbPAKNo.Text = "";
                    tbUserName.Text = "";
                    tbPassword.Text = "";
                    //cbSeniorOfficer.SelectedValue = 0;
                    // cbRole.SelectedValue = 0;
                    pictureBoxPhoto.Image = Properties.Resources.NoHuman;
                    JIMessageBox.ShowInformationMessage("User Created Successfully !");
                }
                else
                {
                    JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                }  
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        }
        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            udf_Combo();
          
        }
        private void udf_Combo()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable DtRoles = MainClass.MngPAFBOS.GetRoles(out Status, out StatusDetails);
            DataTable DtSeniorOfficer = MainClass.MngPAFBOS.usp_GetSeniorOfficerByUserID(out Status, out StatusDetails);
         //   DataTable DtUserDesignation = MainClass.MngPAFBOS.GetUserDesignation(out Status, out StatusDetails);
            
            if (Status)
            {
                ListData.AutoSuggession_With_ComboBox(DtRoles, 1, cbRole, "RoleID", "Role");
                ListData.AutoSuggession_With_ComboBox(DtSeniorOfficer,1, cbSeniorOfficer, "UserID", "FullName");
                // ListData.AutoSuggession_With_ComboBox(DtUserDesignation, 1, cbDesignation, "UserID", "FullName");
                List<String> DesignationList = new List<string>() { "-- Select Designation --","Officer", "Staff", "Admin", "Clerk", "Sr. Cadet", "Cadet" };
                cbDesignation.DataSource = DesignationList;
            }
            
        }
        private void cbSeniorOfficer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            lblSeniorOfficer.Visible = true;
            try { 
                DataTable DtSeniorOfficerByFullName = MainClass.MngPAFBOS.GetSeniorOfficerByFullName(Convert.ToInt32(cbSeniorOfficer.SelectedValue), out Status, out StatusDetails);
                
            if (Status)
            {   if(Convert.ToInt32(DtSeniorOfficerByFullName.Rows.Count) == 0)
                    {
                        lblDesignation.Visible = false;
                    }
                    else
                    {
                        lblDesignation.Visible = true;
                        lblDesignation.Text = DtSeniorOfficerByFullName.Rows[0]["Designation"].ToString();
                    }
                }
            else
            {
                JIMessageBox.ShowErrorMessage("" + StatusDetails);
            }
            }catch(Exception ex)
            {
                JIMessageBox.ShowErrorMessage(StatusDetails + " = " + ex);
            }
        }
        private void btnFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogSelectPicture.FileName = "";
                openFileDialogSelectPicture.Filter = "Image Files(*.JPG;*.PNG;*.BMP)|*.JPG;*.PNG;*.BMP";
                openFileDialogSelectPicture.FilterIndex = 2;
                openFileDialogSelectPicture.RestoreDirectory = true;

                if (openFileDialogSelectPicture.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPhoto.ImageLocation = openFileDialogSelectPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbSeniorOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxPhoto_Click(object sender, EventArgs e)
        {

        }

        private void ribbonClientPanel1_Click(object sender, EventArgs e)
        {

        }
    

        private void tabFormItem2_Click(object sender, EventArgs e)
        {

        }

        private void tabFormItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
