﻿
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
            this.TpgGetSpaceTypes = new System.Windows.Forms.TabPage();
            this.TlpGetSpaceTypes = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGetSpaceTypes = new System.Windows.Forms.Button();
            this.DgvGetSpaceTypes = new System.Windows.Forms.DataGridView();
            this.TpgFindById = new System.Windows.Forms.TabPage();
            this.TlpFindById = new System.Windows.Forms.TableLayoutPanel();
            this.LblFindById_SpaceID = new System.Windows.Forms.Label();
            this.TxtFindById_SpaceID = new System.Windows.Forms.TextBox();
            this.BtnFindById = new System.Windows.Forms.Button();
            this.PrgFindById = new System.Windows.Forms.PropertyGrid();
            this.TpgGetServedByNetworkDevice = new System.Windows.Forms.TabPage();
            this.TlpGetServedByNetworkDevice = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetServedByNetworkDevice_NetworkDeviceID = new System.Windows.Forms.Label();
            this.TxtGetServedByNetworkDevice_NetworkDeviceID = new System.Windows.Forms.TextBox();
            this.BtnGetServedByNetworkDevice = new System.Windows.Forms.Button();
            this.DgvGetServedByNetworkDevice = new System.Windows.Forms.DataGridView();
            this.TpgGetServedByEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetServedByEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetServedByEquipment_EquipmentID = new System.Windows.Forms.Label();
            this.TxtGetServedByEquipment_EquipmentID = new System.Windows.Forms.TextBox();
            this.BtnGetServedByEquipment = new System.Windows.Forms.Button();
            this.DgvGetServedByEquipment = new System.Windows.Forms.DataGridView();
            this.TabMain.SuspendLayout();
            this.TpgGetSpaces.SuspendLayout();
            this.TlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaces)).BeginInit();
            this.TpgGetSpaceChildren.SuspendLayout();
            this.TlpGetSpaceChildren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceChildren)).BeginInit();
            this.TpgGetSpaceTypes.SuspendLayout();
            this.TlpGetSpaceTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceTypes)).BeginInit();
            this.TpgFindById.SuspendLayout();
            this.TlpFindById.SuspendLayout();
            this.TpgGetServedByNetworkDevice.SuspendLayout();
            this.TlpGetServedByNetworkDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServedByNetworkDevice)).BeginInit();
            this.TpgGetServedByEquipment.SuspendLayout();
            this.TlpGetServedByEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServedByEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetSpaces);
            this.TabMain.Controls.Add(this.TpgGetSpaceChildren);
            this.TabMain.Controls.Add(this.TpgGetSpaceTypes);
            this.TabMain.Controls.Add(this.TpgFindById);
            this.TabMain.Controls.Add(this.TpgGetServedByNetworkDevice);
            this.TabMain.Controls.Add(this.TpgGetServedByEquipment);
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
            this.TlpMain.RowCount = 4;
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
            this.LblSpaceType.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblSpaceType.Name = "LblSpaceType";
            this.LblSpaceType.Size = new System.Drawing.Size(140, 21);
            this.LblSpaceType.TabIndex = 0;
            this.LblSpaceType.Text = "Space Type (ENUM):";
            this.LblSpaceType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnGetSpaces
            // 
            this.BtnGetSpaces.Location = new System.Drawing.Point(169, 50);
            this.BtnGetSpaces.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetSpaces.Name = "BtnGetSpaces";
            this.BtnGetSpaces.Size = new System.Drawing.Size(260, 23);
            this.BtnGetSpaces.TabIndex = 2;
            this.BtnGetSpaces.Text = "GetSpaces | Spaces.Get";
            this.BtnGetSpaces.UseVisualStyleBackColor = true;
            this.BtnGetSpaces.Click += new System.EventHandler(this.BtnGetSpaces_Click);
            // 
            // DgvGetSpaces
            // 
            this.DgvGetSpaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TlpMain.SetColumnSpan(this.DgvGetSpaces, 2);
            this.DgvGetSpaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaces.Location = new System.Drawing.Point(169, 79);
            this.DgvGetSpaces.Name = "DgvGetSpaces";
            this.DgvGetSpaces.Size = new System.Drawing.Size(854, 416);
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
            this.CmbGetSpaces.Location = new System.Drawing.Point(169, 23);
            this.CmbGetSpaces.Name = "CmbGetSpaces";
            this.CmbGetSpaces.Size = new System.Drawing.Size(804, 21);
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
            this.TlpGetSpaceChildren.RowCount = 4;
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
            this.LblGetSpaceChildren_Guid.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetSpaceChildren_Guid.Name = "LblGetSpaceChildren_Guid";
            this.LblGetSpaceChildren_Guid.Size = new System.Drawing.Size(140, 20);
            this.LblGetSpaceChildren_Guid.TabIndex = 0;
            this.LblGetSpaceChildren_Guid.Text = "Space ID (GUID):";
            this.LblGetSpaceChildren_Guid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnGetSpaceChildren
            // 
            this.BtnGetSpaceChildren.Location = new System.Drawing.Point(169, 49);
            this.BtnGetSpaceChildren.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetSpaceChildren.Name = "BtnGetSpaceChildren";
            this.BtnGetSpaceChildren.Size = new System.Drawing.Size(260, 23);
            this.BtnGetSpaceChildren.TabIndex = 1;
            this.BtnGetSpaceChildren.Text = "GetSpaceChildren | Spaces.GetChildren";
            this.BtnGetSpaceChildren.UseVisualStyleBackColor = true;
            this.BtnGetSpaceChildren.Click += new System.EventHandler(this.BtnGetSpaceChildren_Click);
            // 
            // TxtGetSpaceChildren_SpaceID
            // 
            this.TxtGetSpaceChildren_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetSpaceChildren_SpaceID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetSpaceChildren_SpaceID.Name = "TxtGetSpaceChildren_SpaceID";
            this.TxtGetSpaceChildren_SpaceID.Size = new System.Drawing.Size(854, 20);
            this.TxtGetSpaceChildren_SpaceID.TabIndex = 2;
            // 
            // DgvGetSpaceChildren
            // 
            this.DgvGetSpaceChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSpaceChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaceChildren.Location = new System.Drawing.Point(169, 78);
            this.DgvGetSpaceChildren.Name = "DgvGetSpaceChildren";
            this.DgvGetSpaceChildren.Size = new System.Drawing.Size(854, 417);
            this.DgvGetSpaceChildren.TabIndex = 3;
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
            this.TlpGetSpaceTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.TlpGetSpaceTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceTypes.Controls.Add(this.BtnGetSpaceTypes, 2, 1);
            this.TlpGetSpaceTypes.Controls.Add(this.DgvGetSpaceTypes, 2, 2);
            this.TlpGetSpaceTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSpaceTypes.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSpaceTypes.Name = "TlpGetSpaceTypes";
            this.TlpGetSpaceTypes.RowCount = 3;
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSpaceTypes.Size = new System.Drawing.Size(1046, 498);
            this.TlpGetSpaceTypes.TabIndex = 0;
            // 
            // BtnGetSpaceTypes
            // 
            this.BtnGetSpaceTypes.Location = new System.Drawing.Point(169, 23);
            this.BtnGetSpaceTypes.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetSpaceTypes.Name = "BtnGetSpaceTypes";
            this.BtnGetSpaceTypes.Size = new System.Drawing.Size(260, 23);
            this.BtnGetSpaceTypes.TabIndex = 0;
            this.BtnGetSpaceTypes.Text = "GetSpaceTypes | Spaces.GetTypes";
            this.BtnGetSpaceTypes.UseVisualStyleBackColor = true;
            this.BtnGetSpaceTypes.Click += new System.EventHandler(this.BtnGetSpaceTypes_Click);
            // 
            // DgvGetSpaceTypes
            // 
            this.DgvGetSpaceTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSpaceTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaceTypes.Location = new System.Drawing.Point(169, 52);
            this.DgvGetSpaceTypes.Name = "DgvGetSpaceTypes";
            this.DgvGetSpaceTypes.Size = new System.Drawing.Size(854, 443);
            this.DgvGetSpaceTypes.TabIndex = 1;
            // 
            // TpgFindById
            // 
            this.TpgFindById.Controls.Add(this.TlpFindById);
            this.TpgFindById.Location = new System.Drawing.Point(4, 29);
            this.TpgFindById.Name = "TpgFindById";
            this.TpgFindById.Padding = new System.Windows.Forms.Padding(3);
            this.TpgFindById.Size = new System.Drawing.Size(1052, 504);
            this.TpgFindById.TabIndex = 4;
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
            this.TlpFindById.Controls.Add(this.LblFindById_SpaceID, 1, 1);
            this.TlpFindById.Controls.Add(this.TxtFindById_SpaceID, 2, 1);
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
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.Size = new System.Drawing.Size(1046, 498);
            this.TlpFindById.TabIndex = 0;
            // 
            // LblFindById_SpaceID
            // 
            this.LblFindById_SpaceID.AutoSize = true;
            this.LblFindById_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFindById_SpaceID.Location = new System.Drawing.Point(23, 23);
            this.LblFindById_SpaceID.Margin = new System.Windows.Forms.Padding(3);
            this.LblFindById_SpaceID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblFindById_SpaceID.Name = "LblFindById_SpaceID";
            this.LblFindById_SpaceID.Size = new System.Drawing.Size(140, 20);
            this.LblFindById_SpaceID.TabIndex = 0;
            this.LblFindById_SpaceID.Text = "Space ID (GUID):";
            this.LblFindById_SpaceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtFindById_SpaceID
            // 
            this.TxtFindById_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFindById_SpaceID.Location = new System.Drawing.Point(169, 23);
            this.TxtFindById_SpaceID.Name = "TxtFindById_SpaceID";
            this.TxtFindById_SpaceID.Size = new System.Drawing.Size(854, 20);
            this.TxtFindById_SpaceID.TabIndex = 1;
            // 
            // BtnFindById
            // 
            this.BtnFindById.Location = new System.Drawing.Point(169, 49);
            this.BtnFindById.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnFindById.Name = "BtnFindById";
            this.BtnFindById.Size = new System.Drawing.Size(260, 23);
            this.BtnFindById.TabIndex = 2;
            this.BtnFindById.Text = "Spaces.FindById";
            this.BtnFindById.UseVisualStyleBackColor = true;
            this.BtnFindById.Click += new System.EventHandler(this.BtnFindById_Click);
            // 
            // PrgFindById
            // 
            this.PrgFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrgFindById.HelpVisible = false;
            this.PrgFindById.Location = new System.Drawing.Point(169, 78);
            this.PrgFindById.Name = "PrgFindById";
            this.PrgFindById.Size = new System.Drawing.Size(854, 417);
            this.PrgFindById.TabIndex = 3;
            // 
            // TpgGetServedByNetworkDevice
            // 
            this.TpgGetServedByNetworkDevice.Controls.Add(this.TlpGetServedByNetworkDevice);
            this.TpgGetServedByNetworkDevice.Location = new System.Drawing.Point(4, 29);
            this.TpgGetServedByNetworkDevice.Name = "TpgGetServedByNetworkDevice";
            this.TpgGetServedByNetworkDevice.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetServedByNetworkDevice.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetServedByNetworkDevice.TabIndex = 5;
            this.TpgGetServedByNetworkDevice.Text = "GetServedByNetworkDevice";
            this.TpgGetServedByNetworkDevice.UseVisualStyleBackColor = true;
            // 
            // TlpGetServedByNetworkDevice
            // 
            this.TlpGetServedByNetworkDevice.ColumnCount = 4;
            this.TlpGetServedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetServedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByNetworkDevice.Controls.Add(this.LblGetServedByNetworkDevice_NetworkDeviceID, 1, 1);
            this.TlpGetServedByNetworkDevice.Controls.Add(this.TxtGetServedByNetworkDevice_NetworkDeviceID, 2, 1);
            this.TlpGetServedByNetworkDevice.Controls.Add(this.BtnGetServedByNetworkDevice, 2, 2);
            this.TlpGetServedByNetworkDevice.Controls.Add(this.DgvGetServedByNetworkDevice, 2, 3);
            this.TlpGetServedByNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetServedByNetworkDevice.Location = new System.Drawing.Point(3, 3);
            this.TlpGetServedByNetworkDevice.Name = "TlpGetServedByNetworkDevice";
            this.TlpGetServedByNetworkDevice.RowCount = 4;
            this.TlpGetServedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByNetworkDevice.Size = new System.Drawing.Size(1046, 498);
            this.TlpGetServedByNetworkDevice.TabIndex = 0;
            // 
            // LblGetServedByNetworkDevice_NetworkDeviceID
            // 
            this.LblGetServedByNetworkDevice_NetworkDeviceID.AutoSize = true;
            this.LblGetServedByNetworkDevice_NetworkDeviceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServedByNetworkDevice_NetworkDeviceID.Location = new System.Drawing.Point(23, 23);
            this.LblGetServedByNetworkDevice_NetworkDeviceID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetServedByNetworkDevice_NetworkDeviceID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetServedByNetworkDevice_NetworkDeviceID.Name = "LblGetServedByNetworkDevice_NetworkDeviceID";
            this.LblGetServedByNetworkDevice_NetworkDeviceID.Size = new System.Drawing.Size(140, 20);
            this.LblGetServedByNetworkDevice_NetworkDeviceID.TabIndex = 0;
            this.LblGetServedByNetworkDevice_NetworkDeviceID.Text = "Network Device ID (GUID):";
            this.LblGetServedByNetworkDevice_NetworkDeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetServedByNetworkDevice_NetworkDeviceID
            // 
            this.TxtGetServedByNetworkDevice_NetworkDeviceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetServedByNetworkDevice_NetworkDeviceID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetServedByNetworkDevice_NetworkDeviceID.Name = "TxtGetServedByNetworkDevice_NetworkDeviceID";
            this.TxtGetServedByNetworkDevice_NetworkDeviceID.Size = new System.Drawing.Size(854, 20);
            this.TxtGetServedByNetworkDevice_NetworkDeviceID.TabIndex = 1;
            // 
            // BtnGetServedByNetworkDevice
            // 
            this.BtnGetServedByNetworkDevice.Location = new System.Drawing.Point(169, 49);
            this.BtnGetServedByNetworkDevice.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetServedByNetworkDevice.Name = "BtnGetServedByNetworkDevice";
            this.BtnGetServedByNetworkDevice.Size = new System.Drawing.Size(260, 23);
            this.BtnGetServedByNetworkDevice.TabIndex = 2;
            this.BtnGetServedByNetworkDevice.Text = "Spaces.GetServedByNetworkDevice";
            this.BtnGetServedByNetworkDevice.UseVisualStyleBackColor = true;
            this.BtnGetServedByNetworkDevice.Click += new System.EventHandler(this.BtnGetServedByNetworkDevice_Click);
            // 
            // DgvGetServedByNetworkDevice
            // 
            this.DgvGetServedByNetworkDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetServedByNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetServedByNetworkDevice.Location = new System.Drawing.Point(169, 78);
            this.DgvGetServedByNetworkDevice.Name = "DgvGetServedByNetworkDevice";
            this.DgvGetServedByNetworkDevice.Size = new System.Drawing.Size(854, 417);
            this.DgvGetServedByNetworkDevice.TabIndex = 3;
            // 
            // TpgGetServedByEquipment
            // 
            this.TpgGetServedByEquipment.Controls.Add(this.TlpGetServedByEquipment);
            this.TpgGetServedByEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetServedByEquipment.Name = "TpgGetServedByEquipment";
            this.TpgGetServedByEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetServedByEquipment.Size = new System.Drawing.Size(1052, 504);
            this.TpgGetServedByEquipment.TabIndex = 6;
            this.TpgGetServedByEquipment.Text = "GetServedByEquipment";
            this.TpgGetServedByEquipment.UseVisualStyleBackColor = true;
            // 
            // TlpGetServedByEquipment
            // 
            this.TlpGetServedByEquipment.ColumnCount = 4;
            this.TlpGetServedByEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetServedByEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServedByEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByEquipment.Controls.Add(this.LblGetServedByEquipment_EquipmentID, 1, 1);
            this.TlpGetServedByEquipment.Controls.Add(this.TxtGetServedByEquipment_EquipmentID, 2, 1);
            this.TlpGetServedByEquipment.Controls.Add(this.BtnGetServedByEquipment, 2, 2);
            this.TlpGetServedByEquipment.Controls.Add(this.DgvGetServedByEquipment, 2, 3);
            this.TlpGetServedByEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetServedByEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetServedByEquipment.Name = "TlpGetServedByEquipment";
            this.TlpGetServedByEquipment.RowCount = 4;
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByEquipment.Size = new System.Drawing.Size(1046, 498);
            this.TlpGetServedByEquipment.TabIndex = 0;
            // 
            // LblGetServedByEquipment_EquipmentID
            // 
            this.LblGetServedByEquipment_EquipmentID.AutoSize = true;
            this.LblGetServedByEquipment_EquipmentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServedByEquipment_EquipmentID.Location = new System.Drawing.Point(23, 23);
            this.LblGetServedByEquipment_EquipmentID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetServedByEquipment_EquipmentID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetServedByEquipment_EquipmentID.Name = "LblGetServedByEquipment_EquipmentID";
            this.LblGetServedByEquipment_EquipmentID.Size = new System.Drawing.Size(140, 20);
            this.LblGetServedByEquipment_EquipmentID.TabIndex = 0;
            this.LblGetServedByEquipment_EquipmentID.Text = "Equipment ID (GUID):";
            this.LblGetServedByEquipment_EquipmentID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetServedByEquipment_EquipmentID
            // 
            this.TxtGetServedByEquipment_EquipmentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetServedByEquipment_EquipmentID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetServedByEquipment_EquipmentID.Name = "TxtGetServedByEquipment_EquipmentID";
            this.TxtGetServedByEquipment_EquipmentID.Size = new System.Drawing.Size(854, 20);
            this.TxtGetServedByEquipment_EquipmentID.TabIndex = 1;
            // 
            // BtnGetServedByEquipment
            // 
            this.BtnGetServedByEquipment.Location = new System.Drawing.Point(169, 49);
            this.BtnGetServedByEquipment.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetServedByEquipment.Name = "BtnGetServedByEquipment";
            this.BtnGetServedByEquipment.Size = new System.Drawing.Size(260, 23);
            this.BtnGetServedByEquipment.TabIndex = 2;
            this.BtnGetServedByEquipment.Text = "Spaces.GetServedByEquipment";
            this.BtnGetServedByEquipment.UseVisualStyleBackColor = true;
            this.BtnGetServedByEquipment.Click += new System.EventHandler(this.BtnGetServedByEquipment_Click);
            // 
            // DgvGetServedByEquipment
            // 
            this.DgvGetServedByEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetServedByEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetServedByEquipment.Location = new System.Drawing.Point(169, 78);
            this.DgvGetServedByEquipment.Name = "DgvGetServedByEquipment";
            this.DgvGetServedByEquipment.Size = new System.Drawing.Size(854, 417);
            this.DgvGetServedByEquipment.TabIndex = 3;
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
            this.TpgGetSpaceTypes.ResumeLayout(false);
            this.TlpGetSpaceTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceTypes)).EndInit();
            this.TpgFindById.ResumeLayout(false);
            this.TlpFindById.ResumeLayout(false);
            this.TlpFindById.PerformLayout();
            this.TpgGetServedByNetworkDevice.ResumeLayout(false);
            this.TlpGetServedByNetworkDevice.ResumeLayout(false);
            this.TlpGetServedByNetworkDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServedByNetworkDevice)).EndInit();
            this.TpgGetServedByEquipment.ResumeLayout(false);
            this.TlpGetServedByEquipment.ResumeLayout(false);
            this.TlpGetServedByEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServedByEquipment)).EndInit();
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
        private System.Windows.Forms.TabPage TpgGetSpaceTypes;
        private System.Windows.Forms.TableLayoutPanel TlpGetSpaceChildren;
        private System.Windows.Forms.Label LblGetSpaceChildren_Guid;
        private System.Windows.Forms.Button BtnGetSpaceChildren;
        private System.Windows.Forms.TextBox TxtGetSpaceChildren_SpaceID;
        private System.Windows.Forms.DataGridView DgvGetSpaceChildren;
        private System.Windows.Forms.TableLayoutPanel TlpGetSpaceTypes;
        private System.Windows.Forms.Button BtnGetSpaceTypes;
        private System.Windows.Forms.DataGridView DgvGetSpaceTypes;
        private System.Windows.Forms.TabPage TpgFindById;
        private System.Windows.Forms.TableLayoutPanel TlpFindById;
        private System.Windows.Forms.Label LblFindById_SpaceID;
        private System.Windows.Forms.TextBox TxtFindById_SpaceID;
        private System.Windows.Forms.Button BtnFindById;
        private System.Windows.Forms.PropertyGrid PrgFindById;
        private System.Windows.Forms.TabPage TpgGetServedByNetworkDevice;
        private System.Windows.Forms.TableLayoutPanel TlpGetServedByNetworkDevice;
        private System.Windows.Forms.Label LblGetServedByNetworkDevice_NetworkDeviceID;
        private System.Windows.Forms.TextBox TxtGetServedByNetworkDevice_NetworkDeviceID;
        private System.Windows.Forms.Button BtnGetServedByNetworkDevice;
        private System.Windows.Forms.DataGridView DgvGetServedByNetworkDevice;
        private System.Windows.Forms.TabPage TpgGetServedByEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetServedByEquipment;
        private System.Windows.Forms.Label LblGetServedByEquipment_EquipmentID;
        private System.Windows.Forms.TextBox TxtGetServedByEquipment_EquipmentID;
        private System.Windows.Forms.Button BtnGetServedByEquipment;
        private System.Windows.Forms.DataGridView DgvGetServedByEquipment;
    }
}