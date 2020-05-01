using AQDBFramwork.Messageboxes;
using ExcelDataReader;
using PAF_BOS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class Method2CadetExcelDataImportfrm : DevComponents.DotNetBar.Office2007Form
    {  
        public Method2CadetExcelDataImportfrm()
        {
            InitializeComponent();
        }
        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;  
        }

        DataTableCollection tableCollection;
        IExcelDataReader EexcelReader;
        OpenFileDialog browseFile;
       
        List<ModelForExcel> mList;
        public void ImportDataFromExcel()
        {
            try
            {
                //create Excel Connection with ExcelFilePath 
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source= " + browseFile.FileName + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                //string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PAFBOS_ConnectionString"].ToString();
               
                //series of commands to bulk copy data from the excel file into our sql table   
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                string myexceldataquery = "select CadetName, CadetFatherName, PAKNumber from "+ comboBoxExcelSheetName.SelectedItem.ToString() + " ";
                 oledbconn.Open();
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                   OleDbDataReader dr = oledbcmd.ExecuteReader();

                // SqlBulkCopy bulkcopy = new SqlBulkCopy(ConnectionString) { DestinationTableName = ssqltable }; //SQL COnnection
                 mList = new List<ModelForExcel>();
                ModelForExcel m = new ModelForExcel();

                while (dr.Read())
                {
                    m.CadetName = dr["CadetName"].ToString();
                    m.Fname = dr["CadetFatherName"].ToString();
                    m.PakNo = dr["PAKNumber"].ToString();
                    m.Address = dr["Address"].ToString();
                    m.Cnic = dr["CNIC"].ToString();
                    m.Blood = dr["BloodGroup"].ToString();
                    m.Contact = dr["ContactNumber"].ToString();
                    m.Mobile = dr["MobileNumber"].ToString();
                    m.Pic = dr["Picture"].ToString();
                    m.RFID = dr["RFIDCardNumber"].ToString();
                    m.SQN_UserID = dr["SQN_User_ID"].ToString();
                    m.Course_ID = dr["Course_ID"].ToString();
                    m.Tape_ID = dr["Tape_ID"].ToString();
                    m.Role_ID = dr["Role_ID"].ToString();

                    mList.Add(m);
                    //bulkcopy.WriteToServer(dr);
                }
                gridViewExcel.DataSource = mList;
                dr.Close();
                oledbconn.Close();
                //DataTable dt = mList.GetEnumerator;
                //foreach (var gridViewExcel.Rows in strList)
                {

                }
                //Label1.Text = "File imported into sql server successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());  
            }
        }

        private void buttonExportFile_Click(object sender, EventArgs e)
        {
            ImportDataFromExcel();



            //bool Status = false;
            //string StatusDetails = null;
            //try
            //{
            //    foreach (DataGridViewRow row in gridViewExcel.Rows)
            //    {
            //        MainClass.MngPAFBOS.InsertCadetFromExcel_with_CadetHistory( row.Cells["CadetName"].Value.ToString(),
            //                                                                    row.Cells["CadetFatherName"].Value.ToString(),
            //                                                                    row.Cells["PAKNumber"].Value.ToString(),
            //                                                                    row.Cells["Address"].Value.ToString(),
            //                                                                    row.Cells["CNIC"].Value.ToString(),
            //                                                                    row.Cells["BloodGroup"].Value.ToString(),
            //                                                                    row.Cells["ContactNumber"].Value.ToString(),
            //                                                                    row.Cells["MobileNumber"].Value.ToString(),
            //                                                                    row.Cells["RFIDCardNumber"].Value.ToString(),
            //                                                                    int.Parse(row.Cells["SQN_User_ID"].Value.ToString()),
            //                                                                    int.Parse(row.Cells["Course_ID"].Value.ToString()),
            //                                                                    int.Parse(row.Cells["Tape_ID"].Value.ToString()),
            //                                                                    MainClass.UserID,
            //                                                                    int.Parse(row.Cells["Role_ID"].Value.ToString()),
            //                                                                    out Status, out StatusDetails);
            //        if (Status == false)
            //        {
            //            MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            break;
            //        }
            //    }
            //    if (Status)
            //    {
            //        JIMessageBox.ShowInformationMessage("Excel Sheet Exported Seccessfully");
            //        //FillGridViewAssignedForms();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails + " => " + ex);
            //}
        }
        DataTable dt;
        private void comboBoxExcelSheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
           dt = tableCollection[comboBoxExcelSheetName.SelectedItem.ToString()];
           //gridViewExcel.DataSource = dt;
            gridViewExcel.Rows.Clear();
            foreach (DataRow Col in dt.Rows)
            {
                gridViewExcel.Rows.Add( Col["CadetName"].ToString(),
                                        Col["CadetFatherName"].ToString(),
                                        Col["PAKNumber"].ToString(),
                                        Col["Address"].ToString(),
                                        Col["CNIC"].ToString(),
                                        Col["BloodGroup"].ToString(),
                                        Col["ContactNumber"].ToString(),
                                        Col["MobileNumber"].ToString(),
                                        Col["RFIDCardNumber"].ToString(),
                                        Col["SQN_User_ID"].ToString(),
                                        Col["Course_ID"].ToString(),
                                        Col["Tape_ID"].ToString(),
                                        Col["Role_ID"].ToString()
                                       );
            }
        }

        private void buttonSelectExcelFile_Click(object sender, EventArgs e)
        {

            browseFile = new OpenFileDialog();  // Browse
            browseFile.Title = "Select Excel File";
            browseFile.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls"; //Filter
            if (browseFile.ShowDialog() == DialogResult.OK) //Ture
            {
                //ImportDataFromExcel(browseFile.FileName);
                labelFilePath1.Text = browseFile.FileName; //FileName to TextBox
                FileStream StoredFile = File.Open(browseFile.FileName, FileMode.Open, FileAccess.Read); //File Stream using FilePath/FileName
                EexcelReader = ExcelReaderFactory.CreateReader(StoredFile); //Read ExelFileData toExcel Reader
                ExcelDataSetConfiguration ExcelTableStructureConfig = new ExcelDataSetConfiguration();  //Dynamic ExcelSheet Setting
                ExcelTableStructureConfig.ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }; //ExcelHead Area ?
                DataSet dataSet = EexcelReader.AsDataSet(ExcelTableStructureConfig); //Excel Head Assign to Excel Reader & ExcelReader Assign to DataSet
                tableCollection = dataSet.Tables; //DataSetTablesAssign to DataTableCollection
                comboBoxExcelSheetName.Items.Clear(); //ComboBox Clear
                foreach (DataTable singalTable in tableCollection)
                {

                    EexcelReader.Read();
                    //EexcelReader[""].ToString();
                    comboBoxExcelSheetName.Items.Add(singalTable.TableName); //All Excel Sheets are getting in ComboBox
                }
            }
        }
    }
}
