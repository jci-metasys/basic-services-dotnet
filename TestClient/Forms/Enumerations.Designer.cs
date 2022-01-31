
namespace MetasysServices_TestClient.Forms
{
    partial class Enumerations
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
            this.TpgGetSiteEnumerations = new System.Windows.Forms.TabPage();
            this.TlpGetSiteEnumerations = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGetSiteEnumerations = new System.Windows.Forms.Button();
            this.DgvGetSiteEnumerations = new System.Windows.Forms.DataGridView();
            this.TpgGetEnumValues = new System.Windows.Forms.TabPage();
            this.TlpGetEnumValues = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetEnumValues_EnumKey = new System.Windows.Forms.Label();
            this.TxtGetEnumValues_EnumKey = new System.Windows.Forms.TextBox();
            this.DgvGetEnumValues = new System.Windows.Forms.DataGridView();
            this.BtnGetEnumValues = new System.Windows.Forms.Button();
            this.TabMain.SuspendLayout();
            this.TpgGetSiteEnumerations.SuspendLayout();
            this.TlpGetSiteEnumerations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSiteEnumerations)).BeginInit();
            this.TpgGetEnumValues.SuspendLayout();
            this.TlpGetEnumValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEnumValues)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetSiteEnumerations);
            this.TabMain.Controls.Add(this.TpgGetEnumValues);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(776, 426);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGetSiteEnumerations
            // 
            this.TpgGetSiteEnumerations.Controls.Add(this.TlpGetSiteEnumerations);
            this.TpgGetSiteEnumerations.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSiteEnumerations.Name = "TpgGetSiteEnumerations";
            this.TpgGetSiteEnumerations.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSiteEnumerations.Size = new System.Drawing.Size(768, 393);
            this.TpgGetSiteEnumerations.TabIndex = 0;
            this.TpgGetSiteEnumerations.Text = "GetSiteEnumerations";
            this.TpgGetSiteEnumerations.UseVisualStyleBackColor = true;
            // 
            // TlpGetSiteEnumerations
            // 
            this.TlpGetSiteEnumerations.ColumnCount = 4;
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSiteEnumerations.Controls.Add(this.BtnGetSiteEnumerations, 2, 1);
            this.TlpGetSiteEnumerations.Controls.Add(this.DgvGetSiteEnumerations, 2, 2);
            this.TlpGetSiteEnumerations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSiteEnumerations.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSiteEnumerations.Name = "TlpGetSiteEnumerations";
            this.TlpGetSiteEnumerations.RowCount = 4;
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSiteEnumerations.Size = new System.Drawing.Size(762, 387);
            this.TlpGetSiteEnumerations.TabIndex = 0;
            // 
            // BtnGetSiteEnumerations
            // 
            this.BtnGetSiteEnumerations.Location = new System.Drawing.Point(129, 23);
            this.BtnGetSiteEnumerations.Name = "BtnGetSiteEnumerations";
            this.BtnGetSiteEnumerations.Size = new System.Drawing.Size(130, 23);
            this.BtnGetSiteEnumerations.TabIndex = 0;
            this.BtnGetSiteEnumerations.Text = "GetSiteEnumerations";
            this.BtnGetSiteEnumerations.UseVisualStyleBackColor = true;
            this.BtnGetSiteEnumerations.Click += new System.EventHandler(this.BtnGetEnumerations_Click);
            // 
            // DgvGetSiteEnumerations
            // 
            this.DgvGetSiteEnumerations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSiteEnumerations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSiteEnumerations.Location = new System.Drawing.Point(129, 52);
            this.DgvGetSiteEnumerations.Name = "DgvGetSiteEnumerations";
            this.DgvGetSiteEnumerations.Size = new System.Drawing.Size(610, 312);
            this.DgvGetSiteEnumerations.TabIndex = 1;
            // 
            // TpgGetEnumValues
            // 
            this.TpgGetEnumValues.Controls.Add(this.TlpGetEnumValues);
            this.TpgGetEnumValues.Location = new System.Drawing.Point(4, 29);
            this.TpgGetEnumValues.Name = "TpgGetEnumValues";
            this.TpgGetEnumValues.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetEnumValues.Size = new System.Drawing.Size(768, 393);
            this.TpgGetEnumValues.TabIndex = 1;
            this.TpgGetEnumValues.Text = "GetEnumValues";
            this.TpgGetEnumValues.UseVisualStyleBackColor = true;
            // 
            // TlpGetEnumValues
            // 
            this.TlpGetEnumValues.ColumnCount = 4;
            this.TlpGetEnumValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEnumValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetEnumValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEnumValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEnumValues.Controls.Add(this.LblGetEnumValues_EnumKey, 1, 1);
            this.TlpGetEnumValues.Controls.Add(this.TxtGetEnumValues_EnumKey, 2, 1);
            this.TlpGetEnumValues.Controls.Add(this.DgvGetEnumValues, 2, 3);
            this.TlpGetEnumValues.Controls.Add(this.BtnGetEnumValues, 2, 2);
            this.TlpGetEnumValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetEnumValues.Location = new System.Drawing.Point(3, 3);
            this.TlpGetEnumValues.Name = "TlpGetEnumValues";
            this.TlpGetEnumValues.RowCount = 5;
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEnumValues.Size = new System.Drawing.Size(762, 387);
            this.TlpGetEnumValues.TabIndex = 0;
            // 
            // LblGetEnumValues_EnumKey
            // 
            this.LblGetEnumValues_EnumKey.AutoSize = true;
            this.LblGetEnumValues_EnumKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetEnumValues_EnumKey.Location = new System.Drawing.Point(23, 23);
            this.LblGetEnumValues_EnumKey.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetEnumValues_EnumKey.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetEnumValues_EnumKey.Name = "LblGetEnumValues_EnumKey";
            this.LblGetEnumValues_EnumKey.Size = new System.Drawing.Size(100, 20);
            this.LblGetEnumValues_EnumKey.TabIndex = 0;
            this.LblGetEnumValues_EnumKey.Text = "Enumeration Key:";
            this.LblGetEnumValues_EnumKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetEnumValues_EnumKey
            // 
            this.TxtGetEnumValues_EnumKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetEnumValues_EnumKey.Location = new System.Drawing.Point(129, 23);
            this.TxtGetEnumValues_EnumKey.Name = "TxtGetEnumValues_EnumKey";
            this.TxtGetEnumValues_EnumKey.Size = new System.Drawing.Size(610, 20);
            this.TxtGetEnumValues_EnumKey.TabIndex = 1;
            // 
            // DgvGetEnumValues
            // 
            this.DgvGetEnumValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetEnumValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetEnumValues.Location = new System.Drawing.Point(129, 78);
            this.DgvGetEnumValues.Name = "DgvGetEnumValues";
            this.DgvGetEnumValues.Size = new System.Drawing.Size(610, 286);
            this.DgvGetEnumValues.TabIndex = 2;
            // 
            // BtnGetEnumValues
            // 
            this.BtnGetEnumValues.Location = new System.Drawing.Point(129, 49);
            this.BtnGetEnumValues.Name = "BtnGetEnumValues";
            this.BtnGetEnumValues.Size = new System.Drawing.Size(130, 23);
            this.BtnGetEnumValues.TabIndex = 3;
            this.BtnGetEnumValues.Text = "GetEnumValues";
            this.BtnGetEnumValues.UseVisualStyleBackColor = true;
            this.BtnGetEnumValues.Click += new System.EventHandler(this.BtnGetEnumValues_Click);
            // 
            // Enumerations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabMain);
            this.Name = "Enumerations";
            this.Text = "Enumerations";
            this.TabMain.ResumeLayout(false);
            this.TpgGetSiteEnumerations.ResumeLayout(false);
            this.TlpGetSiteEnumerations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSiteEnumerations)).EndInit();
            this.TpgGetEnumValues.ResumeLayout(false);
            this.TlpGetEnumValues.ResumeLayout(false);
            this.TlpGetEnumValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEnumValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGetSiteEnumerations;
        private System.Windows.Forms.TabPage TpgGetEnumValues;
        private System.Windows.Forms.TableLayoutPanel TlpGetSiteEnumerations;
        private System.Windows.Forms.Button BtnGetSiteEnumerations;
        private System.Windows.Forms.DataGridView DgvGetSiteEnumerations;
        private System.Windows.Forms.TableLayoutPanel TlpGetEnumValues;
        private System.Windows.Forms.Label LblGetEnumValues_EnumKey;
        private System.Windows.Forms.TextBox TxtGetEnumValues_EnumKey;
        private System.Windows.Forms.DataGridView DgvGetEnumValues;
        private System.Windows.Forms.Button BtnGetEnumValues;
    }
}