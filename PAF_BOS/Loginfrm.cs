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
    public partial class Loginfrm : DevComponents.DotNetBar.Office2007Form
    {
        public Loginfrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxUserName.Text))
                {
                    MessageBox.Show("Please Type User Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxPassword.Text))
                {
                    MessageBox.Show("Please Type Password", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                bool Status = false;
                string StatusDetails = null;
                DataTable DT = MainClass.MngPAFBOS.UsersLogin_With_Roles(textBoxUserName.Text, textBoxPassword.Text, out Status, out StatusDetails);
                if (Status)
                { 
                    MainClass.UserID = (int)DT.Rows[0][0];
                    MainClass.UserName = DT.Rows[0][1].ToString();
                    MainClass.CheckRole = Convert.ToString(DT.Rows[0]["Role"]);
                    MainClass.RoleID = (int)DT.Rows[0]["RoleID"];  
                    this.Close(); 
                }
                else
                {
                    JIMessageBox.ShowInformationMessage(StatusDetails);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        } 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
