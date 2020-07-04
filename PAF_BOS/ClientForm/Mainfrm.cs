using AQDBFramwork.Messageboxes;
using PAF_BOS.AdminForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class Mainfrm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Mainfrm()
        {
            InitializeComponent();
        }
  
        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Book Out System (BOS)\nVersion : " + Application.ProductVersion,"Application",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Mainfrm_Load(object sender, EventArgs e)
        {
            //Main DashBoard Chatrs
            DashBoardCharts frm = new DashBoardCharts();
            CheckFormStatus(frm);

            udf_FormsButtonDisable();

            bool Status = false;
            string StatusDetails = null;
            try
            {
                labelLoggedInUser.Text = MainClass.UserName;
                DataTable checkRole = MainClass.MngPAFBOS.AuthenticateUser(MainClass.CheckRole, out Status,out StatusDetails);
                string RoleName = checkRole.Rows[0]["Role"].ToString();

                foreach (DevComponents.DotNetBar.RibbonBar RB in ribbonPanel1.Controls)
                {
                    foreach (DevComponents.DotNetBar.ButtonItem it in RB.Items)
                    {
                        foreach (DataRow row in checkRole.Rows)
                        {
                            if (it.Name == row["FormName"].ToString())
                                it.Enabled = true;
                        }
                        foreach (DevComponents.DotNetBar.ButtonItem itt in it.SubItems)
                        {
                            foreach (DataRow row in checkRole.Rows)
                            {
                                if (it.Name == row["FormName"].ToString())
                                    it.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(StatusDetails + ":" + ex.Message);
            } 
        }

        public void udf_FormsButtonDisable()
        {
            Application.DoEvents();
            btnItem_USER.Enabled = false; 
            btnItem_CADET_REGISTRATION.Enabled = false;
            btnItem_CADET_PUNSIHMENT.Enabled = false;
            btnItem_CADET_ATTANDANCE_PERMISSION.Enabled = false;
            btnItem_USER_ATTANDANCE_ACCESS.Enabled = false;
            btnItem_FORM_ROLES.Enabled = false;
            btnItemAttendanceReport.Enabled = false;
            buttonItemCadetAttendanceReport.Enabled = false;
            btnItem_ALLCADET_PUNSIHMENT.Enabled = false;
            btnItem_ALLCADET_PUNSIHMENT.Enabled = false;
            buttonItemExcelSheet.Enabled = false;

        }

        //allow only single instance of form open
        public void CheckFormStatus(Form f)
        {
            bool found = false;
            foreach (Form frm in MdiChildren)
            {
                if (f.Text == frm.Text)
                {
                    found = true;
                    frm.Activate();
                    return;
                }
            }
            if (!found)
            {
                f.MdiParent = this;
                f.Show();
            }

        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTotalClientsReport_Click(object sender, EventArgs e)
        {
            UserRolePermission frm = new UserRolePermission();
            CheckFormStatus(frm);
        } 

        private void btnAdminUserAttendanceReport_Click(object sender, EventArgs e)
        { 
            CadetSearchPermissiontfrm frm = new CadetSearchPermissiontfrm();
            CheckFormStatus(frm);
        }

        private void btnItemUSER_Click(object sender, EventArgs e)
        {
            UserRegistrationfrm frm = new UserRegistrationfrm();
            CheckFormStatus(frm);
        } 

        private void btnItemCADETREGISTRATION(object sender, EventArgs e)
        {
            CaderRegistrationfrm frm = new CaderRegistrationfrm();
            CheckFormStatus(frm);
        }

        private void btnItemPUNISHMENT(object sender, EventArgs e)
        {
            CadetPunishmentfrm frm = new CadetPunishmentfrm();
            CheckFormStatus(frm);
        } 
         
        private void btnItem_CADET_ATTANDANCE_PERMISSION_Click(object sender, EventArgs e)
        {
            AttandanceSessiontfrm frm = new AttandanceSessiontfrm();
            CheckFormStatus(frm);
        }

       

        private void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            AttendanceSystem.Reports.Attendancefrm frm = new AttendanceSystem.Reports.Attendancefrm();
            CheckFormStatus(frm);
        }

        private void btnCadetAttendanceReport_Click(object sender, EventArgs e)
        {
            ClientForm.SingleCadetAttendancefrm frm = new ClientForm.SingleCadetAttendancefrm();
            CheckFormStatus(frm);
        }

      

       

        private void btnAttendanceReport(object sender, EventArgs e)
        {
            AttendanceSystem.Reports.Attendancefrm frm = new AttendanceSystem.Reports.Attendancefrm();
            CheckFormStatus(frm);
        }

     

        private void btnItem_ALLCADET_PUNSIHMENT_Click(object sender, EventArgs e)
        {
            CCCadetPunishmentfrm frm = new CCCadetPunishmentfrm();
            CheckFormStatus(frm);
        }

        private void buttonItemExcelSheet_Click(object sender, EventArgs e)
        {
            CadetExcelDataImportfrm frm = new CadetExcelDataImportfrm();
            CheckFormStatus(frm);
        }

        // private void btnItem_CADET_GROUND_ATTANDANCE_PERMISSION_Click(object sender, EventArgs e)
        // {
        //     //GroundAttandanceSessiontfrm frm = new GroundAttandanceSessiontfrm();
        //     //CheckFormStatus(frm);
        //     Method2CadetExcelDataImportfrm frm = new Method2CadetExcelDataImportfrm();
        //      CheckFormStatus(frm);
        //     
        // }
    }
}
