using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DPUruNet;

namespace PAF_BOS.AdminForms
{
    public partial class ManageUserfrm : DevComponents.DotNetBar.Office2007Form
    {
        public ManageUserfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ManageUserfrm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClientComboClients();
                FillClientComboShifts();
                FillClientComboDepartments();
                CheckDevice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSelectClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectClient.Text == "System.Data.DataRowView")
                    return;
                else
                {
                    FillClientComboUsers();
                    FillClientComboShifts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnCreateUser.Enabled = false;
                if (comboBoxSelectUser.Text == "System.Data.DataRowView")
                    return;
                if (comboBoxSelectUser.Text != "-- Select User --")
                {
                    int UserID = (int)comboBoxSelectUser.SelectedValue;

                    DataTable dt = new DataTable();

                    dt = MainClass.GetUserByUserID(UserID);


                    comboBoxSelectShift.SelectedValue = dt.Rows[0]["Shift_ID"].ToString();
                    comboBoxSelectDepartment.SelectedValue = dt.Rows[0]["Department_ID"].ToString();
                    textBoxUserName.Text = dt.Rows[0]["UserName"].ToString();
                    textBoxMobileNumber.Text = dt.Rows[0]["MobileNumber"].ToString();
                    textBoxAddress.Text = dt.Rows[0]["Address"].ToString();
                    textBoxDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    checkBoxClientStatus.Checked = (bool)dt.Rows[0]["Status"];
                    string Gender = dt.Rows[0]["Gender"].ToString();
                    if (Gender == "Male")
                        radioButtonMale.Checked = true;
                    else
                        radioButtonFemale.Checked = true;

                    //Get Picture
                    if (dt.Rows[0]["UserPicture"].ToString().Length > 10)
                        pictureBoxPhoto.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["UserPicture"].ToString());

                    if (dt.Rows[0]["LImage"].ToString().Length > 10)
                        pictureBoxLeftThumb.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["LImage"].ToString());

                    if (dt.Rows[0]["RImage"].ToString().Length > 10)
                        pictureBoxRightThumb.Image = ImageClass.GetImageFromBase64(dt.Rows[0]["RImage"].ToString());

                    pictureBoxRightThumb.Tag = dt.Rows[0]["LFMD"].ToString();
                    pictureBoxLeftThumb.Tag = dt.Rows[0]["RFMD"].ToString();

                    btnCreateUser.Text = "Update User";
                    btnCreateUser.Enabled = true;
                }
                else if (comboBoxSelectClient.Text != "-- Select Client --" && comboBoxSelectUser.Text == "-- Select User --")
                {
                    ClearFormFields();
                    btnCreateUser.Enabled = true;
                    btnCreateUser.Text = "Create User";
                }
                else
                    ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnRightThumbScan_Click(object sender, EventArgs e)
        {

        }

        private void FillClientComboClients()
        {
            try
            {
                if (MainClass.IsAdmin)
                {

                    DataTable dt = new DataTable();

                    dt = MainClass.GetClients();


                    DataRow TopItem = dt.NewRow();
                    TopItem["ClientID"] = 0;
                    TopItem["ClientName"] = "-- Select Client --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectClient.DataSource = dt;
                    comboBoxSelectClient.DisplayMember = "ClientName";
                    comboBoxSelectClient.ValueMember = "ClientID";
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetClientByClientID(MainClass.UserClientID);


                    comboBoxSelectClient.DataSource = dt;
                    comboBoxSelectClient.DisplayMember = "ClientName";
                    comboBoxSelectClient.ValueMember = "ClientID";
                    comboBoxSelectClient.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboUsers()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    int ClientID = 0;
                    if (comboBoxSelectClient.Text != "-- Select Client --")
                        ClientID = (int)comboBoxSelectClient.SelectedValue;

                    DataTable dt = new DataTable();

                    dt = MainClass.GetUsersByClientID(ClientID);

                    DataRow TopItem = dt.NewRow();
                    TopItem["UserID"] = 0;
                    TopItem["UserName"] = "-- Select User --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectUser.DataSource = dt;
                    comboBoxSelectUser.DisplayMember = "UserName";
                    comboBoxSelectUser.ValueMember = "UserID";
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetUsersByClientID(MainClass.UserClientID);


                    DataRow TopItem = dt.NewRow();
                    TopItem["UserID"] = 0;
                    TopItem["UserName"] = "-- Select User --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectUser.DataSource = dt;
                    comboBoxSelectUser.DisplayMember = "UserName";
                    comboBoxSelectUser.ValueMember = "UserID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboShifts()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    int ClientID = 0;
                    if (comboBoxSelectClient.Text != "-- Select Client --")
                        ClientID = (int)comboBoxSelectClient.SelectedValue;

                    DataTable dt = new DataTable();

                    dt = MainClass.GetShiftsByClientID(ClientID);


                    DataRow TopItem = dt.NewRow();
                    TopItem["ShiftID"] = 0;
                    TopItem["Client_ID"] = 0;
                    TopItem["ShiftName"] = "-- Select Shift --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectShift.DataSource = dt;
                    comboBoxSelectShift.DisplayMember = "ShiftName";
                    comboBoxSelectShift.ValueMember = "ShiftID";
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetShiftsByClientID(MainClass.UserClientID);


                    DataRow TopItem = dt.NewRow();
                    TopItem["ShiftID"] = 0;
                    TopItem["Client_ID"] = 0;
                    TopItem["ShiftName"] = "-- Select Shift --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectShift.DataSource = dt;
                    comboBoxSelectShift.DisplayMember = "ShiftName";
                    comboBoxSelectShift.ValueMember = "ShiftID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboDepartments()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = MainClass.GetDepartments();


                DataRow TopItem = dt.NewRow();
                TopItem["DepartmentID"] = 0;
                TopItem["DepartmentName"] = "-- Select Department --";
                dt.Rows.InsertAt(TopItem, 0);

                comboBoxSelectDepartment.DataSource = dt;
                comboBoxSelectDepartment.DisplayMember = "DepartmentName";
                comboBoxSelectDepartment.ValueMember = "DepartmentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                //Validations
                if (comboBoxSelectClient.SelectedValue == null || comboBoxSelectClient.SelectedValue.ToString() == "00")
                {
                    MessageBox.Show("Client is not selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (comboBoxSelectDepartment.SelectedValue == null || comboBoxSelectDepartment.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Department is not selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxSelectShift.SelectedValue == null || comboBoxSelectShift.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Shift is not selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxUserName.Text))
                {
                    MessageBox.Show("User Name is Required !!!");
                    return;
                }

                int ClientID = (int)comboBoxSelectClient.SelectedValue;
                int DepartmentID = (int)comboBoxSelectDepartment.SelectedValue;
                int ShiftID = (int)comboBoxSelectShift.SelectedValue;
                string UserName = textBoxUserName.Text;
                string MobileNumber = textBoxMobileNumber.Text;
                string Address = textBoxAddress.Text;
                string Designation = textBoxDesignation.Text;
                string IsMaleGender;
                if (radioButtonMale.Checked)
                    IsMaleGender = "Male";
                else
                    IsMaleGender = "Female";

                bool Status = checkBoxClientStatus.Checked;

                string LFMD = null;
                string RFMD = null;
                string LIMG = ImageClass.GetBase64StringFromImage(pictureBoxLeftThumb.Image);
                string RIMG = ImageClass.GetBase64StringFromImage(pictureBoxRightThumb.Image);
                string Photo = ImageClass.GetBase64StringFromImage(pictureBoxPhoto.Image);

                if (btnCreateUser.Text == "Create User")
                {
                    if (LeftFinalFMD == null && RightFinalFMD == null)
                    {
                        MessageBox.Show("Finger Scan Required of Both Fingers");
                        return;
                    }

                    LFMD = Fmd.SerializeXml(LeftFinalFMD.Data);
                    RFMD = Fmd.SerializeXml(RightFinalFMD.Data);



                    MainClass.CreateUser(LFMD, LIMG, RFMD, RIMG, Photo, ClientID, DepartmentID, ShiftID, UserName, MobileNumber, Address, Designation, IsMaleGender, Status);


                    MessageBox.Show("User Created Successfully !!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (btnCreateUser.Text == "Update User")
                {
                    if (LeftFinalFMD == null)
                    {
                        LFMD = pictureBoxLeftThumb.Tag.ToString();
                    }
                    else
                    {
                        LFMD = Fmd.SerializeXml(LeftFinalFMD.Data);
                    }

                    if (RightFinalFMD == null)
                    {
                        RFMD = pictureBoxRightThumb.Tag.ToString();
                    }
                    else
                    {
                        RFMD = Fmd.SerializeXml(RightFinalFMD.Data);
                    }

                    int UserID = (int)comboBoxSelectUser.SelectedValue;


                    MainClass.UpdateUser(LFMD, LIMG, RFMD, RIMG, Photo, UserID, DepartmentID, ShiftID, UserName, MobileNumber, Address, Designation, IsMaleGender, Status);


                    MessageBox.Show("User Updated Successfully !!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearFormFields();
                FillClientComboUsers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFormFields();
            FillClientComboUsers();
        }

        private void ClearFormFields()
        {
            btnCreateUser.Text = "Create User";
            btnCreateUser.Enabled = false;
            textBoxUserName.Text = "";
            textBoxMobileNumber.Text = "";
            textBoxAddress.Text = "";
            textBoxDesignation.Text = "";
            radioButtonMale.Checked = true;
            checkBoxClientStatus.Checked = true;
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
                if (radioButtonRightThumb.Checked)
                {
                    pictureBoxRightThumb.Tag = captureResult;
                }
                else if (radioButtonLeftThumb.Checked)
                {
                    pictureBoxLeftThumb.Tag = captureResult;
                }
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

        private void ManageUserfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentReader != null)
                CurrentReader.Dispose();
        }

        private void ManageUserfrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBoxPhoto_Click(object sender, EventArgs e)
        {

        }
    }
}