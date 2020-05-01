using AQDBFramwork.Messageboxes;
using Student_Management_System.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class CadetPunishmentfrm : DevComponents.DotNetBar.Office2007Form
    {
        bool Status = false;
        string StatusDetails = null;
        int cadet_id ;
        int role_id;
        public CadetPunishmentfrm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            udf_GridView();
        }  

        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            udf_Combo();
            udf_GridView();
            WindowState = FormWindowState.Maximized;
        }

        private void udf_GridView()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable dt =  MainClass.MngPAFBOS.GetPunishments(tbSearch.Text, tbSearch.Text, out Status, out StatusDetails);
           
            gdvCadetPunishment.DataSource = dt;
            ListData.setGridviewColHideORShow(gdvCadetPunishment, "PunishmentID", false);
            ListData.setGridviewColHideORShow(gdvCadetPunishment, "CategoryID", false);
            ListData.GridViewColumnFix(gdvCadetPunishment); 
            udf_btn(); //Create Btn 
        }

        private void udf_btn()
        {
            //Dynamic Button on GridView  -btnUpdate-
            DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
            btnUpdate.FlatStyle = FlatStyle.Popup;

            btnUpdate.HeaderText = "Action";
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Text = "Update";
            btnUpdate.DefaultCellStyle.BackColor = Color.Orange;
            btnUpdate.Width = 60;
            btnUpdate.UseColumnTextForButtonValue = true;
            if (gdvCadetPunishment.Columns.Contains(btnUpdate.Name = "btnUpdate"))
            {

            }
            else
            {
                gdvCadetPunishment.Columns.Add(btnUpdate);
            }
        }

        private void udf_Combo()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable DtPunishmentCategory = MainClass.MngPAFBOS.GetPunishmentCategories(out Status, out StatusDetails);
            if (Status)
            {
                ListData.AutoSuggession_With_ComboBox(DtPunishmentCategory, 1, cbCategory, "CategoryID", "CategoryName"); 
            }
        }

        private void btnCadetRegister_Click(object sender, EventArgs e)
        {
            try
            {
                bool Special = false;
                bool Status = false;
                string StatusDetails = null;

                MainClass.MngPAFBOS.InsertPunishments_with_PunishmentsHistory(cadet_id, Convert.ToInt32(cbCategory.SelectedValue), rbRemarks.Text, Special, false, MainClass.UserID, role_id, out Status, out StatusDetails);
                if (Status)
                {
                    udf_GridView();
                    JIMessageBox.ShowInformationMessage("Punishment Applied"); 
                }
                else
                {
                    JIMessageBox.ShowErrorMessage("Punishment Applied Failed , Error : " + StatusDetails);
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        }
 
        private void btnCadetSearch_Click(object sender, EventArgs e)
        {
            try
            {
                String byPakNo = tbSearch.Text;
                String byRFIDCardNo = tbSearch.Text;
                DataTable dt = MainClass.MngPAFBOS.GetCadetsPunishmentInformation(byPakNo, byRFIDCardNo, out Status, out StatusDetails);
                if (Status)
                {
                    if (dt.Rows.Count > 0)
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
                        if (dt.Rows.Count > 0)
                        { 
                            pictureBox.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["Picture"].ToString());
                        }
                        cadet_id = Convert.ToInt32(dt.Rows[0]["CadetID"].ToString());
                        role_id = Convert.ToInt32(dt.Rows[0]["Role_ID"].ToString());
                      //  labelX2.Text = dt.Rows[0]["Senior"].ToString();

                        

                        udf_GridView();

                    }
                    else if (dt.Rows.Count <= 0)
                    {
                        JIMessageBox.ShowInformationMessage(tbSearch.Text + " : Record Not Found");
                        lbPakNo.Text = "";
                        lbRFIDNo.Text = "";
                        lbCadetName.Text = "";
                        lbCadetPosition.Text = "";
                        lbContact.Text = "";
                        lbMObile.Text = "";
                        lbAddress.Text = "";
                        lbCourse.Text = "";
                        lbTape.Text = "";
                        cadet_id = 0;
                        role_id = 0;
                        labelX2.Text = "";
                        pictureBox.Image = null;
                        gdvCadetPunishment.DataSource = null;
                        dt = null;
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

        private void gdvCadetPunishment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    int punishmentID = Convert.ToInt32(gdvCadetPunishment.Rows[e.RowIndex].Cells["PunishmentID"].Value.ToString());
                    int CategoryID = Convert.ToInt32(gdvCadetPunishment.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString());
                    string remakrs = gdvCadetPunishment.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                    bool Special_Waiver = Convert.ToBoolean(gdvCadetPunishment.Rows[e.RowIndex].Cells["Special Waiver"].Value.ToString());
                    bool Punish_Completed = Convert.ToBoolean(gdvCadetPunishment.Rows[e.RowIndex].Cells["Punish Completed"].Value.ToString());
                    MainClass.MngPAFBOS.UpdatePunishments_with_InsertPunishmentsHistory(punishmentID, cadet_id, CategoryID, remakrs, Special_Waiver, Punish_Completed, MainClass.UserID, MainClass.RoleID, out Status, out StatusDetails);
                    if (Status)
                    {
                        JIMessageBox.ShowInformationMessage("Punishment Created Successfully "); 
                    }
                    else
                    {
                        JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                    } 
                    udf_GridView();
                } 
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        } 
    }
}
