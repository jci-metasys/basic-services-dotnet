
namespace MetasysServices_TestClient.Forms
{
    partial class Trends
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
            this.TpgGetTrendedAttributes = new System.Windows.Forms.TabPage();
            this.TpgGetSamples = new System.Windows.Forms.TabPage();
            this.TlpGetTrendedAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetTrendedAttributes_ObjectID = new System.Windows.Forms.Label();
            this.TxtGetTrendedAttributes_ObjectID = new System.Windows.Forms.TextBox();
            this.BtnGetTrendedAttributes = new System.Windows.Forms.Button();
            this.DgvGetTrendedAttributes = new System.Windows.Forms.DataGridView();
            this.TlpGetSamples = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSamples_ObjectID = new System.Windows.Forms.Label();
            this.TxtGetSamples_ObjectID = new System.Windows.Forms.TextBox();
            this.BtnGetSamples = new System.Windows.Forms.Button();
            this.DgvGetSamples = new System.Windows.Forms.DataGridView();
            this.LblGetSamples_AttributeID = new System.Windows.Forms.Label();
            this.NudGetSamples_AttributeID = new System.Windows.Forms.NumericUpDown();
            this.LblGetSamples_Filter = new System.Windows.Forms.Label();
            this.TlpGetSamples_Filter = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSamples_StartTime = new System.Windows.Forms.Label();
            this.DtpGetSamples_StartTime = new System.Windows.Forms.DateTimePicker();
            this.LblGetSamples_EndTime = new System.Windows.Forms.Label();
            this.DtpGetSamples_EndTime = new System.Windows.Forms.DateTimePicker();
            this.TabMain.SuspendLayout();
            this.TpgGetTrendedAttributes.SuspendLayout();
            this.TpgGetSamples.SuspendLayout();
            this.TlpGetTrendedAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetTrendedAttributes)).BeginInit();
            this.TlpGetSamples.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGetSamples_AttributeID)).BeginInit();
            this.TlpGetSamples_Filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetTrendedAttributes);
            this.TabMain.Controls.Add(this.TpgGetSamples);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(846, 500);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGetTrendedAttributes
            // 
            this.TpgGetTrendedAttributes.Controls.Add(this.TlpGetTrendedAttributes);
            this.TpgGetTrendedAttributes.Location = new System.Drawing.Point(4, 29);
            this.TpgGetTrendedAttributes.Name = "TpgGetTrendedAttributes";
            this.TpgGetTrendedAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetTrendedAttributes.Size = new System.Drawing.Size(838, 467);
            this.TpgGetTrendedAttributes.TabIndex = 0;
            this.TpgGetTrendedAttributes.Text = "GetTrendedAttributes";
            this.TpgGetTrendedAttributes.UseVisualStyleBackColor = true;
            // 
            // TpgGetSamples
            // 
            this.TpgGetSamples.Controls.Add(this.TlpGetSamples);
            this.TpgGetSamples.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSamples.Name = "TpgGetSamples";
            this.TpgGetSamples.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSamples.Size = new System.Drawing.Size(838, 467);
            this.TpgGetSamples.TabIndex = 1;
            this.TpgGetSamples.Text = "GetSamples";
            this.TpgGetSamples.UseVisualStyleBackColor = true;
            // 
            // TlpGetTrendedAttributes
            // 
            this.TlpGetTrendedAttributes.ColumnCount = 4;
            this.TlpGetTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTrendedAttributes.Controls.Add(this.LblGetTrendedAttributes_ObjectID, 1, 1);
            this.TlpGetTrendedAttributes.Controls.Add(this.TxtGetTrendedAttributes_ObjectID, 2, 1);
            this.TlpGetTrendedAttributes.Controls.Add(this.BtnGetTrendedAttributes, 2, 2);
            this.TlpGetTrendedAttributes.Controls.Add(this.DgvGetTrendedAttributes, 2, 3);
            this.TlpGetTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetTrendedAttributes.Location = new System.Drawing.Point(3, 3);
            this.TlpGetTrendedAttributes.Name = "TlpGetTrendedAttributes";
            this.TlpGetTrendedAttributes.RowCount = 5;
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTrendedAttributes.Size = new System.Drawing.Size(832, 461);
            this.TlpGetTrendedAttributes.TabIndex = 0;
            // 
            // LblGetTrendedAttributes_ObjectID
            // 
            this.LblGetTrendedAttributes_ObjectID.AutoSize = true;
            this.LblGetTrendedAttributes_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetTrendedAttributes_ObjectID.Location = new System.Drawing.Point(23, 23);
            this.LblGetTrendedAttributes_ObjectID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetTrendedAttributes_ObjectID.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetTrendedAttributes_ObjectID.Name = "LblGetTrendedAttributes_ObjectID";
            this.LblGetTrendedAttributes_ObjectID.Size = new System.Drawing.Size(100, 20);
            this.LblGetTrendedAttributes_ObjectID.TabIndex = 0;
            this.LblGetTrendedAttributes_ObjectID.Text = "Object ID (GUID):";
            this.LblGetTrendedAttributes_ObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetTrendedAttributes_ObjectID
            // 
            this.TxtGetTrendedAttributes_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetTrendedAttributes_ObjectID.Location = new System.Drawing.Point(129, 23);
            this.TxtGetTrendedAttributes_ObjectID.Name = "TxtGetTrendedAttributes_ObjectID";
            this.TxtGetTrendedAttributes_ObjectID.Size = new System.Drawing.Size(680, 20);
            this.TxtGetTrendedAttributes_ObjectID.TabIndex = 1;
            // 
            // BtnGetTrendedAttributes
            // 
            this.BtnGetTrendedAttributes.Location = new System.Drawing.Point(129, 49);
            this.BtnGetTrendedAttributes.Name = "BtnGetTrendedAttributes";
            this.BtnGetTrendedAttributes.Size = new System.Drawing.Size(120, 23);
            this.BtnGetTrendedAttributes.TabIndex = 2;
            this.BtnGetTrendedAttributes.Text = "GetTrendedAttributes";
            this.BtnGetTrendedAttributes.UseVisualStyleBackColor = true;
            this.BtnGetTrendedAttributes.Click += new System.EventHandler(this.BtnGetTrendedAttributes_Click);
            // 
            // DgvGetTrendedAttributes
            // 
            this.DgvGetTrendedAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetTrendedAttributes.Location = new System.Drawing.Point(129, 78);
            this.DgvGetTrendedAttributes.Name = "DgvGetTrendedAttributes";
            this.DgvGetTrendedAttributes.Size = new System.Drawing.Size(680, 360);
            this.DgvGetTrendedAttributes.TabIndex = 3;
            // 
            // TlpGetSamples
            // 
            this.TlpGetSamples.ColumnCount = 4;
            this.TlpGetSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSamples.Controls.Add(this.LblGetSamples_ObjectID, 1, 1);
            this.TlpGetSamples.Controls.Add(this.TxtGetSamples_ObjectID, 2, 1);
            this.TlpGetSamples.Controls.Add(this.BtnGetSamples, 2, 4);
            this.TlpGetSamples.Controls.Add(this.DgvGetSamples, 2, 5);
            this.TlpGetSamples.Controls.Add(this.LblGetSamples_AttributeID, 1, 2);
            this.TlpGetSamples.Controls.Add(this.NudGetSamples_AttributeID, 2, 2);
            this.TlpGetSamples.Controls.Add(this.LblGetSamples_Filter, 1, 3);
            this.TlpGetSamples.Controls.Add(this.TlpGetSamples_Filter, 2, 3);
            this.TlpGetSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSamples.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSamples.Name = "TlpGetSamples";
            this.TlpGetSamples.RowCount = 7;
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSamples.Size = new System.Drawing.Size(832, 461);
            this.TlpGetSamples.TabIndex = 0;
            // 
            // LblGetSamples_ObjectID
            // 
            this.LblGetSamples_ObjectID.AutoSize = true;
            this.LblGetSamples_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_ObjectID.Location = new System.Drawing.Point(23, 23);
            this.LblGetSamples_ObjectID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_ObjectID.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetSamples_ObjectID.Name = "LblGetSamples_ObjectID";
            this.LblGetSamples_ObjectID.Size = new System.Drawing.Size(100, 20);
            this.LblGetSamples_ObjectID.TabIndex = 0;
            this.LblGetSamples_ObjectID.Text = "Object ID (GUID):";
            this.LblGetSamples_ObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetSamples_ObjectID
            // 
            this.TxtGetSamples_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetSamples_ObjectID.Location = new System.Drawing.Point(129, 23);
            this.TxtGetSamples_ObjectID.Name = "TxtGetSamples_ObjectID";
            this.TxtGetSamples_ObjectID.Size = new System.Drawing.Size(680, 20);
            this.TxtGetSamples_ObjectID.TabIndex = 1;
            // 
            // BtnGetSamples
            // 
            this.BtnGetSamples.Location = new System.Drawing.Point(129, 147);
            this.BtnGetSamples.Name = "BtnGetSamples";
            this.BtnGetSamples.Size = new System.Drawing.Size(130, 23);
            this.BtnGetSamples.TabIndex = 2;
            this.BtnGetSamples.Text = "GetSamples";
            this.BtnGetSamples.UseVisualStyleBackColor = true;
            this.BtnGetSamples.Click += new System.EventHandler(this.BtnGetSamples_Click);
            // 
            // DgvGetSamples
            // 
            this.DgvGetSamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSamples.Location = new System.Drawing.Point(129, 176);
            this.DgvGetSamples.Name = "DgvGetSamples";
            this.DgvGetSamples.Size = new System.Drawing.Size(680, 262);
            this.DgvGetSamples.TabIndex = 3;
            // 
            // LblGetSamples_AttributeID
            // 
            this.LblGetSamples_AttributeID.AutoSize = true;
            this.LblGetSamples_AttributeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_AttributeID.Location = new System.Drawing.Point(23, 49);
            this.LblGetSamples_AttributeID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_AttributeID.Name = "LblGetSamples_AttributeID";
            this.LblGetSamples_AttributeID.Size = new System.Drawing.Size(100, 20);
            this.LblGetSamples_AttributeID.TabIndex = 4;
            this.LblGetSamples_AttributeID.Text = "Attribute ID (INT):";
            this.LblGetSamples_AttributeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudGetSamples_AttributeID
            // 
            this.NudGetSamples_AttributeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NudGetSamples_AttributeID.Location = new System.Drawing.Point(129, 49);
            this.NudGetSamples_AttributeID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NudGetSamples_AttributeID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudGetSamples_AttributeID.Name = "NudGetSamples_AttributeID";
            this.NudGetSamples_AttributeID.Size = new System.Drawing.Size(680, 20);
            this.NudGetSamples_AttributeID.TabIndex = 5;
            this.NudGetSamples_AttributeID.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // LblGetSamples_Filter
            // 
            this.LblGetSamples_Filter.AutoSize = true;
            this.LblGetSamples_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_Filter.Location = new System.Drawing.Point(23, 75);
            this.LblGetSamples_Filter.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_Filter.Name = "LblGetSamples_Filter";
            this.LblGetSamples_Filter.Size = new System.Drawing.Size(100, 66);
            this.LblGetSamples_Filter.TabIndex = 6;
            this.LblGetSamples_Filter.Text = "Filter (TimeFilter):";
            this.LblGetSamples_Filter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TlpGetSamples_Filter
            // 
            this.TlpGetSamples_Filter.AutoSize = true;
            this.TlpGetSamples_Filter.ColumnCount = 4;
            this.TlpGetSamples_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSamples_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetSamples_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSamples_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetSamples_Filter.Controls.Add(this.LblGetSamples_StartTime, 0, 0);
            this.TlpGetSamples_Filter.Controls.Add(this.DtpGetSamples_StartTime, 1, 0);
            this.TlpGetSamples_Filter.Controls.Add(this.LblGetSamples_EndTime, 2, 0);
            this.TlpGetSamples_Filter.Controls.Add(this.DtpGetSamples_EndTime, 3, 0);
            this.TlpGetSamples_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSamples_Filter.Location = new System.Drawing.Point(129, 75);
            this.TlpGetSamples_Filter.Name = "TlpGetSamples_Filter";
            this.TlpGetSamples_Filter.RowCount = 3;
            this.TlpGetSamples_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSamples_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSamples_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSamples_Filter.Size = new System.Drawing.Size(680, 66);
            this.TlpGetSamples_Filter.TabIndex = 7;
            // 
            // LblGetSamples_StartTime
            // 
            this.LblGetSamples_StartTime.AutoSize = true;
            this.LblGetSamples_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_StartTime.Location = new System.Drawing.Point(3, 3);
            this.LblGetSamples_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_StartTime.Name = "LblGetSamples_StartTime";
            this.LblGetSamples_StartTime.Size = new System.Drawing.Size(58, 20);
            this.LblGetSamples_StartTime.TabIndex = 0;
            this.LblGetSamples_StartTime.Text = "Start Time:";
            this.LblGetSamples_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGetSamples_StartTime
            // 
            this.DtpGetSamples_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetSamples_StartTime.Location = new System.Drawing.Point(67, 3);
            this.DtpGetSamples_StartTime.Name = "DtpGetSamples_StartTime";
            this.DtpGetSamples_StartTime.Size = new System.Drawing.Size(271, 20);
            this.DtpGetSamples_StartTime.TabIndex = 1;
            // 
            // LblGetSamples_EndTime
            // 
            this.LblGetSamples_EndTime.AutoSize = true;
            this.LblGetSamples_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_EndTime.Location = new System.Drawing.Point(344, 3);
            this.LblGetSamples_EndTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_EndTime.Name = "LblGetSamples_EndTime";
            this.LblGetSamples_EndTime.Size = new System.Drawing.Size(55, 20);
            this.LblGetSamples_EndTime.TabIndex = 2;
            this.LblGetSamples_EndTime.Text = "End Time:";
            this.LblGetSamples_EndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGetSamples_EndTime
            // 
            this.DtpGetSamples_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetSamples_EndTime.Location = new System.Drawing.Point(405, 3);
            this.DtpGetSamples_EndTime.Name = "DtpGetSamples_EndTime";
            this.DtpGetSamples_EndTime.Size = new System.Drawing.Size(272, 20);
            this.DtpGetSamples_EndTime.TabIndex = 3;
            // 
            // Trends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 524);
            this.Controls.Add(this.TabMain);
            this.Name = "Trends";
            this.Text = "Trends";
            this.TabMain.ResumeLayout(false);
            this.TpgGetTrendedAttributes.ResumeLayout(false);
            this.TpgGetSamples.ResumeLayout(false);
            this.TlpGetTrendedAttributes.ResumeLayout(false);
            this.TlpGetTrendedAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetTrendedAttributes)).EndInit();
            this.TlpGetSamples.ResumeLayout(false);
            this.TlpGetSamples.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGetSamples_AttributeID)).EndInit();
            this.TlpGetSamples_Filter.ResumeLayout(false);
            this.TlpGetSamples_Filter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGetTrendedAttributes;
        private System.Windows.Forms.TabPage TpgGetSamples;
        private System.Windows.Forms.TableLayoutPanel TlpGetTrendedAttributes;
        private System.Windows.Forms.Label LblGetTrendedAttributes_ObjectID;
        private System.Windows.Forms.TextBox TxtGetTrendedAttributes_ObjectID;
        private System.Windows.Forms.Button BtnGetTrendedAttributes;
        private System.Windows.Forms.DataGridView DgvGetTrendedAttributes;
        private System.Windows.Forms.TableLayoutPanel TlpGetSamples;
        private System.Windows.Forms.Label LblGetSamples_ObjectID;
        private System.Windows.Forms.TextBox TxtGetSamples_ObjectID;
        private System.Windows.Forms.Button BtnGetSamples;
        private System.Windows.Forms.DataGridView DgvGetSamples;
        private System.Windows.Forms.Label LblGetSamples_AttributeID;
        private System.Windows.Forms.NumericUpDown NudGetSamples_AttributeID;
        private System.Windows.Forms.Label LblGetSamples_Filter;
        private System.Windows.Forms.TableLayoutPanel TlpGetSamples_Filter;
        private System.Windows.Forms.Label LblGetSamples_StartTime;
        private System.Windows.Forms.DateTimePicker DtpGetSamples_StartTime;
        private System.Windows.Forms.Label LblGetSamples_EndTime;
        private System.Windows.Forms.DateTimePicker DtpGetSamples_EndTime;
    }
}