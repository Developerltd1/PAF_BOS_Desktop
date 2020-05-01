namespace PAF_BOS.AdminForms
{
    partial class ManageShiftfrm
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnCreateShift = new DevComponents.DotNetBar.ButtonX();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.textBoxShiftName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ShiftEndTimeControl = new DevComponents.Editors.DateTimeAdv.TimeSelector();
            this.ShiftStartTimeControl = new DevComponents.Editors.DateTimeAdv.TimeSelector();
            this.comboBoxSelectShift = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxSelectClient = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
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
            this.labelX1.Location = new System.Drawing.Point(77, 110);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(128, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Shift Name :";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(81, 211);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(252, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Shift Start Time";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(361, 211);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(252, 23);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "Shift End Time";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCreateShift
            // 
            this.btnCreateShift.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCreateShift.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCreateShift.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateShift.Location = new System.Drawing.Point(458, 461);
            this.btnCreateShift.Name = "btnCreateShift";
            this.btnCreateShift.Size = new System.Drawing.Size(155, 50);
            this.btnCreateShift.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCreateShift.TabIndex = 9;
            this.btnCreateShift.Text = "Create Shift";
            this.btnCreateShift.Click += new System.EventHandler(this.btnCreateShift_Click);
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.textBoxShiftName);
            this.ribbonClientPanel1.Controls.Add(this.ShiftEndTimeControl);
            this.ribbonClientPanel1.Controls.Add(this.ShiftStartTimeControl);
            this.ribbonClientPanel1.Controls.Add(this.comboBoxSelectShift);
            this.ribbonClientPanel1.Controls.Add(this.comboBoxSelectClient);
            this.ribbonClientPanel1.Controls.Add(this.labelX8);
            this.ribbonClientPanel1.Controls.Add(this.btnCancel);
            this.ribbonClientPanel1.Controls.Add(this.btnCreateShift);
            this.ribbonClientPanel1.Controls.Add(this.labelX4);
            this.ribbonClientPanel1.Controls.Add(this.labelX1);
            this.ribbonClientPanel1.Controls.Add(this.labelX2);
            this.ribbonClientPanel1.Controls.Add(this.labelX3);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(715, 523);
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
            // textBoxShiftName
            // 
            // 
            // 
            // 
            this.textBoxShiftName.Border.Class = "TextBoxBorder";
            this.textBoxShiftName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxShiftName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxShiftName.Location = new System.Drawing.Point(211, 154);
            this.textBoxShiftName.Name = "textBoxShiftName";
            this.textBoxShiftName.PreventEnterBeep = true;
            this.textBoxShiftName.Size = new System.Drawing.Size(402, 26);
            this.textBoxShiftName.TabIndex = 5;
            // 
            // ShiftEndTimeControl
            // 
            // 
            // 
            // 
            this.ShiftEndTimeControl.BackgroundStyle.Class = "ItemPanel";
            this.ShiftEndTimeControl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ShiftEndTimeControl.ContainerControlProcessDialogKey = true;
            this.ShiftEndTimeControl.Location = new System.Drawing.Point(361, 240);
            this.ShiftEndTimeControl.Name = "ShiftEndTimeControl";
            this.ShiftEndTimeControl.OkButtonVisible = false;
            this.ShiftEndTimeControl.SelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.MonthCalendarStyle;
            this.ShiftEndTimeControl.Size = new System.Drawing.Size(172, 164);
            // 
            // ShiftStartTimeControl
            // 
            this.ShiftStartTimeControl.AutoSize = true;
            // 
            // 
            // 
            this.ShiftStartTimeControl.BackgroundStyle.Class = "ItemPanel";
            this.ShiftStartTimeControl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ShiftStartTimeControl.ContainerControlProcessDialogKey = true;
            this.ShiftStartTimeControl.Location = new System.Drawing.Point(81, 240);
            this.ShiftStartTimeControl.Name = "ShiftStartTimeControl";
            this.ShiftStartTimeControl.OkButtonVisible = false;
            this.ShiftStartTimeControl.Size = new System.Drawing.Size(252, 190);
            // 
            // comboBoxSelectShift
            // 
            this.comboBoxSelectShift.DisplayMember = "Text";
            this.comboBoxSelectShift.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSelectShift.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectShift.FormattingEnabled = true;
            this.comboBoxSelectShift.ItemHeight = 21;
            this.comboBoxSelectShift.Location = new System.Drawing.Point(211, 110);
            this.comboBoxSelectShift.Name = "comboBoxSelectShift";
            this.comboBoxSelectShift.Size = new System.Drawing.Size(403, 27);
            this.comboBoxSelectShift.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxSelectShift.TabIndex = 3;
            this.comboBoxSelectShift.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectShift_SelectedIndexChanged);
            // 
            // comboBoxSelectClient
            // 
            this.comboBoxSelectClient.DisplayMember = "Text";
            this.comboBoxSelectClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSelectClient.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectClient.FormattingEnabled = true;
            this.comboBoxSelectClient.ItemHeight = 21;
            this.comboBoxSelectClient.Location = new System.Drawing.Point(211, 66);
            this.comboBoxSelectClient.Name = "comboBoxSelectClient";
            this.comboBoxSelectClient.Size = new System.Drawing.Size(403, 27);
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
            this.labelX8.Location = new System.Drawing.Point(77, 67);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(128, 23);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "Select Client :";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(297, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 50);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(77, 153);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(128, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Shift Name :";
            // 
            // ManageShiftfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 523);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonClientPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageShiftfrm";
            this.Text = "Manage Shift";
            this.Activated += new System.EventHandler(this.ManageShiftfrm_Activated);
            this.Load += new System.EventHandler(this.ManageShiftfrm_Load);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ribbonClientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnCreateShift;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxSelectClient;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.Editors.DateTimeAdv.TimeSelector ShiftStartTimeControl;
        private DevComponents.Editors.DateTimeAdv.TimeSelector ShiftEndTimeControl;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxSelectShift;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxShiftName;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}