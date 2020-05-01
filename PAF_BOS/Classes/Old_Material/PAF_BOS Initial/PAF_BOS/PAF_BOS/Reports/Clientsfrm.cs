using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAF_BOS.Reports
{
    public partial class Clientsfrm : DevComponents.DotNetBar.Office2007Form
    {
        public Clientsfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Clientsfrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Clientsfrm_Load(object sender, EventArgs e)
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
                    TopItem["ClientName"] = "-- ALL Clients --";
                    dt.Rows.InsertAt(TopItem, 0);

                    comboBoxClient.DataSource = dt;
                    comboBoxClient.DisplayMember = "ClientName";
                    comboBoxClient.ValueMember = "ClientID";
                }
                else
                {
                    DataTable dt = new DataTable();

                    dt = MainClass.GetClientByClientID(MainClass.UserClientID);

                    comboBoxClient.DataSource = dt;
                    comboBoxClient.DisplayMember = "ClientName";
                    comboBoxClient.ValueMember = "ClientID";
                    comboBoxClient.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ClientID = 0;

                if (!MainClass.IsAdmin)
                    ClientID = MainClass.UserClientID;

                if (comboBoxClient.Text == "System.Data.DataRowView")
                    return;
                else
                {
                    if (comboBoxClient.SelectedValue.ToString() == "System.Data.DataRowView")
                    {
                        LoadReport(ClientID);
                    }
                    else
                    {
                        ClientID = (int)comboBoxClient.SelectedValue;
                        LoadReport(ClientID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadReport(int clientID)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = MainClass.GetClientsDetailsReport(clientID);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}