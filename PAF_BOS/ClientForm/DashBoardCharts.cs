using AQDBFramwork.Messageboxes;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PAF_BOS
{
    public partial class DashBoardCharts : DevComponents.DotNetBar.Office2007Form
    {
        public DashBoardCharts()
        {
            InitializeComponent();
        }
        private void ribbonClientPanel1_Click(object sender, EventArgs e)
        {

        }
        private void DashBoardCharts_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            bool Status = false;
            string StatusDetails = null;
            try
            {
                DataSet ds = MainClass.MngPAFBOS.GetMainDashBoardData(out Status, out StatusDetails);
                if (Status)
                {
                   FillGridView(ds);
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + ex.Message);
            }
         }
        double[] MM;
        private void FillGridView(DataSet ds)
        {
            //Attandence
            DataTable DailyAttendance = ds.Tables["Table11"];
            labelDailyAttandance.Text = DailyAttendance.Rows[0][0].ToString();
            //SQN
            DataTable SQN = ds.Tables["Table"];
            labelTotalSQN.Text = SQN.Rows[0][0].ToString();
            //WC
            DataTable WC = ds.Tables["Table1"];
            labelTotalWC.Text = WC.Rows[0][0].ToString();
            //Cadets
            DataTable TotalCadet = ds.Tables["Table2"];
            labelTotalCadet.Text = TotalCadet.Rows[0][0].ToString();
            DataTable SeniorCadet = ds.Tables["Table3"];
            labelSenior.Text = SeniorCadet.Rows[0][0].ToString();
            DataTable JuniorCadet = ds.Tables["Table4"];
            labelJunior.Text = JuniorCadet.Rows[0][0].ToString();
           
            //--Courses--//
            #region
            DataTable dtEnglish = ds.Tables["Table5"];
            DataTable dtUrdu = ds.Tables["Table6"];
            DataTable dtComputer = ds.Tables["Table7"];
            DataTable dtScience = ds.Tables["Table8"];
            DataTable dtPakStudy = ds.Tables["Table9"];
            DataTable dtMaths = ds.Tables["Table10"];
            labelEnglish.Text = dtEnglish.Rows[0][0].ToString();
            labelUrdu.Text = dtUrdu.Rows[0][0].ToString();
            labelComputer.Text = dtComputer.Rows[0][0].ToString();
            labelScience.Text = dtScience.Rows[0][0].ToString();
            labelPakStudy.Text = dtPakStudy.Rows[0][0].ToString();
            labelMaths.Text = dtMaths.Rows[0][0].ToString();
            DataTable dtBookOutIN = ds.Tables["Table12"];
            #endregion

            DataTable DTCourses = MainClass.MngPAFBOS.GetCadetsAllCourses();
            string[] N = new string[6];
            for (int i = 0; i < DTCourses.Rows.Count; i++)
            {
                N[i] = DTCourses.Rows[i][0].ToString();
            }

            double[] M = new double[6];
            M[0] = Convert.ToDouble(dtEnglish.Rows[0][0].ToString());
            M[1] = Convert.ToDouble(dtUrdu.Rows[0][0].ToString());
            M[2] = Convert.ToDouble(dtComputer.Rows[0][0].ToString());
            M[3] = Convert.ToDouble(dtScience.Rows[0][0].ToString());
            M[4] = Convert.ToDouble(dtPakStudy.Rows[0][0].ToString());
            M[5] = Convert.ToDouble(dtMaths.Rows[0][0].ToString());
           
            this.chart1.Series[0].Points.DataBindXY(N,M);

            string[] NN = new string[2];
            NN[0] = "BookOut";
            NN[1] = "BookIn";
            MM = new double[2];
            MM[0] = Convert.ToDouble(dtBookOutIN.Rows[0][0].ToString());
            MM[1] = Convert.ToDouble(dtBookOutIN.Rows[0][1].ToString());
            
            this.chart2.Series[0].Points.AddXY(NN[0], MM[0]);
            this.chart2.Series[0].Points.AddXY(NN[1], MM[1]);
        }

        private void labelTotalWC_Click(object sender, EventArgs e)
        {

        }
    }
}
