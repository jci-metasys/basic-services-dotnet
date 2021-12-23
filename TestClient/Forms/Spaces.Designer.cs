
namespace MetasysServices_TestClient.Forms
{
    partial class Spaces
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
            this.TpgGetSpaces = new System.Windows.Forms.TabPage();
            this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.LblSpaceType = new System.Windows.Forms.Label();
            this.BtnGetSpaces = new System.Windows.Forms.Button();
            this.DgvGetSpaces = new System.Windows.Forms.DataGridView();
            this.TpgGetSpaceChildren = new System.Windows.Forms.TabPage();
            this.CmbGetSpaces = new System.Windows.Forms.ComboBox();
            this.ChkGetSpaces = new System.Windows.Forms.CheckBox();
            this.TpgGetSpaceEquipment = new System.Windows.Forms.TabPage();
            this.TpgGetSpaceTypes = new System.Windows.Forms.TabPage();
            this.TlpGetSpaceChildren = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSpaceChildren_Guid = new System.Windows.Forms.Label();
            this.TabMain.SuspendLayout();
            this.TpgGetSpaces.SuspendLayout();
            this.TlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaces)).BeginInit();
            this.TpgGetSpaceChildren.SuspendLayout();
            this.TlpGetSpaceChildren.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetSpaces);
            this.TabMain.Controls.Add(this.TpgGetSpaceChildren);
            this.TabMain.Controls.Add(this.TpgGetSpaceEquipment);
            this.TabMain.Controls.Add(this.TpgGetSpaceTypes);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(1060, 537);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGetSpaces
            // 
            this.TpgGetSpaces.Controls.Add(this.TlpMain);
            this.TpgGetSpaces.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSpaces.Name = "TpgGetSpaces";
            this.TpgGetSpaces.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSpaces.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetSpaces.TabIndex = 0;
            this.TpgGetSpaces.Text = "GetSpaces";
            this.TpgGetSpaces.UseVisualStyleBackColor = true;
            // 
            // TlpMain
            // 
            this.TlpMain.ColumnCount = 5;
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.Controls.Add(this.LblSpaceType, 1, 1);
            this.TlpMain.Controls.Add(this.BtnGetSpaces, 2, 2);
            this.TlpMain.Controls.Add(this.DgvGetSpaces, 2, 3);
            this.TlpMain.Controls.Add(this.CmbGetSpaces, 2, 1);
            this.TlpMain.Controls.Add(this.ChkGetSpaces, 3, 1);
            this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpMain.Location = new System.Drawing.Point(3, 3);
            this.TlpMain.Name = "TlpMain";
            this.TlpMain.RowCount = 5;
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.Size = new System.Drawing.Size(1046, 498);
            this.TlpMain.TabIndex = 0;
            // 
            // LblSpaceType
            // 
            this.LblSpaceType.AutoSize = true;
            this.LblSpaceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblSpaceType.Location = new System.Drawing.Point(23, 23);
            this.LblSpaceType.Margin = new System.Windows.Forms.Padding(3);
            this.LblSpaceType.Name = "LblSpaceType";
            this.LblSpaceType.Size = new System.Drawing.Size(68, 21);
            this.LblSpaceType.TabIndex = 0;
            this.LblSpaceType.Text = "Space Type:";
            this.LblSpaceType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnGetSpaces
            // 
            this.BtnGetSpaces.Location = new System.Drawing.Point(97, 50);
            this.BtnGetSpaces.Name = "BtnGetSpaces";
            this.BtnGetSpaces.Size = new System.Drawing.Size(75, 23);
            this.BtnGetSpaces.TabIndex = 2;
            this.BtnGetSpaces.Text = "GetSpaces";
            this.BtnGetSpaces.UseVisualStyleBackColor = true;
            this.BtnGetSpaces.Click += new System.EventHandler(this.BtnGetSpaces_Click);
            // 
            // DgvGetSpaces
            // 
            this.DgvGetSpaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TlpMain.SetColumnSpan(this.DgvGetSpaces, 2);
            this.DgvGetSpaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaces.Location = new System.Drawing.Point(97, 79);
            this.DgvGetSpaces.Name = "DgvGetSpaces";
            this.DgvGetSpaces.Size = new System.Drawing.Size(926, 396);
            this.DgvGetSpaces.TabIndex = 3;
            // 
            // TpgGetSpaceChildren
            // 
            this.TpgGetSpaceChildren.Controls.Add(this.TlpGetSpaceChildren);
            this.TpgGetSpaceChildren.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSpaceChildren.Name = "TpgGetSpaceChildren";
            this.TpgGetSpaceChildren.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSpaceChildren.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetSpaceChildren.TabIndex = 1;
            this.TpgGetSpaceChildren.Text = "GetSpaceChildren";
            this.TpgGetSpaceChildren.UseVisualStyleBackColor = true;
            // 
            // CmbGetSpaces
            // 
            this.CmbGetSpaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbGetSpaces.FormattingEnabled = true;
            this.CmbGetSpaces.Items.AddRange(new object[] {
            "- = Null",
            "0 = Generic",
            "1 = Building",
            "2 = Floor",
            "3 = Room"});
            this.CmbGetSpaces.Location = new System.Drawing.Point(97, 23);
            this.CmbGetSpaces.Name = "CmbGetSpaces";
            this.CmbGetSpaces.Size = new System.Drawing.Size(876, 21);
            this.CmbGetSpaces.TabIndex = 4;
            // 
            // ChkGetSpaces
            // 
            this.ChkGetSpaces.AutoSize = true;
            this.ChkGetSpaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkGetSpaces.Location = new System.Drawing.Point(979, 23);
            this.ChkGetSpaces.Name = "ChkGetSpaces";
            this.ChkGetSpaces.Size = new System.Drawing.Size(44, 21);
            this.ChkGetSpaces.TabIndex = 6;
            this.ChkGetSpaces.Text = "Null";
            this.ChkGetSpaces.UseVisualStyleBackColor = true;
            this.ChkGetSpaces.CheckedChanged += new System.EventHandler(this.ChkGetSpaces_CheckedChanged);
            // 
            // TpgGetSpaceEquipment
            // 
            this.TpgGetSpaceEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSpaceEquipment.Name = "TpgGetSpaceEquipment";
            this.TpgGetSpaceEquipment.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetSpaceEquipment.TabIndex = 2;
            this.TpgGetSpaceEquipment.Text = "GetSpaceEquipment";
            this.TpgGetSpaceEquipment.UseVisualStyleBackColor = true;
            // 
            // TpgGetSpaceTypes
            // 
            this.TpgGetSpaceTypes.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSpaceTypes.Name = "TpgGetSpaceTypes";
            this.TpgGetSpaceTypes.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetSpaceTypes.TabIndex = 3;
            this.TpgGetSpaceTypes.Text = "GetSpaceTypes";
            this.TpgGetSpaceTypes.UseVisualStyleBackColor = true;
            // 
            // TlpGetSpaceChildren
            // 
            this.TlpGetSpaceChildren.ColumnCount = 4;
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceChildren.Controls.Add(this.LblGetSpaceChildren_Guid, 1, 1);
            this.TlpGetSpaceChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSpaceChildren.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSpaceChildren.Name = "TlpGetSpaceChildren";
            this.TlpGetSpaceChildren.RowCount = 4;
            this.TlpGetSpaceChildren.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceChildren.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceChildren.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceChildren.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceChildren.Size = new System.Drawing.Size(1046, 498);
            this.TlpGetSpaceChildren.TabIndex = 0;
            // 
            // LblGetSpaceChildren_Guid
            // 
            this.LblGetSpaceChildren_Guid.AutoSize = true;
            this.LblGetSpaceChildren_Guid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSpaceChildren_Guid.Location = new System.Drawing.Point(23, 23);
            this.LblGetSpaceChildren_Guid.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSpaceChildren_Guid.Name = "LblGetSpaceChildren_Guid";
            this.LblGetSpaceChildren_Guid.Size = new System.Drawing.Size(91, 13);
            this.LblGetSpaceChildren_Guid.TabIndex = 0;
            this.LblGetSpaceChildren_Guid.Text = "Space ID (GUID):";
            this.LblGetSpaceChildren_Guid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Spaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.TabMain);
            this.Name = "Spaces";
            this.Text = "Spaces";
            this.TabMain.ResumeLayout(false);
            this.TpgGetSpaces.ResumeLayout(false);
            this.TlpMain.ResumeLayout(false);
            this.TlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaces)).EndInit();
            this.TpgGetSpaceChildren.ResumeLayout(false);
            this.TlpGetSpaceChildren.ResumeLayout(false);
            this.TlpGetSpaceChildren.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGetSpaces;
        private System.Windows.Forms.TabPage TpgGetSpaceChildren;
        private System.Windows.Forms.TableLayoutPanel TlpMain;
        private System.Windows.Forms.Label LblSpaceType;
        private System.Windows.Forms.Button BtnGetSpaces;
        private System.Windows.Forms.DataGridView DgvGetSpaces;
        private System.Windows.Forms.ComboBox CmbGetSpaces;
        private System.Windows.Forms.CheckBox ChkGetSpaces;
        private System.Windows.Forms.TabPage TpgGetSpaceEquipment;
        private System.Windows.Forms.TabPage TpgGetSpaceTypes;
        private System.Windows.Forms.TableLayoutPanel TlpGetSpaceChildren;
        private System.Windows.Forms.Label LblGetSpaceChildren_Guid;
    }
}