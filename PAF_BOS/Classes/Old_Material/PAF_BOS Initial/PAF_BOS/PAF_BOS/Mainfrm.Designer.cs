namespace PAF_BOS
{
    partial class Mainfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainfrm));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btnTotalClientsReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdminAllUserReport = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdminUserAttendanceReport = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnManageClient = new DevComponents.DotNetBar.ButtonItem();
            this.btnManageShift = new DevComponents.DotNetBar.ButtonItem();
            this.btnManageDepartment = new DevComponents.DotNetBar.ButtonItem();
            this.btnManageUser = new DevComponents.DotNetBar.ButtonItem();
            this.btnChangeUserShift = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.btnChangePassword = new DevComponents.DotNetBar.ButtonItem();
            this.AdminMenu = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.btnAbout = new DevComponents.DotNetBar.ApplicationButton();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.labelLoginUser = new DevComponents.DotNetBar.LabelItem();
            this.labelLoggedInUser = new DevComponents.DotNetBar.LabelItem();
            this.tabStrip2 = new DevComponents.DotNetBar.TabStrip();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198))))));
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar3);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(998, 186);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.DragDropSupport = true;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnTotalClientsReport,
            this.btnAdminAllUserReport,
            this.btnAdminUserAttendanceReport});
            this.ribbonBar3.ItemSpacing = 10;
            this.ribbonBar3.Location = new System.Drawing.Point(583, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(322, 183);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 8;
            this.ribbonBar3.Text = "Reports";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnTotalClientsReport
            // 
            this.btnTotalClientsReport.BeginGroup = true;
            this.btnTotalClientsReport.Image = global::PAF_BOS.Properties.Resources.Clients;
            this.btnTotalClientsReport.ImagePaddingHorizontal = 20;
            this.btnTotalClientsReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnTotalClientsReport.Name = "btnTotalClientsReport";
            this.btnTotalClientsReport.RibbonWordWrap = false;
            this.btnTotalClientsReport.SubItemsExpandWidth = 14;
            this.btnTotalClientsReport.Text = "Clients Report";
            this.btnTotalClientsReport.Click += new System.EventHandler(this.btnTotalClientsReport_Click);
            // 
            // btnAdminAllUserReport
            // 
            this.btnAdminAllUserReport.BeginGroup = true;
            this.btnAdminAllUserReport.Image = global::PAF_BOS.Properties.Resources.UserDetails;
            this.btnAdminAllUserReport.ImagePaddingHorizontal = 20;
            this.btnAdminAllUserReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdminAllUserReport.Name = "btnAdminAllUserReport";
            this.btnAdminAllUserReport.RibbonWordWrap = false;
            this.btnAdminAllUserReport.SubItemsExpandWidth = 14;
            this.btnAdminAllUserReport.Text = "Users Report";
            this.btnAdminAllUserReport.Click += new System.EventHandler(this.btnAdminAllUserReport_Click);
            // 
            // btnAdminUserAttendanceReport
            // 
            this.btnAdminUserAttendanceReport.BeginGroup = true;
            this.btnAdminUserAttendanceReport.Image = global::PAF_BOS.Properties.Resources.AttendanceReport;
            this.btnAdminUserAttendanceReport.ImagePaddingHorizontal = 20;
            this.btnAdminUserAttendanceReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdminUserAttendanceReport.Name = "btnAdminUserAttendanceReport";
            this.btnAdminUserAttendanceReport.RibbonWordWrap = false;
            this.btnAdminUserAttendanceReport.SubItemsExpandWidth = 14;
            this.btnAdminUserAttendanceReport.Text = "Attendance Report";
            this.btnAdminUserAttendanceReport.Click += new System.EventHandler(this.btnAdminUserAttendanceReport_Click);
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
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnManageClient,
            this.btnManageShift,
            this.btnManageDepartment,
            this.btnManageUser,
            this.btnChangeUserShift});
            this.ribbonBar1.ItemSpacing = 10;
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(580, 183);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 2;
            this.ribbonBar1.Text = "Management";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnManageClient
            // 
            this.btnManageClient.Image = global::PAF_BOS.Properties.Resources.Client;
            this.btnManageClient.ImagePaddingHorizontal = 20;
            this.btnManageClient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnManageClient.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.btnManageClient.Name = "btnManageClient";
            this.btnManageClient.RibbonWordWrap = false;
            this.btnManageClient.SubItemsExpandWidth = 14;
            this.btnManageClient.Text = "Manage Clients";
            this.btnManageClient.Click += new System.EventHandler(this.btnClientRegistration_Click);
            // 
            // btnManageShift
            // 
            this.btnManageShift.BeginGroup = true;
            this.btnManageShift.Image = global::PAF_BOS.Properties.Resources.Shift;
            this.btnManageShift.ImagePaddingHorizontal = 20;
            this.btnManageShift.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnManageShift.Name = "btnManageShift";
            this.btnManageShift.RibbonWordWrap = false;
            this.btnManageShift.SubItemsExpandWidth = 14;
            this.btnManageShift.Text = "Manage Shifts";
            this.btnManageShift.Click += new System.EventHandler(this.btnManageShift_Click);
            // 
            // btnManageDepartment
            // 
            this.btnManageDepartment.BeginGroup = true;
            this.btnManageDepartment.Image = global::PAF_BOS.Properties.Resources.Department;
            this.btnManageDepartment.ImagePaddingHorizontal = 20;
            this.btnManageDepartment.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnManageDepartment.Name = "btnManageDepartment";
            this.btnManageDepartment.RibbonWordWrap = false;
            this.btnManageDepartment.SubItemsExpandWidth = 14;
            this.btnManageDepartment.Text = "Manage Departments";
            this.btnManageDepartment.Click += new System.EventHandler(this.btnManageDepartment_Click);
            // 
            // btnManageUser
            // 
            this.btnManageUser.BeginGroup = true;
            this.btnManageUser.Image = global::PAF_BOS.Properties.Resources.FingerIcon;
            this.btnManageUser.ImagePaddingHorizontal = 20;
            this.btnManageUser.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnManageUser.Name = "btnManageUser";
            this.btnManageUser.RibbonWordWrap = false;
            this.btnManageUser.SubItemsExpandWidth = 14;
            this.btnManageUser.Text = "Manage Users";
            this.btnManageUser.Click += new System.EventHandler(this.btnManageUser_Click);
            // 
            // btnChangeUserShift
            // 
            this.btnChangeUserShift.BeginGroup = true;
            this.btnChangeUserShift.Image = global::PAF_BOS.Properties.Resources.ChangeShift;
            this.btnChangeUserShift.ImagePaddingHorizontal = 20;
            this.btnChangeUserShift.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnChangeUserShift.Name = "btnChangeUserShift";
            this.btnChangeUserShift.RibbonWordWrap = false;
            this.btnChangeUserShift.SubItemsExpandWidth = 14;
            this.btnChangeUserShift.Text = "Change User Shift";
            this.btnChangeUserShift.Click += new System.EventHandler(this.btnChangeUserShift_Click);
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            this.qatCustomizeItem1.Visible = false;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // AdminMenu
            // 
            this.AdminMenu.Checked = true;
            this.AdminMenu.Name = "AdminMenu";
            this.AdminMenu.Panel = this.ribbonPanel1;
            this.AdminMenu.Tag = "";
            this.AdminMenu.Text = "Menu";
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.CategorizeMode = DevComponents.DotNetBar.eCategorizeMode.Categories;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.AdminMenu});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAbout,
            this.btnChangePassword,
            this.qatCustomizeItem1});
            this.ribbonControl1.RibbonStripFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl1.Size = new System.Drawing.Size(998, 189);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabGroupsVisible = true;
            this.ribbonControl1.TabIndex = 4;
            this.ribbonControl1.Text = "Biometric Attendance System";
            // 
            // btnAbout
            // 
            this.btnAbout.AutoExpandOnClick = true;
            this.btnAbout.CanCustomize = false;
            this.btnAbout.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.btnAbout.Image = global::PAF_BOS.Properties.Resources.Clock;
            this.btnAbout.ImagePaddingHorizontal = 2;
            this.btnAbout.ImagePaddingVertical = 2;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShowSubItems = false;
            this.btnAbout.Text = "&File";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.Raised;
            this.bar1.DockTabStripHeight = 20;
            this.bar1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelLoginUser,
            this.labelLoggedInUser});
            this.bar1.Location = new System.Drawing.Point(5, 732);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(998, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // labelLoginUser
            // 
            this.labelLoginUser.Name = "labelLoginUser";
            this.labelLoginUser.Text = "User Name : ";
            // 
            // labelLoggedInUser
            // 
            this.labelLoggedInUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoggedInUser.Name = "labelLoggedInUser";
            // 
            // tabStrip2
            // 
            this.tabStrip2.AutoSelectAttachedControl = true;
            this.tabStrip2.CanReorderTabs = true;
            this.tabStrip2.CloseButtonOnTabsVisible = true;
            this.tabStrip2.CloseButtonVisible = false;
            this.tabStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStrip2.Location = new System.Drawing.Point(5, 190);
            this.tabStrip2.MdiForm = this;
            this.tabStrip2.MdiTabbedDocuments = true;
            this.tabStrip2.Name = "tabStrip2";
            this.tabStrip2.SelectedTab = null;
            this.tabStrip2.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStrip2.Size = new System.Drawing.Size(998, 26);
            this.tabStrip2.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabStrip2.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;
            this.tabStrip2.TabIndex = 9;
            this.tabStrip2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabStrip2.Text = "tabStrip2";
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1008, 761);
            this.Controls.Add(this.tabStrip2);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Mainfrm";
            this.Text = "Biometric Attendance System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Mainfrm_Load);
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.ButtonItem btnChangePassword;
        private DevComponents.DotNetBar.ApplicationButton btnAbout;
        private DevComponents.DotNetBar.RibbonTabItem AdminMenu;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelItem labelLoginUser;
        private DevComponents.DotNetBar.LabelItem labelLoggedInUser;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnManageClient;
        private DevComponents.DotNetBar.TabStrip tabStrip2;
        private DevComponents.DotNetBar.ButtonItem btnManageDepartment;
        private DevComponents.DotNetBar.ButtonItem btnManageShift;
        private DevComponents.DotNetBar.ButtonItem btnManageUser;
        private DevComponents.DotNetBar.ButtonItem btnChangeUserShift;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem btnTotalClientsReport;
        private DevComponents.DotNetBar.ButtonItem btnAdminAllUserReport;
        private DevComponents.DotNetBar.ButtonItem btnAdminUserAttendanceReport;
    }
}