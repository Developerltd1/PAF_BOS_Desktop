using DPUruNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AQDBFramwork.Messageboxes;
using System.Speech.Synthesis;
using DevComponents.DotNetBar;

namespace AttendanceScreen.Test
{
    public partial class UserAttendancefrm : DevComponents.DotNetBar.Office2007Form
    {
        public UserAttendancefrm()
        {

            InitializeComponent();

        }
        SpeechSynthesizer speech = new SpeechSynthesizer();

        Timer ClockTimer;
        int Delay = 0;
        #region Image_Setting
        private void DefaultImagePropertiesCard()
        {
            pictureBoxMainImage.Location = new System.Drawing.Point(450, 46);
            pictureBoxMainImage.Size = new System.Drawing.Size(311, 295);
            pictureBoxMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
        }
        private void DefaultImageProperties()
        {
            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Location = new System.Drawing.Point(450, 46); });
            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Size = new System.Drawing.Size(311, 295); });
            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage; });
            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Image = Properties.Resources.ScanFInger2; });
        }
        private void setImageProperties(PictureBox picture, int width, int height, int x, int y, PictureBoxSizeMode Type)
        {
            picture.BeginInvoke((MethodInvoker)delegate () { picture.Location = new System.Drawing.Point(x, y); });
            picture.BeginInvoke((MethodInvoker)delegate () { picture.Size = new System.Drawing.Size(width, height); });
            picture.BeginInvoke((MethodInvoker)delegate () { picture.SizeMode = Type; });
        }
        #endregion
        #region LabelX_Default
        private void setLabelXSetting(LabelX label, string textValue, int width, int height, int x, int y, Color color)
        {
            label.BeginInvoke((MethodInvoker)delegate () { label.Location = new System.Drawing.Point(x, y); });
            label.BeginInvoke((MethodInvoker)delegate () { label.Size = new System.Drawing.Size(width, height); });
            label.BeginInvoke((MethodInvoker)delegate () { label.Text = textValue; });

            label.BeginInvoke((MethodInvoker)delegate () { label.ForeColor = System.Drawing.Color.Red; label.ForeColor = color; });
        }
        #endregion
        #region labelScanRFID_Thumb
        private void labelHideNshow(bool condition)
        {
            if (labelScanRFID_Thumb.InvokeRequired)
            {
                labelScanRFID_Thumb.BeginInvoke((MethodInvoker)delegate () { labelScanRFID_Thumb.Visible = condition; });
            }
        }
        private void labelHideNshowCard(bool condition)
        {
            labelScanRFID_Thumb.Visible = condition;
        }

        private void labelHideNshowTimeDate(bool TimeCondition, bool DateCondition)
        {
            if (TimeLabel.InvokeRequired)
            {
                TimeLabel.BeginInvoke((MethodInvoker)delegate () { TimeLabel.Visible = TimeCondition; });
                DateLabel.BeginInvoke((MethodInvoker)delegate () { DateLabel.Visible = DateCondition; });
            }
        }
        private void labelHideNshowCardTimeDate(bool TimeCondition, bool DateCondition)
        {
            TimeLabel.Visible = TimeCondition;
            DateLabel.Visible = DateCondition;
        }
        #endregion
        #region pictureBoxMainImage_Default
        private void DefaultScanCenterImagelocation()
        {
            if (pictureBoxMainImage.InvokeRequired)
            {
                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                {
                    pictureBoxMainImage.Location = new System.Drawing.Point(450, 46);
                    pictureBoxMainImage.Size = new System.Drawing.Size(311, 295);
                });
            }
        }
        private void DefaultScanImagelocation()
        {
            #region DefaultScanImagelocation
            if (pictureBoxMainImage.InvokeRequired)
            {
                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                {
                    pictureBoxMainImage.Location = new System.Drawing.Point(301, 55);
                    pictureBoxMainImage.Size = new System.Drawing.Size(311, 295);
                    pictureBoxMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage; 
                    pictureBoxMainImage.Image = Properties.Resources.ScanFInger2; 
                    labelScanRFID_Thumb.Location = new System.Drawing.Point(288, 362);
                    labelScanRFID_Thumb.Size = new System.Drawing.Size(345, 36);
                });
            }
            #endregion
        }



        private void DefaultScanCenterImagelocationCard()
        {
                    pictureBoxMainImage.Location = new System.Drawing.Point(450, 46);
                    pictureBoxMainImage.Size = new System.Drawing.Size(311, 295);
        }
        private void DefaultScanImagelocationCard()
        {
                    pictureBoxMainImage.Location = new System.Drawing.Point(301, 55);
                    pictureBoxMainImage.Size = new System.Drawing.Size(311, 295);
                    pictureBoxMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                    labelScanRFID_Thumb.Location = new System.Drawing.Point(288, 362);
                    labelScanRFID_Thumb.Size = new System.Drawing.Size(345, 36);
        }







        #endregion
        private void frmUserAttendance_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Application.DoEvents();
            #region DefaultScanImagelocation
            pictureBoxMainImage.Location = new System.Drawing.Point(301, 55);
            pictureBoxMainImage.Size = new System.Drawing.Size(311, 295);
            labelScanRFID_Thumb.Location = new System.Drawing.Point(288, 362);
            labelScanRFID_Thumb.Size = new System.Drawing.Size(345, 36);
            #endregion

            Delay = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Delay"]);
            Delay *= 2000;

            #region Clock
            DateLabel.Text = DateTime.Now.ToString("dd MMM yyyy");
            TimeLabel.Text = DateTime.Now.ToString("HH"+"mm") + " HRS";
            Application.DoEvents();
            ClockTimer = new Timer();
            ClockTimer.Tick += ClockTimer_Tick;
            ClockTimer.Interval = 1000;
            ClockTimer.Enabled = true;
            #endregion

            checkInternetConnection();
            CheckDevice();
        }
 
        //CheckInternetConnection
        #region 
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        private void checkInternetConnection()
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                labelConnection.Text = "Connected";
            }
            else
            {
                labelConnection.Text = "Not Connected";
            }
        }
        #endregion

        List<Fmd> fmds = new List<Fmd>();
        ReaderCollection conectedDevices = null;   //CollectionReader Class -lib[using DPUruNet;]
        public Reader CurrentReader = null;        //Like FingerPrint Reader Class -lib[using DPUruNet.Reader;]
        internal delegate void SendMessageCallback(FingerScannerClass.Action action, object payload);
        internal void SendMessage(FingerScannerClass.Action action, object payload)
        {
            try
            {
                if (this.pictureBoxMainImage.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case FingerScannerClass.Action.SendMessage:
                            MessageBox.Show((string)payload);
                            break;
                        case FingerScannerClass.Action.SendBitmap:
                            pictureBoxMainImage.Image = (Bitmap)payload;
                            pictureBoxMainImage.Refresh();
                            break;
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
                if (!FingerScannerClass.CheckCaptureResult(captureResult))
                    return;

                // Create bitmap
                // Thumb GIf File Code
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    this.SendMessage(FingerScannerClass.Action.SendBitmap, FingerScannerClass.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }

                this.pictureBoxMainImage.Tag = captureResult;

                SearchUser((CaptureResult)captureResult);
            }
            catch (Exception ex)
            {
                this.SendMessage(FingerScannerClass.Action.SendMessage, "Error:  " + ex.Message);
            }
        }

        //Timer for Clock
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToString("dd MMM yyyy");
            TimeLabel.Text = DateTime.Now.ToString("HH"+"mm") + " HRS";
           //DateLabel.Text = DateTime.Now.ToString("dd MMM yyyy");
           //TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void labelVuLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://nsdevelopers.com");
        }
        private void UserAttendancefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentReader != null)
                CurrentReader.Dispose();
        }

        int Last;
        int Current;
        bool IsStart;
        string CardNo;
        private void UserAttendancefrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkInternetConnection();
            Current = int.Parse(DateTime.Now.ToString("ssfff"));

            if (!IsStart)
            {
                Last = Current;
                IsStart = true;
            }

            if (Current - Last < 300)
            {
                if (e.KeyChar != '\r')
                {
                    CardNo += e.KeyChar.ToString();
                    Last = Current;
                }
                else
                {
                    if (CardNo.Length == 10)
                    {
                        IsStart = false;
                        ShowUser();
                        CardNo = "";
                    }
                    else
                    {
                        CardNo = "";
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1000);
                        labelDelay.Text = null;
                    }
                }
            }
            else
            {
                CardNo = "";
                IsStart = false;
            }
        }
        private void CheckDevice()
        {
            if (conectedDevices == null)
            {
                conectedDevices = FingerScannerClass.DetactsDevices();  //Get Finger Data/Values From Reader

                if (conectedDevices.Count > 0)   //-1 .Check Device Connected Or Not
                {
                    if (conectedDevices.Count <= 0)  //0 .Device Connected But Some Problem Occurs
                    {
                        MessageBox.Show("Finger Print Device Not Found", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    CurrentReader = conectedDevices[0];
                    FingerScannerClass.OpenReader(CurrentReader);  // Checking ReaderDevice Scaning Mahnanizam OK for Scan By .Bool-Funcation();
                    FingerScannerClass.StartCaptureAsync(this.OnCaptured, CurrentReader);  //Capturing Data/Values From ReaderDevice
                }
                else
                {
                    MessageBox.Show("Finger Print Device Not Found", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void SearchUser(CaptureResult captureResult)
        {
            Fid fid = captureResult.Data;
            DataResult<Fmd> fmd = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
            DataTable td = MainClass.MngPAFBOS.GetCadets();

            List<int> IDs;
            List<int> matchID = new List<int>();
            IDs = td.AsEnumerable().Select(dr => dr.Field<int>("CadetID")).ToList();
            List<string> stringfmds0 = td.AsEnumerable().Select(dr => dr.Field<string>("LFmd")).ToList();
            ComparesionOfFMD th = new ComparesionOfFMD(stringfmds0, fmd.Data, IDs.GetRange(0, IDs.Count), 0, matchID);

            bool Status = true;
            string StatusDetails = null;
            string AttendanceType = null;
            string SessionInformation = null;
         
            #region
            //Search Using Thumb
            if (matchID.Count > 0)
            {
                //store value in attendance table.
                MainClass.MngPAFBOS.CreateAttendance(matchID[0], out SessionInformation, out AttendanceType, out Status, out StatusDetails);
                //** Left_THUMB **//
                //==============START=====================//
                #region START To AND THUMB
                if (Status == true)
                {
                    #region BOOK IN DELAY

                    if (AttendanceType == "Delayed Booked In")
                    {
                        speech.SpeakAsync("Delayed Booked In");
                        //display From Database
                        labelHideNshow(false);
                        labelHideNshowTimeDate(false, false);
                        DefaultScanCenterImagelocation();
                        if (labelAttendanceType.InvokeRequired) //AttendanceType
                        {
                            setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired) //Time
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH"+"mm") + " HRS"; });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired) //CadetPic
                        {
                            pictureBoxPhoto.ForeColor = System.Drawing.Color.Black;
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired) //CadetName
                        {
                            labelName.ForeColor = System.Drawing.Color.Black;
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelPakNumber.InvokeRequired) //CadetPak
                        {
                            labelPakNumber.ForeColor = System.Drawing.Color.Black;
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired) //StatusDetails <<Book In Time:>>
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                            setLabelXSetting(labelDelay, StatusDetails, 190, 54, 12, 398, Color.Black);

                        }
                        if (pictureBoxMainImage.InvokeRequired) ////CadetPak << ScanImage >>
                        {
                            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                            {
                                pictureBoxMainImage.Image = Properties.Resources.ArrowDownDelay;
                                setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                            });
                        }

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        labelHideNshow(true);
                        labelHideNshowTimeDate(true, true);
                        DefaultScanImagelocation();
                      //  DefaultImageProperties();
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelPakNumber.InvokeRequired)
                        {
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                    }
                    #endregion
                    #region BOOK IN

                    if (AttendanceType == "Timely Booked In")
                    {
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        labelHideNshow(false);
                        labelHideNshowTimeDate(false, false);
                        DefaultScanCenterImagelocation();
                        if (labelAttendanceType.InvokeRequired) //AttendanceType
                        {
                            setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired) //Time
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () 
                            {
                                labelAttendanceTime.Text = DateTime.Now.ToString("HH"+"mm") + " HRS";
                            });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired) //CadetPic
                        {
                            pictureBoxPhoto.ForeColor = System.Drawing.Color.Black;
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired) //CadetName
                        {
                            labelName.ForeColor = System.Drawing.Color.Black;
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelPakNumber.InvokeRequired) //CadetPak
                        {
                            labelPakNumber.ForeColor = System.Drawing.Color.Black;
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired) //StatusDetails <<Book In Time:>>
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                            setLabelXSetting(labelDelay, StatusDetails, 190, 54, 12, 398, Color.Black);

                        }
                        if (pictureBoxMainImage.InvokeRequired) ////CadetPak << ScanImage >>
                        {
                            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                            {
                                pictureBoxMainImage.Image = Properties.Resources.ArrowDown;
                                setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                            });
                        }

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        labelHideNshow(true);
                        labelHideNshowTimeDate(true, true);
                        //DefaultImageProperties();
                        DefaultScanImagelocation();
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelPakNumber.InvokeRequired)
                        {
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                    }
                    #endregion
                    #region BOOK OUT

                    if (AttendanceType == "Book Out Authorized")
                    {
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        labelHideNshow(false);
                        labelHideNshowTimeDate(false, false);
                        DefaultScanCenterImagelocation();
                        if (labelAttendanceType.InvokeRequired) //AttendanceType
                        {
                            setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired) //Time
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () 
                            {
                                string labelAttendanceTimestr = DateTime.Now.ToString("HH" + "mm") + " HRS";
                                setLabelXSetting(labelAttendanceTime, labelAttendanceTimestr, 178, 54, 230, 398, Color.Black);
                            });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired) //CadetPic
                        {
                            pictureBoxPhoto.ForeColor = System.Drawing.Color.Black;
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired) //CadetName
                        {
                            labelName.ForeColor = System.Drawing.Color.Black;
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelPakNumber.InvokeRequired) //CadetPak
                        {
                            labelPakNumber.ForeColor = System.Drawing.Color.Black;
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired) //StatusDetails <<Book In Time:>>
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                            setLabelXSetting(labelDelay, StatusDetails, 220, 54, 12, 398, Color.Black);
                        }
                        if (pictureBoxMainImage.InvokeRequired) ////CadetPak << ScanImage >>
                        {
                            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                            {
                                pictureBoxMainImage.Image = Properties.Resources.ArrowUp;
                                setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                            });
                        }

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        labelHideNshow(true);
                        labelHideNshowTimeDate(true, true);
                        DefaultScanImagelocation();
                        //DefaultImageProperties();
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelPakNumber.InvokeRequired)
                        {
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                    }
                    #endregion
                    #region Duplicate
                    if (AttendanceType == "Duplicate")
                    {
                        speech.SpeakAsync("Please Wait for 1 Minute");
                        //display From Database
                        labelHideNshow(false);
                        labelHideNshowTimeDate(false, false);
                        DefaultScanCenterImagelocation();
                        if (labelAttendanceType.InvokeRequired) //SessionInformation  << Please Wait for 1 Minute >>
                        {
                            setLabelXSetting(labelAttendanceType, AttendanceType, 680, 64, 155, 150, Color.Black);
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = SessionInformation; });
                        }
                        if (labelDelay.InvokeRequired) //StatusDetails <<(Too Many Attempts)>>
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                            setLabelXSetting(labelDelay, StatusDetails, 300, 54, 350, 210, Color.Red);
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxMainImage.InvokeRequired) //MainPic
                        {
                            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Visible = false; });
                        }
                        if (pictureBoxPhoto.InvokeRequired) //CadetPic
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired) //CadetName
                        {
                            labelName.ForeColor = System.Drawing.Color.Black;
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelPakNumber.InvokeRequired) //CadetPak
                        {
                            labelPakNumber.ForeColor = System.Drawing.Color.Black;
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                        }

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        labelHideNshow(true);
                        labelHideNshowTimeDate(true, true);
                        DefaultScanImagelocation();
                       // DefaultImageProperties();
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelPakNumber.InvokeRequired)
                        {
                            labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                        }
                        if (labelDelay.InvokeRequired) //StatusDetails <<(Too Many Attempts)>>
                        {
                            setLabelXSetting(labelDelay, StatusDetails, 845, 54, 12, 398, Color.Green);
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        if (pictureBoxMainImage.InvokeRequired) //MainPic
                        {
                            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Visible = true; });
                        }

                    }
                    #endregion
                }
                else 
                {
                    #region PUNISHMENT
                    if (AttendanceType == "Punishment")
                    {
                        speech.SpeakAsync("Bookout Un Authorized Please Consult Bookout Incharge");
                        //display From Database
                        labelHideNshow(false);
                        labelHideNshowTimeDate(false, false);
                        DefaultScanCenterImagelocation();
                        if (labelAttendanceType.InvokeRequired)
                        {
                            setLabelXSetting(labelAttendanceType, StatusDetails, 499, 64, 370, 33, Color.Black);
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            setLabelXSetting(labelDelay, SessionInformation, 537, 54, 340, 399, Color.Black);
                            labelDelay.TextAlignment = System.Drawing.StringAlignment.Center;
                        }

                        if (pictureBoxMainImage.InvokeRequired)
                        {
                            setImageProperties(pictureBoxMainImage, 311, 225, 450, 140, PictureBoxSizeMode.Zoom);
                            pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Image = Properties.Resources.Failed; });
                        }


                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        DefaultScanImagelocation();
                       // DefaultImageProperties();
                        labelHideNshow(true);
                        labelHideNshowTimeDate(true, true);
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                    }
                    #endregion
                    #region INVALID SESSION
                    if (AttendanceType == "INVALID SESSION")
                    {
                        speech.SpeakAsync("INVALID SESSION");
                        //display From Database
                        labelHideNshow(false);
                        labelHideNshowTimeDate(false, false);
                        DefaultScanCenterImagelocation();
                        if (labelDelay.InvokeRequired)
                        {
                            setLabelXSetting(labelDelay, SessionInformation, 250, 54, 505, 350, Color.Black);
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        Application.DoEvents();

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);

                        //display Null All 
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        DefaultScanImagelocation();
                        labelHideNshow(true);
                        labelHideNshowTimeDate(true, true);
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                    }
                    #endregion
                }
                #endregion
                //==============END=====================//
            } //Thumb Search END
            else //if not found then search for rfmd
            {
                stringfmds0 = td.AsEnumerable().Select(dr => dr.Field<string>("RFmd")).ToList();  //Access from DataTable
                th = new ComparesionOfFMD(stringfmds0, fmd.Data, IDs.GetRange(0, IDs.Count), 0, matchID); //Access from DataTable
                if (matchID.Count > 0)
                {
                     //store value in attendance table. 
                     MainClass.MngPAFBOS.CreateAttendance(matchID[0], out SessionInformation, out AttendanceType, out Status, out StatusDetails);
                    

                    //** Right_THUMB **//
                    //==============START=====================//
                    #region START To AND THUMB
                    if (Status == true)
                    {
                        #region BOOK IN DELAY

                        if (AttendanceType == "Delayed Booked In")
                        {
                            speech.SpeakAsync("Delayed Booked In");
                            //display From Database
                            labelHideNshow(false);
                            labelHideNshowTimeDate(false, false);
                            DefaultScanCenterImagelocation();
                            if (labelAttendanceType.InvokeRequired) //AttendanceType
                            {
                                setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                            }
                            if (labelAttendanceTime.InvokeRequired) //Time
                            {
                                labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH"+"mm") + " HRS"; });
                            }
                            DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                            DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                            Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                            if (pictureBoxPhoto.InvokeRequired) //CadetPic
                            {
                                pictureBoxPhoto.ForeColor = System.Drawing.Color.Black;
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                            }
                            if (labelName.InvokeRequired) //CadetName
                            {
                                labelName.ForeColor = System.Drawing.Color.Black;
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                            }
                            if (labelPakNumber.InvokeRequired) //CadetPak
                            {
                                labelPakNumber.ForeColor = System.Drawing.Color.Black;
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                            }
                            if (labelDelay.InvokeRequired) //StatusDetails <<Book In Time:>>
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                                setLabelXSetting(labelDelay, StatusDetails, 190, 54, 12, 398, Color.Black);

                            }
                            if (pictureBoxMainImage.InvokeRequired) ////CadetPak << ScanImage >>
                            {
                                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    pictureBoxMainImage.Image = Properties.Resources.ArrowDownDelay;
                                    setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                                });
                            }

                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            labelHideNshow(true);
                            labelHideNshowTimeDate(true, true);
                            DefaultScanImagelocation();
                            //DefaultImageProperties();
                            pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                            }
                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                            }
                            if (labelPakNumber.InvokeRequired)
                            {
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                        }
                        #endregion
                        #region BOOK IN

                        if (AttendanceType == "Timely Booked In")
                        {
                            speech.SpeakAsync("THANK YOU");
                            //display From Database
                            labelHideNshow(false);
                            labelHideNshowTimeDate(false, false);
                            DefaultScanCenterImagelocation();
                            if (labelAttendanceType.InvokeRequired) //AttendanceType
                            {
                                setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                            }
                            if (labelAttendanceTime.InvokeRequired) //Time
                            {
                                labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH"+"mm") + " HRS"; });
                            }
                            DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                            DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                            Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                            if (pictureBoxPhoto.InvokeRequired) //CadetPic
                            {
                                pictureBoxPhoto.ForeColor = System.Drawing.Color.Black;
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                            }
                            if (labelName.InvokeRequired) //CadetName
                            {
                                labelName.ForeColor = System.Drawing.Color.Black;
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                            }
                            if (labelPakNumber.InvokeRequired) //CadetPak
                            {
                                labelPakNumber.ForeColor = System.Drawing.Color.Black;
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                            }
                            if (labelDelay.InvokeRequired) //StatusDetails <<Book In Time:>>
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                                setLabelXSetting(labelDelay, StatusDetails, 190, 54, 12, 398, Color.Black);

                            }
                            if (pictureBoxMainImage.InvokeRequired) ////CadetPak << ScanImage >>
                            {
                                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    pictureBoxMainImage.Image = Properties.Resources.ArrowDown;
                                    setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                                });
                            }

                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            labelHideNshow(true);
                            labelHideNshowTimeDate(true, true);
                            //DefaultImageProperties();
                            DefaultScanImagelocation();
                            pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                            }
                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                            }
                            if (labelPakNumber.InvokeRequired)
                            {
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                        }
                        #endregion
                        #region BOOK OUT

                        if (AttendanceType == "Book Out Authorized")
                        {
                            speech.SpeakAsync("THANK YOU");
                            //display From Database
                            labelHideNshow(false);
                            labelHideNshowTimeDate(false, false);
                            DefaultScanCenterImagelocation();
                            if (labelAttendanceType.InvokeRequired) //AttendanceType
                            {
                                setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                            }
                            if (labelAttendanceTime.InvokeRequired) //Time
                            {
                                labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    string labelAttendanceTimestr = DateTime.Now.ToString("HH" + "mm") + " HRS";
                                    setLabelXSetting(labelAttendanceTime, labelAttendanceTimestr, 178, 54, 230, 398, Color.Black);
                                });
                            }
                            DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                            DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                            Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                            if (pictureBoxPhoto.InvokeRequired) //CadetPic
                            {
                                pictureBoxPhoto.ForeColor = System.Drawing.Color.Black;
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                            }
                            if (labelName.InvokeRequired) //CadetName
                            {
                                labelName.ForeColor = System.Drawing.Color.Black;
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                            }
                            if (labelPakNumber.InvokeRequired) //CadetPak
                            {
                                labelPakNumber.ForeColor = System.Drawing.Color.Black;
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                            }
                            if (labelDelay.InvokeRequired) //StatusDetails <<Book In Time:>>
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                                setLabelXSetting(labelDelay, StatusDetails, 220, 54, 12, 398, Color.Black);

                            }
                            if (pictureBoxMainImage.InvokeRequired) ////CadetPak << ScanImage >>
                            {
                                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    pictureBoxMainImage.Image = Properties.Resources.ArrowUp;
                                    setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                                });
                            }

                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            labelHideNshow(true);
                            labelHideNshowTimeDate(true, true);
                            DefaultScanImagelocation();
                           // DefaultImageProperties();
                            pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                            }
                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                            }
                            if (labelPakNumber.InvokeRequired)
                            {
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                        }
                        #endregion
                        #region Duplicate
                        if (AttendanceType == "Duplicate")
                        {
                            speech.SpeakAsync("Please Wait for 1 Minute");
                            //display From Database
                            labelHideNshow(false);
                            labelHideNshowTimeDate(false, false);
                            DefaultScanCenterImagelocation();
                            if (labelAttendanceType.InvokeRequired) //SessionInformation  << Please Wait for 1 Minute >>
                            {
                                setLabelXSetting(labelAttendanceType, AttendanceType, 680, 64, 155, 150, Color.Black);
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = SessionInformation; });
                            }
                            if (labelDelay.InvokeRequired) //StatusDetails <<(Too Many Attempts)>>
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                                setLabelXSetting(labelDelay, StatusDetails, 300, 54, 350, 210, Color.Red);
                            }
                            DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                            DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                            Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                            if (pictureBoxMainImage.InvokeRequired) //MainPic
                            {
                                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Visible = false; });
                            }
                            if (pictureBoxPhoto.InvokeRequired) //CadetPic
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                            }
                            if (labelName.InvokeRequired) //CadetName
                            {
                                labelName.ForeColor = System.Drawing.Color.Black;
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                            }
                            if (labelPakNumber.InvokeRequired) //CadetPak
                            {
                                labelPakNumber.ForeColor = System.Drawing.Color.Black;
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = "Pak/ " + rows[0]["PAKNumber"].ToString(); });
                            }

                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            labelHideNshow(true);
                            labelHideNshowTimeDate(true, true);
                            DefaultScanImagelocation();
                            //DefaultImageProperties();
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                            }
                            if (labelPakNumber.InvokeRequired)
                            {
                                labelPakNumber.BeginInvoke((MethodInvoker)delegate () { labelPakNumber.Text = null; });
                            }
                            if (labelDelay.InvokeRequired) //StatusDetails <<(Too Many Attempts)>>
                            {
                                setLabelXSetting(labelDelay, StatusDetails, 845, 54, 12, 398, Color.Green);
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                            if (pictureBoxMainImage.InvokeRequired) //MainPic
                            {
                                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Visible = true; });
                            }

                        }
                        #endregion
                    }
                    else
                    {
                        #region PUNISHMENT
                        if (AttendanceType == "Punishment")
                        {
                            speech.SpeakAsync("Bookout Un Authorized Please Consult Bookout Incharge");
                            //display From Database
                            labelHideNshow(false);
                            labelHideNshowTimeDate(false, false);
                            DefaultScanCenterImagelocation();
                            if (labelAttendanceType.InvokeRequired)
                            {
                                setLabelXSetting(labelAttendanceType, StatusDetails, 499, 64, 370, 33, Color.Black);
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                setLabelXSetting(labelDelay, SessionInformation, 537, 54, 340, 399, Color.Black);
                                labelDelay.TextAlignment = System.Drawing.StringAlignment.Center;
                            }

                            if (pictureBoxMainImage.InvokeRequired)
                            {
                                setImageProperties(pictureBoxMainImage, 311, 225, 450, 140, PictureBoxSizeMode.Zoom);
                                pictureBoxMainImage.BeginInvoke((MethodInvoker)delegate () { pictureBoxMainImage.Image = Properties.Resources.Failed; });
                            }


                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            DefaultScanImagelocation();
                           // DefaultImageProperties();
                            labelHideNshow(true);
                            labelHideNshowTimeDate(true, true);
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                            }
                        }
                        #endregion
                        #region INVALID SESSION
                        if (AttendanceType == "INVALID SESSION")
                        {
                            speech.SpeakAsync("INVALID SESSION");
                            //display From Database
                            labelHideNshow(false);
                            labelHideNshowTimeDate(false, false);
                            DefaultScanCenterImagelocation();
                            if (labelDelay.InvokeRequired)
                            {
                                setLabelXSetting(labelDelay, SessionInformation, 250, 54, 505, 350, Color.Black);
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                            }
                            pictureBoxMainImage.Image = Properties.Resources.Failed;
                            Application.DoEvents();

                            //After Delay
                            System.Threading.Thread.Sleep(Delay);

                            //display Null All 
                            pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                            DefaultScanImagelocation();
                            labelHideNshow(true);
                            labelHideNshowTimeDate(true, true);
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                        }
                        #endregion
                    }
                    #endregion
                    //==============END=====================//
                }
                else
                {
                   #region INVALID_THUMB
                    // SessionInformation = "INVALID THUMB";
                    speech.SpeakAsync("INVALID THUMB IMPRESSION");
                    labelHideNshow(false);
                    labelHideNshowTimeDate(false, false);
                    DefaultScanCenterImagelocation();
                    setLabelXSetting(labelDelay, StatusDetails, 400, 54, 420, 350, Color.Black);
                    labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = "INVALID THUMB IMPRESSION"; });
                    pictureBoxMainImage.Image = Properties.Resources.Thumb;
                    Application.DoEvents();
                    //After Delay
                    System.Threading.Thread.Sleep(Delay);
                    //display Null All 
                    labelHideNshow(true);
                    labelHideNshowTimeDate(true, true);
                    DefaultScanImagelocation();
                    setLabelXSetting(labelDelay, StatusDetails, 270, 54, 420, 350, Color.Black);
                    labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                    pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                    #endregion
                }
            }
            #endregion
        }
        private void ShowUser()
        {
            bool Status = true;
            string StatusDetails = null;
            string AttendanceType = null;
            string SessionInformation = null;

            //display 
            DataTable c = MainClass.MngPAFBOS.GetCadetsByCardNumber(CardNo);
            //From RFID Card
            #region RFID_CARD

            if (c.Rows.Count > 0)
            {
                //store value in attendance table.
                MainClass.MngPAFBOS.CreateAttendance(int.Parse(c.Rows[0]["CadetID"].ToString()), out SessionInformation, out AttendanceType, out Status, out StatusDetails);

                if (Status)
                {
                    #region BOOK IN DELAY
                    if (AttendanceType == "Delayed Booked In")
                    {
                        speech.SpeakAsync("Delayed Booked In");
                        //display From Database
                        labelHideNshowCard(false);
                        labelHideNshowCardTimeDate(false, false);
                        DefaultScanCenterImagelocationCard();
                        setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                        labelAttendanceType.Text = AttendanceType;
                        labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                        labelAttendanceTime.Text = DateTime.Now.ToString("HH"+"mm") + " HRS";
                        Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        pictureBoxPhoto.Image = pic;
                        labelName.ForeColor = System.Drawing.Color.Black;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelPakNumber.ForeColor = System.Drawing.Color.Black;
                        labelPakNumber.Text = "Pak/ " + c.Rows[0]["PAKNumber"].ToString();
                        setLabelXSetting(labelDelay, StatusDetails, 190, 54, 12, 398, Color.Black);
                        labelDelay.Text = StatusDetails;
                        setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                        pictureBoxMainImage.Image = Properties.Resources.ArrowDownDelay;

                        //After Delay
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(Delay);

                        labelHideNshowCard(true);
                        labelHideNshowCardTimeDate(true, true);
                        DefaultScanImagelocationCard();
                       // DefaultImagePropertiesCard();
                        labelAttendanceType.Text = null;
                        labelAttendanceTime.Text = null;
                        labelName.Text = null;
                        labelPakNumber.Text = null;
                        labelDelay.Text = null;
                        pictureBoxPhoto.Image = null;
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                    }
                    #endregion
                    #region BOOK IN
                    if (AttendanceType == "Timely Booked In")
                    {
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        labelHideNshowCard(false);
                        labelHideNshowCardTimeDate(false, false);
                        DefaultScanCenterImagelocationCard();
                        setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                        labelAttendanceType.Text = AttendanceType;
                        labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                        labelAttendanceTime.Text = DateTime.Now.ToString("HH"+"mm") + " HRS";
                        Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        pictureBoxPhoto.Image = pic;
                        labelName.ForeColor = System.Drawing.Color.Black;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelPakNumber.ForeColor = System.Drawing.Color.Black;
                        labelPakNumber.Text = "Pak/ " + c.Rows[0]["PAKNumber"].ToString();
                        setLabelXSetting(labelDelay, StatusDetails, 190, 54, 12, 398, Color.Black);
                        labelDelay.Text = StatusDetails;
                        setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                        pictureBoxMainImage.Image = Properties.Resources.ArrowDown;

                        //After Delay
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(Delay);

                        labelHideNshowCard(true);
                        labelHideNshowCardTimeDate(true, true);
                        DefaultScanImagelocationCard();
                       // DefaultImagePropertiesCard();
                        labelAttendanceType.Text = null;
                        labelAttendanceTime.Text = null;
                        labelName.Text = null;
                        labelPakNumber.Text = null;
                        labelDelay.Text = null;
                        pictureBoxPhoto.Image = null;
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                    }
                    #endregion
                    #region BOOK OUT
                    if (AttendanceType == "Book Out Authorized")
                    {
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        labelHideNshowCard(false);
                        labelHideNshowCardTimeDate(false, false);
                        DefaultScanCenterImagelocationCard();
                        setLabelXSetting(labelAttendanceType, AttendanceType, 486, 64, 370, 32, Color.Black);
                        labelAttendanceType.Text = AttendanceType;
                        labelAttendanceTime.ForeColor = System.Drawing.Color.Black;  //195, 398,178, 54, Default 
                        string labelAttendanceTimestr = DateTime.Now.ToString("HH"+"mm") + " HRS";
                        setLabelXSetting(labelAttendanceTime, labelAttendanceTimestr, 178, 54, 230, 398, Color.Black);

                        Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        pictureBoxPhoto.Image = pic;
                        labelName.ForeColor = System.Drawing.Color.Black;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelPakNumber.ForeColor = System.Drawing.Color.Black;
                        labelPakNumber.Text = "Pak/ " + c.Rows[0]["PAKNumber"].ToString();
                        setLabelXSetting(labelDelay, StatusDetails, 220, 54, 12, 398, Color.Black);
                        labelDelay.Text = StatusDetails;
                        setImageProperties(pictureBoxMainImage, 311, 295, 450, 92, PictureBoxSizeMode.CenterImage);
                        pictureBoxMainImage.Image = Properties.Resources.ArrowUp;

                        //After Delay
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(Delay);

                        labelHideNshowCard(true);
                        labelHideNshowCardTimeDate(true, true);
                        DefaultScanImagelocationCard();
                        labelAttendanceType.Text = null;
                        this.labelAttendanceTime.Location = new System.Drawing.Point(205, 398);
                        this.labelAttendanceTime.Size = new System.Drawing.Size(178, 54);
                        labelAttendanceTime.Text = null;
                        labelName.Text = null;
                        labelPakNumber.Text = null;
                     
                        labelDelay.Text = null;
                        pictureBoxPhoto.Image = null;
                        //DefaultImagePropertiesCard();
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                    }
                    #endregion
                    #region Duplicate
                    if (AttendanceType == "Duplicate")
                    {
                        speech.SpeakAsync("Please Wait for 1 Minute");
                        //display From Database
                        labelHideNshowCard(false);
                        labelHideNshowCardTimeDate(false, false);
                        DefaultScanCenterImagelocationCard();
                        setLabelXSetting(labelAttendanceType, SessionInformation, 680, 64, 155, 150, Color.Black);
                        labelAttendanceType.Text = SessionInformation;
                        setLabelXSetting(labelDelay, StatusDetails, 300, 54, 350, 210, Color.Red);
                        labelDelay.Text = StatusDetails;
                        Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        pictureBoxPhoto.Image = pic;
                        pictureBoxMainImage.Visible = false;
                        labelName.ForeColor = System.Drawing.Color.Black;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelPakNumber.ForeColor = System.Drawing.Color.Black;
                        labelPakNumber.Text = "Pak/ " + c.Rows[0]["PAKNumber"].ToString();
                        //After Delay
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        labelHideNshowCard(true);
                        labelHideNshowCardTimeDate(true, true);
                        DefaultScanImagelocationCard();
                        //DefaultImagePropertiesCard();
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        pictureBoxMainImage.Visible = true;
                        labelAttendanceType.Text = null;
                        labelDelay.Text = null;
                        setLabelXSetting(labelDelay, null, 845, 54, 12, 398, Color.Black);
                        pictureBoxPhoto.Image = null;
                        labelName.Text = null;
                        labelPakNumber.Text = null;
                    }
                    #endregion
                }
                else
                {
                    #region PUNISHMANT
                    if (AttendanceType == "Punishment")
                    {
                        speech.SpeakAsync("Bookout Un Authorized");
                        labelHideNshowCard(false);
                        labelHideNshowCardTimeDate(false, false);
                        DefaultScanCenterImagelocationCard();
                        speech.SpeakAsync("Bookout Un Authorized Please Consult Bookout Incharge");
                        setLabelXSetting(labelAttendanceType, StatusDetails, 499, 64, 370, 33, Color.Black);
                        setLabelXSetting(labelDelay, SessionInformation, 537, 54, 340, 399, Color.Black);
                        labelDelay.TextAlignment = System.Drawing.StringAlignment.Center;
                        setImageProperties(pictureBoxMainImage, 311, 225, 450, 140, PictureBoxSizeMode.Zoom);
                        pictureBoxMainImage.Image = Properties.Resources.Failed;

                        Application.DoEvents();
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);

                        labelHideNshowCard(true);
                        labelHideNshowCardTimeDate(true, true);
                        DefaultScanImagelocationCard();
                        //DefaultImageProperties();
                        labelDelay.Text = null;
                        labelAttendanceType.Text = null;
                    }
                    #endregion
                    #region INVALID SESSION
                    if (AttendanceType == "INVALID SESSION")
                    {
                        speech.SpeakAsync("INVALID SESSION");
                        //display From Database
                        setLabelXSetting(labelDelay, SessionInformation, 250, 54, 505, 350, Color.Black);
                        //labelDelay.Text = SessionInformation;
                        labelHideNshowCard(false);
                        labelHideNshowCardTimeDate(false, false);
                        DefaultScanCenterImagelocationCard();
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        //After Delay
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        labelHideNshowCard(true);
                        labelHideNshowCardTimeDate(true, true);
                        DefaultScanImagelocationCard();
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        labelDelay.Text = null;

                    }
                    #endregion
                }
            }
            else
            {
                #region INVALID CARD
                labelHideNshowCard(false);
                labelHideNshowCardTimeDate(false, false);
                DefaultScanCenterImagelocationCard();
                SessionInformation = "INVALID CARD";
                speech.SpeakAsync("INVALID CARD");
                labelDelay.Text = SessionInformation;
                setLabelXSetting(labelDelay, SessionInformation, 199, 54, 505, 350, Color.Black);
                pictureBoxMainImage.Image = Properties.Resources.Rfid_Card;
                //Console.Beep();
                Application.DoEvents();
                //After Delay
                System.Threading.Thread.Sleep(Delay);
                //display Null All 
                labelHideNshowCard(true);
                labelHideNshowCardTimeDate(true, true);
                DefaultScanImagelocationCard();
                labelDelay.Text = null;
                pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                #endregion
            }
            #endregion
        }

        private void labelDelay_Click(object sender, EventArgs e)
        {

        }

        private void labelAttendanceTime_Click(object sender, EventArgs e)
        {

        }
    }
}