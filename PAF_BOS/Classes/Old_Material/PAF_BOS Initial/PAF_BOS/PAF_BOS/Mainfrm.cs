using System; 
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
            try
            {
                labelLoggedInUser.Text = MainClass.UserName;

                if (!MainClass.IsAdmin)
                {
                    btnManageClient.Enabled = false;
                    btnManageDepartment.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void btnClientRegistration_Click(object sender, EventArgs e)
        {
            if (MainClass.IsAdmin == false)
            {
                MessageBox.Show("Admin Option, Not Allowed", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AdminForms.ManageClientfrm frm = new AdminForms.ManageClientfrm();
            CheckFormStatus(frm);

        }
        private void btnManageShift_Click(object sender, EventArgs e)
        {
            AdminForms.ManageShiftfrm frm = new AdminForms.ManageShiftfrm();
            CheckFormStatus(frm);
        }

        private void btnManageDepartment_Click(object sender, EventArgs e)
        {
            if (MainClass.IsAdmin == false)
            {
                MessageBox.Show("Admin Option, Not Allowed", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AdminForms.ManageDepartmentfrm frm = new AdminForms.ManageDepartmentfrm();
            CheckFormStatus(frm);
        } 

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            AdminForms.ManageUserfrm frm = new AdminForms.ManageUserfrm();
            CheckFormStatus(frm);
        }

        private void btnChangeUserShift_Click(object sender, EventArgs e)
        {
            AdminForms.ChangeUserShiftfrm frm = new AdminForms.ChangeUserShiftfrm();
            CheckFormStatus(frm);
        }
  
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordfrm frm = new ChangePasswordfrm();
            CheckFormStatus(frm);
        }

        private void btnTotalClientsReport_Click(object sender, EventArgs e)
        { 
            Reports.Clientsfrm frm = new Reports.Clientsfrm();
            CheckFormStatus(frm);
        }

        private void btnAdminAllUserReport_Click(object sender, EventArgs e)
        {
            Reports.UserDetailsfrm frm = new Reports.UserDetailsfrm();
            CheckFormStatus(frm);
        }

        private void btnAdminUserAttendanceReport_Click(object sender, EventArgs e)
        {
            Reports.Attendancefrm frm = new Reports.Attendancefrm();
            CheckFormStatus(frm);
        }
    }
}
