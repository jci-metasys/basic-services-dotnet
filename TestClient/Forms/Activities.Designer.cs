
namespace MetasysServices_TestClient.Forms
{
    partial class Activities
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
            this.ChkGet_IncludeDiscarded = new System.Windows.Forms.CheckBox();
            this.LblGet_OriginApplication = new System.Windows.Forms.Label();
            this.TlpGet_SelOriginApp = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGet_SelOriginApp = new System.Windows.Forms.Button();
            this.TxtGet_SelOriginApp = new System.Windows.Forms.TextBox();
            this.TlpGet_SelType = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGet_SelType = new System.Windows.Forms.Button();
            this.TxtGet_SelType = new System.Windows.Forms.TextBox();
            this.CmbGet_ActivityType = new System.Windows.Forms.ComboBox();
            this.LblGet_ActivityType = new System.Windows.Forms.Label();
            this.ChkGet_IncludeAcknowledged = new System.Windows.Forms.CheckBox();
            this.ChkGet_IncludeAcknowledmentRequired = new System.Windows.Forms.CheckBox();
            this.ChkGet_IncludeAcknowledgementNotRequired = new System.Windows.Forms.CheckBox();
            this.LblGet_Sort = new System.Windows.Forms.Label();
            this.CmbGet_Sort = new System.Windows.Forms.ComboBox();
            this.LblGet_Type = new System.Windows.Forms.Label();
            this.ChkGet_NoFilters = new System.Windows.Forms.CheckBox();
            this.BtnGet = new System.Windows.Forms.Button();
            this.DgvGet = new System.Windows.Forms.DataGridView();
            this.LblGet_Title = new System.Windows.Forms.Label();
            this.TpgBatch = new System.Windows.Forms.TabPage();
            this.TlpDiscardMultiple = new System.Windows.Forms.TableLayoutPanel();
            this.LblDiscardMultiple_Params = new System.Windows.Forms.Label();
            this.DgvActionMultiple_Params = new System.Windows.Forms.DataGridView();
            this.BtnActionMultiple = new System.Windows.Forms.Button();
            this.LblDiscardMultiple_Result = new System.Windows.Forms.Label();
            this.TxtActionMultiple_Result = new System.Windows.Forms.TextBox();
            this.LblDiscardMultuiple_Title = new System.Windows.Forms.Label();
            this.DgvActionMultiple_ActivityType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgvActionMultiple_ActivityManagementStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgvActionMultiple_ObjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvActionMultiple_Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabMain.SuspendLayout();
            this.TpgGet.SuspendLayout();
            this.TlpGet.SuspendLayout();
            this.TlpGet_Filters.SuspendLayout();
            this.TlpGet_SelOriginApp.SuspendLayout();
            this.TlpGet_SelType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGet)).BeginInit();
            this.TpgBatch.SuspendLayout();
            this.TlpDiscardMultiple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActionMultiple_Params)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGet);
            this.TabMain.Controls.Add(this.TpgBatch);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(912, 585);
            this.TabMain.TabIndex = 1;
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
            this.TlpGet.Controls.Add(this.LblGet_Title, 0, 0);
            this.TlpGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet.Location = new System.Drawing.Point(3, 3);
            this.TlpGet.Name = "TlpGet";
            this.TlpGet.RowCount = 4;
            this.TlpGet.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.LblGet_Filters.Location = new System.Drawing.Point(23, 25);
            this.LblGet_Filters.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_Filters.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGet_Filters.Name = "LblGet_Filters";
            this.LblGet_Filters.Size = new System.Drawing.Size(140, 125);
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
            this.TlpGet_Filters.Controls.Add(this.LblGet_StartTime, 0, 1);
            this.TlpGet_Filters.Controls.Add(this.LblGet_EndTime, 2, 1);
            this.TlpGet_Filters.Controls.Add(this.DtpGet_StartTime, 1, 1);
            this.TlpGet_Filters.Controls.Add(this.DtpGet_EndTime, 3, 1);
            this.TlpGet_Filters.Controls.Add(this.ChkGet_IncludeDiscarded, 1, 2);
            this.TlpGet_Filters.Controls.Add(this.LblGet_OriginApplication, 0, 4);
            this.TlpGet_Filters.Controls.Add(this.TlpGet_SelOriginApp, 1, 4);
            this.TlpGet_Filters.Controls.Add(this.TlpGet_SelType, 3, 4);
            this.TlpGet_Filters.Controls.Add(this.CmbGet_ActivityType, 1, 0);
            this.TlpGet_Filters.Controls.Add(this.LblGet_ActivityType, 0, 0);
            this.TlpGet_Filters.Controls.Add(this.ChkGet_IncludeAcknowledged, 3, 2);
            this.TlpGet_Filters.Controls.Add(this.ChkGet_IncludeAcknowledmentRequired, 1, 3);
            this.TlpGet_Filters.Controls.Add(this.ChkGet_IncludeAcknowledgementNotRequired, 3, 3);
            this.TlpGet_Filters.Controls.Add(this.LblGet_Sort, 2, 0);
            this.TlpGet_Filters.Controls.Add(this.CmbGet_Sort, 3, 0);
            this.TlpGet_Filters.Controls.Add(this.LblGet_Type, 2, 4);
            this.TlpGet_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet_Filters.Location = new System.Drawing.Point(169, 25);
            this.TlpGet_Filters.Name = "TlpGet_Filters";
            this.TlpGet_Filters.RowCount = 5;
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGet_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGet_Filters.Size = new System.Drawing.Size(630, 125);
            this.TlpGet_Filters.TabIndex = 1;
            // 
            // LblGet_StartTime
            // 
            this.LblGet_StartTime.AutoSize = true;
            this.LblGet_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_StartTime.Location = new System.Drawing.Point(3, 30);
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
            this.LblGet_EndTime.Location = new System.Drawing.Point(336, 30);
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
            this.DtpGet_StartTime.Location = new System.Drawing.Point(98, 30);
            this.DtpGet_StartTime.Name = "DtpGet_StartTime";
            this.DtpGet_StartTime.Size = new System.Drawing.Size(232, 20);
            this.DtpGet_StartTime.TabIndex = 2;
            // 
            // DtpGet_EndTime
            // 
            this.DtpGet_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGet_EndTime.Location = new System.Drawing.Point(394, 30);
            this.DtpGet_EndTime.Name = "DtpGet_EndTime";
            this.DtpGet_EndTime.Size = new System.Drawing.Size(233, 20);
            this.DtpGet_EndTime.TabIndex = 3;
            // 
            // ChkGet_IncludeDiscarded
            // 
            this.ChkGet_IncludeDiscarded.AutoSize = true;
            this.ChkGet_IncludeDiscarded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_IncludeDiscarded.Location = new System.Drawing.Point(98, 56);
            this.ChkGet_IncludeDiscarded.Name = "ChkGet_IncludeDiscarded";
            this.ChkGet_IncludeDiscarded.Size = new System.Drawing.Size(232, 17);
            this.ChkGet_IncludeDiscarded.TabIndex = 4;
            this.ChkGet_IncludeDiscarded.Text = "Include Discarded";
            this.ChkGet_IncludeDiscarded.UseVisualStyleBackColor = true;
            // 
            // LblGet_OriginApplication
            // 
            this.LblGet_OriginApplication.AutoSize = true;
            this.LblGet_OriginApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_OriginApplication.Location = new System.Drawing.Point(3, 102);
            this.LblGet_OriginApplication.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_OriginApplication.Name = "LblGet_OriginApplication";
            this.LblGet_OriginApplication.Size = new System.Drawing.Size(89, 20);
            this.LblGet_OriginApplication.TabIndex = 6;
            this.LblGet_OriginApplication.Text = "Origin Application";
            this.LblGet_OriginApplication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TlpGet_SelOriginApp
            // 
            this.TlpGet_SelOriginApp.ColumnCount = 2;
            this.TlpGet_SelOriginApp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet_SelOriginApp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_SelOriginApp.Controls.Add(this.BtnGet_SelOriginApp, 1, 0);
            this.TlpGet_SelOriginApp.Controls.Add(this.TxtGet_SelOriginApp, 0, 0);
            this.TlpGet_SelOriginApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet_SelOriginApp.Location = new System.Drawing.Point(95, 99);
            this.TlpGet_SelOriginApp.Margin = new System.Windows.Forms.Padding(0);
            this.TlpGet_SelOriginApp.Name = "TlpGet_SelOriginApp";
            this.TlpGet_SelOriginApp.RowCount = 1;
            this.TlpGet_SelOriginApp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet_SelOriginApp.Size = new System.Drawing.Size(238, 26);
            this.TlpGet_SelOriginApp.TabIndex = 6;
            // 
            // BtnGet_SelOriginApp
            // 
            this.BtnGet_SelOriginApp.AutoEllipsis = true;
            this.BtnGet_SelOriginApp.Location = new System.Drawing.Point(205, 3);
            this.BtnGet_SelOriginApp.Name = "BtnGet_SelOriginApp";
            this.BtnGet_SelOriginApp.Size = new System.Drawing.Size(30, 20);
            this.BtnGet_SelOriginApp.TabIndex = 0;
            this.BtnGet_SelOriginApp.Text = " Select Origin Application";
            this.BtnGet_SelOriginApp.UseVisualStyleBackColor = true;
            this.BtnGet_SelOriginApp.Click += new System.EventHandler(this.BtnGet_SelOriginApp_Click);
            // 
            // TxtGet_SelOriginApp
            // 
            this.TxtGet_SelOriginApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGet_SelOriginApp.Location = new System.Drawing.Point(3, 3);
            this.TxtGet_SelOriginApp.Name = "TxtGet_SelOriginApp";
            this.TxtGet_SelOriginApp.ReadOnly = true;
            this.TxtGet_SelOriginApp.Size = new System.Drawing.Size(196, 20);
            this.TxtGet_SelOriginApp.TabIndex = 1;
            // 
            // TlpGet_SelType
            // 
            this.TlpGet_SelType.AutoSize = true;
            this.TlpGet_SelType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpGet_SelType.ColumnCount = 2;
            this.TlpGet_SelType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet_SelType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGet_SelType.Controls.Add(this.BtnGet_SelType, 1, 0);
            this.TlpGet_SelType.Controls.Add(this.TxtGet_SelType, 0, 0);
            this.TlpGet_SelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGet_SelType.Location = new System.Drawing.Point(391, 99);
            this.TlpGet_SelType.Margin = new System.Windows.Forms.Padding(0);
            this.TlpGet_SelType.Name = "TlpGet_SelType";
            this.TlpGet_SelType.RowCount = 1;
            this.TlpGet_SelType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGet_SelType.Size = new System.Drawing.Size(239, 26);
            this.TlpGet_SelType.TabIndex = 6;
            // 
            // BtnGet_SelType
            // 
            this.BtnGet_SelType.AutoEllipsis = true;
            this.BtnGet_SelType.Location = new System.Drawing.Point(206, 3);
            this.BtnGet_SelType.Name = "BtnGet_SelType";
            this.BtnGet_SelType.Size = new System.Drawing.Size(30, 20);
            this.BtnGet_SelType.TabIndex = 19;
            this.BtnGet_SelType.Text = " Select Type";
            this.BtnGet_SelType.UseVisualStyleBackColor = true;
            this.BtnGet_SelType.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtGet_SelType
            // 
            this.TxtGet_SelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGet_SelType.Location = new System.Drawing.Point(3, 3);
            this.TxtGet_SelType.Name = "TxtGet_SelType";
            this.TxtGet_SelType.ReadOnly = true;
            this.TxtGet_SelType.Size = new System.Drawing.Size(197, 20);
            this.TxtGet_SelType.TabIndex = 20;
            // 
            // CmbGet_ActivityType
            // 
            this.CmbGet_ActivityType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbGet_ActivityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGet_ActivityType.FormattingEnabled = true;
            this.CmbGet_ActivityType.Items.AddRange(new object[] {
            "alarm",
            "audit"});
            this.CmbGet_ActivityType.Location = new System.Drawing.Point(98, 3);
            this.CmbGet_ActivityType.Name = "CmbGet_ActivityType";
            this.CmbGet_ActivityType.Size = new System.Drawing.Size(232, 21);
            this.CmbGet_ActivityType.TabIndex = 9;
            // 
            // LblGet_ActivityType
            // 
            this.LblGet_ActivityType.AutoSize = true;
            this.LblGet_ActivityType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_ActivityType.Location = new System.Drawing.Point(3, 3);
            this.LblGet_ActivityType.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_ActivityType.Name = "LblGet_ActivityType";
            this.LblGet_ActivityType.Size = new System.Drawing.Size(89, 21);
            this.LblGet_ActivityType.TabIndex = 10;
            this.LblGet_ActivityType.Text = "Activity Type";
            this.LblGet_ActivityType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChkGet_IncludeAcknowledged
            // 
            this.ChkGet_IncludeAcknowledged.AutoSize = true;
            this.ChkGet_IncludeAcknowledged.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_IncludeAcknowledged.Location = new System.Drawing.Point(394, 56);
            this.ChkGet_IncludeAcknowledged.Name = "ChkGet_IncludeAcknowledged";
            this.ChkGet_IncludeAcknowledged.Size = new System.Drawing.Size(233, 17);
            this.ChkGet_IncludeAcknowledged.TabIndex = 11;
            this.ChkGet_IncludeAcknowledged.Text = "Include Acknowledged";
            this.ChkGet_IncludeAcknowledged.UseVisualStyleBackColor = true;
            // 
            // ChkGet_IncludeAcknowledmentRequired
            // 
            this.ChkGet_IncludeAcknowledmentRequired.AutoSize = true;
            this.ChkGet_IncludeAcknowledmentRequired.Location = new System.Drawing.Point(98, 79);
            this.ChkGet_IncludeAcknowledmentRequired.Name = "ChkGet_IncludeAcknowledmentRequired";
            this.ChkGet_IncludeAcknowledmentRequired.Size = new System.Drawing.Size(192, 17);
            this.ChkGet_IncludeAcknowledmentRequired.TabIndex = 13;
            this.ChkGet_IncludeAcknowledmentRequired.Text = "Include Acknowledgment Required";
            this.ChkGet_IncludeAcknowledmentRequired.UseVisualStyleBackColor = true;
            // 
            // ChkGet_IncludeAcknowledgementNotRequired
            // 
            this.ChkGet_IncludeAcknowledgementNotRequired.AutoSize = true;
            this.ChkGet_IncludeAcknowledgementNotRequired.Location = new System.Drawing.Point(394, 79);
            this.ChkGet_IncludeAcknowledgementNotRequired.Name = "ChkGet_IncludeAcknowledgementNotRequired";
            this.ChkGet_IncludeAcknowledgementNotRequired.Size = new System.Drawing.Size(212, 17);
            this.ChkGet_IncludeAcknowledgementNotRequired.TabIndex = 14;
            this.ChkGet_IncludeAcknowledgementNotRequired.Text = "Include Acknowledgment Not Required";
            this.ChkGet_IncludeAcknowledgementNotRequired.UseVisualStyleBackColor = true;
            // 
            // LblGet_Sort
            // 
            this.LblGet_Sort.AutoSize = true;
            this.LblGet_Sort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_Sort.Location = new System.Drawing.Point(336, 3);
            this.LblGet_Sort.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_Sort.Name = "LblGet_Sort";
            this.LblGet_Sort.Size = new System.Drawing.Size(52, 21);
            this.LblGet_Sort.TabIndex = 15;
            this.LblGet_Sort.Text = "Sort";
            this.LblGet_Sort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbGet_Sort
            // 
            this.CmbGet_Sort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbGet_Sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGet_Sort.FormattingEnabled = true;
            this.CmbGet_Sort.Items.AddRange(new object[] {
            "creationTime",
            "-creationTime",
            "priority",
            "-priority"});
            this.CmbGet_Sort.Location = new System.Drawing.Point(394, 3);
            this.CmbGet_Sort.Name = "CmbGet_Sort";
            this.CmbGet_Sort.Size = new System.Drawing.Size(233, 21);
            this.CmbGet_Sort.TabIndex = 16;
            // 
            // LblGet_Type
            // 
            this.LblGet_Type.AutoSize = true;
            this.LblGet_Type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_Type.Location = new System.Drawing.Point(336, 102);
            this.LblGet_Type.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_Type.Name = "LblGet_Type";
            this.LblGet_Type.Size = new System.Drawing.Size(52, 20);
            this.LblGet_Type.TabIndex = 17;
            this.LblGet_Type.Text = "Type";
            this.LblGet_Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChkGet_NoFilters
            // 
            this.ChkGet_NoFilters.AutoSize = true;
            this.ChkGet_NoFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGet_NoFilters.Location = new System.Drawing.Point(805, 25);
            this.ChkGet_NoFilters.Name = "ChkGet_NoFilters";
            this.ChkGet_NoFilters.Size = new System.Drawing.Size(70, 125);
            this.ChkGet_NoFilters.TabIndex = 2;
            this.ChkGet_NoFilters.Text = "No Filters";
            this.ChkGet_NoFilters.UseVisualStyleBackColor = true;
            // 
            // BtnGet
            // 
            this.TlpGet.SetColumnSpan(this.BtnGet, 2);
            this.BtnGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGet.Location = new System.Drawing.Point(169, 156);
            this.BtnGet.Name = "BtnGet";
            this.BtnGet.Size = new System.Drawing.Size(706, 23);
            this.BtnGet.TabIndex = 3;
            this.BtnGet.Text = "Activities.Get";
            this.BtnGet.UseVisualStyleBackColor = true;
            this.BtnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // DgvGet
            // 
            this.DgvGet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TlpGet.SetColumnSpan(this.DgvGet, 2);
            this.DgvGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGet.Location = new System.Drawing.Point(169, 185);
            this.DgvGet.Name = "DgvGet";
            this.DgvGet.Size = new System.Drawing.Size(706, 358);
            this.DgvGet.TabIndex = 4;
            // 
            // LblGet_Title
            // 
            this.LblGet_Title.AutoSize = true;
            this.TlpGet.SetColumnSpan(this.LblGet_Title, 4);
            this.LblGet_Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblGet_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGet_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGet_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGet_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_Title.Name = "LblGet_Title";
            this.LblGet_Title.Size = new System.Drawing.Size(872, 16);
            this.LblGet_Title.TabIndex = 5;
            this.LblGet_Title.Text = "Retrieves a collection of activities.";
            this.LblGet_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TpgBatch
            // 
            this.TpgBatch.Controls.Add(this.TlpDiscardMultiple);
            this.TpgBatch.Location = new System.Drawing.Point(4, 29);
            this.TpgBatch.Name = "TpgBatch";
            this.TpgBatch.Padding = new System.Windows.Forms.Padding(3);
            this.TpgBatch.Size = new System.Drawing.Size(904, 552);
            this.TpgBatch.TabIndex = 7;
            this.TpgBatch.Text = "Action Multiple";
            this.TpgBatch.UseVisualStyleBackColor = true;
            // 
            // TlpDiscardMultiple
            // 
            this.TlpDiscardMultiple.ColumnCount = 4;
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDiscardMultiple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDiscardMultiple.Controls.Add(this.LblDiscardMultiple_Params, 1, 1);
            this.TlpDiscardMultiple.Controls.Add(this.DgvActionMultiple_Params, 2, 1);
            this.TlpDiscardMultiple.Controls.Add(this.BtnActionMultiple, 2, 2);
            this.TlpDiscardMultiple.Controls.Add(this.LblDiscardMultiple_Result, 1, 3);
            this.TlpDiscardMultiple.Controls.Add(this.TxtActionMultiple_Result, 2, 3);
            this.TlpDiscardMultiple.Controls.Add(this.LblDiscardMultuiple_Title, 0, 0);
            this.TlpDiscardMultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpDiscardMultiple.Location = new System.Drawing.Point(3, 3);
            this.TlpDiscardMultiple.Name = "TlpDiscardMultiple";
            this.TlpDiscardMultiple.RowCount = 5;
            this.TlpDiscardMultiple.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.LblDiscardMultiple_Params.Location = new System.Drawing.Point(23, 25);
            this.LblDiscardMultiple_Params.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscardMultiple_Params.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblDiscardMultiple_Params.Name = "LblDiscardMultiple_Params";
            this.LblDiscardMultiple_Params.Size = new System.Drawing.Size(140, 94);
            this.LblDiscardMultiple_Params.TabIndex = 0;
            this.LblDiscardMultiple_Params.Text = "Parameters:";
            this.LblDiscardMultiple_Params.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvActionMultiple_Params
            // 
            this.DgvActionMultiple_Params.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActionMultiple_Params.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvActionMultiple_ActivityType,
            this.DgvActionMultiple_ActivityManagementStatus,
            this.DgvActionMultiple_ObjectId,
            this.DgvActionMultiple_Resource});
            this.DgvActionMultiple_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvActionMultiple_Params.Location = new System.Drawing.Point(169, 25);
            this.DgvActionMultiple_Params.Name = "DgvActionMultiple_Params";
            this.DgvActionMultiple_Params.Size = new System.Drawing.Size(706, 94);
            this.DgvActionMultiple_Params.TabIndex = 1;
            // 
            // BtnActionMultiple
            // 
            this.BtnActionMultiple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnActionMultiple.Location = new System.Drawing.Point(169, 125);
            this.BtnActionMultiple.Name = "BtnActionMultiple";
            this.BtnActionMultiple.Size = new System.Drawing.Size(706, 23);
            this.BtnActionMultiple.TabIndex = 2;
            this.BtnActionMultiple.Text = "Activity.ActionMultiple";
            this.BtnActionMultiple.UseVisualStyleBackColor = true;
            this.BtnActionMultiple.Click += new System.EventHandler(this.BtnActionMultiple_Click);
            // 
            // LblDiscardMultiple_Result
            // 
            this.LblDiscardMultiple_Result.AutoSize = true;
            this.LblDiscardMultiple_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDiscardMultiple_Result.Location = new System.Drawing.Point(23, 154);
            this.LblDiscardMultiple_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscardMultiple_Result.Name = "LblDiscardMultiple_Result";
            this.LblDiscardMultiple_Result.Size = new System.Drawing.Size(140, 20);
            this.LblDiscardMultiple_Result.TabIndex = 3;
            this.LblDiscardMultiple_Result.Text = "Result:";
            this.LblDiscardMultiple_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtActionMultiple_Result
            // 
            this.TxtActionMultiple_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtActionMultiple_Result.Location = new System.Drawing.Point(169, 154);
            this.TxtActionMultiple_Result.Name = "TxtActionMultiple_Result";
            this.TxtActionMultiple_Result.ReadOnly = true;
            this.TxtActionMultiple_Result.Size = new System.Drawing.Size(706, 20);
            this.TxtActionMultiple_Result.TabIndex = 4;
            // 
            // LblDiscardMultuiple_Title
            // 
            this.LblDiscardMultuiple_Title.AutoSize = true;
            this.TlpDiscardMultiple.SetColumnSpan(this.LblDiscardMultuiple_Title, 4);
            this.LblDiscardMultuiple_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDiscardMultuiple_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblDiscardMultuiple_Title.Location = new System.Drawing.Point(3, 3);
            this.LblDiscardMultuiple_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblDiscardMultuiple_Title.Name = "LblDiscardMultuiple_Title";
            this.LblDiscardMultuiple_Title.Size = new System.Drawing.Size(265, 16);
            this.LblDiscardMultuiple_Title.TabIndex = 8;
            this.LblDiscardMultuiple_Title.Text = "Allows for performing multiple actions";
            this.LblDiscardMultuiple_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvActionMultiple_ActivityType
            // 
            this.DgvActionMultiple_ActivityType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvActionMultiple_ActivityType.HeaderText = "Activity Type";
            this.DgvActionMultiple_ActivityType.Items.AddRange(new object[] {
            "alarm",
            "audit"});
            this.DgvActionMultiple_ActivityType.MinimumWidth = 100;
            this.DgvActionMultiple_ActivityType.Name = "DgvActionMultiple_ActivityType";
            // 
            // DgvActionMultiple_ActivityManagementStatus
            // 
            this.DgvActionMultiple_ActivityManagementStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvActionMultiple_ActivityManagementStatus.HeaderText = "Activity Mngm Status";
            this.DgvActionMultiple_ActivityManagementStatus.Items.AddRange(new object[] {
            "discarded",
            "acknowledged"});
            this.DgvActionMultiple_ActivityManagementStatus.MinimumWidth = 120;
            this.DgvActionMultiple_ActivityManagementStatus.Name = "DgvActionMultiple_ActivityManagementStatus";
            this.DgvActionMultiple_ActivityManagementStatus.Width = 120;
            // 
            // DgvActionMultiple_ObjectId
            // 
            this.DgvActionMultiple_ObjectId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvActionMultiple_ObjectId.HeaderText = "Object ID (GUID)";
            this.DgvActionMultiple_ObjectId.MinimumWidth = 140;
            this.DgvActionMultiple_ObjectId.Name = "DgvActionMultiple_ObjectId";
            this.DgvActionMultiple_ObjectId.Width = 140;
            // 
            // DgvActionMultiple_Resource
            // 
            this.DgvActionMultiple_Resource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvActionMultiple_Resource.HeaderText = "Annotation Text";
            this.DgvActionMultiple_Resource.Name = "DgvActionMultiple_Resource";
            // 
            // Activities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 626);
            this.Controls.Add(this.TabMain);
            this.Name = "Activities";
            this.Text = "Activities";
            this.TabMain.ResumeLayout(false);
            this.TpgGet.ResumeLayout(false);
            this.TlpGet.ResumeLayout(false);
            this.TlpGet.PerformLayout();
            this.TlpGet_Filters.ResumeLayout(false);
            this.TlpGet_Filters.PerformLayout();
            this.TlpGet_SelOriginApp.ResumeLayout(false);
            this.TlpGet_SelOriginApp.PerformLayout();
            this.TlpGet_SelType.ResumeLayout(false);
            this.TlpGet_SelType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGet)).EndInit();
            this.TpgBatch.ResumeLayout(false);
            this.TlpDiscardMultiple.ResumeLayout(false);
            this.TlpDiscardMultiple.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActionMultiple_Params)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGet;
        private System.Windows.Forms.TableLayoutPanel TlpGet;
        private System.Windows.Forms.Label LblGet_Filters;
        private System.Windows.Forms.TableLayoutPanel TlpGet_Filters;
        private System.Windows.Forms.Label LblGet_StartTime;
        private System.Windows.Forms.Label LblGet_EndTime;
        private System.Windows.Forms.DateTimePicker DtpGet_StartTime;
        private System.Windows.Forms.DateTimePicker DtpGet_EndTime;
        private System.Windows.Forms.CheckBox ChkGet_IncludeDiscarded;
        private System.Windows.Forms.Label LblGet_OriginApplication;
        private System.Windows.Forms.CheckBox ChkGet_NoFilters;
        private System.Windows.Forms.Button BtnGet;
        private System.Windows.Forms.DataGridView DgvGet;
        private System.Windows.Forms.Label LblGet_Title;
        private System.Windows.Forms.TabPage TpgBatch;
        private System.Windows.Forms.TableLayoutPanel TlpDiscardMultiple;
        private System.Windows.Forms.Label LblDiscardMultiple_Params;
        private System.Windows.Forms.DataGridView DgvActionMultiple_Params;
        private System.Windows.Forms.Button BtnActionMultiple;
        private System.Windows.Forms.Label LblDiscardMultiple_Result;
        private System.Windows.Forms.TextBox TxtActionMultiple_Result;
        private System.Windows.Forms.Label LblDiscardMultuiple_Title;
        private System.Windows.Forms.ComboBox CmbGet_ActivityType;
        private System.Windows.Forms.Label LblGet_ActivityType;
        private System.Windows.Forms.CheckBox ChkGet_IncludeAcknowledged;
        private System.Windows.Forms.CheckBox ChkGet_IncludeAcknowledmentRequired;
        private System.Windows.Forms.CheckBox ChkGet_IncludeAcknowledgementNotRequired;
        private System.Windows.Forms.Label LblGet_Sort;
        private System.Windows.Forms.ComboBox CmbGet_Sort;
        private System.Windows.Forms.Label LblGet_Type;
        private System.Windows.Forms.Button BtnGet_SelType;
        private System.Windows.Forms.TableLayoutPanel TlpGet_SelType;
        private System.Windows.Forms.TextBox TxtGet_SelType;
        private System.Windows.Forms.TableLayoutPanel TlpGet_SelOriginApp;
        private System.Windows.Forms.Button BtnGet_SelOriginApp;
        private System.Windows.Forms.TextBox TxtGet_SelOriginApp;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgvActionMultiple_ActivityType;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgvActionMultiple_ActivityManagementStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvActionMultiple_ObjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvActionMultiple_Resource;
    }
}