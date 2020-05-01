using DPUruNet;
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
    public partial class UserAttendancefrm : DevComponents.DotNetBar.Office2007Form
    {
        public UserAttendancefrm()
        {
            InitializeComponent();  
        }

        Timer ClockTimer;
        int ClientID = 0;
        int Delay = 0;
        private void frmUserAttendance_Load(object sender, EventArgs e)
        {  
            Delay = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Delay"]);
            Delay *= 1000;
            MainClass.IsLoginPageOpen = false; //Control Program Flow
            MainClass.UserClientID = 1;
            pictureBoxCompanyLogo.ImageLocation = "Client.png";

            #region Clock
            DateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TimeLabel.Text = DateTime.Now.ToString("hh:mm tt");
            Application.DoEvents();
            ClockTimer = new Timer();
            ClockTimer.Tick += ClockTimer_Tick;
            ClockTimer.Interval = 1000;
            ClockTimer.Enabled = true;
            #endregion

            CheckDevice();
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
        List<Fmd> fmds = new List<Fmd>(); 
        ReaderCollection conectedDevices = null;
        public Reader CurrentReader = null;
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
                if (!FingerScannerClass.CheckCaptureResult(captureResult)) return;

                // Create bitmap
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
         

        public void SearchUser(CaptureResult captureResult)
        {
            Fid fid = captureResult.Data;
            DataResult<Fmd> fmd = FeatureExtraction.CreateFmdFromFid(fid, Constants.Formats.Fmd.ANSI);
            DataTable td = new DataTable();
           
                td = MainClass.GetUsersByClientID(ClientID);
              
            List<int> IDs;
            List<int> matchID = new List<int>();
            IDs = td.AsEnumerable().Select(dr => dr.Field<int>("UserID")).ToList();
            List<string> stringfmds0 = td.AsEnumerable().Select(dr => dr.Field<string>("LFmd")).ToList();
            ComparesionOfFMD th = new ComparesionOfFMD(stringfmds0, fmd.Data, IDs.GetRange(0, IDs.Count), 0, matchID);
            bool Status = false;
            string StatusDetails = null;
            string AttendanceType = null;

            if (matchID.Count > 0)
            { 
                //store value in attendance table.
                 
                    MainClass.CreateAttendance(ClientID, matchID[0],out AttendanceType, out Status, out StatusDetails);
               
               
                if (Status)
                {
                    //display 
                    if (labelAttendanceType.InvokeRequired)
                    {
                        labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                    }

                    if (labelAttendanceTime.InvokeRequired)
                    {
                        labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("hh:MM tt"); });
                    }

                    DataRow[] rows = td.Select("UserID=" + matchID[0]);
                    Image pic = ImageClass.GetImageFromBase64(rows[0]["UserPicture"].ToString());

                    if (pictureBoxPhoto.InvokeRequired)
                    {
                        pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                    }

                    if (labelName.InvokeRequired)
                    {
                        labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["UserName"].ToString(); });
                    }

                    pictureBoxMainImage.Image = Properties.Resources.Success;
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
                }
                else
                {
                    if (labelDelay.InvokeRequired)
                    {
                        labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                    }
                    System.Threading.Thread.Sleep(Delay);
                    if (labelDelay.InvokeRequired)
                    {
                        labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                    }

                    pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                }
            }
            else //if not found then search for rfmd
            {
                stringfmds0 = td.AsEnumerable().Select(dr => dr.Field<string>("RFmd")).ToList();
                th = new ComparesionOfFMD(stringfmds0, fmd.Data, IDs.GetRange(0, IDs.Count), 0, matchID);

                if (matchID.Count > 0)
                {
                    //store value in attendance table.
                   
                        MainClass.CreateAttendance(ClientID, matchID[0] ,out AttendanceType, out Status, out StatusDetails);
                   

                    if (Status)
                    {
                        //display
                        if (labelAttendanceType.InvokeRequired)
                        {
                            labelAttendanceType.BeginInvoke((MethodInvoker)delegate () { labelAttendanceType.Text = AttendanceType; });
                        }

                        if (labelAttendanceTime.InvokeRequired)
                        {
                            labelAttendanceTime.BeginInvoke((MethodInvoker)delegate () { labelAttendanceTime.Text = DateTime.Now.ToString("hh:MM tt"); });
                        }

                        DataRow[] rows = td.Select("UserID=" + matchID[0]);
                        Image pic = ImageClass.GetImageFromBase64(rows[0]["UserPicture"].ToString());
                        if (pictureBoxPhoto.InvokeRequired)
                        {
                            pictureBoxPhoto.BeginInvoke((MethodInvoker)delegate () { pictureBoxPhoto.Image = pic; });
                        }
                        if (labelName.InvokeRequired)
                        {
                            labelName.BeginInvoke((MethodInvoker)delegate () { labelName.Text = rows[0]["UserName"].ToString(); });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.Success;
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
                    }
                    else
                    {
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = StatusDetails; });
                        }
                        System.Threading.Thread.Sleep(Delay);
                        if (labelDelay.InvokeRequired)
                        {
                            labelDelay.BeginInvoke((MethodInvoker)delegate () { labelDelay.Text = null; });
                        }
                        pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                    }
                }
                else
                {
                    pictureBoxMainImage.Image = Properties.Resources.Failed;
                    System.Threading.Thread.Sleep(Delay);
                    pictureBoxMainImage.Image = Properties.Resources.ScanFInger2;
                }
            }
        }


        //Timer for Clock
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TimeLabel.Text = DateTime.Now.ToString("hh:mm tt"); 
        }
 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.IsLoginPageOpen = true; //Control Program Flow
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
        //Open VU Link
        private void labelVuLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vu.edu.pk");
        }

        private void UserAttendancefrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CurrentReader != null)
                CurrentReader.Dispose();
        }
    }
}
