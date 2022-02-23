
namespace MetasysServices_TestClient.Forms
{
    partial class Audits
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
            this.TabMain = new System.Windows.Forms.TabControl();
            this.TpgGet = new System.Windows.Forms.TabPage();
            this.TlpGet = new System.Windows.Forms.TableLayoutPanel();
            this.LblGet_Filters = new System.Windows.Forms.Label();
            this.TlpGet_Filters = new System.Windows.Forms.TableLayoutPanel();
            this.LblGet_StartTime = new System.Windows.Forms.Label();
            this.LblGet_EndTime = new System.Windows.Forms.Label();
            this.DtpGet_StartTime = new System.Windows.Forms.DateTimePicker();
            this.DtpGet_EndTime = new System.Windows.Forms.DateTimePicker();
            this.ChkGet_ExcludeDiscarded = new System.Windows.Forms.CheckBox();
            this.TlpGet_OriginApplication = new System.Windows.Forms.TableLayoutPanel();
            this.ChkGet_AlarmEvent = new System.Windows.Forms.CheckBox();
            this.ChkGet_AuditTrails = new System.Windows.Forms.CheckBox();
            this.ChkGet_DeviceServices = new System.Windows.Forms.CheckBox();
            this.ChkGet_MCE = new System.Windows.Forms.CheckBox();
            this.ChkGet_SiteServices = new System.Windows.Forms.CheckBox();
            this.LblGet_OriginApplication = new System.Windows.Forms.Label();
            this.LblGet_ActionTypes = new System.Windows.Forms.Label();
            this.TlpGet_ActionTypes = new System.Windows.Forms.TableLayoutPanel();
            this.ChkGet_Write = new System.Windows.Forms.CheckBox();
            this.ChkGet_Command = new System.Windows.Forms.CheckBox();
            this.ChkGet_Create = new System.Windows.Forms.CheckBox();
            this.ChkGet_Delete = new System.Windows.Forms.CheckBox();
            this.ChkGet_Error = new System.Windows.Forms.CheckBox();
            this.ChkGet_Subsystem = new System.Windows.Forms.CheckBox();
            this.ChkGet_NoFilters = new System.Windows.Forms.CheckBox();
            this.BtnGet = new System.Windows.Forms.Button();
            this.DgvGet = new System.Windows.Forms.DataGridView();
            this.TpgFindById = new System.Windows.Forms.TabPage();
            this.TlpFindById = new System.Windows.Forms.TableLayoutPanel();
            this.LblFindById_AuditID = new System.Windows.Forms.Label();
            this.TxtFindById_AuditID = new System.Windows.Forms.TextBox();
            this.BtnFindById = new System.Windows.Forms.Button();
            this.PrgFindById = new System.Windows.Forms.PropertyGrid();
            this.TpgGetForObject = new System.Windows.Forms.TabPage();
            this.TlpGetForObject = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetForObject_ObjectID = new System.Windows.Forms.Label();
            this.TxtGetForObject_ObjectID = new System.Windows.Forms.TextBox();
            this.LblGetForObject_Filters = new System.Windows.Forms.Label();
            this.TlpGetForObject_Filters = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetForObject_StartTime = new System.Windows.Forms.Label();
            this.DtpGetForObject_StartTime = new System.Windows.Forms.DateTimePicker();
            this.LblGetForObject_EndTime = new System.Windows.Forms.Label();
            this.DtpGetForObject_EndTime = new System.Windows.Forms.DateTimePicker();
            this.ChGetForObject_ExcludeDiscarded = new System.Windows.Forms.CheckBox();
            this.ChkGetForObject_NoFilters = new System.Windows.Forms.CheckBox();
            this.BtnGetForObject = new System.Windows.Forms.Button();
            this.DgvGetForObject = new System.Windows.Forms.DataGridView();
            this.TpgGetAnnotations = new System.Windows.Forms.TabPage();
            this.TlpGetAnnotations = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetAnnotations_AuditID = new System.Windows.Forms.Label();
            this.TxtGetAnnotations_AuditID = new System.Windows.Forms.TextBox();
            this.BtnGetAnnotations = new System.Windows.Forms.Button();
            this.TxtGetAnnotations_Result = new System.Windows.Forms.TextBox();
            this.TpgAddAnnotation = new System.Windows.Forms.TabPage();
            this.TlpAddAnnotation = new System.Windows.Forms.TableLayoutPanel();
            this.LblAddAnnotation_AuditID = new System.Windows.Forms.Label();
            this.TxtAddAnnotation_AuditID = new System.Windows.Forms.TextBox();
            this.LblAddAnnotations_AnnotationText = new System.Windows.Forms.Label();
            this.TxtAddAnnotations_AnnotationText = new System.Windows.Forms.TextBox();
            this.BtnAddAnnotation = new System.Windows.Forms.Button();
            this.TxtAddAnnotation_Result = new System.Windows.Forms.TextBox();
            this.TpgAddAnnotationMultiple = new System.Windows.Forms.TabPage();
            this.AddAnnotationMultiple = new System.Windows.Forms.TableLayoutPanel();
            this.DgvAddAnnotationMultiple_Params = new System.Windows.Forms.DataGridView();
            this.DgvAddAnnotationMultiple_AuditID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvAddAnnotationMultiple_AnnotationText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblAddAnnotationMultiple_Params = new System.Windows.Forms.Label();
            this.BtnAddAnnotationMultiple = new System.Windows.Forms.Button();
            this.LblAddAnnotationMultiple_Result = new System.Windows.Forms.Label();
            this.TxtAddAnnotationMultiple_Result = new System.Windows.Forms.TextBox();
            this.TpgDiscard = new System.Windows.Forms.TabPage();
            this.TlpDiscard = new System.Windows.Forms.TableLayoutPanel();
            this.LblDiscard_AuditID = new System.Windows.Forms.Label();
            this.TxtDiscard_AuditID = new System.Windows.Forms.TextBox();
            this.LblDiscard_AnnotationText = new System.Windows.Forms.Label();
            this.TxtDiscard_AnnotationText = new System.Windows.Forms.TextBox();
            this.BtnDiscard = new System.Windows.Forms.Button();
            this.LblDiscard_Result = new System.Windows.Forms.Label();
            this.TxtDiscard_Result = new System.Windows.Forms.TextBox();
            this.TpgDiscardMultiple = new System.Windows.Forms.TabPage();
            this.TlpDiscardMultiple = new System.Windows.Forms.TableLayoutPanel();
            this.LblDiscardMultiple_Params = new System.Windows.Forms.Label();
            this.DgvDiscardMultiple_Params = new System.Windows.Forms.DataGridView();
            this.DgvDiscardMultiple_AuditID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvDiscardMultiple_AnnotationText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnDiscardMultiple = new System.Windows.Forms.Button();
            this.LblDiscardMultiple_Result = new System.Windows.Forms.Label();
            this.TxtDiscardMultiple_Result = new System.Windows.Forms.TextBox();
            this.TabMain.SuspendLayout();
            this.TpgGet.SuspendLayout();
            this.TlpGet.SuspendLayout();
            this.TlpGet_Filters.SuspendLayout();
            this.TlpGet_OriginApplication.SuspendLayout();
            this.TlpGet_ActionTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGet)).BeginInit();
            this.TpgFindById.SuspendLayout();
            this.TlpFindById.SuspendLayout();
            this.TpgGetForObject.SuspendLayout();
            this.TlpGetForObject.SuspendLayout();
            this.TlpGetForObject_Filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetForObject)).BeginInit();
            this.TpgGetAnnotations.SuspendLayout();
            this.TlpGetAnnotations.SuspendLayout();
            this.TpgAddAnnotation.SuspendLayout();
            this.TlpAddAnnotation.SuspendLayout();
            this.TpgAddAnnotationMultiple.SuspendLayout();
            this.AddAnnotationMultiple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAddAnnotationMultiple_Params)).BeginInit();
            this.TpgDiscard.SuspendLayout();
            this.TlpDiscard.SuspendLayout();
            this.TpgDiscardMultiple.SuspendLayout();
            this.TlpDiscardMultiple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDiscardMultiple_Params)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGet);
            this.TabMain.Controls.Add(this.TpgFindById);
            this.TabMain.Controls.Add(this.TpgGetForObject);
            this.TabMain.Controls.Add(this.TpgGetAnnotations);
            this.TabMain.Controls.Add(this.TpgAddAnnotation);
            this.TabMain.Controls.Add(this.TpgAddAnnotationMultiple);
            this.TabMain.Controls.Add(this.TpgDiscard);
            this.TabMain.Controls.Add(this.TpgDiscardMultiple);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(912, 585);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGet
            // 
            this.TpgGet.Controls.Add(this.TlpGet);
            this.TpgGet.Location = new System.Drawing.Point(4, 29);
            this.TpgGet.Name = "TpgGet";
            this.TpgGet.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGet.Size = new System.Drawing.Size(904, 552);
            this.TpgGet.TabIndex = 0;
            this.TpgGet.Text = "Get";
            this.TpgGet.UseVisualStyleBackColor = true;
            // 
            // TlpGet
            // 
            this.TlpGet.ColumnCount = 5;
            this.TlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGet.Controls.Add(this.LblGet_Filters, 1, 1);
            this.TlpGet.Controls.Add(this.TlpGet_Filters, 2, 1);
            this.TlpGet.Controls.Add(this.ChkGet_NoFilters, 3, 1);
            this.TlpGet.Controls.Add(this.BtnGet, 2, 2);
            this.TlpGet.Controls.Add(this.DgvGet, 2, 3);
            this.TlpGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet.Location = new System.Drawing.Point(3, 3);
            this.TlpGet.Name = "TlpGet";
            this.TlpGet.RowCount = 4;
            this.TlpGet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGet.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet.Size = new System.Drawing.Size(898, 546);
            this.TlpGet.TabIndex = 0;
            // 
            // LblGet_Filters
            // 
            this.LblGet_Filters.AutoSize = true;
            this.LblGet_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_Filters.Location = new System.Drawing.Point(23, 23);
            this.LblGet_Filters.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_Filters.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGet_Filters.Name = "LblGet_Filters";
            this.LblGet_Filters.Size = new System.Drawing.Size(140, 95);
            this.LblGet_Filters.TabIndex = 0;
            this.LblGet_Filters.Text = "Filters:";
            this.LblGet_Filters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TlpGet_Filters
            // 
            this.TlpGet_Filters.AutoSize = true;
            this.TlpGet_Filters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpGet_Filters.ColumnCount = 4;
            this.TlpGet_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGet_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGet_Filters.Controls.Add(this.LblGet_StartTime, 0, 0);
            this.TlpGet_Filters.Controls.Add(this.LblGet_EndTime, 2, 0);
            this.TlpGet_Filters.Controls.Add(this.DtpGet_StartTime, 1, 0);
            this.TlpGet_Filters.Controls.Add(this.DtpGet_EndTime, 3, 0);
            this.TlpGet_Filters.Controls.Add(this.ChkGet_ExcludeDiscarded, 1, 1);
            this.TlpGet_Filters.Controls.Add(this.TlpGet_OriginApplication, 1, 2);
            this.TlpGet_Filters.Controls.Add(this.LblGet_OriginApplication, 0, 2);
            this.TlpGet_Filters.Controls.Add(this.LblGet_ActionTypes, 0, 3);
            this.TlpGet_Filters.Controls.Add(this.TlpGet_ActionTypes, 1, 3);
            this.TlpGet_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet_Filters.Location = new System.Drawing.Point(169, 23);
            this.TlpGet_Filters.Name = "TlpGet_Filters";
            this.TlpGet_Filters.RowCount = 4;
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.Size = new System.Drawing.Size(630, 95);
            this.TlpGet_Filters.TabIndex = 1;
            // 
            // LblGet_StartTime
            // 
            this.LblGet_StartTime.AutoSize = true;
            this.LblGet_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_StartTime.Location = new System.Drawing.Point(3, 3);
            this.LblGet_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_StartTime.Name = "LblGet_StartTime";
            this.LblGet_StartTime.Size = new System.Drawing.Size(89, 20);
            this.LblGet_StartTime.TabIndex = 0;
            this.LblGet_StartTime.Text = "Start Time";
            this.LblGet_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblGet_EndTime
            // 
            this.LblGet_EndTime.AutoSize = true;
            this.LblGet_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_EndTime.Location = new System.Drawing.Point(336, 3);
            this.LblGet_EndTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_EndTime.Name = "LblGet_EndTime";
            this.LblGet_EndTime.Size = new System.Drawing.Size(52, 20);
            this.LblGet_EndTime.TabIndex = 1;
            this.LblGet_EndTime.Text = "End Time";
            this.LblGet_EndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGet_StartTime
            // 
            this.DtpGet_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGet_StartTime.Location = new System.Drawing.Point(98, 3);
            this.DtpGet_StartTime.Name = "DtpGet_StartTime";
            this.DtpGet_StartTime.Size = new System.Drawing.Size(232, 20);
            this.DtpGet_StartTime.TabIndex = 2;
            // 
            // DtpGet_EndTime
            // 
            this.DtpGet_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGet_EndTime.Location = new System.Drawing.Point(394, 3);
            this.DtpGet_EndTime.Name = "DtpGet_EndTime";
            this.DtpGet_EndTime.Size = new System.Drawing.Size(233, 20);
            this.DtpGet_EndTime.TabIndex = 3;
            // 
            // ChkGet_ExcludeDiscarded
            // 
            this.ChkGet_ExcludeDiscarded.AutoSize = true;
            this.ChkGet_ExcludeDiscarded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_ExcludeDiscarded.Location = new System.Drawing.Point(98, 29);
            this.ChkGet_ExcludeDiscarded.Name = "ChkGet_ExcludeDiscarded";
            this.ChkGet_ExcludeDiscarded.Size = new System.Drawing.Size(232, 17);
            this.ChkGet_ExcludeDiscarded.TabIndex = 4;
            this.ChkGet_ExcludeDiscarded.Text = "Exclude Dscarded";
            this.ChkGet_ExcludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // TlpGet_OriginApplication
            // 
            this.TlpGet_OriginApplication.AutoSize = true;
            this.TlpGet_OriginApplication.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpGet_OriginApplication.ColumnCount = 6;
            this.TlpGet_Filters.SetColumnSpan(this.TlpGet_OriginApplication, 3);
            this.TlpGet_OriginApplication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_OriginApplication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_OriginApplication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_OriginApplication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_OriginApplication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_OriginApplication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet_OriginApplication.Controls.Add(this.ChkGet_AlarmEvent, 0, 0);
            this.TlpGet_OriginApplication.Controls.Add(this.ChkGet_AuditTrails, 1, 0);
            this.TlpGet_OriginApplication.Controls.Add(this.ChkGet_DeviceServices, 2, 0);
            this.TlpGet_OriginApplication.Controls.Add(this.ChkGet_MCE, 3, 0);
            this.TlpGet_OriginApplication.Controls.Add(this.ChkGet_SiteServices, 4, 0);
            this.TlpGet_OriginApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet_OriginApplication.Location = new System.Drawing.Point(95, 49);
            this.TlpGet_OriginApplication.Margin = new System.Windows.Forms.Padding(0);
            this.TlpGet_OriginApplication.Name = "TlpGet_OriginApplication";
            this.TlpGet_OriginApplication.RowCount = 1;
            this.TlpGet_OriginApplication.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_OriginApplication.Size = new System.Drawing.Size(535, 23);
            this.TlpGet_OriginApplication.TabIndex = 5;
            // 
            // ChkGet_AlarmEvent
            // 
            this.ChkGet_AlarmEvent.AutoSize = true;
            this.ChkGet_AlarmEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_AlarmEvent.Location = new System.Drawing.Point(3, 3);
            this.ChkGet_AlarmEvent.Name = "ChkGet_AlarmEvent";
            this.ChkGet_AlarmEvent.Size = new System.Drawing.Size(83, 17);
            this.ChkGet_AlarmEvent.TabIndex = 0;
            this.ChkGet_AlarmEvent.Text = "Alarm Event";
            this.ChkGet_AlarmEvent.UseVisualStyleBackColor = true;
            // 
            // ChkGet_AuditTrails
            // 
            this.ChkGet_AuditTrails.AutoSize = true;
            this.ChkGet_AuditTrails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_AuditTrails.Location = new System.Drawing.Point(92, 3);
            this.ChkGet_AuditTrails.Name = "ChkGet_AuditTrails";
            this.ChkGet_AuditTrails.Size = new System.Drawing.Size(78, 17);
            this.ChkGet_AuditTrails.TabIndex = 1;
            this.ChkGet_AuditTrails.Text = "Audit Trails";
            this.ChkGet_AuditTrails.UseVisualStyleBackColor = true;
            // 
            // ChkGet_DeviceServices
            // 
            this.ChkGet_DeviceServices.AutoSize = true;
            this.ChkGet_DeviceServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_DeviceServices.Location = new System.Drawing.Point(176, 3);
            this.ChkGet_DeviceServices.Name = "ChkGet_DeviceServices";
            this.ChkGet_DeviceServices.Size = new System.Drawing.Size(104, 17);
            this.ChkGet_DeviceServices.TabIndex = 2;
            this.ChkGet_DeviceServices.Text = "Device Services";
            this.ChkGet_DeviceServices.UseVisualStyleBackColor = true;
            // 
            // ChkGet_MCE
            // 
            this.ChkGet_MCE.AutoSize = true;
            this.ChkGet_MCE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_MCE.Location = new System.Drawing.Point(286, 3);
            this.ChkGet_MCE.Name = "ChkGet_MCE";
            this.ChkGet_MCE.Size = new System.Drawing.Size(49, 17);
            this.ChkGet_MCE.TabIndex = 3;
            this.ChkGet_MCE.Text = "MCE";
            this.ChkGet_MCE.UseVisualStyleBackColor = true;
            // 
            // ChkGet_SiteServices
            // 
            this.ChkGet_SiteServices.AutoSize = true;
            this.ChkGet_SiteServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_SiteServices.Location = new System.Drawing.Point(341, 3);
            this.ChkGet_SiteServices.Name = "ChkGet_SiteServices";
            this.ChkGet_SiteServices.Size = new System.Drawing.Size(88, 17);
            this.ChkGet_SiteServices.TabIndex = 4;
            this.ChkGet_SiteServices.Text = "Site Services";
            this.ChkGet_SiteServices.UseVisualStyleBackColor = true;
            // 
            // LblGet_OriginApplication
            // 
            this.LblGet_OriginApplication.AutoSize = true;
            this.LblGet_OriginApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_OriginApplication.Location = new System.Drawing.Point(3, 52);
            this.LblGet_OriginApplication.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_OriginApplication.Name = "LblGet_OriginApplication";
            this.LblGet_OriginApplication.Size = new System.Drawing.Size(89, 17);
            this.LblGet_OriginApplication.TabIndex = 6;
            this.LblGet_OriginApplication.Text = "Origin Application";
            this.LblGet_OriginApplication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblGet_ActionTypes
            // 
            this.LblGet_ActionTypes.AutoSize = true;
            this.LblGet_ActionTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_ActionTypes.Location = new System.Drawing.Point(3, 75);
            this.LblGet_ActionTypes.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_ActionTypes.Name = "LblGet_ActionTypes";
            this.LblGet_ActionTypes.Size = new System.Drawing.Size(89, 17);
            this.LblGet_ActionTypes.TabIndex = 7;
            this.LblGet_ActionTypes.Text = "Action Types";
            this.LblGet_ActionTypes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TlpGet_ActionTypes
            // 
            this.TlpGet_ActionTypes.AutoSize = true;
            this.TlpGet_ActionTypes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpGet_ActionTypes.ColumnCount = 7;
            this.TlpGet_Filters.SetColumnSpan(this.TlpGet_ActionTypes, 3);
            this.TlpGet_ActionTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_ActionTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_ActionTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_ActionTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_ActionTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_ActionTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_ActionTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet_ActionTypes.Controls.Add(this.ChkGet_Write, 0, 0);
            this.TlpGet_ActionTypes.Controls.Add(this.ChkGet_Command, 1, 0);
            this.TlpGet_ActionTypes.Controls.Add(this.ChkGet_Create, 2, 0);
            this.TlpGet_ActionTypes.Controls.Add(this.ChkGet_Delete, 3, 0);
            this.TlpGet_ActionTypes.Controls.Add(this.ChkGet_Error, 4, 0);
            this.TlpGet_ActionTypes.Controls.Add(this.ChkGet_Subsystem, 5, 0);
            this.TlpGet_ActionTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet_ActionTypes.Location = new System.Drawing.Point(95, 72);
            this.TlpGet_ActionTypes.Margin = new System.Windows.Forms.Padding(0);
            this.TlpGet_ActionTypes.Name = "TlpGet_ActionTypes";
            this.TlpGet_ActionTypes.RowCount = 1;
            this.TlpGet_ActionTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet_ActionTypes.Size = new System.Drawing.Size(535, 23);
            this.TlpGet_ActionTypes.TabIndex = 8;
            // 
            // ChkGet_Write
            // 
            this.ChkGet_Write.AutoSize = true;
            this.ChkGet_Write.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_Write.Location = new System.Drawing.Point(3, 3);
            this.ChkGet_Write.Name = "ChkGet_Write";
            this.ChkGet_Write.Size = new System.Drawing.Size(48, 17);
            this.ChkGet_Write.TabIndex = 0;
            this.ChkGet_Write.Text = "Wite";
            this.ChkGet_Write.UseVisualStyleBackColor = true;
            // 
            // ChkGet_Command
            // 
            this.ChkGet_Command.AutoSize = true;
            this.ChkGet_Command.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_Command.Location = new System.Drawing.Point(57, 3);
            this.ChkGet_Command.Name = "ChkGet_Command";
            this.ChkGet_Command.Size = new System.Drawing.Size(73, 17);
            this.ChkGet_Command.TabIndex = 1;
            this.ChkGet_Command.Text = "Command";
            this.ChkGet_Command.UseVisualStyleBackColor = true;
            // 
            // ChkGet_Create
            // 
            this.ChkGet_Create.AutoSize = true;
            this.ChkGet_Create.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_Create.Location = new System.Drawing.Point(136, 3);
            this.ChkGet_Create.Name = "ChkGet_Create";
            this.ChkGet_Create.Size = new System.Drawing.Size(57, 17);
            this.ChkGet_Create.TabIndex = 2;
            this.ChkGet_Create.Text = "Create";
            this.ChkGet_Create.UseVisualStyleBackColor = true;
            // 
            // ChkGet_Delete
            // 
            this.ChkGet_Delete.AutoSize = true;
            this.ChkGet_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_Delete.Location = new System.Drawing.Point(199, 3);
            this.ChkGet_Delete.Name = "ChkGet_Delete";
            this.ChkGet_Delete.Size = new System.Drawing.Size(57, 17);
            this.ChkGet_Delete.TabIndex = 3;
            this.ChkGet_Delete.Text = "Delete";
            this.ChkGet_Delete.UseVisualStyleBackColor = true;
            // 
            // ChkGet_Error
            // 
            this.ChkGet_Error.AutoSize = true;
            this.ChkGet_Error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_Error.Location = new System.Drawing.Point(262, 3);
            this.ChkGet_Error.Name = "ChkGet_Error";
            this.ChkGet_Error.Size = new System.Drawing.Size(48, 17);
            this.ChkGet_Error.TabIndex = 4;
            this.ChkGet_Error.Text = "Error";
            this.ChkGet_Error.UseVisualStyleBackColor = true;
            // 
            // ChkGet_Subsystem
            // 
            this.ChkGet_Subsystem.AutoSize = true;
            this.ChkGet_Subsystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_Subsystem.Location = new System.Drawing.Point(316, 3);
            this.ChkGet_Subsystem.Name = "ChkGet_Subsystem";
            this.ChkGet_Subsystem.Size = new System.Drawing.Size(77, 17);
            this.ChkGet_Subsystem.TabIndex = 5;
            this.ChkGet_Subsystem.Text = "Subsystem";
            this.ChkGet_Subsystem.UseVisualStyleBackColor = true;
            // 
            // ChkGet_NoFilters
            // 
            this.ChkGet_NoFilters.AutoSize = true;
            this.ChkGet_NoFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_NoFilters.Location = new System.Drawing.Point(805, 23);
            this.ChkGet_NoFilters.Name = "ChkGet_NoFilters";
            this.ChkGet_NoFilters.Size = new System.Drawing.Size(70, 95);
            this.ChkGet_NoFilters.TabIndex = 2;
            this.ChkGet_NoFilters.Text = "No Filters";
            this.ChkGet_NoFilters.UseVisualStyleBackColor = true;
            this.ChkGet_NoFilters.CheckedChanged += new System.EventHandler(this.ChkGet_NoFilters_CheckedChanged);
            // 
            // BtnGet
            // 
            this.TlpGet.SetColumnSpan(this.BtnGet, 2);
            this.BtnGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGet.Location = new System.Drawing.Point(169, 124);
            this.BtnGet.Name = "BtnGet";
            this.BtnGet.Size = new System.Drawing.Size(706, 23);
            this.BtnGet.TabIndex = 3;
            this.BtnGet.Text = "Audits.Get";
            this.BtnGet.UseVisualStyleBackColor = true;
            this.BtnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // DgvGet
            // 
            this.DgvGet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TlpGet.SetColumnSpan(this.DgvGet, 2);
            this.DgvGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGet.Location = new System.Drawing.Point(169, 153);
            this.DgvGet.Name = "DgvGet";
            this.DgvGet.Size = new System.Drawing.Size(706, 390);
            this.DgvGet.TabIndex = 4;
            // 
            // TpgFindById
            // 
            this.TpgFindById.Controls.Add(this.TlpFindById);
            this.TpgFindById.Location = new System.Drawing.Point(4, 29);
            this.TpgFindById.Name = "TpgFindById";
            this.TpgFindById.Padding = new System.Windows.Forms.Padding(3);
            this.TpgFindById.Size = new System.Drawing.Size(904, 552);
            this.TpgFindById.TabIndex = 1;
            this.TpgFindById.Text = "FindById";
            this.TpgFindById.UseVisualStyleBackColor = true;
            // 
            // TlpFindById
            // 
            this.TlpFindById.ColumnCount = 4;
            this.TlpFindById.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpFindById.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpFindById.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.Controls.Add(this.LblFindById_AuditID, 1, 1);
            this.TlpFindById.Controls.Add(this.TxtFindById_AuditID, 2, 1);
            this.TlpFindById.Controls.Add(this.BtnFindById, 2, 2);
            this.TlpFindById.Controls.Add(this.PrgFindById, 2, 3);
            this.TlpFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpFindById.Location = new System.Drawing.Point(3, 3);
            this.TlpFindById.Name = "TlpFindById";
            this.TlpFindById.RowCount = 4;
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpFindById.Size = new System.Drawing.Size(898, 546);
            this.TlpFindById.TabIndex = 0;
            // 
            // LblFindById_AuditID
            // 
            this.LblFindById_AuditID.AutoSize = true;
            this.LblFindById_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFindById_AuditID.Location = new System.Drawing.Point(23, 23);
            this.LblFindById_AuditID.Margin = new System.Windows.Forms.Padding(3);
            this.LblFindById_AuditID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblFindById_AuditID.Name = "LblFindById_AuditID";
            this.LblFindById_AuditID.Size = new System.Drawing.Size(140, 20);
            this.LblFindById_AuditID.TabIndex = 0;
            this.LblFindById_AuditID.Text = "Audit ID (GUID):";
            this.LblFindById_AuditID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtFindById_AuditID
            // 
            this.TxtFindById_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFindById_AuditID.Location = new System.Drawing.Point(169, 23);
            this.TxtFindById_AuditID.Name = "TxtFindById_AuditID";
            this.TxtFindById_AuditID.Size = new System.Drawing.Size(706, 20);
            this.TxtFindById_AuditID.TabIndex = 1;
            // 
            // BtnFindById
            // 
            this.BtnFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFindById.Location = new System.Drawing.Point(169, 49);
            this.BtnFindById.Name = "BtnFindById";
            this.BtnFindById.Size = new System.Drawing.Size(706, 23);
            this.BtnFindById.TabIndex = 2;
            this.BtnFindById.Text = "Audits.FindById";
            this.BtnFindById.UseVisualStyleBackColor = true;
            this.BtnFindById.Click += new System.EventHandler(this.BtnFindById_Click);
            // 
            // PrgFindById
            // 
            this.PrgFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrgFindById.HelpVisible = false;
            this.PrgFindById.Location = new System.Drawing.Point(169, 78);
            this.PrgFindById.Name = "PrgFindById";
            this.PrgFindById.Size = new System.Drawing.Size(706, 465);
            this.PrgFindById.TabIndex = 3;
            // 
            // TpgGetForObject
            // 
            this.TpgGetForObject.Controls.Add(this.TlpGetForObject);
            this.TpgGetForObject.Location = new System.Drawing.Point(4, 29);
            this.TpgGetForObject.Name = "TpgGetForObject";
            this.TpgGetForObject.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetForObject.Size = new System.Drawing.Size(904, 552);
            this.TpgGetForObject.TabIndex = 2;
            this.TpgGetForObject.Text = "GetForObject";
            this.TpgGetForObject.UseVisualStyleBackColor = true;
            // 
            // TlpGetForObject
            // 
            this.TlpGetForObject.ColumnCount = 5;
            this.TlpGetForObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetForObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetForObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetForObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetForObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetForObject.Controls.Add(this.LblGetForObject_ObjectID, 1, 1);
            this.TlpGetForObject.Controls.Add(this.TxtGetForObject_ObjectID, 2, 1);
            this.TlpGetForObject.Controls.Add(this.LblGetForObject_Filters, 1, 2);
            this.TlpGetForObject.Controls.Add(this.TlpGetForObject_Filters, 2, 2);
            this.TlpGetForObject.Controls.Add(this.ChkGetForObject_NoFilters, 3, 2);
            this.TlpGetForObject.Controls.Add(this.BtnGetForObject, 2, 3);
            this.TlpGetForObject.Controls.Add(this.DgvGetForObject, 2, 4);
            this.TlpGetForObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetForObject.Location = new System.Drawing.Point(3, 3);
            this.TlpGetForObject.Name = "TlpGetForObject";
            this.TlpGetForObject.RowCount = 5;
            this.TlpGetForObject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetForObject.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetForObject.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetForObject.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetForObject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetForObject.Size = new System.Drawing.Size(898, 546);
            this.TlpGetForObject.TabIndex = 0;
            // 
            // LblGetForObject_ObjectID
            // 
            this.LblGetForObject_ObjectID.AutoSize = true;
            this.LblGetForObject_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetForObject_ObjectID.Location = new System.Drawing.Point(23, 23);
            this.LblGetForObject_ObjectID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetForObject_ObjectID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetForObject_ObjectID.Name = "LblGetForObject_ObjectID";
            this.LblGetForObject_ObjectID.Size = new System.Drawing.Size(140, 20);
            this.LblGetForObject_ObjectID.TabIndex = 0;
            this.LblGetForObject_ObjectID.Text = "Object ID (GUID):";
            this.LblGetForObject_ObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetForObject_ObjectID
            // 
            this.TlpGetForObject.SetColumnSpan(this.TxtGetForObject_ObjectID, 2);
            this.TxtGetForObject_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetForObject_ObjectID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetForObject_ObjectID.Name = "TxtGetForObject_ObjectID";
            this.TxtGetForObject_ObjectID.Size = new System.Drawing.Size(706, 20);
            this.TxtGetForObject_ObjectID.TabIndex = 1;
            // 
            // LblGetForObject_Filters
            // 
            this.LblGetForObject_Filters.AutoSize = true;
            this.LblGetForObject_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetForObject_Filters.Location = new System.Drawing.Point(23, 49);
            this.LblGetForObject_Filters.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetForObject_Filters.Name = "LblGetForObject_Filters";
            this.LblGetForObject_Filters.Size = new System.Drawing.Size(140, 49);
            this.LblGetForObject_Filters.TabIndex = 2;
            this.LblGetForObject_Filters.Text = "Filters:";
            this.LblGetForObject_Filters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TlpGetForObject_Filters
            // 
            this.TlpGetForObject_Filters.AutoSize = true;
            this.TlpGetForObject_Filters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpGetForObject_Filters.ColumnCount = 4;
            this.TlpGetForObject_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetForObject_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetForObject_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetForObject_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetForObject_Filters.Controls.Add(this.LblGetForObject_StartTime, 0, 0);
            this.TlpGetForObject_Filters.Controls.Add(this.DtpGetForObject_StartTime, 1, 0);
            this.TlpGetForObject_Filters.Controls.Add(this.LblGetForObject_EndTime, 2, 0);
            this.TlpGetForObject_Filters.Controls.Add(this.DtpGetForObject_EndTime, 3, 0);
            this.TlpGetForObject_Filters.Controls.Add(this.ChGetForObject_ExcludeDiscarded, 1, 1);
            this.TlpGetForObject_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetForObject_Filters.Location = new System.Drawing.Point(169, 49);
            this.TlpGetForObject_Filters.Name = "TlpGetForObject_Filters";
            this.TlpGetForObject_Filters.RowCount = 2;
            this.TlpGetForObject_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetForObject_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetForObject_Filters.Size = new System.Drawing.Size(630, 49);
            this.TlpGetForObject_Filters.TabIndex = 3;
            // 
            // LblGetForObject_StartTime
            // 
            this.LblGetForObject_StartTime.AutoSize = true;
            this.LblGetForObject_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetForObject_StartTime.Location = new System.Drawing.Point(3, 3);
            this.LblGetForObject_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetForObject_StartTime.Name = "LblGetForObject_StartTime";
            this.LblGetForObject_StartTime.Size = new System.Drawing.Size(55, 20);
            this.LblGetForObject_StartTime.TabIndex = 0;
            this.LblGetForObject_StartTime.Text = "Start Time";
            this.LblGetForObject_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGetForObject_StartTime
            // 
            this.DtpGetForObject_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetForObject_StartTime.Location = new System.Drawing.Point(64, 3);
            this.DtpGetForObject_StartTime.Name = "DtpGetForObject_StartTime";
            this.DtpGetForObject_StartTime.Size = new System.Drawing.Size(249, 20);
            this.DtpGetForObject_StartTime.TabIndex = 1;
            // 
            // LblGetForObject_EndTime
            // 
            this.LblGetForObject_EndTime.AutoSize = true;
            this.LblGetForObject_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetForObject_EndTime.Location = new System.Drawing.Point(319, 3);
            this.LblGetForObject_EndTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetForObject_EndTime.Name = "LblGetForObject_EndTime";
            this.LblGetForObject_EndTime.Size = new System.Drawing.Size(52, 20);
            this.LblGetForObject_EndTime.TabIndex = 2;
            this.LblGetForObject_EndTime.Text = "End Time";
            this.LblGetForObject_EndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGetForObject_EndTime
            // 
            this.DtpGetForObject_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetForObject_EndTime.Location = new System.Drawing.Point(377, 3);
            this.DtpGetForObject_EndTime.Name = "DtpGetForObject_EndTime";
            this.DtpGetForObject_EndTime.Size = new System.Drawing.Size(250, 20);
            this.DtpGetForObject_EndTime.TabIndex = 3;
            // 
            // ChGetForObject_ExcludeDiscarded
            // 
            this.ChGetForObject_ExcludeDiscarded.AutoSize = true;
            this.ChGetForObject_ExcludeDiscarded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChGetForObject_ExcludeDiscarded.Location = new System.Drawing.Point(64, 29);
            this.ChGetForObject_ExcludeDiscarded.Name = "ChGetForObject_ExcludeDiscarded";
            this.ChGetForObject_ExcludeDiscarded.Size = new System.Drawing.Size(249, 17);
            this.ChGetForObject_ExcludeDiscarded.TabIndex = 4;
            this.ChGetForObject_ExcludeDiscarded.Text = "Exclude Discarded";
            this.ChGetForObject_ExcludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // ChkGetForObject_NoFilters
            // 
            this.ChkGetForObject_NoFilters.AutoSize = true;
            this.ChkGetForObject_NoFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGetForObject_NoFilters.Location = new System.Drawing.Point(805, 49);
            this.ChkGetForObject_NoFilters.Name = "ChkGetForObject_NoFilters";
            this.ChkGetForObject_NoFilters.Size = new System.Drawing.Size(70, 49);
            this.ChkGetForObject_NoFilters.TabIndex = 4;
            this.ChkGetForObject_NoFilters.Text = "No Filters";
            this.ChkGetForObject_NoFilters.UseVisualStyleBackColor = true;
            // 
            // BtnGetForObject
            // 
            this.BtnGetForObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetForObject.Location = new System.Drawing.Point(169, 104);
            this.BtnGetForObject.Name = "BtnGetForObject";
            this.BtnGetForObject.Size = new System.Drawing.Size(630, 23);
            this.BtnGetForObject.TabIndex = 5;
            this.BtnGetForObject.Text = "Audits.GetForObject";
            this.BtnGetForObject.UseVisualStyleBackColor = true;
            this.BtnGetForObject.Click += new System.EventHandler(this.BtnGetForObject_Click);
            // 
            // DgvGetForObject
            // 
            this.DgvGetForObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetForObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetForObject.Location = new System.Drawing.Point(169, 133);
            this.DgvGetForObject.Name = "DgvGetForObject";
            this.DgvGetForObject.Size = new System.Drawing.Size(630, 410);
            this.DgvGetForObject.TabIndex = 6;
            // 
            // TpgGetAnnotations
            // 
            this.TpgGetAnnotations.Controls.Add(this.TlpGetAnnotations);
            this.TpgGetAnnotations.Location = new System.Drawing.Point(4, 29);
            this.TpgGetAnnotations.Name = "TpgGetAnnotations";
            this.TpgGetAnnotations.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetAnnotations.Size = new System.Drawing.Size(904, 552);
            this.TpgGetAnnotations.TabIndex = 3;
            this.TpgGetAnnotations.Text = "GetAnnotations";
            this.TpgGetAnnotations.UseVisualStyleBackColor = true;
            // 
            // TlpGetAnnotations
            // 
            this.TlpGetAnnotations.ColumnCount = 4;
            this.TlpGetAnnotations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetAnnotations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetAnnotations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetAnnotations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetAnnotations.Controls.Add(this.LblGetAnnotations_AuditID, 1, 1);
            this.TlpGetAnnotations.Controls.Add(this.TxtGetAnnotations_AuditID, 2, 1);
            this.TlpGetAnnotations.Controls.Add(this.BtnGetAnnotations, 2, 2);
            this.TlpGetAnnotations.Controls.Add(this.TxtGetAnnotations_Result, 2, 3);
            this.TlpGetAnnotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetAnnotations.Location = new System.Drawing.Point(3, 3);
            this.TlpGetAnnotations.Name = "TlpGetAnnotations";
            this.TlpGetAnnotations.RowCount = 4;
            this.TlpGetAnnotations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetAnnotations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetAnnotations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetAnnotations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetAnnotations.Size = new System.Drawing.Size(898, 546);
            this.TlpGetAnnotations.TabIndex = 0;
            // 
            // LblGetAnnotations_AuditID
            // 
            this.LblGetAnnotations_AuditID.AutoSize = true;
            this.LblGetAnnotations_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetAnnotations_AuditID.Location = new System.Drawing.Point(23, 23);
            this.LblGetAnnotations_AuditID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetAnnotations_AuditID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetAnnotations_AuditID.Name = "LblGetAnnotations_AuditID";
            this.LblGetAnnotations_AuditID.Size = new System.Drawing.Size(140, 20);
            this.LblGetAnnotations_AuditID.TabIndex = 0;
            this.LblGetAnnotations_AuditID.Text = "Audit ID (GUID):";
            this.LblGetAnnotations_AuditID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetAnnotations_AuditID
            // 
            this.TxtGetAnnotations_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetAnnotations_AuditID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetAnnotations_AuditID.Name = "TxtGetAnnotations_AuditID";
            this.TxtGetAnnotations_AuditID.Size = new System.Drawing.Size(706, 20);
            this.TxtGetAnnotations_AuditID.TabIndex = 1;
            // 
            // BtnGetAnnotations
            // 
            this.BtnGetAnnotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetAnnotations.Location = new System.Drawing.Point(169, 49);
            this.BtnGetAnnotations.Name = "BtnGetAnnotations";
            this.BtnGetAnnotations.Size = new System.Drawing.Size(706, 23);
            this.BtnGetAnnotations.TabIndex = 2;
            this.BtnGetAnnotations.Text = "Audits.GetAnnotations";
            this.BtnGetAnnotations.UseVisualStyleBackColor = true;
            this.BtnGetAnnotations.Click += new System.EventHandler(this.BtnGetAnnotations_Click);
            // 
            // TxtGetAnnotations_Result
            // 
            this.TxtGetAnnotations_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetAnnotations_Result.Location = new System.Drawing.Point(169, 78);
            this.TxtGetAnnotations_Result.Multiline = true;
            this.TxtGetAnnotations_Result.Name = "TxtGetAnnotations_Result";
            this.TxtGetAnnotations_Result.Size = new System.Drawing.Size(706, 465);
            this.TxtGetAnnotations_Result.TabIndex = 3;
            // 
            // TpgAddAnnotation
            // 
            this.TpgAddAnnotation.Controls.Add(this.TlpAddAnnotation);
            this.TpgAddAnnotation.Location = new System.Drawing.Point(4, 29);
            this.TpgAddAnnotation.Name = "TpgAddAnnotation";
            this.TpgAddAnnotation.Padding = new System.Windows.Forms.Padding(3);
            this.TpgAddAnnotation.Size = new System.Drawing.Size(904, 552);
            this.TpgAddAnnotation.TabIndex = 4;
            this.TpgAddAnnotation.Text = "AddAnnotation";
            this.TpgAddAnnotation.UseVisualStyleBackColor = true;
            // 
            // TlpAddAnnotation
            // 
            this.TlpAddAnnotation.ColumnCount = 4;
            this.TlpAddAnnotation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpAddAnnotation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpAddAnnotation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpAddAnnotation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpAddAnnotation.Controls.Add(this.LblAddAnnotation_AuditID, 1, 1);
            this.TlpAddAnnotation.Controls.Add(this.TxtAddAnnotation_AuditID, 2, 1);
            this.TlpAddAnnotation.Controls.Add(this.LblAddAnnotations_AnnotationText, 1, 2);
            this.TlpAddAnnotation.Controls.Add(this.TxtAddAnnotations_AnnotationText, 2, 2);
            this.TlpAddAnnotation.Controls.Add(this.BtnAddAnnotation, 2, 3);
            this.TlpAddAnnotation.Controls.Add(this.TxtAddAnnotation_Result, 2, 4);
            this.TlpAddAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpAddAnnotation.Location = new System.Drawing.Point(3, 3);
            this.TlpAddAnnotation.Name = "TlpAddAnnotation";
            this.TlpAddAnnotation.RowCount = 6;
            this.TlpAddAnnotation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpAddAnnotation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpAddAnnotation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpAddAnnotation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpAddAnnotation.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpAddAnnotation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpAddAnnotation.Size = new System.Drawing.Size(898, 546);
            this.TlpAddAnnotation.TabIndex = 0;
            // 
            // LblAddAnnotation_AuditID
            // 
            this.LblAddAnnotation_AuditID.AutoSize = true;
            this.LblAddAnnotation_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAddAnnotation_AuditID.Location = new System.Drawing.Point(23, 23);
            this.LblAddAnnotation_AuditID.Margin = new System.Windows.Forms.Padding(3);
            this.LblAddAnnotation_AuditID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblAddAnnotation_AuditID.Name = "LblAddAnnotation_AuditID";
            this.LblAddAnnotation_AuditID.Size = new System.Drawing.Size(140, 20);
            this.LblAddAnnotation_AuditID.TabIndex = 0;
            this.LblAddAnnotation_AuditID.Text = "Audit ID (GUID):";
            this.LblAddAnnotation_AuditID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAddAnnotation_AuditID
            // 
            this.TxtAddAnnotation_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtAddAnnotation_AuditID.Location = new System.Drawing.Point(169, 23);
            this.TxtAddAnnotation_AuditID.Name = "TxtAddAnnotation_AuditID";
            this.TxtAddAnnotation_AuditID.Size = new System.Drawing.Size(706, 20);
            this.TxtAddAnnotation_AuditID.TabIndex = 1;
            // 
            // LblAddAnnotations_AnnotationText
            // 
            this.LblAddAnnotations_AnnotationText.AutoSize = true;
            this.LblAddAnnotations_AnnotationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAddAnnotations_AnnotationText.Location = new System.Drawing.Point(23, 49);
            this.LblAddAnnotations_AnnotationText.Margin = new System.Windows.Forms.Padding(3);
            this.LblAddAnnotations_AnnotationText.Name = "LblAddAnnotations_AnnotationText";
            this.LblAddAnnotations_AnnotationText.Size = new System.Drawing.Size(140, 20);
            this.LblAddAnnotations_AnnotationText.TabIndex = 2;
            this.LblAddAnnotations_AnnotationText.Text = "Annotation Text:";
            this.LblAddAnnotations_AnnotationText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAddAnnotations_AnnotationText
            // 
            this.TxtAddAnnotations_AnnotationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtAddAnnotations_AnnotationText.Location = new System.Drawing.Point(169, 49);
            this.TxtAddAnnotations_AnnotationText.Name = "TxtAddAnnotations_AnnotationText";
            this.TxtAddAnnotations_AnnotationText.Size = new System.Drawing.Size(706, 20);
            this.TxtAddAnnotations_AnnotationText.TabIndex = 3;
            // 
            // BtnAddAnnotation
            // 
            this.BtnAddAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddAnnotation.Location = new System.Drawing.Point(169, 75);
            this.BtnAddAnnotation.Name = "BtnAddAnnotation";
            this.BtnAddAnnotation.Size = new System.Drawing.Size(706, 23);
            this.BtnAddAnnotation.TabIndex = 4;
            this.BtnAddAnnotation.Text = "Audits.AddAnnotation";
            this.BtnAddAnnotation.UseVisualStyleBackColor = true;
            this.BtnAddAnnotation.Click += new System.EventHandler(this.BtnAddAnnotation_Click);
            // 
            // TxtAddAnnotation_Result
            // 
            this.TxtAddAnnotation_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtAddAnnotation_Result.Location = new System.Drawing.Point(169, 104);
            this.TxtAddAnnotation_Result.Name = "TxtAddAnnotation_Result";
            this.TxtAddAnnotation_Result.ReadOnly = true;
            this.TxtAddAnnotation_Result.Size = new System.Drawing.Size(706, 20);
            this.TxtAddAnnotation_Result.TabIndex = 5;
            // 
            // TpgAddAnnotationMultiple
            // 
            this.TpgAddAnnotationMultiple.Controls.Add(this.AddAnnotationMultiple);
            this.TpgAddAnnotationMultiple.Location = new System.Drawing.Point(4, 29);
            this.TpgAddAnnotationMultiple.Name = "TpgAddAnnotationMultiple";
            this.TpgAddAnnotationMultiple.Padding = new System.Windows.Forms.Padding(3);
            this.TpgAddAnnotationMultiple.Size = new System.Drawing.Size(904, 552);
            this.TpgAddAnnotationMultiple.TabIndex = 5;
            this.TpgAddAnnotationMultiple.Text = "AddAnnotationMultiple";
            this.TpgAddAnnotationMultiple.UseVisualStyleBackColor = true;
            // 
            // AddAnnotationMultiple
            // 
            this.AddAnnotationMultiple.ColumnCount = 4;
            this.AddAnnotationMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AddAnnotationMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AddAnnotationMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddAnnotationMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AddAnnotationMultiple.Controls.Add(this.DgvAddAnnotationMultiple_Params, 2, 1);
            this.AddAnnotationMultiple.Controls.Add(this.LblAddAnnotationMultiple_Params, 1, 1);
            this.AddAnnotationMultiple.Controls.Add(this.BtnAddAnnotationMultiple, 2, 2);
            this.AddAnnotationMultiple.Controls.Add(this.LblAddAnnotationMultiple_Result, 1, 3);
            this.AddAnnotationMultiple.Controls.Add(this.TxtAddAnnotationMultiple_Result, 2, 3);
            this.AddAnnotationMultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddAnnotationMultiple.Location = new System.Drawing.Point(3, 3);
            this.AddAnnotationMultiple.Name = "AddAnnotationMultiple";
            this.AddAnnotationMultiple.RowCount = 5;
            this.AddAnnotationMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AddAnnotationMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.AddAnnotationMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AddAnnotationMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AddAnnotationMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddAnnotationMultiple.Size = new System.Drawing.Size(898, 546);
            this.AddAnnotationMultiple.TabIndex = 0;
            // 
            // DgvAddAnnotationMultiple_Params
            // 
            this.DgvAddAnnotationMultiple_Params.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAddAnnotationMultiple_Params.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvAddAnnotationMultiple_AuditID,
            this.DgvAddAnnotationMultiple_AnnotationText});
            this.DgvAddAnnotationMultiple_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAddAnnotationMultiple_Params.Location = new System.Drawing.Point(169, 23);
            this.DgvAddAnnotationMultiple_Params.Name = "DgvAddAnnotationMultiple_Params";
            this.DgvAddAnnotationMultiple_Params.Size = new System.Drawing.Size(706, 94);
            this.DgvAddAnnotationMultiple_Params.TabIndex = 0;
            // 
            // DgvAddAnnotationMultiple_AuditID
            // 
            this.DgvAddAnnotationMultiple_AuditID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvAddAnnotationMultiple_AuditID.FillWeight = 40F;
            this.DgvAddAnnotationMultiple_AuditID.HeaderText = "Audit ID (GUID)";
            this.DgvAddAnnotationMultiple_AuditID.MinimumWidth = 140;
            this.DgvAddAnnotationMultiple_AuditID.Name = "DgvAddAnnotationMultiple_AuditID";
            this.DgvAddAnnotationMultiple_AuditID.Width = 140;
            // 
            // DgvAddAnnotationMultiple_AnnotationText
            // 
            this.DgvAddAnnotationMultiple_AnnotationText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvAddAnnotationMultiple_AnnotationText.HeaderText = "Annotation Text";
            this.DgvAddAnnotationMultiple_AnnotationText.Name = "DgvAddAnnotationMultiple_AnnotationText";
            // 
            // LblAddAnnotationMultiple_Params
            // 
            this.LblAddAnnotationMultiple_Params.AutoSize = true;
            this.LblAddAnnotationMultiple_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAddAnnotationMultiple_Params.Location = new System.Drawing.Point(23, 23);
            this.LblAddAnnotationMultiple_Params.Margin = new System.Windows.Forms.Padding(3);
            this.LblAddAnnotationMultiple_Params.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblAddAnnotationMultiple_Params.Name = "LblAddAnnotationMultiple_Params";
            this.LblAddAnnotationMultiple_Params.Size = new System.Drawing.Size(140, 94);
            this.LblAddAnnotationMultiple_Params.TabIndex = 1;
            this.LblAddAnnotationMultiple_Params.Text = "Parameters:";
            this.LblAddAnnotationMultiple_Params.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnAddAnnotationMultiple
            // 
            this.BtnAddAnnotationMultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddAnnotationMultiple.Location = new System.Drawing.Point(169, 123);
            this.BtnAddAnnotationMultiple.Name = "BtnAddAnnotationMultiple";
            this.BtnAddAnnotationMultiple.Size = new System.Drawing.Size(706, 23);
            this.BtnAddAnnotationMultiple.TabIndex = 2;
            this.BtnAddAnnotationMultiple.Text = "Audits.AddAnnotationMultiple";
            this.BtnAddAnnotationMultiple.UseVisualStyleBackColor = true;
            this.BtnAddAnnotationMultiple.Click += new System.EventHandler(this.BtnAddAnnotationMultiple_Click);
            // 
            // LblAddAnnotationMultiple_Result
            // 
            this.LblAddAnnotationMultiple_Result.AutoSize = true;
            this.LblAddAnnotationMultiple_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAddAnnotationMultiple_Result.Location = new System.Drawing.Point(23, 152);
            this.LblAddAnnotationMultiple_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblAddAnnotationMultiple_Result.Name = "LblAddAnnotationMultiple_Result";
            this.LblAddAnnotationMultiple_Result.Size = new System.Drawing.Size(140, 20);
            this.LblAddAnnotationMultiple_Result.TabIndex = 3;
            this.LblAddAnnotationMultiple_Result.Text = "Result:";
            this.LblAddAnnotationMultiple_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtAddAnnotationMultiple_Result
            // 
            this.TxtAddAnnotationMultiple_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtAddAnnotationMultiple_Result.Location = new System.Drawing.Point(169, 152);
            this.TxtAddAnnotationMultiple_Result.Name = "TxtAddAnnotationMultiple_Result";
            this.TxtAddAnnotationMultiple_Result.ReadOnly = true;
            this.TxtAddAnnotationMultiple_Result.Size = new System.Drawing.Size(706, 20);
            this.TxtAddAnnotationMultiple_Result.TabIndex = 4;
            // 
            // TpgDiscard
            // 
            this.TpgDiscard.Controls.Add(this.TlpDiscard);
            this.TpgDiscard.Location = new System.Drawing.Point(4, 29);
            this.TpgDiscard.Name = "TpgDiscard";
            this.TpgDiscard.Padding = new System.Windows.Forms.Padding(3);
            this.TpgDiscard.Size = new System.Drawing.Size(904, 552);
            this.TpgDiscard.TabIndex = 6;
            this.TpgDiscard.Text = "Discard";
            this.TpgDiscard.UseVisualStyleBackColor = true;
            // 
            // TlpDiscard
            // 
            this.TlpDiscard.ColumnCount = 4;
            this.TlpDiscard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpDiscard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDiscard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscard.Controls.Add(this.LblDiscard_AuditID, 1, 1);
            this.TlpDiscard.Controls.Add(this.TxtDiscard_AuditID, 2, 1);
            this.TlpDiscard.Controls.Add(this.LblDiscard_AnnotationText, 1, 2);
            this.TlpDiscard.Controls.Add(this.TxtDiscard_AnnotationText, 2, 2);
            this.TlpDiscard.Controls.Add(this.BtnDiscard, 2, 3);
            this.TlpDiscard.Controls.Add(this.LblDiscard_Result, 1, 4);
            this.TlpDiscard.Controls.Add(this.TxtDiscard_Result, 2, 4);
            this.TlpDiscard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpDiscard.Location = new System.Drawing.Point(3, 3);
            this.TlpDiscard.Name = "TlpDiscard";
            this.TlpDiscard.RowCount = 6;
            this.TlpDiscard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDiscard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDiscard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDiscard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDiscard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDiscard.Size = new System.Drawing.Size(898, 546);
            this.TlpDiscard.TabIndex = 0;
            // 
            // LblDiscard_AuditID
            // 
            this.LblDiscard_AuditID.AutoSize = true;
            this.LblDiscard_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDiscard_AuditID.Location = new System.Drawing.Point(23, 23);
            this.LblDiscard_AuditID.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscard_AuditID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblDiscard_AuditID.Name = "LblDiscard_AuditID";
            this.LblDiscard_AuditID.Size = new System.Drawing.Size(140, 20);
            this.LblDiscard_AuditID.TabIndex = 0;
            this.LblDiscard_AuditID.Text = "Audit ID (GUID):";
            this.LblDiscard_AuditID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDiscard_AuditID
            // 
            this.TxtDiscard_AuditID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDiscard_AuditID.Location = new System.Drawing.Point(169, 23);
            this.TxtDiscard_AuditID.Name = "TxtDiscard_AuditID";
            this.TxtDiscard_AuditID.Size = new System.Drawing.Size(706, 20);
            this.TxtDiscard_AuditID.TabIndex = 1;
            // 
            // LblDiscard_AnnotationText
            // 
            this.LblDiscard_AnnotationText.AutoSize = true;
            this.LblDiscard_AnnotationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDiscard_AnnotationText.Location = new System.Drawing.Point(23, 49);
            this.LblDiscard_AnnotationText.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscard_AnnotationText.Name = "LblDiscard_AnnotationText";
            this.LblDiscard_AnnotationText.Size = new System.Drawing.Size(140, 20);
            this.LblDiscard_AnnotationText.TabIndex = 2;
            this.LblDiscard_AnnotationText.Text = "Annotation Text:";
            this.LblDiscard_AnnotationText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDiscard_AnnotationText
            // 
            this.TxtDiscard_AnnotationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDiscard_AnnotationText.Location = new System.Drawing.Point(169, 49);
            this.TxtDiscard_AnnotationText.Name = "TxtDiscard_AnnotationText";
            this.TxtDiscard_AnnotationText.Size = new System.Drawing.Size(706, 20);
            this.TxtDiscard_AnnotationText.TabIndex = 3;
            // 
            // BtnDiscard
            // 
            this.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDiscard.Location = new System.Drawing.Point(169, 75);
            this.BtnDiscard.Name = "BtnDiscard";
            this.BtnDiscard.Size = new System.Drawing.Size(706, 23);
            this.BtnDiscard.TabIndex = 4;
            this.BtnDiscard.Text = "Audits.Discard";
            this.BtnDiscard.UseVisualStyleBackColor = true;
            this.BtnDiscard.Click += new System.EventHandler(this.BtnDiscard_Click);
            // 
            // LblDiscard_Result
            // 
            this.LblDiscard_Result.AutoSize = true;
            this.LblDiscard_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDiscard_Result.Location = new System.Drawing.Point(23, 104);
            this.LblDiscard_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscard_Result.Name = "LblDiscard_Result";
            this.LblDiscard_Result.Size = new System.Drawing.Size(140, 20);
            this.LblDiscard_Result.TabIndex = 5;
            this.LblDiscard_Result.Text = "Result:";
            this.LblDiscard_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDiscard_Result
            // 
            this.TxtDiscard_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDiscard_Result.Location = new System.Drawing.Point(169, 104);
            this.TxtDiscard_Result.Name = "TxtDiscard_Result";
            this.TxtDiscard_Result.ReadOnly = true;
            this.TxtDiscard_Result.Size = new System.Drawing.Size(706, 20);
            this.TxtDiscard_Result.TabIndex = 6;
            // 
            // TpgDiscardMultiple
            // 
            this.TpgDiscardMultiple.Controls.Add(this.TlpDiscardMultiple);
            this.TpgDiscardMultiple.Location = new System.Drawing.Point(4, 29);
            this.TpgDiscardMultiple.Name = "TpgDiscardMultiple";
            this.TpgDiscardMultiple.Padding = new System.Windows.Forms.Padding(3);
            this.TpgDiscardMultiple.Size = new System.Drawing.Size(904, 552);
            this.TpgDiscardMultiple.TabIndex = 7;
            this.TpgDiscardMultiple.Text = "DiscardMultiple";
            this.TpgDiscardMultiple.UseVisualStyleBackColor = true;
            // 
            // TlpDiscardMultiple
            // 
            this.TlpDiscardMultiple.ColumnCount = 4;
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscardMultiple.Controls.Add(this.LblDiscardMultiple_Params, 1, 1);
            this.TlpDiscardMultiple.Controls.Add(this.DgvDiscardMultiple_Params, 2, 1);
            this.TlpDiscardMultiple.Controls.Add(this.BtnDiscardMultiple, 2, 2);
            this.TlpDiscardMultiple.Controls.Add(this.LblDiscardMultiple_Result, 1, 3);
            this.TlpDiscardMultiple.Controls.Add(this.TxtDiscardMultiple_Result, 2, 3);
            this.TlpDiscardMultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpDiscardMultiple.Location = new System.Drawing.Point(3, 3);
            this.TlpDiscardMultiple.Name = "TlpDiscardMultiple";
            this.TlpDiscardMultiple.RowCount = 5;
            this.TlpDiscardMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscardMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TlpDiscardMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDiscardMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDiscardMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDiscardMultiple.Size = new System.Drawing.Size(898, 546);
            this.TlpDiscardMultiple.TabIndex = 0;
            // 
            // LblDiscardMultiple_Params
            // 
            this.LblDiscardMultiple_Params.AutoSize = true;
            this.LblDiscardMultiple_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDiscardMultiple_Params.Location = new System.Drawing.Point(23, 23);
            this.LblDiscardMultiple_Params.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscardMultiple_Params.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblDiscardMultiple_Params.Name = "LblDiscardMultiple_Params";
            this.LblDiscardMultiple_Params.Size = new System.Drawing.Size(140, 94);
            this.LblDiscardMultiple_Params.TabIndex = 0;
            this.LblDiscardMultiple_Params.Text = "Parameters:";
            this.LblDiscardMultiple_Params.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvDiscardMultiple_Params
            // 
            this.DgvDiscardMultiple_Params.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDiscardMultiple_Params.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvDiscardMultiple_AuditID,
            this.DgvDiscardMultiple_AnnotationText});
            this.DgvDiscardMultiple_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDiscardMultiple_Params.Location = new System.Drawing.Point(169, 23);
            this.DgvDiscardMultiple_Params.Name = "DgvDiscardMultiple_Params";
            this.DgvDiscardMultiple_Params.Size = new System.Drawing.Size(706, 94);
            this.DgvDiscardMultiple_Params.TabIndex = 1;
            // 
            // DgvDiscardMultiple_AuditID
            // 
            this.DgvDiscardMultiple_AuditID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvDiscardMultiple_AuditID.HeaderText = "Audit ID (GUID)";
            this.DgvDiscardMultiple_AuditID.MinimumWidth = 140;
            this.DgvDiscardMultiple_AuditID.Name = "DgvDiscardMultiple_AuditID";
            this.DgvDiscardMultiple_AuditID.Width = 140;
            // 
            // DgvDiscardMultiple_AnnotationText
            // 
            this.DgvDiscardMultiple_AnnotationText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvDiscardMultiple_AnnotationText.HeaderText = "Annotation Text";
            this.DgvDiscardMultiple_AnnotationText.Name = "DgvDiscardMultiple_AnnotationText";
            // 
            // BtnDiscardMultiple
            // 
            this.BtnDiscardMultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDiscardMultiple.Location = new System.Drawing.Point(169, 123);
            this.BtnDiscardMultiple.Name = "BtnDiscardMultiple";
            this.BtnDiscardMultiple.Size = new System.Drawing.Size(706, 23);
            this.BtnDiscardMultiple.TabIndex = 2;
            this.BtnDiscardMultiple.Text = "Audits.DiscardMultiple";
            this.BtnDiscardMultiple.UseVisualStyleBackColor = true;
            this.BtnDiscardMultiple.Click += new System.EventHandler(this.BtnDiscardMultiple_Click);
            // 
            // LblDiscardMultiple_Result
            // 
            this.LblDiscardMultiple_Result.AutoSize = true;
            this.LblDiscardMultiple_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDiscardMultiple_Result.Location = new System.Drawing.Point(23, 152);
            this.LblDiscardMultiple_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscardMultiple_Result.Name = "LblDiscardMultiple_Result";
            this.LblDiscardMultiple_Result.Size = new System.Drawing.Size(140, 20);
            this.LblDiscardMultiple_Result.TabIndex = 3;
            this.LblDiscardMultiple_Result.Text = "Result:";
            this.LblDiscardMultiple_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDiscardMultiple_Result
            // 
            this.TxtDiscardMultiple_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDiscardMultiple_Result.Location = new System.Drawing.Point(169, 152);
            this.TxtDiscardMultiple_Result.Name = "TxtDiscardMultiple_Result";
            this.TxtDiscardMultiple_Result.ReadOnly = true;
            this.TxtDiscardMultiple_Result.Size = new System.Drawing.Size(706, 20);
            this.TxtDiscardMultiple_Result.TabIndex = 4;
            // 
            // Audits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 609);
            this.Controls.Add(this.TabMain);
            this.Name = "Audits";
            this.Text = "Audits";
            this.TabMain.ResumeLayout(false);
            this.TpgGet.ResumeLayout(false);
            this.TlpGet.ResumeLayout(false);
            this.TlpGet.PerformLayout();
            this.TlpGet_Filters.ResumeLayout(false);
            this.TlpGet_Filters.PerformLayout();
            this.TlpGet_OriginApplication.ResumeLayout(false);
            this.TlpGet_OriginApplication.PerformLayout();
            this.TlpGet_ActionTypes.ResumeLayout(false);
            this.TlpGet_ActionTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGet)).EndInit();
            this.TpgFindById.ResumeLayout(false);
            this.TlpFindById.ResumeLayout(false);
            this.TlpFindById.PerformLayout();
            this.TpgGetForObject.ResumeLayout(false);
            this.TlpGetForObject.ResumeLayout(false);
            this.TlpGetForObject.PerformLayout();
            this.TlpGetForObject_Filters.ResumeLayout(false);
            this.TlpGetForObject_Filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetForObject)).EndInit();
            this.TpgGetAnnotations.ResumeLayout(false);
            this.TlpGetAnnotations.ResumeLayout(false);
            this.TlpGetAnnotations.PerformLayout();
            this.TpgAddAnnotation.ResumeLayout(false);
            this.TlpAddAnnotation.ResumeLayout(false);
            this.TlpAddAnnotation.PerformLayout();
            this.TpgAddAnnotationMultiple.ResumeLayout(false);
            this.AddAnnotationMultiple.ResumeLayout(false);
            this.AddAnnotationMultiple.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAddAnnotationMultiple_Params)).EndInit();
            this.TpgDiscard.ResumeLayout(false);
            this.TlpDiscard.ResumeLayout(false);
            this.TlpDiscard.PerformLayout();
            this.TpgDiscardMultiple.ResumeLayout(false);
            this.TlpDiscardMultiple.ResumeLayout(false);
            this.TlpDiscardMultiple.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDiscardMultiple_Params)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGet;
        private System.Windows.Forms.TabPage TpgFindById;
        private System.Windows.Forms.TableLayoutPanel TlpGet;
        private System.Windows.Forms.Label LblGet_Filters;
        private System.Windows.Forms.TableLayoutPanel TlpGet_Filters;
        private System.Windows.Forms.Label LblGet_StartTime;
        private System.Windows.Forms.Label LblGet_EndTime;
        private System.Windows.Forms.DateTimePicker DtpGet_StartTime;
        private System.Windows.Forms.DateTimePicker DtpGet_EndTime;
        private System.Windows.Forms.CheckBox ChkGet_ExcludeDiscarded;
        private System.Windows.Forms.Label LblGet_OriginApplication;
        private System.Windows.Forms.TableLayoutPanel TlpGet_OriginApplication;
        private System.Windows.Forms.CheckBox ChkGet_AlarmEvent;
        private System.Windows.Forms.CheckBox ChkGet_AuditTrails;
        private System.Windows.Forms.CheckBox ChkGet_DeviceServices;
        private System.Windows.Forms.CheckBox ChkGet_MCE;
        private System.Windows.Forms.CheckBox ChkGet_SiteServices;
        private System.Windows.Forms.Label LblGet_ActionTypes;
        private System.Windows.Forms.TableLayoutPanel TlpGet_ActionTypes;
        private System.Windows.Forms.CheckBox ChkGet_Write;
        private System.Windows.Forms.CheckBox ChkGet_Command;
        private System.Windows.Forms.CheckBox ChkGet_Create;
        private System.Windows.Forms.CheckBox ChkGet_Delete;
        private System.Windows.Forms.CheckBox ChkGet_Error;
        private System.Windows.Forms.CheckBox ChkGet_Subsystem;
        private System.Windows.Forms.CheckBox ChkGet_NoFilters;
        private System.Windows.Forms.Button BtnGet;
        private System.Windows.Forms.DataGridView DgvGet;
        private System.Windows.Forms.TableLayoutPanel TlpFindById;
        private System.Windows.Forms.Label LblFindById_AuditID;
        private System.Windows.Forms.TextBox TxtFindById_AuditID;
        private System.Windows.Forms.Button BtnFindById;
        private System.Windows.Forms.PropertyGrid PrgFindById;
        private System.Windows.Forms.TabPage TpgGetForObject;
        private System.Windows.Forms.TableLayoutPanel TlpGetForObject;
        private System.Windows.Forms.Label LblGetForObject_ObjectID;
        private System.Windows.Forms.TextBox TxtGetForObject_ObjectID;
        private System.Windows.Forms.Label LblGetForObject_Filters;
        private System.Windows.Forms.TableLayoutPanel TlpGetForObject_Filters;
        private System.Windows.Forms.CheckBox ChkGetForObject_NoFilters;
        private System.Windows.Forms.Label LblGetForObject_StartTime;
        private System.Windows.Forms.DateTimePicker DtpGetForObject_StartTime;
        private System.Windows.Forms.Label LblGetForObject_EndTime;
        private System.Windows.Forms.DateTimePicker DtpGetForObject_EndTime;
        private System.Windows.Forms.CheckBox ChGetForObject_ExcludeDiscarded;
        private System.Windows.Forms.Button BtnGetForObject;
        private System.Windows.Forms.DataGridView DgvGetForObject;
        private System.Windows.Forms.TabPage TpgGetAnnotations;
        private System.Windows.Forms.TableLayoutPanel TlpGetAnnotations;
        private System.Windows.Forms.Label LblGetAnnotations_AuditID;
        private System.Windows.Forms.TextBox TxtGetAnnotations_AuditID;
        private System.Windows.Forms.Button BtnGetAnnotations;
        private System.Windows.Forms.TextBox TxtGetAnnotations_Result;
        private System.Windows.Forms.TabPage TpgAddAnnotation;
        private System.Windows.Forms.TableLayoutPanel TlpAddAnnotation;
        private System.Windows.Forms.Label LblAddAnnotation_AuditID;
        private System.Windows.Forms.TextBox TxtAddAnnotation_AuditID;
        private System.Windows.Forms.Label LblAddAnnotations_AnnotationText;
        private System.Windows.Forms.TextBox TxtAddAnnotations_AnnotationText;
        private System.Windows.Forms.Button BtnAddAnnotation;
        private System.Windows.Forms.TextBox TxtAddAnnotation_Result;
        private System.Windows.Forms.TabPage TpgAddAnnotationMultiple;
        private System.Windows.Forms.TableLayoutPanel AddAnnotationMultiple;
        private System.Windows.Forms.DataGridView DgvAddAnnotationMultiple_Params;
        private System.Windows.Forms.Label LblAddAnnotationMultiple_Params;
        private System.Windows.Forms.Button BtnAddAnnotationMultiple;
        private System.Windows.Forms.Label LblAddAnnotationMultiple_Result;
        private System.Windows.Forms.TextBox TxtAddAnnotationMultiple_Result;
        private System.Windows.Forms.TabPage TpgDiscard;
        private System.Windows.Forms.TableLayoutPanel TlpDiscard;
        private System.Windows.Forms.Label LblDiscard_AuditID;
        private System.Windows.Forms.TextBox TxtDiscard_AuditID;
        private System.Windows.Forms.Label LblDiscard_AnnotationText;
        private System.Windows.Forms.TextBox TxtDiscard_AnnotationText;
        private System.Windows.Forms.Button BtnDiscard;
        private System.Windows.Forms.Label LblDiscard_Result;
        private System.Windows.Forms.TextBox TxtDiscard_Result;
        private System.Windows.Forms.TabPage TpgDiscardMultiple;
        private System.Windows.Forms.TableLayoutPanel TlpDiscardMultiple;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvAddAnnotationMultiple_AuditID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvAddAnnotationMultiple_AnnotationText;
        private System.Windows.Forms.Label LblDiscardMultiple_Params;
        private System.Windows.Forms.DataGridView DgvDiscardMultiple_Params;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvDiscardMultiple_AuditID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvDiscardMultiple_AnnotationText;
        private System.Windows.Forms.Button BtnDiscardMultiple;
        private System.Windows.Forms.Label LblDiscardMultiple_Result;
        private System.Windows.Forms.TextBox TxtDiscardMultiple_Result;
    }
}