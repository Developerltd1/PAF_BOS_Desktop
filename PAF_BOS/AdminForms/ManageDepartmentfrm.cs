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
    public partial class ManageDepartmentfrm : DevComponents.DotNetBar.Office2007Form
    {
        public ManageDepartmentfrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        } 

        private void ManageDepartmentfrm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClientComboDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillClientComboDepartments()
        {
            try
            { 
                DataTable dt = new DataTable();
                
                    dt = MainClass.GetDepartments();
                
                
                DataRow TopItem = dt.NewRow();
                TopItem["DepartmentID"] = 0;
                TopItem["DepartmentName"] = "-- Add New Department --";
                dt.Rows.InsertAt(TopItem, 0);

                comboBoxSelectDepartment.DataSource = dt;
                comboBoxSelectDepartment.DisplayMember = "DepartmentName";
                comboBoxSelectDepartment.ValueMember = "DepartmentID";

                btnCreateDepartment.Text = "Create Department"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        { 
            try
            {
                if (comboBoxSelectDepartment.Text == "System.Data.DataRowView")
                    return;

                if (comboBoxSelectDepartment.Text == "-- Add New Department --")
                {
                    btnCreateDepartment.Text = "Create Department";
                    textBoxDepartmentName.Text = "";
                }
                else
                {
                    btnCreateDepartment.Text = "Update Department";

                    int DepartmentID = (int)comboBoxSelectDepartment.SelectedValue;

                    DataTable dt = new DataTable();
                   
                        dt = MainClass.GetDepartmentByDepartmentID(DepartmentID);
                    

                    DataRow Row = dt.Rows[0];
                    textBoxDepartmentName.Text = Row["DepartmentName"].ToString(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnCreateDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                string DepartmentName = textBoxDepartmentName.Text;
                int DepartmentID = (int)comboBoxSelectDepartment.SelectedValue;

                if (btnCreateDepartment.Text == "Create Department")
                {

                    
                        MainClass.CreateDepartment(DepartmentName);
                   
                     
                    MessageBox.Show("Department Successfully Created !!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxDepartmentName.Text = "";
                    FillClientComboDepartments();
                }
                else if (btnCreateDepartment.Text == "Update Department")
                {
                  
                        MainClass.UpdateDepartment(DepartmentID, DepartmentName);
                    
                     
                    MessageBox.Show("Department Successfully Updated !!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxDepartmentName.Text = "";
                    FillClientComboDepartments();
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
                textBoxDepartmentName.Text = "";
                FillClientComboDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageDepartmentfrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
