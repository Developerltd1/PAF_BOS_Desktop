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
    public partial class CadetPunishmentfrm : DevComponents.DotNetBar.Office2007Form
    {

        int cadet_id ;
        int role_id;
        public CadetPunishmentfrm()
        {
            InitializeComponent();
            udf_GridView();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

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

        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            udf_Combo();
            udf_GridView();
        }

        private void udf_GridView()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable dt =  MainClass.MngPAFBOS.GetPunishments(tbSearch.Text, tbSearch.Text, out Status, out StatusDetails);
           
            gdvCadetPunishment.DataSource = dt;
            ListData.GridViewColumnFix(gdvCadetPunishment);
        }

        private void udf_Combo()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable DtPunishmentCategory = MainClass.MngPAFBOS.GetPunishmentCategories(out Status, out StatusDetails);
            if (Status)
            {
                ListData.AutoSuggession_With_ComboBox(DtPunishmentCategory, 1, cbCategory, "CategoryID", "CategoryName");
                //ListData.AutoSuggession_With_ComboBox(DtCadetTape, 1, cbTape, "TapeID", "TapeName");
                //ListData.AutoSuggession_With_ComboBox(DtCadetCourses, 1, cbCourse, "CourseID", "CourseName");
            }
        }

        private void btnCadetRegister_Click(object sender, EventArgs e)
        {
            try
            {
                bool Special= ckbSpecialWaiver.CanSelect;
                bool Status = false;
                string StatusDetails = null;

               MainClass.MngPAFBOS.InsertPunishments_with_PunishmentsHistory(cadet_id,Convert.ToInt32(cbCategory.SelectedValue),rbRemarks.Text, Special, false,MainClass.UserID,role_id, out Status, out StatusDetails);
                if (Status)
                {
                    JIMessageBox.ShowInformationMessage("" + Status + " = " + StatusDetails);
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

        private void labelX16_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadetSearch_Click(object sender, EventArgs e)
        {
         try{
             bool Status = false;
             String StatusDetails = null;
             String byPakNo = tbSearch.Text;
             String byRFIDCardNo = tbSearch.Text;
             DataTable dt =  MainClass.MngPAFBOS.GetCadetsPunishmentInformation(byPakNo, byRFIDCardNo, out Status, out StatusDetails);
                
          if(Status)
            {
              if(dt.Rows.Count > 0)
                  { 
                   lbPakNo.Text = dt.Rows[0]["PAKNumber"].ToString();
                   lbRFIDNo.Text = dt.Rows[0]["RFIDCardNumber"].ToString();
                   lbCadetName.Text = dt.Rows[0]["CadetName"].ToString();
                   lbCadetPosition.Text = dt.Rows[0]["Role"].ToString();
                   lbContact.Text = dt.Rows[0]["ContactNumber"].ToString();
                   lbMObile.Text = dt.Rows[0]["MobileNumber"].ToString();
                   lbAddress.Text = dt.Rows[0]["Address"].ToString();
                   lbCourse.Text = dt.Rows[0]["CourseName"].ToString();
                   lbTape.Text = dt.Rows[0]["TapeName"].ToString();
                   pictureBox.Text = dt.Rows[0]["Picture"].ToString();
                   cadet_id= Convert.ToInt32(dt.Rows[0]["CadetID"].ToString());
                   role_id = Convert.ToInt32(dt.Rows[0]["Role_ID"].ToString());
                   udf_GridView();

                   JIMessageBox.ShowInformationMessage("" + Status + " = " + StatusDetails);
                  }
              else if(dt.Rows.Count <= 0)
                    {
                        JIMessageBox.ShowInformationMessage( tbSearch.Text + " : Record Not Found");
                    }
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

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            CaderRegistrationfrm ff = new CaderRegistrationfrm();
            ff.Show();
            this.Visible = false;
        }
    }
}
