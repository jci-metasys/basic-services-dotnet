
namespace MetasysServices_TestClient.Forms
{
    partial class Miscellanea
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
            this.TpgGetServerTime = new System.Windows.Forms.TabPage();
            this.TlpGetServerTime = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGetServerTime = new System.Windows.Forms.Button();
            this.LblGetServerTime_Result = new System.Windows.Forms.Label();
            this.TxtGetServerTime_Result = new System.Windows.Forms.TextBox();
            this.Tpglocalize = new System.Windows.Forms.TabPage();
            this.TlpLocalize = new System.Windows.Forms.TableLayoutPanel();
            this.LblLocalize_SourceText = new System.Windows.Forms.Label();
            this.TxtLocalize_ResourceText = new System.Windows.Forms.TextBox();
            this.LblLocalize_CultureInfo = new System.Windows.Forms.Label();
            this.CmbLocalize_CultureInfo = new System.Windows.Forms.ComboBox();
            this.BtnLocalize = new System.Windows.Forms.Button();
            this.LblLocalize_Result = new System.Windows.Forms.Label();
            this.TxtLocalize_Result = new System.Windows.Forms.TextBox();
            this.TabMain.SuspendLayout();
            this.TpgGetServerTime.SuspendLayout();
            this.TlpGetServerTime.SuspendLayout();
            this.Tpglocalize.SuspendLayout();
            this.TlpLocalize.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetServerTime);
            this.TabMain.Controls.Add(this.Tpglocalize);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(776, 426);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGetServerTime
            // 
            this.TpgGetServerTime.Controls.Add(this.TlpGetServerTime);
            this.TpgGetServerTime.Location = new System.Drawing.Point(4, 29);
            this.TpgGetServerTime.Name = "TpgGetServerTime";
            this.TpgGetServerTime.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetServerTime.Size = new System.Drawing.Size(768, 393);
            this.TpgGetServerTime.TabIndex = 0;
            this.TpgGetServerTime.Text = "GetServerTime";
            this.TpgGetServerTime.UseVisualStyleBackColor = true;
            // 
            // TlpGetServerTime
            // 
            this.TlpGetServerTime.ColumnCount = 4;
            this.TlpGetServerTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServerTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetServerTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServerTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServerTime.Controls.Add(this.BtnGetServerTime, 2, 1);
            this.TlpGetServerTime.Controls.Add(this.LblGetServerTime_Result, 1, 2);
            this.TlpGetServerTime.Controls.Add(this.TxtGetServerTime_Result, 2, 2);
            this.TlpGetServerTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetServerTime.Location = new System.Drawing.Point(3, 3);
            this.TlpGetServerTime.Name = "TlpGetServerTime";
            this.TlpGetServerTime.RowCount = 4;
            this.TlpGetServerTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServerTime.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServerTime.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServerTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServerTime.Size = new System.Drawing.Size(762, 387);
            this.TlpGetServerTime.TabIndex = 0;
            // 
            // BtnGetServerTime
            // 
            this.BtnGetServerTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetServerTime.Location = new System.Drawing.Point(169, 23);
            this.BtnGetServerTime.Name = "BtnGetServerTime";
            this.BtnGetServerTime.Size = new System.Drawing.Size(570, 23);
            this.BtnGetServerTime.TabIndex = 0;
            this.BtnGetServerTime.Text = "GetServerTime";
            this.BtnGetServerTime.UseVisualStyleBackColor = true;
            this.BtnGetServerTime.Click += new System.EventHandler(this.BtnGetServerTime_Click);
            // 
            // LblGetServerTime_Result
            // 
            this.LblGetServerTime_Result.AutoSize = true;
            this.LblGetServerTime_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServerTime_Result.Location = new System.Drawing.Point(23, 52);
            this.LblGetServerTime_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetServerTime_Result.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetServerTime_Result.Name = "LblGetServerTime_Result";
            this.LblGetServerTime_Result.Size = new System.Drawing.Size(140, 20);
            this.LblGetServerTime_Result.TabIndex = 1;
            this.LblGetServerTime_Result.Text = "Result:";
            this.LblGetServerTime_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetServerTime_Result
            // 
            this.TxtGetServerTime_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetServerTime_Result.Location = new System.Drawing.Point(169, 52);
            this.TxtGetServerTime_Result.Name = "TxtGetServerTime_Result";
            this.TxtGetServerTime_Result.ReadOnly = true;
            this.TxtGetServerTime_Result.Size = new System.Drawing.Size(570, 20);
            this.TxtGetServerTime_Result.TabIndex = 2;
            // 
            // Tpglocalize
            // 
            this.Tpglocalize.Controls.Add(this.TlpLocalize);
            this.Tpglocalize.Location = new System.Drawing.Point(4, 29);
            this.Tpglocalize.Name = "Tpglocalize";
            this.Tpglocalize.Padding = new System.Windows.Forms.Padding(3);
            this.Tpglocalize.Size = new System.Drawing.Size(768, 393);
            this.Tpglocalize.TabIndex = 1;
            this.Tpglocalize.Text = "Localize";
            this.Tpglocalize.UseVisualStyleBackColor = true;
            // 
            // TlpLocalize
            // 
            this.TlpLocalize.ColumnCount = 4;
            this.TlpLocalize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpLocalize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpLocalize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpLocalize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpLocalize.Controls.Add(this.LblLocalize_SourceText, 1, 1);
            this.TlpLocalize.Controls.Add(this.TxtLocalize_ResourceText, 2, 1);
            this.TlpLocalize.Controls.Add(this.LblLocalize_CultureInfo, 1, 2);
            this.TlpLocalize.Controls.Add(this.CmbLocalize_CultureInfo, 2, 2);
            this.TlpLocalize.Controls.Add(this.BtnLocalize, 2, 3);
            this.TlpLocalize.Controls.Add(this.LblLocalize_Result, 1, 4);
            this.TlpLocalize.Controls.Add(this.TxtLocalize_Result, 2, 4);
            this.TlpLocalize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpLocalize.Location = new System.Drawing.Point(3, 3);
            this.TlpLocalize.Name = "TlpLocalize";
            this.TlpLocalize.RowCount = 6;
            this.TlpLocalize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpLocalize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpLocalize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpLocalize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpLocalize.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpLocalize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpLocalize.Size = new System.Drawing.Size(762, 387);
            this.TlpLocalize.TabIndex = 0;
            // 
            // LblLocalize_SourceText
            // 
            this.LblLocalize_SourceText.AutoSize = true;
            this.LblLocalize_SourceText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblLocalize_SourceText.Location = new System.Drawing.Point(23, 23);
            this.LblLocalize_SourceText.Margin = new System.Windows.Forms.Padding(3);
            this.LblLocalize_SourceText.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblLocalize_SourceText.Name = "LblLocalize_SourceText";
            this.LblLocalize_SourceText.Size = new System.Drawing.Size(140, 20);
            this.LblLocalize_SourceText.TabIndex = 0;
            this.LblLocalize_SourceText.Text = "Resource Text:";
            this.LblLocalize_SourceText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtLocalize_ResourceText
            // 
            this.TxtLocalize_ResourceText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLocalize_ResourceText.Location = new System.Drawing.Point(169, 23);
            this.TxtLocalize_ResourceText.Name = "TxtLocalize_ResourceText";
            this.TxtLocalize_ResourceText.Size = new System.Drawing.Size(570, 20);
            this.TxtLocalize_ResourceText.TabIndex = 1;
            // 
            // LblLocalize_CultureInfo
            // 
            this.LblLocalize_CultureInfo.AutoSize = true;
            this.LblLocalize_CultureInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblLocalize_CultureInfo.Location = new System.Drawing.Point(23, 49);
            this.LblLocalize_CultureInfo.Margin = new System.Windows.Forms.Padding(3);
            this.LblLocalize_CultureInfo.Name = "LblLocalize_CultureInfo";
            this.LblLocalize_CultureInfo.Size = new System.Drawing.Size(140, 21);
            this.LblLocalize_CultureInfo.TabIndex = 2;
            this.LblLocalize_CultureInfo.Text = "Culture Info:";
            this.LblLocalize_CultureInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbLocalize_CultureInfo
            // 
            this.CmbLocalize_CultureInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbLocalize_CultureInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLocalize_CultureInfo.FormattingEnabled = true;
            this.CmbLocalize_CultureInfo.Items.AddRange(new object[] {
            "cs-CZ",
            "de-DE",
            "en-US",
            "es-ES",
            "fr-FR",
            "hu-HU",
            "it-IT",
            "ja-JP",
            "ko-KR",
            "nb-NO",
            "nl-NL",
            "pl-PL",
            "pt-BR",
            "ru-RU",
            "sv-SE",
            "tr-TR",
            "zh-CN",
            "zh-TW",
            "zh-Hans-CN",
            "zh-Hant-TW"});
            this.CmbLocalize_CultureInfo.Location = new System.Drawing.Point(169, 49);
            this.CmbLocalize_CultureInfo.Name = "CmbLocalize_CultureInfo";
            this.CmbLocalize_CultureInfo.Size = new System.Drawing.Size(570, 21);
            this.CmbLocalize_CultureInfo.TabIndex = 3;
            // 
            // BtnLocalize
            // 
            this.BtnLocalize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLocalize.Location = new System.Drawing.Point(169, 76);
            this.BtnLocalize.Name = "BtnLocalize";
            this.BtnLocalize.Size = new System.Drawing.Size(570, 23);
            this.BtnLocalize.TabIndex = 4;
            this.BtnLocalize.Text = "Localize";
            this.BtnLocalize.UseVisualStyleBackColor = true;
            this.BtnLocalize.Click += new System.EventHandler(this.BtnLocalize_Click);
            // 
            // LblLocalize_Result
            // 
            this.LblLocalize_Result.AutoSize = true;
            this.LblLocalize_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblLocalize_Result.Location = new System.Drawing.Point(23, 105);
            this.LblLocalize_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblLocalize_Result.Name = "LblLocalize_Result";
            this.LblLocalize_Result.Size = new System.Drawing.Size(140, 20);
            this.LblLocalize_Result.TabIndex = 5;
            this.LblLocalize_Result.Text = "Result:";
            this.LblLocalize_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtLocalize_Result
            // 
            this.TxtLocalize_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLocalize_Result.Location = new System.Drawing.Point(169, 105);
            this.TxtLocalize_Result.Name = "TxtLocalize_Result";
            this.TxtLocalize_Result.ReadOnly = true;
            this.TxtLocalize_Result.Size = new System.Drawing.Size(570, 20);
            this.TxtLocalize_Result.TabIndex = 6;
            // 
            // Miscellanea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabMain);
            this.Name = "Miscellanea";
            this.Text = "Miscellanea";
            this.TabMain.ResumeLayout(false);
            this.TpgGetServerTime.ResumeLayout(false);
            this.TlpGetServerTime.ResumeLayout(false);
            this.TlpGetServerTime.PerformLayout();
            this.Tpglocalize.ResumeLayout(false);
            this.TlpLocalize.ResumeLayout(false);
            this.TlpLocalize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGetServerTime;
        private System.Windows.Forms.TabPage Tpglocalize;
        private System.Windows.Forms.TableLayoutPanel TlpGetServerTime;
        private System.Windows.Forms.Button BtnGetServerTime;
        private System.Windows.Forms.Label LblGetServerTime_Result;
        private System.Windows.Forms.TextBox TxtGetServerTime_Result;
        private System.Windows.Forms.TableLayoutPanel TlpLocalize;
        private System.Windows.Forms.Label LblLocalize_SourceText;
        private System.Windows.Forms.TextBox TxtLocalize_ResourceText;
        private System.Windows.Forms.Label LblLocalize_CultureInfo;
        private System.Windows.Forms.ComboBox CmbLocalize_CultureInfo;
        private System.Windows.Forms.Button BtnLocalize;
        private System.Windows.Forms.Label LblLocalize_Result;
        private System.Windows.Forms.TextBox TxtLocalize_Result;
    }
}