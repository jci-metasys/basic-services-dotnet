
namespace MetasysServices_TestClient.Forms
{
    partial class NetworkDevices
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
            this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetTypes_TypeID = new System.Windows.Forms.Label();
            this.TxtGetTypes_TypeID = new System.Windows.Forms.TextBox();
            this.DgvGet = new System.Windows.Forms.DataGridView();
            this.BtnGet = new System.Windows.Forms.Button();
            this.TpgGetTypes = new System.Windows.Forms.TabPage();
            this.TlpGetTypes = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGetTypes = new System.Windows.Forms.Button();
            this.DgvGetTypes = new System.Windows.Forms.DataGridView();
            this.TpgFindById = new System.Windows.Forms.TabPage();
            this.TlpFindById = new System.Windows.Forms.TableLayoutPanel();
            this.LblFindById_NetworkDeviceID = new System.Windows.Forms.Label();
            this.TxtFindById_NetworkDeviceID = new System.Windows.Forms.TextBox();
            this.BtnFindById = new System.Windows.Forms.Button();
            this.PrgFindById = new System.Windows.Forms.PropertyGrid();
            this.TpgGetChildren = new System.Windows.Forms.TabPage();
            this.TlpGetChildren = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetChildren_NetworkDeviceID = new System.Windows.Forms.Label();
            this.TxtGetChildren_NetworkDeviceID = new System.Windows.Forms.TextBox();
            this.BtnGetChildren = new System.Windows.Forms.Button();
            this.DgvGetChildren = new System.Windows.Forms.DataGridView();
            this.TpgGetHostingAnEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetHostingAnEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetHostingAnEquipment_EquipmentID = new System.Windows.Forms.Label();
            this.TxtGetHostingAnEquipment_EquipmentID = new System.Windows.Forms.TextBox();
            this.BtnGetHostingAnEquipment = new System.Windows.Forms.Button();
            this.DgvGetHostingAnEquipment = new System.Windows.Forms.DataGridView();
            this.TpgGetServingASpace = new System.Windows.Forms.TabPage();
            this.TlpGetServingASpace = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetServingASpace_SpaceID = new System.Windows.Forms.Label();
            this.TxtGetServingASpace_SpaceID = new System.Windows.Forms.TextBox();
            this.BtnGetServingASpace = new System.Windows.Forms.Button();
            this.DgvGetServingASpace = new System.Windows.Forms.DataGridView();
            this.TabMain.SuspendLayout();
            this.TpgGet.SuspendLayout();
            this.TlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGet)).BeginInit();
            this.TpgGetTypes.SuspendLayout();
            this.TlpGetTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetTypes)).BeginInit();
            this.TpgFindById.SuspendLayout();
            this.TlpFindById.SuspendLayout();
            this.TpgGetChildren.SuspendLayout();
            this.TlpGetChildren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetChildren)).BeginInit();
            this.TpgGetHostingAnEquipment.SuspendLayout();
            this.TlpGetHostingAnEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetHostingAnEquipment)).BeginInit();
            this.TpgGetServingASpace.SuspendLayout();
            this.TlpGetServingASpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServingASpace)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGet);
            this.TabMain.Controls.Add(this.TpgGetTypes);
            this.TabMain.Controls.Add(this.TpgFindById);
            this.TabMain.Controls.Add(this.TpgGetChildren);
            this.TabMain.Controls.Add(this.TpgGetHostingAnEquipment);
            this.TabMain.Controls.Add(this.TpgGetServingASpace);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(941, 602);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGet
            // 
            this.TpgGet.Controls.Add(this.TlpMain);
            this.TpgGet.Location = new System.Drawing.Point(4, 29);
            this.TpgGet.Name = "TpgGet";
            this.TpgGet.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGet.Size = new System.Drawing.Size(933, 569);
            this.TpgGet.TabIndex = 0;
            this.TpgGet.Text = "GetNetworkDevices";
            this.TpgGet.UseVisualStyleBackColor = true;
            // 
            // TlpMain
            // 
            this.TlpMain.ColumnCount = 4;
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.Controls.Add(this.LblGetTypes_TypeID, 1, 1);
            this.TlpMain.Controls.Add(this.TxtGetTypes_TypeID, 2, 1);
            this.TlpMain.Controls.Add(this.DgvGet, 2, 3);
            this.TlpMain.Controls.Add(this.BtnGet, 2, 2);
            this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpMain.Location = new System.Drawing.Point(3, 3);
            this.TlpMain.Name = "TlpMain";
            this.TlpMain.RowCount = 5;
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpMain.Size = new System.Drawing.Size(927, 563);
            this.TlpMain.TabIndex = 0;
            // 
            // LblGetTypes_TypeID
            // 
            this.LblGetTypes_TypeID.AutoSize = true;
            this.LblGetTypes_TypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetTypes_TypeID.Location = new System.Drawing.Point(23, 23);
            this.LblGetTypes_TypeID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetTypes_TypeID.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetTypes_TypeID.Name = "LblGetTypes_TypeID";
            this.LblGetTypes_TypeID.Size = new System.Drawing.Size(100, 20);
            this.LblGetTypes_TypeID.TabIndex = 0;
            this.LblGetTypes_TypeID.Text = "Type ID:";
            this.LblGetTypes_TypeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetTypes_TypeID
            // 
            this.TxtGetTypes_TypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetTypes_TypeID.Location = new System.Drawing.Point(129, 23);
            this.TxtGetTypes_TypeID.Name = "TxtGetTypes_TypeID";
            this.TxtGetTypes_TypeID.Size = new System.Drawing.Size(775, 20);
            this.TxtGetTypes_TypeID.TabIndex = 1;
            // 
            // DgvGet
            // 
            this.DgvGet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGet.Location = new System.Drawing.Point(129, 78);
            this.DgvGet.Name = "DgvGet";
            this.DgvGet.Size = new System.Drawing.Size(775, 462);
            this.DgvGet.TabIndex = 3;
            // 
            // BtnGet
            // 
            this.BtnGet.Location = new System.Drawing.Point(129, 49);
            this.BtnGet.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGet.Name = "BtnGet";
            this.BtnGet.Size = new System.Drawing.Size(260, 23);
            this.BtnGet.TabIndex = 4;
            this.BtnGet.Text = "GetNetworkDevices";
            this.BtnGet.UseVisualStyleBackColor = true;
            this.BtnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // TpgGetTypes
            // 
            this.TpgGetTypes.Controls.Add(this.TlpGetTypes);
            this.TpgGetTypes.Location = new System.Drawing.Point(4, 29);
            this.TpgGetTypes.Name = "TpgGetTypes";
            this.TpgGetTypes.Size = new System.Drawing.Size(933, 569);
            this.TpgGetTypes.TabIndex = 2;
            this.TpgGetTypes.Text = "GetNetworkDeviceTypes";
            this.TpgGetTypes.UseVisualStyleBackColor = true;
            // 
            // TlpGetTypes
            // 
            this.TlpGetTypes.ColumnCount = 4;
            this.TlpGetTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.TlpGetTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTypes.Controls.Add(this.BtnGetTypes, 2, 1);
            this.TlpGetTypes.Controls.Add(this.DgvGetTypes, 2, 2);
            this.TlpGetTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetTypes.Location = new System.Drawing.Point(0, 0);
            this.TlpGetTypes.Name = "TlpGetTypes";
            this.TlpGetTypes.RowCount = 4;
            this.TlpGetTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTypes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetTypes.Size = new System.Drawing.Size(933, 569);
            this.TlpGetTypes.TabIndex = 0;
            // 
            // BtnGetTypes
            // 
            this.BtnGetTypes.Location = new System.Drawing.Point(129, 23);
            this.BtnGetTypes.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetTypes.Name = "BtnGetTypes";
            this.BtnGetTypes.Size = new System.Drawing.Size(260, 23);
            this.BtnGetTypes.TabIndex = 0;
            this.BtnGetTypes.Text = "GetNetworkDeviceTypes";
            this.BtnGetTypes.UseVisualStyleBackColor = true;
            this.BtnGetTypes.Click += new System.EventHandler(this.BtnGetTypes_Click);
            // 
            // DgvGetTypes
            // 
            this.DgvGetTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetTypes.Location = new System.Drawing.Point(129, 52);
            this.DgvGetTypes.Name = "DgvGetTypes";
            this.DgvGetTypes.Size = new System.Drawing.Size(781, 494);
            this.DgvGetTypes.TabIndex = 1;
            // 
            // TpgFindById
            // 
            this.TpgFindById.Controls.Add(this.TlpFindById);
            this.TpgFindById.Location = new System.Drawing.Point(4, 29);
            this.TpgFindById.Name = "TpgFindById";
            this.TpgFindById.Padding = new System.Windows.Forms.Padding(3);
            this.TpgFindById.Size = new System.Drawing.Size(933, 569);
            this.TpgFindById.TabIndex = 1;
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
            this.TlpFindById.Controls.Add(this.LblFindById_NetworkDeviceID, 1, 1);
            this.TlpFindById.Controls.Add(this.TxtFindById_NetworkDeviceID, 2, 1);
            this.TlpFindById.Controls.Add(this.BtnFindById, 2, 2);
            this.TlpFindById.Controls.Add(this.PrgFindById, 2, 3);
            this.TlpFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpFindById.Location = new System.Drawing.Point(3, 3);
            this.TlpFindById.Name = "TlpFindById";
            this.TlpFindById.RowCount = 5;
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.Size = new System.Drawing.Size(927, 563);
            this.TlpFindById.TabIndex = 0;
            // 
            // LblFindById_NetworkDeviceID
            // 
            this.LblFindById_NetworkDeviceID.AutoSize = true;
            this.LblFindById_NetworkDeviceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFindById_NetworkDeviceID.Location = new System.Drawing.Point(23, 23);
            this.LblFindById_NetworkDeviceID.Margin = new System.Windows.Forms.Padding(3);
            this.LblFindById_NetworkDeviceID.Name = "LblFindById_NetworkDeviceID";
            this.LblFindById_NetworkDeviceID.Size = new System.Drawing.Size(137, 20);
            this.LblFindById_NetworkDeviceID.TabIndex = 0;
            this.LblFindById_NetworkDeviceID.Text = "Network Device ID (GUID):";
            this.LblFindById_NetworkDeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtFindById_NetworkDeviceID
            // 
            this.TxtFindById_NetworkDeviceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFindById_NetworkDeviceID.Location = new System.Drawing.Point(166, 23);
            this.TxtFindById_NetworkDeviceID.Name = "TxtFindById_NetworkDeviceID";
            this.TxtFindById_NetworkDeviceID.Size = new System.Drawing.Size(738, 20);
            this.TxtFindById_NetworkDeviceID.TabIndex = 1;
            // 
            // BtnFindById
            // 
            this.BtnFindById.Location = new System.Drawing.Point(166, 49);
            this.BtnFindById.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnFindById.Name = "BtnFindById";
            this.BtnFindById.Size = new System.Drawing.Size(260, 23);
            this.BtnFindById.TabIndex = 2;
            this.BtnFindById.Text = "NetworkDevices.FindById";
            this.BtnFindById.UseVisualStyleBackColor = true;
            this.BtnFindById.Click += new System.EventHandler(this.BtnFindById_Click);
            // 
            // PrgFindById
            // 
            this.PrgFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrgFindById.HelpVisible = false;
            this.PrgFindById.Location = new System.Drawing.Point(166, 78);
            this.PrgFindById.Name = "PrgFindById";
            this.PrgFindById.Size = new System.Drawing.Size(738, 462);
            this.PrgFindById.TabIndex = 3;
            // 
            // TpgGetChildren
            // 
            this.TpgGetChildren.Controls.Add(this.TlpGetChildren);
            this.TpgGetChildren.Location = new System.Drawing.Point(4, 29);
            this.TpgGetChildren.Name = "TpgGetChildren";
            this.TpgGetChildren.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetChildren.Size = new System.Drawing.Size(933, 569);
            this.TpgGetChildren.TabIndex = 3;
            this.TpgGetChildren.Text = "GetChildren";
            this.TpgGetChildren.UseVisualStyleBackColor = true;
            // 
            // TlpGetChildren
            // 
            this.TlpGetChildren.ColumnCount = 4;
            this.TlpGetChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetChildren.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetChildren.Controls.Add(this.LblGetChildren_NetworkDeviceID, 1, 1);
            this.TlpGetChildren.Controls.Add(this.TxtGetChildren_NetworkDeviceID, 2, 1);
            this.TlpGetChildren.Controls.Add(this.BtnGetChildren, 2, 2);
            this.TlpGetChildren.Controls.Add(this.DgvGetChildren, 2, 3);
            this.TlpGetChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetChildren.Location = new System.Drawing.Point(3, 3);
            this.TlpGetChildren.Name = "TlpGetChildren";
            this.TlpGetChildren.RowCount = 5;
            this.TlpGetChildren.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetChildren.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetChildren.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetChildren.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetChildren.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetChildren.Size = new System.Drawing.Size(927, 563);
            this.TlpGetChildren.TabIndex = 0;
            // 
            // LblGetChildren_NetworkDeviceID
            // 
            this.LblGetChildren_NetworkDeviceID.AutoSize = true;
            this.LblGetChildren_NetworkDeviceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetChildren_NetworkDeviceID.Location = new System.Drawing.Point(23, 23);
            this.LblGetChildren_NetworkDeviceID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetChildren_NetworkDeviceID.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetChildren_NetworkDeviceID.Name = "LblGetChildren_NetworkDeviceID";
            this.LblGetChildren_NetworkDeviceID.Size = new System.Drawing.Size(137, 20);
            this.LblGetChildren_NetworkDeviceID.TabIndex = 0;
            this.LblGetChildren_NetworkDeviceID.Text = "Network Device ID (GUID):";
            this.LblGetChildren_NetworkDeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetChildren_NetworkDeviceID
            // 
            this.TxtGetChildren_NetworkDeviceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetChildren_NetworkDeviceID.Location = new System.Drawing.Point(166, 23);
            this.TxtGetChildren_NetworkDeviceID.Name = "TxtGetChildren_NetworkDeviceID";
            this.TxtGetChildren_NetworkDeviceID.Size = new System.Drawing.Size(738, 20);
            this.TxtGetChildren_NetworkDeviceID.TabIndex = 1;
            // 
            // BtnGetChildren
            // 
            this.BtnGetChildren.Location = new System.Drawing.Point(166, 49);
            this.BtnGetChildren.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetChildren.Name = "BtnGetChildren";
            this.BtnGetChildren.Size = new System.Drawing.Size(260, 23);
            this.BtnGetChildren.TabIndex = 2;
            this.BtnGetChildren.Text = "NetworkDevices.GetChildren";
            this.BtnGetChildren.UseVisualStyleBackColor = true;
            this.BtnGetChildren.Click += new System.EventHandler(this.BtnGetChildren_Click);
            // 
            // DgvGetChildren
            // 
            this.DgvGetChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetChildren.Location = new System.Drawing.Point(166, 78);
            this.DgvGetChildren.Name = "DgvGetChildren";
            this.DgvGetChildren.Size = new System.Drawing.Size(738, 462);
            this.DgvGetChildren.TabIndex = 3;
            // 
            // TpgGetHostingAnEquipment
            // 
            this.TpgGetHostingAnEquipment.Controls.Add(this.TlpGetHostingAnEquipment);
            this.TpgGetHostingAnEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetHostingAnEquipment.Name = "TpgGetHostingAnEquipment";
            this.TpgGetHostingAnEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetHostingAnEquipment.Size = new System.Drawing.Size(933, 569);
            this.TpgGetHostingAnEquipment.TabIndex = 4;
            this.TpgGetHostingAnEquipment.Text = "GetHostingAnEquipment";
            this.TpgGetHostingAnEquipment.UseVisualStyleBackColor = true;
            // 
            // TlpGetHostingAnEquipment
            // 
            this.TlpGetHostingAnEquipment.ColumnCount = 4;
            this.TlpGetHostingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetHostingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetHostingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostingAnEquipment.Controls.Add(this.LblGetHostingAnEquipment_EquipmentID, 1, 1);
            this.TlpGetHostingAnEquipment.Controls.Add(this.TxtGetHostingAnEquipment_EquipmentID, 2, 1);
            this.TlpGetHostingAnEquipment.Controls.Add(this.BtnGetHostingAnEquipment, 2, 2);
            this.TlpGetHostingAnEquipment.Controls.Add(this.DgvGetHostingAnEquipment, 2, 3);
            this.TlpGetHostingAnEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetHostingAnEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetHostingAnEquipment.Name = "TlpGetHostingAnEquipment";
            this.TlpGetHostingAnEquipment.RowCount = 5;
            this.TlpGetHostingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetHostingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetHostingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetHostingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostingAnEquipment.Size = new System.Drawing.Size(927, 563);
            this.TlpGetHostingAnEquipment.TabIndex = 0;
            // 
            // LblGetHostingAnEquipment_EquipmentID
            // 
            this.LblGetHostingAnEquipment_EquipmentID.AutoSize = true;
            this.LblGetHostingAnEquipment_EquipmentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetHostingAnEquipment_EquipmentID.Location = new System.Drawing.Point(23, 23);
            this.LblGetHostingAnEquipment_EquipmentID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetHostingAnEquipment_EquipmentID.Name = "LblGetHostingAnEquipment_EquipmentID";
            this.LblGetHostingAnEquipment_EquipmentID.Size = new System.Drawing.Size(110, 20);
            this.LblGetHostingAnEquipment_EquipmentID.TabIndex = 0;
            this.LblGetHostingAnEquipment_EquipmentID.Text = "Equipment ID (GUID):";
            this.LblGetHostingAnEquipment_EquipmentID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetHostingAnEquipment_EquipmentID
            // 
            this.TxtGetHostingAnEquipment_EquipmentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetHostingAnEquipment_EquipmentID.Location = new System.Drawing.Point(139, 23);
            this.TxtGetHostingAnEquipment_EquipmentID.Name = "TxtGetHostingAnEquipment_EquipmentID";
            this.TxtGetHostingAnEquipment_EquipmentID.Size = new System.Drawing.Size(765, 20);
            this.TxtGetHostingAnEquipment_EquipmentID.TabIndex = 1;
            // 
            // BtnGetHostingAnEquipment
            // 
            this.BtnGetHostingAnEquipment.Location = new System.Drawing.Point(139, 49);
            this.BtnGetHostingAnEquipment.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetHostingAnEquipment.Name = "BtnGetHostingAnEquipment";
            this.BtnGetHostingAnEquipment.Size = new System.Drawing.Size(260, 23);
            this.BtnGetHostingAnEquipment.TabIndex = 2;
            this.BtnGetHostingAnEquipment.Text = "GetHostingAnEquipment";
            this.BtnGetHostingAnEquipment.UseVisualStyleBackColor = true;
            this.BtnGetHostingAnEquipment.Click += new System.EventHandler(this.BtnGetHostingAnEquipment_Click);
            // 
            // DgvGetHostingAnEquipment
            // 
            this.DgvGetHostingAnEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetHostingAnEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetHostingAnEquipment.Location = new System.Drawing.Point(139, 78);
            this.DgvGetHostingAnEquipment.Name = "DgvGetHostingAnEquipment";
            this.DgvGetHostingAnEquipment.Size = new System.Drawing.Size(765, 462);
            this.DgvGetHostingAnEquipment.TabIndex = 3;
            // 
            // TpgGetServingASpace
            // 
            this.TpgGetServingASpace.Controls.Add(this.TlpGetServingASpace);
            this.TpgGetServingASpace.Location = new System.Drawing.Point(4, 29);
            this.TpgGetServingASpace.Name = "TpgGetServingASpace";
            this.TpgGetServingASpace.Size = new System.Drawing.Size(933, 569);
            this.TpgGetServingASpace.TabIndex = 5;
            this.TpgGetServingASpace.Text = "GetServingASpace";
            this.TpgGetServingASpace.UseVisualStyleBackColor = true;
            // 
            // TlpGetServingASpace
            // 
            this.TlpGetServingASpace.ColumnCount = 4;
            this.TlpGetServingASpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServingASpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetServingASpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServingASpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServingASpace.Controls.Add(this.LblGetServingASpace_SpaceID, 1, 1);
            this.TlpGetServingASpace.Controls.Add(this.TxtGetServingASpace_SpaceID, 2, 1);
            this.TlpGetServingASpace.Controls.Add(this.BtnGetServingASpace, 2, 2);
            this.TlpGetServingASpace.Controls.Add(this.DgvGetServingASpace, 2, 3);
            this.TlpGetServingASpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetServingASpace.Location = new System.Drawing.Point(0, 0);
            this.TlpGetServingASpace.Name = "TlpGetServingASpace";
            this.TlpGetServingASpace.RowCount = 5;
            this.TlpGetServingASpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServingASpace.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServingASpace.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServingASpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServingASpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServingASpace.Size = new System.Drawing.Size(933, 569);
            this.TlpGetServingASpace.TabIndex = 0;
            // 
            // LblGetServingASpace_SpaceID
            // 
            this.LblGetServingASpace_SpaceID.AutoSize = true;
            this.LblGetServingASpace_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServingASpace_SpaceID.Location = new System.Drawing.Point(23, 23);
            this.LblGetServingASpace_SpaceID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetServingASpace_SpaceID.Name = "LblGetServingASpace_SpaceID";
            this.LblGetServingASpace_SpaceID.Size = new System.Drawing.Size(91, 20);
            this.LblGetServingASpace_SpaceID.TabIndex = 0;
            this.LblGetServingASpace_SpaceID.Text = "Space ID (GUID):";
            this.LblGetServingASpace_SpaceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetServingASpace_SpaceID
            // 
            this.TxtGetServingASpace_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetServingASpace_SpaceID.Location = new System.Drawing.Point(120, 23);
            this.TxtGetServingASpace_SpaceID.Name = "TxtGetServingASpace_SpaceID";
            this.TxtGetServingASpace_SpaceID.Size = new System.Drawing.Size(790, 20);
            this.TxtGetServingASpace_SpaceID.TabIndex = 1;
            // 
            // BtnGetServingASpace
            // 
            this.BtnGetServingASpace.Location = new System.Drawing.Point(120, 49);
            this.BtnGetServingASpace.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetServingASpace.Name = "BtnGetServingASpace";
            this.BtnGetServingASpace.Size = new System.Drawing.Size(260, 23);
            this.BtnGetServingASpace.TabIndex = 2;
            this.BtnGetServingASpace.Text = "GetServingASpace";
            this.BtnGetServingASpace.UseVisualStyleBackColor = true;
            this.BtnGetServingASpace.Click += new System.EventHandler(this.BtnGetServingASpace_Click);
            // 
            // DgvGetServingASpace
            // 
            this.DgvGetServingASpace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetServingASpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetServingASpace.Location = new System.Drawing.Point(120, 78);
            this.DgvGetServingASpace.Name = "DgvGetServingASpace";
            this.DgvGetServingASpace.Size = new System.Drawing.Size(790, 468);
            this.DgvGetServingASpace.TabIndex = 3;
            // 
            // NetworkDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 626);
            this.Controls.Add(this.TabMain);
            this.Name = "NetworkDevices";
            this.Text = "NetworkDevices";
            this.TabMain.ResumeLayout(false);
            this.TpgGet.ResumeLayout(false);
            this.TlpMain.ResumeLayout(false);
            this.TlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGet)).EndInit();
            this.TpgGetTypes.ResumeLayout(false);
            this.TlpGetTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetTypes)).EndInit();
            this.TpgFindById.ResumeLayout(false);
            this.TlpFindById.ResumeLayout(false);
            this.TlpFindById.PerformLayout();
            this.TpgGetChildren.ResumeLayout(false);
            this.TlpGetChildren.ResumeLayout(false);
            this.TlpGetChildren.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetChildren)).EndInit();
            this.TpgGetHostingAnEquipment.ResumeLayout(false);
            this.TlpGetHostingAnEquipment.ResumeLayout(false);
            this.TlpGetHostingAnEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetHostingAnEquipment)).EndInit();
            this.TpgGetServingASpace.ResumeLayout(false);
            this.TlpGetServingASpace.ResumeLayout(false);
            this.TlpGetServingASpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServingASpace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGet;
        private System.Windows.Forms.TabPage TpgFindById;
        private System.Windows.Forms.TableLayoutPanel TlpMain;
        private System.Windows.Forms.TabPage TpgGetTypes;
        private System.Windows.Forms.Label LblGetTypes_TypeID;
        private System.Windows.Forms.TextBox TxtGetTypes_TypeID;
        private System.Windows.Forms.DataGridView DgvGet;
        private System.Windows.Forms.Button BtnGet;
        private System.Windows.Forms.TableLayoutPanel TlpGetTypes;
        private System.Windows.Forms.Button BtnGetTypes;
        private System.Windows.Forms.DataGridView DgvGetTypes;
        private System.Windows.Forms.TableLayoutPanel TlpFindById;
        private System.Windows.Forms.Label LblFindById_NetworkDeviceID;
        private System.Windows.Forms.TextBox TxtFindById_NetworkDeviceID;
        private System.Windows.Forms.Button BtnFindById;
        private System.Windows.Forms.PropertyGrid PrgFindById;
        private System.Windows.Forms.TabPage TpgGetChildren;
        private System.Windows.Forms.TableLayoutPanel TlpGetChildren;
        private System.Windows.Forms.Label LblGetChildren_NetworkDeviceID;
        private System.Windows.Forms.TextBox TxtGetChildren_NetworkDeviceID;
        private System.Windows.Forms.Button BtnGetChildren;
        private System.Windows.Forms.DataGridView DgvGetChildren;
        private System.Windows.Forms.TabPage TpgGetHostingAnEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetHostingAnEquipment;
        private System.Windows.Forms.Label LblGetHostingAnEquipment_EquipmentID;
        private System.Windows.Forms.TextBox TxtGetHostingAnEquipment_EquipmentID;
        private System.Windows.Forms.Button BtnGetHostingAnEquipment;
        private System.Windows.Forms.DataGridView DgvGetHostingAnEquipment;
        private System.Windows.Forms.TabPage TpgGetServingASpace;
        private System.Windows.Forms.TableLayoutPanel TlpGetServingASpace;
        private System.Windows.Forms.Label LblGetServingASpace_SpaceID;
        private System.Windows.Forms.TextBox TxtGetServingASpace_SpaceID;
        private System.Windows.Forms.Button BtnGetServingASpace;
        private System.Windows.Forms.DataGridView DgvGetServingASpace;
    }
}