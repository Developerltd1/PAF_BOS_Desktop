using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAF_BOS.AdminForms
{
    public partial class ManageShiftfrm : DevComponents.DotNetBar.Office2007Form
    {
        public ManageShiftfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ManageShiftfrm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClientComboClients();

                ShiftStartTimeControl.SelectedDateTime = DateTime.Now;
                ShiftEndTimeControl.SelectedDateTime = DateTime.Now; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
        private void comboBoxSelectClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectClient.Text == "System.Data.DataRowView" || comboBoxSelectClient.Text == "-- Select Client --")
                    return;
                else
                    FillClientComboShifts(); 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSelectShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectShift.Text == "System.Data.DataRowView")
                    return;
                if (comboBoxSelectShift.Text != "-- Select Shift --")
                {
                    btnCreateShift.Text = "Update Shift";
                    int ShiftID = (int)comboBoxSelectShift.SelectedValue;

                    DataTable dt = new DataTable();
                 
                        dt = MainClass.GetShiftByShiftID(ShiftID);
                   
                     
                    DataRow Row = dt.Rows[0];
                    textBoxShiftName.Text = Row["ShiftName"].ToString();
                    ShiftStartTimeControl.SelectedDateTime = DateTime.Parse(Row["FromTime"].ToString());
                    ShiftEndTimeControl.SelectedDateTime = DateTime.Parse(Row["ToTime"].ToString()); 
                }
                else
                {
                    ClearFormFields(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateShift_Click(object sender, EventArgs e)
        {
            try
            {
                string ShiftName = textBoxShiftName.Text;
                DateTime StartTime = ShiftStartTimeControl.SelectedDateTime;
                DateTime EndTime = ShiftEndTimeControl.SelectedDateTime; 
                int ClientID = (int)comboBoxSelectClient.SelectedValue;
                int ShiftID = (int)comboBoxSelectShift.SelectedValue;

                if (btnCreateShift.Text == "Create Shift")
                { 
                   
                        MainClass.CreateShift(ClientID, ShiftName, StartTime, EndTime);
                     

                    MessageBox.Show("Shift Successfully Created !!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormFields();
                    FillClientComboClients(); 
                }
                else if (btnCreateShift.Text == "Update Shift")
                {
                    
                        MainClass.UpdateShift(ShiftID, ShiftName, StartTime, EndTime);
                     

                    MessageBox.Show("Shift Successfully Updated !!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormFields();
                    FillClientComboClients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { 
            try
            {
                ClearFormFields(); 
                FillClientComboClients(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFormFields()
        {
            btnCreateShift.Text = "Create Shift";
            textBoxShiftName.Text = ""; 
        } 

        private void FillClientComboClients()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    
                        dt = MainClass.GetClients();
                   
                    
                    DataRow TopItem = dt.NewRow();
                    TopItem["ClientID"] = 1;
                    TopItem["ClientName"] = "-- Select Client --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectClient.DataSource = dt;
                    comboBoxSelectClient.DisplayMember = "ClientName";
                    comboBoxSelectClient.ValueMember = "ClientID";

                    btnCreateShift.Enabled = false;

                    //Clear Shift Combo
                    DataTable d = new DataTable();
                    comboBoxSelectShift.DataSource = d;
                }
                else
                {
                    DataTable dt = new DataTable();
                   
                        dt = MainClass.GetClientByClientID(MainClass.UserClientID);
                     

                    comboBoxSelectClient.DataSource = dt;
                    comboBoxSelectClient.DisplayMember = "ClientName";
                    comboBoxSelectClient.ValueMember = "ClientID";
                    comboBoxSelectClient.Enabled = false;

                    btnCreateShift.Enabled = true;
                    FillClientComboShifts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboShifts()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    int ClientID = (int)comboBoxSelectClient.SelectedValue;

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                  
                        dt = MainClass.GetShiftsByClientID(ClientID);
                    
                     
                    DataRow TopItem = dt.NewRow();
                    TopItem["ShiftID"] = 0;
                    TopItem["Client_ID"] = 0;
                    TopItem["ShiftName"] = "-- Select Shift --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectShift.DataSource = dt;
                    comboBoxSelectShift.DisplayMember = "ShiftName";
                    comboBoxSelectShift.ValueMember = "ShiftID";

                    btnCreateShift.Text = "Create Shift";

                    btnCreateShift.Enabled = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                  
                        dt = MainClass.GetShiftsByClientID(MainClass.UserClientID);
                  

                    DataRow TopItem = dt.NewRow();
                    TopItem["ShiftID"] = 0;
                    TopItem["Client_ID"] = 0;
                    TopItem["ShiftName"] = "-- Select Shift --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectShift.DataSource = dt;
                    comboBoxSelectShift.DisplayMember = "ShiftName";
                    comboBoxSelectShift.ValueMember = "ShiftID";

                    btnCreateShift.Text = "Create Shift";

                    btnCreateShift.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageShiftfrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
