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
    public partial class ChangePasswordfrm : DevComponents.DotNetBar.Office2007Form
    {
        public ChangePasswordfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBoxOldPassword.Text))
                {
                    MessageBox.Show("Please Enter Old Password !", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxNewPassword.Text))
                {
                    MessageBox.Show("Please Enter New Password !", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxNewPasswordAgain.Text))
                {
                    MessageBox.Show("Please Enter New Password Again !", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxNewPassword.Text != textBoxNewPasswordAgain.Text)
                {
                    MessageBox.Show("Mismatch New Password , Please Enter Correctl!", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNewPassword.Text = "";
                    textBoxNewPasswordAgain.Text = "";
                    return;
                }



                string StatusDetails = "";
                bool Result = false;
                 
                    MainClass.ChangePassword(MainClass.UserName, textBoxNewPassword.Text, textBoxOldPassword.Text,out Result, out StatusDetails);
                

                if (Result)
                {
                    MessageBox.Show("Password Successfully Updated !!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNewPasswordAgain.Text = "";
                    textBoxOldPassword.Text = "";
                    textBoxNewPassword.Text = "";
                }
                else
                    MessageBox.Show("Password Change Failed !!!\n"+StatusDetails, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
