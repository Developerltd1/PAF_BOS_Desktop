using AQDBFramwork.Messageboxes;
using Student_Management_System.Utilities.Lists;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class CadetPunishmentfrm : DevComponents.DotNetBar.Office2007Form
    {
        bool Status = false;
        string StatusDetails = null;
        string PakNovalue = null;
        DataTable DtAllCadets;
        DataTable DtAllCadetsByUserID;
        DataTable DtPunishmentCadets;
        DataGridViewRow Row;
        int cadet_id;
        int role_id;
        public CadetPunishmentfrm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }  

        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            udf_Combo();
            udf_AllCadetGridViewByUserID();
             WindowState = FormWindowState.Maximized;
        }

        #region EXTRA
        private void btnCadetSearch_Click(object sender, EventArgs e)
        {
            //   try
            //   {
            //       String byPakNo = tbSearch.Text;
            //       String byRFIDCardNo = tbSearch.Text;
            //      DataTable dt = MainClass.MngPAFBOS.GetCadetsPunishmentInformation(byPakNo, byRFIDCardNo, out Status, out StatusDetails);
            //       if (Status)
            //       {
            //           if (dt.Rows.Count > 0)
            //           {
            //               lbPakNo.Text = dt.Rows[0]["PAKNumber"].ToString();
            //               lbRFIDNo.Text = dt.Rows[0]["RFIDCardNumber"].ToString();
            //               lbCadetName.Text = dt.Rows[0]["CadetName"].ToString();
            //               lbCadetPosition.Text = dt.Rows[0]["Role"].ToString();
            //               lbContact.Text = dt.Rows[0]["ContactNumber"].ToString();
            //               lbMObile.Text = dt.Rows[0]["MobileNumber"].ToString();
            //               lbAddress.Text = dt.Rows[0]["Address"].ToString();
            //               lbCourse.Text = dt.Rows[0]["CourseName"].ToString();
            //               lbTape.Text = dt.Rows[0]["TapeName"].ToString();
            //               pictureBox.Text = dt.Rows[0]["Picture"].ToString();
            //               if (dt.Rows.Count > 0)
            //               { 
            //                   pictureBox.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["Picture"].ToString());
            //               }
            //               cadet_id = Convert.ToInt32(dt.Rows[0]["CadetID"].ToString());
            //               role_id =  Convert.ToInt32(dt.Rows[0]["Role_ID"].ToString());
            //             //  labelX2.Text = dt.Rows[0]["Senior"].ToString();
            //
            //               
            //
            //udf_GridView();
            //
            //           }
            //           else if (dt.Rows.Count <= 0)
            //           {
            //               JIMessageBox.ShowInformationMessage(tbSearch.Text + " : Record Not Found");
            //               lbPakNo.Text = "";
            //               lbRFIDNo.Text = "";
            //               lbCadetName.Text = "";
            //               lbCadetPosition.Text = "";
            //               lbContact.Text = "";
            //               lbMObile.Text = "";
            //               lbAddress.Text = "";
            //               lbCourse.Text = "";
            //               lbTape.Text = "";
            //               cadet_id = 0;
            //               role_id = 0;
            //               labelX2.Text = "";
            //               pictureBox.Image = null;
            //               gdvCadetPunishment.DataSource = null;
            //               dt = null;
            //           }
            //       }
            //       else
            //       {
            //           JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
            //       }
            //   }
            //   catch (Exception ex)
            //   {
            //       JIMessageBox.ShowErrorMessage(ex.Message);
            //   }
        }

        #endregion

        #region EVENT_Listener

        private void gdvCadetPunishment_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 13)
                {
                    int punishmentID = Convert.ToInt32(gdvCadetPunishment.Rows[e.RowIndex].Cells["PunishID1"].Value.ToString());
                    int CategoryID = Convert.ToInt32(gdvCadetPunishment.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString());
                    string remakrs = gdvCadetPunishment.Rows[e.RowIndex].Cells["Remarks1"].Value.ToString();
                    bool Special_Waiver = Convert.ToBoolean(gdvCadetPunishment.Rows[e.RowIndex].Cells["SpecialWaiver1"].Value.ToString());
                    bool Punish_Completed = Convert.ToBoolean(gdvCadetPunishment.Rows[e.RowIndex].Cells["PunishmentCompleted"].Value.ToString());
                    DateTime To = Convert.ToDateTime(gdvCadetPunishment.Rows[e.RowIndex].Cells["To"].Value.ToString());
                    DateTime From = Convert.ToDateTime(gdvCadetPunishment.Rows[e.RowIndex].Cells["From"].Value.ToString());

                    MainClass.MngPAFBOS.UpdatePunishments_with_InsertPunishmentsHistory(punishmentID, cadet_id, CategoryID, remakrs, Special_Waiver, Punish_Completed, MainClass.UserID, MainClass.RoleID, out Status, out StatusDetails,To,From);
                    if (Status)
                    {
                        JIMessageBox.ShowInformationMessage("Punishment Created Successfully ");
                        udf_PunishmentGridView();
                    }
                    else
                    {
                        JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        }
        private void gdvAllCadet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (e.RowIndex >= 0)
                {
                    Row = this.gdvAllCadet.Rows[e.RowIndex];
                    lbCadetName.Text = Row.Cells["CadetName"].Value.ToString();
                    lbFatherName.Text = Row.Cells["CadetFatherName"].Value.ToString();
                   // lbContact.Text = Row.Cells["MobileNumber"].Value.ToString();
                    lbPak.Text = Row.Cells["PAKNumber"].Value.ToString();
                   // lbCNIC.Text = Row.Cells["CNIC"].Value.ToString();
                    lbTape.Text = Row.Cells["Tape"].Value.ToString();
                    lbCourse.Text = Row.Cells["CourseName"].Value.ToString();
                    DataTable dd = MainClass.MngPAFBOS.GetCadetsPictureByCadetID(Convert.ToInt32(Row.Cells["CadetID"].Value.ToString()));

                    pictureBox.Image = ImageClass.GetImageFromBase64(dd.Rows[0][1].ToString());

                    cadet_id = Convert.ToInt32(Row.Cells["CadetID"].Value.ToString());
                    role_id = Convert.ToInt32(Row.Cells["RoleID"].Value.ToString());

                    #region Punishment_Cadets
                    udf_PunishmentGridView();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex);
            }
        }
        private void btnPunishmentSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                bool Special = false;
                bool Status = false;
                string StatusDetails = null;

                DateTime to = DateTime.Parse(string.Format("{0}", dtTo.Value.ToString("dd-MMM-yyy")));
                DateTime from = DateTime.Parse(string.Format("{0}", dtFrom.Value.ToString("dd-MMM-yyy")));

                MainClass.MngPAFBOS.InsertPunishments_with_PunishmentsHistory(cadet_id, Convert.ToInt32(cbCategory.SelectedValue), rbRemarks.Text, Special, false, MainClass.UserID, role_id, out Status, out StatusDetails, to, from);
                if (Status)
                {
                    if (lbCadetName.Text != "") {
                        JIMessageBox.ShowInformationMessage("Punishment Applied");
                        lbCadetName.Text = "";
                        lbCourse.Text = "";
                        lbFatherName.Text = "";
                        lbPak.Text = "";
                        lbTape.Text = "";
                        pictureBox.Image = null;
                        rbRemarks.Text = "";
                        udf_PunishmentGridView();
                    }else
                    {
                        JIMessageBox.ShowInformationMessage("Please Select Cadet !");
                    }
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
        private void textBoxSearchTape_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("Tape", textBoxSearchTape.Text);
        }
        private void textBoxSearchCourse_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CourseName", textBoxSearchCourse.Text);
        }
        private void textBoxSearchPak_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CourseName", textBoxSearchCourse.Text);
        }
        private void textBoxSearchCadetName_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CadetName", textBoxSearchCadetName.Text);
        }
        private void textBoxSearchPakNo_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("PAKNumber", textBoxSearchPakNo.Text);
        }
        #endregion

        #region User_Define_Methods

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
        private void udf_AllCadetGridViewByUserID()
        {
            bool Status = false;
            string StatusDetails = null;
            DtAllCadetsByUserID = MainClass.MngPAFBOS.GellAllCadetsByUserID(MainClass.UserID,out Status, out StatusDetails);

            if (Status)
            {
                gdvAllCadet.Rows.Clear();
                foreach (DataRow r in DtAllCadetsByUserID.Rows)
                {
                    gdvAllCadet.Rows.Add(r["CadetID"].ToString(), r["RoleID"].ToString(), r["CadetName"].ToString(), r["CadetFatherName"].ToString(), r["MobileNumber"].ToString(), r["PAKNumber"].ToString(), r["CNIC"].ToString(), r["TapeName"].ToString(), r["CourseName"].ToString());
                }
            }
            else
            {
                JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
            }
        }
        private void udf_PunishmentGridView()
        {
            bool Status = false;
            string StatusDetails = null;
            PakNovalue = Row.Cells["PAKNumber"].Value.ToString();
            DtPunishmentCadets  = MainClass.MngPAFBOS.GetPunishments(PakNovalue, out Status, out StatusDetails);
            if (Status)
            {
                gdvCadetPunishment.Rows.Clear();
                // gdvSearchCadet.DataSource = DtCadetsByTapeAndCourseID;
                foreach (DataRow r in DtPunishmentCadets.Rows)
                {
                    gdvCadetPunishment.Rows.Add(r["PunishmentID"].ToString(), r["CategoryID"].ToString(), r["CadetName"].ToString(),
                                         r["PAKNumber"].ToString(), r["MobileNumber"].ToString(), r["CourseName"].ToString(),
                                         r["TapeName"].ToString(), r["PunishmentType"].ToString(), r["Remarks"].ToString(),
                                         r["To"].ToString(), r["From"].ToString(),
                                         r["SpecialWaiver"].ToString(), r["PunishCompleted"].ToString());

                    udf_btn(); //Create Btn 
                }
            }
            else
            {
                JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
            }
          }
        private void udf_btn()
        {
            //Dynamic Button on GridView  -btnUpdate-
            DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
        private void SearchFilter(string Cell, string Criteria)
        {
            foreach (DataGridViewRow row in gdvAllCadet.Rows)
            {
                if (row.Cells[Cell].Value.ToString().ToLower().Contains(Criteria.ToLower()))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }


        #endregion

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void lbCNIC_Click(object sender, EventArgs e)
        {
                    }
    }
}
