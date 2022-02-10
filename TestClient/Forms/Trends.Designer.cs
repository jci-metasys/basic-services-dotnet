
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
            this.TlpGetTrendedAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetTrendedAttributes_ObjectID = new System.Windows.Forms.Label();
            this.TxtGetTrendedAttributes_ObjectID = new System.Windows.Forms.TextBox();
            this.BtnGetTrendedAttributes = new System.Windows.Forms.Button();
            this.DgvGetTrendedAttributes = new System.Windows.Forms.DataGridView();
            this.LblGetTrendedAttributes_Title = new System.Windows.Forms.Label();
            this.TpgGetSamples = new System.Windows.Forms.TabPage();
            this.TlpGetSamples = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSamples_ObjectID = new System.Windows.Forms.Label();
            this.TxtGetSamples_ObjectID = new System.Windows.Forms.TextBox();
            this.BtnGetSamples = new System.Windows.Forms.Button();
            this.DgvGetSamples = new System.Windows.Forms.DataGridView();
            this.LblGetSamples_AttributeID = new System.Windows.Forms.Label();
            this.NudGetSamples_AttributeID = new System.Windows.Forms.NumericUpDown();
            this.LblGetSamples_Filters = new System.Windows.Forms.Label();
            this.TlpGetSamples_Filters = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSamples_StartTime = new System.Windows.Forms.Label();
            this.DtpGetSamples_StartTime = new System.Windows.Forms.DateTimePicker();
            this.LblGetSamples_EndTime = new System.Windows.Forms.Label();
            this.DtpGetSamples_EndTime = new System.Windows.Forms.DateTimePicker();
            this.LblGetSamples_Title = new System.Windows.Forms.Label();
            this.TpgGetNetDevTrendedAttributes = new System.Windows.Forms.TabPage();
            this.TlpGetNetDevTrendedAttributes = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetNetDeTrendedAttributes_NetDevID = new System.Windows.Forms.Label();
            this.TxtGetNetDeTrendedAttributes_NetDevID = new System.Windows.Forms.TextBox();
            this.BtnGetNetDevTrendedAttributes = new System.Windows.Forms.Button();
            this.DgvGetNetDevTrendedAttributes = new System.Windows.Forms.DataGridView();
            this.LblGetNetDevTrendedAttributes = new System.Windows.Forms.Label();
            this.TpgGetNetDevSamples = new System.Windows.Forms.TabPage();
            this.TlpGeNetDevSamples = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetNetDevSamples_NetDevID = new System.Windows.Forms.Label();
            this.TxtGetNetDevSamples_NetDevID = new System.Windows.Forms.TextBox();
            this.LblGetNetDevSamples_AttributeID = new System.Windows.Forms.Label();
            this.CmbGetNetDevSamples_AttributeID = new System.Windows.Forms.ComboBox();
            this.LblGetNetDevSamples_Title = new System.Windows.Forms.Label();
            this.LblGetNetDevSample_Filters = new System.Windows.Forms.Label();
            this.TlpGetNetDevSamples_Filters = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetNetDevSamples_StartTime = new System.Windows.Forms.Label();
            this.DtpGetNetDevSamples_StartTime = new System.Windows.Forms.DateTimePicker();
            this.DtpGetNetDevSamples_EndTime = new System.Windows.Forms.DateTimePicker();
            this.LblGetNetDevSamples_EndTime = new System.Windows.Forms.Label();
            this.BtnGetNetDevSamples = new System.Windows.Forms.Button();
            this.DgvGetNetDevSamples = new System.Windows.Forms.DataGridView();
            this.TabMain.SuspendLayout();
            this.TpgGetTrendedAttributes.SuspendLayout();
            this.TlpGetTrendedAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetTrendedAttributes)).BeginInit();
            this.TpgGetSamples.SuspendLayout();
            this.TlpGetSamples.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGetSamples_AttributeID)).BeginInit();
            this.TlpGetSamples_Filters.SuspendLayout();
            this.TpgGetNetDevTrendedAttributes.SuspendLayout();
            this.TlpGetNetDevTrendedAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetDevTrendedAttributes)).BeginInit();
            this.TpgGetNetDevSamples.SuspendLayout();
            this.TlpGeNetDevSamples.SuspendLayout();
            this.TlpGetNetDevSamples_Filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetDevSamples)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetTrendedAttributes);
            this.TabMain.Controls.Add(this.TpgGetSamples);
            this.TabMain.Controls.Add(this.TpgGetNetDevTrendedAttributes);
            this.TabMain.Controls.Add(this.TpgGetNetDevSamples);
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
            this.TlpGetTrendedAttributes.Controls.Add(this.LblGetTrendedAttributes_Title, 0, 0);
            this.TlpGetTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetTrendedAttributes.Location = new System.Drawing.Point(3, 3);
            this.TlpGetTrendedAttributes.Name = "TlpGetTrendedAttributes";
            this.TlpGetTrendedAttributes.RowCount = 4;
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetTrendedAttributes.Size = new System.Drawing.Size(832, 461);
            this.TlpGetTrendedAttributes.TabIndex = 0;
            // 
            // LblGetTrendedAttributes_ObjectID
            // 
            this.LblGetTrendedAttributes_ObjectID.AutoSize = true;
            this.LblGetTrendedAttributes_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetTrendedAttributes_ObjectID.Location = new System.Drawing.Point(23, 25);
            this.LblGetTrendedAttributes_ObjectID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetTrendedAttributes_ObjectID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetTrendedAttributes_ObjectID.Name = "LblGetTrendedAttributes_ObjectID";
            this.LblGetTrendedAttributes_ObjectID.Size = new System.Drawing.Size(140, 20);
            this.LblGetTrendedAttributes_ObjectID.TabIndex = 0;
            this.LblGetTrendedAttributes_ObjectID.Text = "Object ID (GUID):";
            this.LblGetTrendedAttributes_ObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetTrendedAttributes_ObjectID
            // 
            this.TxtGetTrendedAttributes_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetTrendedAttributes_ObjectID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetTrendedAttributes_ObjectID.Name = "TxtGetTrendedAttributes_ObjectID";
            this.TxtGetTrendedAttributes_ObjectID.Size = new System.Drawing.Size(640, 20);
            this.TxtGetTrendedAttributes_ObjectID.TabIndex = 1;
            // 
            // BtnGetTrendedAttributes
            // 
            this.BtnGetTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetTrendedAttributes.Location = new System.Drawing.Point(169, 51);
            this.BtnGetTrendedAttributes.Name = "BtnGetTrendedAttributes";
            this.BtnGetTrendedAttributes.Size = new System.Drawing.Size(640, 23);
            this.BtnGetTrendedAttributes.TabIndex = 2;
            this.BtnGetTrendedAttributes.Text = "Trends.GetTrendedAttributes";
            this.BtnGetTrendedAttributes.UseVisualStyleBackColor = true;
            this.BtnGetTrendedAttributes.Click += new System.EventHandler(this.BtnGetTrendedAttributes_Click);
            // 
            // DgvGetTrendedAttributes
            // 
            this.DgvGetTrendedAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetTrendedAttributes.Location = new System.Drawing.Point(169, 80);
            this.DgvGetTrendedAttributes.Name = "DgvGetTrendedAttributes";
            this.DgvGetTrendedAttributes.Size = new System.Drawing.Size(640, 378);
            this.DgvGetTrendedAttributes.TabIndex = 3;
            // 
            // LblGetTrendedAttributes_Title
            // 
            this.LblGetTrendedAttributes_Title.AutoSize = true;
            this.TlpGetTrendedAttributes.SetColumnSpan(this.LblGetTrendedAttributes_Title, 4);
            this.LblGetTrendedAttributes_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetTrendedAttributes_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetTrendedAttributes_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetTrendedAttributes_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetTrendedAttributes_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetTrendedAttributes_Title.Name = "LblGetTrendedAttributes_Title";
            this.LblGetTrendedAttributes_Title.Size = new System.Drawing.Size(826, 16);
            this.LblGetTrendedAttributes_Title.TabIndex = 4;
            this.LblGetTrendedAttributes_Title.Text = "Get object attributes with samples";
            this.LblGetTrendedAttributes_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.TlpGetSamples.Controls.Add(this.LblGetSamples_Filters, 1, 3);
            this.TlpGetSamples.Controls.Add(this.TlpGetSamples_Filters, 2, 3);
            this.TlpGetSamples.Controls.Add(this.LblGetSamples_Title, 0, 0);
            this.TlpGetSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSamples.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSamples.Name = "TlpGetSamples";
            this.TlpGetSamples.RowCount = 6;
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSamples.Size = new System.Drawing.Size(832, 461);
            this.TlpGetSamples.TabIndex = 0;
            // 
            // LblGetSamples_ObjectID
            // 
            this.LblGetSamples_ObjectID.AutoSize = true;
            this.LblGetSamples_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_ObjectID.Location = new System.Drawing.Point(23, 25);
            this.LblGetSamples_ObjectID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_ObjectID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetSamples_ObjectID.Name = "LblGetSamples_ObjectID";
            this.LblGetSamples_ObjectID.Size = new System.Drawing.Size(140, 20);
            this.LblGetSamples_ObjectID.TabIndex = 0;
            this.LblGetSamples_ObjectID.Text = "Object ID (GUID):";
            this.LblGetSamples_ObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetSamples_ObjectID
            // 
            this.TxtGetSamples_ObjectID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetSamples_ObjectID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetSamples_ObjectID.Name = "TxtGetSamples_ObjectID";
            this.TxtGetSamples_ObjectID.Size = new System.Drawing.Size(640, 20);
            this.TxtGetSamples_ObjectID.TabIndex = 1;
            // 
            // BtnGetSamples
            // 
            this.BtnGetSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetSamples.Location = new System.Drawing.Point(169, 109);
            this.BtnGetSamples.Name = "BtnGetSamples";
            this.BtnGetSamples.Size = new System.Drawing.Size(640, 23);
            this.BtnGetSamples.TabIndex = 2;
            this.BtnGetSamples.Text = "Trends.GetSamples";
            this.BtnGetSamples.UseVisualStyleBackColor = true;
            this.BtnGetSamples.Click += new System.EventHandler(this.BtnGetSamples_Click);
            // 
            // DgvGetSamples
            // 
            this.DgvGetSamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetSamples.Location = new System.Drawing.Point(169, 138);
            this.DgvGetSamples.Name = "DgvGetSamples";
            this.DgvGetSamples.Size = new System.Drawing.Size(640, 320);
            this.DgvGetSamples.TabIndex = 3;
            // 
            // LblGetSamples_AttributeID
            // 
            this.LblGetSamples_AttributeID.AutoSize = true;
            this.LblGetSamples_AttributeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_AttributeID.Location = new System.Drawing.Point(23, 51);
            this.LblGetSamples_AttributeID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_AttributeID.Name = "LblGetSamples_AttributeID";
            this.LblGetSamples_AttributeID.Size = new System.Drawing.Size(140, 20);
            this.LblGetSamples_AttributeID.TabIndex = 4;
            this.LblGetSamples_AttributeID.Text = "Attribute ID (INT/ENUM):";
            this.LblGetSamples_AttributeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudGetSamples_AttributeID
            // 
            this.NudGetSamples_AttributeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NudGetSamples_AttributeID.Location = new System.Drawing.Point(169, 51);
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
            this.NudGetSamples_AttributeID.Size = new System.Drawing.Size(640, 20);
            this.NudGetSamples_AttributeID.TabIndex = 5;
            this.NudGetSamples_AttributeID.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // LblGetSamples_Filters
            // 
            this.LblGetSamples_Filters.AutoSize = true;
            this.LblGetSamples_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_Filters.Location = new System.Drawing.Point(23, 77);
            this.LblGetSamples_Filters.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_Filters.Name = "LblGetSamples_Filters";
            this.LblGetSamples_Filters.Size = new System.Drawing.Size(140, 26);
            this.LblGetSamples_Filters.TabIndex = 6;
            this.LblGetSamples_Filters.Text = "Filters (TimeFilter):";
            this.LblGetSamples_Filters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TlpGetSamples_Filters
            // 
            this.TlpGetSamples_Filters.AutoSize = true;
            this.TlpGetSamples_Filters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpGetSamples_Filters.ColumnCount = 4;
            this.TlpGetSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetSamples_Filters.Controls.Add(this.LblGetSamples_StartTime, 0, 0);
            this.TlpGetSamples_Filters.Controls.Add(this.DtpGetSamples_StartTime, 1, 0);
            this.TlpGetSamples_Filters.Controls.Add(this.LblGetSamples_EndTime, 2, 0);
            this.TlpGetSamples_Filters.Controls.Add(this.DtpGetSamples_EndTime, 3, 0);
            this.TlpGetSamples_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSamples_Filters.Location = new System.Drawing.Point(169, 77);
            this.TlpGetSamples_Filters.Name = "TlpGetSamples_Filters";
            this.TlpGetSamples_Filters.RowCount = 1;
            this.TlpGetSamples_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSamples_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.TlpGetSamples_Filters.Size = new System.Drawing.Size(640, 26);
            this.TlpGetSamples_Filters.TabIndex = 7;
            // 
            // LblGetSamples_StartTime
            // 
            this.LblGetSamples_StartTime.AutoSize = true;
            this.LblGetSamples_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_StartTime.Location = new System.Drawing.Point(3, 3);
            this.LblGetSamples_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_StartTime.Name = "LblGetSamples_StartTime";
            this.LblGetSamples_StartTime.Size = new System.Drawing.Size(55, 20);
            this.LblGetSamples_StartTime.TabIndex = 0;
            this.LblGetSamples_StartTime.Text = "Start Time";
            this.LblGetSamples_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGetSamples_StartTime
            // 
            this.DtpGetSamples_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetSamples_StartTime.Location = new System.Drawing.Point(64, 3);
            this.DtpGetSamples_StartTime.Name = "DtpGetSamples_StartTime";
            this.DtpGetSamples_StartTime.Size = new System.Drawing.Size(254, 20);
            this.DtpGetSamples_StartTime.TabIndex = 1;
            // 
            // LblGetSamples_EndTime
            // 
            this.LblGetSamples_EndTime.AutoSize = true;
            this.LblGetSamples_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_EndTime.Location = new System.Drawing.Point(324, 3);
            this.LblGetSamples_EndTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_EndTime.Name = "LblGetSamples_EndTime";
            this.LblGetSamples_EndTime.Size = new System.Drawing.Size(52, 20);
            this.LblGetSamples_EndTime.TabIndex = 2;
            this.LblGetSamples_EndTime.Text = "End Time";
            this.LblGetSamples_EndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGetSamples_EndTime
            // 
            this.DtpGetSamples_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetSamples_EndTime.Location = new System.Drawing.Point(382, 3);
            this.DtpGetSamples_EndTime.Name = "DtpGetSamples_EndTime";
            this.DtpGetSamples_EndTime.Size = new System.Drawing.Size(255, 20);
            this.DtpGetSamples_EndTime.TabIndex = 3;
            // 
            // LblGetSamples_Title
            // 
            this.LblGetSamples_Title.AutoSize = true;
            this.TlpGetSamples.SetColumnSpan(this.LblGetSamples_Title, 4);
            this.LblGetSamples_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSamples_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetSamples_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetSamples_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetSamples_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSamples_Title.Name = "LblGetSamples_Title";
            this.LblGetSamples_Title.Size = new System.Drawing.Size(826, 16);
            this.LblGetSamples_Title.TabIndex = 8;
            this.LblGetSamples_Title.Text = "Get samples for an object attribute";
            this.LblGetSamples_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TpgGetNetDevTrendedAttributes
            // 
            this.TpgGetNetDevTrendedAttributes.Controls.Add(this.TlpGetNetDevTrendedAttributes);
            this.TpgGetNetDevTrendedAttributes.Location = new System.Drawing.Point(4, 29);
            this.TpgGetNetDevTrendedAttributes.Name = "TpgGetNetDevTrendedAttributes";
            this.TpgGetNetDevTrendedAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetNetDevTrendedAttributes.Size = new System.Drawing.Size(838, 467);
            this.TpgGetNetDevTrendedAttributes.TabIndex = 2;
            this.TpgGetNetDevTrendedAttributes.Text = "GetNetDevTrendedAttributes";
            this.TpgGetNetDevTrendedAttributes.UseVisualStyleBackColor = true;
            // 
            // TlpGetNetDevTrendedAttributes
            // 
            this.TlpGetNetDevTrendedAttributes.ColumnCount = 4;
            this.TlpGetNetDevTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetNetDevTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetNetDevTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetNetDevTrendedAttributes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetNetDevTrendedAttributes.Controls.Add(this.LblGetNetDeTrendedAttributes_NetDevID, 1, 1);
            this.TlpGetNetDevTrendedAttributes.Controls.Add(this.TxtGetNetDeTrendedAttributes_NetDevID, 2, 1);
            this.TlpGetNetDevTrendedAttributes.Controls.Add(this.BtnGetNetDevTrendedAttributes, 2, 2);
            this.TlpGetNetDevTrendedAttributes.Controls.Add(this.DgvGetNetDevTrendedAttributes, 2, 3);
            this.TlpGetNetDevTrendedAttributes.Controls.Add(this.LblGetNetDevTrendedAttributes, 0, 0);
            this.TlpGetNetDevTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetNetDevTrendedAttributes.Location = new System.Drawing.Point(3, 3);
            this.TlpGetNetDevTrendedAttributes.Name = "TlpGetNetDevTrendedAttributes";
            this.TlpGetNetDevTrendedAttributes.RowCount = 4;
            this.TlpGetNetDevTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetNetDevTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetNetDevTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetNetDevTrendedAttributes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetNetDevTrendedAttributes.Size = new System.Drawing.Size(832, 461);
            this.TlpGetNetDevTrendedAttributes.TabIndex = 0;
            // 
            // LblGetNetDeTrendedAttributes_NetDevID
            // 
            this.LblGetNetDeTrendedAttributes_NetDevID.AutoSize = true;
            this.LblGetNetDeTrendedAttributes_NetDevID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDeTrendedAttributes_NetDevID.Location = new System.Drawing.Point(23, 25);
            this.LblGetNetDeTrendedAttributes_NetDevID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDeTrendedAttributes_NetDevID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetNetDeTrendedAttributes_NetDevID.Name = "LblGetNetDeTrendedAttributes_NetDevID";
            this.LblGetNetDeTrendedAttributes_NetDevID.Size = new System.Drawing.Size(140, 20);
            this.LblGetNetDeTrendedAttributes_NetDevID.TabIndex = 0;
            this.LblGetNetDeTrendedAttributes_NetDevID.Text = "Network Device ID (GUID):";
            this.LblGetNetDeTrendedAttributes_NetDevID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetNetDeTrendedAttributes_NetDevID
            // 
            this.TxtGetNetDeTrendedAttributes_NetDevID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetNetDeTrendedAttributes_NetDevID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetNetDeTrendedAttributes_NetDevID.Name = "TxtGetNetDeTrendedAttributes_NetDevID";
            this.TxtGetNetDeTrendedAttributes_NetDevID.Size = new System.Drawing.Size(640, 20);
            this.TxtGetNetDeTrendedAttributes_NetDevID.TabIndex = 1;
            // 
            // BtnGetNetDevTrendedAttributes
            // 
            this.BtnGetNetDevTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetNetDevTrendedAttributes.Location = new System.Drawing.Point(169, 51);
            this.BtnGetNetDevTrendedAttributes.Name = "BtnGetNetDevTrendedAttributes";
            this.BtnGetNetDevTrendedAttributes.Size = new System.Drawing.Size(640, 23);
            this.BtnGetNetDevTrendedAttributes.TabIndex = 2;
            this.BtnGetNetDevTrendedAttributes.Text = "Trends.GetNetDevTrendedAttributes";
            this.BtnGetNetDevTrendedAttributes.UseVisualStyleBackColor = true;
            this.BtnGetNetDevTrendedAttributes.Click += new System.EventHandler(this.BtnGetNetDevTrendedAttributes_Click);
            // 
            // DgvGetNetDevTrendedAttributes
            // 
            this.DgvGetNetDevTrendedAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetNetDevTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetNetDevTrendedAttributes.Location = new System.Drawing.Point(169, 80);
            this.DgvGetNetDevTrendedAttributes.Name = "DgvGetNetDevTrendedAttributes";
            this.DgvGetNetDevTrendedAttributes.Size = new System.Drawing.Size(640, 378);
            this.DgvGetNetDevTrendedAttributes.TabIndex = 3;
            // 
            // LblGetNetDevTrendedAttributes
            // 
            this.LblGetNetDevTrendedAttributes.AutoSize = true;
            this.TlpGetNetDevTrendedAttributes.SetColumnSpan(this.LblGetNetDevTrendedAttributes, 4);
            this.LblGetNetDevTrendedAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDevTrendedAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetNetDevTrendedAttributes.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetNetDevTrendedAttributes.Location = new System.Drawing.Point(3, 3);
            this.LblGetNetDevTrendedAttributes.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDevTrendedAttributes.Name = "LblGetNetDevTrendedAttributes";
            this.LblGetNetDevTrendedAttributes.Size = new System.Drawing.Size(826, 16);
            this.LblGetNetDevTrendedAttributes.TabIndex = 4;
            this.LblGetNetDevTrendedAttributes.Text = "Get network device attributes with samples";
            this.LblGetNetDevTrendedAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TpgGetNetDevSamples
            // 
            this.TpgGetNetDevSamples.Controls.Add(this.TlpGeNetDevSamples);
            this.TpgGetNetDevSamples.Location = new System.Drawing.Point(4, 29);
            this.TpgGetNetDevSamples.Name = "TpgGetNetDevSamples";
            this.TpgGetNetDevSamples.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetNetDevSamples.Size = new System.Drawing.Size(838, 467);
            this.TpgGetNetDevSamples.TabIndex = 3;
            this.TpgGetNetDevSamples.Text = "GetNetDevSamples";
            this.TpgGetNetDevSamples.UseVisualStyleBackColor = true;
            // 
            // TlpGeNetDevSamples
            // 
            this.TlpGeNetDevSamples.ColumnCount = 4;
            this.TlpGeNetDevSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGeNetDevSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGeNetDevSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGeNetDevSamples.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGeNetDevSamples.Controls.Add(this.LblGetNetDevSamples_NetDevID, 1, 1);
            this.TlpGeNetDevSamples.Controls.Add(this.TxtGetNetDevSamples_NetDevID, 2, 1);
            this.TlpGeNetDevSamples.Controls.Add(this.LblGetNetDevSamples_AttributeID, 1, 2);
            this.TlpGeNetDevSamples.Controls.Add(this.CmbGetNetDevSamples_AttributeID, 2, 2);
            this.TlpGeNetDevSamples.Controls.Add(this.LblGetNetDevSamples_Title, 0, 0);
            this.TlpGeNetDevSamples.Controls.Add(this.LblGetNetDevSample_Filters, 1, 3);
            this.TlpGeNetDevSamples.Controls.Add(this.TlpGetNetDevSamples_Filters, 2, 3);
            this.TlpGeNetDevSamples.Controls.Add(this.BtnGetNetDevSamples, 2, 4);
            this.TlpGeNetDevSamples.Controls.Add(this.DgvGetNetDevSamples, 2, 5);
            this.TlpGeNetDevSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGeNetDevSamples.Location = new System.Drawing.Point(3, 3);
            this.TlpGeNetDevSamples.Name = "TlpGeNetDevSamples";
            this.TlpGeNetDevSamples.RowCount = 6;
            this.TlpGeNetDevSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGeNetDevSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGeNetDevSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGeNetDevSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGeNetDevSamples.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGeNetDevSamples.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGeNetDevSamples.Size = new System.Drawing.Size(832, 461);
            this.TlpGeNetDevSamples.TabIndex = 0;
            // 
            // LblGetNetDevSamples_NetDevID
            // 
            this.LblGetNetDevSamples_NetDevID.AutoSize = true;
            this.LblGetNetDevSamples_NetDevID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDevSamples_NetDevID.Location = new System.Drawing.Point(23, 25);
            this.LblGetNetDevSamples_NetDevID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDevSamples_NetDevID.MinimumSize = new System.Drawing.Size(140, 0);
            this.LblGetNetDevSamples_NetDevID.Name = "LblGetNetDevSamples_NetDevID";
            this.LblGetNetDevSamples_NetDevID.Size = new System.Drawing.Size(140, 20);
            this.LblGetNetDevSamples_NetDevID.TabIndex = 0;
            this.LblGetNetDevSamples_NetDevID.Text = "Network Device ID (GUID):";
            this.LblGetNetDevSamples_NetDevID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetNetDevSamples_NetDevID
            // 
            this.TxtGetNetDevSamples_NetDevID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetNetDevSamples_NetDevID.Location = new System.Drawing.Point(169, 25);
            this.TxtGetNetDevSamples_NetDevID.Name = "TxtGetNetDevSamples_NetDevID";
            this.TxtGetNetDevSamples_NetDevID.Size = new System.Drawing.Size(640, 20);
            this.TxtGetNetDevSamples_NetDevID.TabIndex = 1;
            // 
            // LblGetNetDevSamples_AttributeID
            // 
            this.LblGetNetDevSamples_AttributeID.AutoSize = true;
            this.LblGetNetDevSamples_AttributeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDevSamples_AttributeID.Location = new System.Drawing.Point(23, 51);
            this.LblGetNetDevSamples_AttributeID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDevSamples_AttributeID.Name = "LblGetNetDevSamples_AttributeID";
            this.LblGetNetDevSamples_AttributeID.Size = new System.Drawing.Size(140, 21);
            this.LblGetNetDevSamples_AttributeID.TabIndex = 2;
            this.LblGetNetDevSamples_AttributeID.Text = "Attribute ID (INT/ENUM):";
            this.LblGetNetDevSamples_AttributeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbGetNetDevSamples_AttributeID
            // 
            this.CmbGetNetDevSamples_AttributeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbGetNetDevSamples_AttributeID.FormattingEnabled = true;
            this.CmbGetNetDevSamples_AttributeID.Items.AddRange(new object[] {
            "85",
            "presentValue"});
            this.CmbGetNetDevSamples_AttributeID.Location = new System.Drawing.Point(169, 51);
            this.CmbGetNetDevSamples_AttributeID.Name = "CmbGetNetDevSamples_AttributeID";
            this.CmbGetNetDevSamples_AttributeID.Size = new System.Drawing.Size(640, 21);
            this.CmbGetNetDevSamples_AttributeID.TabIndex = 3;
            this.CmbGetNetDevSamples_AttributeID.SelectedIndexChanged += new System.EventHandler(this.CmbGetNetDevSamples_AttributeID_SelectedIndexChanged);
            // 
            // LblGetNetDevSamples_Title
            // 
            this.LblGetNetDevSamples_Title.AutoSize = true;
            this.TlpGeNetDevSamples.SetColumnSpan(this.LblGetNetDevSamples_Title, 4);
            this.LblGetNetDevSamples_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDevSamples_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGetNetDevSamples_Title.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblGetNetDevSamples_Title.Location = new System.Drawing.Point(3, 3);
            this.LblGetNetDevSamples_Title.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDevSamples_Title.Name = "LblGetNetDevSamples_Title";
            this.LblGetNetDevSamples_Title.Size = new System.Drawing.Size(826, 16);
            this.LblGetNetDevSamples_Title.TabIndex = 4;
            this.LblGetNetDevSamples_Title.Text = "Get samples for a network device attribute";
            this.LblGetNetDevSamples_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblGetNetDevSample_Filters
            // 
            this.LblGetNetDevSample_Filters.AutoSize = true;
            this.LblGetNetDevSample_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDevSample_Filters.Location = new System.Drawing.Point(23, 78);
            this.LblGetNetDevSample_Filters.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDevSample_Filters.Name = "LblGetNetDevSample_Filters";
            this.LblGetNetDevSample_Filters.Size = new System.Drawing.Size(140, 26);
            this.LblGetNetDevSample_Filters.TabIndex = 5;
            this.LblGetNetDevSample_Filters.Text = "Filters (TimeFilter):";
            this.LblGetNetDevSample_Filters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TlpGetNetDevSamples_Filters
            // 
            this.TlpGetNetDevSamples_Filters.AutoSize = true;
            this.TlpGetNetDevSamples_Filters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpGetNetDevSamples_Filters.ColumnCount = 4;
            this.TlpGetNetDevSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetNetDevSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetNetDevSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetNetDevSamples_Filters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetNetDevSamples_Filters.Controls.Add(this.LblGetNetDevSamples_StartTime, 0, 0);
            this.TlpGetNetDevSamples_Filters.Controls.Add(this.DtpGetNetDevSamples_StartTime, 1, 0);
            this.TlpGetNetDevSamples_Filters.Controls.Add(this.DtpGetNetDevSamples_EndTime, 3, 0);
            this.TlpGetNetDevSamples_Filters.Controls.Add(this.LblGetNetDevSamples_EndTime, 2, 0);
            this.TlpGetNetDevSamples_Filters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetNetDevSamples_Filters.Location = new System.Drawing.Point(169, 78);
            this.TlpGetNetDevSamples_Filters.Name = "TlpGetNetDevSamples_Filters";
            this.TlpGetNetDevSamples_Filters.RowCount = 1;
            this.TlpGetNetDevSamples_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetNetDevSamples_Filters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.TlpGetNetDevSamples_Filters.Size = new System.Drawing.Size(640, 26);
            this.TlpGetNetDevSamples_Filters.TabIndex = 6;
            // 
            // LblGetNetDevSamples_StartTime
            // 
            this.LblGetNetDevSamples_StartTime.AutoSize = true;
            this.LblGetNetDevSamples_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDevSamples_StartTime.Location = new System.Drawing.Point(3, 3);
            this.LblGetNetDevSamples_StartTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDevSamples_StartTime.Name = "LblGetNetDevSamples_StartTime";
            this.LblGetNetDevSamples_StartTime.Size = new System.Drawing.Size(55, 20);
            this.LblGetNetDevSamples_StartTime.TabIndex = 0;
            this.LblGetNetDevSamples_StartTime.Text = "Start Time";
            this.LblGetNetDevSamples_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpGetNetDevSamples_StartTime
            // 
            this.DtpGetNetDevSamples_StartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetNetDevSamples_StartTime.Location = new System.Drawing.Point(64, 3);
            this.DtpGetNetDevSamples_StartTime.Name = "DtpGetNetDevSamples_StartTime";
            this.DtpGetNetDevSamples_StartTime.Size = new System.Drawing.Size(254, 20);
            this.DtpGetNetDevSamples_StartTime.TabIndex = 1;
            // 
            // DtpGetNetDevSamples_EndTime
            // 
            this.DtpGetNetDevSamples_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtpGetNetDevSamples_EndTime.Location = new System.Drawing.Point(382, 3);
            this.DtpGetNetDevSamples_EndTime.Name = "DtpGetNetDevSamples_EndTime";
            this.DtpGetNetDevSamples_EndTime.Size = new System.Drawing.Size(255, 20);
            this.DtpGetNetDevSamples_EndTime.TabIndex = 2;
            // 
            // LblGetNetDevSamples_EndTime
            // 
            this.LblGetNetDevSamples_EndTime.AutoSize = true;
            this.LblGetNetDevSamples_EndTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetNetDevSamples_EndTime.Location = new System.Drawing.Point(324, 3);
            this.LblGetNetDevSamples_EndTime.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetNetDevSamples_EndTime.Name = "LblGetNetDevSamples_EndTime";
            this.LblGetNetDevSamples_EndTime.Size = new System.Drawing.Size(52, 20);
            this.LblGetNetDevSamples_EndTime.TabIndex = 3;
            this.LblGetNetDevSamples_EndTime.Text = "End Time";
            this.LblGetNetDevSamples_EndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnGetNetDevSamples
            // 
            this.BtnGetNetDevSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGetNetDevSamples.Location = new System.Drawing.Point(169, 110);
            this.BtnGetNetDevSamples.Name = "BtnGetNetDevSamples";
            this.BtnGetNetDevSamples.Size = new System.Drawing.Size(640, 23);
            this.BtnGetNetDevSamples.TabIndex = 7;
            this.BtnGetNetDevSamples.Text = "Trends.GetNetDevSamples";
            this.BtnGetNetDevSamples.UseVisualStyleBackColor = true;
            this.BtnGetNetDevSamples.Click += new System.EventHandler(this.BtnGetNetDevSamples_Click);
            // 
            // DgvGetNetDevSamples
            // 
            this.DgvGetNetDevSamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetNetDevSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetNetDevSamples.Location = new System.Drawing.Point(169, 139);
            this.DgvGetNetDevSamples.Name = "DgvGetNetDevSamples";
            this.DgvGetNetDevSamples.Size = new System.Drawing.Size(640, 319);
            this.DgvGetNetDevSamples.TabIndex = 8;
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
            this.TlpGetTrendedAttributes.ResumeLayout(false);
            this.TlpGetTrendedAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetTrendedAttributes)).EndInit();
            this.TpgGetSamples.ResumeLayout(false);
            this.TlpGetSamples.ResumeLayout(false);
            this.TlpGetSamples.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGetSamples_AttributeID)).EndInit();
            this.TlpGetSamples_Filters.ResumeLayout(false);
            this.TlpGetSamples_Filters.PerformLayout();
            this.TpgGetNetDevTrendedAttributes.ResumeLayout(false);
            this.TlpGetNetDevTrendedAttributes.ResumeLayout(false);
            this.TlpGetNetDevTrendedAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetDevTrendedAttributes)).EndInit();
            this.TpgGetNetDevSamples.ResumeLayout(false);
            this.TlpGeNetDevSamples.ResumeLayout(false);
            this.TlpGeNetDevSamples.PerformLayout();
            this.TlpGetNetDevSamples_Filters.ResumeLayout(false);
            this.TlpGetNetDevSamples_Filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetNetDevSamples)).EndInit();
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
        private System.Windows.Forms.Label LblGetSamples_Filters;
        private System.Windows.Forms.TableLayoutPanel TlpGetSamples_Filters;
        private System.Windows.Forms.Label LblGetSamples_StartTime;
        private System.Windows.Forms.DateTimePicker DtpGetSamples_StartTime;
        private System.Windows.Forms.Label LblGetSamples_EndTime;
        private System.Windows.Forms.DateTimePicker DtpGetSamples_EndTime;
        private System.Windows.Forms.Label LblGetTrendedAttributes_Title;
        private System.Windows.Forms.TabPage TpgGetNetDevTrendedAttributes;
        private System.Windows.Forms.TableLayoutPanel TlpGetNetDevTrendedAttributes;
        private System.Windows.Forms.Label LblGetNetDeTrendedAttributes_NetDevID;
        private System.Windows.Forms.TextBox TxtGetNetDeTrendedAttributes_NetDevID;
        private System.Windows.Forms.Button BtnGetNetDevTrendedAttributes;
        private System.Windows.Forms.DataGridView DgvGetNetDevTrendedAttributes;
        private System.Windows.Forms.Label LblGetSamples_Title;
        private System.Windows.Forms.Label LblGetNetDevTrendedAttributes;
        private System.Windows.Forms.TabPage TpgGetNetDevSamples;
        private System.Windows.Forms.TableLayoutPanel TlpGeNetDevSamples;
        private System.Windows.Forms.Label LblGetNetDevSamples_NetDevID;
        private System.Windows.Forms.TextBox TxtGetNetDevSamples_NetDevID;
        private System.Windows.Forms.Label LblGetNetDevSamples_AttributeID;
        private System.Windows.Forms.ComboBox CmbGetNetDevSamples_AttributeID;
        private System.Windows.Forms.Label LblGetNetDevSamples_Title;
        private System.Windows.Forms.Label LblGetNetDevSample_Filters;
        private System.Windows.Forms.TableLayoutPanel TlpGetNetDevSamples_Filters;
        private System.Windows.Forms.Label LblGetNetDevSamples_StartTime;
        private System.Windows.Forms.DateTimePicker DtpGetNetDevSamples_StartTime;
        private System.Windows.Forms.DateTimePicker DtpGetNetDevSamples_EndTime;
        private System.Windows.Forms.Label LblGetNetDevSamples_EndTime;
        private System.Windows.Forms.Button BtnGetNetDevSamples;
        private System.Windows.Forms.DataGridView DgvGetNetDevSamples;
    }
}