
namespace MetasysServices_TestClient.Forms
{
    partial class Streams
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
            this.TabMain = new System.Windows.Forms.TabControl();
            this.TpgCOVValue = new System.Windows.Forms.TabPage();
            this.PrgCOVValue = new System.Windows.Forms.PropertyGrid();
            this.DgvCOVValue = new System.Windows.Forms.DataGridView();
            this.TxtCOVValue_RequestID = new System.Windows.Forms.TextBox();
            this.LblCOVValue_RequestID = new System.Windows.Forms.Label();
            this.LblCOVValue_ObjectID = new System.Windows.Forms.Label();
            this.TxtCOVValue_ObjectID = new System.Windows.Forms.TextBox();
            this.BtnCOVValue_GetCOVValues = new System.Windows.Forms.Button();
            this.RtbCOVValue = new System.Windows.Forms.RichTextBox();
            this.BtnCOVValue_StopReadingCOVValue = new System.Windows.Forms.Button();
            this.BtnCOVValue_StartReadingValue = new System.Windows.Forms.Button();
            this.TpgCOVValues = new System.Windows.Forms.TabPage();
            this.TlpCOVvalues = new System.Windows.Forms.TableLayoutPanel();
            this.LblCOVValues_Params = new System.Windows.Forms.Label();
            this.DgvCOVValues = new System.Windows.Forms.DataGridView();
            this.LblCOVValues_RequestID = new System.Windows.Forms.Label();
            this.TxtCOVValues_RequestID = new System.Windows.Forms.TextBox();
            this.DgvCOVValues_Params = new System.Windows.Forms.DataGridView();
            this.DgvCOVValues_Params_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCOVValues_StartReadingCOVValues = new System.Windows.Forms.Button();
            this.BtnCOVValues_StopReadingCOVValues = new System.Windows.Forms.Button();
            this.LblCOVValues_Heartbeat = new System.Windows.Forms.Label();
            this.TxtCOVValues_Heartbeat = new System.Windows.Forms.TextBox();
            this.TpgAlarmEvents = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtAlarmEvents_MaxNumber = new System.Windows.Forms.TextBox();
            this.BtnAlarmEvent_StopCollectingAlarms = new System.Windows.Forms.Button();
            this.DgvAlarmEvents = new System.Windows.Forms.DataGridView();
            this.TxtAlarmEvents_RequestID = new System.Windows.Forms.TextBox();
            this.LblAlarmEvents_RequestID = new System.Windows.Forms.Label();
            this.BtnAlarmEvent_StartCollectingAlarms = new System.Windows.Forms.Button();
            this.TpgAuditEvents = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAuditEvents_MaxNumber = new System.Windows.Forms.TextBox();
            this.BtnAuditEvent_StopCollectingAudits = new System.Windows.Forms.Button();
            this.BtnAuditEvent_StartCollectingAudits = new System.Windows.Forms.Button();
            this.DgvAuditEvents = new System.Windows.Forms.DataGridView();
            this.TxtAuditEvents_RequestID = new System.Windows.Forms.TextBox();
            this.LblAuditEvents_RequestID = new System.Windows.Forms.Label();
            this.TmrRefreshCOVValue = new System.Windows.Forms.Timer(this.components);
            this.BtnCOVValues_KeepAlive = new System.Windows.Forms.Button();
            this.LblCOVValues_StartTime = new System.Windows.Forms.Label();
            this.TxtCOVValues_StartTime = new System.Windows.Forms.TextBox();
            this.TmrStreamCheck = new System.Windows.Forms.Timer(this.components);
            this.TabMain.SuspendLayout();
            this.TpgCOVValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValue)).BeginInit();
            this.TpgCOVValues.SuspendLayout();
            this.TlpCOVvalues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValues_Params)).BeginInit();
            this.TpgAlarmEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarmEvents)).BeginInit();
            this.TpgAuditEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAuditEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgCOVValue);
            this.TabMain.Controls.Add(this.TpgCOVValues);
            this.TabMain.Controls.Add(this.TpgAlarmEvents);
            this.TabMain.Controls.Add(this.TpgAuditEvents);
            this.TabMain.ItemSize = new System.Drawing.Size(84, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(1068, 541);
            this.TabMain.TabIndex = 0;
            // 
            // TpgCOVValue
            // 
            this.TpgCOVValue.Controls.Add(this.PrgCOVValue);
            this.TpgCOVValue.Controls.Add(this.DgvCOVValue);
            this.TpgCOVValue.Controls.Add(this.TxtCOVValue_RequestID);
            this.TpgCOVValue.Controls.Add(this.LblCOVValue_RequestID);
            this.TpgCOVValue.Controls.Add(this.LblCOVValue_ObjectID);
            this.TpgCOVValue.Controls.Add(this.TxtCOVValue_ObjectID);
            this.TpgCOVValue.Controls.Add(this.BtnCOVValue_GetCOVValues);
            this.TpgCOVValue.Controls.Add(this.RtbCOVValue);
            this.TpgCOVValue.Controls.Add(this.BtnCOVValue_StopReadingCOVValue);
            this.TpgCOVValue.Controls.Add(this.BtnCOVValue_StartReadingValue);
            this.TpgCOVValue.Location = new System.Drawing.Point(4, 29);
            this.TpgCOVValue.Name = "TpgCOVValue";
            this.TpgCOVValue.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCOVValue.Size = new System.Drawing.Size(1060, 508);
            this.TpgCOVValue.TabIndex = 0;
            this.TpgCOVValue.Text = "Get COV Value";
            this.TpgCOVValue.UseVisualStyleBackColor = true;
            // 
            // PrgCOVValue
            // 
            this.PrgCOVValue.HelpVisible = false;
            this.PrgCOVValue.Location = new System.Drawing.Point(205, 66);
            this.PrgCOVValue.Name = "PrgCOVValue";
            this.PrgCOVValue.Size = new System.Drawing.Size(425, 158);
            this.PrgCOVValue.TabIndex = 20;
            this.PrgCOVValue.ToolbarVisible = false;
            // 
            // DgvCOVValue
            // 
            this.DgvCOVValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCOVValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCOVValue.Location = new System.Drawing.Point(205, 237);
            this.DgvCOVValue.Name = "DgvCOVValue";
            this.DgvCOVValue.Size = new System.Drawing.Size(838, 257);
            this.DgvCOVValue.TabIndex = 19;
            // 
            // TxtCOVValue_RequestID
            // 
            this.TxtCOVValue_RequestID.Location = new System.Drawing.Point(203, 32);
            this.TxtCOVValue_RequestID.Name = "TxtCOVValue_RequestID";
            this.TxtCOVValue_RequestID.ReadOnly = true;
            this.TxtCOVValue_RequestID.Size = new System.Drawing.Size(236, 20);
            this.TxtCOVValue_RequestID.TabIndex = 18;
            // 
            // LblCOVValue_RequestID
            // 
            this.LblCOVValue_RequestID.AutoSize = true;
            this.LblCOVValue_RequestID.Location = new System.Drawing.Point(133, 35);
            this.LblCOVValue_RequestID.Name = "LblCOVValue_RequestID";
            this.LblCOVValue_RequestID.Size = new System.Drawing.Size(64, 13);
            this.LblCOVValue_RequestID.TabIndex = 17;
            this.LblCOVValue_RequestID.Text = "Request ID:";
            // 
            // LblCOVValue_ObjectID
            // 
            this.LblCOVValue_ObjectID.AutoSize = true;
            this.LblCOVValue_ObjectID.Location = new System.Drawing.Point(111, 9);
            this.LblCOVValue_ObjectID.Name = "LblCOVValue_ObjectID";
            this.LblCOVValue_ObjectID.Size = new System.Drawing.Size(86, 13);
            this.LblCOVValue_ObjectID.TabIndex = 16;
            this.LblCOVValue_ObjectID.Text = "Object ID (Guid):";
            // 
            // TxtCOVValue_ObjectID
            // 
            this.TxtCOVValue_ObjectID.Location = new System.Drawing.Point(203, 6);
            this.TxtCOVValue_ObjectID.Name = "TxtCOVValue_ObjectID";
            this.TxtCOVValue_ObjectID.Size = new System.Drawing.Size(236, 20);
            this.TxtCOVValue_ObjectID.TabIndex = 15;
            // 
            // BtnCOVValue_GetCOVValues
            // 
            this.BtnCOVValue_GetCOVValues.Location = new System.Drawing.Point(10, 124);
            this.BtnCOVValue_GetCOVValues.Name = "BtnCOVValue_GetCOVValues";
            this.BtnCOVValue_GetCOVValues.Size = new System.Drawing.Size(178, 23);
            this.BtnCOVValue_GetCOVValues.TabIndex = 14;
            this.BtnCOVValue_GetCOVValues.Text = "GetCOVValues";
            this.BtnCOVValue_GetCOVValues.UseVisualStyleBackColor = true;
            this.BtnCOVValue_GetCOVValues.Click += new System.EventHandler(this.BtnCOVValue_GetCOVValues_Click);
            // 
            // RtbCOVValue
            // 
            this.RtbCOVValue.Location = new System.Drawing.Point(636, 66);
            this.RtbCOVValue.Name = "RtbCOVValue";
            this.RtbCOVValue.Size = new System.Drawing.Size(408, 158);
            this.RtbCOVValue.TabIndex = 13;
            this.RtbCOVValue.Text = "";
            // 
            // BtnCOVValue_StopReadingCOVValue
            // 
            this.BtnCOVValue_StopReadingCOVValue.Location = new System.Drawing.Point(10, 95);
            this.BtnCOVValue_StopReadingCOVValue.Name = "BtnCOVValue_StopReadingCOVValue";
            this.BtnCOVValue_StopReadingCOVValue.Size = new System.Drawing.Size(178, 23);
            this.BtnCOVValue_StopReadingCOVValue.TabIndex = 12;
            this.BtnCOVValue_StopReadingCOVValue.Text = "StopReadingCOVValue";
            this.BtnCOVValue_StopReadingCOVValue.UseVisualStyleBackColor = true;
            this.BtnCOVValue_StopReadingCOVValue.Click += new System.EventHandler(this.BtnCOVValue_StopReadingCOVValue_Click);
            // 
            // BtnCOVValue_StartReadingValue
            // 
            this.BtnCOVValue_StartReadingValue.Location = new System.Drawing.Point(10, 66);
            this.BtnCOVValue_StartReadingValue.Name = "BtnCOVValue_StartReadingValue";
            this.BtnCOVValue_StartReadingValue.Size = new System.Drawing.Size(178, 23);
            this.BtnCOVValue_StartReadingValue.TabIndex = 11;
            this.BtnCOVValue_StartReadingValue.Text = "StartReadingCOVValue";
            this.BtnCOVValue_StartReadingValue.UseVisualStyleBackColor = true;
            this.BtnCOVValue_StartReadingValue.Click += new System.EventHandler(this.BtnCOVValue_StartReadingValue_Click);
            // 
            // TpgCOVValues
            // 
            this.TpgCOVValues.Controls.Add(this.TlpCOVvalues);
            this.TpgCOVValues.Location = new System.Drawing.Point(4, 29);
            this.TpgCOVValues.Name = "TpgCOVValues";
            this.TpgCOVValues.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCOVValues.Size = new System.Drawing.Size(1060, 508);
            this.TpgCOVValues.TabIndex = 1;
            this.TpgCOVValues.Text = "Get COV Values (multiple)";
            this.TpgCOVValues.UseVisualStyleBackColor = true;
            // 
            // TlpCOVvalues
            // 
            this.TlpCOVvalues.ColumnCount = 6;
            this.TlpCOVvalues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpCOVvalues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpCOVvalues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpCOVvalues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpCOVvalues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpCOVvalues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpCOVvalues.Controls.Add(this.LblCOVValues_Params, 1, 1);
            this.TlpCOVvalues.Controls.Add(this.DgvCOVValues, 2, 5);
            this.TlpCOVvalues.Controls.Add(this.LblCOVValues_RequestID, 1, 3);
            this.TlpCOVvalues.Controls.Add(this.TxtCOVValues_RequestID, 2, 3);
            this.TlpCOVvalues.Controls.Add(this.DgvCOVValues_Params, 2, 1);
            this.TlpCOVvalues.Controls.Add(this.BtnCOVValues_StartReadingCOVValues, 2, 2);
            this.TlpCOVvalues.Controls.Add(this.BtnCOVValues_StopReadingCOVValues, 4, 2);
            this.TlpCOVvalues.Controls.Add(this.LblCOVValues_Heartbeat, 1, 4);
            this.TlpCOVvalues.Controls.Add(this.TxtCOVValues_Heartbeat, 2, 4);
            this.TlpCOVvalues.Controls.Add(this.BtnCOVValues_KeepAlive, 3, 2);
            this.TlpCOVvalues.Controls.Add(this.LblCOVValues_StartTime, 3, 4);
            this.TlpCOVvalues.Controls.Add(this.TxtCOVValues_StartTime, 4, 4);
            this.TlpCOVvalues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpCOVvalues.Location = new System.Drawing.Point(3, 3);
            this.TlpCOVvalues.Name = "TlpCOVvalues";
            this.TlpCOVvalues.RowCount = 6;
            this.TlpCOVvalues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpCOVvalues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TlpCOVvalues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpCOVvalues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpCOVvalues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpCOVvalues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpCOVvalues.Size = new System.Drawing.Size(1054, 502);
            this.TlpCOVvalues.TabIndex = 30;
            // 
            // LblCOVValues_Params
            // 
            this.LblCOVValues_Params.AutoSize = true;
            this.LblCOVValues_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCOVValues_Params.Location = new System.Drawing.Point(23, 23);
            this.LblCOVValues_Params.Margin = new System.Windows.Forms.Padding(3);
            this.LblCOVValues_Params.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblCOVValues_Params.Name = "LblCOVValues_Params";
            this.LblCOVValues_Params.Size = new System.Drawing.Size(140, 94);
            this.LblCOVValues_Params.TabIndex = 0;
            this.LblCOVValues_Params.Text = "Parameters:";
            this.LblCOVValues_Params.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvCOVValues
            // 
            this.DgvCOVValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCOVValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TlpCOVvalues.SetColumnSpan(this.DgvCOVValues, 3);
            this.DgvCOVValues.Location = new System.Drawing.Point(169, 204);
            this.DgvCOVValues.Name = "DgvCOVValues";
            this.DgvCOVValues.Size = new System.Drawing.Size(861, 295);
            this.DgvCOVValues.TabIndex = 29;
            // 
            // LblCOVValues_RequestID
            // 
            this.LblCOVValues_RequestID.AutoSize = true;
            this.LblCOVValues_RequestID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCOVValues_RequestID.Location = new System.Drawing.Point(23, 152);
            this.LblCOVValues_RequestID.Margin = new System.Windows.Forms.Padding(3);
            this.LblCOVValues_RequestID.Name = "LblCOVValues_RequestID";
            this.LblCOVValues_RequestID.Size = new System.Drawing.Size(140, 20);
            this.LblCOVValues_RequestID.TabIndex = 25;
            this.LblCOVValues_RequestID.Text = "Request ID:";
            this.LblCOVValues_RequestID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtCOVValues_RequestID
            // 
            this.TlpCOVvalues.SetColumnSpan(this.TxtCOVValues_RequestID, 3);
            this.TxtCOVValues_RequestID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCOVValues_RequestID.Location = new System.Drawing.Point(169, 152);
            this.TxtCOVValues_RequestID.Name = "TxtCOVValues_RequestID";
            this.TxtCOVValues_RequestID.ReadOnly = true;
            this.TxtCOVValues_RequestID.Size = new System.Drawing.Size(861, 20);
            this.TxtCOVValues_RequestID.TabIndex = 26;
            // 
            // DgvCOVValues_Params
            // 
            this.DgvCOVValues_Params.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCOVValues_Params.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvCOVValues_Params_Id});
            this.TlpCOVvalues.SetColumnSpan(this.DgvCOVValues_Params, 3);
            this.DgvCOVValues_Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCOVValues_Params.Location = new System.Drawing.Point(169, 23);
            this.DgvCOVValues_Params.Name = "DgvCOVValues_Params";
            this.DgvCOVValues_Params.Size = new System.Drawing.Size(861, 94);
            this.DgvCOVValues_Params.TabIndex = 1;
            // 
            // DgvCOVValues_Params_Id
            // 
            this.DgvCOVValues_Params_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvCOVValues_Params_Id.HeaderText = "Object ID (GUID)";
            this.DgvCOVValues_Params_Id.Name = "DgvCOVValues_Params_Id";
            // 
            // BtnCOVValues_StartReadingCOVValues
            // 
            this.BtnCOVValues_StartReadingCOVValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCOVValues_StartReadingCOVValues.Location = new System.Drawing.Point(169, 123);
            this.BtnCOVValues_StartReadingCOVValues.Name = "BtnCOVValues_StartReadingCOVValues";
            this.BtnCOVValues_StartReadingCOVValues.Size = new System.Drawing.Size(283, 23);
            this.BtnCOVValues_StartReadingCOVValues.TabIndex = 21;
            this.BtnCOVValues_StartReadingCOVValues.Text = "StartReadingCOVValues";
            this.BtnCOVValues_StartReadingCOVValues.UseVisualStyleBackColor = true;
            this.BtnCOVValues_StartReadingCOVValues.Click += new System.EventHandler(this.BtnCOVValues_StartReadingCOVValues_Click);
            // 
            // BtnCOVValues_StopReadingCOVValues
            // 
            this.BtnCOVValues_StopReadingCOVValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCOVValues_StopReadingCOVValues.Location = new System.Drawing.Point(747, 123);
            this.BtnCOVValues_StopReadingCOVValues.Name = "BtnCOVValues_StopReadingCOVValues";
            this.BtnCOVValues_StopReadingCOVValues.Size = new System.Drawing.Size(283, 23);
            this.BtnCOVValues_StopReadingCOVValues.TabIndex = 22;
            this.BtnCOVValues_StopReadingCOVValues.Text = "StopReadingCOVValues";
            this.BtnCOVValues_StopReadingCOVValues.UseVisualStyleBackColor = true;
            this.BtnCOVValues_StopReadingCOVValues.Click += new System.EventHandler(this.BtnCOVValues_StopReadingCOVValues_Click);
            // 
            // LblCOVValues_Heartbeat
            // 
            this.LblCOVValues_Heartbeat.AutoSize = true;
            this.LblCOVValues_Heartbeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCOVValues_Heartbeat.Location = new System.Drawing.Point(23, 178);
            this.LblCOVValues_Heartbeat.Margin = new System.Windows.Forms.Padding(3);
            this.LblCOVValues_Heartbeat.Name = "LblCOVValues_Heartbeat";
            this.LblCOVValues_Heartbeat.Size = new System.Drawing.Size(140, 20);
            this.LblCOVValues_Heartbeat.TabIndex = 30;
            this.LblCOVValues_Heartbeat.Text = "HeartBeat:";
            this.LblCOVValues_Heartbeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtCOVValues_Heartbeat
            // 
            this.TxtCOVValues_Heartbeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCOVValues_Heartbeat.Location = new System.Drawing.Point(169, 178);
            this.TxtCOVValues_Heartbeat.Name = "TxtCOVValues_Heartbeat";
            this.TxtCOVValues_Heartbeat.ReadOnly = true;
            this.TxtCOVValues_Heartbeat.Size = new System.Drawing.Size(283, 20);
            this.TxtCOVValues_Heartbeat.TabIndex = 31;
            // 
            // TpgAlarmEvents
            // 
            this.TpgAlarmEvents.Controls.Add(this.label1);
            this.TpgAlarmEvents.Controls.Add(this.TxtAlarmEvents_MaxNumber);
            this.TpgAlarmEvents.Controls.Add(this.BtnAlarmEvent_StopCollectingAlarms);
            this.TpgAlarmEvents.Controls.Add(this.DgvAlarmEvents);
            this.TpgAlarmEvents.Controls.Add(this.TxtAlarmEvents_RequestID);
            this.TpgAlarmEvents.Controls.Add(this.LblAlarmEvents_RequestID);
            this.TpgAlarmEvents.Controls.Add(this.BtnAlarmEvent_StartCollectingAlarms);
            this.TpgAlarmEvents.Location = new System.Drawing.Point(4, 29);
            this.TpgAlarmEvents.Name = "TpgAlarmEvents";
            this.TpgAlarmEvents.Size = new System.Drawing.Size(1060, 508);
            this.TpgAlarmEvents.TabIndex = 2;
            this.TpgAlarmEvents.Text = "Alarm Events";
            this.TpgAlarmEvents.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Max Number of Alarms:";
            // 
            // TxtAlarmEvents_MaxNumber
            // 
            this.TxtAlarmEvents_MaxNumber.Location = new System.Drawing.Point(195, 19);
            this.TxtAlarmEvents_MaxNumber.Name = "TxtAlarmEvents_MaxNumber";
            this.TxtAlarmEvents_MaxNumber.Size = new System.Drawing.Size(845, 20);
            this.TxtAlarmEvents_MaxNumber.TabIndex = 28;
            this.TxtAlarmEvents_MaxNumber.Text = "10";
            // 
            // BtnAlarmEvent_StopCollectingAlarms
            // 
            this.BtnAlarmEvent_StopCollectingAlarms.Location = new System.Drawing.Point(606, 45);
            this.BtnAlarmEvent_StopCollectingAlarms.Name = "BtnAlarmEvent_StopCollectingAlarms";
            this.BtnAlarmEvent_StopCollectingAlarms.Size = new System.Drawing.Size(434, 23);
            this.BtnAlarmEvent_StopCollectingAlarms.TabIndex = 27;
            this.BtnAlarmEvent_StopCollectingAlarms.Text = "StopCollectingAlarms";
            this.BtnAlarmEvent_StopCollectingAlarms.UseVisualStyleBackColor = true;
            this.BtnAlarmEvent_StopCollectingAlarms.Click += new System.EventHandler(this.BtnAlarmEvent_StopCollectingAlarms_Click);
            // 
            // DgvAlarmEvents
            // 
            this.DgvAlarmEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlarmEvents.Location = new System.Drawing.Point(195, 101);
            this.DgvAlarmEvents.Name = "DgvAlarmEvents";
            this.DgvAlarmEvents.Size = new System.Drawing.Size(845, 392);
            this.DgvAlarmEvents.TabIndex = 26;
            // 
            // TxtAlarmEvents_RequestID
            // 
            this.TxtAlarmEvents_RequestID.Location = new System.Drawing.Point(195, 75);
            this.TxtAlarmEvents_RequestID.Name = "TxtAlarmEvents_RequestID";
            this.TxtAlarmEvents_RequestID.ReadOnly = true;
            this.TxtAlarmEvents_RequestID.Size = new System.Drawing.Size(845, 20);
            this.TxtAlarmEvents_RequestID.TabIndex = 25;
            // 
            // LblAlarmEvents_RequestID
            // 
            this.LblAlarmEvents_RequestID.AutoSize = true;
            this.LblAlarmEvents_RequestID.Location = new System.Drawing.Point(125, 78);
            this.LblAlarmEvents_RequestID.Name = "LblAlarmEvents_RequestID";
            this.LblAlarmEvents_RequestID.Size = new System.Drawing.Size(64, 13);
            this.LblAlarmEvents_RequestID.TabIndex = 24;
            this.LblAlarmEvents_RequestID.Text = "Request ID:";
            // 
            // BtnAlarmEvent_StartCollectingAlarms
            // 
            this.BtnAlarmEvent_StartCollectingAlarms.Location = new System.Drawing.Point(195, 45);
            this.BtnAlarmEvent_StartCollectingAlarms.Name = "BtnAlarmEvent_StartCollectingAlarms";
            this.BtnAlarmEvent_StartCollectingAlarms.Size = new System.Drawing.Size(405, 23);
            this.BtnAlarmEvent_StartCollectingAlarms.TabIndex = 23;
            this.BtnAlarmEvent_StartCollectingAlarms.Text = "StartCollectingAlarms";
            this.BtnAlarmEvent_StartCollectingAlarms.UseVisualStyleBackColor = true;
            this.BtnAlarmEvent_StartCollectingAlarms.Click += new System.EventHandler(this.BtnAlarmEvent_StartCollectingAlarms_Click);
            // 
            // TpgAuditEvents
            // 
            this.TpgAuditEvents.Controls.Add(this.label2);
            this.TpgAuditEvents.Controls.Add(this.TxtAuditEvents_MaxNumber);
            this.TpgAuditEvents.Controls.Add(this.BtnAuditEvent_StopCollectingAudits);
            this.TpgAuditEvents.Controls.Add(this.BtnAuditEvent_StartCollectingAudits);
            this.TpgAuditEvents.Controls.Add(this.DgvAuditEvents);
            this.TpgAuditEvents.Controls.Add(this.TxtAuditEvents_RequestID);
            this.TpgAuditEvents.Controls.Add(this.LblAuditEvents_RequestID);
            this.TpgAuditEvents.Location = new System.Drawing.Point(4, 29);
            this.TpgAuditEvents.Name = "TpgAuditEvents";
            this.TpgAuditEvents.Size = new System.Drawing.Size(1060, 508);
            this.TpgAuditEvents.TabIndex = 3;
            this.TpgAuditEvents.Text = "Audit Events";
            this.TpgAuditEvents.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Max Number of Audits:";
            // 
            // TxtAuditEvents_MaxNumber
            // 
            this.TxtAuditEvents_MaxNumber.Location = new System.Drawing.Point(197, 24);
            this.TxtAuditEvents_MaxNumber.Name = "TxtAuditEvents_MaxNumber";
            this.TxtAuditEvents_MaxNumber.Size = new System.Drawing.Size(849, 20);
            this.TxtAuditEvents_MaxNumber.TabIndex = 30;
            this.TxtAuditEvents_MaxNumber.Text = "20";
            // 
            // BtnAuditEvent_StopCollectingAudits
            // 
            this.BtnAuditEvent_StopCollectingAudits.Location = new System.Drawing.Point(641, 50);
            this.BtnAuditEvent_StopCollectingAudits.Name = "BtnAuditEvent_StopCollectingAudits";
            this.BtnAuditEvent_StopCollectingAudits.Size = new System.Drawing.Size(405, 22);
            this.BtnAuditEvent_StopCollectingAudits.TabIndex = 29;
            this.BtnAuditEvent_StopCollectingAudits.Text = "StopCollectingAudits";
            this.BtnAuditEvent_StopCollectingAudits.UseVisualStyleBackColor = true;
            this.BtnAuditEvent_StopCollectingAudits.Click += new System.EventHandler(this.BtnAuditEvent_StopCollectingAudits_Click);
            // 
            // BtnAuditEvent_StartCollectingAudits
            // 
            this.BtnAuditEvent_StartCollectingAudits.Location = new System.Drawing.Point(197, 50);
            this.BtnAuditEvent_StartCollectingAudits.Name = "BtnAuditEvent_StartCollectingAudits";
            this.BtnAuditEvent_StartCollectingAudits.Size = new System.Drawing.Size(425, 23);
            this.BtnAuditEvent_StartCollectingAudits.TabIndex = 28;
            this.BtnAuditEvent_StartCollectingAudits.Text = "StartCollectingAuditStream";
            this.BtnAuditEvent_StartCollectingAudits.UseVisualStyleBackColor = true;
            this.BtnAuditEvent_StartCollectingAudits.Click += new System.EventHandler(this.BtnAuditEvent_StartCollectingAudits_Click);
            // 
            // DgvAuditEvents
            // 
            this.DgvAuditEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAuditEvents.Location = new System.Drawing.Point(197, 105);
            this.DgvAuditEvents.Name = "DgvAuditEvents";
            this.DgvAuditEvents.Size = new System.Drawing.Size(849, 391);
            this.DgvAuditEvents.TabIndex = 27;
            // 
            // TxtAuditEvents_RequestID
            // 
            this.TxtAuditEvents_RequestID.Location = new System.Drawing.Point(197, 79);
            this.TxtAuditEvents_RequestID.Name = "TxtAuditEvents_RequestID";
            this.TxtAuditEvents_RequestID.ReadOnly = true;
            this.TxtAuditEvents_RequestID.Size = new System.Drawing.Size(849, 20);
            this.TxtAuditEvents_RequestID.TabIndex = 26;
            // 
            // LblAuditEvents_RequestID
            // 
            this.LblAuditEvents_RequestID.AutoSize = true;
            this.LblAuditEvents_RequestID.Location = new System.Drawing.Point(127, 82);
            this.LblAuditEvents_RequestID.Name = "LblAuditEvents_RequestID";
            this.LblAuditEvents_RequestID.Size = new System.Drawing.Size(64, 13);
            this.LblAuditEvents_RequestID.TabIndex = 25;
            this.LblAuditEvents_RequestID.Text = "Request ID:";
            // 
            // TmrRefreshCOVValue
            // 
            this.TmrRefreshCOVValue.Interval = 1000;
            this.TmrRefreshCOVValue.Tick += new System.EventHandler(this.TmrRefreshCOVValue_Tick);
            // 
            // BtnCOVValues_KeepAlive
            // 
            this.BtnCOVValues_KeepAlive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCOVValues_KeepAlive.Location = new System.Drawing.Point(458, 123);
            this.BtnCOVValues_KeepAlive.Name = "BtnCOVValues_KeepAlive";
            this.BtnCOVValues_KeepAlive.Size = new System.Drawing.Size(283, 23);
            this.BtnCOVValues_KeepAlive.TabIndex = 32;
            this.BtnCOVValues_KeepAlive.Text = "Streams.KeepAlive";
            this.BtnCOVValues_KeepAlive.UseVisualStyleBackColor = true;
            this.BtnCOVValues_KeepAlive.Click += new System.EventHandler(this.BtnCOVValues_KeepAlive_Click);
            // 
            // LblCOVValues_StartTime
            // 
            this.LblCOVValues_StartTime.AutoSize = true;
            this.LblCOVValues_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCOVValues_StartTime.Location = new System.Drawing.Point(458, 178);
            this.LblCOVValues_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblCOVValues_StartTime.Name = "LblCOVValues_StartTime";
            this.LblCOVValues_StartTime.Size = new System.Drawing.Size(283, 20);
            this.LblCOVValues_StartTime.TabIndex = 33;
            this.LblCOVValues_StartTime.Text = "Start Time:";
            this.LblCOVValues_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtCOVValues_StartTime
            // 
            this.TxtCOVValues_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCOVValues_StartTime.Location = new System.Drawing.Point(747, 178);
            this.TxtCOVValues_StartTime.Name = "TxtCOVValues_StartTime";
            this.TxtCOVValues_StartTime.ReadOnly = true;
            this.TxtCOVValues_StartTime.Size = new System.Drawing.Size(283, 20);
            this.TxtCOVValues_StartTime.TabIndex = 34;
            // 
            // TmrStreamCheck
            // 
            this.TmrStreamCheck.Interval = 30000;
            this.TmrStreamCheck.Tick += new System.EventHandler(this.TmrStreamCheck_Tick);
            // 
            // Streams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.TabMain);
            this.Name = "Streams";
            this.Text = "Streams";
            this.TabMain.ResumeLayout(false);
            this.TpgCOVValue.ResumeLayout(false);
            this.TpgCOVValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValue)).EndInit();
            this.TpgCOVValues.ResumeLayout(false);
            this.TlpCOVvalues.ResumeLayout(false);
            this.TlpCOVvalues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValues_Params)).EndInit();
            this.TpgAlarmEvents.ResumeLayout(false);
            this.TpgAlarmEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarmEvents)).EndInit();
            this.TpgAuditEvents.ResumeLayout(false);
            this.TpgAuditEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAuditEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgCOVValue;
        private System.Windows.Forms.TabPage TpgCOVValues;
        private System.Windows.Forms.TabPage TpgAlarmEvents;
        private System.Windows.Forms.TabPage TpgAuditEvents;
        private System.Windows.Forms.PropertyGrid PrgCOVValue;
        private System.Windows.Forms.DataGridView DgvCOVValue;
        private System.Windows.Forms.TextBox TxtCOVValue_RequestID;
        private System.Windows.Forms.Label LblCOVValue_RequestID;
        private System.Windows.Forms.Label LblCOVValue_ObjectID;
        private System.Windows.Forms.TextBox TxtCOVValue_ObjectID;
        private System.Windows.Forms.Button BtnCOVValue_GetCOVValues;
        private System.Windows.Forms.RichTextBox RtbCOVValue;
        private System.Windows.Forms.Button BtnCOVValue_StopReadingCOVValue;
        private System.Windows.Forms.Button BtnCOVValue_StartReadingValue;
        private System.Windows.Forms.Timer TmrRefreshCOVValue;
        private System.Windows.Forms.TextBox TxtCOVValues_RequestID;
        private System.Windows.Forms.Label LblCOVValues_RequestID;
        private System.Windows.Forms.Button BtnCOVValues_StopReadingCOVValues;
        private System.Windows.Forms.Button BtnCOVValues_StartReadingCOVValues;
        private System.Windows.Forms.DataGridView DgvAlarmEvents;
        private System.Windows.Forms.TextBox TxtAlarmEvents_RequestID;
        private System.Windows.Forms.Label LblAlarmEvents_RequestID;
        private System.Windows.Forms.Button BtnAlarmEvent_StartCollectingAlarms;
        private System.Windows.Forms.Button BtnAuditEvent_StartCollectingAudits;
        private System.Windows.Forms.DataGridView DgvAuditEvents;
        private System.Windows.Forms.TextBox TxtAuditEvents_RequestID;
        private System.Windows.Forms.Label LblAuditEvents_RequestID;
        private System.Windows.Forms.DataGridView DgvCOVValues;
        private System.Windows.Forms.TableLayoutPanel TlpCOVvalues;
        private System.Windows.Forms.Label LblCOVValues_Params;
        private System.Windows.Forms.DataGridView DgvCOVValues_Params;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCOVValues_Params_Id;
        private System.Windows.Forms.Button BtnAlarmEvent_StopCollectingAlarms;
        private System.Windows.Forms.TextBox TxtAlarmEvents_MaxNumber;
        private System.Windows.Forms.Button BtnAuditEvent_StopCollectingAudits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtAuditEvents_MaxNumber;
        private System.Windows.Forms.Label LblCOVValues_Heartbeat;
        private System.Windows.Forms.TextBox TxtCOVValues_Heartbeat;
        private System.Windows.Forms.Button BtnCOVValues_KeepAlive;
        private System.Windows.Forms.Label LblCOVValues_StartTime;
        private System.Windows.Forms.TextBox TxtCOVValues_StartTime;
        private System.Windows.Forms.Timer TmrStreamCheck;
    }
}