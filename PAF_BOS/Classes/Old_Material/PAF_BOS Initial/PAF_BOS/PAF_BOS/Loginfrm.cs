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

                string UserName = textBoxUserName.Text;
                string Password = textBoxPassword.Text;
                bool Status = false;
                string StatusDetails = null;
                DataTable DT = new DataTable();
                
                    DT = MainClass.AuthenticateUser(UserName, Password, out Status, out StatusDetails);
                 
                

                if(Status)
                { 
                    MainClass.UserName = UserName;
                    MainClass.Password = Password;
                    MainClass.IsAdmin = (bool)DT.Rows[0]["IsAdmin"];
                    MainClass.UserClientID = (int)DT.Rows[0]["Client_ID"];
                    this.Close();
                }
                else
                {
                    textBoxPassword.Text = "";
                    MessageBox.Show("Invalid Credentials", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
 
    }
}
