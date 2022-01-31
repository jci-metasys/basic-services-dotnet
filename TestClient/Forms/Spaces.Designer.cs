
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
            this.CmbGetSpaces = new System.Windows.Forms.ComboBox();
            this.ChkGetSpaces = new System.Windows.Forms.CheckBox();
            this.TpgGetSpaceChildren = new System.Windows.Forms.TabPage();
            this.TlpGetSpaceChildren = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSpaceChildren_Guid = new System.Windows.Forms.Label();
            this.BtnGetSpaceChildren = new System.Windows.Forms.Button();
            this.TxtGetSpaceChildren_SpaceID = new System.Windows.Forms.TextBox();
            this.DgvGetSpaceChildren = new System.Windows.Forms.DataGridView();
            this.TpgGetSpaceEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetSpaceEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSpaceEquipment_SpaceID = new System.Windows.Forms.Label();
            this.TxtGetSpaceEquipment_SpaceID = new System.Windows.Forms.TextBox();
            this.BtnGetSpaceEquipment = new System.Windows.Forms.Button();
            this.DgvGetSpaceEquipment = new System.Windows.Forms.DataGridView();
            this.TpgGetSpaceTypes = new System.Windows.Forms.TabPage();
            this.TlpGetSpaceTypes = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGetSpaceTypes = new System.Windows.Forms.Button();
            this.DgvGetSpaceTypes = new System.Windows.Forms.DataGridView();
            this.TabMain.SuspendLayout();
            this.TpgGetSpaces.SuspendLayout();
            this.TlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaces)).BeginInit();
            this.TpgGetSpaceChildren.SuspendLayout();
            this.TlpGetSpaceChildren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceChildren)).BeginInit();
            this.TpgGetSpaceEquipment.SuspendLayout();
            this.TlpGetSpaceEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceEquipment)).BeginInit();
            this.TpgGetSpaceTypes.SuspendLayout();
            this.TlpGetSpaceTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceTypes)).BeginInit();
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
            this.LblSpaceType.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblSpaceType.Name = "LblSpaceType";
            this.LblSpaceType.Size = new System.Drawing.Size(100, 21);
            this.LblSpaceType.TabIndex = 0;
            this.LblSpaceType.Text = "Space Type:";
            this.LblSpaceType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnGetSpaces
            // 
            this.BtnGetSpaces.Location = new System.Drawing.Point(129, 50);
            this.BtnGetSpaces.Name = "BtnGetSpaces";
            this.BtnGetSpaces.Size = new System.Drawing.Size(130, 23);
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
            this.DgvGetSpaces.Location = new System.Drawing.Point(129, 79);
            this.DgvGetSpaces.Name = "DgvGetSpaces";
            this.DgvGetSpaces.Size = new System.Drawing.Size(894, 396);
            this.DgvGetSpaces.TabIndex = 3;
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
            this.CmbGetSpaces.Location = new System.Drawing.Point(129, 23);
            this.CmbGetSpaces.Name = "CmbGetSpaces";
            this.CmbGetSpaces.Size = new System.Drawing.Size(844, 21);
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
            // TlpGetSpaceChildren
            // 
            this.TlpGetSpaceChildren.ColumnCount = 4;
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceChildren.Controls.Add(this.LblGetSpaceChildren_Guid, 1, 1);
            this.TlpGetSpaceChildren.Controls.Add(this.BtnGetSpaceChildren, 2, 2);
            this.TlpGetSpaceChildren.Controls.Add(this.TxtGetSpaceChildren_SpaceID, 2, 1);
            this.TlpGetSpaceChildren.Controls.Add(this.DgvGetSpaceChildren, 2, 3);
            this.TlpGetSpaceChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSpaceChildren.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSpaceChildren.Name = "TlpGetSpaceChildren";
            this.TlpGetSpaceChildren.RowCount = 5;
            this.TlpGetSpaceChildren.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceChildren.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.LblGetSpaceChildren_Guid.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetSpaceChildren_Guid.Name = "LblGetSpaceChildren_Guid";
            this.LblGetSpaceChildren_Guid.Size = new System.Drawing.Size(100, 20);
            this.LblGetSpaceChildren_Guid.TabIndex = 0;
            this.LblGetSpaceChildren_Guid.Text = "Space ID (GUID):";
            this.LblGetSpaceChildren_Guid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnGetSpaceChildren
            // 
            this.BtnGetSpaceChildren.Location = new System.Drawing.Point(129, 49);
            this.BtnGetSpaceChildren.Name = "BtnGetSpaceChildren";
            this.BtnGetSpaceChildren.Size = new System.Drawing.Size(130, 23);
            this.BtnGetSpaceChildren.TabIndex = 1;
            this.BtnGetSpaceChildren.Text = "GetSpaceChildren";
            this.BtnGetSpaceChildren.UseVisualStyleBackColor = true;
            this.BtnGetSpaceChildren.Click += new System.EventHandler(this.BtnGetSpaceChildren_Click);
            // 
            // TxtGetSpaceChildren_SpaceID
            // 
            this.TxtGetSpaceChildren_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetSpaceChildren_SpaceID.Location = new System.Drawing.Point(129, 23);
            this.TxtGetSpaceChildren_SpaceID.Name = "TxtGetSpaceChildren_SpaceID";
            this.TxtGetSpaceChildren_SpaceID.Size = new System.Drawing.Size(894, 20);
            this.TxtGetSpaceChildren_SpaceID.TabIndex = 2;
            // 
            // DgvGetSpaceChildren
            // 
            this.DgvGetSpaceChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSpaceChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaceChildren.Location = new System.Drawing.Point(129, 78);
            this.DgvGetSpaceChildren.Name = "DgvGetSpaceChildren";
            this.DgvGetSpaceChildren.Size = new System.Drawing.Size(894, 397);
            this.DgvGetSpaceChildren.TabIndex = 3;
            // 
            // TpgGetSpaceEquipment
            // 
            this.TpgGetSpaceEquipment.Controls.Add(this.TlpGetSpaceEquipment);
            this.TpgGetSpaceEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSpaceEquipment.Name = "TpgGetSpaceEquipment";
            this.TpgGetSpaceEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSpaceEquipment.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetSpaceEquipment.TabIndex = 2;
            this.TpgGetSpaceEquipment.Text = "GetSpaceEquipment";
            this.TpgGetSpaceEquipment.UseVisualStyleBackColor = true;
            // 
            // TlpGetSpaceEquipment
            // 
            this.TlpGetSpaceEquipment.ColumnCount = 4;
            this.TlpGetSpaceEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSpaceEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceEquipment.Controls.Add(this.LblGetSpaceEquipment_SpaceID, 1, 1);
            this.TlpGetSpaceEquipment.Controls.Add(this.TxtGetSpaceEquipment_SpaceID, 2, 1);
            this.TlpGetSpaceEquipment.Controls.Add(this.BtnGetSpaceEquipment, 2, 2);
            this.TlpGetSpaceEquipment.Controls.Add(this.DgvGetSpaceEquipment, 2, 3);
            this.TlpGetSpaceEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSpaceEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSpaceEquipment.Name = "TlpGetSpaceEquipment";
            this.TlpGetSpaceEquipment.RowCount = 5;
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceEquipment.Size = new System.Drawing.Size(1046, 498);
            this.TlpGetSpaceEquipment.TabIndex = 0;
            // 
            // LblGetSpaceEquipment_SpaceID
            // 
            this.LblGetSpaceEquipment_SpaceID.AutoSize = true;
            this.LblGetSpaceEquipment_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSpaceEquipment_SpaceID.Location = new System.Drawing.Point(23, 23);
            this.LblGetSpaceEquipment_SpaceID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSpaceEquipment_SpaceID.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetSpaceEquipment_SpaceID.Name = "LblGetSpaceEquipment_SpaceID";
            this.LblGetSpaceEquipment_SpaceID.Size = new System.Drawing.Size(100, 20);
            this.LblGetSpaceEquipment_SpaceID.TabIndex = 0;
            this.LblGetSpaceEquipment_SpaceID.Text = "Space ID (GUID):";
            this.LblGetSpaceEquipment_SpaceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetSpaceEquipment_SpaceID
            // 
            this.TxtGetSpaceEquipment_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetSpaceEquipment_SpaceID.Location = new System.Drawing.Point(129, 23);
            this.TxtGetSpaceEquipment_SpaceID.Name = "TxtGetSpaceEquipment_SpaceID";
            this.TxtGetSpaceEquipment_SpaceID.Size = new System.Drawing.Size(894, 20);
            this.TxtGetSpaceEquipment_SpaceID.TabIndex = 1;
            // 
            // BtnGetSpaceEquipment
            // 
            this.BtnGetSpaceEquipment.Location = new System.Drawing.Point(129, 49);
            this.BtnGetSpaceEquipment.Name = "BtnGetSpaceEquipment";
            this.BtnGetSpaceEquipment.Size = new System.Drawing.Size(130, 23);
            this.BtnGetSpaceEquipment.TabIndex = 2;
            this.BtnGetSpaceEquipment.Text = "GetSpaceEquipment";
            this.BtnGetSpaceEquipment.UseVisualStyleBackColor = true;
            this.BtnGetSpaceEquipment.Click += new System.EventHandler(this.BtnGetSpaceEquipment_Click);
            // 
            // DgvGetSpaceEquipment
            // 
            this.DgvGetSpaceEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSpaceEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaceEquipment.Location = new System.Drawing.Point(129, 78);
            this.DgvGetSpaceEquipment.Name = "DgvGetSpaceEquipment";
            this.DgvGetSpaceEquipment.Size = new System.Drawing.Size(894, 397);
            this.DgvGetSpaceEquipment.TabIndex = 3;
            // 
            // TpgGetSpaceTypes
            // 
            this.TpgGetSpaceTypes.Controls.Add(this.TlpGetSpaceTypes);
            this.TpgGetSpaceTypes.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSpaceTypes.Name = "TpgGetSpaceTypes";
            this.TpgGetSpaceTypes.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSpaceTypes.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetSpaceTypes.TabIndex = 3;
            this.TpgGetSpaceTypes.Text = "GetSpaceTypes";
            this.TpgGetSpaceTypes.UseVisualStyleBackColor = true;
            // 
            // TlpGetSpaceTypes
            // 
            this.TlpGetSpaceTypes.ColumnCount = 4;
            this.TlpGetSpaceTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.TlpGetSpaceTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceTypes.Controls.Add(this.BtnGetSpaceTypes, 2, 1);
            this.TlpGetSpaceTypes.Controls.Add(this.DgvGetSpaceTypes, 2, 2);
            this.TlpGetSpaceTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSpaceTypes.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSpaceTypes.Name = "TlpGetSpaceTypes";
            this.TlpGetSpaceTypes.RowCount = 4;
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceTypes.Size = new System.Drawing.Size(1046, 498);
            this.TlpGetSpaceTypes.TabIndex = 0;
            // 
            // BtnGetSpaceTypes
            // 
            this.BtnGetSpaceTypes.Location = new System.Drawing.Point(129, 23);
            this.BtnGetSpaceTypes.Name = "BtnGetSpaceTypes";
            this.BtnGetSpaceTypes.Size = new System.Drawing.Size(130, 23);
            this.BtnGetSpaceTypes.TabIndex = 0;
            this.BtnGetSpaceTypes.Text = "GetSpaceTypes";
            this.BtnGetSpaceTypes.UseVisualStyleBackColor = true;
            this.BtnGetSpaceTypes.Click += new System.EventHandler(this.BtnGetSpaceTypes_Click);
            // 
            // DgvGetSpaceTypes
            // 
            this.DgvGetSpaceTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSpaceTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaceTypes.Location = new System.Drawing.Point(129, 52);
            this.DgvGetSpaceTypes.Name = "DgvGetSpaceTypes";
            this.DgvGetSpaceTypes.Size = new System.Drawing.Size(894, 423);
            this.DgvGetSpaceTypes.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceChildren)).EndInit();
            this.TpgGetSpaceEquipment.ResumeLayout(false);
            this.TlpGetSpaceEquipment.ResumeLayout(false);
            this.TlpGetSpaceEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceEquipment)).EndInit();
            this.TpgGetSpaceTypes.ResumeLayout(false);
            this.TlpGetSpaceTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceTypes)).EndInit();
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
        private System.Windows.Forms.Button BtnGetSpaceChildren;
        private System.Windows.Forms.TextBox TxtGetSpaceChildren_SpaceID;
        private System.Windows.Forms.DataGridView DgvGetSpaceChildren;
        private System.Windows.Forms.TableLayoutPanel TlpGetSpaceEquipment;
        private System.Windows.Forms.Label LblGetSpaceEquipment_SpaceID;
        private System.Windows.Forms.TextBox TxtGetSpaceEquipment_SpaceID;
        private System.Windows.Forms.Button BtnGetSpaceEquipment;
        private System.Windows.Forms.DataGridView DgvGetSpaceEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetSpaceTypes;
        private System.Windows.Forms.Button BtnGetSpaceTypes;
        private System.Windows.Forms.DataGridView DgvGetSpaceTypes;
    }
}