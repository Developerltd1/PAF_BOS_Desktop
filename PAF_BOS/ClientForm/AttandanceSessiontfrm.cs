using AQDBFramwork.Messageboxes; 
using System; 
using System.Data; 
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class AttandanceSessiontfrm : DevComponents.DotNetBar.Office2007Form
    {  
        public AttandanceSessiontfrm()
        {
            InitializeComponent();
        }
        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            udm_CreatedSessionNyUserGrid();
            SessionCreatedGrid();
            
            
        }
        private void SessionCreatedGrid()
        {
            bool Status = false;
            string StatusDetails = null; 
            DataTable DT = MainClass.GetCadetDataForAttendanceSession(MainClass.UserID, out Status, out StatusDetails);
            if (Status)
            {
                gridViewCadetSessionNotCreated.Rows.Clear();
                foreach (DataRow r in DT.Rows)
                {
                    gridViewCadetSessionNotCreated.Rows.Add(
                        false,
                        r["CadetID"].ToString(),
                        r["CadetName"].ToString(),
                        r["CNIC"].ToString(),
                        r["PAKNumber"].ToString(),
                        r["ContactNumber"].ToString(),
                        r["Senior Officer"].ToString(),
                        r["TapeName"].ToString(),
                        r["Expr1"].ToString()
                        );
                } 
            }
            else
            {
                JIMessageBox.ShowInformationMessage(StatusDetails);
            }
        }
        private void btnCreateAttandanceSessions_Click(object sender, EventArgs e)
        {
           
            bool Status = false;
            string StatusDetails = null;
            try
            { 
                DateTime CheckInDate = DateTime.Parse(string.Format("{0} {1}", dtCheckIn.Value.ToString("dd-MMM-yyy"), tIn.SelectedTime));
                DateTime CheckOutDate = DateTime.Parse(string.Format("{0} {1}", dtCheckOut.Value.ToString("dd-MMM-yyy"), tOut.SelectedTime));
                 
                //2,4
                int CadetID = 0;
                foreach (DataGridViewRow row in gridViewCadetSessionNotCreated.Rows)
                {

                    if ((bool)row.Cells[0].Value)
                    {
                        CadetID = int.Parse(row.Cells["CadetID"].Value.ToString());
                        MainClass.MngPAFBOS.InsertAttendanceSessions(CheckOutDate, CheckInDate,CadetID, MainClass.UserID,out Status, out StatusDetails);

                         if (Status == false)
                         {
                            MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         } 
                    }
                }

                if (Status)
                {
                    JIMessageBox.ShowInformationMessage("Attandance Session Created Successfully ");

                    udm_CreatedSessionNyUserGrid();
                }
            }catch(Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                JIMessageBox.ShowErrorMessage("Exception: " + ex);
            }
        }

        private void udm_CreatedSessionNyUserGrid()
        {
            #region udm_CreatedSessionNyUserGrid
            var yesterday = DateTime.Today;
            DataTable dt = MainClass.GetSessionByOutDate(yesterday);
            dataGridViewCreatedSession.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dataGridViewCreatedSession.Rows.Add(
                    DateTime.Parse(r["AllowedCheckOUTDateTime"].ToString()).ToString("dd-MMM-yyyy HH:mm").ToString(),
                    DateTime.Parse(r["AllowedCheckINDateTime"].ToString()).ToString("dd-MMM-yyyy HH:mm").ToString(),
                    r["CreatedBy"].ToString());
            }
            #endregion
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridViewCadetSessionNotCreated.Rows)
            {
                if (row.Visible == true)
                    row.Cells[0].Value = cbAll.Checked;
            }
        }

        private void textBoxPAKNumber_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("PAKNumber", textBoxPAKNumber.Text);
        }

        private void textBoxCadetName_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CadetName", textBoxCadetName.Text);
        }

        private void textBoxCNIC_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CNIC", textBoxCNIC.Text);
        }

        private void textBoxCourseName_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CourseName", textBoxCourseName.Text);
        }

        private void textBoxTapeName_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("TapeName", textBoxTapeName.Text);
        }

        private void textBoxSQN_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("SQN", textBoxSQN.Text);
        }

        private void SearchFilter(string Cell,string Criteria)
        {
            foreach (DataGridViewRow row in gridViewCadetSessionNotCreated.Rows)
            {
                if (row.Cells[Cell].Value.ToString().ToLower().Contains(Criteria.ToLower()))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void dtCheckOut_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = MainClass.GetSessionByOutDate(DateTime.Parse(dtCheckOut.Value.ToString("dd-MMM-yyy")));
            dataGridViewCreatedSession.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dataGridViewCreatedSession.Rows.Add(
                    DateTime.Parse(r["AllowedCheckOUTDateTime"].ToString()).ToString("dd-MMM-yyyy HH:mm").ToString(),
                    DateTime.Parse(r["AllowedCheckINDateTime"].ToString()).ToString("dd-MMM-yyyy HH:mm").ToString(),
                    r["CreatedBy"].ToString());
            }
        }

        private void tabControlSessionCreated_Click(object sender, EventArgs e)
        {
           // SessionCreatedGrid();
        }
    }
}
