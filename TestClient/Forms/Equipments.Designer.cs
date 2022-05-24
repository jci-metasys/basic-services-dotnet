
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
            this.LblGet_Title = new System.Windows.Forms.Label();
            this.TpgGetEquipmentPoints = new System.Windows.Forms.TabPage();
            this.TlpGetEquipmentpoints = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetEquipmentPoints_EquipID = new System.Windows.Forms.Label();
            this.TxtGetEquipmentPoints_EquipID = new System.Windows.Forms.TextBox();
            this.BtnGetEuipmentPoints = new System.Windows.Forms.Button();
            this.DgvGetEquipmentPoints = new System.Windows.Forms.DataGridView();
            this.LblReadAttributeValue = new System.Windows.Forms.Label();
            this.ChkReadAttributeValue = new System.Windows.Forms.CheckBox();
            this.LblGetPoints_Title = new System.Windows.Forms.Label();
            this.TpgFindById = new System.Windows.Forms.TabPage();
            this.TlpFindById = new System.Windows.Forms.TableLayoutPanel();
            this.LblFindById_EquipmentId = new System.Windows.Forms.Label();
            this.TxtFindById_EquipmentId = new System.Windows.Forms.TextBox();
            this.BtnFindById = new System.Windows.Forms.Button();
            this.PrgGetFindById = new System.Windows.Forms.PropertyGrid();
            this.LblFindById_Title = new System.Windows.Forms.Label();
            this.TpgGetSpaceEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetSpaceEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSpaceEquipment_SpaceID = new System.Windows.Forms.Label();
            this.TxtGetSpaceEquipment_SpaceID = new System.Windows.Forms.TextBox();
            this.BtnGetSpaceEquipment = new System.Windows.Forms.Button();
            this.DgvGetSpaceEquipment = new System.Windows.Forms.DataGridView();
            this.LblGetServingASpace_Title = new System.Windows.Forms.Label();
            this.TpgGetHostedByNetworkDevice = new System.Windows.Forms.TabPage();
            this.TlpGetHostedByNetworkDevice = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetHostedByNetworkDevice_NetDevID = new System.Windows.Forms.Label();
            this.TxtGetHostedByNetworkDevice_NetDevID = new System.Windows.Forms.TextBox();
            this.BtnGetHostedByNetworkDevice = new System.Windows.Forms.Button();
            this.DgvGetHostedByNetworkDevice = new System.Windows.Forms.DataGridView();
            this.LblGetHostedByNetworkDevice_Title = new System.Windows.Forms.Label();
            this.TpgGetServedByEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetServedByEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetServedByEquipment_EquipmentID = new System.Windows.Forms.Label();
            this.TxtGetServedByEquipment_EquipmentID = new System.Windows.Forms.TextBox();
            this.BtnGetServedByEquipment = new System.Windows.Forms.Button();
            this.LblGetServedByEquipment_Title = new System.Windows.Forms.Label();
            this.DgvGetServedByEquipment = new System.Windows.Forms.DataGridView();
            this.TpgGetServingAnEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetServingAnEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetServingAnEquipment_EquipmentID = new System.Windows.Forms.Label();
            this.TxtGetServingAnEquipment_EquipmentID = new System.Windows.Forms.TextBox();
            this.BtnGetServingAnEquipment = new System.Windows.Forms.Button();
            this.LblGetSetrvingAnEquipment_Title = new System.Windows.Forms.Label();
            this.DgvGetServingAnEquipment = new System.Windows.Forms.DataGridView();
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
            this.TpgGetServedByEquipment.SuspendLayout();
            this.TlpGetServedByEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServedByEquipment)).BeginInit();
            this.TpgGetServingAnEquipment.SuspendLayout();
            this.TlpGetServingAnEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServingAnEquipment)).BeginInit();
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
            this.TabMain.Controls.Add(this.TpgGetServedByEquipment);
            this.TabMain.Controls.Add(this.TpgGetServingAnEquipment);
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
            this.TlpGetEquipment.Controls.Add(this.LblGet_Title, 0, 0);
            this.TlpGetEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetEquipment.Name = "TlpGetEquipment";
            this.TlpGetEquipment.RowCount = 3;
            this.TlpGetEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEquipment.Size = new System.Drawing.Size(978, 519);
            this.TlpGetEquipment.TabIndex = 0;
            // 
            // BtnGetEquipment
            // 
            this.BtnGetEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetEquipment.Location = new System.Drawing.Point(169, 25);
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
            this.DgvGetEquipment.Location = new System.Drawing.Point(169, 54);
            this.DgvGetEquipment.Name = "DgvGetEquipment";
            this.DgvGetEquipment.Size = new System.Drawing.Size(786, 462);
            this.DgvGetEquipment.TabIndex = 1;
            // 
            // LblGet_Title
            // 
            this.LblGet_Title.AutoSize = true;
            this.TlpGetEquipment.SetColumnSpan(this.LblGet_Title, 3);
            this.LblGet_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGet_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGet_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGet_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGet_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGet_Title.Name = "LblGet_Title";
            this.LblGet_Title.Size = new System.Drawing.Size(952, 16);
            this.LblGet_Title.TabIndex = 2;
            this.LblGet_Title.Text = "Retrieves a collection of equipment instances.";
            this.LblGet_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.TlpGetEquipmentpoints.Controls.Add(this.LblGetPoints_Title, 0, 0);
            this.TlpGetEquipmentpoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetEquipmentpoints.Location = new System.Drawing.Point(3, 3);
            this.TlpGetEquipmentpoints.Name = "TlpGetEquipmentpoints";
            this.TlpGetEquipmentpoints.RowCount = 5;
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetEquipmentpoints.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetEquipmentpoints.Size = new System.Drawing.Size(978, 519);
            this.TlpGetEquipmentpoints.TabIndex = 0;
            // 
            // LblGetEquipmentPoints_EquipID
            // 
            this.LblGetEquipmentPoints_EquipID.AutoSize = true;
            this.LblGetEquipmentPoints_EquipID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetEquipmentPoints_EquipID.Location = new System.Drawing.Point(23, 25);
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
            this.TxtGetEquipmentPoints_EquipID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetEquipmentPoints_EquipID.Name = "TxtGetEquipmentPoints_EquipID";
            this.TxtGetEquipmentPoints_EquipID.Size = new System.Drawing.Size(786, 20);
            this.TxtGetEquipmentPoints_EquipID.TabIndex = 1;
            // 
            // BtnGetEuipmentPoints
            // 
            this.BtnGetEuipmentPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetEuipmentPoints.Location = new System.Drawing.Point(169, 77);
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
            this.DgvGetEquipmentPoints.Location = new System.Drawing.Point(169, 106);
            this.DgvGetEquipmentPoints.Name = "DgvGetEquipmentPoints";
            this.DgvGetEquipmentPoints.Size = new System.Drawing.Size(786, 410);
            this.DgvGetEquipmentPoints.TabIndex = 3;
            // 
            // LblReadAttributeValue
            // 
            this.LblReadAttributeValue.AutoSize = true;
            this.LblReadAttributeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblReadAttributeValue.Location = new System.Drawing.Point(23, 51);
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
            this.ChkReadAttributeValue.Location = new System.Drawing.Point(169, 51);
            this.ChkReadAttributeValue.MinimumSize = new System.Drawing.Size(0, 20);
            this.ChkReadAttributeValue.Name = "ChkReadAttributeValue";
            this.ChkReadAttributeValue.Size = new System.Drawing.Size(15, 20);
            this.ChkReadAttributeValue.TabIndex = 5;
            this.ChkReadAttributeValue.UseVisualStyleBackColor = true;
            // 
            // LblGetPoints_Title
            // 
            this.LblGetPoints_Title.AutoSize = true;
            this.TlpGetEquipmentpoints.SetColumnSpan(this.LblGetPoints_Title, 4);
            this.LblGetPoints_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetPoints_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetPoints_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetPoints_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetPoints_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetPoints_Title.Name = "LblGetPoints_Title";
            this.LblGetPoints_Title.Size = new System.Drawing.Size(972, 16);
            this.LblGetPoints_Title.TabIndex = 6;
            this.LblGetPoints_Title.Text = "Retrieves the collection of points that are defined by the specified equipment in" +
    "stance.";
            this.LblGetPoints_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.TlpFindById.Controls.Add(this.LblFindById_Title, 0, 0);
            this.TlpFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpFindById.Location = new System.Drawing.Point(3, 3);
            this.TlpFindById.Name = "TlpFindById";
            this.TlpFindById.RowCount = 4;
            this.TlpFindById.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.LblFindById_EquipmentId.Location = new System.Drawing.Point(23, 25);
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
            this.TxtFindById_EquipmentId.Location = new System.Drawing.Point(169, 25);
            this.TxtFindById_EquipmentId.Name = "TxtFindById_EquipmentId";
            this.TxtFindById_EquipmentId.Size = new System.Drawing.Size(786, 20);
            this.TxtFindById_EquipmentId.TabIndex = 1;
            // 
            // BtnFindById
            // 
            this.BtnFindById.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFindById.Location = new System.Drawing.Point(169, 51);
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
            this.PrgGetFindById.Location = new System.Drawing.Point(169, 80);
            this.PrgGetFindById.Name = "PrgGetFindById";
            this.PrgGetFindById.Size = new System.Drawing.Size(786, 436);
            this.PrgGetFindById.TabIndex = 3;
            // 
            // LblFindById_Title
            // 
            this.LblFindById_Title.AutoSize = true;
            this.TlpFindById.SetColumnSpan(this.LblFindById_Title, 4);
            this.LblFindById_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFindById_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFindById_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblFindById_Title.Location = new System.Drawing.Point(3, 3);
            this.LblFindById_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblFindById_Title.Name = "LblFindById_Title";
            this.LblFindById_Title.Size = new System.Drawing.Size(972, 16);
            this.LblFindById_Title.TabIndex = 4;
            this.LblFindById_Title.Text = "Retrieves the specified equipment instance.";
            this.LblFindById_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.TlpGetSpaceEquipment.Controls.Add(this.LblGetServingASpace_Title, 0, 0);
            this.TlpGetSpaceEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSpaceEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSpaceEquipment.Name = "TlpGetSpaceEquipment";
            this.TlpGetSpaceEquipment.RowCount = 4;
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSpaceEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSpaceEquipment.Size = new System.Drawing.Size(978, 519);
            this.TlpGetSpaceEquipment.TabIndex = 1;
            // 
            // LblGetSpaceEquipment_SpaceID
            // 
            this.LblGetSpaceEquipment_SpaceID.AutoSize = true;
            this.LblGetSpaceEquipment_SpaceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSpaceEquipment_SpaceID.Location = new System.Drawing.Point(23, 25);
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
            this.TxtGetSpaceEquipment_SpaceID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetSpaceEquipment_SpaceID.Name = "TxtGetSpaceEquipment_SpaceID";
            this.TxtGetSpaceEquipment_SpaceID.Size = new System.Drawing.Size(786, 20);
            this.TxtGetSpaceEquipment_SpaceID.TabIndex = 1;
            // 
            // BtnGetSpaceEquipment
            // 
            this.BtnGetSpaceEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetSpaceEquipment.Location = new System.Drawing.Point(169, 51);
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
            this.DgvGetSpaceEquipment.Location = new System.Drawing.Point(169, 80);
            this.DgvGetSpaceEquipment.Name = "DgvGetSpaceEquipment";
            this.DgvGetSpaceEquipment.Size = new System.Drawing.Size(786, 436);
            this.DgvGetSpaceEquipment.TabIndex = 3;
            // 
            // LblGetServingASpace_Title
            // 
            this.LblGetServingASpace_Title.AutoSize = true;
            this.TlpGetSpaceEquipment.SetColumnSpan(this.LblGetServingASpace_Title, 4);
            this.LblGetServingASpace_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServingASpace_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetServingASpace_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetServingASpace_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetServingASpace_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetServingASpace_Title.Name = "LblGetServingASpace_Title";
            this.LblGetServingASpace_Title.Size = new System.Drawing.Size(972, 16);
            this.LblGetServingASpace_Title.TabIndex = 4;
            this.LblGetServingASpace_Title.Text = "Retrieves the collection of equipment that serve the specified space.";
            this.LblGetServingASpace_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.TlpGetHostedByNetworkDevice.Controls.Add(this.LblGetHostedByNetworkDevice_Title, 0, 0);
            this.TlpGetHostedByNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetHostedByNetworkDevice.Location = new System.Drawing.Point(3, 3);
            this.TlpGetHostedByNetworkDevice.Name = "TlpGetHostedByNetworkDevice";
            this.TlpGetHostedByNetworkDevice.RowCount = 4;
            this.TlpGetHostedByNetworkDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.LblGetHostedByNetworkDevice_NetDevID.Location = new System.Drawing.Point(23, 25);
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
            this.TxtGetHostedByNetworkDevice_NetDevID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetHostedByNetworkDevice_NetDevID.Name = "TxtGetHostedByNetworkDevice_NetDevID";
            this.TxtGetHostedByNetworkDevice_NetDevID.Size = new System.Drawing.Size(786, 20);
            this.TxtGetHostedByNetworkDevice_NetDevID.TabIndex = 1;
            // 
            // BtnGetHostedByNetworkDevice
            // 
            this.BtnGetHostedByNetworkDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetHostedByNetworkDevice.Location = new System.Drawing.Point(169, 51);
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
            this.DgvGetHostedByNetworkDevice.Location = new System.Drawing.Point(169, 80);
            this.DgvGetHostedByNetworkDevice.Name = "DgvGetHostedByNetworkDevice";
            this.DgvGetHostedByNetworkDevice.Size = new System.Drawing.Size(786, 436);
            this.DgvGetHostedByNetworkDevice.TabIndex = 3;
            // 
            // LblGetHostedByNetworkDevice_Title
            // 
            this.LblGetHostedByNetworkDevice_Title.AutoSize = true;
            this.TlpGetHostedByNetworkDevice.SetColumnSpan(this.LblGetHostedByNetworkDevice_Title, 4);
            this.LblGetHostedByNetworkDevice_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetHostedByNetworkDevice_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetHostedByNetworkDevice_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetHostedByNetworkDevice_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetHostedByNetworkDevice_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetHostedByNetworkDevice_Title.Name = "LblGetHostedByNetworkDevice_Title";
            this.LblGetHostedByNetworkDevice_Title.Size = new System.Drawing.Size(972, 16);
            this.LblGetHostedByNetworkDevice_Title.TabIndex = 4;
            this.LblGetHostedByNetworkDevice_Title.Text = "Retrieves the collection of equipment instances that are hosted by the specified " +
    "network device or its children.";
            this.LblGetHostedByNetworkDevice_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TpgGetServedByEquipment
            // 
            this.TpgGetServedByEquipment.Controls.Add(this.TlpGetServedByEquipment);
            this.TpgGetServedByEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetServedByEquipment.Name = "TpgGetServedByEquipment";
            this.TpgGetServedByEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetServedByEquipment.Size = new System.Drawing.Size(984, 525);
            this.TpgGetServedByEquipment.TabIndex = 5;
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
            this.TlpGetServedByEquipment.Controls.Add(this.LblGetServedByEquipment_Title, 0, 0);
            this.TlpGetServedByEquipment.Controls.Add(this.DgvGetServedByEquipment, 2, 3);
            this.TlpGetServedByEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetServedByEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetServedByEquipment.Name = "TlpGetServedByEquipment";
            this.TlpGetServedByEquipment.RowCount = 4;
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServedByEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServedByEquipment.Size = new System.Drawing.Size(978, 519);
            this.TlpGetServedByEquipment.TabIndex = 0;
            // 
            // LblGetServedByEquipment_EquipmentID
            // 
            this.LblGetServedByEquipment_EquipmentID.AutoSize = true;
            this.LblGetServedByEquipment_EquipmentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServedByEquipment_EquipmentID.Location = new System.Drawing.Point(23, 25);
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
            this.TxtGetServedByEquipment_EquipmentID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetServedByEquipment_EquipmentID.Name = "TxtGetServedByEquipment_EquipmentID";
            this.TxtGetServedByEquipment_EquipmentID.Size = new System.Drawing.Size(786, 20);
            this.TxtGetServedByEquipment_EquipmentID.TabIndex = 1;
            // 
            // BtnGetServedByEquipment
            // 
            this.BtnGetServedByEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetServedByEquipment.Location = new System.Drawing.Point(169, 51);
            this.BtnGetServedByEquipment.Name = "BtnGetServedByEquipment";
            this.BtnGetServedByEquipment.Size = new System.Drawing.Size(786, 23);
            this.BtnGetServedByEquipment.TabIndex = 2;
            this.BtnGetServedByEquipment.Text = "Equipments.GetServedByEquipment";
            this.BtnGetServedByEquipment.UseVisualStyleBackColor = true;
            this.BtnGetServedByEquipment.Click += new System.EventHandler(this.BtnGetServedByEquipment_Click);
            // 
            // LblGetServedByEquipment_Title
            // 
            this.LblGetServedByEquipment_Title.AutoSize = true;
            this.TlpGetServedByEquipment.SetColumnSpan(this.LblGetServedByEquipment_Title, 4);
            this.LblGetServedByEquipment_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServedByEquipment_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetServedByEquipment_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetServedByEquipment_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetServedByEquipment_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetServedByEquipment_Title.Name = "LblGetServedByEquipment_Title";
            this.LblGetServedByEquipment_Title.Size = new System.Drawing.Size(972, 16);
            this.LblGetServedByEquipment_Title.TabIndex = 4;
            this.LblGetServedByEquipment_Title.Text = "Retrieves the equipment served by the specified equipment instance.";
            this.LblGetServedByEquipment_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvGetServedByEquipment
            // 
            this.DgvGetServedByEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetServedByEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetServedByEquipment.Location = new System.Drawing.Point(169, 80);
            this.DgvGetServedByEquipment.Name = "DgvGetServedByEquipment";
            this.DgvGetServedByEquipment.Size = new System.Drawing.Size(786, 436);
            this.DgvGetServedByEquipment.TabIndex = 5;
            // 
            // TpgGetServingAnEquipment
            // 
            this.TpgGetServingAnEquipment.Controls.Add(this.TlpGetServingAnEquipment);
            this.TpgGetServingAnEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetServingAnEquipment.Name = "TpgGetServingAnEquipment";
            this.TpgGetServingAnEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetServingAnEquipment.Size = new System.Drawing.Size(984, 525);
            this.TpgGetServingAnEquipment.TabIndex = 6;
            this.TpgGetServingAnEquipment.Text = "GetServingAnEquipment";
            this.TpgGetServingAnEquipment.UseVisualStyleBackColor = true;
            // 
            // TlpGetServingAnEquipment
            // 
            this.TlpGetServingAnEquipment.ColumnCount = 4;
            this.TlpGetServingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetServingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServingAnEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServingAnEquipment.Controls.Add(this.LblGetServingAnEquipment_EquipmentID, 1, 1);
            this.TlpGetServingAnEquipment.Controls.Add(this.TxtGetServingAnEquipment_EquipmentID, 2, 1);
            this.TlpGetServingAnEquipment.Controls.Add(this.BtnGetServingAnEquipment, 2, 2);
            this.TlpGetServingAnEquipment.Controls.Add(this.LblGetSetrvingAnEquipment_Title, 0, 0);
            this.TlpGetServingAnEquipment.Controls.Add(this.DgvGetServingAnEquipment, 2, 3);
            this.TlpGetServingAnEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetServingAnEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetServingAnEquipment.Name = "TlpGetServingAnEquipment";
            this.TlpGetServingAnEquipment.RowCount = 4;
            this.TlpGetServingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetServingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetServingAnEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetServingAnEquipment.Size = new System.Drawing.Size(978, 519);
            this.TlpGetServingAnEquipment.TabIndex = 0;
            // 
            // LblGetServingAnEquipment_EquipmentID
            // 
            this.LblGetServingAnEquipment_EquipmentID.AutoSize = true;
            this.LblGetServingAnEquipment_EquipmentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetServingAnEquipment_EquipmentID.Location = new System.Drawing.Point(23, 25);
            this.LblGetServingAnEquipment_EquipmentID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetServingAnEquipment_EquipmentID.Name = "LblGetServingAnEquipment_EquipmentID";
            this.LblGetServingAnEquipment_EquipmentID.Size = new System.Drawing.Size(110, 20);
            this.LblGetServingAnEquipment_EquipmentID.TabIndex = 0;
            this.LblGetServingAnEquipment_EquipmentID.Text = "Equipment ID (GUID):";
            this.LblGetServingAnEquipment_EquipmentID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetServingAnEquipment_EquipmentID
            // 
            this.TxtGetServingAnEquipment_EquipmentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetServingAnEquipment_EquipmentID.Location = new System.Drawing.Point(139, 25);
            this.TxtGetServingAnEquipment_EquipmentID.Name = "TxtGetServingAnEquipment_EquipmentID";
            this.TxtGetServingAnEquipment_EquipmentID.Size = new System.Drawing.Size(816, 20);
            this.TxtGetServingAnEquipment_EquipmentID.TabIndex = 1;
            // 
            // BtnGetServingAnEquipment
            // 
            this.BtnGetServingAnEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetServingAnEquipment.Location = new System.Drawing.Point(139, 51);
            this.BtnGetServingAnEquipment.Name = "BtnGetServingAnEquipment";
            this.BtnGetServingAnEquipment.Size = new System.Drawing.Size(816, 23);
            this.BtnGetServingAnEquipment.TabIndex = 2;
            this.BtnGetServingAnEquipment.Text = "Equipments.GetServingAnEquipment";
            this.BtnGetServingAnEquipment.UseVisualStyleBackColor = true;
            this.BtnGetServingAnEquipment.Click += new System.EventHandler(this.BtnGetServingAnEquipment_Click);
            // 
            // LblGetSetrvingAnEquipment_Title
            // 
            this.LblGetSetrvingAnEquipment_Title.AutoSize = true;
            this.TlpGetServingAnEquipment.SetColumnSpan(this.LblGetSetrvingAnEquipment_Title, 4);
            this.LblGetSetrvingAnEquipment_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSetrvingAnEquipment_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetSetrvingAnEquipment_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetSetrvingAnEquipment_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetSetrvingAnEquipment_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSetrvingAnEquipment_Title.Name = "LblGetSetrvingAnEquipment_Title";
            this.LblGetSetrvingAnEquipment_Title.Size = new System.Drawing.Size(972, 16);
            this.LblGetSetrvingAnEquipment_Title.TabIndex = 3;
            this.LblGetSetrvingAnEquipment_Title.Text = "Retrieves the collection of equipment that serve the specified equipment instance" +
    ".";
            this.LblGetSetrvingAnEquipment_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgvGetServingAnEquipment
            // 
            this.DgvGetServingAnEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetServingAnEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetServingAnEquipment.Location = new System.Drawing.Point(139, 80);
            this.DgvGetServingAnEquipment.Name = "DgvGetServingAnEquipment";
            this.DgvGetServingAnEquipment.Size = new System.Drawing.Size(816, 436);
            this.DgvGetServingAnEquipment.TabIndex = 4;
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
            this.TlpGetEquipment.PerformLayout();
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
            this.TpgGetServedByEquipment.ResumeLayout(false);
            this.TlpGetServedByEquipment.ResumeLayout(false);
            this.TlpGetServedByEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServedByEquipment)).EndInit();
            this.TpgGetServingAnEquipment.ResumeLayout(false);
            this.TlpGetServingAnEquipment.ResumeLayout(false);
            this.TlpGetServingAnEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetServingAnEquipment)).EndInit();
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
        private System.Windows.Forms.TabPage TpgGetServedByEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetServedByEquipment;
        private System.Windows.Forms.Label LblGetServedByEquipment_EquipmentID;
        private System.Windows.Forms.TextBox TxtGetServedByEquipment_EquipmentID;
        private System.Windows.Forms.Button BtnGetServedByEquipment;
        private System.Windows.Forms.TabPage TpgGetServingAnEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetServingAnEquipment;
        private System.Windows.Forms.Label LblGetServingAnEquipment_EquipmentID;
        private System.Windows.Forms.TextBox TxtGetServingAnEquipment_EquipmentID;
        private System.Windows.Forms.Button BtnGetServingAnEquipment;
        private System.Windows.Forms.Label LblGetSetrvingAnEquipment_Title;
        private System.Windows.Forms.DataGridView DgvGetServingAnEquipment;
        private System.Windows.Forms.Label LblGet_Title;
        private System.Windows.Forms.Label LblGetPoints_Title;
        private System.Windows.Forms.Label LblFindById_Title;
        private System.Windows.Forms.Label LblGetServingASpace_Title;
        private System.Windows.Forms.Label LblGetHostedByNetworkDevice_Title;
        private System.Windows.Forms.Label LblGetServedByEquipment_Title;
        private System.Windows.Forms.DataGridView DgvGetServedByEquipment;
    }
}