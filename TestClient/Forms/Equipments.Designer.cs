
namespace MetasysServices_TestClient.Forms
{
    partial class Equipments
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
            this.TpgGetEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGetEquipment = new System.Windows.Forms.Button();
            this.DgvGetEquipment = new System.Windows.Forms.DataGridView();
            this.TpgGetEquipmentPoints = new System.Windows.Forms.TabPage();
            this.TlpGetEquipmentpoints = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetEquipmentPoints_EquipID = new System.Windows.Forms.Label();
            this.TxtGetEquipmentPoints_EquipID = new System.Windows.Forms.TextBox();
            this.BtnGetEuipmentPoints = new System.Windows.Forms.Button();
            this.DgvGetEquipmentPoints = new System.Windows.Forms.DataGridView();
            this.LblReadAttributeValue = new System.Windows.Forms.Label();
            this.ChkReadAttributeValue = new System.Windows.Forms.CheckBox();
            this.TpgFindById = new System.Windows.Forms.TabPage();
            this.TlpFindById = new System.Windows.Forms.TableLayoutPanel();
            this.LblFindById_EquipmentId = new System.Windows.Forms.Label();
            this.TxtFindById_EquipmentId = new System.Windows.Forms.TextBox();
            this.BtnFindById = new System.Windows.Forms.Button();
            this.PrgGetFindById = new System.Windows.Forms.PropertyGrid();
            this.TpgGetSpaceEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetSpaceEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSpaceEquipment_SpaceID = new System.Windows.Forms.Label();
            this.TxtGetSpaceEquipment_SpaceID = new System.Windows.Forms.TextBox();
            this.BtnGetSpaceEquipment = new System.Windows.Forms.Button();
            this.DgvGetSpaceEquipment = new System.Windows.Forms.DataGridView();
            this.TpgGetHostedByNetworkDevice = new System.Windows.Forms.TabPage();
            this.TlpGetHostedByNetworkDevice = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetHostedByNetworkDevice_NetDevID = new System.Windows.Forms.Label();
            this.TxtGetHostedByNetworkDevice_NetDevID = new System.Windows.Forms.TextBox();
            this.BtnGetHostedByNetworkDevice = new System.Windows.Forms.Button();
            this.DgvGetHostedByNetworkDevice = new System.Windows.Forms.DataGridView();
            this.TabMain.SuspendLayout();
            this.TpgGetEquipment.SuspendLayout();
            this.TlpGetEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipment)).BeginInit();
            this.TpgGetEquipmentPoints.SuspendLayout();
            this.TlpGetEquipmentpoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipmentPoints)).BeginInit();
            this.TpgFindById.SuspendLayout();
            this.TlpFindById.SuspendLayout();
            this.TpgGetSpaceEquipment.SuspendLayout();
            this.TlpGetSpaceEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceEquipment)).BeginInit();
            this.TpgGetHostedByNetworkDevice.SuspendLayout();
            this.TlpGetHostedByNetworkDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetHostedByNetworkDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetEquipment);
            this.TabMain.Controls.Add(this.TpgGetEquipmentPoints);
            this.TabMain.Controls.Add(this.TpgFindById);
            this.TabMain.Controls.Add(this.TpgGetSpaceEquipment);
            this.TabMain.Controls.Add(this.TpgGetHostedByNetworkDevice);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(992, 558);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGetEquipment
            // 
            this.TpgGetEquipment.Controls.Add(this.TlpGetEquipment);
            this.TpgGetEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetEquipment.Name = "TpgGetEquipment";
            this.TpgGetEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetEquipment.Size = new System.Drawing.Size(984, 525);
            this.TpgGetEquipment.TabIndex = 0;
            this.TpgGetEquipment.Text = "GetEquipment";
            this.TpgGetEquipment.UseVisualStyleBackColor = true;
            // 
            // TlpGetEquipment
            // 
            this.TlpGetEquipment.ColumnCount = 4;
            this.TlpGetEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.TlpGetEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipment.Controls.Add(this.BtnGetEquipment, 2, 1);
            this.TlpGetEquipment.Controls.Add(this.DgvGetEquipment, 2, 2);
            this.TlpGetEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetEquipment.Name = "TlpGetEquipment";
            this.TlpGetEquipment.RowCount = 4;
            this.TlpGetEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipment.Size = new System.Drawing.Size(978, 519);
            this.TlpGetEquipment.TabIndex = 0;
            // 
            // BtnGetEquipment
            // 
            this.BtnGetEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetEquipment.Location = new System.Drawing.Point(169, 23);
            this.BtnGetEquipment.Name = "BtnGetEquipment";
            this.BtnGetEquipment.Size = new System.Drawing.Size(786, 23);
            this.BtnGetEquipment.TabIndex = 0;
            this.BtnGetEquipment.Text = "GetEquipment = Equipments.Get";
            this.BtnGetEquipment.UseVisualStyleBackColor = true;
            this.BtnGetEquipment.Click += new System.EventHandler(this.BtnGetEquipment_Click);
            // 
            // DgvGetEquipment
            // 
            this.DgvGetEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetEquipment.Location = new System.Drawing.Point(169, 52);
            this.DgvGetEquipment.Name = "DgvGetEquipment";
            this.DgvGetEquipment.Size = new System.Drawing.Size(786, 444);
            this.DgvGetEquipment.TabIndex = 1;
            // 
            // TpgGetEquipmentPoints
            // 
            this.TpgGetEquipmentPoints.Controls.Add(this.TlpGetEquipmentpoints);
            this.TpgGetEquipmentPoints.Location = new System.Drawing.Point(4, 29);
            this.TpgGetEquipmentPoints.Name = "TpgGetEquipmentPoints";
            this.TpgGetEquipmentPoints.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetEquipmentPoints.Size = new System.Drawing.Size(984, 525);
            this.TpgGetEquipmentPoints.TabIndex = 1;
            this.TpgGetEquipmentPoints.Text = "GetEquipmentPoints";
            this.TpgGetEquipmentPoints.UseVisualStyleBackColor = true;
            // 
            // TlpGetEquipmentpoints
            // 
            this.TlpGetEquipmentpoints.ColumnCount = 4;
            this.TlpGetEquipmentpoints.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipmentpoints.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetEquipmentpoints.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEquipmentpoints.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipmentpoints.Controls.Add(this.LblGetEquipmentPoints_EquipID, 1, 1);
            this.TlpGetEquipmentpoints.Controls.Add(this.TxtGetEquipmentPoints_EquipID, 2, 1);
            this.TlpGetEquipmentpoints.Controls.Add(this.BtnGetEuipmentPoints, 2, 3);
            this.TlpGetEquipmentpoints.Controls.Add(this.DgvGetEquipmentPoints, 2, 4);
            this.TlpGetEquipmentpoints.Controls.Add(this.LblReadAttributeValue, 1, 2);
            this.TlpGetEquipmentpoints.Controls.Add(this.ChkReadAttributeValue, 2, 2);
            this.TlpGetEquipmentpoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetEquipmentpoints.Location = new System.Drawing.Point(3, 3);
            this.TlpGetEquipmentpoints.Name = "TlpGetEquipmentpoints";
            this.TlpGetEquipmentpoints.RowCount = 6;
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetEquipmentpoints.Size = new System.Drawing.Size(978, 519);
            this.TlpGetEquipmentpoints.TabIndex = 0;
            // 
            // LblGetEquipmentPoints_EquipID
            // 
            this.LblGetEquipmentPoints_EquipID.AutoSize = true;
            this.LblGetEquipmentPoints_EquipID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetEquipmentPoints_EquipID.Location = new System.Drawing.Point(23, 23);
            this.LblGetEquipmentPoints_EquipID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetEquipmentPoints_EquipID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetEquipmentPoints_EquipID.Name = "LblGetEquipmentPoints_EquipID";
            this.LblGetEquipmentPoints_EquipID.Size = new System.Drawing.Size(140, 20);
            this.LblGetEquipmentPoints_EquipID.TabIndex = 0;
            this.LblGetEquipmentPoints_EquipID.Text = "Equipment ID (GUID):";
            this.LblGetEquipmentPoints_EquipID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetEquipmentPoints_EquipID
            // 
            this.TxtGetEquipmentPoints_EquipID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetEquipmentPoints_EquipID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetEquipmentPoints_EquipID.Name = "TxtGetEquipmentPoints_EquipID";
            this.TxtGetEquipmentPoints_EquipID.Size = new System.Drawing.Size(786, 20);
            this.TxtGetEquipmentPoints_EquipID.TabIndex = 1;
            // 
            // BtnGetEuipmentPoints
            // 
            this.BtnGetEuipmentPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetEuipmentPoints.Location = new System.Drawing.Point(169, 75);
            this.BtnGetEuipmentPoints.Name = "BtnGetEuipmentPoints";
            this.BtnGetEuipmentPoints.Size = new System.Drawing.Size(786, 23);
            this.BtnGetEuipmentPoints.TabIndex = 2;
            this.BtnGetEuipmentPoints.Text = "GetEquipmentPoints = Equipments.GetPoints";
            this.BtnGetEuipmentPoints.UseVisualStyleBackColor = true;
            this.BtnGetEuipmentPoints.Click += new System.EventHandler(this.BtnGetEuipmentPoints_Click);
            // 
            // DgvGetEquipmentPoints
            // 
            this.DgvGetEquipmentPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetEquipmentPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetEquipmentPoints.Location = new System.Drawing.Point(169, 104);
            this.DgvGetEquipmentPoints.Name = "DgvGetEquipmentPoints";
            this.DgvGetEquipmentPoints.Size = new System.Drawing.Size(786, 392);
            this.DgvGetEquipmentPoints.TabIndex = 3;
            // 
            // LblReadAttributeValue
            // 
            this.LblReadAttributeValue.AutoSize = true;
            this.LblReadAttributeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblReadAttributeValue.Location = new System.Drawing.Point(23, 49);
            this.LblReadAttributeValue.Margin = new System.Windows.Forms.Padding(3);
            this.LblReadAttributeValue.Name = "LblReadAttributeValue";
            this.LblReadAttributeValue.Size = new System.Drawing.Size(140, 20);
            this.LblReadAttributeValue.TabIndex = 4;
            this.LblReadAttributeValue.Text = "Read Attribute Value";
            this.LblReadAttributeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChkReadAttributeValue
            // 
            this.ChkReadAttributeValue.AutoSize = true;
            this.ChkReadAttributeValue.Checked = true;
            this.ChkReadAttributeValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkReadAttributeValue.Location = new System.Drawing.Point(169, 49);
            this.ChkReadAttributeValue.MinimumSize = new System.Drawing.Size(0, 20);
            this.ChkReadAttributeValue.Name = "ChkReadAttributeValue";
            this.ChkReadAttributeValue.Size = new System.Drawing.Size(15, 20);
            this.ChkReadAttributeValue.TabIndex = 5;
            this.ChkReadAttributeValue.UseVisualStyleBackColor = true;
            // 
            // TpgFindById
            // 
            this.TpgFindById.Controls.Add(this.TlpFindById);
            this.TpgFindById.Location = new System.Drawing.Point(4, 29);
            this.TpgFindById.Name = "TpgFindById";
            this.TpgFindById.Padding = new System.Windows.Forms.Padding(3);
            this.TpgFindById.Size = new System.Drawing.Size(984, 525);
            this.TpgFindById.TabIndex = 2;
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
            this.TlpFindById.Controls.Add(this.LblFindById_EquipmentId, 1, 1);
            this.TlpFindById.Controls.Add(this.TxtFindById_EquipmentId, 2, 1);
            this.TlpFindById.Controls.Add(this.BtnFindById, 2, 2);
            this.TlpFindById.Controls.Add(this.PrgGetFindById, 2, 3);
            this.TlpFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpFindById.Location = new System.Drawing.Point(3, 3);
            this.TlpFindById.Name = "TlpFindById";
            this.TlpFindById.RowCount = 5;
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpFindById.Size = new System.Drawing.Size(978, 519);
            this.TlpFindById.TabIndex = 0;
            // 
            // LblFindById_EquipmentId
            // 
            this.LblFindById_EquipmentId.AutoSize = true;
            this.LblFindById_EquipmentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFindById_EquipmentId.Location = new System.Drawing.Point(23, 23);
            this.LblFindById_EquipmentId.Margin = new System.Windows.Forms.Padding(3);
            this.LblFindById_EquipmentId.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblFindById_EquipmentId.Name = "LblFindById_EquipmentId";
            this.LblFindById_EquipmentId.Size = new System.Drawing.Size(140, 20);
            this.LblFindById_EquipmentId.TabIndex = 0;
            this.LblFindById_EquipmentId.Text = "Equipment ID (GUID):";
            this.LblFindById_EquipmentId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtFindById_EquipmentId
            // 
            this.TxtFindById_EquipmentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFindById_EquipmentId.Location = new System.Drawing.Point(169, 23);
            this.TxtFindById_EquipmentId.Name = "TxtFindById_EquipmentId";
            this.TxtFindById_EquipmentId.Size = new System.Drawing.Size(786, 20);
            this.TxtFindById_EquipmentId.TabIndex = 1;
            // 
            // BtnFindById
            // 
            this.BtnFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFindById.Location = new System.Drawing.Point(169, 49);
            this.BtnFindById.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnFindById.Name = "BtnFindById";
            this.BtnFindById.Size = new System.Drawing.Size(786, 23);
            this.BtnFindById.TabIndex = 2;
            this.BtnFindById.Text = "Equipments.FindById";
            this.BtnFindById.UseVisualStyleBackColor = true;
            this.BtnFindById.Click += new System.EventHandler(this.BtnGetSingleEquipemnt_Click);
            // 
            // PrgGetFindById
            // 
            this.PrgGetFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrgGetFindById.HelpVisible = false;
            this.PrgGetFindById.Location = new System.Drawing.Point(169, 78);
            this.PrgGetFindById.Name = "PrgGetFindById";
            this.PrgGetFindById.Size = new System.Drawing.Size(786, 418);
            this.PrgGetFindById.TabIndex = 3;
            // 
            // TpgGetSpaceEquipment
            // 
            this.TpgGetSpaceEquipment.Controls.Add(this.TlpGetSpaceEquipment);
            this.TpgGetSpaceEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSpaceEquipment.Name = "TpgGetSpaceEquipment";
            this.TpgGetSpaceEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSpaceEquipment.Size = new System.Drawing.Size(984, 525);
            this.TpgGetSpaceEquipment.TabIndex = 3;
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
            this.TlpGetSpaceEquipment.Size = new System.Drawing.Size(978, 519);
            this.TlpGetSpaceEquipment.TabIndex = 1;
            // 
            // LblGetSpaceEquipment_SpaceID
            // 
            this.LblGetSpaceEquipment_SpaceID.AutoSize = true;
            this.LblGetSpaceEquipment_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSpaceEquipment_SpaceID.Location = new System.Drawing.Point(23, 23);
            this.LblGetSpaceEquipment_SpaceID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSpaceEquipment_SpaceID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetSpaceEquipment_SpaceID.Name = "LblGetSpaceEquipment_SpaceID";
            this.LblGetSpaceEquipment_SpaceID.Size = new System.Drawing.Size(140, 20);
            this.LblGetSpaceEquipment_SpaceID.TabIndex = 0;
            this.LblGetSpaceEquipment_SpaceID.Text = "Space ID (GUID):";
            this.LblGetSpaceEquipment_SpaceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetSpaceEquipment_SpaceID
            // 
            this.TxtGetSpaceEquipment_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetSpaceEquipment_SpaceID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetSpaceEquipment_SpaceID.Name = "TxtGetSpaceEquipment_SpaceID";
            this.TxtGetSpaceEquipment_SpaceID.Size = new System.Drawing.Size(786, 20);
            this.TxtGetSpaceEquipment_SpaceID.TabIndex = 1;
            // 
            // BtnGetSpaceEquipment
            // 
            this.BtnGetSpaceEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetSpaceEquipment.Location = new System.Drawing.Point(169, 49);
            this.BtnGetSpaceEquipment.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetSpaceEquipment.Name = "BtnGetSpaceEquipment";
            this.BtnGetSpaceEquipment.Size = new System.Drawing.Size(786, 23);
            this.BtnGetSpaceEquipment.TabIndex = 2;
            this.BtnGetSpaceEquipment.Text = "GetSpaceEquipment = Equipments.GetServingASpace";
            this.BtnGetSpaceEquipment.UseVisualStyleBackColor = true;
            this.BtnGetSpaceEquipment.Click += new System.EventHandler(this.BtnGetSpaceEquipment_Click);
            // 
            // DgvGetSpaceEquipment
            // 
            this.DgvGetSpaceEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSpaceEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSpaceEquipment.Location = new System.Drawing.Point(169, 78);
            this.DgvGetSpaceEquipment.Name = "DgvGetSpaceEquipment";
            this.DgvGetSpaceEquipment.Size = new System.Drawing.Size(786, 418);
            this.DgvGetSpaceEquipment.TabIndex = 3;
            // 
            // TpgGetHostedByNetworkDevice
            // 
            this.TpgGetHostedByNetworkDevice.Controls.Add(this.TlpGetHostedByNetworkDevice);
            this.TpgGetHostedByNetworkDevice.Location = new System.Drawing.Point(4, 29);
            this.TpgGetHostedByNetworkDevice.Name = "TpgGetHostedByNetworkDevice";
            this.TpgGetHostedByNetworkDevice.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetHostedByNetworkDevice.Size = new System.Drawing.Size(984, 525);
            this.TpgGetHostedByNetworkDevice.TabIndex = 4;
            this.TpgGetHostedByNetworkDevice.Text = "GetHostedByNetworkDevice";
            this.TpgGetHostedByNetworkDevice.UseVisualStyleBackColor = true;
            // 
            // TlpGetHostedByNetworkDevice
            // 
            this.TlpGetHostedByNetworkDevice.ColumnCount = 4;
            this.TlpGetHostedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetHostedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetHostedByNetworkDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostedByNetworkDevice.Controls.Add(this.LblGetHostedByNetworkDevice_NetDevID, 1, 1);
            this.TlpGetHostedByNetworkDevice.Controls.Add(this.TxtGetHostedByNetworkDevice_NetDevID, 2, 1);
            this.TlpGetHostedByNetworkDevice.Controls.Add(this.BtnGetHostedByNetworkDevice, 2, 2);
            this.TlpGetHostedByNetworkDevice.Controls.Add(this.DgvGetHostedByNetworkDevice, 2, 3);
            this.TlpGetHostedByNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetHostedByNetworkDevice.Location = new System.Drawing.Point(3, 3);
            this.TlpGetHostedByNetworkDevice.Name = "TlpGetHostedByNetworkDevice";
            this.TlpGetHostedByNetworkDevice.RowCount = 5;
            this.TlpGetHostedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetHostedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetHostedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetHostedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetHostedByNetworkDevice.Size = new System.Drawing.Size(978, 519);
            this.TlpGetHostedByNetworkDevice.TabIndex = 0;
            // 
            // LblGetHostedByNetworkDevice_NetDevID
            // 
            this.LblGetHostedByNetworkDevice_NetDevID.AutoSize = true;
            this.LblGetHostedByNetworkDevice_NetDevID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetHostedByNetworkDevice_NetDevID.Location = new System.Drawing.Point(23, 23);
            this.LblGetHostedByNetworkDevice_NetDevID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetHostedByNetworkDevice_NetDevID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetHostedByNetworkDevice_NetDevID.Name = "LblGetHostedByNetworkDevice_NetDevID";
            this.LblGetHostedByNetworkDevice_NetDevID.Size = new System.Drawing.Size(140, 20);
            this.LblGetHostedByNetworkDevice_NetDevID.TabIndex = 0;
            this.LblGetHostedByNetworkDevice_NetDevID.Text = "Network Device ID (GUID):";
            this.LblGetHostedByNetworkDevice_NetDevID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetHostedByNetworkDevice_NetDevID
            // 
            this.TxtGetHostedByNetworkDevice_NetDevID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetHostedByNetworkDevice_NetDevID.Location = new System.Drawing.Point(169, 23);
            this.TxtGetHostedByNetworkDevice_NetDevID.Name = "TxtGetHostedByNetworkDevice_NetDevID";
            this.TxtGetHostedByNetworkDevice_NetDevID.Size = new System.Drawing.Size(786, 20);
            this.TxtGetHostedByNetworkDevice_NetDevID.TabIndex = 1;
            // 
            // BtnGetHostedByNetworkDevice
            // 
            this.BtnGetHostedByNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetHostedByNetworkDevice.Location = new System.Drawing.Point(169, 49);
            this.BtnGetHostedByNetworkDevice.Name = "BtnGetHostedByNetworkDevice";
            this.BtnGetHostedByNetworkDevice.Size = new System.Drawing.Size(786, 23);
            this.BtnGetHostedByNetworkDevice.TabIndex = 2;
            this.BtnGetHostedByNetworkDevice.Text = "Equipments.GetHostedByNetworkDevice";
            this.BtnGetHostedByNetworkDevice.UseVisualStyleBackColor = true;
            this.BtnGetHostedByNetworkDevice.Click += new System.EventHandler(this.BtnGetHostedByNetworkDevice_Click);
            // 
            // DgvGetHostedByNetworkDevice
            // 
            this.DgvGetHostedByNetworkDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetHostedByNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetHostedByNetworkDevice.Location = new System.Drawing.Point(169, 78);
            this.DgvGetHostedByNetworkDevice.Name = "DgvGetHostedByNetworkDevice";
            this.DgvGetHostedByNetworkDevice.Size = new System.Drawing.Size(786, 418);
            this.DgvGetHostedByNetworkDevice.TabIndex = 3;
            // 
            // Equipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 582);
            this.Controls.Add(this.TabMain);
            this.Name = "Equipments";
            this.Text = "Equipments";
            this.TabMain.ResumeLayout(false);
            this.TpgGetEquipment.ResumeLayout(false);
            this.TlpGetEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipment)).EndInit();
            this.TpgGetEquipmentPoints.ResumeLayout(false);
            this.TlpGetEquipmentpoints.ResumeLayout(false);
            this.TlpGetEquipmentpoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipmentPoints)).EndInit();
            this.TpgFindById.ResumeLayout(false);
            this.TlpFindById.ResumeLayout(false);
            this.TlpFindById.PerformLayout();
            this.TpgGetSpaceEquipment.ResumeLayout(false);
            this.TlpGetSpaceEquipment.ResumeLayout(false);
            this.TlpGetSpaceEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSpaceEquipment)).EndInit();
            this.TpgGetHostedByNetworkDevice.ResumeLayout(false);
            this.TlpGetHostedByNetworkDevice.ResumeLayout(false);
            this.TlpGetHostedByNetworkDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetHostedByNetworkDevice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGetEquipment;
        private System.Windows.Forms.TabPage TpgGetEquipmentPoints;
        private System.Windows.Forms.TableLayoutPanel TlpGetEquipment;
        private System.Windows.Forms.Button BtnGetEquipment;
        private System.Windows.Forms.DataGridView DgvGetEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetEquipmentpoints;
        private System.Windows.Forms.Label LblGetEquipmentPoints_EquipID;
        private System.Windows.Forms.TextBox TxtGetEquipmentPoints_EquipID;
        private System.Windows.Forms.Button BtnGetEuipmentPoints;
        private System.Windows.Forms.DataGridView DgvGetEquipmentPoints;
        private System.Windows.Forms.Label LblReadAttributeValue;
        private System.Windows.Forms.CheckBox ChkReadAttributeValue;
        private System.Windows.Forms.TabPage TpgFindById;
        private System.Windows.Forms.TableLayoutPanel TlpFindById;
        private System.Windows.Forms.Label LblFindById_EquipmentId;
        private System.Windows.Forms.TextBox TxtFindById_EquipmentId;
        private System.Windows.Forms.Button BtnFindById;
        private System.Windows.Forms.PropertyGrid PrgGetFindById;
        private System.Windows.Forms.TabPage TpgGetSpaceEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetSpaceEquipment;
        private System.Windows.Forms.Label LblGetSpaceEquipment_SpaceID;
        private System.Windows.Forms.TextBox TxtGetSpaceEquipment_SpaceID;
        private System.Windows.Forms.Button BtnGetSpaceEquipment;
        private System.Windows.Forms.DataGridView DgvGetSpaceEquipment;
        private System.Windows.Forms.TabPage TpgGetHostedByNetworkDevice;
        private System.Windows.Forms.TableLayoutPanel TlpGetHostedByNetworkDevice;
        private System.Windows.Forms.Label LblGetHostedByNetworkDevice_NetDevID;
        private System.Windows.Forms.TextBox TxtGetHostedByNetworkDevice_NetDevID;
        private System.Windows.Forms.Button BtnGetHostedByNetworkDevice;
        private System.Windows.Forms.DataGridView DgvGetHostedByNetworkDevice;
    }
}