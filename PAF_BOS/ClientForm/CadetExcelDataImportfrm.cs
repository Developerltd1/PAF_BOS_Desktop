using AQDBFramwork.Messageboxes;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Text;
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
            this.WindowState = FormWindowState.Maximized;
            Application.DoEvents();
        }

        DataTableCollection tableCollection;
        IExcelDataReader EexcelReader;
        private void buttonSelectExcelFile_Click(object sender, EventArgs e)
        {try { 
            OpenFileDialog browseFile = new OpenFileDialog();  // Browse
            browseFile.Title = "Select Excel File";
            browseFile.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls"; //Filter
            if (browseFile.ShowDialog() == DialogResult.OK) //Ture
            {
                labelFilePath1.Text = browseFile.FileName; //FileName to TextBox
                FileStream StoredFile = File.Open(browseFile.FileName, FileMode.Open, FileAccess.ReadWrite); //File Stream using FilePath/FileName
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
                StoredFile.Close();
                EexcelReader.Close();
            }
            }
            catch (Exception  ex) { JIMessageBox.ShowErrorMessage(ex.ToString()); }
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
        System.Collections.Generic.List<string> str;
        private void buttonExportFile_Click(object sender, EventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            str = new System.Collections.Generic.List<string>();
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
                                                                                  out Status, out StatusDetails
                                                                                );
                      if (Status == false)
                      {
                      }
                    }//End Foreach_Loop
                    
                    if (Status)
                    {
                      JIMessageBox.ShowInformationMessage("Excel Sheet Exported Seccessfully");
                    }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage("Some Thing went Wrong: " + StatusDetails +" => "+ex);
            }
        }
        private void buttonCloseFile_Click(object sender, EventArgs e)
        {
            labelFilePath1.Text = "";
            comboBoxExcelSheetName.Text = "";
            gridViewExcel.Rows.Clear();
        }

        private void gridViewExcel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
         
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            DataTable dt = MainClass.MngPAFBOS.GetAllCadetss();
            dataGridViewUpdate.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dataGridViewUpdate.Rows.Add(r["CadetID"].ToString(), r["CadetName"].ToString(), r["CadetFatherName"].ToString(), r["PAKNumber"].ToString(), r["Address"].ToString(), r["CNIC"].ToString(), r["BloodGroup"].ToString(), r["ContactNumber"].ToString(), r["MobileNumber"].ToString(), r["RFIDCardNumber"].ToString(), r["SQN_User_ID"].ToString(), r["Course_ID"].ToString(), r["Tape_ID"].ToString(), r["Role_ID"].ToString());
            }
        }




        private void SearchFilter(string Cell, string Criteria)
        {
            foreach (DataGridViewRow row in dataGridViewUpdate.Rows)
            {
                if (row.Cells[Cell].Value.ToString().ToLower().Contains(Criteria.ToLower()))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void textBoxCadetName_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("CadetName1", textBoxCadetName.Text);
        }

        private void textBoxPakNo_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("PAKNo2", textBoxPakNo.Text);
        }

        private void textBoxTape_TextChanged(object sender, EventArgs e)
        {
            SearchFilter("Tape_ID2", textBoxTape.Text);
        }

        private void dataGridViewUpdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool Status = false;
            string StatusDetails = null;
            try
            {
                if (e.ColumnIndex == 14)
                {
                    int CadetID = Convert.ToInt32(dataGridViewUpdate.Rows[e.RowIndex].Cells["CadetID"].Value.ToString());
                    string CadetName = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["CadetName1"].Value.ToString());
                    string CadetFatherName = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["FatherName2"].Value.ToString());
                    string PAKNumber = dataGridViewUpdate.Rows[e.RowIndex].Cells["PAKNo2"].Value.ToString();
                    string Address = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["Address2"].Value.ToString());
                    string CNIC = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["CNIC2"].Value.ToString());
                    string BloodGroup = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["BloodGroup2"].Value.ToString());
                    string ContactNumber = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["ContactNo2"].Value.ToString());
                    string MobileNumber = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["Mobile2"].Value.ToString());
                    string RFIDCardNumber = Convert.ToString(dataGridViewUpdate.Rows[e.RowIndex].Cells["RFID2"].Value.ToString());
                    int SQN_User_ID = Convert.ToInt32(dataGridViewUpdate.Rows[e.RowIndex].Cells["SQN_User_ID2"].Value.ToString());
                    int Course_ID = Convert.ToInt32(dataGridViewUpdate.Rows[e.RowIndex].Cells["Course_ID2"].Value.ToString());
                    int Tape_ID = Convert.ToInt32(dataGridViewUpdate.Rows[e.RowIndex].Cells["Tape_ID2"].Value.ToString());
                    int Role_ID = Convert.ToInt32(dataGridViewUpdate.Rows[e.RowIndex].Cells["Role_ID2"].Value.ToString());

                    MainClass.MngPAFBOS.UpdateCadet_with_InsertCadetHistory1(CadetID,SQN_User_ID,Course_ID,Tape_ID,Role_ID,
                        MainClass.UserID,"Batch",CadetName,CadetFatherName,PAKNumber,Address,
                        CNIC,BloodGroup,ContactNumber,MobileNumber,RFIDCardNumber,out Status,out StatusDetails
                                                                              );

                    if (Status)
                    {
                        JIMessageBox.ShowInformationMessage("Rocord Updated Successfully ");
                        // udf_PunishmentGridView();
                    }
                    else
                    {
                        JIMessageBox.ShowErrorMessage("Some Thing Went Wrong: " + StatusDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                JIMessageBox.ShowErrorMessage(ex.Message);
            }
        }
    }
}
