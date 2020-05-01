namespace PAF_BOS.AdminForms
{
    partial class ChangeUserShiftfrm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnChangeShift = new DevComponents.DotNetBar.ButtonX();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.textBoxShiftTiming = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxSelectShift = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxSelectUserName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxSelectClient = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.ribbonClientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(60, 111);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(145, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Select User Name : ";
            // 
            // btnChangeShift
            // 
            this.btnChangeShift.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangeShift.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChangeShift.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeShift.Location = new System.Drawing.Point(372, 252);
            this.btnChangeShift.Name = "btnChangeShift";
            this.btnChangeShift.Size = new System.Drawing.Size(155, 41);
            this.btnChangeShift.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChangeShift.TabIndex = 7;
            this.btnChangeShift.Text = "Change Shift";
            this.btnChangeShift.Click += new System.EventHandler(this.btnChangeShift_Click);
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.textBoxShiftTiming);
            this.ribbonClientPanel1.Controls.Add(this.btnCancel);
            this.ribbonClientPanel1.Controls.Add(this.comboBoxSelectShift);
            this.ribbonClientPanel1.Controls.Add(this.comboBoxSelectUserName);
            this.ribbonClientPanel1.Controls.Add(this.comboBoxSelectClient);
            this.ribbonClientPanel1.Controls.Add(this.labelX8);
            this.ribbonClientPanel1.Controls.Add(this.btnChangeShift);
            this.ribbonClientPanel1.Controls.Add(this.labelX2);
            this.ribbonClientPanel1.Controls.Add(this.labelX4);
            this.ribbonClientPanel1.Controls.Add(this.labelX1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(566, 330);
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
            this.ribbonClientPanel1.TabIndex = 0;
            // 
            // textBoxShiftTiming
            // 
            // 
            // 
            // 
            this.textBoxShiftTiming.Border.Class = "TextBoxBorder";
            this.textBoxShiftTiming.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxShiftTiming.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxShiftTiming.Location = new System.Drawing.Point(211, 199);
            this.textBoxShiftTiming.Name = "textBoxShiftTiming";
            this.textBoxShiftTiming.PreventEnterBeep = true;
            this.textBoxShiftTiming.ReadOnly = true;
            this.textBoxShiftTiming.Size = new System.Drawing.Size(316, 26);
            this.textBoxShiftTiming.TabIndex = 23;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(211, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 41);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBoxSelectShift
            // 
            this.comboBoxSelectShift.DisplayMember = "Text";
            this.comboBoxSelectShift.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSelectShift.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectShift.FormattingEnabled = true;
            this.comboBoxSelectShift.ItemHeight = 21;
            this.comboBoxSelectShift.Location = new System.Drawing.Point(210, 154);
            this.comboBoxSelectShift.Name = "comboBoxSelectShift";
            this.comboBoxSelectShift.Size = new System.Drawing.Size(317, 27);
            this.comboBoxSelectShift.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxSelectShift.TabIndex = 5;
            this.comboBoxSelectShift.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectShift_SelectedIndexChanged);
            // 
            // comboBoxSelectUserName
            // 
            this.comboBoxSelectUserName.DisplayMember = "Text";
            this.comboBoxSelectUserName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSelectUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectUserName.FormattingEnabled = true;
            this.comboBoxSelectUserName.ItemHeight = 21;
            this.comboBoxSelectUserName.Location = new System.Drawing.Point(210, 110);
            this.comboBoxSelectUserName.Name = "comboBoxSelectUserName";
            this.comboBoxSelectUserName.Size = new System.Drawing.Size(317, 27);
            this.comboBoxSelectUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxSelectUserName.TabIndex = 3;
            this.comboBoxSelectUserName.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectUserName_SelectedIndexChanged);
            // 
            // comboBoxSelectClient
            // 
            this.comboBoxSelectClient.DisplayMember = "Text";
            this.comboBoxSelectClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSelectClient.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectClient.FormattingEnabled = true;
            this.comboBoxSelectClient.ItemHeight = 21;
            this.comboBoxSelectClient.Location = new System.Drawing.Point(210, 66);
            this.comboBoxSelectClient.Name = "comboBoxSelectClient";
            this.comboBoxSelectClient.Size = new System.Drawing.Size(317, 27);
            this.comboBoxSelectClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxSelectClient.TabIndex = 1;
            this.comboBoxSelectClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectClient_SelectedIndexChanged);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.Location = new System.Drawing.Point(60, 67);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(145, 23);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "Select Client :";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(60, 199);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(145, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Shift Timing : ";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(60, 155);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(145, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Select Shift : ";
            // 
            // ChangeUserShiftfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 330);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonClientPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeUserShiftfrm";
            this.Text = " Change User Shift";
            this.Activated += new System.EventHandler(this.ChangeUserShiftfrm_Activated);
            this.Load += new System.EventHandler(this.ChangeUserShiftfrm_Load);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnChangeShift;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxSelectClient;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxSelectUserName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxSelectShift;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxShiftTiming;
    }
}