namespace PAF_BOS.Reports
{
    partial class Attendancefrm
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
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnGetReport = new DevComponents.DotNetBar.ButtonX();
            this.ToDateTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromDateTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.comboBoxUsers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxClient = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ribbonClientPanel1.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDateTime)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.reportViewer1);
            this.ribbonClientPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(872, 561);
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
            this.ribbonClientPanel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PAF_BOS.Reports.AttendancefrmReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 156);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(872, 405);
            this.reportViewer1.TabIndex = 2;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panelEx1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(872, 156);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 1;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnGetReport);
            this.panelEx1.Controls.Add(this.ToDateTime);
            this.panelEx1.Controls.Add(this.FromDateTime);
            this.panelEx1.Controls.Add(this.comboBoxUsers);
            this.panelEx1.Controls.Add(this.comboBoxClient);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(872, 141);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnGetReport
            // 
            this.btnGetReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetReport.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGetReport.Location = new System.Drawing.Point(682, 45);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(102, 65);
            this.btnGetReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetReport.TabIndex = 6;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // ToDateTime
            // 
            // 
            // 
            // 
            this.ToDateTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ToDateTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.ToDateTime.ButtonDropDown.Visible = true;
            this.ToDateTime.Font = new System.Drawing.Font("Arial", 12F);
            this.ToDateTime.IsPopupCalendarOpen = false;
            this.ToDateTime.Location = new System.Drawing.Point(439, 83);
            // 
            // 
            // 
            // 
            // 
            // 
            this.ToDateTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ToDateTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.ToDateTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToDateTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToDateTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ToDateTime.MonthCalendar.DisplayMonth = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.ToDateTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToDateTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ToDateTime.MonthCalendar.TodayButtonVisible = true;
            this.ToDateTime.Name = "ToDateTime";
            this.ToDateTime.Size = new System.Drawing.Size(188, 26);
            this.ToDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ToDateTime.TabIndex = 5;
            // 
            // FromDateTime
            // 
            // 
            // 
            // 
            this.FromDateTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FromDateTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.FromDateTime.ButtonDropDown.Visible = true;
            this.FromDateTime.Font = new System.Drawing.Font("Arial", 12F);
            this.FromDateTime.IsPopupCalendarOpen = false;
            this.FromDateTime.Location = new System.Drawing.Point(439, 45);
            // 
            // 
            // 
            // 
            // 
            // 
            this.FromDateTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FromDateTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.FromDateTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromDateTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromDateTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromDateTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromDateTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FromDateTime.MonthCalendar.DisplayMonth = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.FromDateTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromDateTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromDateTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FromDateTime.MonthCalendar.TodayButtonVisible = true;
            this.FromDateTime.Name = "FromDateTime";
            this.FromDateTime.Size = new System.Drawing.Size(188, 26);
            this.FromDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FromDateTime.TabIndex = 3;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.DisplayMember = "Text";
            this.comboBoxUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxUsers.Font = new System.Drawing.Font("Arial", 12F);
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.ItemHeight = 21;
            this.comboBoxUsers.Location = new System.Drawing.Point(128, 83);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(188, 27);
            this.comboBoxUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxUsers.TabIndex = 1;
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.DisplayMember = "Text";
            this.comboBoxClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxClient.Font = new System.Drawing.Font("Arial", 12F);
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.ItemHeight = 21;
            this.comboBoxClient.Location = new System.Drawing.Point(128, 44);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(188, 27);
            this.comboBoxClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxClient.TabIndex = 1;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxClient_SelectedIndexChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(332, 86);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(101, 24);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "To Date : ";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(19, 86);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(116, 24);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Select User : ";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(332, 46);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(101, 24);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "From Date  : ";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(19, 47);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(116, 24);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Select Client : ";
            // 
            // Attendancefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 561);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonClientPanel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Attendancefrm";
            this.Text = "Attendance Report";
            this.Activated += new System.EventHandler(this.Attendancefrm_Activated);
            this.Load += new System.EventHandler(this.Attendancefrm_Load);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDateTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxClient;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToDateTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromDateTime;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnGetReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxUsers;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}