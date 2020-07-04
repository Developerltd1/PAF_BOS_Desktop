using AQDBFramwork.Messageboxes; 
using System; 
using System.Data; 
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class GroundAttandanceSessiontfrm : DevComponents.DotNetBar.Office2007Form
    {  
        public GroundAttandanceSessiontfrm()
        {
            InitializeComponent();
        }
        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;  
          //  FillGrid();
        }
     // private void FillGrid()
     // {
     //     bool Status = false;
     //     string StatusDetails = null; 
     //     DataTable DT = MainClass.GetCadetDataByUserID(MainClass.UserID, out Status, out StatusDetails);
     //     if (Status)
     //     {
     //         gridViewCadetAttandance.Rows.Clear();
     //         foreach (DataRow r in DT.Rows)
     //         {
     //             gridViewCadetAttandance.Rows.Add(
     //                 false,
     //                 r["CadetID"].ToString(),
     //                 r["CadetName"].ToString(),
     //                 r["CNIC"].ToString(),
     //                 r["PAKNumber"].ToString(),
     //                 r["ContactNumber"].ToString(),
     //                 r["Senior Officer"].ToString(),
     //                 r["TapeName"].ToString(),
     //                 r["Expr1"].ToString()
     //                 );
     //         } 
     //     }
     //     else
     //     {
     //         JIMessageBox.ShowInformationMessage(StatusDetails);
     //     }
     // } 
       
        private void btnCreateAttandanceSessions_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            { 
                DateTime CheckInDate = DateTime.Parse(string.Format("{0} {1}", dtCheckIn.Value.ToString("dd-MMM-yyy"), tIn.SelectedTime));
                DateTime CheckOutDate = DateTime.Parse(string.Format("{0} {1}", dtCheckOut.Value.ToString("dd-MMM-yyy"), tOut.SelectedTime));

                int CadetID = 0;
                foreach (DataGridViewRow row in gridViewCadetAttandance.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        CadetID = int.Parse(row.Cells["CadetID"].Value.ToString());
                        MainClass.MngPAFBOS.InsertGroundAttendanceSessions(CheckInDate, CheckOutDate, textBoxActivityTitle.Text, richTextBoxDescription.Text,true,CadetID, MainClass.UserID,out Status, out StatusDetails);
                        if (Status == false)
                        {
                            MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

                if (Status)
                {
                    JIMessageBox.ShowInformationMessage("Attandance Session Created Successfully ");
                }
            }catch(Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                JIMessageBox.ShowErrorMessage("Exception: " + ex);
            }
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridViewCadetAttandance.Rows)
            {
                if (row.Visible == true)
                    row.Cells[0].Value = cbAll.Checked;
            }
        }

       

      

       

        private void SearchFilter(string Cell,string Criteria)
        {
            foreach (DataGridViewRow row in gridViewCadetAttandance.Rows)
            {
                if (row.Cells[Cell].Value.ToString().ToLower().Contains(Criteria.ToLower()))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void dtCheckOut_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = MainClass.GetGroundSessionByOutDate(DateTime.Parse(dtCheckOut.Value.ToString("dd-MMM-yyy")));
            dataGridViewCreatedSession.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dataGridViewCreatedSession.Rows.Add(
                    DateTime.Parse(r["CheckOutActualTime"].ToString()).ToString("dd-MMM-yyyy HH:mm").ToString(),
                    DateTime.Parse(r["ChecnInActualTime"].ToString()).ToString("dd-MMM-yyyy HH:mm").ToString(),
                    r["CreatedBy"].ToString());
            }
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
