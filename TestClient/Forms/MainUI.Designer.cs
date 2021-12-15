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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.BtlAlarm_Get = new System.Windows.Forms.Button();
            this.lblAlarm_StartDate = new System.Windows.Forms.Label();
            this.DtpAlarm_StartTime = new System.Windows.Forms.DateTimePicker();
            this.GrbGetAlarms = new System.Windows.Forms.GroupBox();
            this.ChkAlarm_NoFilter = new System.Windows.Forms.CheckBox();
            this.GrbAlarm_Filter = new System.Windows.Forms.GroupBox();
            this.DtpAlarm_EndTime = new System.Windows.Forms.DateTimePicker();
            this.chkAlarm_ExcludeDiscarded = new System.Windows.Forms.CheckBox();
            this.lblAlarm_Enddate = new System.Windows.Forms.Label();
            this.chkAlarm_ExcludeAcknowledged = new System.Windows.Forms.CheckBox();
            this.TxtAlarm_Total = new System.Windows.Forms.TextBox();
            this.lblAlarm_Total = new System.Windows.Forms.Label();
            this.DgvAlarm = new System.Windows.Forms.DataGridView();
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
            this.TabAlarm = new System.Windows.Forms.TabControl();
            this.TgpGetAlarms = new System.Windows.Forms.TabPage();
            this.LblAlarm_Get = new System.Windows.Forms.Label();
            this.TgpFindByID = new System.Windows.Forms.TabPage();
            this.LblAlarm_FindById = new System.Windows.Forms.Label();
            this.PrgAlarm_FindByID = new System.Windows.Forms.PropertyGrid();
            this.BtnAlarm_FindByID = new System.Windows.Forms.Button();
            this.TxtAlarm_FindByID_GUID = new System.Windows.Forms.TextBox();
            this.LblAlarm_FindByID_GUID = new System.Windows.Forms.Label();
            this.TgpGetForNetworkDevice = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.GrbAlarm_GFND = new System.Windows.Forms.GroupBox();
            this.TxtAlarm_GFND_GUID = new System.Windows.Forms.TextBox();
            this.LblAlarm_GFND_GUID = new System.Windows.Forms.Label();
            this.chkAlarm_GFND_NoFilter = new System.Windows.Forms.CheckBox();
            this.TxtAlarm_GFND_Total = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvAlarm_GFND = new System.Windows.Forms.DataGridView();
            this.BtnAlarm_GetForNetworkDevice = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAlarm_GFND_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpAlarm_GFND_EndTime = new System.Windows.Forms.DateTimePicker();
            this.chkAlarm_GFND_ExcludeDiscarded = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAlarm_GFND_ExcludeAcknowledged = new System.Windows.Forms.CheckBox();
            this.TgpGetForObject = new System.Windows.Forms.TabPage();
            this.GrbAlarm_GFO = new System.Windows.Forms.GroupBox();
            this.TxtAlarm_GFO_GUID = new System.Windows.Forms.TextBox();
            this.LblAlarm_GFO_GUID = new System.Windows.Forms.Label();
            this.chkAlarm_GFO_NoFilter = new System.Windows.Forms.CheckBox();
            this.TxtAlarm_GFO_Total = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DgvAlarm_GFO = new System.Windows.Forms.DataGridView();
            this.BtnAlarm_GetForObject = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtpAlarm_GFO_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpAlarm_GFO_EndTime = new System.Windows.Forms.DateTimePicker();
            this.chkAlarm_GFO_ExcludeDiscarded = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAlarm_GFO_ExcludeAcknowledged = new System.Windows.Forms.CheckBox();
            this.TgpGetAnnotation = new System.Windows.Forms.TabPage();
            this.GrbGetAlarmAnnotation = new System.Windows.Forms.GroupBox();
            this.LblAlarms_Annotations = new System.Windows.Forms.Label();
            this.TxtAlarms_Annotations = new System.Windows.Forms.TextBox();
            this.BtnAlarms_GetAnnotations = new System.Windows.Forms.Button();
            this.TxtAlarmGUID = new System.Windows.Forms.TextBox();
            this.LblAlarmGUID = new System.Windows.Forms.Label();
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
            this.TabEquipment = new System.Windows.Forms.TabControl();
            this.TpgGetEquipment = new System.Windows.Forms.TabPage();
            this.GrbGetEquipment = new System.Windows.Forms.GroupBox();
            this.BtnGetEquipment = new System.Windows.Forms.Button();
            this.DgvGetEquipment = new System.Windows.Forms.DataGridView();
            this.TpgGetEquipmentPoints = new System.Windows.Forms.TabPage();
            this.TpgNetworkDevice = new System.Windows.Forms.TabPage();
            this.TabNetworkDevice = new System.Windows.Forms.TabControl();
            this.TpgGetNetworkDevices = new System.Windows.Forms.TabPage();
            this.GrbGetNetworkDevices = new System.Windows.Forms.GroupBox();
            this.DgvGetNetworkDevices = new System.Windows.Forms.DataGridView();
            this.BtnGetNetworkDevices = new System.Windows.Forms.Button();
            this.TxtGetNetworkDevices_Type_ID = new System.Windows.Forms.TextBox();
            this.LblGetNetworkDevices_Type_ID = new System.Windows.Forms.Label();
            this.TpgGetNetworkDeviceTypes = new System.Windows.Forms.TabPage();
            this.GrbGetNetworkDeviceTypes = new System.Windows.Forms.GroupBox();
            this.BtnGetNetworkDeviceTypes = new System.Windows.Forms.Button();
            this.DgvGetNetworkDeviceTypes = new System.Windows.Forms.DataGridView();
            this.TpgObject = new System.Windows.Forms.TabPage();
            this.TabObject = new System.Windows.Forms.TabControl();
            this.TpgGetObjectIdentifier = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtObjectIdentifier_GUID = new System.Windows.Forms.TextBox();
            this.LblObjectIdentifier_GUID = new System.Windows.Forms.Label();
            this.BtnGetObjectIdentifier = new System.Windows.Forms.Button();
            this.TxtGetObjectIdentifier_FQR = new System.Windows.Forms.TextBox();
            this.LblGetObjectIdentifier_FQR = new System.Windows.Forms.Label();
            this.TpgGetObjects = new System.Windows.Forms.TabPage();
            this.TpgGetCommands = new System.Windows.Forms.TabPage();
            this.GrbGetCommands = new System.Windows.Forms.GroupBox();
            this.DgvGetCommandEnums = new System.Windows.Forms.DataGridView();
            this.DgvCommandEnum_TitleEnumerationKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnGetCommandEnums = new System.Windows.Forms.Button();
            this.DgvGetCommands = new System.Windows.Forms.DataGridView();
            this.DgvCommand_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvCommand_TitleEnumerationKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvCommand_CommandId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnGetCommands = new System.Windows.Forms.Button();
            this.TxtObjects_GetCommands_GUID = new System.Windows.Forms.TextBox();
            this.LblObjects_GetCommands_GUID = new System.Windows.Forms.Label();
            this.TpgGetCommandEnumeration = new System.Windows.Forms.TabPage();
            this.GrbGetCommandEnumeration = new System.Windows.Forms.GroupBox();
            this.DgvGetCommandEnumeration = new System.Windows.Forms.DataGridView();
            this.BtnGetCommandEnumeration = new System.Windows.Forms.Button();
            this.TxtObjects_GetCommandEnum_ID = new System.Windows.Forms.TextBox();
            this.LblObjects_GetCommandEnum_ID = new System.Windows.Forms.Label();
            this.TpgReadProperty = new System.Windows.Forms.TabPage();
            this.LblObject_Title5 = new System.Windows.Forms.Label();
            this.grbReadProperty = new System.Windows.Forms.GroupBox();
            this.lblPropertyValue = new System.Windows.Forms.Label();
            this.TxtObject_PropertyValue = new System.Windows.Forms.TextBox();
            this.lblObjectProperty = new System.Windows.Forms.Label();
            this.btnReadProperty = new System.Windows.Forms.Button();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.lblObjectFQR = new System.Windows.Forms.Label();
            this.txtObjectFQR = new System.Windows.Forms.TextBox();
            this.TpgSpace = new System.Windows.Forms.TabPage();
            this.TabSpace = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.GrbGetAlarms.SuspendLayout();
            this.GrbAlarm_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm)).BeginInit();
            this.TabMain.SuspendLayout();
            this.TpgLogin.SuspendLayout();
            this.TpgAlarm.SuspendLayout();
            this.TabAlarm.SuspendLayout();
            this.TgpGetAlarms.SuspendLayout();
            this.TgpFindByID.SuspendLayout();
            this.TgpGetForNetworkDevice.SuspendLayout();
            this.GrbAlarm_GFND.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm_GFND)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.TgpGetForObject.SuspendLayout();
            this.GrbAlarm_GFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm_GFO)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.TgpGetAnnotation.SuspendLayout();
            this.GrbGetAlarmAnnotation.SuspendLayout();
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
            this.TpgEquipment.SuspendLayout();
            this.TabEquipment.SuspendLayout();
            this.TpgGetEquipment.SuspendLayout();
            this.GrbGetEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipment)).BeginInit();
            this.TpgNetworkDevice.SuspendLayout();
            this.TabNetworkDevice.SuspendLayout();
            this.TpgGetNetworkDevices.SuspendLayout();
            this.GrbGetNetworkDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetworkDevices)).BeginInit();
            this.TpgGetNetworkDeviceTypes.SuspendLayout();
            this.GrbGetNetworkDeviceTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetworkDeviceTypes)).BeginInit();
            this.TpgObject.SuspendLayout();
            this.TabObject.SuspendLayout();
            this.TpgGetObjectIdentifier.SuspendLayout();
            this.TpgGetCommands.SuspendLayout();
            this.GrbGetCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommandEnums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommands)).BeginInit();
            this.TpgGetCommandEnumeration.SuspendLayout();
            this.GrbGetCommandEnumeration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommandEnumeration)).BeginInit();
            this.TpgReadProperty.SuspendLayout();
            this.grbReadProperty.SuspendLayout();
            this.TpgSpace.SuspendLayout();
            this.TabSpace.SuspendLayout();
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
            // BtlAlarm_Get
            // 
            this.BtlAlarm_Get.Location = new System.Drawing.Point(6, 107);
            this.BtlAlarm_Get.Name = "BtlAlarm_Get";
            this.BtlAlarm_Get.Size = new System.Drawing.Size(515, 23);
            this.BtlAlarm_Get.TabIndex = 19;
            this.BtlAlarm_Get.Text = "Get";
            this.BtlAlarm_Get.UseVisualStyleBackColor = true;
            this.BtlAlarm_Get.Click += new System.EventHandler(this.BtlAlarm_Get_Click);
            // 
            // lblAlarm_StartDate
            // 
            this.lblAlarm_StartDate.AutoSize = true;
            this.lblAlarm_StartDate.Location = new System.Drawing.Point(21, 26);
            this.lblAlarm_StartDate.Name = "lblAlarm_StartDate";
            this.lblAlarm_StartDate.Size = new System.Drawing.Size(58, 13);
            this.lblAlarm_StartDate.TabIndex = 20;
            this.lblAlarm_StartDate.Text = "Start Time:";
            // 
            // DtpAlarm_StartTime
            // 
            this.DtpAlarm_StartTime.Location = new System.Drawing.Point(80, 22);
            this.DtpAlarm_StartTime.Name = "DtpAlarm_StartTime";
            this.DtpAlarm_StartTime.Size = new System.Drawing.Size(200, 20);
            this.DtpAlarm_StartTime.TabIndex = 21;
            // 
            // GrbGetAlarms
            // 
            this.GrbGetAlarms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbGetAlarms.Controls.Add(this.ChkAlarm_NoFilter);
            this.GrbGetAlarms.Controls.Add(this.GrbAlarm_Filter);
            this.GrbGetAlarms.Controls.Add(this.TxtAlarm_Total);
            this.GrbGetAlarms.Controls.Add(this.lblAlarm_Total);
            this.GrbGetAlarms.Controls.Add(this.DgvAlarm);
            this.GrbGetAlarms.Controls.Add(this.BtlAlarm_Get);
            this.GrbGetAlarms.Location = new System.Drawing.Point(3, 25);
            this.GrbGetAlarms.Name = "GrbGetAlarms";
            this.GrbGetAlarms.Size = new System.Drawing.Size(1060, 383);
            this.GrbGetAlarms.TabIndex = 22;
            this.GrbGetAlarms.TabStop = false;
            // 
            // ChkAlarm_NoFilter
            // 
            this.ChkAlarm_NoFilter.AutoSize = true;
            this.ChkAlarm_NoFilter.Location = new System.Drawing.Point(528, 30);
            this.ChkAlarm_NoFilter.Name = "ChkAlarm_NoFilter";
            this.ChkAlarm_NoFilter.Size = new System.Drawing.Size(70, 17);
            this.ChkAlarm_NoFilter.TabIndex = 30;
            this.ChkAlarm_NoFilter.Text = "No Filters";
            this.ChkAlarm_NoFilter.UseVisualStyleBackColor = true;
            this.ChkAlarm_NoFilter.CheckedChanged += new System.EventHandler(this.ChkAlarm_NoFilter_CheckedChanged);
            // 
            // GrbAlarm_Filter
            // 
            this.GrbAlarm_Filter.Controls.Add(this.DtpAlarm_StartTime);
            this.GrbAlarm_Filter.Controls.Add(this.lblAlarm_StartDate);
            this.GrbAlarm_Filter.Controls.Add(this.DtpAlarm_EndTime);
            this.GrbAlarm_Filter.Controls.Add(this.chkAlarm_ExcludeDiscarded);
            this.GrbAlarm_Filter.Controls.Add(this.lblAlarm_Enddate);
            this.GrbAlarm_Filter.Controls.Add(this.chkAlarm_ExcludeAcknowledged);
            this.GrbAlarm_Filter.Location = new System.Drawing.Point(6, 19);
            this.GrbAlarm_Filter.Name = "GrbAlarm_Filter";
            this.GrbAlarm_Filter.Size = new System.Drawing.Size(515, 82);
            this.GrbAlarm_Filter.TabIndex = 29;
            this.GrbAlarm_Filter.TabStop = false;
            this.GrbAlarm_Filter.Text = "Filters";
            // 
            // DtpAlarm_EndTime
            // 
            this.DtpAlarm_EndTime.Location = new System.Drawing.Point(80, 49);
            this.DtpAlarm_EndTime.Name = "DtpAlarm_EndTime";
            this.DtpAlarm_EndTime.Size = new System.Drawing.Size(200, 20);
            this.DtpAlarm_EndTime.TabIndex = 22;
            // 
            // chkAlarm_ExcludeDiscarded
            // 
            this.chkAlarm_ExcludeDiscarded.AutoSize = true;
            this.chkAlarm_ExcludeDiscarded.Location = new System.Drawing.Point(335, 49);
            this.chkAlarm_ExcludeDiscarded.Name = "chkAlarm_ExcludeDiscarded";
            this.chkAlarm_ExcludeDiscarded.Size = new System.Drawing.Size(115, 17);
            this.chkAlarm_ExcludeDiscarded.TabIndex = 26;
            this.chkAlarm_ExcludeDiscarded.Text = "Exclude Discarded";
            this.chkAlarm_ExcludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // lblAlarm_Enddate
            // 
            this.lblAlarm_Enddate.AutoSize = true;
            this.lblAlarm_Enddate.Location = new System.Drawing.Point(24, 50);
            this.lblAlarm_Enddate.Name = "lblAlarm_Enddate";
            this.lblAlarm_Enddate.Size = new System.Drawing.Size(55, 13);
            this.lblAlarm_Enddate.TabIndex = 23;
            this.lblAlarm_Enddate.Text = "End Time:";
            // 
            // chkAlarm_ExcludeAcknowledged
            // 
            this.chkAlarm_ExcludeAcknowledged.AutoSize = true;
            this.chkAlarm_ExcludeAcknowledged.Location = new System.Drawing.Point(335, 25);
            this.chkAlarm_ExcludeAcknowledged.Name = "chkAlarm_ExcludeAcknowledged";
            this.chkAlarm_ExcludeAcknowledged.Size = new System.Drawing.Size(138, 17);
            this.chkAlarm_ExcludeAcknowledged.TabIndex = 25;
            this.chkAlarm_ExcludeAcknowledged.Text = "Exclude Acknowledged";
            this.chkAlarm_ExcludeAcknowledged.UseVisualStyleBackColor = true;
            // 
            // TxtAlarm_Total
            // 
            this.TxtAlarm_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAlarm_Total.Location = new System.Drawing.Point(954, 109);
            this.TxtAlarm_Total.Name = "TxtAlarm_Total";
            this.TxtAlarm_Total.ReadOnly = true;
            this.TxtAlarm_Total.Size = new System.Drawing.Size(100, 20);
            this.TxtAlarm_Total.TabIndex = 28;
            // 
            // lblAlarm_Total
            // 
            this.lblAlarm_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlarm_Total.AutoSize = true;
            this.lblAlarm_Total.Location = new System.Drawing.Point(864, 113);
            this.lblAlarm_Total.Name = "lblAlarm_Total";
            this.lblAlarm_Total.Size = new System.Drawing.Size(87, 13);
            this.lblAlarm_Total.TabIndex = 27;
            this.lblAlarm_Total.Text = "Numb. of Alarms:";
            // 
            // DgvAlarm
            // 
            this.DgvAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlarm.Location = new System.Drawing.Point(6, 136);
            this.DgvAlarm.Name = "DgvAlarm";
            this.DgvAlarm.Size = new System.Drawing.Size(1048, 238);
            this.DgvAlarm.TabIndex = 24;
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
            this.lblVersionExample.Text = "Example: v3";
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
            this.TpgAlarm.Controls.Add(this.TabAlarm);
            this.TpgAlarm.Location = new System.Drawing.Point(4, 34);
            this.TpgAlarm.Name = "TpgAlarm";
            this.TpgAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.TpgAlarm.Size = new System.Drawing.Size(1080, 450);
            this.TpgAlarm.TabIndex = 0;
            this.TpgAlarm.Text = "ALARMS";
            // 
            // TabAlarm
            // 
            this.TabAlarm.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabAlarm.Controls.Add(this.TgpGetAlarms);
            this.TabAlarm.Controls.Add(this.TgpFindByID);
            this.TabAlarm.Controls.Add(this.TgpGetForNetworkDevice);
            this.TabAlarm.Controls.Add(this.TgpGetForObject);
            this.TabAlarm.Controls.Add(this.TgpGetAnnotation);
            this.TabAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabAlarm.ItemSize = new System.Drawing.Size(63, 25);
            this.TabAlarm.Location = new System.Drawing.Point(3, 3);
            this.TabAlarm.Name = "TabAlarm";
            this.TabAlarm.SelectedIndex = 0;
            this.TabAlarm.Size = new System.Drawing.Size(1074, 444);
            this.TabAlarm.TabIndex = 23;
            // 
            // TgpGetAlarms
            // 
            this.TgpGetAlarms.Controls.Add(this.LblAlarm_Get);
            this.TgpGetAlarms.Controls.Add(this.GrbGetAlarms);
            this.TgpGetAlarms.Location = new System.Drawing.Point(4, 29);
            this.TgpGetAlarms.Name = "TgpGetAlarms";
            this.TgpGetAlarms.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TgpGetAlarms.Size = new System.Drawing.Size(1066, 411);
            this.TgpGetAlarms.TabIndex = 1;
            this.TgpGetAlarms.Text = "Get Alarms";
            this.TgpGetAlarms.UseVisualStyleBackColor = true;
            // 
            // LblAlarm_Get
            // 
            this.LblAlarm_Get.AutoSize = true;
            this.LblAlarm_Get.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlarm_Get.Location = new System.Drawing.Point(6, 6);
            this.LblAlarm_Get.Name = "LblAlarm_Get";
            this.LblAlarm_Get.Size = new System.Drawing.Size(150, 16);
            this.LblAlarm_Get.TabIndex = 23;
            this.LblAlarm_Get.Text = "Function: Alarms.Get";
            // 
            // TgpFindByID
            // 
            this.TgpFindByID.Controls.Add(this.LblAlarm_FindById);
            this.TgpFindByID.Controls.Add(this.PrgAlarm_FindByID);
            this.TgpFindByID.Controls.Add(this.BtnAlarm_FindByID);
            this.TgpFindByID.Controls.Add(this.TxtAlarm_FindByID_GUID);
            this.TgpFindByID.Controls.Add(this.LblAlarm_FindByID_GUID);
            this.TgpFindByID.Location = new System.Drawing.Point(4, 29);
            this.TgpFindByID.Name = "TgpFindByID";
            this.TgpFindByID.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TgpFindByID.Size = new System.Drawing.Size(1066, 411);
            this.TgpFindByID.TabIndex = 0;
            this.TgpFindByID.Text = "Get a Single Alarm";
            this.TgpFindByID.UseVisualStyleBackColor = true;
            // 
            // LblAlarm_FindById
            // 
            this.LblAlarm_FindById.AutoSize = true;
            this.LblAlarm_FindById.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlarm_FindById.Location = new System.Drawing.Point(6, 6);
            this.LblAlarm_FindById.Name = "LblAlarm_FindById";
            this.LblAlarm_FindById.Size = new System.Drawing.Size(187, 16);
            this.LblAlarm_FindById.TabIndex = 4;
            this.LblAlarm_FindById.Text = "Function: Alarms.FindById";
            // 
            // PrgAlarm_FindByID
            // 
            this.PrgAlarm_FindByID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrgAlarm_FindByID.HelpVisible = false;
            this.PrgAlarm_FindByID.Location = new System.Drawing.Point(9, 85);
            this.PrgAlarm_FindByID.Name = "PrgAlarm_FindByID";
            this.PrgAlarm_FindByID.Size = new System.Drawing.Size(1051, 320);
            this.PrgAlarm_FindByID.TabIndex = 3;
            this.PrgAlarm_FindByID.ToolbarVisible = false;
            // 
            // BtnAlarm_FindByID
            // 
            this.BtnAlarm_FindByID.Location = new System.Drawing.Point(98, 56);
            this.BtnAlarm_FindByID.Name = "BtnAlarm_FindByID";
            this.BtnAlarm_FindByID.Size = new System.Drawing.Size(220, 23);
            this.BtnAlarm_FindByID.TabIndex = 2;
            this.BtnAlarm_FindByID.Text = "FindByID";
            this.BtnAlarm_FindByID.UseVisualStyleBackColor = true;
            this.BtnAlarm_FindByID.Click += new System.EventHandler(this.BtnAlarm_FindByID_Click);
            // 
            // TxtAlarm_FindByID_GUID
            // 
            this.TxtAlarm_FindByID_GUID.Location = new System.Drawing.Point(98, 30);
            this.TxtAlarm_FindByID_GUID.Name = "TxtAlarm_FindByID_GUID";
            this.TxtAlarm_FindByID_GUID.Size = new System.Drawing.Size(220, 20);
            this.TxtAlarm_FindByID_GUID.TabIndex = 1;
            // 
            // LblAlarm_FindByID_GUID
            // 
            this.LblAlarm_FindByID_GUID.AutoSize = true;
            this.LblAlarm_FindByID_GUID.Location = new System.Drawing.Point(6, 33);
            this.LblAlarm_FindByID_GUID.Name = "LblAlarm_FindByID_GUID";
            this.LblAlarm_FindByID_GUID.Size = new System.Drawing.Size(86, 13);
            this.LblAlarm_FindByID_GUID.TabIndex = 0;
            this.LblAlarm_FindByID_GUID.Text = "Alarm ID (GUID):";
            // 
            // TgpGetForNetworkDevice
            // 
            this.TgpGetForNetworkDevice.Controls.Add(this.label12);
            this.TgpGetForNetworkDevice.Controls.Add(this.GrbAlarm_GFND);
            this.TgpGetForNetworkDevice.Location = new System.Drawing.Point(4, 29);
            this.TgpGetForNetworkDevice.Name = "TgpGetForNetworkDevice";
            this.TgpGetForNetworkDevice.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TgpGetForNetworkDevice.Size = new System.Drawing.Size(1066, 411);
            this.TgpGetForNetworkDevice.TabIndex = 2;
            this.TgpGetForNetworkDevice.Text = "Get Alarms for a Network Device";
            this.TgpGetForNetworkDevice.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(226, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Function: GetForNetworkDevice";
            // 
            // GrbAlarm_GFND
            // 
            this.GrbAlarm_GFND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbAlarm_GFND.Controls.Add(this.TxtAlarm_GFND_GUID);
            this.GrbAlarm_GFND.Controls.Add(this.LblAlarm_GFND_GUID);
            this.GrbAlarm_GFND.Controls.Add(this.chkAlarm_GFND_NoFilter);
            this.GrbAlarm_GFND.Controls.Add(this.TxtAlarm_GFND_Total);
            this.GrbAlarm_GFND.Controls.Add(this.label4);
            this.GrbAlarm_GFND.Controls.Add(this.DgvAlarm_GFND);
            this.GrbAlarm_GFND.Controls.Add(this.BtnAlarm_GetForNetworkDevice);
            this.GrbAlarm_GFND.Controls.Add(this.groupBox1);
            this.GrbAlarm_GFND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbAlarm_GFND.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrbAlarm_GFND.Location = new System.Drawing.Point(3, 25);
            this.GrbAlarm_GFND.Name = "GrbAlarm_GFND";
            this.GrbAlarm_GFND.Size = new System.Drawing.Size(1060, 383);
            this.GrbAlarm_GFND.TabIndex = 0;
            this.GrbAlarm_GFND.TabStop = false;
            // 
            // TxtAlarm_GFND_GUID
            // 
            this.TxtAlarm_GFND_GUID.Location = new System.Drawing.Point(666, 47);
            this.TxtAlarm_GFND_GUID.Name = "TxtAlarm_GFND_GUID";
            this.TxtAlarm_GFND_GUID.Size = new System.Drawing.Size(261, 20);
            this.TxtAlarm_GFND_GUID.TabIndex = 37;
            // 
            // LblAlarm_GFND_GUID
            // 
            this.LblAlarm_GFND_GUID.AutoSize = true;
            this.LblAlarm_GFND_GUID.Location = new System.Drawing.Point(663, 31);
            this.LblAlarm_GFND_GUID.Name = "LblAlarm_GFND_GUID";
            this.LblAlarm_GFND_GUID.Size = new System.Drawing.Size(137, 13);
            this.LblAlarm_GFND_GUID.TabIndex = 36;
            this.LblAlarm_GFND_GUID.Text = "Network Device ID (GUID):";
            // 
            // chkAlarm_GFND_NoFilter
            // 
            this.chkAlarm_GFND_NoFilter.AutoSize = true;
            this.chkAlarm_GFND_NoFilter.Location = new System.Drawing.Point(527, 29);
            this.chkAlarm_GFND_NoFilter.Name = "chkAlarm_GFND_NoFilter";
            this.chkAlarm_GFND_NoFilter.Size = new System.Drawing.Size(70, 17);
            this.chkAlarm_GFND_NoFilter.TabIndex = 35;
            this.chkAlarm_GFND_NoFilter.Text = "No Filters";
            this.chkAlarm_GFND_NoFilter.UseVisualStyleBackColor = true;
            // 
            // TxtAlarm_GFND_Total
            // 
            this.TxtAlarm_GFND_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAlarm_GFND_Total.Location = new System.Drawing.Point(954, 109);
            this.TxtAlarm_GFND_Total.Name = "TxtAlarm_GFND_Total";
            this.TxtAlarm_GFND_Total.ReadOnly = true;
            this.TxtAlarm_GFND_Total.Size = new System.Drawing.Size(100, 20);
            this.TxtAlarm_GFND_Total.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(864, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Numb. of Alarms:";
            // 
            // DgvAlarm_GFND
            // 
            this.DgvAlarm_GFND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvAlarm_GFND.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlarm_GFND.Location = new System.Drawing.Point(6, 136);
            this.DgvAlarm_GFND.Name = "DgvAlarm_GFND";
            this.DgvAlarm_GFND.Size = new System.Drawing.Size(1048, 238);
            this.DgvAlarm_GFND.TabIndex = 32;
            // 
            // BtnAlarm_GetForNetworkDevice
            // 
            this.BtnAlarm_GetForNetworkDevice.Location = new System.Drawing.Point(6, 107);
            this.BtnAlarm_GetForNetworkDevice.Name = "BtnAlarm_GetForNetworkDevice";
            this.BtnAlarm_GetForNetworkDevice.Size = new System.Drawing.Size(515, 23);
            this.BtnAlarm_GetForNetworkDevice.TabIndex = 31;
            this.BtnAlarm_GetForNetworkDevice.Text = "GetForNetworkDevice";
            this.BtnAlarm_GetForNetworkDevice.UseVisualStyleBackColor = true;
            this.BtnAlarm_GetForNetworkDevice.Click += new System.EventHandler(this.BtnAlarm_GetForNetworkDevice_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpAlarm_GFND_StartTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpAlarm_GFND_EndTime);
            this.groupBox1.Controls.Add(this.chkAlarm_GFND_ExcludeDiscarded);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkAlarm_GFND_ExcludeAcknowledged);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 82);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // dtpAlarm_GFND_StartTime
            // 
            this.dtpAlarm_GFND_StartTime.Location = new System.Drawing.Point(80, 22);
            this.dtpAlarm_GFND_StartTime.Name = "dtpAlarm_GFND_StartTime";
            this.dtpAlarm_GFND_StartTime.Size = new System.Drawing.Size(200, 20);
            this.dtpAlarm_GFND_StartTime.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Start Time:";
            // 
            // dtpAlarm_GFND_EndTime
            // 
            this.dtpAlarm_GFND_EndTime.Location = new System.Drawing.Point(80, 49);
            this.dtpAlarm_GFND_EndTime.Name = "dtpAlarm_GFND_EndTime";
            this.dtpAlarm_GFND_EndTime.Size = new System.Drawing.Size(200, 20);
            this.dtpAlarm_GFND_EndTime.TabIndex = 22;
            // 
            // chkAlarm_GFND_ExcludeDiscarded
            // 
            this.chkAlarm_GFND_ExcludeDiscarded.AutoSize = true;
            this.chkAlarm_GFND_ExcludeDiscarded.Location = new System.Drawing.Point(335, 49);
            this.chkAlarm_GFND_ExcludeDiscarded.Name = "chkAlarm_GFND_ExcludeDiscarded";
            this.chkAlarm_GFND_ExcludeDiscarded.Size = new System.Drawing.Size(115, 17);
            this.chkAlarm_GFND_ExcludeDiscarded.TabIndex = 26;
            this.chkAlarm_GFND_ExcludeDiscarded.Text = "Exclude Discarded";
            this.chkAlarm_GFND_ExcludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "End Time:";
            // 
            // chkAlarm_GFND_ExcludeAcknowledged
            // 
            this.chkAlarm_GFND_ExcludeAcknowledged.AutoSize = true;
            this.chkAlarm_GFND_ExcludeAcknowledged.Location = new System.Drawing.Point(335, 25);
            this.chkAlarm_GFND_ExcludeAcknowledged.Name = "chkAlarm_GFND_ExcludeAcknowledged";
            this.chkAlarm_GFND_ExcludeAcknowledged.Size = new System.Drawing.Size(138, 17);
            this.chkAlarm_GFND_ExcludeAcknowledged.TabIndex = 25;
            this.chkAlarm_GFND_ExcludeAcknowledged.Text = "Exclude Acknowledged";
            this.chkAlarm_GFND_ExcludeAcknowledged.UseVisualStyleBackColor = true;
            // 
            // TgpGetForObject
            // 
            this.TgpGetForObject.Controls.Add(this.GrbAlarm_GFO);
            this.TgpGetForObject.Location = new System.Drawing.Point(4, 29);
            this.TgpGetForObject.Name = "TgpGetForObject";
            this.TgpGetForObject.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TgpGetForObject.Size = new System.Drawing.Size(1066, 411);
            this.TgpGetForObject.TabIndex = 3;
            this.TgpGetForObject.Text = "Get Alarms for an Object";
            this.TgpGetForObject.UseVisualStyleBackColor = true;
            // 
            // GrbAlarm_GFO
            // 
            this.GrbAlarm_GFO.Controls.Add(this.TxtAlarm_GFO_GUID);
            this.GrbAlarm_GFO.Controls.Add(this.LblAlarm_GFO_GUID);
            this.GrbAlarm_GFO.Controls.Add(this.chkAlarm_GFO_NoFilter);
            this.GrbAlarm_GFO.Controls.Add(this.TxtAlarm_GFO_Total);
            this.GrbAlarm_GFO.Controls.Add(this.label6);
            this.GrbAlarm_GFO.Controls.Add(this.DgvAlarm_GFO);
            this.GrbAlarm_GFO.Controls.Add(this.BtnAlarm_GetForObject);
            this.GrbAlarm_GFO.Controls.Add(this.groupBox3);
            this.GrbAlarm_GFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbAlarm_GFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbAlarm_GFO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrbAlarm_GFO.Location = new System.Drawing.Point(3, 6);
            this.GrbAlarm_GFO.Name = "GrbAlarm_GFO";
            this.GrbAlarm_GFO.Size = new System.Drawing.Size(1060, 402);
            this.GrbAlarm_GFO.TabIndex = 1;
            this.GrbAlarm_GFO.TabStop = false;
            this.GrbAlarm_GFO.Text = "Method: Alarms.GetForObject";
            // 
            // TxtAlarm_GFO_GUID
            // 
            this.TxtAlarm_GFO_GUID.Location = new System.Drawing.Point(666, 47);
            this.TxtAlarm_GFO_GUID.Name = "TxtAlarm_GFO_GUID";
            this.TxtAlarm_GFO_GUID.Size = new System.Drawing.Size(261, 20);
            this.TxtAlarm_GFO_GUID.TabIndex = 37;
            // 
            // LblAlarm_GFO_GUID
            // 
            this.LblAlarm_GFO_GUID.AutoSize = true;
            this.LblAlarm_GFO_GUID.Location = new System.Drawing.Point(663, 31);
            this.LblAlarm_GFO_GUID.Name = "LblAlarm_GFO_GUID";
            this.LblAlarm_GFO_GUID.Size = new System.Drawing.Size(91, 13);
            this.LblAlarm_GFO_GUID.TabIndex = 36;
            this.LblAlarm_GFO_GUID.Text = "Object ID (GUID):";
            // 
            // chkAlarm_GFO_NoFilter
            // 
            this.chkAlarm_GFO_NoFilter.AutoSize = true;
            this.chkAlarm_GFO_NoFilter.Location = new System.Drawing.Point(527, 29);
            this.chkAlarm_GFO_NoFilter.Name = "chkAlarm_GFO_NoFilter";
            this.chkAlarm_GFO_NoFilter.Size = new System.Drawing.Size(70, 17);
            this.chkAlarm_GFO_NoFilter.TabIndex = 35;
            this.chkAlarm_GFO_NoFilter.Text = "No Filters";
            this.chkAlarm_GFO_NoFilter.UseVisualStyleBackColor = true;
            // 
            // TxtAlarm_GFO_Total
            // 
            this.TxtAlarm_GFO_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAlarm_GFO_Total.Location = new System.Drawing.Point(954, 109);
            this.TxtAlarm_GFO_Total.Name = "TxtAlarm_GFO_Total";
            this.TxtAlarm_GFO_Total.ReadOnly = true;
            this.TxtAlarm_GFO_Total.Size = new System.Drawing.Size(100, 20);
            this.TxtAlarm_GFO_Total.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(864, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Numb. of Alarms:";
            // 
            // DgvAlarm_GFO
            // 
            this.DgvAlarm_GFO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAlarm_GFO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvAlarm_GFO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAlarm_GFO.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvAlarm_GFO.Location = new System.Drawing.Point(6, 136);
            this.DgvAlarm_GFO.Name = "DgvAlarm_GFO";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAlarm_GFO.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvAlarm_GFO.Size = new System.Drawing.Size(1048, 257);
            this.DgvAlarm_GFO.TabIndex = 32;
            // 
            // BtnAlarm_GetForObject
            // 
            this.BtnAlarm_GetForObject.Location = new System.Drawing.Point(6, 107);
            this.BtnAlarm_GetForObject.Name = "BtnAlarm_GetForObject";
            this.BtnAlarm_GetForObject.Size = new System.Drawing.Size(515, 23);
            this.BtnAlarm_GetForObject.TabIndex = 31;
            this.BtnAlarm_GetForObject.Text = "GetForObject";
            this.BtnAlarm_GetForObject.UseVisualStyleBackColor = true;
            this.BtnAlarm_GetForObject.Click += new System.EventHandler(this.BtnAlarm_GetForObject_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtpAlarm_GFO_StartTime);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dtpAlarm_GFO_EndTime);
            this.groupBox3.Controls.Add(this.chkAlarm_GFO_ExcludeDiscarded);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chkAlarm_GFO_ExcludeAcknowledged);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 82);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // DtpAlarm_GFO_StartTime
            // 
            this.DtpAlarm_GFO_StartTime.Location = new System.Drawing.Point(80, 22);
            this.DtpAlarm_GFO_StartTime.Name = "DtpAlarm_GFO_StartTime";
            this.DtpAlarm_GFO_StartTime.Size = new System.Drawing.Size(200, 20);
            this.DtpAlarm_GFO_StartTime.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Start Time:";
            // 
            // dtpAlarm_GFO_EndTime
            // 
            this.dtpAlarm_GFO_EndTime.Location = new System.Drawing.Point(80, 49);
            this.dtpAlarm_GFO_EndTime.Name = "dtpAlarm_GFO_EndTime";
            this.dtpAlarm_GFO_EndTime.Size = new System.Drawing.Size(200, 20);
            this.dtpAlarm_GFO_EndTime.TabIndex = 22;
            // 
            // chkAlarm_GFO_ExcludeDiscarded
            // 
            this.chkAlarm_GFO_ExcludeDiscarded.AutoSize = true;
            this.chkAlarm_GFO_ExcludeDiscarded.Location = new System.Drawing.Point(335, 49);
            this.chkAlarm_GFO_ExcludeDiscarded.Name = "chkAlarm_GFO_ExcludeDiscarded";
            this.chkAlarm_GFO_ExcludeDiscarded.Size = new System.Drawing.Size(115, 17);
            this.chkAlarm_GFO_ExcludeDiscarded.TabIndex = 26;
            this.chkAlarm_GFO_ExcludeDiscarded.Text = "Exclude Discarded";
            this.chkAlarm_GFO_ExcludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "End Time:";
            // 
            // chkAlarm_GFO_ExcludeAcknowledged
            // 
            this.chkAlarm_GFO_ExcludeAcknowledged.AutoSize = true;
            this.chkAlarm_GFO_ExcludeAcknowledged.Location = new System.Drawing.Point(335, 25);
            this.chkAlarm_GFO_ExcludeAcknowledged.Name = "chkAlarm_GFO_ExcludeAcknowledged";
            this.chkAlarm_GFO_ExcludeAcknowledged.Size = new System.Drawing.Size(138, 17);
            this.chkAlarm_GFO_ExcludeAcknowledged.TabIndex = 25;
            this.chkAlarm_GFO_ExcludeAcknowledged.Text = "Exclude Acknowledged";
            this.chkAlarm_GFO_ExcludeAcknowledged.UseVisualStyleBackColor = true;
            // 
            // TgpGetAnnotation
            // 
            this.TgpGetAnnotation.Controls.Add(this.GrbGetAlarmAnnotation);
            this.TgpGetAnnotation.Location = new System.Drawing.Point(4, 29);
            this.TgpGetAnnotation.Name = "TgpGetAnnotation";
            this.TgpGetAnnotation.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TgpGetAnnotation.Size = new System.Drawing.Size(1066, 411);
            this.TgpGetAnnotation.TabIndex = 4;
            this.TgpGetAnnotation.Text = "Get Alarm Annotations";
            this.TgpGetAnnotation.UseVisualStyleBackColor = true;
            // 
            // GrbGetAlarmAnnotation
            // 
            this.GrbGetAlarmAnnotation.Controls.Add(this.LblAlarms_Annotations);
            this.GrbGetAlarmAnnotation.Controls.Add(this.TxtAlarms_Annotations);
            this.GrbGetAlarmAnnotation.Controls.Add(this.BtnAlarms_GetAnnotations);
            this.GrbGetAlarmAnnotation.Controls.Add(this.TxtAlarmGUID);
            this.GrbGetAlarmAnnotation.Controls.Add(this.LblAlarmGUID);
            this.GrbGetAlarmAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetAlarmAnnotation.Location = new System.Drawing.Point(3, 6);
            this.GrbGetAlarmAnnotation.Name = "GrbGetAlarmAnnotation";
            this.GrbGetAlarmAnnotation.Size = new System.Drawing.Size(1060, 402);
            this.GrbGetAlarmAnnotation.TabIndex = 1;
            this.GrbGetAlarmAnnotation.TabStop = false;
            this.GrbGetAlarmAnnotation.Text = "Method: Alarms.GetAnnotations";
            // 
            // LblAlarms_Annotations
            // 
            this.LblAlarms_Annotations.AutoSize = true;
            this.LblAlarms_Annotations.Location = new System.Drawing.Point(6, 86);
            this.LblAlarms_Annotations.Name = "LblAlarms_Annotations";
            this.LblAlarms_Annotations.Size = new System.Drawing.Size(66, 13);
            this.LblAlarms_Annotations.TabIndex = 4;
            this.LblAlarms_Annotations.Text = "Annotations:";
            // 
            // TxtAlarms_Annotations
            // 
            this.TxtAlarms_Annotations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAlarms_Annotations.Location = new System.Drawing.Point(6, 102);
            this.TxtAlarms_Annotations.Multiline = true;
            this.TxtAlarms_Annotations.Name = "TxtAlarms_Annotations";
            this.TxtAlarms_Annotations.Size = new System.Drawing.Size(1047, 289);
            this.TxtAlarms_Annotations.TabIndex = 3;
            // 
            // BtnAlarms_GetAnnotations
            // 
            this.BtnAlarms_GetAnnotations.Location = new System.Drawing.Point(254, 39);
            this.BtnAlarms_GetAnnotations.Name = "BtnAlarms_GetAnnotations";
            this.BtnAlarms_GetAnnotations.Size = new System.Drawing.Size(157, 23);
            this.BtnAlarms_GetAnnotations.TabIndex = 2;
            this.BtnAlarms_GetAnnotations.Text = "GetAnnotations";
            this.BtnAlarms_GetAnnotations.UseVisualStyleBackColor = true;
            this.BtnAlarms_GetAnnotations.Click += new System.EventHandler(this.BtnGetAlarmAnnotation_Click);
            // 
            // TxtAlarmGUID
            // 
            this.TxtAlarmGUID.Location = new System.Drawing.Point(14, 41);
            this.TxtAlarmGUID.Name = "TxtAlarmGUID";
            this.TxtAlarmGUID.Size = new System.Drawing.Size(234, 20);
            this.TxtAlarmGUID.TabIndex = 1;
            // 
            // LblAlarmGUID
            // 
            this.LblAlarmGUID.AutoSize = true;
            this.LblAlarmGUID.Location = new System.Drawing.Point(11, 25);
            this.LblAlarmGUID.Name = "LblAlarmGUID";
            this.LblAlarmGUID.Size = new System.Drawing.Size(86, 13);
            this.LblAlarmGUID.TabIndex = 0;
            this.LblAlarmGUID.Text = "Alarm ID (GUID):";
            this.LblAlarmGUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAudit_GFO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvAudit_GFO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAudit_GFO.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvAudit_GFO.Location = new System.Drawing.Point(6, 136);
            this.DgvAudit_GFO.Name = "DgvAudit_GFO";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAudit_GFO.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
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
            this.TpgEquipment.Controls.Add(this.TabEquipment);
            this.TpgEquipment.Location = new System.Drawing.Point(4, 34);
            this.TpgEquipment.Name = "TpgEquipment";
            this.TpgEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgEquipment.Size = new System.Drawing.Size(1080, 450);
            this.TpgEquipment.TabIndex = 8;
            this.TpgEquipment.Text = "EQUIPMENTS";
            // 
            // TabEquipment
            // 
            this.TabEquipment.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabEquipment.Controls.Add(this.TpgGetEquipment);
            this.TabEquipment.Controls.Add(this.TpgGetEquipmentPoints);
            this.TabEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabEquipment.ItemSize = new System.Drawing.Size(58, 25);
            this.TabEquipment.Location = new System.Drawing.Point(3, 3);
            this.TabEquipment.Name = "TabEquipment";
            this.TabEquipment.SelectedIndex = 0;
            this.TabEquipment.Size = new System.Drawing.Size(1074, 444);
            this.TabEquipment.TabIndex = 1;
            // 
            // TpgGetEquipment
            // 
            this.TpgGetEquipment.Controls.Add(this.GrbGetEquipment);
            this.TpgGetEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetEquipment.Name = "TpgGetEquipment";
            this.TpgGetEquipment.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetEquipment.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetEquipment.TabIndex = 0;
            this.TpgGetEquipment.Text = "Get Equipments";
            this.TpgGetEquipment.UseVisualStyleBackColor = true;
            // 
            // GrbGetEquipment
            // 
            this.GrbGetEquipment.Controls.Add(this.BtnGetEquipment);
            this.GrbGetEquipment.Controls.Add(this.DgvGetEquipment);
            this.GrbGetEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetEquipment.Location = new System.Drawing.Point(3, 6);
            this.GrbGetEquipment.Name = "GrbGetEquipment";
            this.GrbGetEquipment.Size = new System.Drawing.Size(1060, 402);
            this.GrbGetEquipment.TabIndex = 0;
            this.GrbGetEquipment.TabStop = false;
            this.GrbGetEquipment.Text = "Method: GetEquipment";
            // 
            // BtnGetEquipment
            // 
            this.BtnGetEquipment.Location = new System.Drawing.Point(6, 19);
            this.BtnGetEquipment.Name = "BtnGetEquipment";
            this.BtnGetEquipment.Size = new System.Drawing.Size(515, 23);
            this.BtnGetEquipment.TabIndex = 26;
            this.BtnGetEquipment.Text = "GetEquipment";
            this.BtnGetEquipment.UseVisualStyleBackColor = true;
            this.BtnGetEquipment.Click += new System.EventHandler(this.BtnGetEquipment_Click);
            // 
            // DgvGetEquipment
            // 
            this.DgvGetEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGetEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetEquipment.Location = new System.Drawing.Point(6, 48);
            this.DgvGetEquipment.Name = "DgvGetEquipment";
            this.DgvGetEquipment.Size = new System.Drawing.Size(1048, 348);
            this.DgvGetEquipment.TabIndex = 25;
            // 
            // TpgGetEquipmentPoints
            // 
            this.TpgGetEquipmentPoints.Location = new System.Drawing.Point(4, 29);
            this.TpgGetEquipmentPoints.Name = "TpgGetEquipmentPoints";
            this.TpgGetEquipmentPoints.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetEquipmentPoints.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetEquipmentPoints.TabIndex = 1;
            this.TpgGetEquipmentPoints.Text = "Get Points by Equipment";
            this.TpgGetEquipmentPoints.UseVisualStyleBackColor = true;
            // 
            // TpgNetworkDevice
            // 
            this.TpgNetworkDevice.BackColor = System.Drawing.SystemColors.Control;
            this.TpgNetworkDevice.Controls.Add(this.TabNetworkDevice);
            this.TpgNetworkDevice.Location = new System.Drawing.Point(4, 34);
            this.TpgNetworkDevice.Name = "TpgNetworkDevice";
            this.TpgNetworkDevice.Padding = new System.Windows.Forms.Padding(3);
            this.TpgNetworkDevice.Size = new System.Drawing.Size(1080, 450);
            this.TpgNetworkDevice.TabIndex = 9;
            this.TpgNetworkDevice.Text = "NETWORK DEVICES";
            // 
            // TabNetworkDevice
            // 
            this.TabNetworkDevice.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabNetworkDevice.Controls.Add(this.TpgGetNetworkDevices);
            this.TabNetworkDevice.Controls.Add(this.TpgGetNetworkDeviceTypes);
            this.TabNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabNetworkDevice.ItemSize = new System.Drawing.Size(58, 25);
            this.TabNetworkDevice.Location = new System.Drawing.Point(3, 3);
            this.TabNetworkDevice.Name = "TabNetworkDevice";
            this.TabNetworkDevice.SelectedIndex = 0;
            this.TabNetworkDevice.Size = new System.Drawing.Size(1074, 444);
            this.TabNetworkDevice.TabIndex = 0;
            // 
            // TpgGetNetworkDevices
            // 
            this.TpgGetNetworkDevices.Controls.Add(this.GrbGetNetworkDevices);
            this.TpgGetNetworkDevices.Location = new System.Drawing.Point(4, 29);
            this.TpgGetNetworkDevices.Name = "TpgGetNetworkDevices";
            this.TpgGetNetworkDevices.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetNetworkDevices.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetNetworkDevices.TabIndex = 0;
            this.TpgGetNetworkDevices.Text = "Get Network Devices";
            this.TpgGetNetworkDevices.UseVisualStyleBackColor = true;
            // 
            // GrbGetNetworkDevices
            // 
            this.GrbGetNetworkDevices.Controls.Add(this.DgvGetNetworkDevices);
            this.GrbGetNetworkDevices.Controls.Add(this.BtnGetNetworkDevices);
            this.GrbGetNetworkDevices.Controls.Add(this.TxtGetNetworkDevices_Type_ID);
            this.GrbGetNetworkDevices.Controls.Add(this.LblGetNetworkDevices_Type_ID);
            this.GrbGetNetworkDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetNetworkDevices.Location = new System.Drawing.Point(3, 6);
            this.GrbGetNetworkDevices.Name = "GrbGetNetworkDevices";
            this.GrbGetNetworkDevices.Size = new System.Drawing.Size(1060, 402);
            this.GrbGetNetworkDevices.TabIndex = 0;
            this.GrbGetNetworkDevices.TabStop = false;
            this.GrbGetNetworkDevices.Text = "Method: GetNetworkDevices";
            // 
            // DgvGetNetworkDevices
            // 
            this.DgvGetNetworkDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGetNetworkDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetNetworkDevices.Location = new System.Drawing.Point(9, 85);
            this.DgvGetNetworkDevices.Name = "DgvGetNetworkDevices";
            this.DgvGetNetworkDevices.Size = new System.Drawing.Size(1045, 311);
            this.DgvGetNetworkDevices.TabIndex = 27;
            // 
            // BtnGetNetworkDevices
            // 
            this.BtnGetNetworkDevices.Location = new System.Drawing.Point(9, 56);
            this.BtnGetNetworkDevices.Name = "BtnGetNetworkDevices";
            this.BtnGetNetworkDevices.Size = new System.Drawing.Size(207, 23);
            this.BtnGetNetworkDevices.TabIndex = 5;
            this.BtnGetNetworkDevices.Text = "GetNetworkDevices";
            this.BtnGetNetworkDevices.UseVisualStyleBackColor = true;
            this.BtnGetNetworkDevices.Click += new System.EventHandler(this.BtnGetNetworkDevices_Click);
            // 
            // TxtGetNetworkDevices_Type_ID
            // 
            this.TxtGetNetworkDevices_Type_ID.Location = new System.Drawing.Point(9, 30);
            this.TxtGetNetworkDevices_Type_ID.Name = "TxtGetNetworkDevices_Type_ID";
            this.TxtGetNetworkDevices_Type_ID.Size = new System.Drawing.Size(207, 20);
            this.TxtGetNetworkDevices_Type_ID.TabIndex = 4;
            // 
            // LblGetNetworkDevices_Type_ID
            // 
            this.LblGetNetworkDevices_Type_ID.AutoSize = true;
            this.LblGetNetworkDevices_Type_ID.Location = new System.Drawing.Point(6, 16);
            this.LblGetNetworkDevices_Type_ID.Name = "LblGetNetworkDevices_Type_ID";
            this.LblGetNetworkDevices_Type_ID.Size = new System.Drawing.Size(131, 13);
            this.LblGetNetworkDevices_Type_ID.TabIndex = 3;
            this.LblGetNetworkDevices_Type_ID.Text = "Device Type ID (numeric):";
            // 
            // TpgGetNetworkDeviceTypes
            // 
            this.TpgGetNetworkDeviceTypes.Controls.Add(this.GrbGetNetworkDeviceTypes);
            this.TpgGetNetworkDeviceTypes.Location = new System.Drawing.Point(4, 29);
            this.TpgGetNetworkDeviceTypes.Name = "TpgGetNetworkDeviceTypes";
            this.TpgGetNetworkDeviceTypes.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetNetworkDeviceTypes.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetNetworkDeviceTypes.TabIndex = 1;
            this.TpgGetNetworkDeviceTypes.Text = "Get Network Device Types";
            this.TpgGetNetworkDeviceTypes.UseVisualStyleBackColor = true;
            // 
            // GrbGetNetworkDeviceTypes
            // 
            this.GrbGetNetworkDeviceTypes.Controls.Add(this.BtnGetNetworkDeviceTypes);
            this.GrbGetNetworkDeviceTypes.Controls.Add(this.DgvGetNetworkDeviceTypes);
            this.GrbGetNetworkDeviceTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetNetworkDeviceTypes.Location = new System.Drawing.Point(3, 6);
            this.GrbGetNetworkDeviceTypes.Name = "GrbGetNetworkDeviceTypes";
            this.GrbGetNetworkDeviceTypes.Size = new System.Drawing.Size(1060, 402);
            this.GrbGetNetworkDeviceTypes.TabIndex = 0;
            this.GrbGetNetworkDeviceTypes.TabStop = false;
            this.GrbGetNetworkDeviceTypes.Text = "Method: GetNetworkDeviceTypes";
            // 
            // BtnGetNetworkDeviceTypes
            // 
            this.BtnGetNetworkDeviceTypes.Location = new System.Drawing.Point(6, 19);
            this.BtnGetNetworkDeviceTypes.Name = "BtnGetNetworkDeviceTypes";
            this.BtnGetNetworkDeviceTypes.Size = new System.Drawing.Size(515, 23);
            this.BtnGetNetworkDeviceTypes.TabIndex = 27;
            this.BtnGetNetworkDeviceTypes.Text = "GetNetworkDeviceTypes";
            this.BtnGetNetworkDeviceTypes.UseVisualStyleBackColor = true;
            this.BtnGetNetworkDeviceTypes.Click += new System.EventHandler(this.BtnGetNetworkDeviceTypes_Click);
            // 
            // DgvGetNetworkDeviceTypes
            // 
            this.DgvGetNetworkDeviceTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGetNetworkDeviceTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetNetworkDeviceTypes.Location = new System.Drawing.Point(6, 48);
            this.DgvGetNetworkDeviceTypes.Name = "DgvGetNetworkDeviceTypes";
            this.DgvGetNetworkDeviceTypes.Size = new System.Drawing.Size(1048, 348);
            this.DgvGetNetworkDeviceTypes.TabIndex = 26;
            // 
            // TpgObject
            // 
            this.TpgObject.BackColor = System.Drawing.SystemColors.Control;
            this.TpgObject.Controls.Add(this.TabObject);
            this.TpgObject.Location = new System.Drawing.Point(4, 34);
            this.TpgObject.Name = "TpgObject";
            this.TpgObject.Padding = new System.Windows.Forms.Padding(3);
            this.TpgObject.Size = new System.Drawing.Size(1080, 450);
            this.TpgObject.TabIndex = 5;
            this.TpgObject.Text = "OBJECTS";
            // 
            // TabObject
            // 
            this.TabObject.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabObject.Controls.Add(this.TpgGetObjectIdentifier);
            this.TabObject.Controls.Add(this.TpgGetObjects);
            this.TabObject.Controls.Add(this.TpgGetCommands);
            this.TabObject.Controls.Add(this.TpgGetCommandEnumeration);
            this.TabObject.Controls.Add(this.TpgReadProperty);
            this.TabObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabObject.ItemSize = new System.Drawing.Size(106, 25);
            this.TabObject.Location = new System.Drawing.Point(3, 3);
            this.TabObject.Name = "TabObject";
            this.TabObject.SelectedIndex = 0;
            this.TabObject.Size = new System.Drawing.Size(1074, 444);
            this.TabObject.TabIndex = 0;
            // 
            // TpgGetObjectIdentifier
            // 
            this.TpgGetObjectIdentifier.Controls.Add(this.label11);
            this.TpgGetObjectIdentifier.Controls.Add(this.TxtObjectIdentifier_GUID);
            this.TpgGetObjectIdentifier.Controls.Add(this.LblObjectIdentifier_GUID);
            this.TpgGetObjectIdentifier.Controls.Add(this.BtnGetObjectIdentifier);
            this.TpgGetObjectIdentifier.Controls.Add(this.TxtGetObjectIdentifier_FQR);
            this.TpgGetObjectIdentifier.Controls.Add(this.LblGetObjectIdentifier_FQR);
            this.TpgGetObjectIdentifier.Location = new System.Drawing.Point(4, 29);
            this.TpgGetObjectIdentifier.Name = "TpgGetObjectIdentifier";
            this.TpgGetObjectIdentifier.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetObjectIdentifier.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetObjectIdentifier.TabIndex = 0;
            this.TpgGetObjectIdentifier.Text = "Get Object Identifier";
            this.TpgGetObjectIdentifier.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Method: GetObjectIdentifier";
            // 
            // TxtObjectIdentifier_GUID
            // 
            this.TxtObjectIdentifier_GUID.Location = new System.Drawing.Point(78, 92);
            this.TxtObjectIdentifier_GUID.Name = "TxtObjectIdentifier_GUID";
            this.TxtObjectIdentifier_GUID.ReadOnly = true;
            this.TxtObjectIdentifier_GUID.Size = new System.Drawing.Size(316, 20);
            this.TxtObjectIdentifier_GUID.TabIndex = 4;
            // 
            // LblObjectIdentifier_GUID
            // 
            this.LblObjectIdentifier_GUID.AutoSize = true;
            this.LblObjectIdentifier_GUID.Location = new System.Drawing.Point(6, 95);
            this.LblObjectIdentifier_GUID.Name = "LblObjectIdentifier_GUID";
            this.LblObjectIdentifier_GUID.Size = new System.Drawing.Size(68, 13);
            this.LblObjectIdentifier_GUID.TabIndex = 3;
            this.LblObjectIdentifier_GUID.Text = "Object GUID";
            // 
            // BtnGetObjectIdentifier
            // 
            this.BtnGetObjectIdentifier.Location = new System.Drawing.Point(78, 63);
            this.BtnGetObjectIdentifier.Name = "BtnGetObjectIdentifier";
            this.BtnGetObjectIdentifier.Size = new System.Drawing.Size(316, 23);
            this.BtnGetObjectIdentifier.TabIndex = 2;
            this.BtnGetObjectIdentifier.Text = "GetObjectIdentifier";
            this.BtnGetObjectIdentifier.UseVisualStyleBackColor = true;
            this.BtnGetObjectIdentifier.Click += new System.EventHandler(this.BtnGetObjectIdentifier_Click);
            // 
            // TxtGetObjectIdentifier_FQR
            // 
            this.TxtGetObjectIdentifier_FQR.Location = new System.Drawing.Point(78, 37);
            this.TxtGetObjectIdentifier_FQR.Name = "TxtGetObjectIdentifier_FQR";
            this.TxtGetObjectIdentifier_FQR.Size = new System.Drawing.Size(576, 20);
            this.TxtGetObjectIdentifier_FQR.TabIndex = 1;
            // 
            // LblGetObjectIdentifier_FQR
            // 
            this.LblGetObjectIdentifier_FQR.AutoSize = true;
            this.LblGetObjectIdentifier_FQR.Location = new System.Drawing.Point(6, 40);
            this.LblGetObjectIdentifier_FQR.Name = "LblGetObjectIdentifier_FQR";
            this.LblGetObjectIdentifier_FQR.Size = new System.Drawing.Size(63, 13);
            this.LblGetObjectIdentifier_FQR.TabIndex = 0;
            this.LblGetObjectIdentifier_FQR.Text = "Object FQR";
            // 
            // TpgGetObjects
            // 
            this.TpgGetObjects.Location = new System.Drawing.Point(4, 29);
            this.TpgGetObjects.Name = "TpgGetObjects";
            this.TpgGetObjects.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetObjects.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetObjects.TabIndex = 1;
            this.TpgGetObjects.Text = "Get Objects";
            this.TpgGetObjects.UseVisualStyleBackColor = true;
            // 
            // TpgGetCommands
            // 
            this.TpgGetCommands.Controls.Add(this.GrbGetCommands);
            this.TpgGetCommands.Location = new System.Drawing.Point(4, 29);
            this.TpgGetCommands.Name = "TpgGetCommands";
            this.TpgGetCommands.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetCommands.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetCommands.TabIndex = 2;
            this.TpgGetCommands.Text = "Get Commands List";
            this.TpgGetCommands.UseVisualStyleBackColor = true;
            // 
            // GrbGetCommands
            // 
            this.GrbGetCommands.Controls.Add(this.DgvGetCommandEnums);
            this.GrbGetCommands.Controls.Add(this.BtnGetCommandEnums);
            this.GrbGetCommands.Controls.Add(this.DgvGetCommands);
            this.GrbGetCommands.Controls.Add(this.BtnGetCommands);
            this.GrbGetCommands.Controls.Add(this.TxtObjects_GetCommands_GUID);
            this.GrbGetCommands.Controls.Add(this.LblObjects_GetCommands_GUID);
            this.GrbGetCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetCommands.Location = new System.Drawing.Point(3, 6);
            this.GrbGetCommands.Name = "GrbGetCommands";
            this.GrbGetCommands.Size = new System.Drawing.Size(1060, 402);
            this.GrbGetCommands.TabIndex = 0;
            this.GrbGetCommands.TabStop = false;
            this.GrbGetCommands.Text = "Method: GetCommands";
            // 
            // DgvGetCommandEnums
            // 
            this.DgvGetCommandEnums.AllowUserToAddRows = false;
            this.DgvGetCommandEnums.AllowUserToDeleteRows = false;
            this.DgvGetCommandEnums.AllowUserToResizeRows = false;
            this.DgvGetCommandEnums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetCommandEnums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvCommandEnum_TitleEnumerationKey});
            this.DgvGetCommandEnums.Location = new System.Drawing.Point(608, 94);
            this.DgvGetCommandEnums.Name = "DgvGetCommandEnums";
            this.DgvGetCommandEnums.Size = new System.Drawing.Size(446, 302);
            this.DgvGetCommandEnums.TabIndex = 33;
            // 
            // DgvCommandEnum_TitleEnumerationKey
            // 
            this.DgvCommandEnum_TitleEnumerationKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvCommandEnum_TitleEnumerationKey.HeaderText = "TitleEnumerationKey";
            this.DgvCommandEnum_TitleEnumerationKey.Name = "DgvCommandEnum_TitleEnumerationKey";
            this.DgvCommandEnum_TitleEnumerationKey.Width = 129;
            // 
            // BtnGetCommandEnums
            // 
            this.BtnGetCommandEnums.Location = new System.Drawing.Point(608, 65);
            this.BtnGetCommandEnums.Name = "BtnGetCommandEnums";
            this.BtnGetCommandEnums.Size = new System.Drawing.Size(261, 23);
            this.BtnGetCommandEnums.TabIndex = 32;
            this.BtnGetCommandEnums.Text = "Get Command Enumerations";
            this.BtnGetCommandEnums.UseVisualStyleBackColor = true;
            this.BtnGetCommandEnums.Click += new System.EventHandler(this.BtnGetCommandEnums_Click);
            // 
            // DgvGetCommands
            // 
            this.DgvGetCommands.AllowUserToAddRows = false;
            this.DgvGetCommands.AllowUserToDeleteRows = false;
            this.DgvGetCommands.AllowUserToResizeRows = false;
            this.DgvGetCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGetCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvCommand_Title,
            this.DgvCommand_TitleEnumerationKey,
            this.DgvCommand_CommandId});
            this.DgvGetCommands.Location = new System.Drawing.Point(6, 94);
            this.DgvGetCommands.Name = "DgvGetCommands";
            this.DgvGetCommands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvGetCommands.Size = new System.Drawing.Size(596, 302);
            this.DgvGetCommands.TabIndex = 31;
            // 
            // DgvCommand_Title
            // 
            this.DgvCommand_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvCommand_Title.HeaderText = "Title";
            this.DgvCommand_Title.Name = "DgvCommand_Title";
            this.DgvCommand_Title.Width = 52;
            // 
            // DgvCommand_TitleEnumerationKey
            // 
            this.DgvCommand_TitleEnumerationKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvCommand_TitleEnumerationKey.HeaderText = "TitleEnumerationKey";
            this.DgvCommand_TitleEnumerationKey.Name = "DgvCommand_TitleEnumerationKey";
            this.DgvCommand_TitleEnumerationKey.Width = 129;
            // 
            // DgvCommand_CommandId
            // 
            this.DgvCommand_CommandId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvCommand_CommandId.HeaderText = "CommandId";
            this.DgvCommand_CommandId.Name = "DgvCommand_CommandId";
            this.DgvCommand_CommandId.Width = 88;
            // 
            // BtnGetCommands
            // 
            this.BtnGetCommands.Location = new System.Drawing.Point(6, 65);
            this.BtnGetCommands.Name = "BtnGetCommands";
            this.BtnGetCommands.Size = new System.Drawing.Size(344, 23);
            this.BtnGetCommands.TabIndex = 30;
            this.BtnGetCommands.Text = "GetCommands";
            this.BtnGetCommands.UseVisualStyleBackColor = true;
            this.BtnGetCommands.Click += new System.EventHandler(this.BtnGetCommands_Click);
            // 
            // TxtObjects_GetCommands_GUID
            // 
            this.TxtObjects_GetCommands_GUID.Location = new System.Drawing.Point(6, 39);
            this.TxtObjects_GetCommands_GUID.Name = "TxtObjects_GetCommands_GUID";
            this.TxtObjects_GetCommands_GUID.Size = new System.Drawing.Size(344, 20);
            this.TxtObjects_GetCommands_GUID.TabIndex = 29;
            // 
            // LblObjects_GetCommands_GUID
            // 
            this.LblObjects_GetCommands_GUID.AutoSize = true;
            this.LblObjects_GetCommands_GUID.Location = new System.Drawing.Point(3, 25);
            this.LblObjects_GetCommands_GUID.Name = "LblObjects_GetCommands_GUID";
            this.LblObjects_GetCommands_GUID.Size = new System.Drawing.Size(91, 13);
            this.LblObjects_GetCommands_GUID.TabIndex = 28;
            this.LblObjects_GetCommands_GUID.Text = "Object ID (GUID):";
            // 
            // TpgGetCommandEnumeration
            // 
            this.TpgGetCommandEnumeration.Controls.Add(this.GrbGetCommandEnumeration);
            this.TpgGetCommandEnumeration.Location = new System.Drawing.Point(4, 29);
            this.TpgGetCommandEnumeration.Name = "TpgGetCommandEnumeration";
            this.TpgGetCommandEnumeration.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgGetCommandEnumeration.Size = new System.Drawing.Size(1066, 411);
            this.TpgGetCommandEnumeration.TabIndex = 3;
            this.TpgGetCommandEnumeration.Text = "Get Command Enumeration";
            this.TpgGetCommandEnumeration.UseVisualStyleBackColor = true;
            // 
            // GrbGetCommandEnumeration
            // 
            this.GrbGetCommandEnumeration.Controls.Add(this.DgvGetCommandEnumeration);
            this.GrbGetCommandEnumeration.Controls.Add(this.BtnGetCommandEnumeration);
            this.GrbGetCommandEnumeration.Controls.Add(this.TxtObjects_GetCommandEnum_ID);
            this.GrbGetCommandEnumeration.Controls.Add(this.LblObjects_GetCommandEnum_ID);
            this.GrbGetCommandEnumeration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetCommandEnumeration.Location = new System.Drawing.Point(3, 6);
            this.GrbGetCommandEnumeration.Name = "GrbGetCommandEnumeration";
            this.GrbGetCommandEnumeration.Size = new System.Drawing.Size(1060, 402);
            this.GrbGetCommandEnumeration.TabIndex = 0;
            this.GrbGetCommandEnumeration.TabStop = false;
            this.GrbGetCommandEnumeration.Text = "Method: GetCommandEnumeration";
            // 
            // DgvGetCommandEnumeration
            // 
            this.DgvGetCommandEnumeration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGetCommandEnumeration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetCommandEnumeration.Location = new System.Drawing.Point(6, 94);
            this.DgvGetCommandEnumeration.Name = "DgvGetCommandEnumeration";
            this.DgvGetCommandEnumeration.Size = new System.Drawing.Size(1048, 302);
            this.DgvGetCommandEnumeration.TabIndex = 35;
            // 
            // BtnGetCommandEnumeration
            // 
            this.BtnGetCommandEnumeration.Location = new System.Drawing.Point(6, 65);
            this.BtnGetCommandEnumeration.Name = "BtnGetCommandEnumeration";
            this.BtnGetCommandEnumeration.Size = new System.Drawing.Size(207, 23);
            this.BtnGetCommandEnumeration.TabIndex = 34;
            this.BtnGetCommandEnumeration.Text = "GetCommandEnumeration";
            this.BtnGetCommandEnumeration.UseVisualStyleBackColor = true;
            this.BtnGetCommandEnumeration.Click += new System.EventHandler(this.BtnGetCommandEnumeration_Click);
            // 
            // TxtObjects_GetCommandEnum_ID
            // 
            this.TxtObjects_GetCommandEnum_ID.Location = new System.Drawing.Point(6, 39);
            this.TxtObjects_GetCommandEnum_ID.Name = "TxtObjects_GetCommandEnum_ID";
            this.TxtObjects_GetCommandEnum_ID.Size = new System.Drawing.Size(207, 20);
            this.TxtObjects_GetCommandEnum_ID.TabIndex = 33;
            // 
            // LblObjects_GetCommandEnum_ID
            // 
            this.LblObjects_GetCommandEnum_ID.AutoSize = true;
            this.LblObjects_GetCommandEnum_ID.Location = new System.Drawing.Point(3, 25);
            this.LblObjects_GetCommandEnum_ID.Name = "LblObjects_GetCommandEnum_ID";
            this.LblObjects_GetCommandEnum_ID.Size = new System.Drawing.Size(91, 13);
            this.LblObjects_GetCommandEnum_ID.TabIndex = 32;
            this.LblObjects_GetCommandEnum_ID.Text = "Object ID (GUID):";
            // 
            // TpgReadProperty
            // 
            this.TpgReadProperty.Controls.Add(this.LblObject_Title5);
            this.TpgReadProperty.Controls.Add(this.grbReadProperty);
            this.TpgReadProperty.Location = new System.Drawing.Point(4, 29);
            this.TpgReadProperty.Name = "TpgReadProperty";
            this.TpgReadProperty.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TpgReadProperty.Size = new System.Drawing.Size(1066, 411);
            this.TpgReadProperty.TabIndex = 4;
            this.TpgReadProperty.Text = "Read Object Property";
            this.TpgReadProperty.UseVisualStyleBackColor = true;
            // 
            // LblObject_Title5
            // 
            this.LblObject_Title5.AutoSize = true;
            this.LblObject_Title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblObject_Title5.Location = new System.Drawing.Point(6, 6);
            this.LblObject_Title5.Name = "LblObject_Title5";
            this.LblObject_Title5.Size = new System.Drawing.Size(171, 16);
            this.LblObject_Title5.TabIndex = 29;
            this.LblObject_Title5.Text = "Function: ReadProperty";
            // 
            // grbReadProperty
            // 
            this.grbReadProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbReadProperty.Controls.Add(this.lblPropertyValue);
            this.grbReadProperty.Controls.Add(this.TxtObject_PropertyValue);
            this.grbReadProperty.Controls.Add(this.lblObjectProperty);
            this.grbReadProperty.Controls.Add(this.btnReadProperty);
            this.grbReadProperty.Controls.Add(this.txtPropertyName);
            this.grbReadProperty.Controls.Add(this.lblObjectFQR);
            this.grbReadProperty.Controls.Add(this.txtObjectFQR);
            this.grbReadProperty.Location = new System.Drawing.Point(6, 25);
            this.grbReadProperty.Name = "grbReadProperty";
            this.grbReadProperty.Size = new System.Drawing.Size(1054, 380);
            this.grbReadProperty.TabIndex = 28;
            this.grbReadProperty.TabStop = false;
            // 
            // lblPropertyValue
            // 
            this.lblPropertyValue.AutoSize = true;
            this.lblPropertyValue.Location = new System.Drawing.Point(3, 111);
            this.lblPropertyValue.Name = "lblPropertyValue";
            this.lblPropertyValue.Size = new System.Drawing.Size(79, 13);
            this.lblPropertyValue.TabIndex = 6;
            this.lblPropertyValue.Text = "Property Value:";
            // 
            // TxtObject_PropertyValue
            // 
            this.TxtObject_PropertyValue.Location = new System.Drawing.Point(86, 108);
            this.TxtObject_PropertyValue.Name = "TxtObject_PropertyValue";
            this.TxtObject_PropertyValue.ReadOnly = true;
            this.TxtObject_PropertyValue.Size = new System.Drawing.Size(152, 20);
            this.TxtObject_PropertyValue.TabIndex = 5;
            // 
            // lblObjectProperty
            // 
            this.lblObjectProperty.AutoSize = true;
            this.lblObjectProperty.Location = new System.Drawing.Point(3, 50);
            this.lblObjectProperty.Name = "lblObjectProperty";
            this.lblObjectProperty.Size = new System.Drawing.Size(77, 13);
            this.lblObjectProperty.TabIndex = 4;
            this.lblObjectProperty.Text = "Property Name";
            this.lblObjectProperty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReadProperty
            // 
            this.btnReadProperty.Location = new System.Drawing.Point(86, 73);
            this.btnReadProperty.Name = "btnReadProperty";
            this.btnReadProperty.Size = new System.Drawing.Size(152, 23);
            this.btnReadProperty.TabIndex = 3;
            this.btnReadProperty.Text = "Read Property";
            this.btnReadProperty.UseVisualStyleBackColor = true;
            this.btnReadProperty.Click += new System.EventHandler(this.BtnReadProperty_Click_1);
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Location = new System.Drawing.Point(86, 47);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(152, 20);
            this.txtPropertyName.TabIndex = 2;
            this.txtPropertyName.Text = "presentValue";
            // 
            // lblObjectFQR
            // 
            this.lblObjectFQR.AutoSize = true;
            this.lblObjectFQR.Location = new System.Drawing.Point(12, 23);
            this.lblObjectFQR.Name = "lblObjectFQR";
            this.lblObjectFQR.Size = new System.Drawing.Size(66, 13);
            this.lblObjectFQR.TabIndex = 1;
            this.lblObjectFQR.Text = "Object FQR:";
            this.lblObjectFQR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObjectFQR
            // 
            this.txtObjectFQR.Location = new System.Drawing.Point(86, 20);
            this.txtObjectFQR.Name = "txtObjectFQR";
            this.txtObjectFQR.Size = new System.Drawing.Size(604, 20);
            this.txtObjectFQR.TabIndex = 0;
            // 
            // TpgSpace
            // 
            this.TpgSpace.BackColor = System.Drawing.SystemColors.Control;
            this.TpgSpace.Controls.Add(this.TabSpace);
            this.TpgSpace.Location = new System.Drawing.Point(4, 34);
            this.TpgSpace.Name = "TpgSpace";
            this.TpgSpace.Padding = new System.Windows.Forms.Padding(3);
            this.TpgSpace.Size = new System.Drawing.Size(1080, 450);
            this.TpgSpace.TabIndex = 10;
            this.TpgSpace.Text = "SPACES";
            // 
            // TabSpace
            // 
            this.TabSpace.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabSpace.Controls.Add(this.tabPage1);
            this.TabSpace.Controls.Add(this.tabPage2);
            this.TabSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabSpace.ItemSize = new System.Drawing.Size(58, 25);
            this.TabSpace.Location = new System.Drawing.Point(3, 3);
            this.TabSpace.Name = "TabSpace";
            this.TabSpace.SelectedIndex = 0;
            this.TabSpace.Size = new System.Drawing.Size(1074, 444);
            this.TabSpace.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1066, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1066, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
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
            this.GrbGetAlarms.ResumeLayout(false);
            this.GrbGetAlarms.PerformLayout();
            this.GrbAlarm_Filter.ResumeLayout(false);
            this.GrbAlarm_Filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm)).EndInit();
            this.TabMain.ResumeLayout(false);
            this.TpgLogin.ResumeLayout(false);
            this.TpgLogin.PerformLayout();
            this.TpgAlarm.ResumeLayout(false);
            this.TabAlarm.ResumeLayout(false);
            this.TgpGetAlarms.ResumeLayout(false);
            this.TgpGetAlarms.PerformLayout();
            this.TgpFindByID.ResumeLayout(false);
            this.TgpFindByID.PerformLayout();
            this.TgpGetForNetworkDevice.ResumeLayout(false);
            this.TgpGetForNetworkDevice.PerformLayout();
            this.GrbAlarm_GFND.ResumeLayout(false);
            this.GrbAlarm_GFND.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm_GFND)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TgpGetForObject.ResumeLayout(false);
            this.GrbAlarm_GFO.ResumeLayout(false);
            this.GrbAlarm_GFO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm_GFO)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.TgpGetAnnotation.ResumeLayout(false);
            this.GrbGetAlarmAnnotation.ResumeLayout(false);
            this.GrbGetAlarmAnnotation.PerformLayout();
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
            this.TpgEquipment.ResumeLayout(false);
            this.TabEquipment.ResumeLayout(false);
            this.TpgGetEquipment.ResumeLayout(false);
            this.GrbGetEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipment)).EndInit();
            this.TpgNetworkDevice.ResumeLayout(false);
            this.TabNetworkDevice.ResumeLayout(false);
            this.TpgGetNetworkDevices.ResumeLayout(false);
            this.GrbGetNetworkDevices.ResumeLayout(false);
            this.GrbGetNetworkDevices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetworkDevices)).EndInit();
            this.TpgGetNetworkDeviceTypes.ResumeLayout(false);
            this.GrbGetNetworkDeviceTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetworkDeviceTypes)).EndInit();
            this.TpgObject.ResumeLayout(false);
            this.TabObject.ResumeLayout(false);
            this.TpgGetObjectIdentifier.ResumeLayout(false);
            this.TpgGetObjectIdentifier.PerformLayout();
            this.TpgGetCommands.ResumeLayout(false);
            this.GrbGetCommands.ResumeLayout(false);
            this.GrbGetCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommandEnums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommands)).EndInit();
            this.TpgGetCommandEnumeration.ResumeLayout(false);
            this.GrbGetCommandEnumeration.ResumeLayout(false);
            this.GrbGetCommandEnumeration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommandEnumeration)).EndInit();
            this.TpgReadProperty.ResumeLayout(false);
            this.TpgReadProperty.PerformLayout();
            this.grbReadProperty.ResumeLayout(false);
            this.grbReadProperty.PerformLayout();
            this.TpgSpace.ResumeLayout(false);
            this.TabSpace.ResumeLayout(false);
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
        private System.Windows.Forms.Button BtlAlarm_Get;
        private System.Windows.Forms.Label lblAlarm_StartDate;
        private System.Windows.Forms.DateTimePicker DtpAlarm_StartTime;
        private System.Windows.Forms.GroupBox GrbGetAlarms;
        private System.Windows.Forms.DateTimePicker DtpAlarm_EndTime;
        private System.Windows.Forms.Label lblAlarm_Enddate;
        private System.Windows.Forms.DataGridView DgvAlarm;
        private System.Windows.Forms.CheckBox chkAlarm_ExcludeDiscarded;
        private System.Windows.Forms.CheckBox chkAlarm_ExcludeAcknowledged;
        private System.Windows.Forms.TextBox TxtAlarm_Total;
        private System.Windows.Forms.Label lblAlarm_Total;
        private System.Windows.Forms.GroupBox GrbAlarm_Filter;
        private System.Windows.Forms.CheckBox ChkAlarm_NoFilter;
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
        private System.Windows.Forms.TabControl TabObject;
        private System.Windows.Forms.TabPage TpgGetObjectIdentifier;
        private System.Windows.Forms.Button BtnGetObjectIdentifier;
        private System.Windows.Forms.TextBox TxtGetObjectIdentifier_FQR;
        private System.Windows.Forms.Label LblGetObjectIdentifier_FQR;
        private System.Windows.Forms.TabPage TpgGetObjects;
        private System.Windows.Forms.Label LblObjectIdentifier_GUID;
        private System.Windows.Forms.TextBox TxtObjectIdentifier_GUID;
        private System.Windows.Forms.TabPage TpgMisc;
        private System.Windows.Forms.TextBox TxtMisc_ServerTime;
        private System.Windows.Forms.Button BtnMisc_GetServerTime;
        private System.Windows.Forms.TabPage TpgEnumeration;
        private System.Windows.Forms.TabControl TabAlarm;
        private System.Windows.Forms.TabPage TgpFindByID;
        private System.Windows.Forms.TabPage TgpGetAlarms;
        private System.Windows.Forms.Button BtnAlarm_FindByID;
        private System.Windows.Forms.TextBox TxtAlarm_FindByID_GUID;
        private System.Windows.Forms.Label LblAlarm_FindByID_GUID;
        private System.Windows.Forms.PropertyGrid PrgAlarm_FindByID;
        private System.Windows.Forms.TabPage TgpGetForNetworkDevice;
        private System.Windows.Forms.GroupBox GrbAlarm_GFND;
        private System.Windows.Forms.TextBox TxtAlarm_GFND_Total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DgvAlarm_GFND;
        private System.Windows.Forms.Button BtnAlarm_GetForNetworkDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpAlarm_GFND_StartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAlarm_GFND_EndTime;
        private System.Windows.Forms.CheckBox chkAlarm_GFND_ExcludeDiscarded;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAlarm_GFND_ExcludeAcknowledged;
        private System.Windows.Forms.CheckBox chkAlarm_GFND_NoFilter;
        private System.Windows.Forms.TextBox TxtAlarm_GFND_GUID;
        private System.Windows.Forms.Label LblAlarm_GFND_GUID;
        private System.Windows.Forms.TabPage TgpGetForObject;
        private System.Windows.Forms.TabPage TgpGetAnnotation;
        private System.Windows.Forms.GroupBox GrbGetAlarmAnnotation;
        private System.Windows.Forms.Label LblAlarms_Annotations;
        private System.Windows.Forms.TextBox TxtAlarms_Annotations;
        private System.Windows.Forms.Button BtnAlarms_GetAnnotations;
        private System.Windows.Forms.TextBox TxtAlarmGUID;
        private System.Windows.Forms.Label LblAlarmGUID;
        private System.Windows.Forms.GroupBox GrbAlarm_GFO;
        private System.Windows.Forms.TextBox TxtAlarm_GFO_GUID;
        private System.Windows.Forms.Label LblAlarm_GFO_GUID;
        private System.Windows.Forms.CheckBox chkAlarm_GFO_NoFilter;
        private System.Windows.Forms.TextBox TxtAlarm_GFO_Total;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DgvAlarm_GFO;
        private System.Windows.Forms.Button BtnAlarm_GetForObject;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DtpAlarm_GFO_StartTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpAlarm_GFO_EndTime;
        private System.Windows.Forms.CheckBox chkAlarm_GFO_ExcludeDiscarded;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkAlarm_GFO_ExcludeAcknowledged;
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
        private System.Windows.Forms.GroupBox GrbGetEquipment;
        private System.Windows.Forms.Button BtnGetEquipment;
        private System.Windows.Forms.DataGridView DgvGetEquipment;
        private System.Windows.Forms.TabControl TabEquipment;
        private System.Windows.Forms.TabPage TpgGetEquipment;
        private System.Windows.Forms.TabPage TpgGetEquipmentPoints;
        private System.Windows.Forms.TabPage TpgNetworkDevice;
        private System.Windows.Forms.TabControl TabNetworkDevice;
        private System.Windows.Forms.TabPage TpgGetNetworkDevices;
        private System.Windows.Forms.TabPage TpgGetNetworkDeviceTypes;
        private System.Windows.Forms.GroupBox GrbGetNetworkDevices;
        private System.Windows.Forms.GroupBox GrbGetNetworkDeviceTypes;
        private System.Windows.Forms.Button BtnGetNetworkDeviceTypes;
        private System.Windows.Forms.DataGridView DgvGetNetworkDeviceTypes;
        private System.Windows.Forms.Button BtnGetNetworkDevices;
        private System.Windows.Forms.TextBox TxtGetNetworkDevices_Type_ID;
        private System.Windows.Forms.Label LblGetNetworkDevices_Type_ID;
        private System.Windows.Forms.DataGridView DgvGetNetworkDevices;
        private System.Windows.Forms.TabPage TpgSpace;
        private System.Windows.Forms.TabPage TpgGetCommands;
        private System.Windows.Forms.GroupBox GrbGetCommands;
        private System.Windows.Forms.DataGridView DgvGetCommands;
        private System.Windows.Forms.Button BtnGetCommands;
        private System.Windows.Forms.TextBox TxtObjects_GetCommands_GUID;
        private System.Windows.Forms.Label LblObjects_GetCommands_GUID;
        private System.Windows.Forms.TabPage TpgGetCommandEnumeration;
        private System.Windows.Forms.GroupBox GrbGetCommandEnumeration;
        private System.Windows.Forms.DataGridView DgvGetCommandEnumeration;
        private System.Windows.Forms.Button BtnGetCommandEnumeration;
        private System.Windows.Forms.TextBox TxtObjects_GetCommandEnum_ID;
        private System.Windows.Forms.Label LblObjects_GetCommandEnum_ID;
        private System.Windows.Forms.TabControl TabSpace;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnGetCommandEnums;
        private System.Windows.Forms.DataGridView DgvGetCommandEnums;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCommandEnum_TitleEnumerationKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCommand_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCommand_TitleEnumerationKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCommand_CommandId;
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblLogin_Title1;
        private System.Windows.Forms.Label LblAlarm_Get;
        private System.Windows.Forms.Label LblAlarm_FindById;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage TpgReadProperty;
        private System.Windows.Forms.GroupBox grbReadProperty;
        private System.Windows.Forms.Label lblPropertyValue;
        private System.Windows.Forms.TextBox TxtObject_PropertyValue;
        private System.Windows.Forms.Label lblObjectProperty;
        private System.Windows.Forms.Button btnReadProperty;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Label lblObjectFQR;
        private System.Windows.Forms.TextBox txtObjectFQR;
        private System.Windows.Forms.Label LblObject_Title5;
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

