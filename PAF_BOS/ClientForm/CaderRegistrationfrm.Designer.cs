namespace PAF_BOS
{
    partial class CaderRegistrationfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaderRegistrationfrm));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbCadet = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCadetRegister = new DevComponents.DotNetBar.ButtonX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.CbBloodGroup = new System.Windows.Forms.ComboBox();
            this.lblSeniorOfficer = new DevComponents.DotNetBar.LabelX();
            this.tbMobileNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.cbSeniorOfficer = new System.Windows.Forms.ComboBox();
            this.tbContactNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbCNIC = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbTape = new System.Windows.Forms.ComboBox();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.tbFatherName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.tbPAKNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tbAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnClearRegistration = new DevComponents.DotNetBar.ButtonX();
            this.radioButtonRightThumb = new System.Windows.Forms.RadioButton();
            this.radioButtonLeftThumb = new System.Windows.Forms.RadioButton();
            this.pictureBoxRightThumb = new System.Windows.Forms.PictureBox();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelLeftThumb = new DevComponents.DotNetBar.LabelX();
            this.labelRightThumb = new DevComponents.DotNetBar.LabelX();
            this.btnFromFile = new DevComponents.DotNetBar.ButtonX();
            this.pictureBoxLeftThumb = new System.Windows.Forms.PictureBox();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.tbRFIDCardNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.radioJuniorCadet = new System.Windows.Forms.RadioButton();
            this.radioSeniorCadet = new System.Windows.Forms.RadioButton();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.openFileDialogSelectPicture = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ribbonClientPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(21, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(115, 23);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "Cadet Name:";
            // 
            // tbCadet
            // 
            this.tbCadet.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbCadet.Border.Class = "TextBoxBorder";
            this.tbCadet.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCadet.DisabledBackColor = System.Drawing.Color.White;
            this.tbCadet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCadet.Location = new System.Drawing.Point(146, 36);
            this.tbCadet.Name = "tbCadet";
            this.tbCadet.PreventEnterBeep = true;
            this.tbCadet.Size = new System.Drawing.Size(210, 26);
            this.tbCadet.TabIndex = 0;
            this.tbCadet.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyUp);
            // 
            // btnCadetRegister
            // 
            this.btnCadetRegister.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCadetRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCadetRegister.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCadetRegister.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadetRegister.Location = new System.Drawing.Point(272, 13);
            this.btnCadetRegister.Name = "btnCadetRegister";
            this.btnCadetRegister.Size = new System.Drawing.Size(206, 45);
            this.btnCadetRegister.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCadetRegister.TabIndex = 6;
            this.btnCadetRegister.Text = "Register";
            this.btnCadetRegister.Click += new System.EventHandler(this.btnCadetRegister_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198))))));
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.btnCancel);
            this.ribbonClientPanel1.Controls.Add(this.groupPanel2);
            this.ribbonClientPanel1.Controls.Add(this.groupPanel1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(934, 511);
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
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(0, 0);
            this.btnCancel.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.CbBloodGroup);
            this.groupPanel2.Controls.Add(this.lblSeniorOfficer);
            this.groupPanel2.Controls.Add(this.tbCadet);
            this.groupPanel2.Controls.Add(this.tbMobileNo);
            this.groupPanel2.Controls.Add(this.labelX10);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.labelX17);
            this.groupPanel2.Controls.Add(this.cbSeniorOfficer);
            this.groupPanel2.Controls.Add(this.tbContactNo);
            this.groupPanel2.Controls.Add(this.tbCNIC);
            this.groupPanel2.Controls.Add(this.cbTape);
            this.groupPanel2.Controls.Add(this.labelX11);
            this.groupPanel2.Controls.Add(this.labelX16);
            this.groupPanel2.Controls.Add(this.labelX9);
            this.groupPanel2.Controls.Add(this.cbCourse);
            this.groupPanel2.Controls.Add(this.tbFatherName);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.tbPAKNumber);
            this.groupPanel2.Controls.Add(this.labelX5);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.Controls.Add(this.tbAddress);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(6, 35);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(375, 470);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuUnusedBackground;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            this.groupPanel2.TabIndex = 1;
            // 
            // CbBloodGroup
            // 
            this.CbBloodGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbBloodGroup.Font = new System.Drawing.Font("Arial", 12F);
            this.CbBloodGroup.FormattingEnabled = true;
            this.CbBloodGroup.Items.AddRange(new object[] {
            "A+",
            "B+",
            "AB+",
            "A-",
            "B-",
            "AB-",
            "O+",
            "O-"});
            this.CbBloodGroup.Location = new System.Drawing.Point(146, 209);
            this.CbBloodGroup.Name = "CbBloodGroup";
            this.CbBloodGroup.Size = new System.Drawing.Size(210, 26);
            this.CbBloodGroup.TabIndex = 5;
            // 
            // lblSeniorOfficer
            // 
            this.lblSeniorOfficer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSeniorOfficer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSeniorOfficer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeniorOfficer.Location = new System.Drawing.Point(146, 413);
            this.lblSeniorOfficer.Name = "lblSeniorOfficer";
            this.lblSeniorOfficer.Size = new System.Drawing.Size(210, 23);
            this.lblSeniorOfficer.TabIndex = 11;
            // 
            // tbMobileNo
            // 
            this.tbMobileNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbMobileNo.Border.Class = "TextBoxBorder";
            this.tbMobileNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMobileNo.DisabledBackColor = System.Drawing.Color.White;
            this.tbMobileNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMobileNo.Location = new System.Drawing.Point(146, 277);
            this.tbMobileNo.Name = "tbMobileNo";
            this.tbMobileNo.PreventEnterBeep = true;
            this.tbMobileNo.Size = new System.Drawing.Size(210, 26);
            this.tbMobileNo.TabIndex = 7;
            // 
            // labelX10
            // 
            this.labelX10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.Location = new System.Drawing.Point(21, 242);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(115, 23);
            this.labelX10.TabIndex = 18;
            this.labelX10.Text = "Contact #:";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(21, 379);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(115, 23);
            this.labelX2.TabIndex = 22;
            this.labelX2.Text = "Senior Officer:";
            // 
            // labelX17
            // 
            this.labelX17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX17.Location = new System.Drawing.Point(21, 311);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(115, 23);
            this.labelX17.TabIndex = 20;
            this.labelX17.Text = "Tape:";
            // 
            // cbSeniorOfficer
            // 
            this.cbSeniorOfficer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSeniorOfficer.Font = new System.Drawing.Font("Arial", 12F);
            this.cbSeniorOfficer.FormattingEnabled = true;
            this.cbSeniorOfficer.Location = new System.Drawing.Point(146, 379);
            this.cbSeniorOfficer.Name = "cbSeniorOfficer";
            this.cbSeniorOfficer.Size = new System.Drawing.Size(210, 26);
            this.cbSeniorOfficer.TabIndex = 10;
            this.cbSeniorOfficer.SelectionChangeCommitted += new System.EventHandler(this.cbSeniorOfficer_SelectionChangeCommitted);
            // 
            // tbContactNo
            // 
            this.tbContactNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbContactNo.Border.Class = "TextBoxBorder";
            this.tbContactNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbContactNo.DisabledBackColor = System.Drawing.Color.White;
            this.tbContactNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContactNo.Location = new System.Drawing.Point(146, 243);
            this.tbContactNo.Name = "tbContactNo";
            this.tbContactNo.PreventEnterBeep = true;
            this.tbContactNo.Size = new System.Drawing.Size(210, 26);
            this.tbContactNo.TabIndex = 6;
            this.tbContactNo.Leave += new System.EventHandler(this.tbContactNo_Leave);
            // 
            // tbCNIC
            // 
            this.tbCNIC.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbCNIC.Border.Class = "TextBoxBorder";
            this.tbCNIC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCNIC.DisabledBackColor = System.Drawing.Color.White;
            this.tbCNIC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCNIC.Location = new System.Drawing.Point(146, 175);
            this.tbCNIC.Name = "tbCNIC";
            this.tbCNIC.PreventEnterBeep = true;
            this.tbCNIC.Size = new System.Drawing.Size(210, 26);
            this.tbCNIC.TabIndex = 4;
            // 
            // cbTape
            // 
            this.cbTape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbTape.Font = new System.Drawing.Font("Arial", 12F);
            this.cbTape.FormattingEnabled = true;
            this.cbTape.Location = new System.Drawing.Point(146, 311);
            this.cbTape.Name = "cbTape";
            this.cbTape.Size = new System.Drawing.Size(210, 26);
            this.cbTape.TabIndex = 8;
            // 
            // labelX11
            // 
            this.labelX11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.Location = new System.Drawing.Point(21, 209);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(115, 23);
            this.labelX11.TabIndex = 17;
            this.labelX11.Text = "Blood Group:";
            // 
            // labelX16
            // 
            this.labelX16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX16.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX16.Location = new System.Drawing.Point(21, 348);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(115, 23);
            this.labelX16.TabIndex = 21;
            this.labelX16.Text = "Course:";
            // 
            // labelX9
            // 
            this.labelX9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.Location = new System.Drawing.Point(21, 276);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(115, 23);
            this.labelX9.TabIndex = 19;
            this.labelX9.Text = "Mobile #:";
            // 
            // cbCourse
            // 
            this.cbCourse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCourse.Font = new System.Drawing.Font("Arial", 12F);
            this.cbCourse.FormattingEnabled = true;
            this.cbCourse.Location = new System.Drawing.Point(146, 345);
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.Size = new System.Drawing.Size(210, 26);
            this.cbCourse.TabIndex = 9;
            // 
            // tbFatherName
            // 
            this.tbFatherName.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbFatherName.Border.Class = "TextBoxBorder";
            this.tbFatherName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbFatherName.DisabledBackColor = System.Drawing.Color.White;
            this.tbFatherName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFatherName.Location = new System.Drawing.Point(146, 70);
            this.tbFatherName.Name = "tbFatherName";
            this.tbFatherName.PreventEnterBeep = true;
            this.tbFatherName.Size = new System.Drawing.Size(210, 26);
            this.tbFatherName.TabIndex = 1;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(21, 74);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(115, 23);
            this.labelX4.TabIndex = 13;
            this.labelX4.Text = "F. Name:";
            // 
            // labelX7
            // 
            this.labelX7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(21, 174);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(115, 23);
            this.labelX7.TabIndex = 16;
            this.labelX7.Text = "CNIC:";
            // 
            // tbPAKNumber
            // 
            this.tbPAKNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbPAKNumber.Border.Class = "TextBoxBorder";
            this.tbPAKNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPAKNumber.DisabledBackColor = System.Drawing.Color.White;
            this.tbPAKNumber.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPAKNumber.Location = new System.Drawing.Point(146, 104);
            this.tbPAKNumber.Name = "tbPAKNumber";
            this.tbPAKNumber.PreventEnterBeep = true;
            this.tbPAKNumber.Size = new System.Drawing.Size(210, 26);
            this.tbPAKNumber.TabIndex = 2;
            this.tbPAKNumber.Leave += new System.EventHandler(this.tbPAKNumber_Leave);
            // 
            // labelX5
            // 
            this.labelX5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(21, 137);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(115, 23);
            this.labelX5.TabIndex = 15;
            this.labelX5.Text = "Address:";
            // 
            // labelX6
            // 
            this.labelX6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(21, 103);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(115, 23);
            this.labelX6.TabIndex = 14;
            this.labelX6.Text = "PAK #:";
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbAddress.Border.Class = "TextBoxBorder";
            this.tbAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbAddress.DisabledBackColor = System.Drawing.Color.White;
            this.tbAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(146, 138);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.PreventEnterBeep = true;
            this.tbAddress.Size = new System.Drawing.Size(210, 26);
            this.tbAddress.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupBox3);
            this.groupPanel1.Controls.Add(this.groupBox2);
            this.groupPanel1.Controls.Add(this.groupBox1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(387, 35);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(536, 470);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuUnusedBackground;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            this.groupPanel1.TabIndex = 2;
            // 
            // btnClearRegistration
            // 
            this.btnClearRegistration.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearRegistration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearRegistration.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearRegistration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearRegistration.Location = new System.Drawing.Point(50, 13);
            this.btnClearRegistration.Name = "btnClearRegistration";
            this.btnClearRegistration.Size = new System.Drawing.Size(206, 45);
            this.btnClearRegistration.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearRegistration.TabIndex = 6;
            this.btnClearRegistration.Text = "Clear";
            this.btnClearRegistration.Click += new System.EventHandler(this.btnClearRegistration_Click);
            // 
            // radioButtonRightThumb
            // 
            this.radioButtonRightThumb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonRightThumb.AutoSize = true;
            this.radioButtonRightThumb.Font = new System.Drawing.Font("Arial", 10F);
            this.radioButtonRightThumb.ForeColor = System.Drawing.Color.Black;
            this.radioButtonRightThumb.Location = new System.Drawing.Point(340, 210);
            this.radioButtonRightThumb.Name = "radioButtonRightThumb";
            this.radioButtonRightThumb.Size = new System.Drawing.Size(143, 20);
            this.radioButtonRightThumb.TabIndex = 5;
            this.radioButtonRightThumb.Text = "Scan Right Thumb";
            this.radioButtonRightThumb.UseVisualStyleBackColor = true;
            // 
            // radioButtonLeftThumb
            // 
            this.radioButtonLeftThumb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonLeftThumb.AutoSize = true;
            this.radioButtonLeftThumb.Checked = true;
            this.radioButtonLeftThumb.Font = new System.Drawing.Font("Arial", 10F);
            this.radioButtonLeftThumb.ForeColor = System.Drawing.Color.Black;
            this.radioButtonLeftThumb.Location = new System.Drawing.Point(186, 210);
            this.radioButtonLeftThumb.Name = "radioButtonLeftThumb";
            this.radioButtonLeftThumb.Size = new System.Drawing.Size(134, 20);
            this.radioButtonLeftThumb.TabIndex = 3;
            this.radioButtonLeftThumb.TabStop = true;
            this.radioButtonLeftThumb.Text = "Scan Left Thumb";
            this.radioButtonLeftThumb.UseVisualStyleBackColor = true;
            // 
            // pictureBoxRightThumb
            // 
            this.pictureBoxRightThumb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRightThumb.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxRightThumb.Location = new System.Drawing.Point(340, 48);
            this.pictureBoxRightThumb.Name = "pictureBoxRightThumb";
            this.pictureBoxRightThumb.Size = new System.Drawing.Size(138, 153);
            this.pictureBoxRightThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRightThumb.TabIndex = 17;
            this.pictureBoxRightThumb.TabStop = false;
            // 
            // labelX8
            // 
            this.labelX8.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(21, 19);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(138, 23);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "User Picture";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelLeftThumb
            // 
            this.labelLeftThumb.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelLeftThumb.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLeftThumb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeftThumb.ForeColor = System.Drawing.Color.Black;
            this.labelLeftThumb.Location = new System.Drawing.Point(186, 19);
            this.labelLeftThumb.Name = "labelLeftThumb";
            this.labelLeftThumb.Size = new System.Drawing.Size(138, 23);
            this.labelLeftThumb.TabIndex = 2;
            this.labelLeftThumb.Text = "Left Thumb";
            this.labelLeftThumb.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelLeftThumb.Click += new System.EventHandler(this.labelLeftThumb_Click);
            // 
            // labelRightThumb
            // 
            this.labelRightThumb.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelRightThumb.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelRightThumb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRightThumb.ForeColor = System.Drawing.Color.Black;
            this.labelRightThumb.Location = new System.Drawing.Point(340, 19);
            this.labelRightThumb.Name = "labelRightThumb";
            this.labelRightThumb.Size = new System.Drawing.Size(138, 23);
            this.labelRightThumb.TabIndex = 4;
            this.labelRightThumb.Text = "Right Thumb";
            this.labelRightThumb.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelRightThumb.Click += new System.EventHandler(this.labelRightThumb_Click);
            // 
            // btnFromFile
            // 
            this.btnFromFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFromFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFromFile.Location = new System.Drawing.Point(21, 207);
            this.btnFromFile.Name = "btnFromFile";
            this.btnFromFile.Size = new System.Drawing.Size(138, 23);
            this.btnFromFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFromFile.TabIndex = 1;
            this.btnFromFile.Text = "Select From File";
            this.btnFromFile.Click += new System.EventHandler(this.btnFromFile_Click);
            // 
            // pictureBoxLeftThumb
            // 
            this.pictureBoxLeftThumb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxLeftThumb.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxLeftThumb.Location = new System.Drawing.Point(186, 48);
            this.pictureBoxLeftThumb.Name = "pictureBoxLeftThumb";
            this.pictureBoxLeftThumb.Size = new System.Drawing.Size(138, 153);
            this.pictureBoxLeftThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeftThumb.TabIndex = 17;
            this.pictureBoxLeftThumb.TabStop = false;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxPhoto.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(21, 48);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(138, 153);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPhoto.TabIndex = 17;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // tbRFIDCardNo
            // 
            this.tbRFIDCardNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.tbRFIDCardNo.Border.Class = "TextBoxBorder";
            this.tbRFIDCardNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbRFIDCardNo.DisabledBackColor = System.Drawing.Color.White;
            this.tbRFIDCardNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRFIDCardNo.Location = new System.Drawing.Point(168, 14);
            this.tbRFIDCardNo.MaxLength = 10;
            this.tbRFIDCardNo.Name = "tbRFIDCardNo";
            this.tbRFIDCardNo.PreventEnterBeep = true;
            this.tbRFIDCardNo.Size = new System.Drawing.Size(310, 26);
            this.tbRFIDCardNo.TabIndex = 1;
            this.tbRFIDCardNo.Leave += new System.EventHandler(this.tbRFIDCardNo_Leave);
            // 
            // labelX14
            // 
            this.labelX14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX14.Location = new System.Drawing.Point(51, 15);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(111, 23);
            this.labelX14.TabIndex = 0;
            this.labelX14.Text = "RFID Card:";
            // 
            // radioJuniorCadet
            // 
            this.radioJuniorCadet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioJuniorCadet.AutoSize = true;
            this.radioJuniorCadet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioJuniorCadet.ForeColor = System.Drawing.SystemColors.MenuText;
            this.radioJuniorCadet.Location = new System.Drawing.Point(168, 50);
            this.radioJuniorCadet.Name = "radioJuniorCadet";
            this.radioJuniorCadet.Size = new System.Drawing.Size(101, 20);
            this.radioJuniorCadet.TabIndex = 3;
            this.radioJuniorCadet.TabStop = true;
            this.radioJuniorCadet.Text = "Junior Cadet";
            this.radioJuniorCadet.UseVisualStyleBackColor = true;
            // 
            // radioSeniorCadet
            // 
            this.radioSeniorCadet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioSeniorCadet.AutoSize = true;
            this.radioSeniorCadet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSeniorCadet.ForeColor = System.Drawing.SystemColors.MenuText;
            this.radioSeniorCadet.Location = new System.Drawing.Point(287, 50);
            this.radioSeniorCadet.Name = "radioSeniorCadet";
            this.radioSeniorCadet.Size = new System.Drawing.Size(104, 20);
            this.radioSeniorCadet.TabIndex = 4;
            this.radioSeniorCadet.TabStop = true;
            this.radioSeniorCadet.Text = "Senior Cadet";
            this.radioSeniorCadet.UseVisualStyleBackColor = true;
            // 
            // labelX18
            // 
            this.labelX18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelX18.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX18.Location = new System.Drawing.Point(51, 48);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(111, 23);
            this.labelX18.TabIndex = 2;
            this.labelX18.Text = "Role:";
            // 
            // openFileDialogSelectPicture
            // 
            this.openFileDialogSelectPicture.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tbRFIDCardNo);
            this.groupBox1.Controls.Add(this.labelX18);
            this.groupBox1.Controls.Add(this.radioSeniorCadet);
            this.groupBox1.Controls.Add(this.radioJuniorCadet);
            this.groupBox1.Controls.Add(this.labelX14);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(19, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnCadetRegister);
            this.groupBox2.Controls.Add(this.btnClearRegistration);
            this.groupBox2.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point(19, 391);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 64);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.radioButtonRightThumb);
            this.groupBox3.Controls.Add(this.labelX8);
            this.groupBox3.Controls.Add(this.radioButtonLeftThumb);
            this.groupBox3.Controls.Add(this.pictureBoxPhoto);
            this.groupBox3.Controls.Add(this.pictureBoxRightThumb);
            this.groupBox3.Controls.Add(this.pictureBoxLeftThumb);
            this.groupBox3.Controls.Add(this.btnFromFile);
            this.groupBox3.Controls.Add(this.labelLeftThumb);
            this.groupBox3.Controls.Add(this.labelRightThumb);
            this.groupBox3.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox3.Location = new System.Drawing.Point(19, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 281);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // CaderRegistrationfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonClientPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CaderRegistrationfrm";
            this.Text = "Cadet Registration Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaderRegistrationfrm_FormClosing);
            this.Load += new System.EventHandler(this.UserRegistrationfrm_Load);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCadet;
        private DevComponents.DotNetBar.ButtonX btnCadetRegister;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbFatherName;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbAddress;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPAKNumber;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMobileNo;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX tbContactNo;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX14;
        private System.Windows.Forms.ComboBox cbCourse;
        private DevComponents.DotNetBar.LabelX labelX16;
        private System.Windows.Forms.ComboBox cbTape;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCNIC;
        private System.Windows.Forms.ComboBox cbSeniorOfficer;
        private System.Windows.Forms.RadioButton radioSeniorCadet;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.RadioButton radioJuniorCadet;
        private DevComponents.DotNetBar.Controls.TextBoxX tbRFIDCardNo;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.ComboBox CbBloodGroup;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectPicture;
        private DevComponents.DotNetBar.LabelX lblSeniorOfficer;
        private System.Windows.Forms.RadioButton radioButtonRightThumb;
        private System.Windows.Forms.RadioButton radioButtonLeftThumb;
        private System.Windows.Forms.PictureBox pictureBoxRightThumb;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelLeftThumb;
        private DevComponents.DotNetBar.LabelX labelRightThumb;
        private DevComponents.DotNetBar.ButtonX btnFromFile;
        private System.Windows.Forms.PictureBox pictureBoxLeftThumb;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private DevComponents.DotNetBar.ButtonX btnClearRegistration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}