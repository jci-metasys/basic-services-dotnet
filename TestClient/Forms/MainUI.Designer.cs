namespace MetasysServices_TestClient
{
    partial class MainUI
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
            this.rcbToken = new System.Windows.Forms.RichTextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblHostExample = new System.Windows.Forms.Label();
            this.lblUsernameExample = new System.Windows.Forms.Label();
            this.lblPasswordExample = new System.Windows.Forms.Label();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblVersionExample = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.TpgLogin = new System.Windows.Forms.TabPage();
            this.LblLogin_Title1 = new System.Windows.Forms.Label();
            this.BtnGetAccessToken = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.TpgAlarm = new System.Windows.Forms.TabPage();
            this.TpgAudit = new System.Windows.Forms.TabPage();
            this.TabAudit = new System.Windows.Forms.TabControl();
            this.TpgGetAudits = new System.Windows.Forms.TabPage();
            this.GrbAudits_Get = new System.Windows.Forms.GroupBox();
            this.ChkAudit_NoFilter = new System.Windows.Forms.CheckBox();
            this.GrbAudit_Filter = new System.Windows.Forms.GroupBox();
            this.GrdAudit_ActionTypes = new System.Windows.Forms.GroupBox();
            this.ChkAudit_ActionType_Subsystem = new System.Windows.Forms.CheckBox();
            this.ChkAudit_ActionType_Error = new System.Windows.Forms.CheckBox();
            this.ChkAudit_ActionType_Delete = new System.Windows.Forms.CheckBox();
            this.ChkAudit_ActionType_Create = new System.Windows.Forms.CheckBox();
            this.ChkAudit_ActionType_Command = new System.Windows.Forms.CheckBox();
            this.ChkAudit_ActionType_Write = new System.Windows.Forms.CheckBox();
            this.Grb_Audit_OriginApplication_Filters = new System.Windows.Forms.GroupBox();
            this.ChkAudit_SiteServices = new System.Windows.Forms.CheckBox();
            this.ChkAudit_MCE = new System.Windows.Forms.CheckBox();
            this.ChkAudit_AlarmEvent = new System.Windows.Forms.CheckBox();
            this.ChkAudit_DeviceServices = new System.Windows.Forms.CheckBox();
            this.ChkAudit_AuditTrails = new System.Windows.Forms.CheckBox();
            this.DtpAudit_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpAudit_EndTime = new System.Windows.Forms.DateTimePicker();
            this.ChkAudit_ExcludeDiscarded = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtAudit_Total = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DgvAudit = new System.Windows.Forms.DataGridView();
            this.BtlAudit_Get = new System.Windows.Forms.Button();
            this.TpgFindById = new System.Windows.Forms.TabPage();
            this.PrgAudit_FindByID = new System.Windows.Forms.PropertyGrid();
            this.BtnAudit_FindByID = new System.Windows.Forms.Button();
            this.TxtAudit_FindByID_GUID = new System.Windows.Forms.TextBox();
            this.LblAudit_FindByID_GUID = new System.Windows.Forms.Label();
            this.TpgGetForObject = new System.Windows.Forms.TabPage();
            this.GrbAudit_GFO = new System.Windows.Forms.GroupBox();
            this.TxtAudit_GFO_GUID = new System.Windows.Forms.TextBox();
            this.LblAudit_GFO_GUID = new System.Windows.Forms.Label();
            this.chkAudit_GFO_NoFilter = new System.Windows.Forms.CheckBox();
            this.TxtAudit_GFO_Total = new System.Windows.Forms.TextBox();
            this.LblAudit_GFO_Total = new System.Windows.Forms.Label();
            this.DgvAudit_GFO = new System.Windows.Forms.DataGridView();
            this.BtnAudit_GetForObject = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.DtpAudit_GFO_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.DtpAudit_GFO_EndTime = new System.Windows.Forms.DateTimePicker();
            this.chkAudit_GFO_ExcludeDiscarded = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TpgGetAnnotations = new System.Windows.Forms.TabPage();
            this.GrbGetAuditAnnotation = new System.Windows.Forms.GroupBox();
            this.LblAudits_Annotations = new System.Windows.Forms.Label();
            this.TxtAudits_Annotations = new System.Windows.Forms.TextBox();
            this.BtnAudit_GetAnnotations = new System.Windows.Forms.Button();
            this.TxtAudit_GetAnnotations_GUID = new System.Windows.Forms.TextBox();
            this.LblAudit_GetAnnotations_GUID = new System.Windows.Forms.Label();
            this.TpgAddAnnotation = new System.Windows.Forms.TabPage();
            this.GrbAddAuditAnnotation = new System.Windows.Forms.GroupBox();
            this.BtnAudit_AddAnnotation = new System.Windows.Forms.Button();
            this.TxtAudit_AddAnnotation_Text = new System.Windows.Forms.TextBox();
            this.LblAudit_AddAnnotation_Text = new System.Windows.Forms.Label();
            this.TxtAudit_AddAnnotation_GUID = new System.Windows.Forms.TextBox();
            this.LblAudit_AddAnnotation_GUID = new System.Windows.Forms.Label();
            this.TpgAddAnnotationMulti = new System.Windows.Forms.TabPage();
            this.GrbAddAuditAnnotationMulti = new System.Windows.Forms.GroupBox();
            this.TxtAudit_AddAnnotationMulti_Text2 = new System.Windows.Forms.TextBox();
            this.LblAudit_AddAnnotationMulti_Text2 = new System.Windows.Forms.Label();
            this.TxtAudit_AddAnnotationMulti_GUID2 = new System.Windows.Forms.TextBox();
            this.LblAudit_AddAnnotationMulti_GUID2 = new System.Windows.Forms.Label();
            this.BtnAudit_AddAnnotationMultiple = new System.Windows.Forms.Button();
            this.TxtAudit_AddAnnotationMulti_Text1 = new System.Windows.Forms.TextBox();
            this.LblAudit_AddAnnotationMulti_Text1 = new System.Windows.Forms.Label();
            this.TxtAudit_AddAnnotationMulti_GUID1 = new System.Windows.Forms.TextBox();
            this.LblAudit_AddAnnotationMulti_GUID1 = new System.Windows.Forms.Label();
            this.TpgDiscard = new System.Windows.Forms.TabPage();
            this.GrbDiscardAudit = new System.Windows.Forms.GroupBox();
            this.BtnAudit_Discard = new System.Windows.Forms.Button();
            this.TxtAudit_Discard_Text = new System.Windows.Forms.TextBox();
            this.LblAudit_Discard_Text = new System.Windows.Forms.Label();
            this.TxtAudit_Discard_GUID = new System.Windows.Forms.TextBox();
            this.LblAudit_Discard_GUID = new System.Windows.Forms.Label();
            this.TpgDiscardMultiple = new System.Windows.Forms.TabPage();
            this.GrbDiscardAuditMulti = new System.Windows.Forms.GroupBox();
            this.TxtAudit_DiscardMulti_Text2 = new System.Windows.Forms.TextBox();
            this.LblAudit_DiscardMulti_Text2 = new System.Windows.Forms.Label();
            this.TxtAudit_DiscardMulti_GUID2 = new System.Windows.Forms.TextBox();
            this.LblAudit_DiscardMulti_GUID2 = new System.Windows.Forms.Label();
            this.BtnAudit_DiscardMultiple = new System.Windows.Forms.Button();
            this.TxtAudit_DiscardMulti_Text1 = new System.Windows.Forms.TextBox();
            this.LblAudit_DiscardMulti_Text1 = new System.Windows.Forms.Label();
            this.TxtAudit_DiscardMulti_GUID1 = new System.Windows.Forms.TextBox();
            this.LblAudit_DiscardMulti_GUID1 = new System.Windows.Forms.Label();
            this.TpgEnumeration = new System.Windows.Forms.TabPage();
            this.TpgEquipment = new System.Windows.Forms.TabPage();
            this.TpgNetworkDevice = new System.Windows.Forms.TabPage();
            this.TpgObject = new System.Windows.Forms.TabPage();
            this.TpgSpace = new System.Windows.Forms.TabPage();
            this.TpgTrend = new System.Windows.Forms.TabPage();
            this.TpgStream = new System.Windows.Forms.TabPage();
            this.TpgMisc = new System.Windows.Forms.TabPage();
            this.TabMiscellanea = new System.Windows.Forms.TabControl();
            this.TpgMisc_GetServerTime = new System.Windows.Forms.TabPage();
            this.LblMisc_Title1 = new System.Windows.Forms.Label();
            this.BtnMisc_GetServerTime = new System.Windows.Forms.Button();
            this.TxtMisc_ServerTime = new System.Windows.Forms.TextBox();
            this.TpgMisc_Localize = new System.Windows.Forms.TabPage();
            this.LblMisc_Localize_CultureInfo = new System.Windows.Forms.Label();
            this.LblEnum_LocalizedText = new System.Windows.Forms.Label();
            this.TxtEnum_LocalizedText = new System.Windows.Forms.TextBox();
            this.BtnEnum_Localize = new System.Windows.Forms.Button();
            this.CmbMisc_Localize_CultureInfo = new System.Windows.Forms.ComboBox();
            this.TxtEnum_SourceText = new System.Windows.Forms.TextBox();
            this.LblEnum_SourceText = new System.Windows.Forms.Label();
            this.LblMisc_Title2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TabMain.SuspendLayout();
            this.TpgLogin.SuspendLayout();
            this.TpgAudit.SuspendLayout();
            this.TabAudit.SuspendLayout();
            this.TpgGetAudits.SuspendLayout();
            this.GrbAudits_Get.SuspendLayout();
            this.GrbAudit_Filter.SuspendLayout();
            this.GrdAudit_ActionTypes.SuspendLayout();
            this.Grb_Audit_OriginApplication_Filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAudit)).BeginInit();
            this.TpgFindById.SuspendLayout();
            this.TpgGetForObject.SuspendLayout();
            this.GrbAudit_GFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAudit_GFO)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.TpgGetAnnotations.SuspendLayout();
            this.GrbGetAuditAnnotation.SuspendLayout();
            this.TpgAddAnnotation.SuspendLayout();
            this.GrbAddAuditAnnotation.SuspendLayout();
            this.TpgAddAnnotationMulti.SuspendLayout();
            this.GrbAddAuditAnnotationMulti.SuspendLayout();
            this.TpgDiscard.SuspendLayout();
            this.GrbDiscardAudit.SuspendLayout();
            this.TpgDiscardMultiple.SuspendLayout();
            this.GrbDiscardAuditMulti.SuspendLayout();
            this.TpgMisc.SuspendLayout();
            this.TabMiscellanea.SuspendLayout();
            this.TpgMisc_GetServerTime.SuspendLayout();
            this.TpgMisc_Localize.SuspendLayout();
            this.SuspendLayout();
            // 
            // rcbToken
            // 
            this.rcbToken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rcbToken.Location = new System.Drawing.Point(100, 190);
            this.rcbToken.Name = "rcbToken";
            this.rcbToken.ReadOnly = true;
            this.rcbToken.Size = new System.Drawing.Size(972, 250);
            this.rcbToken.TabIndex = 15;
            this.rcbToken.Text = "";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(102, 154);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "TryLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(38, 104);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(102, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(38, 75);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 13);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "User name:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 72);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(102, 43);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 9;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(13, 46);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(86, 13);
            this.lblHost.TabIndex = 8;
            this.lblHost.Text = "Host name or IP:";
            // 
            // lblHostExample
            // 
            this.lblHostExample.AutoSize = true;
            this.lblHostExample.Location = new System.Drawing.Point(208, 46);
            this.lblHostExample.Name = "lblHostExample";
            this.lblHostExample.Size = new System.Drawing.Size(162, 13);
            this.lblHostExample.TabIndex = 16;
            this.lblHostExample.Text = "Example: ADX-01 or 10.121.34.5";
            // 
            // lblUsernameExample
            // 
            this.lblUsernameExample.AutoSize = true;
            this.lblUsernameExample.Location = new System.Drawing.Point(208, 75);
            this.lblUsernameExample.Name = "lblUsernameExample";
            this.lblUsernameExample.Size = new System.Drawing.Size(133, 13);
            this.lblUsernameExample.TabIndex = 17;
            this.lblUsernameExample.Text = "Example: metasyssysagent";
            // 
            // lblPasswordExample
            // 
            this.lblPasswordExample.AutoSize = true;
            this.lblPasswordExample.Location = new System.Drawing.Point(208, 104);
            this.lblPasswordExample.Name = "lblPasswordExample";
            this.lblPasswordExample.Size = new System.Drawing.Size(184, 13);
            this.lblPasswordExample.TabIndex = 18;
            this.lblPasswordExample.Text = "Example: ChangeThi$Pa$$w0rdN0w!";
            // 
            // cmbVersion
            // 
            this.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Items.AddRange(new object[] {
            "v4",
            "v3",
            "v2"});
            this.cmbVersion.Location = new System.Drawing.Point(102, 127);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(100, 21);
            this.cmbVersion.TabIndex = 23;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(49, 130);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersionExample
            // 
            this.lblVersionExample.AutoSize = true;
            this.lblVersionExample.Location = new System.Drawing.Point(208, 130);
            this.lblVersionExample.Name = "lblVersionExample";
            this.lblVersionExample.Size = new System.Drawing.Size(65, 13);
            this.lblVersionExample.TabIndex = 25;
            this.lblVersionExample.Text = "Example: v4";
            // 
            // lblToken
            // 
            this.lblToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(53, 190);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(41, 13);
            this.lblToken.TabIndex = 26;
            this.lblToken.Text = "Token:";
            this.lblToken.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TabMain
            // 
            this.TabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabMain.Controls.Add(this.TpgLogin);
            this.TabMain.Controls.Add(this.TpgAlarm);
            this.TabMain.Controls.Add(this.TpgAudit);
            this.TabMain.Controls.Add(this.TpgEnumeration);
            this.TabMain.Controls.Add(this.TpgEquipment);
            this.TabMain.Controls.Add(this.TpgNetworkDevice);
            this.TabMain.Controls.Add(this.TpgObject);
            this.TabMain.Controls.Add(this.TpgSpace);
            this.TabMain.Controls.Add(this.TpgTrend);
            this.TabMain.Controls.Add(this.TpgStream);
            this.TabMain.Controls.Add(this.TpgMisc);
            this.TabMain.ItemSize = new System.Drawing.Size(43, 30);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(1088, 488);
            this.TabMain.TabIndex = 28;
            this.TabMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabMain_Selecting);
            // 
            // TpgLogin
            // 
            this.TpgLogin.BackColor = System.Drawing.SystemColors.Control;
            this.TpgLogin.Controls.Add(this.LblLogin_Title1);
            this.TpgLogin.Controls.Add(this.BtnGetAccessToken);
            this.TpgLogin.Controls.Add(this.BtnRefresh);
            this.TpgLogin.Controls.Add(this.txtHost);
            this.TpgLogin.Controls.Add(this.lblToken);
            this.TpgLogin.Controls.Add(this.lblHost);
            this.TpgLogin.Controls.Add(this.rcbToken);
            this.TpgLogin.Controls.Add(this.lblVersionExample);
            this.TpgLogin.Controls.Add(this.txtUsername);
            this.TpgLogin.Controls.Add(this.lblVersion);
            this.TpgLogin.Controls.Add(this.lblUsername);
            this.TpgLogin.Controls.Add(this.cmbVersion);
            this.TpgLogin.Controls.Add(this.txtPassword);
            this.TpgLogin.Controls.Add(this.lblPasswordExample);
            this.TpgLogin.Controls.Add(this.lblPassword);
            this.TpgLogin.Controls.Add(this.lblUsernameExample);
            this.TpgLogin.Controls.Add(this.btnLogin);
            this.TpgLogin.Controls.Add(this.lblHostExample);
            this.TpgLogin.Location = new System.Drawing.Point(4, 34);
            this.TpgLogin.Name = "TpgLogin";
            this.TpgLogin.Padding = new System.Windows.Forms.Padding(3);
            this.TpgLogin.Size = new System.Drawing.Size(1080, 450);
            this.TpgLogin.TabIndex = 4;
            this.TpgLogin.Text = "LOGIN";
            // 
            // LblLogin_Title1
            // 
            this.LblLogin_Title1.AutoSize = true;
            this.LblLogin_Title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLogin_Title1.Location = new System.Drawing.Point(7, 7);
            this.LblLogin_Title1.Name = "LblLogin_Title1";
            this.LblLogin_Title1.Size = new System.Drawing.Size(332, 16);
            this.LblLogin_Title1.TabIndex = 29;
            this.LblLogin_Title1.Text = "Functions: TryLogin, Refresh, GetAccessToken";
            // 
            // BtnGetAccessToken
            // 
            this.BtnGetAccessToken.Location = new System.Drawing.Point(326, 154);
            this.BtnGetAccessToken.Name = "BtnGetAccessToken";
            this.BtnGetAccessToken.Size = new System.Drawing.Size(114, 23);
            this.BtnGetAccessToken.TabIndex = 28;
            this.BtnGetAccessToken.Text = "GetAccessToken";
            this.BtnGetAccessToken.UseVisualStyleBackColor = true;
            this.BtnGetAccessToken.Click += new System.EventHandler(this.BtnGetAccessToken_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(210, 154);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(99, 23);
            this.BtnRefresh.TabIndex = 27;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // TpgAlarm
            // 
            this.TpgAlarm.BackColor = System.Drawing.SystemColors.Control;
            this.TpgAlarm.Location = new System.Drawing.Point(4, 34);
            this.TpgAlarm.Name = "TpgAlarm";
            this.TpgAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.TpgAlarm.Size = new System.Drawing.Size(1080, 450);
            this.TpgAlarm.TabIndex = 0;
            this.TpgAlarm.Text = "ALARMS";
            // 
            // TpgAudit
            // 
            this.TpgAudit.BackColor = System.Drawing.SystemColors.Control;
            this.TpgAudit.Controls.Add(this.TabAudit);
            this.TpgAudit.Location = new System.Drawing.Point(4, 34);
            this.TpgAudit.Name = "TpgAudit";
            this.TpgAudit.Padding = new System.Windows.Forms.Padding(3);
            this.TpgAudit.Size = new System.Drawing.Size(1080, 450);
            this.TpgAudit.TabIndex = 3;
            this.TpgAudit.Text = "AUDITS";
            // 
            // TabAudit
            // 
            this.TabAudit.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabAudit.Controls.Add(this.TpgGetAudits);
            this.TabAudit.Controls.Add(this.TpgFindById);
            this.TabAudit.Controls.Add(this.TpgGetForObject);
            this.TabAudit.Controls.Add(this.TpgGetAnnotations);
            this.TabAudit.Controls.Add(this.TpgAddAnnotation);
            this.TabAudit.Controls.Add(this.TpgAddAnnotationMulti);
            this.TabAudit.Controls.Add(this.TpgDiscard);
            this.TabAudit.Controls.Add(this.TpgDiscardMultiple);
            this.TabAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabAudit.ItemSize = new System.Drawing.Size(63, 25);
            this.TabAudit.Location = new System.Drawing.Point(3, 3);
            this.TabAudit.Name = "TabAudit";
            this.TabAudit.SelectedIndex = 0;
            this.TabAudit.Size = new System.Drawing.Size(1074, 444);
            this.TabAudit.TabIndex = 24;
            // 
            // TpgGetAudits
            // 
            this.TpgGetAudits.Controls.Add(this.GrbAudits_Get);
            this.TpgGetAudits.Location = new System.Drawing.Point(4, 29);
            this.TpgGetAudits.Name = "TpgGetAudits";
            this.TpgGetAudits.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetAudits.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetAudits.TabIndex = 1;
            this.TpgGetAudits.Text = "Get Audits";
            this.TpgGetAudits.UseVisualStyleBackColor = true;
            // 
            // GrbAudits_Get
            // 
            this.GrbAudits_Get.Controls.Add(this.ChkAudit_NoFilter);
            this.GrbAudits_Get.Controls.Add(this.GrbAudit_Filter);
            this.GrbAudits_Get.Controls.Add(this.TxtAudit_Total);
            this.GrbAudits_Get.Controls.Add(this.label10);
            this.GrbAudits_Get.Controls.Add(this.DgvAudit);
            this.GrbAudits_Get.Controls.Add(this.BtlAudit_Get);
            this.GrbAudits_Get.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbAudits_Get.Location = new System.Drawing.Point(3, 6);
            this.GrbAudits_Get.Name = "GrbAudits_Get";
            this.GrbAudits_Get.Size = new System.Drawing.Size(1060, 402);
            this.GrbAudits_Get.TabIndex = 22;
            this.GrbAudits_Get.TabStop = false;
            this.GrbAudits_Get.Text = "Method: Audits.Get";
            // 
            // ChkAudit_NoFilter
            // 
            this.ChkAudit_NoFilter.AutoSize = true;
            this.ChkAudit_NoFilter.Location = new System.Drawing.Point(984, 19);
            this.ChkAudit_NoFilter.Name = "ChkAudit_NoFilter";
            this.ChkAudit_NoFilter.Size = new System.Drawing.Size(70, 17);
            this.ChkAudit_NoFilter.TabIndex = 30;
            this.ChkAudit_NoFilter.Text = "No Filters";
            this.ChkAudit_NoFilter.UseVisualStyleBackColor = true;
            this.ChkAudit_NoFilter.CheckedChanged += new System.EventHandler(this.ChkAudit_NoFilter_CheckedChanged);
            // 
            // GrbAudit_Filter
            // 
            this.GrbAudit_Filter.Controls.Add(this.GrdAudit_ActionTypes);
            this.GrbAudit_Filter.Controls.Add(this.Grb_Audit_OriginApplication_Filters);
            this.GrbAudit_Filter.Controls.Add(this.DtpAudit_StartTime);
            this.GrbAudit_Filter.Controls.Add(this.label5);
            this.GrbAudit_Filter.Controls.Add(this.DtpAudit_EndTime);
            this.GrbAudit_Filter.Controls.Add(this.ChkAudit_ExcludeDiscarded);
            this.GrbAudit_Filter.Controls.Add(this.label9);
            this.GrbAudit_Filter.Location = new System.Drawing.Point(6, 19);
            this.GrbAudit_Filter.Name = "GrbAudit_Filter";
            this.GrbAudit_Filter.Size = new System.Drawing.Size(972, 107);
            this.GrbAudit_Filter.TabIndex = 29;
            this.GrbAudit_Filter.TabStop = false;
            this.GrbAudit_Filter.Text = "Filters";
            // 
            // GrdAudit_ActionTypes
            // 
            this.GrdAudit_ActionTypes.Controls.Add(this.ChkAudit_ActionType_Subsystem);
            this.GrdAudit_ActionTypes.Controls.Add(this.ChkAudit_ActionType_Error);
            this.GrdAudit_ActionTypes.Controls.Add(this.ChkAudit_ActionType_Delete);
            this.GrdAudit_ActionTypes.Controls.Add(this.ChkAudit_ActionType_Create);
            this.GrdAudit_ActionTypes.Controls.Add(this.ChkAudit_ActionType_Command);
            this.GrdAudit_ActionTypes.Controls.Add(this.ChkAudit_ActionType_Write);
            this.GrdAudit_ActionTypes.Location = new System.Drawing.Point(303, 65);
            this.GrdAudit_ActionTypes.Name = "GrdAudit_ActionTypes";
            this.GrdAudit_ActionTypes.Size = new System.Drawing.Size(576, 36);
            this.GrdAudit_ActionTypes.TabIndex = 32;
            this.GrdAudit_ActionTypes.TabStop = false;
            this.GrdAudit_ActionTypes.Text = "Action Types filter";
            // 
            // ChkAudit_ActionType_Subsystem
            // 
            this.ChkAudit_ActionType_Subsystem.AutoSize = true;
            this.ChkAudit_ActionType_Subsystem.Location = new System.Drawing.Point(321, 19);
            this.ChkAudit_ActionType_Subsystem.Name = "ChkAudit_ActionType_Subsystem";
            this.ChkAudit_ActionType_Subsystem.Size = new System.Drawing.Size(77, 17);
            this.ChkAudit_ActionType_Subsystem.TabIndex = 0;
            this.ChkAudit_ActionType_Subsystem.Text = "Subsystem";
            this.ChkAudit_ActionType_Subsystem.UseVisualStyleBackColor = false;
            // 
            // ChkAudit_ActionType_Error
            // 
            this.ChkAudit_ActionType_Error.AutoSize = true;
            this.ChkAudit_ActionType_Error.Location = new System.Drawing.Point(267, 19);
            this.ChkAudit_ActionType_Error.Name = "ChkAudit_ActionType_Error";
            this.ChkAudit_ActionType_Error.Size = new System.Drawing.Size(48, 17);
            this.ChkAudit_ActionType_Error.TabIndex = 0;
            this.ChkAudit_ActionType_Error.Text = "Error";
            this.ChkAudit_ActionType_Error.UseVisualStyleBackColor = false;
            // 
            // ChkAudit_ActionType_Delete
            // 
            this.ChkAudit_ActionType_Delete.AutoSize = true;
            this.ChkAudit_ActionType_Delete.Location = new System.Drawing.Point(204, 19);
            this.ChkAudit_ActionType_Delete.Name = "ChkAudit_ActionType_Delete";
            this.ChkAudit_ActionType_Delete.Size = new System.Drawing.Size(57, 17);
            this.ChkAudit_ActionType_Delete.TabIndex = 0;
            this.ChkAudit_ActionType_Delete.Text = "Delete";
            this.ChkAudit_ActionType_Delete.UseVisualStyleBackColor = false;
            // 
            // ChkAudit_ActionType_Create
            // 
            this.ChkAudit_ActionType_Create.AutoSize = true;
            this.ChkAudit_ActionType_Create.Location = new System.Drawing.Point(141, 19);
            this.ChkAudit_ActionType_Create.Name = "ChkAudit_ActionType_Create";
            this.ChkAudit_ActionType_Create.Size = new System.Drawing.Size(57, 17);
            this.ChkAudit_ActionType_Create.TabIndex = 0;
            this.ChkAudit_ActionType_Create.Text = "Create";
            this.ChkAudit_ActionType_Create.UseVisualStyleBackColor = true;
            // 
            // ChkAudit_ActionType_Command
            // 
            this.ChkAudit_ActionType_Command.AutoSize = true;
            this.ChkAudit_ActionType_Command.Location = new System.Drawing.Point(62, 19);
            this.ChkAudit_ActionType_Command.Name = "ChkAudit_ActionType_Command";
            this.ChkAudit_ActionType_Command.Size = new System.Drawing.Size(73, 17);
            this.ChkAudit_ActionType_Command.TabIndex = 0;
            this.ChkAudit_ActionType_Command.Text = "Command";
            this.ChkAudit_ActionType_Command.UseVisualStyleBackColor = true;
            // 
            // ChkAudit_ActionType_Write
            // 
            this.ChkAudit_ActionType_Write.AutoSize = true;
            this.ChkAudit_ActionType_Write.Location = new System.Drawing.Point(5, 19);
            this.ChkAudit_ActionType_Write.Name = "ChkAudit_ActionType_Write";
            this.ChkAudit_ActionType_Write.Size = new System.Drawing.Size(51, 17);
            this.ChkAudit_ActionType_Write.TabIndex = 0;
            this.ChkAudit_ActionType_Write.Text = "Write";
            this.ChkAudit_ActionType_Write.UseVisualStyleBackColor = true;
            // 
            // Grb_Audit_OriginApplication_Filters
            // 
            this.Grb_Audit_OriginApplication_Filters.Controls.Add(this.ChkAudit_SiteServices);
            this.Grb_Audit_OriginApplication_Filters.Controls.Add(this.ChkAudit_MCE);
            this.Grb_Audit_OriginApplication_Filters.Controls.Add(this.ChkAudit_AlarmEvent);
            this.Grb_Audit_OriginApplication_Filters.Controls.Add(this.ChkAudit_DeviceServices);
            this.Grb_Audit_OriginApplication_Filters.Controls.Add(this.ChkAudit_AuditTrails);
            this.Grb_Audit_OriginApplication_Filters.Location = new System.Drawing.Point(302, 19);
            this.Grb_Audit_OriginApplication_Filters.Name = "Grb_Audit_OriginApplication_Filters";
            this.Grb_Audit_OriginApplication_Filters.Size = new System.Drawing.Size(578, 38);
            this.Grb_Audit_OriginApplication_Filters.TabIndex = 31;
            this.Grb_Audit_OriginApplication_Filters.TabStop = false;
            this.Grb_Audit_OriginApplication_Filters.Text = "Origin Application filter";
            // 
            // ChkAudit_SiteServices
            // 
            this.ChkAudit_SiteServices.AutoSize = true;
            this.ChkAudit_SiteServices.Location = new System.Drawing.Point(352, 19);
            this.ChkAudit_SiteServices.Name = "ChkAudit_SiteServices";
            this.ChkAudit_SiteServices.Size = new System.Drawing.Size(88, 17);
            this.ChkAudit_SiteServices.TabIndex = 32;
            this.ChkAudit_SiteServices.Text = "Site Services";
            this.ChkAudit_SiteServices.UseVisualStyleBackColor = true;
            // 
            // ChkAudit_MCE
            // 
            this.ChkAudit_MCE.AutoSize = true;
            this.ChkAudit_MCE.Location = new System.Drawing.Point(297, 19);
            this.ChkAudit_MCE.Name = "ChkAudit_MCE";
            this.ChkAudit_MCE.Size = new System.Drawing.Size(49, 17);
            this.ChkAudit_MCE.TabIndex = 31;
            this.ChkAudit_MCE.Text = "MCE";
            this.ChkAudit_MCE.UseVisualStyleBackColor = true;
            // 
            // ChkAudit_AlarmEvent
            // 
            this.ChkAudit_AlarmEvent.AutoSize = true;
            this.ChkAudit_AlarmEvent.Location = new System.Drawing.Point(6, 19);
            this.ChkAudit_AlarmEvent.Name = "ChkAudit_AlarmEvent";
            this.ChkAudit_AlarmEvent.Size = new System.Drawing.Size(83, 17);
            this.ChkAudit_AlarmEvent.TabIndex = 28;
            this.ChkAudit_AlarmEvent.Text = "Alarm Event";
            this.ChkAudit_AlarmEvent.UseVisualStyleBackColor = true;
            // 
            // ChkAudit_DeviceServices
            // 
            this.ChkAudit_DeviceServices.AutoSize = true;
            this.ChkAudit_DeviceServices.Location = new System.Drawing.Point(187, 19);
            this.ChkAudit_DeviceServices.Name = "ChkAudit_DeviceServices";
            this.ChkAudit_DeviceServices.Size = new System.Drawing.Size(104, 17);
            this.ChkAudit_DeviceServices.TabIndex = 30;
            this.ChkAudit_DeviceServices.Text = "Device Services";
            this.ChkAudit_DeviceServices.UseVisualStyleBackColor = true;
            // 
            // ChkAudit_AuditTrails
            // 
            this.ChkAudit_AuditTrails.AutoSize = true;
            this.ChkAudit_AuditTrails.Location = new System.Drawing.Point(95, 19);
            this.ChkAudit_AuditTrails.Name = "ChkAudit_AuditTrails";
            this.ChkAudit_AuditTrails.Size = new System.Drawing.Size(75, 17);
            this.ChkAudit_AuditTrails.TabIndex = 29;
            this.ChkAudit_AuditTrails.Text = "AuditTrails";
            this.ChkAudit_AuditTrails.UseVisualStyleBackColor = true;
            // 
            // DtpAudit_StartTime
            // 
            this.DtpAudit_StartTime.Location = new System.Drawing.Point(80, 22);
            this.DtpAudit_StartTime.Name = "DtpAudit_StartTime";
            this.DtpAudit_StartTime.Size = new System.Drawing.Size(200, 20);
            this.DtpAudit_StartTime.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Start Time:";
            // 
            // DtpAudit_EndTime
            // 
            this.DtpAudit_EndTime.Location = new System.Drawing.Point(80, 49);
            this.DtpAudit_EndTime.Name = "DtpAudit_EndTime";
            this.DtpAudit_EndTime.Size = new System.Drawing.Size(200, 20);
            this.DtpAudit_EndTime.TabIndex = 22;
            // 
            // ChkAudit_ExcludeDiscarded
            // 
            this.ChkAudit_ExcludeDiscarded.AutoSize = true;
            this.ChkAudit_ExcludeDiscarded.Location = new System.Drawing.Point(80, 75);
            this.ChkAudit_ExcludeDiscarded.Name = "ChkAudit_ExcludeDiscarded";
            this.ChkAudit_ExcludeDiscarded.Size = new System.Drawing.Size(115, 17);
            this.ChkAudit_ExcludeDiscarded.TabIndex = 26;
            this.ChkAudit_ExcludeDiscarded.Text = "Exclude Discarded";
            this.ChkAudit_ExcludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "End Time:";
            // 
            // TxtAudit_Total
            // 
            this.TxtAudit_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAudit_Total.Location = new System.Drawing.Point(954, 135);
            this.TxtAudit_Total.Name = "TxtAudit_Total";
            this.TxtAudit_Total.ReadOnly = true;
            this.TxtAudit_Total.Size = new System.Drawing.Size(100, 20);
            this.TxtAudit_Total.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(863, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Numb. of Audits:";
            // 
            // DgvAudit
            // 
            this.DgvAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAudit.Location = new System.Drawing.Point(6, 161);
            this.DgvAudit.Name = "DgvAudit";
            this.DgvAudit.Size = new System.Drawing.Size(1048, 232);
            this.DgvAudit.TabIndex = 24;
            // 
            // BtlAudit_Get
            // 
            this.BtlAudit_Get.Location = new System.Drawing.Point(6, 132);
            this.BtlAudit_Get.Name = "BtlAudit_Get";
            this.BtlAudit_Get.Size = new System.Drawing.Size(515, 23);
            this.BtlAudit_Get.TabIndex = 19;
            this.BtlAudit_Get.Text = "Get";
            this.BtlAudit_Get.UseVisualStyleBackColor = true;
            this.BtlAudit_Get.Click += new System.EventHandler(this.BtlAudit_Get_Click);
            // 
            // TpgFindById
            // 
            this.TpgFindById.Controls.Add(this.PrgAudit_FindByID);
            this.TpgFindById.Controls.Add(this.BtnAudit_FindByID);
            this.TpgFindById.Controls.Add(this.TxtAudit_FindByID_GUID);
            this.TpgFindById.Controls.Add(this.LblAudit_FindByID_GUID);
            this.TpgFindById.Location = new System.Drawing.Point(4, 29);
            this.TpgFindById.Name = "TpgFindById";
            this.TpgFindById.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgFindById.Size = new System.Drawing.Size(1066, 411);
            this.TpgFindById.TabIndex = 0;
            this.TpgFindById.Text = "Get a Single Audit";
            this.TpgFindById.UseVisualStyleBackColor = true;
            // 
            // PrgAudit_FindByID
            // 
            this.PrgAudit_FindByID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrgAudit_FindByID.HelpVisible = false;
            this.PrgAudit_FindByID.Location = new System.Drawing.Point(18, 62);
            this.PrgAudit_FindByID.Name = "PrgAudit_FindByID";
            this.PrgAudit_FindByID.Size = new System.Drawing.Size(1042, 343);
            this.PrgAudit_FindByID.TabIndex = 3;
            // 
            // BtnAudit_FindByID
            // 
            this.BtnAudit_FindByID.Location = new System.Drawing.Point(231, 30);
            this.BtnAudit_FindByID.Name = "BtnAudit_FindByID";
            this.BtnAudit_FindByID.Size = new System.Drawing.Size(141, 23);
            this.BtnAudit_FindByID.TabIndex = 2;
            this.BtnAudit_FindByID.Text = "FindByID";
            this.BtnAudit_FindByID.UseVisualStyleBackColor = true;
            this.BtnAudit_FindByID.Click += new System.EventHandler(this.BtnAudit_FindByID_Click);
            // 
            // TxtAudit_FindByID_GUID
            // 
            this.TxtAudit_FindByID_GUID.Location = new System.Drawing.Point(18, 32);
            this.TxtAudit_FindByID_GUID.Name = "TxtAudit_FindByID_GUID";
            this.TxtAudit_FindByID_GUID.Size = new System.Drawing.Size(207, 20);
            this.TxtAudit_FindByID_GUID.TabIndex = 1;
            // 
            // LblAudit_FindByID_GUID
            // 
            this.LblAudit_FindByID_GUID.AutoSize = true;
            this.LblAudit_FindByID_GUID.Location = new System.Drawing.Point(15, 18);
            this.LblAudit_FindByID_GUID.Name = "LblAudit_FindByID_GUID";
            this.LblAudit_FindByID_GUID.Size = new System.Drawing.Size(84, 13);
            this.LblAudit_FindByID_GUID.TabIndex = 0;
            this.LblAudit_FindByID_GUID.Text = "Audit ID (GUID):";
            // 
            // TpgGetForObject
            // 
            this.TpgGetForObject.Controls.Add(this.GrbAudit_GFO);
            this.TpgGetForObject.Location = new System.Drawing.Point(4, 29);
            this.TpgGetForObject.Name = "TpgGetForObject";
            this.TpgGetForObject.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetForObject.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetForObject.TabIndex = 3;
            this.TpgGetForObject.Text = "Get Audits for an Object";
            this.TpgGetForObject.UseVisualStyleBackColor = true;
            // 
            // GrbAudit_GFO
            // 
            this.GrbAudit_GFO.Controls.Add(this.TxtAudit_GFO_GUID);
            this.GrbAudit_GFO.Controls.Add(this.LblAudit_GFO_GUID);
            this.GrbAudit_GFO.Controls.Add(this.chkAudit_GFO_NoFilter);
            this.GrbAudit_GFO.Controls.Add(this.TxtAudit_GFO_Total);
            this.GrbAudit_GFO.Controls.Add(this.LblAudit_GFO_Total);
            this.GrbAudit_GFO.Controls.Add(this.DgvAudit_GFO);
            this.GrbAudit_GFO.Controls.Add(this.BtnAudit_GetForObject);
            this.GrbAudit_GFO.Controls.Add(this.groupBox8);
            this.GrbAudit_GFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbAudit_GFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbAudit_GFO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrbAudit_GFO.Location = new System.Drawing.Point(3, 6);
            this.GrbAudit_GFO.Name = "GrbAudit_GFO";
            this.GrbAudit_GFO.Size = new System.Drawing.Size(1060, 402);
            this.GrbAudit_GFO.TabIndex = 1;
            this.GrbAudit_GFO.TabStop = false;
            this.GrbAudit_GFO.Text = "Method: Audits.GetForObject";
            // 
            // TxtAudit_GFO_GUID
            // 
            this.TxtAudit_GFO_GUID.Location = new System.Drawing.Point(666, 47);
            this.TxtAudit_GFO_GUID.Name = "TxtAudit_GFO_GUID";
            this.TxtAudit_GFO_GUID.Size = new System.Drawing.Size(261, 20);
            this.TxtAudit_GFO_GUID.TabIndex = 37;
            // 
            // LblAudit_GFO_GUID
            // 
            this.LblAudit_GFO_GUID.AutoSize = true;
            this.LblAudit_GFO_GUID.Location = new System.Drawing.Point(663, 31);
            this.LblAudit_GFO_GUID.Name = "LblAudit_GFO_GUID";
            this.LblAudit_GFO_GUID.Size = new System.Drawing.Size(91, 13);
            this.LblAudit_GFO_GUID.TabIndex = 36;
            this.LblAudit_GFO_GUID.Text = "Object ID (GUID):";
            // 
            // chkAudit_GFO_NoFilter
            // 
            this.chkAudit_GFO_NoFilter.AutoSize = true;
            this.chkAudit_GFO_NoFilter.Location = new System.Drawing.Point(527, 29);
            this.chkAudit_GFO_NoFilter.Name = "chkAudit_GFO_NoFilter";
            this.chkAudit_GFO_NoFilter.Size = new System.Drawing.Size(70, 17);
            this.chkAudit_GFO_NoFilter.TabIndex = 35;
            this.chkAudit_GFO_NoFilter.Text = "No Filters";
            this.chkAudit_GFO_NoFilter.UseVisualStyleBackColor = true;
            // 
            // TxtAudit_GFO_Total
            // 
            this.TxtAudit_GFO_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAudit_GFO_Total.Location = new System.Drawing.Point(954, 109);
            this.TxtAudit_GFO_Total.Name = "TxtAudit_GFO_Total";
            this.TxtAudit_GFO_Total.ReadOnly = true;
            this.TxtAudit_GFO_Total.Size = new System.Drawing.Size(100, 20);
            this.TxtAudit_GFO_Total.TabIndex = 34;
            // 
            // LblAudit_GFO_Total
            // 
            this.LblAudit_GFO_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAudit_GFO_Total.AutoSize = true;
            this.LblAudit_GFO_Total.Location = new System.Drawing.Point(864, 113);
            this.LblAudit_GFO_Total.Name = "LblAudit_GFO_Total";
            this.LblAudit_GFO_Total.Size = new System.Drawing.Size(85, 13);
            this.LblAudit_GFO_Total.TabIndex = 33;
            this.LblAudit_GFO_Total.Text = "Numb. of Audits:";
            // 
            // DgvAudit_GFO
            // 
            this.DgvAudit_GFO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAudit_GFO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAudit_GFO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAudit_GFO.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAudit_GFO.Location = new System.Drawing.Point(6, 136);
            this.DgvAudit_GFO.Name = "DgvAudit_GFO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAudit_GFO.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvAudit_GFO.Size = new System.Drawing.Size(1048, 257);
            this.DgvAudit_GFO.TabIndex = 32;
            // 
            // BtnAudit_GetForObject
            // 
            this.BtnAudit_GetForObject.Location = new System.Drawing.Point(6, 107);
            this.BtnAudit_GetForObject.Name = "BtnAudit_GetForObject";
            this.BtnAudit_GetForObject.Size = new System.Drawing.Size(515, 23);
            this.BtnAudit_GetForObject.TabIndex = 31;
            this.BtnAudit_GetForObject.Text = "GetForObject";
            this.BtnAudit_GetForObject.UseVisualStyleBackColor = true;
            this.BtnAudit_GetForObject.Click += new System.EventHandler(this.BtnAudit_GetForObject_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.DtpAudit_GFO_StartTime);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.DtpAudit_GFO_EndTime);
            this.groupBox8.Controls.Add(this.chkAudit_GFO_ExcludeDiscarded);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Location = new System.Drawing.Point(6, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(515, 82);
            this.groupBox8.TabIndex = 30;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Filters";
            // 
            // DtpAudit_GFO_StartTime
            // 
            this.DtpAudit_GFO_StartTime.Location = new System.Drawing.Point(80, 22);
            this.DtpAudit_GFO_StartTime.Name = "DtpAudit_GFO_StartTime";
            this.DtpAudit_GFO_StartTime.Size = new System.Drawing.Size(200, 20);
            this.DtpAudit_GFO_StartTime.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Start Time:";
            // 
            // DtpAudit_GFO_EndTime
            // 
            this.DtpAudit_GFO_EndTime.Location = new System.Drawing.Point(80, 49);
            this.DtpAudit_GFO_EndTime.Name = "DtpAudit_GFO_EndTime";
            this.DtpAudit_GFO_EndTime.Size = new System.Drawing.Size(200, 20);
            this.DtpAudit_GFO_EndTime.TabIndex = 22;
            // 
            // chkAudit_GFO_ExcludeDiscarded
            // 
            this.chkAudit_GFO_ExcludeDiscarded.AutoSize = true;
            this.chkAudit_GFO_ExcludeDiscarded.Location = new System.Drawing.Point(335, 49);
            this.chkAudit_GFO_ExcludeDiscarded.Name = "chkAudit_GFO_ExcludeDiscarded";
            this.chkAudit_GFO_ExcludeDiscarded.Size = new System.Drawing.Size(115, 17);
            this.chkAudit_GFO_ExcludeDiscarded.TabIndex = 26;
            this.chkAudit_GFO_ExcludeDiscarded.Text = "Exclude Discarded";
            this.chkAudit_GFO_ExcludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 55);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 23;
            this.label19.Text = "End Time:";
            // 
            // TpgGetAnnotations
            // 
            this.TpgGetAnnotations.Controls.Add(this.GrbGetAuditAnnotation);
            this.TpgGetAnnotations.Location = new System.Drawing.Point(4, 29);
            this.TpgGetAnnotations.Name = "TpgGetAnnotations";
            this.TpgGetAnnotations.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetAnnotations.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetAnnotations.TabIndex = 4;
            this.TpgGetAnnotations.Text = "Get Audit Annotations";
            this.TpgGetAnnotations.UseVisualStyleBackColor = true;
            // 
            // GrbGetAuditAnnotation
            // 
            this.GrbGetAuditAnnotation.Controls.Add(this.LblAudits_Annotations);
            this.GrbGetAuditAnnotation.Controls.Add(this.TxtAudits_Annotations);
            this.GrbGetAuditAnnotation.Controls.Add(this.BtnAudit_GetAnnotations);
            this.GrbGetAuditAnnotation.Controls.Add(this.TxtAudit_GetAnnotations_GUID);
            this.GrbGetAuditAnnotation.Controls.Add(this.LblAudit_GetAnnotations_GUID);
            this.GrbGetAuditAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetAuditAnnotation.Location = new System.Drawing.Point(3, 6);
            this.GrbGetAuditAnnotation.Name = "GrbGetAuditAnnotation";
            this.GrbGetAuditAnnotation.Size = new System.Drawing.Size(1060, 402);
            this.GrbGetAuditAnnotation.TabIndex = 1;
            this.GrbGetAuditAnnotation.TabStop = false;
            this.GrbGetAuditAnnotation.Text = "Method: Audits.GetAnnotations";
            // 
            // LblAudits_Annotations
            // 
            this.LblAudits_Annotations.AutoSize = true;
            this.LblAudits_Annotations.Location = new System.Drawing.Point(6, 86);
            this.LblAudits_Annotations.Name = "LblAudits_Annotations";
            this.LblAudits_Annotations.Size = new System.Drawing.Size(66, 13);
            this.LblAudits_Annotations.TabIndex = 4;
            this.LblAudits_Annotations.Text = "Annotations:";
            // 
            // TxtAudits_Annotations
            // 
            this.TxtAudits_Annotations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAudits_Annotations.Location = new System.Drawing.Point(6, 102);
            this.TxtAudits_Annotations.Multiline = true;
            this.TxtAudits_Annotations.Name = "TxtAudits_Annotations";
            this.TxtAudits_Annotations.Size = new System.Drawing.Size(1047, 289);
            this.TxtAudits_Annotations.TabIndex = 3;
            // 
            // BtnAudit_GetAnnotations
            // 
            this.BtnAudit_GetAnnotations.Location = new System.Drawing.Point(254, 39);
            this.BtnAudit_GetAnnotations.Name = "BtnAudit_GetAnnotations";
            this.BtnAudit_GetAnnotations.Size = new System.Drawing.Size(157, 23);
            this.BtnAudit_GetAnnotations.TabIndex = 2;
            this.BtnAudit_GetAnnotations.Text = "GetAnnotations";
            this.BtnAudit_GetAnnotations.UseVisualStyleBackColor = true;
            this.BtnAudit_GetAnnotations.Click += new System.EventHandler(this.BtnAudit_GetAnnotations_Click);
            // 
            // TxtAudit_GetAnnotations_GUID
            // 
            this.TxtAudit_GetAnnotations_GUID.Location = new System.Drawing.Point(14, 41);
            this.TxtAudit_GetAnnotations_GUID.Name = "TxtAudit_GetAnnotations_GUID";
            this.TxtAudit_GetAnnotations_GUID.Size = new System.Drawing.Size(234, 20);
            this.TxtAudit_GetAnnotations_GUID.TabIndex = 1;
            // 
            // LblAudit_GetAnnotations_GUID
            // 
            this.LblAudit_GetAnnotations_GUID.AutoSize = true;
            this.LblAudit_GetAnnotations_GUID.Location = new System.Drawing.Point(11, 25);
            this.LblAudit_GetAnnotations_GUID.Name = "LblAudit_GetAnnotations_GUID";
            this.LblAudit_GetAnnotations_GUID.Size = new System.Drawing.Size(84, 13);
            this.LblAudit_GetAnnotations_GUID.TabIndex = 0;
            this.LblAudit_GetAnnotations_GUID.Text = "Audit ID (GUID):";
            this.LblAudit_GetAnnotations_GUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TpgAddAnnotation
            // 
            this.TpgAddAnnotation.Controls.Add(this.GrbAddAuditAnnotation);
            this.TpgAddAnnotation.Location = new System.Drawing.Point(4, 29);
            this.TpgAddAnnotation.Name = "TpgAddAnnotation";
            this.TpgAddAnnotation.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgAddAnnotation.Size = new System.Drawing.Size(1066, 411);
            this.TpgAddAnnotation.TabIndex = 5;
            this.TpgAddAnnotation.Text = "Add Annotation";
            this.TpgAddAnnotation.UseVisualStyleBackColor = true;
            // 
            // GrbAddAuditAnnotation
            // 
            this.GrbAddAuditAnnotation.Controls.Add(this.BtnAudit_AddAnnotation);
            this.GrbAddAuditAnnotation.Controls.Add(this.TxtAudit_AddAnnotation_Text);
            this.GrbAddAuditAnnotation.Controls.Add(this.LblAudit_AddAnnotation_Text);
            this.GrbAddAuditAnnotation.Controls.Add(this.TxtAudit_AddAnnotation_GUID);
            this.GrbAddAuditAnnotation.Controls.Add(this.LblAudit_AddAnnotation_GUID);
            this.GrbAddAuditAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbAddAuditAnnotation.Location = new System.Drawing.Point(3, 6);
            this.GrbAddAuditAnnotation.Name = "GrbAddAuditAnnotation";
            this.GrbAddAuditAnnotation.Size = new System.Drawing.Size(1060, 402);
            this.GrbAddAuditAnnotation.TabIndex = 0;
            this.GrbAddAuditAnnotation.TabStop = false;
            this.GrbAddAuditAnnotation.Text = "Method: Audits.AddAnnotation";
            // 
            // BtnAudit_AddAnnotation
            // 
            this.BtnAudit_AddAnnotation.Location = new System.Drawing.Point(14, 121);
            this.BtnAudit_AddAnnotation.Name = "BtnAudit_AddAnnotation";
            this.BtnAudit_AddAnnotation.Size = new System.Drawing.Size(157, 23);
            this.BtnAudit_AddAnnotation.TabIndex = 6;
            this.BtnAudit_AddAnnotation.Text = "AddAnnotation";
            this.BtnAudit_AddAnnotation.UseVisualStyleBackColor = true;
            this.BtnAudit_AddAnnotation.Click += new System.EventHandler(this.BtnAudit_AddAnnotation_Click);
            // 
            // TxtAudit_AddAnnotation_Text
            // 
            this.TxtAudit_AddAnnotation_Text.Location = new System.Drawing.Point(14, 83);
            this.TxtAudit_AddAnnotation_Text.Name = "TxtAudit_AddAnnotation_Text";
            this.TxtAudit_AddAnnotation_Text.Size = new System.Drawing.Size(682, 20);
            this.TxtAudit_AddAnnotation_Text.TabIndex = 5;
            // 
            // LblAudit_AddAnnotation_Text
            // 
            this.LblAudit_AddAnnotation_Text.AutoSize = true;
            this.LblAudit_AddAnnotation_Text.Location = new System.Drawing.Point(11, 67);
            this.LblAudit_AddAnnotation_Text.Name = "LblAudit_AddAnnotation_Text";
            this.LblAudit_AddAnnotation_Text.Size = new System.Drawing.Size(81, 13);
            this.LblAudit_AddAnnotation_Text.TabIndex = 4;
            this.LblAudit_AddAnnotation_Text.Text = "Annotation text:";
            this.LblAudit_AddAnnotation_Text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAudit_AddAnnotation_GUID
            // 
            this.TxtAudit_AddAnnotation_GUID.Location = new System.Drawing.Point(14, 44);
            this.TxtAudit_AddAnnotation_GUID.Name = "TxtAudit_AddAnnotation_GUID";
            this.TxtAudit_AddAnnotation_GUID.Size = new System.Drawing.Size(234, 20);
            this.TxtAudit_AddAnnotation_GUID.TabIndex = 3;
            // 
            // LblAudit_AddAnnotation_GUID
            // 
            this.LblAudit_AddAnnotation_GUID.AutoSize = true;
            this.LblAudit_AddAnnotation_GUID.Location = new System.Drawing.Point(11, 28);
            this.LblAudit_AddAnnotation_GUID.Name = "LblAudit_AddAnnotation_GUID";
            this.LblAudit_AddAnnotation_GUID.Size = new System.Drawing.Size(84, 13);
            this.LblAudit_AddAnnotation_GUID.TabIndex = 2;
            this.LblAudit_AddAnnotation_GUID.Text = "Audit ID (GUID):";
            this.LblAudit_AddAnnotation_GUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TpgAddAnnotationMulti
            // 
            this.TpgAddAnnotationMulti.Controls.Add(this.GrbAddAuditAnnotationMulti);
            this.TpgAddAnnotationMulti.Location = new System.Drawing.Point(4, 29);
            this.TpgAddAnnotationMulti.Name = "TpgAddAnnotationMulti";
            this.TpgAddAnnotationMulti.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgAddAnnotationMulti.Size = new System.Drawing.Size(1066, 411);
            this.TpgAddAnnotationMulti.TabIndex = 6;
            this.TpgAddAnnotationMulti.Text = "Add Multiple Annotations";
            this.TpgAddAnnotationMulti.UseVisualStyleBackColor = true;
            // 
            // GrbAddAuditAnnotationMulti
            // 
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.TxtAudit_AddAnnotationMulti_Text2);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.LblAudit_AddAnnotationMulti_Text2);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.TxtAudit_AddAnnotationMulti_GUID2);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.LblAudit_AddAnnotationMulti_GUID2);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.BtnAudit_AddAnnotationMultiple);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.TxtAudit_AddAnnotationMulti_Text1);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.LblAudit_AddAnnotationMulti_Text1);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.TxtAudit_AddAnnotationMulti_GUID1);
            this.GrbAddAuditAnnotationMulti.Controls.Add(this.LblAudit_AddAnnotationMulti_GUID1);
            this.GrbAddAuditAnnotationMulti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbAddAuditAnnotationMulti.Location = new System.Drawing.Point(3, 6);
            this.GrbAddAuditAnnotationMulti.Name = "GrbAddAuditAnnotationMulti";
            this.GrbAddAuditAnnotationMulti.Size = new System.Drawing.Size(1060, 402);
            this.GrbAddAuditAnnotationMulti.TabIndex = 1;
            this.GrbAddAuditAnnotationMulti.TabStop = false;
            this.GrbAddAuditAnnotationMulti.Text = "Method: Audits.AddAnnotationMultiple";
            // 
            // TxtAudit_AddAnnotationMulti_Text2
            // 
            this.TxtAudit_AddAnnotationMulti_Text2.Location = new System.Drawing.Point(273, 83);
            this.TxtAudit_AddAnnotationMulti_Text2.Name = "TxtAudit_AddAnnotationMulti_Text2";
            this.TxtAudit_AddAnnotationMulti_Text2.Size = new System.Drawing.Size(682, 20);
            this.TxtAudit_AddAnnotationMulti_Text2.TabIndex = 10;
            // 
            // LblAudit_AddAnnotationMulti_Text2
            // 
            this.LblAudit_AddAnnotationMulti_Text2.AutoSize = true;
            this.LblAudit_AddAnnotationMulti_Text2.Location = new System.Drawing.Point(270, 67);
            this.LblAudit_AddAnnotationMulti_Text2.Name = "LblAudit_AddAnnotationMulti_Text2";
            this.LblAudit_AddAnnotationMulti_Text2.Size = new System.Drawing.Size(87, 13);
            this.LblAudit_AddAnnotationMulti_Text2.TabIndex = 9;
            this.LblAudit_AddAnnotationMulti_Text2.Text = "Annotation text2:";
            this.LblAudit_AddAnnotationMulti_Text2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAudit_AddAnnotationMulti_GUID2
            // 
            this.TxtAudit_AddAnnotationMulti_GUID2.Location = new System.Drawing.Point(14, 83);
            this.TxtAudit_AddAnnotationMulti_GUID2.Name = "TxtAudit_AddAnnotationMulti_GUID2";
            this.TxtAudit_AddAnnotationMulti_GUID2.Size = new System.Drawing.Size(234, 20);
            this.TxtAudit_AddAnnotationMulti_GUID2.TabIndex = 8;
            // 
            // LblAudit_AddAnnotationMulti_GUID2
            // 
            this.LblAudit_AddAnnotationMulti_GUID2.AutoSize = true;
            this.LblAudit_AddAnnotationMulti_GUID2.Location = new System.Drawing.Point(11, 67);
            this.LblAudit_AddAnnotationMulti_GUID2.Name = "LblAudit_AddAnnotationMulti_GUID2";
            this.LblAudit_AddAnnotationMulti_GUID2.Size = new System.Drawing.Size(90, 13);
            this.LblAudit_AddAnnotationMulti_GUID2.TabIndex = 7;
            this.LblAudit_AddAnnotationMulti_GUID2.Text = "Audit ID2 (GUID):";
            this.LblAudit_AddAnnotationMulti_GUID2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnAudit_AddAnnotationMultiple
            // 
            this.BtnAudit_AddAnnotationMultiple.Location = new System.Drawing.Point(14, 121);
            this.BtnAudit_AddAnnotationMultiple.Name = "BtnAudit_AddAnnotationMultiple";
            this.BtnAudit_AddAnnotationMultiple.Size = new System.Drawing.Size(157, 23);
            this.BtnAudit_AddAnnotationMultiple.TabIndex = 6;
            this.BtnAudit_AddAnnotationMultiple.Text = "AddAnnotationMultiple";
            this.BtnAudit_AddAnnotationMultiple.UseVisualStyleBackColor = true;
            this.BtnAudit_AddAnnotationMultiple.Click += new System.EventHandler(this.BtnAudit_AddAnnotationMultiple_Click);
            // 
            // TxtAudit_AddAnnotationMulti_Text1
            // 
            this.TxtAudit_AddAnnotationMulti_Text1.Location = new System.Drawing.Point(273, 44);
            this.TxtAudit_AddAnnotationMulti_Text1.Name = "TxtAudit_AddAnnotationMulti_Text1";
            this.TxtAudit_AddAnnotationMulti_Text1.Size = new System.Drawing.Size(682, 20);
            this.TxtAudit_AddAnnotationMulti_Text1.TabIndex = 5;
            // 
            // LblAudit_AddAnnotationMulti_Text1
            // 
            this.LblAudit_AddAnnotationMulti_Text1.AutoSize = true;
            this.LblAudit_AddAnnotationMulti_Text1.Location = new System.Drawing.Point(270, 28);
            this.LblAudit_AddAnnotationMulti_Text1.Name = "LblAudit_AddAnnotationMulti_Text1";
            this.LblAudit_AddAnnotationMulti_Text1.Size = new System.Drawing.Size(87, 13);
            this.LblAudit_AddAnnotationMulti_Text1.TabIndex = 4;
            this.LblAudit_AddAnnotationMulti_Text1.Text = "Annotation text1:";
            this.LblAudit_AddAnnotationMulti_Text1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAudit_AddAnnotationMulti_GUID1
            // 
            this.TxtAudit_AddAnnotationMulti_GUID1.Location = new System.Drawing.Point(14, 44);
            this.TxtAudit_AddAnnotationMulti_GUID1.Name = "TxtAudit_AddAnnotationMulti_GUID1";
            this.TxtAudit_AddAnnotationMulti_GUID1.Size = new System.Drawing.Size(234, 20);
            this.TxtAudit_AddAnnotationMulti_GUID1.TabIndex = 3;
            // 
            // LblAudit_AddAnnotationMulti_GUID1
            // 
            this.LblAudit_AddAnnotationMulti_GUID1.AutoSize = true;
            this.LblAudit_AddAnnotationMulti_GUID1.Location = new System.Drawing.Point(11, 28);
            this.LblAudit_AddAnnotationMulti_GUID1.Name = "LblAudit_AddAnnotationMulti_GUID1";
            this.LblAudit_AddAnnotationMulti_GUID1.Size = new System.Drawing.Size(90, 13);
            this.LblAudit_AddAnnotationMulti_GUID1.TabIndex = 2;
            this.LblAudit_AddAnnotationMulti_GUID1.Text = "Audit ID1 (GUID):";
            this.LblAudit_AddAnnotationMulti_GUID1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TpgDiscard
            // 
            this.TpgDiscard.Controls.Add(this.GrbDiscardAudit);
            this.TpgDiscard.Location = new System.Drawing.Point(4, 29);
            this.TpgDiscard.Name = "TpgDiscard";
            this.TpgDiscard.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgDiscard.Size = new System.Drawing.Size(1066, 411);
            this.TpgDiscard.TabIndex = 2;
            this.TpgDiscard.Text = "Discard an Audit";
            this.TpgDiscard.UseVisualStyleBackColor = true;
            // 
            // GrbDiscardAudit
            // 
            this.GrbDiscardAudit.Controls.Add(this.BtnAudit_Discard);
            this.GrbDiscardAudit.Controls.Add(this.TxtAudit_Discard_Text);
            this.GrbDiscardAudit.Controls.Add(this.LblAudit_Discard_Text);
            this.GrbDiscardAudit.Controls.Add(this.TxtAudit_Discard_GUID);
            this.GrbDiscardAudit.Controls.Add(this.LblAudit_Discard_GUID);
            this.GrbDiscardAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbDiscardAudit.Location = new System.Drawing.Point(3, 6);
            this.GrbDiscardAudit.Name = "GrbDiscardAudit";
            this.GrbDiscardAudit.Size = new System.Drawing.Size(1060, 402);
            this.GrbDiscardAudit.TabIndex = 1;
            this.GrbDiscardAudit.TabStop = false;
            this.GrbDiscardAudit.Text = "Method: Audits.Discard";
            // 
            // BtnAudit_Discard
            // 
            this.BtnAudit_Discard.Location = new System.Drawing.Point(14, 109);
            this.BtnAudit_Discard.Name = "BtnAudit_Discard";
            this.BtnAudit_Discard.Size = new System.Drawing.Size(157, 23);
            this.BtnAudit_Discard.TabIndex = 6;
            this.BtnAudit_Discard.Text = "Discard";
            this.BtnAudit_Discard.UseVisualStyleBackColor = true;
            this.BtnAudit_Discard.Click += new System.EventHandler(this.BtnAudit_Discard_Click);
            // 
            // TxtAudit_Discard_Text
            // 
            this.TxtAudit_Discard_Text.Location = new System.Drawing.Point(14, 83);
            this.TxtAudit_Discard_Text.Name = "TxtAudit_Discard_Text";
            this.TxtAudit_Discard_Text.Size = new System.Drawing.Size(682, 20);
            this.TxtAudit_Discard_Text.TabIndex = 5;
            // 
            // LblAudit_Discard_Text
            // 
            this.LblAudit_Discard_Text.AutoSize = true;
            this.LblAudit_Discard_Text.Location = new System.Drawing.Point(11, 67);
            this.LblAudit_Discard_Text.Name = "LblAudit_Discard_Text";
            this.LblAudit_Discard_Text.Size = new System.Drawing.Size(81, 13);
            this.LblAudit_Discard_Text.TabIndex = 4;
            this.LblAudit_Discard_Text.Text = "Annotation text:";
            this.LblAudit_Discard_Text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAudit_Discard_GUID
            // 
            this.TxtAudit_Discard_GUID.Location = new System.Drawing.Point(14, 44);
            this.TxtAudit_Discard_GUID.Name = "TxtAudit_Discard_GUID";
            this.TxtAudit_Discard_GUID.Size = new System.Drawing.Size(234, 20);
            this.TxtAudit_Discard_GUID.TabIndex = 3;
            // 
            // LblAudit_Discard_GUID
            // 
            this.LblAudit_Discard_GUID.AutoSize = true;
            this.LblAudit_Discard_GUID.Location = new System.Drawing.Point(11, 28);
            this.LblAudit_Discard_GUID.Name = "LblAudit_Discard_GUID";
            this.LblAudit_Discard_GUID.Size = new System.Drawing.Size(84, 13);
            this.LblAudit_Discard_GUID.TabIndex = 2;
            this.LblAudit_Discard_GUID.Text = "Audit ID (GUID):";
            this.LblAudit_Discard_GUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TpgDiscardMultiple
            // 
            this.TpgDiscardMultiple.Controls.Add(this.GrbDiscardAuditMulti);
            this.TpgDiscardMultiple.Location = new System.Drawing.Point(4, 29);
            this.TpgDiscardMultiple.Name = "TpgDiscardMultiple";
            this.TpgDiscardMultiple.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgDiscardMultiple.Size = new System.Drawing.Size(1066, 411);
            this.TpgDiscardMultiple.TabIndex = 7;
            this.TpgDiscardMultiple.Text = "Discard Multiple Audits";
            this.TpgDiscardMultiple.UseVisualStyleBackColor = true;
            // 
            // GrbDiscardAuditMulti
            // 
            this.GrbDiscardAuditMulti.Controls.Add(this.TxtAudit_DiscardMulti_Text2);
            this.GrbDiscardAuditMulti.Controls.Add(this.LblAudit_DiscardMulti_Text2);
            this.GrbDiscardAuditMulti.Controls.Add(this.TxtAudit_DiscardMulti_GUID2);
            this.GrbDiscardAuditMulti.Controls.Add(this.LblAudit_DiscardMulti_GUID2);
            this.GrbDiscardAuditMulti.Controls.Add(this.BtnAudit_DiscardMultiple);
            this.GrbDiscardAuditMulti.Controls.Add(this.TxtAudit_DiscardMulti_Text1);
            this.GrbDiscardAuditMulti.Controls.Add(this.LblAudit_DiscardMulti_Text1);
            this.GrbDiscardAuditMulti.Controls.Add(this.TxtAudit_DiscardMulti_GUID1);
            this.GrbDiscardAuditMulti.Controls.Add(this.LblAudit_DiscardMulti_GUID1);
            this.GrbDiscardAuditMulti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbDiscardAuditMulti.Location = new System.Drawing.Point(3, 6);
            this.GrbDiscardAuditMulti.Name = "GrbDiscardAuditMulti";
            this.GrbDiscardAuditMulti.Size = new System.Drawing.Size(1060, 402);
            this.GrbDiscardAuditMulti.TabIndex = 2;
            this.GrbDiscardAuditMulti.TabStop = false;
            this.GrbDiscardAuditMulti.Text = "Method: Audits.AddAnnotationMultiple";
            // 
            // TxtAudit_DiscardMulti_Text2
            // 
            this.TxtAudit_DiscardMulti_Text2.Location = new System.Drawing.Point(273, 83);
            this.TxtAudit_DiscardMulti_Text2.Name = "TxtAudit_DiscardMulti_Text2";
            this.TxtAudit_DiscardMulti_Text2.Size = new System.Drawing.Size(682, 20);
            this.TxtAudit_DiscardMulti_Text2.TabIndex = 10;
            // 
            // LblAudit_DiscardMulti_Text2
            // 
            this.LblAudit_DiscardMulti_Text2.AutoSize = true;
            this.LblAudit_DiscardMulti_Text2.Location = new System.Drawing.Point(270, 67);
            this.LblAudit_DiscardMulti_Text2.Name = "LblAudit_DiscardMulti_Text2";
            this.LblAudit_DiscardMulti_Text2.Size = new System.Drawing.Size(87, 13);
            this.LblAudit_DiscardMulti_Text2.TabIndex = 9;
            this.LblAudit_DiscardMulti_Text2.Text = "Annotation text2:";
            this.LblAudit_DiscardMulti_Text2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAudit_DiscardMulti_GUID2
            // 
            this.TxtAudit_DiscardMulti_GUID2.Location = new System.Drawing.Point(14, 83);
            this.TxtAudit_DiscardMulti_GUID2.Name = "TxtAudit_DiscardMulti_GUID2";
            this.TxtAudit_DiscardMulti_GUID2.Size = new System.Drawing.Size(234, 20);
            this.TxtAudit_DiscardMulti_GUID2.TabIndex = 8;
            // 
            // LblAudit_DiscardMulti_GUID2
            // 
            this.LblAudit_DiscardMulti_GUID2.AutoSize = true;
            this.LblAudit_DiscardMulti_GUID2.Location = new System.Drawing.Point(11, 67);
            this.LblAudit_DiscardMulti_GUID2.Name = "LblAudit_DiscardMulti_GUID2";
            this.LblAudit_DiscardMulti_GUID2.Size = new System.Drawing.Size(90, 13);
            this.LblAudit_DiscardMulti_GUID2.TabIndex = 7;
            this.LblAudit_DiscardMulti_GUID2.Text = "Audit ID2 (GUID):";
            this.LblAudit_DiscardMulti_GUID2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnAudit_DiscardMultiple
            // 
            this.BtnAudit_DiscardMultiple.Location = new System.Drawing.Point(14, 121);
            this.BtnAudit_DiscardMultiple.Name = "BtnAudit_DiscardMultiple";
            this.BtnAudit_DiscardMultiple.Size = new System.Drawing.Size(157, 23);
            this.BtnAudit_DiscardMultiple.TabIndex = 6;
            this.BtnAudit_DiscardMultiple.Text = "DiscardMultiple";
            this.BtnAudit_DiscardMultiple.UseVisualStyleBackColor = true;
            this.BtnAudit_DiscardMultiple.Click += new System.EventHandler(this.BtnAudit_DiscardMultiple_Click);
            // 
            // TxtAudit_DiscardMulti_Text1
            // 
            this.TxtAudit_DiscardMulti_Text1.Location = new System.Drawing.Point(273, 44);
            this.TxtAudit_DiscardMulti_Text1.Name = "TxtAudit_DiscardMulti_Text1";
            this.TxtAudit_DiscardMulti_Text1.Size = new System.Drawing.Size(682, 20);
            this.TxtAudit_DiscardMulti_Text1.TabIndex = 5;
            // 
            // LblAudit_DiscardMulti_Text1
            // 
            this.LblAudit_DiscardMulti_Text1.AutoSize = true;
            this.LblAudit_DiscardMulti_Text1.Location = new System.Drawing.Point(270, 28);
            this.LblAudit_DiscardMulti_Text1.Name = "LblAudit_DiscardMulti_Text1";
            this.LblAudit_DiscardMulti_Text1.Size = new System.Drawing.Size(87, 13);
            this.LblAudit_DiscardMulti_Text1.TabIndex = 4;
            this.LblAudit_DiscardMulti_Text1.Text = "Annotation text1:";
            this.LblAudit_DiscardMulti_Text1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAudit_DiscardMulti_GUID1
            // 
            this.TxtAudit_DiscardMulti_GUID1.Location = new System.Drawing.Point(14, 44);
            this.TxtAudit_DiscardMulti_GUID1.Name = "TxtAudit_DiscardMulti_GUID1";
            this.TxtAudit_DiscardMulti_GUID1.Size = new System.Drawing.Size(234, 20);
            this.TxtAudit_DiscardMulti_GUID1.TabIndex = 3;
            // 
            // LblAudit_DiscardMulti_GUID1
            // 
            this.LblAudit_DiscardMulti_GUID1.AutoSize = true;
            this.LblAudit_DiscardMulti_GUID1.Location = new System.Drawing.Point(11, 28);
            this.LblAudit_DiscardMulti_GUID1.Name = "LblAudit_DiscardMulti_GUID1";
            this.LblAudit_DiscardMulti_GUID1.Size = new System.Drawing.Size(90, 13);
            this.LblAudit_DiscardMulti_GUID1.TabIndex = 2;
            this.LblAudit_DiscardMulti_GUID1.Text = "Audit ID1 (GUID):";
            this.LblAudit_DiscardMulti_GUID1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TpgEnumeration
            // 
            this.TpgEnumeration.BackColor = System.Drawing.SystemColors.Control;
            this.TpgEnumeration.Location = new System.Drawing.Point(4, 34);
            this.TpgEnumeration.Name = "TpgEnumeration";
            this.TpgEnumeration.Padding = new System.Windows.Forms.Padding(3);
            this.TpgEnumeration.Size = new System.Drawing.Size(1080, 450);
            this.TpgEnumeration.TabIndex = 7;
            this.TpgEnumeration.Text = "ENUMERATIONS";
            // 
            // TpgEquipment
            // 
            this.TpgEquipment.BackColor = System.Drawing.SystemColors.Control;
            this.TpgEquipment.Location = new System.Drawing.Point(4, 34);
            this.TpgEquipment.Name = "TpgEquipment";
            this.TpgEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgEquipment.Size = new System.Drawing.Size(1080, 450);
            this.TpgEquipment.TabIndex = 8;
            this.TpgEquipment.Text = "EQUIPMENTS";
            // 
            // TpgNetworkDevice
            // 
            this.TpgNetworkDevice.BackColor = System.Drawing.SystemColors.Control;
            this.TpgNetworkDevice.Location = new System.Drawing.Point(4, 34);
            this.TpgNetworkDevice.Name = "TpgNetworkDevice";
            this.TpgNetworkDevice.Padding = new System.Windows.Forms.Padding(3);
            this.TpgNetworkDevice.Size = new System.Drawing.Size(1080, 450);
            this.TpgNetworkDevice.TabIndex = 9;
            this.TpgNetworkDevice.Text = "NETWORK DEVICES";
            // 
            // TpgObject
            // 
            this.TpgObject.BackColor = System.Drawing.SystemColors.Control;
            this.TpgObject.Location = new System.Drawing.Point(4, 34);
            this.TpgObject.Name = "TpgObject";
            this.TpgObject.Padding = new System.Windows.Forms.Padding(3);
            this.TpgObject.Size = new System.Drawing.Size(1080, 450);
            this.TpgObject.TabIndex = 5;
            this.TpgObject.Text = "OBJECTS";
            // 
            // TpgSpace
            // 
            this.TpgSpace.BackColor = System.Drawing.SystemColors.Control;
            this.TpgSpace.Location = new System.Drawing.Point(4, 34);
            this.TpgSpace.Name = "TpgSpace";
            this.TpgSpace.Padding = new System.Windows.Forms.Padding(3);
            this.TpgSpace.Size = new System.Drawing.Size(1080, 450);
            this.TpgSpace.TabIndex = 10;
            this.TpgSpace.Text = "SPACES";
            // 
            // TpgTrend
            // 
            this.TpgTrend.BackColor = System.Drawing.SystemColors.Control;
            this.TpgTrend.Location = new System.Drawing.Point(4, 34);
            this.TpgTrend.Name = "TpgTrend";
            this.TpgTrend.Padding = new System.Windows.Forms.Padding(3);
            this.TpgTrend.Size = new System.Drawing.Size(1080, 450);
            this.TpgTrend.TabIndex = 1;
            this.TpgTrend.Text = "TRENDS (SAMPLES)";
            // 
            // TpgStream
            // 
            this.TpgStream.BackColor = System.Drawing.SystemColors.Control;
            this.TpgStream.Location = new System.Drawing.Point(4, 34);
            this.TpgStream.Name = "TpgStream";
            this.TpgStream.Padding = new System.Windows.Forms.Padding(3);
            this.TpgStream.Size = new System.Drawing.Size(1080, 450);
            this.TpgStream.TabIndex = 11;
            this.TpgStream.Text = "STREAMS";
            // 
            // TpgMisc
            // 
            this.TpgMisc.BackColor = System.Drawing.SystemColors.Control;
            this.TpgMisc.Controls.Add(this.TabMiscellanea);
            this.TpgMisc.Location = new System.Drawing.Point(4, 34);
            this.TpgMisc.Name = "TpgMisc";
            this.TpgMisc.Padding = new System.Windows.Forms.Padding(3);
            this.TpgMisc.Size = new System.Drawing.Size(1080, 450);
            this.TpgMisc.TabIndex = 6;
            this.TpgMisc.Text = "MISCELLANEA";
            // 
            // TabMiscellanea
            // 
            this.TabMiscellanea.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMiscellanea.Controls.Add(this.TpgMisc_GetServerTime);
            this.TabMiscellanea.Controls.Add(this.TpgMisc_Localize);
            this.TabMiscellanea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMiscellanea.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMiscellanea.Location = new System.Drawing.Point(3, 3);
            this.TabMiscellanea.Name = "TabMiscellanea";
            this.TabMiscellanea.SelectedIndex = 0;
            this.TabMiscellanea.Size = new System.Drawing.Size(1074, 444);
            this.TabMiscellanea.TabIndex = 33;
            // 
            // TpgMisc_GetServerTime
            // 
            this.TpgMisc_GetServerTime.Controls.Add(this.LblMisc_Title1);
            this.TpgMisc_GetServerTime.Controls.Add(this.BtnMisc_GetServerTime);
            this.TpgMisc_GetServerTime.Controls.Add(this.TxtMisc_ServerTime);
            this.TpgMisc_GetServerTime.Location = new System.Drawing.Point(4, 29);
            this.TpgMisc_GetServerTime.Name = "TpgMisc_GetServerTime";
            this.TpgMisc_GetServerTime.Padding = new System.Windows.Forms.Padding(3);
            this.TpgMisc_GetServerTime.Size = new System.Drawing.Size(1066, 411);
            this.TpgMisc_GetServerTime.TabIndex = 0;
            this.TpgMisc_GetServerTime.Text = "Get Server Time";
            this.TpgMisc_GetServerTime.UseVisualStyleBackColor = true;
            // 
            // LblMisc_Title1
            // 
            this.LblMisc_Title1.AutoSize = true;
            this.LblMisc_Title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMisc_Title1.Location = new System.Drawing.Point(6, 3);
            this.LblMisc_Title1.Name = "LblMisc_Title1";
            this.LblMisc_Title1.Size = new System.Drawing.Size(172, 16);
            this.LblMisc_Title1.TabIndex = 33;
            this.LblMisc_Title1.Text = "Method: GetServerTime";
            // 
            // BtnMisc_GetServerTime
            // 
            this.BtnMisc_GetServerTime.Location = new System.Drawing.Point(9, 36);
            this.BtnMisc_GetServerTime.Name = "BtnMisc_GetServerTime";
            this.BtnMisc_GetServerTime.Size = new System.Drawing.Size(97, 20);
            this.BtnMisc_GetServerTime.TabIndex = 31;
            this.BtnMisc_GetServerTime.Text = "Get Server Time";
            this.BtnMisc_GetServerTime.UseVisualStyleBackColor = true;
            this.BtnMisc_GetServerTime.Click += new System.EventHandler(this.BtnMisc_GetServerTime_Click);
            // 
            // TxtMisc_ServerTime
            // 
            this.TxtMisc_ServerTime.Location = new System.Drawing.Point(109, 36);
            this.TxtMisc_ServerTime.Name = "TxtMisc_ServerTime";
            this.TxtMisc_ServerTime.Size = new System.Drawing.Size(231, 20);
            this.TxtMisc_ServerTime.TabIndex = 32;
            // 
            // TpgMisc_Localize
            // 
            this.TpgMisc_Localize.Controls.Add(this.LblMisc_Localize_CultureInfo);
            this.TpgMisc_Localize.Controls.Add(this.LblEnum_LocalizedText);
            this.TpgMisc_Localize.Controls.Add(this.TxtEnum_LocalizedText);
            this.TpgMisc_Localize.Controls.Add(this.BtnEnum_Localize);
            this.TpgMisc_Localize.Controls.Add(this.CmbMisc_Localize_CultureInfo);
            this.TpgMisc_Localize.Controls.Add(this.TxtEnum_SourceText);
            this.TpgMisc_Localize.Controls.Add(this.LblEnum_SourceText);
            this.TpgMisc_Localize.Controls.Add(this.LblMisc_Title2);
            this.TpgMisc_Localize.Location = new System.Drawing.Point(4, 29);
            this.TpgMisc_Localize.Name = "TpgMisc_Localize";
            this.TpgMisc_Localize.Padding = new System.Windows.Forms.Padding(3);
            this.TpgMisc_Localize.Size = new System.Drawing.Size(1066, 411);
            this.TpgMisc_Localize.TabIndex = 1;
            this.TpgMisc_Localize.Text = "Get Localization";
            this.TpgMisc_Localize.UseVisualStyleBackColor = true;
            // 
            // LblMisc_Localize_CultureInfo
            // 
            this.LblMisc_Localize_CultureInfo.AutoSize = true;
            this.LblMisc_Localize_CultureInfo.Location = new System.Drawing.Point(10, 57);
            this.LblMisc_Localize_CultureInfo.Name = "LblMisc_Localize_CultureInfo";
            this.LblMisc_Localize_CultureInfo.Size = new System.Drawing.Size(61, 13);
            this.LblMisc_Localize_CultureInfo.TabIndex = 12;
            this.LblMisc_Localize_CultureInfo.Text = "Culture Info";
            // 
            // LblEnum_LocalizedText
            // 
            this.LblEnum_LocalizedText.AutoSize = true;
            this.LblEnum_LocalizedText.Location = new System.Drawing.Point(6, 138);
            this.LblEnum_LocalizedText.Name = "LblEnum_LocalizedText";
            this.LblEnum_LocalizedText.Size = new System.Drawing.Size(76, 13);
            this.LblEnum_LocalizedText.TabIndex = 11;
            this.LblEnum_LocalizedText.Text = "Localized Text";
            // 
            // TxtEnum_LocalizedText
            // 
            this.TxtEnum_LocalizedText.Location = new System.Drawing.Point(88, 135);
            this.TxtEnum_LocalizedText.Name = "TxtEnum_LocalizedText";
            this.TxtEnum_LocalizedText.ReadOnly = true;
            this.TxtEnum_LocalizedText.Size = new System.Drawing.Size(210, 20);
            this.TxtEnum_LocalizedText.TabIndex = 10;
            // 
            // BtnEnum_Localize
            // 
            this.BtnEnum_Localize.Location = new System.Drawing.Point(9, 104);
            this.BtnEnum_Localize.Name = "BtnEnum_Localize";
            this.BtnEnum_Localize.Size = new System.Drawing.Size(289, 21);
            this.BtnEnum_Localize.TabIndex = 9;
            this.BtnEnum_Localize.Text = "Localize";
            this.BtnEnum_Localize.UseVisualStyleBackColor = true;
            this.BtnEnum_Localize.Click += new System.EventHandler(this.BtnEnum_Localize_Click);
            // 
            // CmbMisc_Localize_CultureInfo
            // 
            this.CmbMisc_Localize_CultureInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMisc_Localize_CultureInfo.FormattingEnabled = true;
            this.CmbMisc_Localize_CultureInfo.Items.AddRange(new object[] {
            "en-US",
            "it-IT",
            "fr-FR",
            "de-DE"});
            this.CmbMisc_Localize_CultureInfo.Location = new System.Drawing.Point(89, 54);
            this.CmbMisc_Localize_CultureInfo.Name = "CmbMisc_Localize_CultureInfo";
            this.CmbMisc_Localize_CultureInfo.Size = new System.Drawing.Size(209, 21);
            this.CmbMisc_Localize_CultureInfo.TabIndex = 8;
            // 
            // TxtEnum_SourceText
            // 
            this.TxtEnum_SourceText.Location = new System.Drawing.Point(89, 28);
            this.TxtEnum_SourceText.Name = "TxtEnum_SourceText";
            this.TxtEnum_SourceText.Size = new System.Drawing.Size(209, 20);
            this.TxtEnum_SourceText.TabIndex = 7;
            this.TxtEnum_SourceText.Text = "reliabilityEnumSet.reliable";
            // 
            // LblEnum_SourceText
            // 
            this.LblEnum_SourceText.AutoSize = true;
            this.LblEnum_SourceText.Location = new System.Drawing.Point(6, 31);
            this.LblEnum_SourceText.Name = "LblEnum_SourceText";
            this.LblEnum_SourceText.Size = new System.Drawing.Size(65, 13);
            this.LblEnum_SourceText.TabIndex = 6;
            this.LblEnum_SourceText.Text = "Source Text";
            // 
            // LblMisc_Title2
            // 
            this.LblMisc_Title2.AutoSize = true;
            this.LblMisc_Title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMisc_Title2.Location = new System.Drawing.Point(6, 3);
            this.LblMisc_Title2.Name = "LblMisc_Title2";
            this.LblMisc_Title2.Size = new System.Drawing.Size(125, 16);
            this.LblMisc_Title2.TabIndex = 0;
            this.LblMisc_Title2.Text = "Method: Localize";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 512);
            this.Controls.Add(this.TabMain);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metasys Services: Test Client";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.TabMain.ResumeLayout(false);
            this.TpgLogin.ResumeLayout(false);
            this.TpgLogin.PerformLayout();
            this.TpgAudit.ResumeLayout(false);
            this.TabAudit.ResumeLayout(false);
            this.TpgGetAudits.ResumeLayout(false);
            this.GrbAudits_Get.ResumeLayout(false);
            this.GrbAudits_Get.PerformLayout();
            this.GrbAudit_Filter.ResumeLayout(false);
            this.GrbAudit_Filter.PerformLayout();
            this.GrdAudit_ActionTypes.ResumeLayout(false);
            this.GrdAudit_ActionTypes.PerformLayout();
            this.Grb_Audit_OriginApplication_Filters.ResumeLayout(false);
            this.Grb_Audit_OriginApplication_Filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAudit)).EndInit();
            this.TpgFindById.ResumeLayout(false);
            this.TpgFindById.PerformLayout();
            this.TpgGetForObject.ResumeLayout(false);
            this.GrbAudit_GFO.ResumeLayout(false);
            this.GrbAudit_GFO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAudit_GFO)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.TpgGetAnnotations.ResumeLayout(false);
            this.GrbGetAuditAnnotation.ResumeLayout(false);
            this.GrbGetAuditAnnotation.PerformLayout();
            this.TpgAddAnnotation.ResumeLayout(false);
            this.GrbAddAuditAnnotation.ResumeLayout(false);
            this.GrbAddAuditAnnotation.PerformLayout();
            this.TpgAddAnnotationMulti.ResumeLayout(false);
            this.GrbAddAuditAnnotationMulti.ResumeLayout(false);
            this.GrbAddAuditAnnotationMulti.PerformLayout();
            this.TpgDiscard.ResumeLayout(false);
            this.GrbDiscardAudit.ResumeLayout(false);
            this.GrbDiscardAudit.PerformLayout();
            this.TpgDiscardMultiple.ResumeLayout(false);
            this.GrbDiscardAuditMulti.ResumeLayout(false);
            this.GrbDiscardAuditMulti.PerformLayout();
            this.TpgMisc.ResumeLayout(false);
            this.TabMiscellanea.ResumeLayout(false);
            this.TpgMisc_GetServerTime.ResumeLayout(false);
            this.TpgMisc_GetServerTime.PerformLayout();
            this.TpgMisc_Localize.ResumeLayout(false);
            this.TpgMisc_Localize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rcbToken;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblHostExample;
        private System.Windows.Forms.Label lblUsernameExample;
        private System.Windows.Forms.Label lblPasswordExample;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVersionExample;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgAlarm;
        private System.Windows.Forms.TabPage TpgTrend;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage TpgAudit;
        private System.Windows.Forms.TabPage TpgLogin;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnGetAccessToken;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TabPage TpgObject;
        private System.Windows.Forms.TabPage TpgMisc;
        private System.Windows.Forms.TextBox TxtMisc_ServerTime;
        private System.Windows.Forms.Button BtnMisc_GetServerTime;
        private System.Windows.Forms.TabPage TpgEnumeration;
        private System.Windows.Forms.TabControl TabAudit;
        private System.Windows.Forms.TabPage TpgGetAudits;
        private System.Windows.Forms.GroupBox GrbAudits_Get;
        private System.Windows.Forms.CheckBox ChkAudit_NoFilter;
        private System.Windows.Forms.GroupBox GrbAudit_Filter;
        private System.Windows.Forms.DateTimePicker DtpAudit_StartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpAudit_EndTime;
        private System.Windows.Forms.CheckBox ChkAudit_ExcludeDiscarded;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtAudit_Total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView DgvAudit;
        private System.Windows.Forms.Button BtlAudit_Get;
        private System.Windows.Forms.TabPage TpgFindById;
        private System.Windows.Forms.PropertyGrid PrgAudit_FindByID;
        private System.Windows.Forms.Button BtnAudit_FindByID;
        private System.Windows.Forms.TextBox TxtAudit_FindByID_GUID;
        private System.Windows.Forms.Label LblAudit_FindByID_GUID;
        private System.Windows.Forms.TabPage TpgGetForObject;
        private System.Windows.Forms.GroupBox GrbAudit_GFO;
        private System.Windows.Forms.TextBox TxtAudit_GFO_GUID;
        private System.Windows.Forms.Label LblAudit_GFO_GUID;
        private System.Windows.Forms.CheckBox chkAudit_GFO_NoFilter;
        private System.Windows.Forms.TextBox TxtAudit_GFO_Total;
        private System.Windows.Forms.Label LblAudit_GFO_Total;
        private System.Windows.Forms.DataGridView DgvAudit_GFO;
        private System.Windows.Forms.Button BtnAudit_GetForObject;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DateTimePicker DtpAudit_GFO_StartTime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker DtpAudit_GFO_EndTime;
        private System.Windows.Forms.CheckBox chkAudit_GFO_ExcludeDiscarded;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage TpgGetAnnotations;
        private System.Windows.Forms.GroupBox GrbGetAuditAnnotation;
        private System.Windows.Forms.Label LblAudits_Annotations;
        private System.Windows.Forms.TextBox TxtAudits_Annotations;
        private System.Windows.Forms.Button BtnAudit_GetAnnotations;
        private System.Windows.Forms.TextBox TxtAudit_GetAnnotations_GUID;
        private System.Windows.Forms.Label LblAudit_GetAnnotations_GUID;
        private System.Windows.Forms.TabPage TpgDiscard;
        private System.Windows.Forms.TabPage TpgAddAnnotation;
        private System.Windows.Forms.TabPage TpgAddAnnotationMulti;
        private System.Windows.Forms.GroupBox GrbAddAuditAnnotation;
        private System.Windows.Forms.Button BtnAudit_AddAnnotation;
        private System.Windows.Forms.TextBox TxtAudit_AddAnnotation_Text;
        private System.Windows.Forms.Label LblAudit_AddAnnotation_Text;
        private System.Windows.Forms.TextBox TxtAudit_AddAnnotation_GUID;
        private System.Windows.Forms.Label LblAudit_AddAnnotation_GUID;
        private System.Windows.Forms.GroupBox GrbDiscardAudit;
        private System.Windows.Forms.Button BtnAudit_Discard;
        private System.Windows.Forms.TextBox TxtAudit_Discard_Text;
        private System.Windows.Forms.Label LblAudit_Discard_Text;
        private System.Windows.Forms.TextBox TxtAudit_Discard_GUID;
        private System.Windows.Forms.Label LblAudit_Discard_GUID;
        private System.Windows.Forms.GroupBox GrbAddAuditAnnotationMulti;
        private System.Windows.Forms.Button BtnAudit_AddAnnotationMultiple;
        private System.Windows.Forms.TextBox TxtAudit_AddAnnotationMulti_Text1;
        private System.Windows.Forms.Label LblAudit_AddAnnotationMulti_Text1;
        private System.Windows.Forms.TextBox TxtAudit_AddAnnotationMulti_GUID1;
        private System.Windows.Forms.Label LblAudit_AddAnnotationMulti_GUID1;
        private System.Windows.Forms.TextBox TxtAudit_AddAnnotationMulti_Text2;
        private System.Windows.Forms.Label LblAudit_AddAnnotationMulti_Text2;
        private System.Windows.Forms.TextBox TxtAudit_AddAnnotationMulti_GUID2;
        private System.Windows.Forms.Label LblAudit_AddAnnotationMulti_GUID2;
        private System.Windows.Forms.TabPage TpgDiscardMultiple;
        private System.Windows.Forms.GroupBox GrbDiscardAuditMulti;
        private System.Windows.Forms.TextBox TxtAudit_DiscardMulti_Text2;
        private System.Windows.Forms.Label LblAudit_DiscardMulti_Text2;
        private System.Windows.Forms.TextBox TxtAudit_DiscardMulti_GUID2;
        private System.Windows.Forms.Label LblAudit_DiscardMulti_GUID2;
        private System.Windows.Forms.Button BtnAudit_DiscardMultiple;
        private System.Windows.Forms.TextBox TxtAudit_DiscardMulti_Text1;
        private System.Windows.Forms.Label LblAudit_DiscardMulti_Text1;
        private System.Windows.Forms.TextBox TxtAudit_DiscardMulti_GUID1;
        private System.Windows.Forms.Label LblAudit_DiscardMulti_GUID1;
        private System.Windows.Forms.TabPage TpgEquipment;
        private System.Windows.Forms.TabPage TpgNetworkDevice;
        private System.Windows.Forms.TabPage TpgSpace;
        private System.Windows.Forms.TabControl TabMiscellanea;
        private System.Windows.Forms.TabPage TpgMisc_GetServerTime;
        private System.Windows.Forms.TabPage TpgMisc_Localize;
        private System.Windows.Forms.Label LblMisc_Title1;
        private System.Windows.Forms.Label LblEnum_LocalizedText;
        private System.Windows.Forms.TextBox TxtEnum_LocalizedText;
        private System.Windows.Forms.Button BtnEnum_Localize;
        private System.Windows.Forms.ComboBox CmbMisc_Localize_CultureInfo;
        private System.Windows.Forms.TextBox TxtEnum_SourceText;
        private System.Windows.Forms.Label LblEnum_SourceText;
        private System.Windows.Forms.Label LblMisc_Title2;
        private System.Windows.Forms.Label LblMisc_Localize_CultureInfo;
        private System.Windows.Forms.Label LblLogin_Title1;
        private System.Windows.Forms.TabPage TpgStream;
        private System.Windows.Forms.CheckBox ChkAudit_AlarmEvent;
        private System.Windows.Forms.CheckBox ChkAudit_AuditTrails;
        private System.Windows.Forms.CheckBox ChkAudit_DeviceServices;
        private System.Windows.Forms.GroupBox Grb_Audit_OriginApplication_Filters;
        private System.Windows.Forms.CheckBox ChkAudit_MCE;
        private System.Windows.Forms.CheckBox ChkAudit_SiteServices;
        private System.Windows.Forms.GroupBox GrdAudit_ActionTypes;
        private System.Windows.Forms.CheckBox ChkAudit_ActionType_Write;
        private System.Windows.Forms.CheckBox ChkAudit_ActionType_Command;
        private System.Windows.Forms.CheckBox ChkAudit_ActionType_Create;
        private System.Windows.Forms.CheckBox ChkAudit_ActionType_Delete;
        private System.Windows.Forms.CheckBox ChkAudit_ActionType_Error;
        private System.Windows.Forms.CheckBox ChkAudit_ActionType_Subsystem;
    }
}

