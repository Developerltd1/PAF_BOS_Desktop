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
        private void frmUserAttendance_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Application.DoEvents();



            Delay = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Delay"]);
            Delay *= 2000;

            #region Clock
            DateLabel.Text = DateTime.Now.ToString("dd MMM yyyy");
            TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
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
            TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
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

                //==============START=====================//
                //ALL
                #region

                //TRUE

                if (Status == true)
                {
                    #region
                    if (SessionInformation == "SESSION EXPIRE")
                    {
                        speech.SpeakAsync("SESSION EXPIRE");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }

                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                    if (AttendanceType == "INVALID SESSION")
                    {
                        speech.SpeakAsync("INVALID SESSION");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {

                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
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
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }

                    if (AttendanceType == "BOOK IN")
                    {
                        #region BOOKIN
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.ForeColor = System.Drawing.Color.Red;
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Red;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        //if (pictureBoxPhoto.InvokeRequired)
                        //{
                        //    pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = Properties.Resources.ArrowDown; });
                        //}
                        
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.ArrowDown;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
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
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion 
                        #endregion
                    }
                    if (AttendanceType == "BOOK OUT")
                    {
                        #region BOOKIN
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.ForeColor = System.Drawing.Color.Green;
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Green;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        
                       // if (pictureBoxPhoto.InvokeRequired)
                       // {
                       //     pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = Properties.Resources.ArrowUp; });
                       // }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.ForeColor = System.Drawing.Color.Green;
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.ForeColor = System.Drawing.Color.Green;
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.ForeColor = System.Drawing.Color.Green;
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.ArrowUp;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
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
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion 
                        #endregion
                    }

                    if (AttendanceType == "Duplicate")
                    {
                        speech.SpeakAsync("Try Again after 1 Minute");
                        //display From Database
                        #region
                        
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.ForeColor = System.Drawing.Color.Black;
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Success;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                    #endregion
                }
                //FLASE
                else
                {
                    #region//if Some Error Occur
                    if (AttendanceType == "Punishment")
                    {
                        speech.SpeakAsync("PENDING PUNISHMENT CANNOT ALLOWED BOOK OUT");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.Size = new System.Drawing.Size(1764, 463);
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }

                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.Size = new System.Drawing.Size(1764, 463);
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                    else
                    {
                        #region Temporary
                        if (SessionInformation == "SESSION EXPIRE")
                        {
                            speech.SpeakAsync("SESSION EXPIRE");
                            //display From Database
                            #region
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                            }

                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                            }
                            pictureBoxMainImage.Image = Properties.Resources.Failed;
                            #endregion
                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            #region
                            pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                            }
                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                            #endregion
                        }
                        if (AttendanceType == "INVALID SESSION")
                        {
                            speech.SpeakAsync("INVALID SESSION");
                            //display From Database
                            #region
                           
             
                            if (labelDelay.InvokeRequired)
                            {

                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                            }
                            pictureBoxMainImage.Image = Properties.Resources.Failed;
                            #endregion
                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            #region
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
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                            #endregion
                        }

                        if (AttendanceType == "BOOK IN")
                        {
                            #region BOOKIN
                            speech.SpeakAsync("THANK YOU");
                            //display From Database
                            #region
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.ForeColor = System.Drawing.Color.Red;
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                            }
                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.ForeColor = System.Drawing.Color.Red;
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                            }
                            DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                            DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                            Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                            }
                            //if (pictureBoxPhoto.InvokeRequired)
                            //{
                            //    pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = Properties.Resources.ArrowDown; });
                            //}

                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                            }
                            pictureBoxMainImage.Image = Properties.Resources.ArrowDown;
                            #endregion
                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            #region
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
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                            #endregion
                            #endregion
                        }
                        if (AttendanceType == "BOOK OUT")
                        {
                            #region BOOKIN
                            speech.SpeakAsync("THANK YOU");
                            //display From Database
                            #region
                            if (labelAttendanceType.InvokeRequired)
                            {
                                labelAttendanceType.ForeColor = System.Drawing.Color.Green;
                                labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                            }
                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.ForeColor = System.Drawing.Color.Green;
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                            }
                            DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                            DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                            Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());


                            // if (pictureBoxPhoto.InvokeRequired)
                            // {
                            //     pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = Properties.Resources.ArrowUp; });
                            // }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.ForeColor = System.Drawing.Color.Green;
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.ForeColor = System.Drawing.Color.Green;
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.ForeColor = System.Drawing.Color.Green;
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                            }
                            pictureBoxMainImage.Image = Properties.Resources.ArrowUp;
                            #endregion
                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            #region
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
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                            #endregion
                            #endregion
                        }

                        if (AttendanceType == "Duplicate")
                        {
                            speech.SpeakAsync("Try Again after 1 Minute");
                            //display From Database
                            #region

                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                            }
                            DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                            DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                            Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.ForeColor = System.Drawing.Color.Black;
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                            }
                            pictureBoxMainImage.Image = Properties.Resources.Success;
                            #endregion
                            //After Delay
                            System.Threading.Thread.Sleep(Delay);
                            //display Null All 
                            #region
                            pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;

                            if (labelAttendanceTime.InvokeRequired)
                            {
                                labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                            }
                            if (pictureBoxPhoto.InvokeRequired)
                            {
                                pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                            }
                            if (labelName.InvokeRequired)
                            {
                                labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                            }
                            if (labelDelay.InvokeRequired)
                            {
                                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }

            }//Thumb Search END
            else //if not found then search for rfmd
            {
                stringfmds0 = td.AsEnumerable().Select(dr => dr.Field<string>("RFmd")).ToList();  //Access from DataTable
                th = new ComparesionOfFMD(stringfmds0, fmd.Data, IDs.GetRange(0, IDs.Count), 0, matchID); //Access from DataTable
                if (matchID.Count > 0)
                {
                    //store value in attendance table. 
                    MainClass.MngPAFBOS.CreateAttendance(matchID[0], out SessionInformation, out AttendanceType, out Status, out StatusDetails);

                    if (Status)
                    {// Found Data
                        #region
                        //display
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }

                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("hh:mm tt"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }

                        pictureBoxMainImage.Image = Properties.Resources.Success;


                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
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
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                    else
                    {   //Not Found Data
                        #region
                        //if (labelDelay.InvokeRequired)
                        //{
                        //    labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                        //}
                        //System.Threading.Thread.Sleep(Delay);
                        //if (labelDelay.InvokeRequired)
                        //{
                        //    labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        //}
                        //pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        #endregion
                        //Found_Data
                        #region
                        //display
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }

                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("hh:mm tt"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (labelDelay.InvokeRequired)
                        {
                            string First = SessionInformation.Substring(0, 18);
                            string Second = SessionInformation.Substring(19, 21);
                            SessionInformation = First + " \n " + Second;
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }

                        pictureBoxMainImage.Image = Properties.Resources.Failed_on_Pic;

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
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
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                }
                else
                {
                    #region Temporary
                    if (SessionInformation == "SESSION EXPIRE")
                    {
                        speech.SpeakAsync("SESSION EXPIRE");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }

                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                    if (AttendanceType == "INVALID SESSION")
                    {
                        speech.SpeakAsync("INVALID SESSION");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {

                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
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
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }

                    if (AttendanceType == "BOOK IN")
                    {
                        #region BOOKIN
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.ForeColor = System.Drawing.Color.Red;
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Red;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        //if (pictureBoxPhoto.InvokeRequired)
                        //{
                        //    pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = Properties.Resources.ArrowDown; });
                        //}

                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.ArrowDown;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
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
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion 
                        #endregion
                    }
                    if (AttendanceType == "BOOK OUT")
                    {
                        #region BOOKIN
                        speech.SpeakAsync("THANK YOU");
                        //display From Database
                        #region
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.ForeColor = System.Drawing.Color.Green;
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Green;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());


                        // if (pictureBoxPhoto.InvokeRequired)
                        // {
                        //     pictureBoxArrow.BeginInvoke((MethodInvoker)delegate () { pictureBoxArrow.Image = Properties.Resources.ArrowUp; });
                        // }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.ForeColor = System.Drawing.Color.Green;
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.ForeColor = System.Drawing.Color.Green;
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.ForeColor = System.Drawing.Color.Green;
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.ArrowUp;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
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
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion 
                        #endregion
                    }

                    if (AttendanceType == "Duplicate")
                    {
                        speech.SpeakAsync("Try Again after 1 Minute");
                        //display From Database
                        #region

                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm"); });
                        }
                        DataTable c = MainClass.MngPAFBOS.GetCadetsByCadetID(matchID[0]);
                        DataRow[] rows = c.Select("CadetID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["Picture"].ToString());

                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["CadetName"].ToString(); });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.ForeColor = System.Drawing.Color.Black;
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Success;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;

                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = null; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                    #endregion
                    else
                    {
                        //display From Database
                        #region
                      //  if (labelAttendanceType.InvokeRequired)
                      //  {
                      //      labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                      //  }

                        if (labelDelay.InvokeRequired)
                        {
                            speech.SpeakAsync("INVALID");
                            SessionInformation = "INVALID";
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Failed_on_Pic;
                        #endregion
                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        //display Null All 
                        #region
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = null; });
                        }
                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = null; });
                        }
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
                //==============END=====================//
               
            }
        }
        private void ShowUser()
        {
            bool Status = true;
            string StatusDetails = null;
            string AttendanceType = null;
            string SessionInformation = null;

            //display 
            DataTable c = MainClass.MngPAFBOS.GetCadetsByCardNumber(CardNo);
            if (c.Rows.Count > 0)
            {
                //store value in attendance table.
                MainClass.MngPAFBOS.CreateAttendance(int.Parse(c.Rows[0]["CadetID"].ToString()), out SessionInformation, out AttendanceType, out Status, out StatusDetails);

                if (Status)
                {
                    if (SessionInformation == "SESSION EXPIRE")
                    {
                      speech.SpeakAsync("SESSION EXPIRE");
                      labelAttendanceType.Text = AttendanceType;
                      //labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm");
                      //Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                      //pictureBoxPhoto.Image = pic;
                      //labelName.Text = c.Rows[0]["CadetName"].ToString();
                      labelDelay.Text = SessionInformation;
                      pictureBoxMainImage.Image = Properties.Resources.Failed;

                      Application.DoEvents();

                      //After Delay
                      System.Threading.Thread.Sleep(Delay);
                      //display Null All 
                      #region 
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        labelAttendanceType.Text = null;
                        labelAttendanceTime.Text = null;
                        pictureBoxPhoto.Image = null;
                        labelName.Text = null;
                        labelDelay.Text = null; 
                        #endregion
                    }
                    if (AttendanceType == "INVALID SESSION")
                    {
                      //display From Database
                      #region 
                        speech.SpeakAsync("INVALID SESSION");
                        labelAttendanceType.Text = AttendanceType;
                        labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm");
                        Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        pictureBoxPhoto.Image = pic;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelDelay.Text = SessionInformation;
                        pictureBoxMainImage.Image = Properties.Resources.Failed;
                        Application.DoEvents(); 
                        #endregion

                      //After Delay
                      System.Threading.Thread.Sleep(Delay);
                      pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                      labelAttendanceType.Text = null;
                      labelAttendanceTime.Text = null;
                      pictureBoxPhoto.Image = null;
                      labelName.Text = null;
                      labelDelay.Text = null;
                    }
                    #region BOOK IN
                    if (AttendanceType == "BOOK IN")
                    {
                      speech.SpeakAsync("THANK YOU");
                        labelAttendanceType.ForeColor = System.Drawing.Color.Red;
                        labelAttendanceType.Text = AttendanceType;
                        labelAttendanceTime.ForeColor = System.Drawing.Color.Red;
                        labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm");
                      Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                      pictureBoxPhoto.Image = pic;
                        labelName.ForeColor = System.Drawing.Color.Red;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelDelay.ForeColor = System.Drawing.Color.Red;
                        labelDelay.Text = SessionInformation;
                      pictureBoxMainImage.Image = Properties.Resources.ArrowDown;
                     // pictureBoxArrow.Image = Properties.Resources.ArrowDown;
                      Application.DoEvents();

                      //After Delay
                      System.Threading.Thread.Sleep(Delay);
                      pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                      labelAttendanceType.Text = null;
                      labelAttendanceTime.Text = null;
                      pictureBoxPhoto.Image = null;
                      pictureBoxArrow.Image = null;
                      labelName.Text = null;
                      labelDelay.Text = null;
                    }
                    #endregion
                    #region BOOK OUT
                    if (AttendanceType == "BOOK OUT")
                    {
                      speech.SpeakAsync("THANK YOU");
                      labelAttendanceType.ForeColor = System.Drawing.Color.Green;
                      labelAttendanceType.Text = AttendanceType;
                      labelAttendanceTime.ForeColor = System.Drawing.Color.Green;
                      labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm");
                      Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                      pictureBoxPhoto.Image = pic;
                        labelName.ForeColor = System.Drawing.Color.Green;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                      labelDelay.ForeColor = System.Drawing.Color.Green;
                      labelDelay.Text = SessionInformation;
                      pictureBoxMainImage.Image = Properties.Resources.ArrowUp;
                      //pictureBoxArrow.Image = Properties.Resources.ArrowUp;
                      Application.DoEvents();

                      //After Delay
                      System.Threading.Thread.Sleep(Delay);
                      pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                      labelAttendanceType.Text = null;
                      labelAttendanceTime.Text = null;
                      pictureBoxPhoto.Image = null;
                      pictureBoxArrow.Image = null;
                      labelName.Text = null;
                      labelDelay.Text = null;
                    }
                    #endregion
                    if (AttendanceType == "Duplicate")
                    {
                      speech.SpeakAsync("Try Again After 1 Minute");
                        labelAttendanceTime.ForeColor = System.Drawing.Color.Black;
                        labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm");
                        Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        pictureBoxPhoto.Image = pic;
                        labelName.ForeColor = System.Drawing.Color.Black;
                        labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelName.ForeColor = System.Drawing.Color.Black;
                        labelDelay.ForeColor = System.Drawing.Color.Black;
                        labelDelay.Text = SessionInformation;
                        pictureBoxMainImage.Image = Properties.Resources.Success;

                      Application.DoEvents();

                      //After Delay
                      System.Threading.Thread.Sleep(Delay);
                      pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                      labelAttendanceTime.Text = null;
                      pictureBoxPhoto.Image = null;
                      labelName.Text = null;
                      labelDelay.Text = null;
                    }
                }
                else
                {
                    if (AttendanceType == "Punishment")
                    {
                        #region PUNISHMANT
                        speech.SpeakAsync("PENDING PUNISHMENT CANNOT ALLOWED BOOK OUT");
                        //labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm");
                        //Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        //pictureBoxPhoto.Image = pic;
                        //labelName.Text = c.Rows[0]["CadetName"].ToString();
                        this.labelDelay.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.labelDelay.Location = new System.Drawing.Point(230, 391);
                        this.labelDelay.Size = new System.Drawing.Size(737, 54);
                        labelDelay.Text = SessionInformation;
                        pictureBoxMainImage.Image = Properties.Resources.Failed;

                        Application.DoEvents();

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        labelAttendanceTime.Text = null;
                        pictureBoxPhoto.Image = null;
                        labelName.Text = null;
                        labelDelay.Text = null;
                        this.labelDelay.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.labelDelay.Location = new System.Drawing.Point(334, 391);
                        this.labelDelay.Size = new System.Drawing.Size(537, 54);
                        #endregion
                    }

                    if (AttendanceType == "INVALID SESSION")
                    {
                        #region INVALID SESSION
                        speech.SpeakAsync("INVALID SESSION");
                        //labelAttendanceTime.Text = DateTime.Now.ToString("HH:mm");
                        //Image pic = ImageClass.GetImageFromBase64(c.Rows[0]["Picture"].ToString());
                        //pictureBoxPhoto.Image = pic;
                        //labelName.Text = c.Rows[0]["CadetName"].ToString();
                        labelDelay.Text = SessionInformation;
                        pictureBoxMainImage.Image = Properties.Resources.Failed;

                        Application.DoEvents();

                        //After Delay
                        System.Threading.Thread.Sleep(Delay);
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                        labelAttendanceTime.Text = null;
                        pictureBoxPhoto.Image = null;
                        labelName.Text = null;
                        labelDelay.Text = null;
                        #endregion
                    }
                }
            }
            else
            {
                //display From Database
                #region
                SessionInformation = "INVALID CARD";
                speech.SpeakAsync("INVALID CARD");
                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = SessionInformation; });
                pictureBoxMainImage.Image = Properties.Resources.Rfid_Card;
                //Console.Beep();
                Application.DoEvents();
                #endregion
                //After Delay
                System.Threading.Thread.Sleep(Delay);
                //display Null All 
                #region
                labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                #endregion
            }
        }
    }
}