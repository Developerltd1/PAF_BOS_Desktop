namespace PAF_BOS
{
    partial class Method2CadetExcelDataImportfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Method2CadetExcelDataImportfrm));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.gridViewExcel = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CadetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CadetFatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAKNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BloodGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFIDCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQN_User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tape_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonCloseFile = new DevComponents.DotNetBar.ButtonX();
            this.labelFilePath1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonExportFile = new DevComponents.DotNetBar.ButtonX();
            this.buttonSelectExcelFile = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxExcelSheetName = new System.Windows.Forms.ComboBox();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcel)).BeginInit();
            this.ribbonClientPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198))))));
            // 
            // gridViewExcel
            // 
            this.gridViewExcel.AllowUserToAddRows = false;
            this.gridViewExcel.AllowUserToDeleteRows = false;
            this.gridViewExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewExcel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewExcel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CadetName,
            this.CadetFatherName,
            this.PAKNumber,
            this.Address,
            this.CNIC,
            this.BloodGroup,
            this.ContactNumber,
            this.MobileNumber,
            this.RFIDCardNumber,
            this.SQN_User_ID,
            this.Course_ID,
            this.Tape_ID,
            this.Role_ID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewExcel.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewExcel.EnableHeadersVisualStyles = false;
            this.gridViewExcel.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewExcel.Location = new System.Drawing.Point(10, 14);
            this.gridViewExcel.MultiSelect = false;
            this.gridViewExcel.Name = "gridViewExcel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewExcel.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridViewExcel.Size = new System.Drawing.Size(940, 322);
            this.gridViewExcel.TabIndex = 59;
            // 
            // CadetName
            // 
            this.CadetName.HeaderText = "CadetName";
            this.CadetName.Name = "CadetName";
            // 
            // CadetFatherName
            // 
            this.CadetFatherName.HeaderText = "Father Name";
            this.CadetFatherName.Name = "CadetFatherName";
            // 
            // PAKNumber
            // 
            this.PAKNumber.HeaderText = "PAK Number";
            this.PAKNumber.Name = "PAKNumber";
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // CNIC
            // 
            this.CNIC.HeaderText = "CNIC";
            this.CNIC.Name = "CNIC";
            // 
            // BloodGroup
            // 
            this.BloodGroup.HeaderText = "BloodGroup";
            this.BloodGroup.Name = "BloodGroup";
            // 
            // ContactNumber
            // 
            this.ContactNumber.HeaderText = "Contact No";
            this.ContactNumber.Name = "ContactNumber";
            // 
            // MobileNumber
            // 
            this.MobileNumber.HeaderText = "Mobile No";
            this.MobileNumber.Name = "MobileNumber";
            // 
            // RFIDCardNumber
            // 
            this.RFIDCardNumber.HeaderText = "RFID";
            this.RFIDCardNumber.Name = "RFIDCardNumber";
            // 
            // SQN_User_ID
            // 
            this.SQN_User_ID.HeaderText = "SQN_User_ID";
            this.SQN_User_ID.Name = "SQN_User_ID";
            // 
            // Course_ID
            // 
            this.Course_ID.HeaderText = "Course_ID";
            this.Course_ID.Name = "Course_ID";
            // 
            // Tape_ID
            // 
            this.Tape_ID.HeaderText = "Tape_ID";
            this.Tape_ID.Name = "Tape_ID";
            // 
            // Role_ID
            // 
            this.Role_ID.HeaderText = "Role_ID";
            this.Role_ID.Name = "Role_ID";
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.groupPanel2);
            this.ribbonClientPanel1.Controls.Add(this.groupPanel1);
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, -1);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(984, 533);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel1.TabIndex = 5;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.buttonCloseFile);
            this.groupPanel2.Controls.Add(this.labelFilePath1);
            this.groupPanel2.Controls.Add(this.buttonExportFile);
            this.groupPanel2.Controls.Add(this.buttonSelectExcelFile);
            this.groupPanel2.Controls.Add(this.comboBoxExcelSheetName);
            this.groupPanel2.Controls.Add(this.labelX13);
            this.groupPanel2.Controls.Add(this.labelX10);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(7, 24);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(966, 106);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 82;
            this.groupPanel2.Text = "Excel File";
            // 
            // buttonCloseFile
            // 
            this.buttonCloseFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCloseFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCloseFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseFile.Location = new System.Drawing.Point(792, 4);
            this.buttonCloseFile.Name = "buttonCloseFile";
            this.buttonCloseFile.Size = new System.Drawing.Size(159, 72);
            this.buttonCloseFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCloseFile.TabIndex = 68;
            this.buttonCloseFile.Text = "Close File";
            // 
            // labelFilePath1
            // 
            // 
            // 
            // 
            this.labelFilePath1.Border.Class = "TextBoxBorder";
            this.labelFilePath1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelFilePath1.DisabledBackColor = System.Drawing.Color.White;
            this.labelFilePath1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilePath1.Location = new System.Drawing.Point(104, 54);
            this.labelFilePath1.Name = "labelFilePath1";
            this.labelFilePath1.PreventEnterBeep = true;
            this.labelFilePath1.ReadOnly = true;
            this.labelFilePath1.Size = new System.Drawing.Size(575, 22);
            this.labelFilePath1.TabIndex = 67;
            // 
            // buttonExportFile
            // 
            this.buttonExportFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonExportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonExportFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportFile.Location = new System.Drawing.Point(520, 8);
            this.buttonExportFile.Name = "buttonExportFile";
            this.buttonExportFile.Size = new System.Drawing.Size(159, 37);
            this.buttonExportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonExportFile.TabIndex = 66;
            this.buttonExportFile.Text = "Export File";
            this.buttonExportFile.Click += new System.EventHandler(this.buttonExportFile_Click);
            // 
            // buttonSelectExcelFile
            // 
            this.buttonSelectExcelFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSelectExcelFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSelectExcelFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectExcelFile.Location = new System.Drawing.Point(355, 8);
            this.buttonSelectExcelFile.Name = "buttonSelectExcelFile";
            this.buttonSelectExcelFile.Size = new System.Drawing.Size(159, 37);
            this.buttonSelectExcelFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSelectExcelFile.TabIndex = 63;
            this.buttonSelectExcelFile.Text = "Import File";
            this.buttonSelectExcelFile.Click += new System.EventHandler(this.buttonSelectExcelFile_Click);
            // 
            // comboBoxExcelSheetName
            // 
            this.comboBoxExcelSheetName.Font = new System.Drawing.Font("Arial", 12F);
            this.comboBoxExcelSheetName.FormattingEnabled = true;
            this.comboBoxExcelSheetName.Location = new System.Drawing.Point(104, 15);
            this.comboBoxExcelSheetName.Name = "comboBoxExcelSheetName";
            this.comboBoxExcelSheetName.Size = new System.Drawing.Size(242, 26);
            this.comboBoxExcelSheetName.TabIndex = 62;
            this.comboBoxExcelSheetName.SelectedIndexChanged += new System.EventHandler(this.comboBoxExcelSheetName_SelectedIndexChanged);
            // 
            // labelX13
            // 
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.Location = new System.Drawing.Point(12, 52);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(75, 23);
            this.labelX13.TabIndex = 59;
            this.labelX13.Text = "File Path :";
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.Location = new System.Drawing.Point(12, 16);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(96, 23);
            this.labelX10.TabIndex = 60;
            this.labelX10.Text = "Sheet Title :";
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.gridViewExcel);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(8, 136);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(966, 372);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 60;
            this.groupPanel1.Text = "Excel Data Sheet";
            // 
            // Method2CadetExcelDataImportfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 532);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonClientPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Method2CadetExcelDataImportfrm";
            this.Text = "Method2 Cadet  Excel Data Export";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserRegistrationfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcel)).EndInit();
            this.ribbonClientPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridViewExcel;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX10;
        private System.Windows.Forms.ComboBox comboBoxExcelSheetName;
        private DevComponents.DotNetBar.ButtonX buttonSelectExcelFile;
        private DevComponents.DotNetBar.ButtonX buttonExportFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CadetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CadetFatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAKNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn BloodGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFIDCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQN_User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tape_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role_ID;
        private DevComponents.DotNetBar.Controls.TextBoxX labelFilePath1;
        private DevComponents.DotNetBar.ButtonX buttonCloseFile;
    }
}