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
    public partial class ChangeUserShiftfrm : DevComponents.DotNetBar.Office2007Form
    {
        public ChangeUserShiftfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ChangeUserShiftfrm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClientComboClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillClientComboClients()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetClients();


                    DataRow TopItem = dt.NewRow();
                    TopItem["ClientID"] = 0;
                    TopItem["ClientName"] = "-- Select Client --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectClient.DataSource = dt;
                    comboBoxSelectClient.DisplayMember = "ClientName";
                    comboBoxSelectClient.ValueMember = "ClientID";
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetClientByClientID(MainClass.UserClientID);

                    comboBoxSelectClient.DataSource = dt;
                    comboBoxSelectClient.DisplayMember = "ClientName";
                    comboBoxSelectClient.ValueMember = "ClientID";
                    comboBoxSelectClient.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientComboUsers()
        {
            try
            {
                if (MainClass.IsAdmin)
                {
                    int ClientID = 0;
                    if (comboBoxSelectClient.Text != "-- Select Client --")
                        ClientID = (int)comboBoxSelectClient.SelectedValue;

                    DataTable dt = new DataTable();

                    dt = MainClass.GetUsersByClientID(ClientID);

                    DataRow TopItem = dt.NewRow();
                    TopItem["UserID"] = 0;
                    TopItem["UserName"] = "-- Select User --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectUserName.DataSource = dt;
                    comboBoxSelectUserName.DisplayMember = "UserName";
                    comboBoxSelectUserName.ValueMember = "UserID";
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetUsersByClientID(MainClass.UserClientID);


                    DataRow TopItem = dt.NewRow();
                    TopItem["UserID"] = 0;
                    TopItem["UserName"] = "-- Select User --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectUserName.DataSource = dt;
                    comboBoxSelectUserName.DisplayMember = "UserName";
                    comboBoxSelectUserName.ValueMember = "UserID";
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
                    int ClientID = 0;
                    if (comboBoxSelectClient.Text != "-- Select Client --")
                        ClientID = (int)comboBoxSelectClient.SelectedValue;

                    DataTable dt = new DataTable();

                    dt = MainClass.GetShiftsByClientID(ClientID);


                    DataRow TopItem = dt.NewRow();
                    TopItem["ShiftID"] = 0;
                    TopItem["Client_ID"] = 0;
                    TopItem["ShiftName"] = "-- Select Shift --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxSelectShift.DataSource = dt;
                    comboBoxSelectShift.DisplayMember = "ShiftName";
                    comboBoxSelectShift.ValueMember = "ShiftID";
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
                }
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
                if (comboBoxSelectClient.Text == "System.Data.DataRowView")
                    return;
                else
                {
                    FillClientComboUsers();
                    FillClientComboShifts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSelectUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnChangeShift.Enabled = false;
                if (comboBoxSelectUserName.Text == "System.Data.DataRowView")
                    return;
                if (comboBoxSelectUserName.Text != "-- Select User --")
                {
                    int UserID = (int)comboBoxSelectUserName.SelectedValue;

                    DataTable dt = new DataTable();

                    dt = MainClass.GetUserByUserID(UserID);


                    comboBoxSelectShift.SelectedValue = dt.Rows[0]["Shift_ID"].ToString();

                    btnChangeShift.Enabled = true;
                }
                else
                {
                    btnChangeShift.Enabled = false;
                }
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
                    int ShiftID = (int)comboBoxSelectShift.SelectedValue;

                    DataTable dt = new DataTable();

                    dt = MainClass.GetShiftByShiftID(ShiftID);


                    textBoxShiftTiming.Text = string.Format("From : {0}   To : {1}", DateTime.Parse(dt.Rows[0]["FromTime"].ToString()).ToString("hh:MM tt"), DateTime.Parse(dt.Rows[0]["ToTime"].ToString()).ToString("hh:MM tt"));
                }
                else
                {
                    textBoxShiftTiming.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnChangeShift_Click(object sender, EventArgs e)
        {
            try
            {
                int UserID = (int)comboBoxSelectUserName.SelectedValue;
                int ShiftID = (int)comboBoxSelectShift.SelectedValue;


                MainClass.UpdateUserShift(UserID, ShiftID);


                MessageBox.Show("User Shift Updated Successfully !!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearAll()
        {
            textBoxShiftTiming.Text = "";
            comboBoxSelectShift.SelectedIndex = 0;
            FillClientComboUsers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ChangeUserShiftfrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}