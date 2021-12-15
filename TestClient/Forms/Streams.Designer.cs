
namespace MetasysServices_TestClient
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
            this.TxtCOVValues_ObjectID2 = new System.Windows.Forms.TextBox();
            this.TxtCOVValues_RequestID = new System.Windows.Forms.TextBox();
            this.LblCOVValues_RequestID = new System.Windows.Forms.Label();
            this.LblCOVValues_ObjectIDs = new System.Windows.Forms.Label();
            this.TxtCOVValues_ObjectID1 = new System.Windows.Forms.TextBox();
            this.BtnCOVValues_StopReadingCOVValues = new System.Windows.Forms.Button();
            this.BtnCOVValues_StartReadingCOVValues = new System.Windows.Forms.Button();
            this.TpgAlarmEvents = new System.Windows.Forms.TabPage();
            this.DgvAlarmEvents = new System.Windows.Forms.DataGridView();
            this.TxtAlarmEvents_RequestID = new System.Windows.Forms.TextBox();
            this.LblAlarmEvents_RequestID = new System.Windows.Forms.Label();
            this.BtnAlarmEvent_StartCollectingAlarms = new System.Windows.Forms.Button();
            this.TpgAuditEvents = new System.Windows.Forms.TabPage();
            this.BtnAuditEvent_StartCollectingAudits = new System.Windows.Forms.Button();
            this.DgvAuditEvents = new System.Windows.Forms.DataGridView();
            this.TxtAuditEvents_RequestID = new System.Windows.Forms.TextBox();
            this.LblAuditEvents_RequestID = new System.Windows.Forms.Label();
            this.TmrRefreshCOVValue = new System.Windows.Forms.Timer(this.components);
            this.TmrRefreshCOVValues = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TabMain.SuspendLayout();
            this.TpgCOVValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValue)).BeginInit();
            this.TpgCOVValues.SuspendLayout();
            this.TpgAlarmEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarmEvents)).BeginInit();
            this.TpgAuditEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAuditEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgCOVValue);
            this.TabMain.Controls.Add(this.TpgCOVValues);
            this.TabMain.Controls.Add(this.TpgAlarmEvents);
            this.TabMain.Controls.Add(this.TpgAuditEvents);
            this.TabMain.ItemSize = new System.Drawing.Size(84, 26);
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
            this.TpgCOVValue.Location = new System.Drawing.Point(4, 30);
            this.TpgCOVValue.Name = "TpgCOVValue";
            this.TpgCOVValue.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCOVValue.Size = new System.Drawing.Size(1060, 507);
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
            this.DgvCOVValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCOVValue.Location = new System.Drawing.Point(205, 237);
            this.DgvCOVValue.Name = "DgvCOVValue";
            this.DgvCOVValue.Size = new System.Drawing.Size(838, 162);
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
            this.TxtCOVValue_ObjectID.Text = "453be0a5-2027-5b01-a088-b16ea8a45556";
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
            this.TpgCOVValues.Controls.Add(this.dataGridView1);
            this.TpgCOVValues.Controls.Add(this.TxtCOVValues_ObjectID2);
            this.TpgCOVValues.Controls.Add(this.TxtCOVValues_RequestID);
            this.TpgCOVValues.Controls.Add(this.LblCOVValues_RequestID);
            this.TpgCOVValues.Controls.Add(this.LblCOVValues_ObjectIDs);
            this.TpgCOVValues.Controls.Add(this.TxtCOVValues_ObjectID1);
            this.TpgCOVValues.Controls.Add(this.BtnCOVValues_StopReadingCOVValues);
            this.TpgCOVValues.Controls.Add(this.BtnCOVValues_StartReadingCOVValues);
            this.TpgCOVValues.Location = new System.Drawing.Point(4, 30);
            this.TpgCOVValues.Name = "TpgCOVValues";
            this.TpgCOVValues.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCOVValues.Size = new System.Drawing.Size(1060, 507);
            this.TpgCOVValues.TabIndex = 1;
            this.TpgCOVValues.Text = "Get COV Values (multiple)";
            this.TpgCOVValues.UseVisualStyleBackColor = true;
            // 
            // TxtCOVValues_ObjectID2
            // 
            this.TxtCOVValues_ObjectID2.Location = new System.Drawing.Point(456, 6);
            this.TxtCOVValues_ObjectID2.Name = "TxtCOVValues_ObjectID2";
            this.TxtCOVValues_ObjectID2.Size = new System.Drawing.Size(236, 20);
            this.TxtCOVValues_ObjectID2.TabIndex = 28;
            this.TxtCOVValues_ObjectID2.Text = "16580b9f-b82c-5040-9ab4-e68766f9b306";
            // 
            // TxtCOVValues_RequestID
            // 
            this.TxtCOVValues_RequestID.Location = new System.Drawing.Point(200, 32);
            this.TxtCOVValues_RequestID.Name = "TxtCOVValues_RequestID";
            this.TxtCOVValues_RequestID.ReadOnly = true;
            this.TxtCOVValues_RequestID.Size = new System.Drawing.Size(236, 20);
            this.TxtCOVValues_RequestID.TabIndex = 26;
            // 
            // LblCOVValues_RequestID
            // 
            this.LblCOVValues_RequestID.AutoSize = true;
            this.LblCOVValues_RequestID.Location = new System.Drawing.Point(121, 34);
            this.LblCOVValues_RequestID.Name = "LblCOVValues_RequestID";
            this.LblCOVValues_RequestID.Size = new System.Drawing.Size(64, 13);
            this.LblCOVValues_RequestID.TabIndex = 25;
            this.LblCOVValues_RequestID.Text = "Request ID:";
            // 
            // LblCOVValues_ObjectIDs
            // 
            this.LblCOVValues_ObjectIDs.AutoSize = true;
            this.LblCOVValues_ObjectIDs.Location = new System.Drawing.Point(121, 9);
            this.LblCOVValues_ObjectIDs.Name = "LblCOVValues_ObjectIDs";
            this.LblCOVValues_ObjectIDs.Size = new System.Drawing.Size(60, 13);
            this.LblCOVValues_ObjectIDs.TabIndex = 24;
            this.LblCOVValues_ObjectIDs.Text = "Object IDs:";
            // 
            // TxtCOVValues_ObjectID1
            // 
            this.TxtCOVValues_ObjectID1.Location = new System.Drawing.Point(200, 6);
            this.TxtCOVValues_ObjectID1.Name = "TxtCOVValues_ObjectID1";
            this.TxtCOVValues_ObjectID1.Size = new System.Drawing.Size(236, 20);
            this.TxtCOVValues_ObjectID1.TabIndex = 23;
            this.TxtCOVValues_ObjectID1.Text = "453be0a5-2027-5b01-a088-b16ea8a45556";
            // 
            // BtnCOVValues_StopReadingCOVValues
            // 
            this.BtnCOVValues_StopReadingCOVValues.Location = new System.Drawing.Point(14, 87);
            this.BtnCOVValues_StopReadingCOVValues.Name = "BtnCOVValues_StopReadingCOVValues";
            this.BtnCOVValues_StopReadingCOVValues.Size = new System.Drawing.Size(178, 23);
            this.BtnCOVValues_StopReadingCOVValues.TabIndex = 22;
            this.BtnCOVValues_StopReadingCOVValues.Text = "StopReadingCOVValues";
            this.BtnCOVValues_StopReadingCOVValues.UseVisualStyleBackColor = true;
            this.BtnCOVValues_StopReadingCOVValues.Click += new System.EventHandler(this.BtnCOVValues_StopReadingCOVValues_Click);
            // 
            // BtnCOVValues_StartReadingCOVValues
            // 
            this.BtnCOVValues_StartReadingCOVValues.Location = new System.Drawing.Point(14, 58);
            this.BtnCOVValues_StartReadingCOVValues.Name = "BtnCOVValues_StartReadingCOVValues";
            this.BtnCOVValues_StartReadingCOVValues.Size = new System.Drawing.Size(178, 23);
            this.BtnCOVValues_StartReadingCOVValues.TabIndex = 21;
            this.BtnCOVValues_StartReadingCOVValues.Text = "StartReadingCOVValues";
            this.BtnCOVValues_StartReadingCOVValues.UseVisualStyleBackColor = true;
            this.BtnCOVValues_StartReadingCOVValues.Click += new System.EventHandler(this.BtnCOVValues_StartReadingCOVValues_Click);
            // 
            // TpgAlarmEvents
            // 
            this.TpgAlarmEvents.Controls.Add(this.DgvAlarmEvents);
            this.TpgAlarmEvents.Controls.Add(this.TxtAlarmEvents_RequestID);
            this.TpgAlarmEvents.Controls.Add(this.LblAlarmEvents_RequestID);
            this.TpgAlarmEvents.Controls.Add(this.BtnAlarmEvent_StartCollectingAlarms);
            this.TpgAlarmEvents.Location = new System.Drawing.Point(4, 30);
            this.TpgAlarmEvents.Name = "TpgAlarmEvents";
            this.TpgAlarmEvents.Size = new System.Drawing.Size(1060, 507);
            this.TpgAlarmEvents.TabIndex = 2;
            this.TpgAlarmEvents.Text = "Alarm Events";
            this.TpgAlarmEvents.UseVisualStyleBackColor = true;
            // 
            // DgvAlarmEvents
            // 
            this.DgvAlarmEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlarmEvents.Location = new System.Drawing.Point(195, 35);
            this.DgvAlarmEvents.Name = "DgvAlarmEvents";
            this.DgvAlarmEvents.Size = new System.Drawing.Size(845, 364);
            this.DgvAlarmEvents.TabIndex = 26;
            // 
            // TxtAlarmEvents_RequestID
            // 
            this.TxtAlarmEvents_RequestID.Location = new System.Drawing.Point(195, 9);
            this.TxtAlarmEvents_RequestID.Name = "TxtAlarmEvents_RequestID";
            this.TxtAlarmEvents_RequestID.ReadOnly = true;
            this.TxtAlarmEvents_RequestID.Size = new System.Drawing.Size(236, 20);
            this.TxtAlarmEvents_RequestID.TabIndex = 25;
            // 
            // LblAlarmEvents_RequestID
            // 
            this.LblAlarmEvents_RequestID.AutoSize = true;
            this.LblAlarmEvents_RequestID.Location = new System.Drawing.Point(116, 12);
            this.LblAlarmEvents_RequestID.Name = "LblAlarmEvents_RequestID";
            this.LblAlarmEvents_RequestID.Size = new System.Drawing.Size(64, 13);
            this.LblAlarmEvents_RequestID.TabIndex = 24;
            this.LblAlarmEvents_RequestID.Text = "Request ID:";
            // 
            // BtnAlarmEvent_StartCollectingAlarms
            // 
            this.BtnAlarmEvent_StartCollectingAlarms.Location = new System.Drawing.Point(11, 35);
            this.BtnAlarmEvent_StartCollectingAlarms.Name = "BtnAlarmEvent_StartCollectingAlarms";
            this.BtnAlarmEvent_StartCollectingAlarms.Size = new System.Drawing.Size(178, 23);
            this.BtnAlarmEvent_StartCollectingAlarms.TabIndex = 23;
            this.BtnAlarmEvent_StartCollectingAlarms.Text = "StartCollectingAlarms";
            this.BtnAlarmEvent_StartCollectingAlarms.UseVisualStyleBackColor = true;
            this.BtnAlarmEvent_StartCollectingAlarms.Click += new System.EventHandler(this.BtnAlarmEvent_StartCollectingAlarms_Click);
            // 
            // TpgAuditEvents
            // 
            this.TpgAuditEvents.Controls.Add(this.BtnAuditEvent_StartCollectingAudits);
            this.TpgAuditEvents.Controls.Add(this.DgvAuditEvents);
            this.TpgAuditEvents.Controls.Add(this.TxtAuditEvents_RequestID);
            this.TpgAuditEvents.Controls.Add(this.LblAuditEvents_RequestID);
            this.TpgAuditEvents.Location = new System.Drawing.Point(4, 30);
            this.TpgAuditEvents.Name = "TpgAuditEvents";
            this.TpgAuditEvents.Size = new System.Drawing.Size(1060, 507);
            this.TpgAuditEvents.TabIndex = 3;
            this.TpgAuditEvents.Text = "Audit Events";
            this.TpgAuditEvents.UseVisualStyleBackColor = true;
            // 
            // BtnAuditEvent_StartCollectingAudits
            // 
            this.BtnAuditEvent_StartCollectingAudits.Location = new System.Drawing.Point(13, 35);
            this.BtnAuditEvent_StartCollectingAudits.Name = "BtnAuditEvent_StartCollectingAudits";
            this.BtnAuditEvent_StartCollectingAudits.Size = new System.Drawing.Size(178, 23);
            this.BtnAuditEvent_StartCollectingAudits.TabIndex = 28;
            this.BtnAuditEvent_StartCollectingAudits.Text = "StartCollectingAuditStream";
            this.BtnAuditEvent_StartCollectingAudits.UseVisualStyleBackColor = true;
            this.BtnAuditEvent_StartCollectingAudits.Click += new System.EventHandler(this.BtnAuditEvent_StartCollectingAudits_Click);
            // 
            // DgvAuditEvents
            // 
            this.DgvAuditEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAuditEvents.Location = new System.Drawing.Point(197, 35);
            this.DgvAuditEvents.Name = "DgvAuditEvents";
            this.DgvAuditEvents.Size = new System.Drawing.Size(842, 364);
            this.DgvAuditEvents.TabIndex = 27;
            // 
            // TxtAuditEvents_RequestID
            // 
            this.TxtAuditEvents_RequestID.Location = new System.Drawing.Point(197, 9);
            this.TxtAuditEvents_RequestID.Name = "TxtAuditEvents_RequestID";
            this.TxtAuditEvents_RequestID.ReadOnly = true;
            this.TxtAuditEvents_RequestID.Size = new System.Drawing.Size(236, 20);
            this.TxtAuditEvents_RequestID.TabIndex = 26;
            // 
            // LblAuditEvents_RequestID
            // 
            this.LblAuditEvents_RequestID.AutoSize = true;
            this.LblAuditEvents_RequestID.Location = new System.Drawing.Point(118, 12);
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
            // TmrRefreshCOVValues
            // 
            this.TmrRefreshCOVValues.Interval = 1000;
            this.TmrRefreshCOVValues.Tick += new System.EventHandler(this.TmrRefreshCOVValues_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(205, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(842, 434);
            this.dataGridView1.TabIndex = 29;
            // 
            // Streams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 565);
            this.Controls.Add(this.TabMain);
            this.Name = "Streams";
            this.Text = "Streams";
            this.TabMain.ResumeLayout(false);
            this.TpgCOVValue.ResumeLayout(false);
            this.TpgCOVValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCOVValue)).EndInit();
            this.TpgCOVValues.ResumeLayout(false);
            this.TpgCOVValues.PerformLayout();
            this.TpgAlarmEvents.ResumeLayout(false);
            this.TpgAlarmEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarmEvents)).EndInit();
            this.TpgAuditEvents.ResumeLayout(false);
            this.TpgAuditEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAuditEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Timer TmrRefreshCOVValues;
        private System.Windows.Forms.TextBox TxtCOVValues_ObjectID2;
        private System.Windows.Forms.TextBox TxtCOVValues_RequestID;
        private System.Windows.Forms.Label LblCOVValues_RequestID;
        private System.Windows.Forms.Label LblCOVValues_ObjectIDs;
        private System.Windows.Forms.TextBox TxtCOVValues_ObjectID1;
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
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}