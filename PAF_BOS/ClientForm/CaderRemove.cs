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
    public partial class CaderRemove : DevComponents.DotNetBar.Office2007Form
    {
        public CaderRemove()
        {
            InitializeComponent();
        } 

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void CaderRemove_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            udf_Combo();
            udf_GridView();
        }

        private void udf_GridView()
        {

            //Show All Data
            bool Status = false;
            string StatusDetails = null;
            DataTable DtAllCadets = MainClass.MngPAFBOS.GellAllCadets(out Status, out StatusDetails);
            if (Status)
            {
                gdvSearchCadet.Rows.Clear();
                // gdvSearchCadet.DataSource = DtCadetsByTapeAndCourseID;
                foreach (DataRow r in DtAllCadets.Rows)
                {
                    gdvSearchCadet.Rows.Add(false,
                        r["CadetID"].ToString(), r["CadetName"].ToString(), r["PAKNumber"].ToString(), r["CNIC"].ToString(), r["SQN"].ToString(), r["TapeName"].ToString(), r["CourseName"].ToString());
                }
            }
            else
            {
                JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
            }
        }
        private void udf_Combo()
        {
            bool Status = false;
            string StatusDetails = null;
            DataTable DtRoles = MainClass.MngPAFBOS.GetRoles(out Status, out StatusDetails);
           if (Status)
            {
               // ListData.AutoSuggession_With_ComboBox(DtSeniorOfficer, 1, cbSeniorOfficer, "UserID", "FullName");
              }
        }
    }
}
