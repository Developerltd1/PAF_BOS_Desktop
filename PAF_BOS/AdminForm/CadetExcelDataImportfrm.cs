using AQDBFramwork.Messageboxes;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PAF_BOS
{
    public partial class CadetExcelDataImportfrm : DevComponents.DotNetBar.Office2007Form
    {  
        public CadetExcelDataImportfrm()
        {
            InitializeComponent();
        }
        private void UserRegistrationfrm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;  
        }

        DataTableCollection tableCollection;
        IExcelDataReader EexcelReader;
        private void buttonSelectExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();  // Browse
            browseFile.Title = "Select Excel File";
            browseFile.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls"; //Filter
            if (browseFile.ShowDialog() == DialogResult.OK) //Ture
            {
                labelFilePath1.Text = browseFile.FileName; //FileName to TextBox
                FileStream StoredFile = File.Open(browseFile.FileName, FileMode.Open, FileAccess.Read); //File Stream using FilePath/FileName
                EexcelReader  = ExcelReaderFactory.CreateReader(StoredFile); //Read ExelFileData toExcel Reader
                ExcelDataSetConfiguration ExcelTableStructureConfig = new ExcelDataSetConfiguration();  //Dynamic ExcelSheet Setting
                ExcelTableStructureConfig.ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true}; //ExcelHead Area ?
                DataSet dataSet = EexcelReader.AsDataSet(ExcelTableStructureConfig); //Excel Head Assign to Excel Reader & ExcelReader Assign to DataSet
                tableCollection =  dataSet.Tables; //DataSetTablesAssign to DataTableCollection
                comboBoxExcelSheetName.Items.Clear(); //ComboBox Clear
                foreach (DataTable singalTable in tableCollection)
                {
                    comboBoxExcelSheetName.Items.Add(singalTable.TableName); //All Excel Sheets are getting in ComboBox
                }
            }
        }
        private void comboBoxExcelSheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
           DataTable dt = tableCollection[comboBoxExcelSheetName.SelectedItem.ToString()];
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
        private void buttonExportFile_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                    foreach (DataGridViewRow row in gridViewExcel.Rows)
                    {
                            MainClass.MngPAFBOS.InsertCadetFromExcel_with_CadetHistory( row.Cells["CadetName"].Value.ToString(),
                                                                                        row.Cells["CadetFatherName"].Value.ToString(),
                                                                                        row.Cells["PAKNumber"].Value.ToString(),
                                                                                        row.Cells["Address"].Value.ToString(),
                                                                                        row.Cells["CNIC"].Value.ToString(),
                                                                                        row.Cells["BloodGroup"].Value.ToString(),
                                                                                        row.Cells["ContactNumber"].Value.ToString(),
                                                                                        row.Cells["MobileNumber"].Value.ToString(),
                                                                                        row.Cells["RFIDCardNumber"].Value.ToString(),
                                                                                        int.Parse(row.Cells["SQN_User_ID"].Value.ToString()),
                                                                                        int.Parse(row.Cells["Course_ID"].Value.ToString()),
                                                                                        int.Parse(row.Cells["Tape_ID"].Value.ToString()),
                                                                                        MainClass.UserID,
                                                                                        int.Parse(row.Cells["Role_ID"].Value.ToString()),
                                                                                        out Status, out StatusDetails);
                            if (Status == false)
                            {
                                MessageBox.Show(StatusDetails, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                    }
                    if (Status)
                    {
                        JIMessageBox.ShowInformationMessage("Excel Sheet" + tableCollection + "Exported Seccessfully");
                        //FillGridViewAssignedForms();
                    }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails +" => "+ex);
            }
        }
        private void buttonCloseFile_Click(object sender, EventArgs e)
        {
            
        }
    }
}
