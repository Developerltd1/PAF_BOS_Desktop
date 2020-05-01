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
    public partial class ManageClientfrm : DevComponents.DotNetBar.Office2007Form
    {
        public ManageClientfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ManageClientfrm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClientCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillClientCombo()
        {
            try
            {
                DataTable dt = new DataTable();
               
                    dt = MainClass.GetClients();
               
                
                DataRow TopItem = dt.NewRow();
                TopItem["ClientID"] = 1;
                TopItem["ClientName"] = "-- Add New Client --";
                dt.Rows.InsertAt(TopItem, 0);

                comboBoxSelectClient.DataSource = dt;
                comboBoxSelectClient.DisplayMember = "ClientName";
                comboBoxSelectClient.ValueMember = "ClientID";

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

                if(comboBoxSelectClient.Text == "-- Add New Client --")
                {
                    btnCreateClient.Text = "Create Client";
                    ClearFormFields();
                }
                else
                {
                    btnCreateClient.Text = "Update Client";

                    int ClientID =(int) comboBoxSelectClient.SelectedValue;

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                   
                        dt = MainClass.GetClientByClientID(ClientID);
                    
                    
                    DataRow Row = dt.Rows[0];
                    textBoxBusinessNature.Text = Row["BusinessNature"].ToString();
                    textBoxClientName.Text = Row["ClientName"].ToString();
                    textBoxClientNumber.Text = Row["ContactNumber"].ToString();
                    textBoxOwnerName.Text = Row["OwnerName"].ToString();
                    textBoxAddress.Text = Row["Address"].ToString();
                    checkBoxClientStatus.CheckValue = Row["Status"];
                    textBoxLoginPassword.Text = Row["Password"].ToString();
                    textBoxLoginUser.Text = Row["LoginName"].ToString();  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            try
            {
                string BusinessNature = textBoxBusinessNature.Text;
                string ClientName = textBoxClientName.Text;
                string ContactNumber = textBoxClientNumber.Text;
                string Password = textBoxLoginPassword.Text;
                string LoginUser = textBoxLoginUser.Text; 
                string OwnerName = textBoxOwnerName.Text;
                string Address = textBoxAddress.Text;

                bool Status = false;
                string StatusDetails = null;

                if (btnCreateClient.Text == "Create Client")
                {
                     
                        MainClass.CreateClient(ClientName, BusinessNature, OwnerName, ContactNumber, Address, LoginUser, Password, out Status, out StatusDetails);
                    
                }
                else if (btnCreateClient.Text == "Update Client")
                {
                    int ClientID = (int)comboBoxSelectClient.SelectedValue;

                   
                        MainClass.UpdateClient(ClientID, ClientName, BusinessNature, OwnerName, ContactNumber, Address, LoginUser, Password, checkBoxClientStatus.Checked, out Status, out StatusDetails);
                     
                }
                 
                if (Status)
                {
                    MessageBox.Show(StatusDetails, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormFields();
                    FillClientCombo();
                }
                else
                    MessageBox.Show(StatusDetails, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
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
                FillClientCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFormFields()
        {
            textBoxBusinessNature.Text = "";
            textBoxClientName.Text = "";
            textBoxClientNumber.Text = "";
            textBoxLoginPassword.Text = "";
            textBoxLoginUser.Text = ""; 
            textBoxOwnerName.Text = "";
            textBoxAddress.Text = "";

        }

        private void ManageClientfrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
