using AQDBFramwork.Messageboxes;
using DPUruNet;
using Student_Management_System.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class CaderRegistrationfrm : DevComponents.DotNetBar.Office2007Form
    {
        public CaderRegistrationfrm()
        {
            InitializeComponent();
        } 

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
           // if (e.KeyCode == Keys.Enter)
              //  btnLogin_Click(sender, e);
        } 

        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            radioJuniorCadet.Checked = true;
            udf_Combo();
            CheckDevice();
            udf_GridView();
        }

        #region FingerPrint Methods

        DataResult<Fmd> LeftFMD1 = null;
        DataResult<Fmd> LeftFMD2 = null;
        DataResult<Fmd> LeftFMD3 = null;
        DataResult<Fmd> LeftFMD4 = null;
        DataResult<Fmd> LeftFinalFMD = null;


        DataResult<Fmd> RightFMD1 = null;
        DataResult<Fmd> RightFMD2 = null;
        DataResult<Fmd> RightFMD3 = null;
        DataResult<Fmd> RightFMD4 = null;
        DataResult<Fmd> RightFinalFMD = null;

        ReaderCollection conectedDevices = null;
        public Reader CurrentReader = null;
        internal delegate void SendMessageCallback(FingerScannerClass.Action action, object payload);
        internal void SendMessage(FingerScannerClass.Action action, object payload)
        {
            try
            {
                if (tabItemNew.IsSelected)
                {
                    #region TabItemNEW
                    if (radioButtonLeftThumb.Checked)
                    {
                        if (pictureBoxLeftThumb.InvokeRequired)
                        {
                            SendMessageCallback d = new SendMessageCallback(SendMessage);
                            Invoke(d, new object[] { action, payload });
                        }
                        else
                        {
                            switch (action)
                            {
                                case FingerScannerClass.Action.SendMessage:
                                    MessageBox.Show((string)payload);
                                    break;
                                case FingerScannerClass.Action.SendBitmap:
                                    pictureBoxLeftThumb.Image = (Bitmap)payload;
                                    pictureBoxLeftThumb.Refresh();
                                    break;
                            }
                        }
                    }
                    else if (radioButtonRightThumb.Checked)
                    {
                        if (radioButtonRightThumb.InvokeRequired)
                        {
                            SendMessageCallback d = new SendMessageCallback(SendMessage);
                            Invoke(d, new object[] { action, payload });
                        }
                        else
                        {
                            switch (action)
                            {
                                case FingerScannerClass.Action.SendMessage:
                                    MessageBox.Show((string)payload);
                                    break;
                                case FingerScannerClass.Action.SendBitmap:
                                    pictureBoxRightThumb.Image = (Bitmap)payload;
                                    pictureBoxRightThumb.Refresh();
                                    break;
                            }
                        }
                    }
                    #endregion
                }
                if (tabItemUpdate.IsSelected)
                { 
                    #region TabItemUpdate
                    if (UradioButtonLeftThumb.Checked)
                    {
                        if (uThumbLeft.InvokeRequired)
                        {
                            SendMessageCallback d = new SendMessageCallback(SendMessage);
                            Invoke(d, new object[] { action, payload });
                        }
                        else
                        {
                            switch (action)
                            {
                                case FingerScannerClass.Action.SendMessage:
                                    MessageBox.Show((string)payload);
                                    break;
                                case FingerScannerClass.Action.SendBitmap:
                                    uThumbLeft.Image = (Bitmap)payload;
                                    uThumbLeft.Refresh();
                                    break;
                            }
                        }
                    }
                    else if (UradioButtonRightThumb.Checked)
                    {
                        if (UradioButtonRightThumb.InvokeRequired)
                        {
                            SendMessageCallback d = new SendMessageCallback(SendMessage);
                            Invoke(d, new object[] { action, payload });
                        }
                        else
                        {
                            switch (action)
                            {
                                case FingerScannerClass.Action.SendMessage:
                                    MessageBox.Show((string)payload);
                                    break;
                                case FingerScannerClass.Action.SendBitmap:
                                    uThumbRight.Image = (Bitmap)payload;
                                    uThumbRight.Refresh();
                                    break;
                            }
                        }
                    }
                #endregion
                }
            }
            catch (Exception)
            {
            }
        }
        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!FingerScannerClass.CheckCaptureResult(captureResult)) return;

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(FingerScannerClass.Action.SendBitmap, FingerScannerClass.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }
                #region tabItemNEW
                if (tabItemNew.IsSelected)
                {
                    if (radioButtonRightThumb.Checked)
                    {
                        pictureBoxRightThumb.Tag = captureResult;
                    }
                    else if (radioButtonLeftThumb.Checked)
                    {
                        pictureBoxLeftThumb.Tag = captureResult;
                    }
                }
                #endregion
                #region tabItemUPATE
                if (tabItemUpdate.IsSelected)
                {
                    if (UradioButtonRightThumb.Checked)
                    {
                        uThumbRight.Tag = captureResult;
                    }
                    else if (UradioButtonLeftThumb.Checked)
                    {
                        uThumbLeft.Tag = captureResult;
                    }
                }
                #endregion

                this.Invoke(new EventHandler(DisplayData));
            }
            catch (Exception ex)
            {
                SendMessage(FingerScannerClass.Action.SendMessage, "Error:  " + ex.Message);
            }
        }
        private void CheckDevice()
        {
            if (conectedDevices == null)
            {
                conectedDevices = FingerScannerClass.DetactsDevices();

                if (conectedDevices.Count > 0)
                {
                    if (conectedDevices.Count <= 0)
                    {
                        MessageBox.Show("Finger Print Device Not Found", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    CurrentReader = conectedDevices[0];
                    FingerScannerClass.OpenReader(CurrentReader);
                    FingerScannerClass.StartCaptureAsync(this.OnCaptured, CurrentReader);
                }
                else
                {
                    MessageBox.Show("Finger Print Device Not Found", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void DisplayData(object sender, EventArgs e)
        {
            #region tabItemNEW
            if (tabItemNew.IsSelected)
            {
                if (radioButtonLeftThumb.Checked)
                {
                    Fid fid = ((CaptureResult)pictureBoxLeftThumb.Tag).Data;

                    if (LeftFMD1 == null)
                        LeftFMD1 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (LeftFMD2 == null)
                        LeftFMD2 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (LeftFMD3 == null)
                        LeftFMD3 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (LeftFMD4 == null)
                    {
                        LeftFMD4 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                        List<Fmd> fmds = new List<Fmd>();
                        fmds.Add(LeftFMD1.Data);
                        fmds.Add(LeftFMD2.Data);
                        fmds.Add(LeftFMD3.Data);
                        fmds.Add(LeftFMD4.Data);
                        LeftFinalFMD = Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, fmds);
                        if (LeftFinalFMD.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            MessageBox.Show("Successfully Scanned !!!");
                            LeftFMD1 = null;
                            LeftFMD2 = null;
                            LeftFMD3 = null;
                            LeftFMD4 = null;
                        }
                    }

                }
                else if (radioButtonRightThumb.Checked)
                {
                    Fid fid = ((CaptureResult)pictureBoxRightThumb.Tag).Data;

                    if (RightFMD1 == null) RightFMD1 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (RightFMD2 == null) RightFMD2 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (RightFMD3 == null) RightFMD3 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (RightFMD4 == null)
                    {
                        RightFMD4 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                        List<Fmd> fmds = new List<Fmd>();
                        fmds.Add(RightFMD1.Data);
                        fmds.Add(RightFMD2.Data);
                        fmds.Add(RightFMD3.Data);
                        fmds.Add(RightFMD4.Data);
                        RightFinalFMD = Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, fmds);
                        if (RightFinalFMD.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            MessageBox.Show("Successfully Scanned !!!");
                            RightFMD1 = null;
                            RightFMD2 = null;
                            RightFMD3 = null;
                            RightFMD4 = null;
                        }
                    }
                }
            }
            #endregion
            #region tabItemUPDATE
            if (tabItemUpdate.IsSelected)
            {
                if (UradioButtonLeftThumb.Checked)
                {
                    Fid fid = ((CaptureResult)uThumbLeft.Tag).Data;

                    if (LeftFMD1 == null)
                        LeftFMD1 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (LeftFMD2 == null)
                        LeftFMD2 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (LeftFMD3 == null)
                        LeftFMD3 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (LeftFMD4 == null)
                    {
                        LeftFMD4 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                        List<Fmd> fmds = new List<Fmd>();
                        fmds.Add(LeftFMD1.Data);
                        fmds.Add(LeftFMD2.Data);
                        fmds.Add(LeftFMD3.Data);
                        fmds.Add(LeftFMD4.Data);
                        LeftFinalFMD = Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, fmds);
                        if (LeftFinalFMD.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            MessageBox.Show("Successfully Scanned !!!");
                            LeftFMD1 = null;
                            LeftFMD2 = null;
                            LeftFMD3 = null;
                            LeftFMD4 = null;
                        }
                    }

                }
                else if (UradioButtonRightThumb.Checked)
                {
                    Fid fid = ((CaptureResult)uThumbRight.Tag).Data;

                    if (RightFMD1 == null) RightFMD1 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (RightFMD2 == null) RightFMD2 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (RightFMD3 == null) RightFMD3 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                    else if (RightFMD4 == null)
                    {
                        RightFMD4 = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
                        List<Fmd> fmds = new List<Fmd>();
                        fmds.Add(RightFMD1.Data);
                        fmds.Add(RightFMD2.Data);
                        fmds.Add(RightFMD3.Data);
                        fmds.Add(RightFMD4.Data);
                        RightFinalFMD = Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, fmds);
                        if (RightFinalFMD.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            MessageBox.Show("Successfully Scanned !!!");
                            RightFMD1 = null;
                            RightFMD2 = null;
                            RightFMD3 = null;
                            RightFMD4 = null;
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        private void udf_Combo()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable DtRoles = MainClass.MngPAFBOS.GetRoles(out Status, out StatusDetails);
            DataTable DtSeniorOfficer = MainClass.MngPAFBOS.usp_GetSeniorOfficerByUserID(out Status, out StatusDetails);
            DataTable DtCadetTape = MainClass.MngPAFBOS.GetCadetTapes(out Status, out StatusDetails);
            DataTable DtCadetCourses = MainClass.MngPAFBOS.GetCadetCourses(out Status, out StatusDetails);
            if (Status)
            {
                ListData.AutoSuggession_With_ComboBox(DtSeniorOfficer, 1, cbSeniorOfficer, "UserID", "FullName");
                ListData.AutoSuggession_With_ComboBox(DtCadetTape, 1, cbTape, "TapeID", "TapeName");
                ListData.AutoSuggession_With_ComboBox(DtCadetCourses, 1, cbCourse, "CourseID", "CourseName");
            }
            List<String> BloodGroupList = new List<string>() { "-- Select Bloodgroup --", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            CbBloodGroup.DataSource = BloodGroupList;
        }
        int radioOfCadet = 0;
        private void btnCadetRegister_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (radioSeniorCadet.Checked) { radioOfCadet = 5; }
                if (radioJuniorCadet.Checked) { radioOfCadet = 6; }
                if (udf_Validation(tbCadet.Text, tbFatherName.Text, tbPAKNumber.Text, tbCNIC.Text, CbBloodGroup.Text, tbContactNo.Text, tbMobileNo.Text, tbRFIDCardNo.Text, cbSeniorOfficer.Text, cbTape.Text, cbCourse.Text, radioOfCadet) == true)
                {
                    string batch = "STATIC-BATCH";

                    string LFMD = null;
                    string RFMD = null;
                    string LIMG = ImageClass.GetBase64StringFromImage(pictureBoxLeftThumb.Image);
                    string RIMG = ImageClass.GetBase64StringFromImage(pictureBoxRightThumb.Image);

                    if (LeftFinalFMD == null && RightFinalFMD == null)
                    {
                        MessageBox.Show("Finger Scan Required of Both Fingers, Scan Again");
                        return;
                    }

                    LFMD = Fmd.SerializeXml(LeftFinalFMD.Data);
                    RFMD = Fmd.SerializeXml(RightFinalFMD.Data);

                    int SeniorOfficeID = Convert.ToInt32(cbSeniorOfficer.SelectedValue);
                    int courseid = Convert.ToInt32(cbCourse.SelectedValue);
                    int tapeid = Convert.ToInt32(cbTape.SelectedValue);
                    int userid = MainClass.UserID; 
                    Bitmap img = ImageClass.Resize((Bitmap)pictureBoxPhoto.Image, new Size(100, 100), System.Drawing.Imaging.ImageFormat.Jpeg);
                    string Photo = ImageClass.GetBase64StringFromImage(img); //Resize & Convert to String

                    MainClass.MngPAFBOS.InsertCadet_with_CadetHistory(batch, tbCadet.Text, tbFatherName.Text, 
                        tbPAKNumber.Text, tbAddress.Text, tbCNIC.Text, CbBloodGroup.Text,tbContactNo.Text, tbMobileNo.Text, Photo, tbRFIDCardNo.Text, 
                        LFMD,RFMD,LIMG,RIMG, SeniorOfficeID, courseid, tapeid, MainClass.UserID, radioOfCadet, out Status, out StatusDetails);

                    if (Status)
                    {
                        JIMessageBox.ShowInformationMessage("Cadet Created Successfully !");
                        ClearFormFields();
                    }
                    else
                    {
                        JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                    } 
                }
                else
                {
                    JIMessageBox.ShowErrorMessage("Please Fill All Fields");
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        }

        private void ClearFormFields()
        {
            lblSeniorOfficer.Text = "";
            tbCadet.Text = null;
            tbAddress.Text = null;
            tbFatherName.Text = null;
            tbPAKNumber.Text = null;
            tbCNIC.Text = null;
            CbBloodGroup.Text = null;
            tbContactNo.Text = null;
            tbMobileNo.Text = null;
            tbRFIDCardNo.Text = null;
            cbSeniorOfficer.Text = null;
            cbTape.Text = null;
            cbCourse.Text = null;  
            pictureBoxPhoto.Image = Properties.Resources.NoHuman;
            pictureBoxRightThumb.Image = null;
            pictureBoxLeftThumb.Image = null; 
            RightFinalFMD = null;
            LeftFinalFMD = null; 
            LeftFMD1 = null;
            LeftFMD2 = null;
            LeftFMD3 = null;
            LeftFMD4 = null; 
            RightFMD1 = null;
            RightFMD2 = null;
            RightFMD3 = null;
            RightFMD4 = null;
        }
        private void UpdateTabClearFormFields()
        {
            //lblSeniorOfficer.Text = "";
            utbCadetName.Text = null;
            utbAddress.Text = null;
            utbFatherName.Text = null;
            utbPAK.Text = null;
            utbCNIC.Text = null;
            ucbBloodGroup.Text = null;
            utbContact.Text = null;
            utbMobile.Text = null;
            utbRFIDCard.Text = null;
            ucbSeniorOfficer.Text = null;
            ucbTape.Text = null;
            ucbCourse.Text = null;
            uCadetPic.Image = Properties.Resources.NoHuman;
            uThumbRight.Image = null;
            uThumbLeft.Image = null;
            RightFinalFMD = null;
            LeftFinalFMD = null;
            LeftFMD1 = null;
            LeftFMD2 = null;
            LeftFMD3 = null;
            LeftFMD4 = null;
            RightFMD1 = null;
            RightFMD2 = null;
            RightFMD3 = null;
            RightFMD4 = null;
        }
        private bool udf_Validation(string ca, string fa, string pak, string cnic, string blood, string con, string mob, string rfid, string senior, string tap, string course, int radio)
        { 
            if (ca != "" && fa != "" && pak != "" && cnic != "" && blood != "" && con != "" && mob != "" && rfid != "" && senior != "" && tap != "" && course != "" && radio != 0)
            {
                return true;
            }
            return false;
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
 
        private void cbSeniorOfficer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            lblSeniorOfficer.Visible = true;
            try
            {
                DataTable DtSeniorOfficerByFullName = MainClass.MngPAFBOS.GetSeniorOfficerByFullName(Convert.ToInt32(cbSeniorOfficer.SelectedValue), out Status, out StatusDetails);

                if (Status)
                {
                    if (Convert.ToInt32(DtSeniorOfficerByFullName.Rows.Count) == 0)
                    {
                        lblSeniorOfficer.Visible = false;
                    }
                    else
                    {
                        lblSeniorOfficer.Visible = true;
                        lblSeniorOfficer.Text = DtSeniorOfficerByFullName.Rows[0]["Designation"].ToString();
                    }
                }
                else
                {
                    JIMessageBox.ShowErrorMessage("" + StatusDetails);
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(StatusDetails + " = " + ex);
            }
        }

        private void tbPAKNumber_Leave(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable dt = MainClass.MngPAFBOS.GetPakNo_AND_RFIDNo_EXIST(out Status, out StatusDetails);
                foreach (DataRow row in dt.Rows)
                {
                    if (tbPAKNumber.Text.Trim() == row["PAKNumber"].ToString())
                    {
                        JIMessageBox.ShowInformationMessage(tbPAKNumber.Text + ": Already Exist");
                        tbPAKNumber.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(StatusDetails + " = " + ex);
            }
        }

        private void tbRFIDCardNo_Leave(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataTable dt = MainClass.MngPAFBOS.GetPakNo_AND_RFIDNo_EXIST(out Status, out StatusDetails);
                foreach (DataRow row in dt.Rows)
                {
                    if (tbRFIDCardNo.Text.Trim() == row["RFIDCardNumber"].ToString())
                    {
                        JIMessageBox.ShowInformationMessage(tbRFIDCardNo.Text + ": Already Exist");
                        tbRFIDCardNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(StatusDetails);
            }
        }

        private void tbContactNo_Leave(object sender, EventArgs e)
        {
            bool isPhoneValid = Regex.IsMatch(tbContactNo.Text, @"[()+-.0-9]*");
            if (!isPhoneValid)
            {
                MessageBox.Show("Pattern Example: 091-5275827");
                tbContactNo.Focus();
            }
        }

        private void CaderRegistrationfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentReader != null)
                CurrentReader.Dispose();
        }

        private void btnClearRegistration_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void labelLeftThumb_Click(object sender, EventArgs e)
        {
            pictureBoxLeftThumb.Image = null;
            LeftFinalFMD = null;
            LeftFMD1 = null;
            LeftFMD2 = null;
            LeftFMD3 = null;
            LeftFMD4 = null; 
        }

        private void labelRightThumb_Click(object sender, EventArgs e)
        { 
            pictureBoxRightThumb.Image = null; 
            RightFinalFMD = null;  
            RightFMD1 = null;
            RightFMD2 = null;
            RightFMD3 = null;
            RightFMD4 = null;
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }






        #region REMOVE_CADET

        private void udf_GridView()
        {

            //Show All Data
            bool Status = false;
            string StatusDetails = null;
            DataTable DtAllCadets = MainClass.MngPAFBOS.GellAllCadets(out Status, out StatusDetails);
            if (Status)
            {
                gdvAllCadet.Rows.Clear();
                // gdvSearchCadet.DataSource = DtCadetsByTapeAndCourseID;
                foreach (DataRow r in DtAllCadets.Rows)
                {
                    gdvAllCadet.Rows.Add(
                        r["CadetID"].ToString(), r["CadetName"].ToString(), r["CadetFatherName"].ToString(), r["MobileNumber"].ToString(), r["CNIC"].ToString(), r["PAKNumber"].ToString(), r["TapeName"].ToString(), r["CourseName"].ToString());
                }
            }
            else
            {
                JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
            }
        }

        #endregion

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gdvAllCadet.Rows)
            {
                row.Cells[0].Value = cbAll.Checked;
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
            SearchFilter("PAKNumber", textBoxSearchPak.Text);
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

        private void btnRemoveCadet_Click(object sender, EventArgs e)
        {
          try
          {
              bool Status = false;
              string StatusDetails = null;
               
                  MainClass.MngPAFBOS.RemoveCadet(int.Parse(Cadetidd.Text), out Status, out StatusDetails);
                         
                  if (Status)
                  {
                      JIMessageBox.ShowInformationMessage("Cadet Remove Successfully \n Thank You");
                    udf_GridView();
                    udf_Clear();
                }
          }
          catch (Exception ex)
          {
              JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex);
          }
        }

        private void udf_Clear()
        {
           txCname.Text = "";
           txFname.Text = "";
           txMobile.Text = "";
           txCnic.Text = "";
           txPakNo.Text = "";
           txTape.Text = "";
           txCourse.Text = "";
           pictureBox.Image = null;
        }

        private void gdvAllCadet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool Status = false;
                string StatusDetails = null;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row = this.gdvAllCadet.Rows[e.RowIndex];
                    Cadetidd.Text = Row.Cells["CadetID"].Value.ToString();
                    txCname.Text = Row.Cells["CadetName"].Value.ToString();
                    txFname.Text = Row.Cells["CadetFatherName"].Value.ToString();
                    txMobile.Text = Row.Cells["MobileNumber"].Value.ToString();
                    txCnic.Text = Row.Cells["PAKNumber"].Value.ToString();
                    txPakNo.Text = Row.Cells["CNIC"].Value.ToString();
                    txTape.Text = Row.Cells["Tape"].Value.ToString();
                    txCourse.Text = Row.Cells["CourseName"].Value.ToString();
                    DataTable dd = MainClass.MngPAFBOS.GetCadetsPictureByCadetID(Convert.ToInt32(Row.Cells["CadetID"].Value.ToString()));
                    pictureBox.Image = ImageClass.GetImageFromBase64(dd.Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            udf_GridView();
        }

        private void textBoxX11_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchRFID_Click(object sender, EventArgs e)
        {
            
            udf_GetCadetDataByRFIDCard();
        }
        string chk;
        DataTable dt;
        private void udf_GetCadetDataByRFIDCard()
        {
            try
            {
                bool Status = false;
                string StatusDetails = null;
                dt = MainClass.MngPAFBOS.Cadets_SelectByRFIDCard(Convert.ToString(tbSearchRFIDCard.Text), out Status, out StatusDetails);
                    if (Status)
                    {
                        udf_UpdatePanelCombo();
                        ucbSeniorOfficer.Text = Convert.ToString(dt.Rows[0]["FullName"].ToString()); // FullName
                        ucbCourse.Text = Convert.ToString(dt.Rows[0]["CourseName"].ToString()); // CourseName
                        utbCadetName.Text = Convert.ToString(dt.Rows[0]["CadetName"].ToString()); // CadetName
                        utbFatherName.Text = Convert.ToString(dt.Rows[0]["CadetFatherName"].ToString()); // CadetFatherName
                        utbPAK.Text = Convert.ToString(dt.Rows[0]["PAKNumber"].ToString()); // PAKNumber
                        utbAddress.Text = Convert.ToString(dt.Rows[0]["Address"].ToString()); // Address
                        utbCNIC.Text = Convert.ToString(dt.Rows[0]["CNIC"].ToString()); // CNIC
                        ucbBloodGroup.Text = Convert.ToString(dt.Rows[0]["BloodGroup"].ToString()); // BloodGroup
                        utbContact.Text = Convert.ToString(dt.Rows[0]["ContactNumber"].ToString()); // ContactNumber
                        utbMobile.Text = Convert.ToString(dt.Rows[0]["MobileNumber"].ToString()); // MobileNumber
                        utbRFIDCard.Text = Convert.ToString(dt.Rows[0]["RFIDCardNumber"].ToString()); // RFIDCardNumber
                        ucbTape.Text = Convert.ToString(dt.Rows[0]["TapeName"].ToString()); // TapeName
                        chk = Convert.ToString(dt.Rows[0]["Role"].ToString()); // TapeName
                        if (chk == "Cadet") uchkJuniorCadet.Checked = true;
                        else
                        if (chk == "Sr. Cadet") uchkSeniorCadet.Checked = true;
                        uCadetPic.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["Picture"].ToString()); // Picture
                        uThumbLeft.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["LThumbImage"].ToString()); // LThumbImage
                        uThumbRight.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["RThumbImage"].ToString()); // RThumbImage
                                                                                                                 //dt.Rows[0]["CreatedBy_User_ID"].ToString(); // CreatedBy_User_ID
                                                                                                                 //dt.Rows[0]["LFMD"].ToString(); // LFMD
                                                                                                                 //dt.Rows[0]["RFMD"].ToString(); // RFMD
                    }
                    else
                    {
                        if (StatusDetails == "Invalid Card")
                        {
                            JIMessageBox.ShowErrorMessage(StatusDetails);
                            ucbSeniorOfficer.Text = null;
                            ucbCourse.Text = null;
                            utbCadetName.Text = null;
                            utbFatherName.Text = null;
                            utbPAK.Text = null;
                            utbAddress.Text = null;
                            utbCNIC.Text = null;
                            ucbBloodGroup.Text = null;
                            utbContact.Text = null;
                            utbMobile.Text = null;
                            utbRFIDCard.Text = null;
                            ucbTape.Text = null;
                            uCadetPic.Image = null;
                            uThumbLeft.Image = null;
                            uThumbRight.Image = null;
                        }
                        else
                        {
                            JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                        }
                    }
            }
            catch(Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Error: "+ ex);
            }
        }
        public static int roleZreo;
        public static int SeniorOfficerZreo;
        public static int CadetTapeZreo;
        public static int CadetCoursesZreo;
        private void udf_UpdatePanelCombo()
        {
            bool Status = false;
            string StatusDetails = null;
             DataTable DtRoles = MainClass.MngPAFBOS.GetRoles(out Status, out StatusDetails);
             DataTable DtSeniorOfficer = MainClass.MngPAFBOS.usp_GetSeniorOfficerByUserID(out Status, out StatusDetails);
             DataTable DtCadetTape = MainClass.MngPAFBOS.GetCadetTapes(out Status, out StatusDetails);
             DataTable DtCadetCourses = MainClass.MngPAFBOS.GetCadetCourses(out Status, out StatusDetails);

            

            if (Status)
            {
                ListData.AutoSuggession_With_ComboBox(DtSeniorOfficer, 1, ucbSeniorOfficer, "UserID", "FullName");
                ListData.AutoSuggession_With_ComboBox(DtCadetTape, 1, ucbTape, "TapeID", "TapeName");
                ListData.AutoSuggession_With_ComboBox(DtCadetCourses, 1, ucbCourse, "CourseID", "CourseName");
            }
            List<String> BloodGroupList = new List<string>() { "-- Select Bloodgroup --", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            ucbBloodGroup.DataSource = BloodGroupList;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool Status = false;
                string StatusDetails = null; 
                
                if (Convert.ToInt32(ucbSeniorOfficer.SelectedValue) > 0 && Convert.ToInt32(ucbTape.SelectedValue) > 0 && Convert.ToInt32(ucbCourse.SelectedValue) > 0 && ucbBloodGroup.Text != "-- Select Bloodgroup --")
                {
                    MainClass.MngPAFBOS.MdlCadet mdl = new MainClass.MngPAFBOS.MdlCadet();
                    int uRadioOfCadet = 0;
                    if (chk == "Cadet") { uRadioOfCadet = 6; }
                    else
                    if (chk == "Sr. Cadet") { uRadioOfCadet = 5; }

                    if (uchkSeniorCadet.Checked)
                        uRadioOfCadet = 5;
                    if (uchkJuniorCadet.Checked)
                        uRadioOfCadet = 6;
                    
                    if (udf_Validation(utbCadetName.Text, utbFatherName.Text, utbPAK.Text, utbCNIC.Text, ucbBloodGroup.Text, utbContact.Text, utbMobile.Text, utbRFIDCard.Text, ucbSeniorOfficer.Text, ucbTape.Text, ucbCourse.Text, uRadioOfCadet) == true)
                    {

                        string LIMG = ImageClass.GetBase64StringFromImage(uThumbLeft.Image);
                        string RIMG = ImageClass.GetBase64StringFromImage(uThumbRight.Image);

                         if (LeftFinalFMD == null && RightFinalFMD == null)
                         {
                             MessageBox.Show("Finger Scan Required of Both Fingers, Scan Again");
                             return;
                         }
                        string LFMD = null;
                        string RFMD = null;
                         LFMD = Fmd.SerializeXml(LeftFinalFMD.Data);
                         RFMD = Fmd.SerializeXml(RightFinalFMD.Data);


                        mdl.SQN_User_ID = Convert.ToInt32(ucbSeniorOfficer.SelectedValue);
                        mdl.Course_ID = Convert.ToInt32(ucbCourse.SelectedValue);
                        mdl.Tape_ID = Convert.ToInt32(ucbTape.SelectedValue);
                        mdl.CreatedBy_User_ID = Convert.ToInt32(ucbSeniorOfficer.SelectedValue);
                        Bitmap img = ImageClass.Resize((Bitmap)uCadetPic.Image, new Size(100, 100), System.Drawing.Imaging.ImageFormat.Jpeg);
                        mdl.Picture = ImageClass.GetBase64StringFromImage(img); //Resize & Convert to String
                        mdl.Role_ID = uRadioOfCadet;
                        mdl.Batch = "Static_Batch";
                        mdl.CadetName = utbCadetName.Text;
                        mdl.CadetFatherName = utbFatherName.Text;
                        mdl.PAKNumber = utbPAK.Text;
                        mdl.Address = utbAddress.Text;
                        mdl.CNIC = utbCNIC.Text;
                        mdl.BloodGroup = ucbBloodGroup.Text;
                        mdl.ContactNumber = utbContact.Text;
                        mdl.MobileNumber = utbMobile.Text;
                        mdl.RFIDCardNumber = utbRFIDCard.Text;
                        mdl.LFMD = dt.Rows[0]["LFMD"].ToString();
                        mdl.RFMD = dt.Rows[0]["RFMD"].ToString();
                        mdl.RThumbImage = LIMG;
                        mdl.LThumbImage = RIMG;
                        mdl.LFMD = LFMD;
                        mdl.RFMD = RFMD;
                        MainClass.MngPAFBOS.Cadets_UpdateByRFIDCard(mdl, out Status, out StatusDetails);

                        if (Status)
                        {
                            JIMessageBox.ShowInformationMessage("Record Updated Successfully !");
                            UpdateTabClearFormFields();
                        }
                        else
                        {
                            JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                        }
                    }
                    else
                    {
                        JIMessageBox.ShowErrorMessage("Please Fill All Fields");
                    }
                }
                else
                {
                    JIMessageBox.ShowErrorMessage("Please Select Correct Fields");
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        }

        private void buttonSelectPicture_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogSelectPicture.FileName = "";
                openFileDialogSelectPicture.Filter = "Image Files(*.JPG;*.PNG;*.BMP)|*.JPG;*.PNG;*.BMP";
                openFileDialogSelectPicture.FilterIndex = 2;
                openFileDialogSelectPicture.RestoreDirectory = true;

                if (openFileDialogSelectPicture.ShowDialog() == DialogResult.OK)
                {
                    uCadetPic.ImageLocation = openFileDialogSelectPicture.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdateTebClear_Click(object sender, EventArgs e)
        {
            UpdateTabClearFormFields();
        }
    }
}
