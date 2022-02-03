
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
            this.TpgGet = new System.Windows.Forms.TabPage();
            this.TlpGetSiteEnumerations = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGetSiteEnumerations = new System.Windows.Forms.Button();
            this.DgvGetSiteEnumerations = new System.Windows.Forms.DataGridView();
            this.LblGet_Title = new System.Windows.Forms.Label();
            this.TpgGetValues = new System.Windows.Forms.TabPage();
            this.TlpGetEnumValues = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetEnumValues_EnumKey = new System.Windows.Forms.Label();
            this.TxtGetEnumValues_EnumKey = new System.Windows.Forms.TextBox();
            this.DgvGetEnumValues = new System.Windows.Forms.DataGridView();
            this.BtnGetEnumValues = new System.Windows.Forms.Button();
            this.LblGetValues_Title = new System.Windows.Forms.Label();
            this.TpgDelete = new System.Windows.Forms.TabPage();
            this.TlpDelete = new System.Windows.Forms.TableLayoutPanel();
            this.LblDelete_EnumerationKey = new System.Windows.Forms.Label();
            this.TxtDelete_EnumerationKey = new System.Windows.Forms.TextBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.LblDelete_Result = new System.Windows.Forms.Label();
            this.TxtDeleted_Result = new System.Windows.Forms.TextBox();
            this.LblDelete_Title = new System.Windows.Forms.Label();
            this.TabMain.SuspendLayout();
            this.TpgGet.SuspendLayout();
            this.TlpGetSiteEnumerations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSiteEnumerations)).BeginInit();
            this.TpgGetValues.SuspendLayout();
            this.TlpGetEnumValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEnumValues)).BeginInit();
            this.TpgDelete.SuspendLayout();
            this.TlpDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGet);
            this.TabMain.Controls.Add(this.TpgGetValues);
            this.TabMain.Controls.Add(this.TpgDelete);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(927, 599);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGet
            // 
            this.TpgGet.Controls.Add(this.TlpGetSiteEnumerations);
            this.TpgGet.Location = new System.Drawing.Point(4, 29);
            this.TpgGet.Name = "TpgGet";
            this.TpgGet.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGet.Size = new System.Drawing.Size(919, 566);
            this.TpgGet.TabIndex = 0;
            this.TpgGet.Text = "Get";
            this.TpgGet.UseVisualStyleBackColor = true;
            // 
            // TlpGetSiteEnumerations
            // 
            this.TlpGetSiteEnumerations.ColumnCount = 4;
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSiteEnumerations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSiteEnumerations.Controls.Add(this.BtnGetSiteEnumerations, 2, 1);
            this.TlpGetSiteEnumerations.Controls.Add(this.DgvGetSiteEnumerations, 2, 2);
            this.TlpGetSiteEnumerations.Controls.Add(this.LblGet_Title, 0, 0);
            this.TlpGetSiteEnumerations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSiteEnumerations.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSiteEnumerations.Name = "TlpGetSiteEnumerations";
            this.TlpGetSiteEnumerations.RowCount = 3;
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSiteEnumerations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSiteEnumerations.Size = new System.Drawing.Size(913, 560);
            this.TlpGetSiteEnumerations.TabIndex = 0;
            // 
            // BtnGetSiteEnumerations
            // 
            this.BtnGetSiteEnumerations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetSiteEnumerations.Location = new System.Drawing.Point(169, 25);
            this.BtnGetSiteEnumerations.Name = "BtnGetSiteEnumerations";
            this.BtnGetSiteEnumerations.Size = new System.Drawing.Size(721, 23);
            this.BtnGetSiteEnumerations.TabIndex = 0;
            this.BtnGetSiteEnumerations.Text = "Enujmerations.Get";
            this.BtnGetSiteEnumerations.UseVisualStyleBackColor = true;
            this.BtnGetSiteEnumerations.Click += new System.EventHandler(this.BtnGetEnumerations_Click);
            // 
            // DgvGetSiteEnumerations
            // 
            this.DgvGetSiteEnumerations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSiteEnumerations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSiteEnumerations.Location = new System.Drawing.Point(169, 54);
            this.DgvGetSiteEnumerations.Name = "DgvGetSiteEnumerations";
            this.DgvGetSiteEnumerations.Size = new System.Drawing.Size(721, 503);
            this.DgvGetSiteEnumerations.TabIndex = 1;
            // 
            // LblGet_Title
            // 
            this.LblGet_Title.AutoSize = true;
            this.TlpGetSiteEnumerations.SetColumnSpan(this.LblGet_Title, 4);
            this.LblGet_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGet_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGet_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGet_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_Title.Name = "LblGet_Title";
            this.LblGet_Title.Size = new System.Drawing.Size(907, 16);
            this.LblGet_Title.TabIndex = 2;
            this.LblGet_Title.Text = "List all the enumerations.";
            this.LblGet_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TpgGetValues
            // 
            this.TpgGetValues.Controls.Add(this.TlpGetEnumValues);
            this.TpgGetValues.Location = new System.Drawing.Point(4, 29);
            this.TpgGetValues.Name = "TpgGetValues";
            this.TpgGetValues.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetValues.Size = new System.Drawing.Size(919, 566);
            this.TpgGetValues.TabIndex = 1;
            this.TpgGetValues.Text = "GetValues";
            this.TpgGetValues.UseVisualStyleBackColor = true;
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
            this.TlpGetEnumValues.Controls.Add(this.LblGetValues_Title, 0, 0);
            this.TlpGetEnumValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetEnumValues.Location = new System.Drawing.Point(3, 3);
            this.TlpGetEnumValues.Name = "TlpGetEnumValues";
            this.TlpGetEnumValues.RowCount = 4;
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEnumValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEnumValues.Size = new System.Drawing.Size(913, 560);
            this.TlpGetEnumValues.TabIndex = 0;
            // 
            // LblGetEnumValues_EnumKey
            // 
            this.LblGetEnumValues_EnumKey.AutoSize = true;
            this.LblGetEnumValues_EnumKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetEnumValues_EnumKey.Location = new System.Drawing.Point(23, 25);
            this.LblGetEnumValues_EnumKey.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetEnumValues_EnumKey.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetEnumValues_EnumKey.Name = "LblGetEnumValues_EnumKey";
            this.LblGetEnumValues_EnumKey.Size = new System.Drawing.Size(140, 20);
            this.LblGetEnumValues_EnumKey.TabIndex = 0;
            this.LblGetEnumValues_EnumKey.Text = "Enumeration Key (STRING):";
            this.LblGetEnumValues_EnumKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetEnumValues_EnumKey
            // 
            this.TxtGetEnumValues_EnumKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetEnumValues_EnumKey.Location = new System.Drawing.Point(169, 25);
            this.TxtGetEnumValues_EnumKey.Name = "TxtGetEnumValues_EnumKey";
            this.TxtGetEnumValues_EnumKey.Size = new System.Drawing.Size(721, 20);
            this.TxtGetEnumValues_EnumKey.TabIndex = 1;
            this.TxtGetEnumValues_EnumKey.Text = "displayPrecisionEnumSet";
            // 
            // DgvGetEnumValues
            // 
            this.DgvGetEnumValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetEnumValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetEnumValues.Location = new System.Drawing.Point(169, 80);
            this.DgvGetEnumValues.Name = "DgvGetEnumValues";
            this.DgvGetEnumValues.Size = new System.Drawing.Size(721, 477);
            this.DgvGetEnumValues.TabIndex = 2;
            // 
            // BtnGetEnumValues
            // 
            this.BtnGetEnumValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetEnumValues.Location = new System.Drawing.Point(169, 51);
            this.BtnGetEnumValues.Name = "BtnGetEnumValues";
            this.BtnGetEnumValues.Size = new System.Drawing.Size(721, 23);
            this.BtnGetEnumValues.TabIndex = 3;
            this.BtnGetEnumValues.Text = "Enumerations.GetValues";
            this.BtnGetEnumValues.UseVisualStyleBackColor = true;
            this.BtnGetEnumValues.Click += new System.EventHandler(this.BtnGetEnumValues_Click);
            // 
            // LblGetValues_Title
            // 
            this.LblGetValues_Title.AutoSize = true;
            this.TlpGetEnumValues.SetColumnSpan(this.LblGetValues_Title, 4);
            this.LblGetValues_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetValues_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetValues_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetValues_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetValues_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetValues_Title.Name = "LblGetValues_Title";
            this.LblGetValues_Title.Size = new System.Drawing.Size(907, 16);
            this.LblGetValues_Title.TabIndex = 4;
            this.LblGetValues_Title.Text = "Get an enumeration values.";
            this.LblGetValues_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TpgDelete
            // 
            this.TpgDelete.Controls.Add(this.TlpDelete);
            this.TpgDelete.Location = new System.Drawing.Point(4, 29);
            this.TpgDelete.Name = "TpgDelete";
            this.TpgDelete.Padding = new System.Windows.Forms.Padding(3);
            this.TpgDelete.Size = new System.Drawing.Size(919, 566);
            this.TpgDelete.TabIndex = 2;
            this.TpgDelete.Text = "Delete";
            this.TpgDelete.UseVisualStyleBackColor = true;
            // 
            // TlpDelete
            // 
            this.TlpDelete.ColumnCount = 4;
            this.TlpDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDelete.Controls.Add(this.LblDelete_EnumerationKey, 1, 1);
            this.TlpDelete.Controls.Add(this.TxtDelete_EnumerationKey, 2, 1);
            this.TlpDelete.Controls.Add(this.BtnDelete, 2, 2);
            this.TlpDelete.Controls.Add(this.LblDelete_Result, 1, 3);
            this.TlpDelete.Controls.Add(this.TxtDeleted_Result, 2, 3);
            this.TlpDelete.Controls.Add(this.LblDelete_Title, 0, 0);
            this.TlpDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpDelete.Location = new System.Drawing.Point(3, 3);
            this.TlpDelete.Name = "TlpDelete";
            this.TlpDelete.RowCount = 5;
            this.TlpDelete.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDelete.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDelete.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDelete.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpDelete.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDelete.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpDelete.Size = new System.Drawing.Size(913, 560);
            this.TlpDelete.TabIndex = 0;
            // 
            // LblDelete_EnumerationKey
            // 
            this.LblDelete_EnumerationKey.AutoSize = true;
            this.LblDelete_EnumerationKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDelete_EnumerationKey.Location = new System.Drawing.Point(23, 25);
            this.LblDelete_EnumerationKey.Margin = new System.Windows.Forms.Padding(3);
            this.LblDelete_EnumerationKey.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblDelete_EnumerationKey.Name = "LblDelete_EnumerationKey";
            this.LblDelete_EnumerationKey.Size = new System.Drawing.Size(140, 20);
            this.LblDelete_EnumerationKey.TabIndex = 0;
            this.LblDelete_EnumerationKey.Text = "Enumeration Key (STRING):";
            this.LblDelete_EnumerationKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDelete_EnumerationKey
            // 
            this.TxtDelete_EnumerationKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDelete_EnumerationKey.Location = new System.Drawing.Point(169, 25);
            this.TxtDelete_EnumerationKey.Name = "TxtDelete_EnumerationKey";
            this.TxtDelete_EnumerationKey.Size = new System.Drawing.Size(721, 20);
            this.TxtDelete_EnumerationKey.TabIndex = 1;
            this.TxtDelete_EnumerationKey.Text = "customEnumSet30000";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Location = new System.Drawing.Point(169, 51);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(721, 23);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Enumerations.Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // LblDelete_Result
            // 
            this.LblDelete_Result.AutoSize = true;
            this.LblDelete_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDelete_Result.Location = new System.Drawing.Point(23, 80);
            this.LblDelete_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblDelete_Result.Name = "LblDelete_Result";
            this.LblDelete_Result.Size = new System.Drawing.Size(140, 20);
            this.LblDelete_Result.TabIndex = 3;
            this.LblDelete_Result.Text = "Result:";
            this.LblDelete_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDeleted_Result
            // 
            this.TxtDeleted_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDeleted_Result.Location = new System.Drawing.Point(169, 80);
            this.TxtDeleted_Result.Name = "TxtDeleted_Result";
            this.TxtDeleted_Result.ReadOnly = true;
            this.TxtDeleted_Result.Size = new System.Drawing.Size(721, 20);
            this.TxtDeleted_Result.TabIndex = 4;
            // 
            // LblDelete_Title
            // 
            this.LblDelete_Title.AutoSize = true;
            this.TlpDelete.SetColumnSpan(this.LblDelete_Title, 4);
            this.LblDelete_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDelete_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblDelete_Title.Location = new System.Drawing.Point(3, 3);
            this.LblDelete_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblDelete_Title.Name = "LblDelete_Title";
            this.LblDelete_Title.Size = new System.Drawing.Size(406, 16);
            this.LblDelete_Title.TabIndex = 5;
            this.LblDelete_Title.Text = "Delete an enumeration. Only custom enumerations may be deleted.";
            this.LblDelete_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Enumerations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 623);
            this.Controls.Add(this.TabMain);
            this.Name = "Enumerations";
            this.Text = "Enumerations";
            this.TabMain.ResumeLayout(false);
            this.TpgGet.ResumeLayout(false);
            this.TlpGetSiteEnumerations.ResumeLayout(false);
            this.TlpGetSiteEnumerations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSiteEnumerations)).EndInit();
            this.TpgGetValues.ResumeLayout(false);
            this.TlpGetEnumValues.ResumeLayout(false);
            this.TlpGetEnumValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEnumValues)).EndInit();
            this.TpgDelete.ResumeLayout(false);
            this.TlpDelete.ResumeLayout(false);
            this.TlpDelete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGet;
        private System.Windows.Forms.TabPage TpgGetValues;
        private System.Windows.Forms.TableLayoutPanel TlpGetSiteEnumerations;
        private System.Windows.Forms.Button BtnGetSiteEnumerations;
        private System.Windows.Forms.DataGridView DgvGetSiteEnumerations;
        private System.Windows.Forms.TableLayoutPanel TlpGetEnumValues;
        private System.Windows.Forms.Label LblGetEnumValues_EnumKey;
        private System.Windows.Forms.TextBox TxtGetEnumValues_EnumKey;
        private System.Windows.Forms.DataGridView DgvGetEnumValues;
        private System.Windows.Forms.Button BtnGetEnumValues;
        private System.Windows.Forms.TabPage TpgDelete;
        private System.Windows.Forms.TableLayoutPanel TlpDelete;
        private System.Windows.Forms.Label LblDelete_EnumerationKey;
        private System.Windows.Forms.TextBox TxtDelete_EnumerationKey;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Label LblDelete_Result;
        private System.Windows.Forms.TextBox TxtDeleted_Result;
        private System.Windows.Forms.Label LblDelete_Title;
        private System.Windows.Forms.Label LblGet_Title;
        private System.Windows.Forms.Label LblGetValues_Title;
    }
}