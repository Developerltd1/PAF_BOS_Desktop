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
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.btnItemAttendanceReport = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemCadetAttendanceReport = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemExcelSheet = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btnItem_USER_ATTANDANCE_ACCESS = new DevComponents.DotNetBar.ButtonItem();
            this.btnItem_FORM_ROLES = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnItem_USER = new DevComponents.DotNetBar.ButtonItem();
            this.btnItem_CADET_REGISTRATION = new DevComponents.DotNetBar.ButtonItem();
            this.btnItem_CADET_PUNSIHMENT = new DevComponents.DotNetBar.ButtonItem();
            this.btnItem_ALLCADET_PUNSIHMENT = new DevComponents.DotNetBar.ButtonItem();
            this.btnItem_CADET_ATTANDANCE_PERMISSION = new DevComponents.DotNetBar.ButtonItem();
            this.btnItem_CADET_GROUND_ATTANDANCE_PERMISSION = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.btnChangePassword = new DevComponents.DotNetBar.ButtonItem();
            this.AdminMenu = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.btnAbout = new DevComponents.DotNetBar.ApplicationButton();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.labelLoginUser = new DevComponents.DotNetBar.LabelItem();
            this.labelLoggedInUser = new DevComponents.DotNetBar.LabelItem();
            this.tabStrip2 = new DevComponents.DotNetBar.TabStrip();
            this.btnManageClient = new DevComponents.DotNetBar.ButtonItem();
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
            this.ribbonPanel1.Controls.Add(this.ribbonBar4);
            this.ribbonPanel1.Controls.Add(this.ribbonBar3);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(1005, 181);
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
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar4.DragDropSupport = true;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnItemAttendanceReport,
            this.buttonItemCadetAttendanceReport,
            this.buttonItemExcelSheet});
            this.ribbonBar4.ItemSpacing = 10;
            this.ribbonBar4.Location = new System.Drawing.Point(625, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(322, 178);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 9;
            this.ribbonBar4.Text = "Reports";
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnItemAttendanceReport
            // 
            this.btnItemAttendanceReport.BeginGroup = true;
            this.btnItemAttendanceReport.Image = global::PAF_BOS.Properties.Resources.attendance;
            this.btnItemAttendanceReport.ImagePaddingHorizontal = 20;
            this.btnItemAttendanceReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemAttendanceReport.Name = "btnItemAttendanceReport";
            this.btnItemAttendanceReport.RibbonWordWrap = false;
            this.btnItemAttendanceReport.SubItemsExpandWidth = 14;
            this.btnItemAttendanceReport.Text = "Pass Out/In Report";
            this.btnItemAttendanceReport.Click += new System.EventHandler(this.btnAttendanceReport);
            // 
            // buttonItemCadetAttendanceReport
            // 
            this.buttonItemCadetAttendanceReport.BeginGroup = true;
            this.buttonItemCadetAttendanceReport.Image = global::PAF_BOS.Properties.Resources.attendance;
            this.buttonItemCadetAttendanceReport.ImagePaddingHorizontal = 20;
            this.buttonItemCadetAttendanceReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItemCadetAttendanceReport.Name = "buttonItemCadetAttendanceReport";
            this.buttonItemCadetAttendanceReport.RibbonWordWrap = false;
            this.buttonItemCadetAttendanceReport.SubItemsExpandWidth = 14;
            this.buttonItemCadetAttendanceReport.Text = "Cadet History Report";
            this.buttonItemCadetAttendanceReport.Click += new System.EventHandler(this.btnCadetAttendanceReport_Click);
            // 
            // buttonItemExcelSheet
            // 
            this.buttonItemExcelSheet.BeginGroup = true;
            this.buttonItemExcelSheet.Image = global::PAF_BOS.Properties.Resources.attendance;
            this.buttonItemExcelSheet.ImagePaddingHorizontal = 20;
            this.buttonItemExcelSheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItemExcelSheet.Name = "buttonItemExcelSheet";
            this.buttonItemExcelSheet.RibbonWordWrap = false;
            this.buttonItemExcelSheet.SubItemsExpandWidth = 14;
            this.buttonItemExcelSheet.Text = "Excel Sheet";
            this.buttonItemExcelSheet.Click += new System.EventHandler(this.buttonItemExcelSheet_Click);
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
            this.btnItem_USER_ATTANDANCE_ACCESS,
            this.btnItem_FORM_ROLES});
            this.ribbonBar3.ItemSpacing = 10;
            this.ribbonBar3.Location = new System.Drawing.Point(455, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(170, 178);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 8;
            this.ribbonBar3.Text = "User Management";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnItem_USER_ATTANDANCE_ACCESS
            // 
            this.btnItem_USER_ATTANDANCE_ACCESS.BeginGroup = true;
            this.btnItem_USER_ATTANDANCE_ACCESS.Image = global::PAF_BOS.Properties.Resources.permission1;
            this.btnItem_USER_ATTANDANCE_ACCESS.ImagePaddingHorizontal = 20;
            this.btnItem_USER_ATTANDANCE_ACCESS.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem_USER_ATTANDANCE_ACCESS.Name = "btnItem_USER_ATTANDANCE_ACCESS";
            this.btnItem_USER_ATTANDANCE_ACCESS.RibbonWordWrap = false;
            this.btnItem_USER_ATTANDANCE_ACCESS.SubItemsExpandWidth = 14;
            this.btnItem_USER_ATTANDANCE_ACCESS.Text = "Cadet Search Permission";
            this.btnItem_USER_ATTANDANCE_ACCESS.Click += new System.EventHandler(this.btnAdminUserAttendanceReport_Click);
            // 
            // btnItem_FORM_ROLES
            // 
            this.btnItem_FORM_ROLES.BeginGroup = true;
            this.btnItem_FORM_ROLES.Image = global::PAF_BOS.Properties.Resources.Role;
            this.btnItem_FORM_ROLES.ImagePaddingHorizontal = 20;
            this.btnItem_FORM_ROLES.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem_FORM_ROLES.Name = "btnItem_FORM_ROLES";
            this.btnItem_FORM_ROLES.RibbonWordWrap = false;
            this.btnItem_FORM_ROLES.SubItemsExpandWidth = 14;
            this.btnItem_FORM_ROLES.Text = "Access Level Roles";
            this.btnItem_FORM_ROLES.Click += new System.EventHandler(this.btnTotalClientsReport_Click);
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
            this.btnItem_USER,
            this.btnItem_CADET_REGISTRATION,
            this.btnItem_CADET_PUNSIHMENT,
            this.btnItem_ALLCADET_PUNSIHMENT,
            this.btnItem_CADET_ATTANDANCE_PERMISSION,
            this.btnItem_CADET_GROUND_ATTANDANCE_PERMISSION});
            this.ribbonBar1.ItemSpacing = 10;
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.ribbonBar1.Size = new System.Drawing.Size(452, 178);
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
            // btnItem_USER
            // 
            this.btnItem_USER.BeginGroup = true;
            this.btnItem_USER.Image = global::PAF_BOS.Properties.Resources.army640;
            this.btnItem_USER.ImagePaddingHorizontal = 20;
            this.btnItem_USER.ImagePaddingVertical = 20;
            this.btnItem_USER.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem_USER.KeyTips = "CREATE NEW USER";
            this.btnItem_USER.Name = "btnItem_USER";
            this.btnItem_USER.RibbonWordWrap = false;
            this.btnItem_USER.SubItemsExpandWidth = 14;
            this.btnItem_USER.Text = "Create Login User";
            this.btnItem_USER.Click += new System.EventHandler(this.btnItemUSER_Click);
            // 
            // btnItem_CADET_REGISTRATION
            // 
            this.btnItem_CADET_REGISTRATION.BeginGroup = true;
            this.btnItem_CADET_REGISTRATION.Image = global::PAF_BOS.Properties.Resources.id;
            this.btnItem_CADET_REGISTRATION.ImagePaddingHorizontal = 20;
            this.btnItem_CADET_REGISTRATION.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem_CADET_REGISTRATION.Name = "btnItem_CADET_REGISTRATION";
            this.btnItem_CADET_REGISTRATION.RibbonWordWrap = false;
            this.btnItem_CADET_REGISTRATION.SubItemsExpandWidth = 14;
            this.btnItem_CADET_REGISTRATION.Text = "Cadet Registration";
            this.btnItem_CADET_REGISTRATION.Click += new System.EventHandler(this.btnItemCADETREGISTRATION);
            // 
            // btnItem_CADET_PUNSIHMENT
            // 
            this.btnItem_CADET_PUNSIHMENT.BeginGroup = true;
            this.btnItem_CADET_PUNSIHMENT.Image = global::PAF_BOS.Properties.Resources.limit;
            this.btnItem_CADET_PUNSIHMENT.ImagePaddingHorizontal = 20;
            this.btnItem_CADET_PUNSIHMENT.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem_CADET_PUNSIHMENT.Name = "btnItem_CADET_PUNSIHMENT";
            this.btnItem_CADET_PUNSIHMENT.RibbonWordWrap = false;
            this.btnItem_CADET_PUNSIHMENT.SubItemsExpandWidth = 14;
            this.btnItem_CADET_PUNSIHMENT.Text = "Add Cadet Punishments";
            this.btnItem_CADET_PUNSIHMENT.Click += new System.EventHandler(this.btnItemPUNISHMENT);
            // 
            // btnItem_ALLCADET_PUNSIHMENT
            // 
            this.btnItem_ALLCADET_PUNSIHMENT.BeginGroup = true;
            this.btnItem_ALLCADET_PUNSIHMENT.Image = global::PAF_BOS.Properties.Resources.limit;
            this.btnItem_ALLCADET_PUNSIHMENT.ImagePaddingHorizontal = 20;
            this.btnItem_ALLCADET_PUNSIHMENT.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem_ALLCADET_PUNSIHMENT.Name = "btnItem_ALLCADET_PUNSIHMENT";
            this.btnItem_ALLCADET_PUNSIHMENT.RibbonWordWrap = false;
            this.btnItem_ALLCADET_PUNSIHMENT.SubItemsExpandWidth = 14;
            this.btnItem_ALLCADET_PUNSIHMENT.Text = "All Cadet Punishments";
            this.btnItem_ALLCADET_PUNSIHMENT.Click += new System.EventHandler(this.btnItem_ALLCADET_PUNSIHMENT_Click);
            // 
            // btnItem_CADET_ATTANDANCE_PERMISSION
            // 
            this.btnItem_CADET_ATTANDANCE_PERMISSION.BeginGroup = true;
            this.btnItem_CADET_ATTANDANCE_PERMISSION.Image = global::PAF_BOS.Properties.Resources.attendance_copy;
            this.btnItem_CADET_ATTANDANCE_PERMISSION.ImagePaddingHorizontal = 20;
            this.btnItem_CADET_ATTANDANCE_PERMISSION.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem_CADET_ATTANDANCE_PERMISSION.Name = "btnItem_CADET_ATTANDANCE_PERMISSION";
            this.btnItem_CADET_ATTANDANCE_PERMISSION.RibbonWordWrap = false;
            this.btnItem_CADET_ATTANDANCE_PERMISSION.SubItemsExpandWidth = 14;
            this.btnItem_CADET_ATTANDANCE_PERMISSION.Text = "Add Pass Out/In Session";
            this.btnItem_CADET_ATTANDANCE_PERMISSION.Click += new System.EventHandler(this.btnItem_CADET_ATTANDANCE_PERMISSION_Click);
            // 
            // btnItem_CADET_GROUND_ATTANDANCE_PERMISSION
            // 
            this.btnItem_CADET_GROUND_ATTANDANCE_PERMISSION.Name = "btnItem_CADET_GROUND_ATTANDANCE_PERMISSION";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            this.qatCustomizeItem1.Visible = false;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Text = "Logout";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // AdminMenu
            // 
            this.AdminMenu.Checked = true;
            this.AdminMenu.Name = "AdminMenu";
            this.AdminMenu.Panel = this.ribbonPanel1;
            this.AdminMenu.Tag = "";
            this.AdminMenu.Text = "Activities";
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
            this.ribbonControl1.Size = new System.Drawing.Size(1005, 184);
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
            this.ribbonControl1.Text = "CADET BOOK OUT/IN SYSTEM";
            // 
            // btnAbout
            // 
            this.btnAbout.AutoExpandOnClick = true;
            this.btnAbout.CanCustomize = false;
            this.btnAbout.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.btnAbout.Image = global::PAF_BOS.Properties.Resources.comet1;
            this.btnAbout.ImagePaddingHorizontal = 2;
            this.btnAbout.ImagePaddingVertical = 2;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShowSubItems = false;
            this.btnAbout.Text = "&File";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.Raised;
            this.bar1.DockOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.bar1.DockTabStripHeight = 20;
            this.bar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelLoginUser,
            this.labelLoggedInUser});
            this.bar1.LayoutType = DevComponents.DotNetBar.eLayoutType.TaskList;
            this.bar1.Location = new System.Drawing.Point(5, 674);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(78, 25);
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
            this.tabStrip2.Location = new System.Drawing.Point(5, 185);
            this.tabStrip2.MdiForm = this;
            this.tabStrip2.MdiTabbedDocuments = true;
            this.tabStrip2.Name = "tabStrip2";
            this.tabStrip2.SelectedTab = null;
            this.tabStrip2.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStrip2.Size = new System.Drawing.Size(1005, 26);
            this.tabStrip2.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabStrip2.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;
            this.tabStrip2.TabIndex = 9;
            this.tabStrip2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabStrip2.Text = "tabStrip2";
            // 
            // btnManageClient
            // 
            this.btnManageClient.Image = global::PAF_BOS.Properties.Resources.NoHuman;
            this.btnManageClient.ImagePaddingHorizontal = 20;
            this.btnManageClient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnManageClient.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.btnManageClient.Name = "btnManageClient";
            this.btnManageClient.RibbonWordWrap = false;
            this.btnManageClient.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnManageClient.SubItemsExpandWidth = 14;
            this.btnManageClient.Text = "Users";
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1015, 701);
            this.Controls.Add(this.tabStrip2);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Mainfrm";
            this.Text = "CADET BOOK OUT/IN SYSTEM";
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
        private DevComponents.DotNetBar.TabStrip tabStrip2;
        private DevComponents.DotNetBar.ButtonItem btnItem_CADET_REGISTRATION;
        private DevComponents.DotNetBar.ButtonItem btnItem_CADET_PUNSIHMENT;
        private DevComponents.DotNetBar.ButtonItem btnItem_CADET_ATTANDANCE_PERMISSION;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem btnItem_FORM_ROLES;
        private DevComponents.DotNetBar.ButtonItem btnItem_USER_ATTANDANCE_ACCESS;
        private DevComponents.DotNetBar.ButtonItem btnItem_USER;
        private DevComponents.DotNetBar.ButtonItem btnManageClient;
        private DevComponents.DotNetBar.ButtonItem btnItem_CADET_GROUND_ATTANDANCE_PERMISSION;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.ButtonItem btnItemAttendanceReport;
        private DevComponents.DotNetBar.ButtonItem buttonItemCadetAttendanceReport;
        private DevComponents.DotNetBar.ButtonItem btnItem_ALLCADET_PUNSIHMENT;
        private DevComponents.DotNetBar.ButtonItem buttonItemExcelSheet;
    }
}