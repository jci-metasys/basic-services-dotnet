
namespace MetasysServices_TestClient.Forms
{
    partial class Objects
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
            this.TpgGetObjectIdentifier = new System.Windows.Forms.TabPage();
            this.TlpGetObjectIdentifier = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetObjectIdentifier_ObjectFQR = new System.Windows.Forms.Label();
            this.TxtGetObjectIdentifier_ObjectFQR = new System.Windows.Forms.TextBox();
            this.BtnGetObjectIdentifier = new System.Windows.Forms.Button();
            this.LblGetObjectIdentifier_Result = new System.Windows.Forms.Label();
            this.TxtGetObjectIdentifier_Result = new System.Windows.Forms.TextBox();
            this.TpgGetObjects = new System.Windows.Forms.TabPage();
            this.TlpGetObjects = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetObjects_ParentID = new System.Windows.Forms.Label();
            this.TxtGetObjects_ParentID = new System.Windows.Forms.TextBox();
            this.BtnGetObjects = new System.Windows.Forms.Button();
            this.DgvGetObjects = new System.Windows.Forms.DataGridView();
            this.TpgGetCommands = new System.Windows.Forms.TabPage();
            this.TlpGetCommands = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetCommands_ObjectId = new System.Windows.Forms.Label();
            this.TxtGetCommands_ObjectId = new System.Windows.Forms.TextBox();
            this.BtnGetCommands = new System.Windows.Forms.Button();
            this.DgvGetCommands = new System.Windows.Forms.DataGridView();
            this.DgvGetCommands_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvGetCommands_CommandId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvGetCommands_TitleEnumerationKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnGetCommands_RetrieveEnumValues = new System.Windows.Forms.Button();
            this.DgvGetCommands_RetrieveEnumValues = new System.Windows.Forms.DataGridView();
            this.DgvCommandEnum_TitleEnumerationKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpgGetCommandEnumeration = new System.Windows.Forms.TabPage();
            this.TlpGetCommandEnumeration = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetCommandEnumeration_EnumTitle = new System.Windows.Forms.Label();
            this.TxtGetCommandEnumeration_EnumTitle = new System.Windows.Forms.TextBox();
            this.BtnGetCommandEnumeration = new System.Windows.Forms.Button();
            this.TpgReadProperty = new System.Windows.Forms.TabPage();
            this.TlpReadProperty = new System.Windows.Forms.TableLayoutPanel();
            this.LblReadProperty_ObjectId = new System.Windows.Forms.Label();
            this.TxtReadProperty_ObjectId = new System.Windows.Forms.TextBox();
            this.TxtReadProperty = new System.Windows.Forms.TextBox();
            this.LblReadProperty = new System.Windows.Forms.Label();
            this.BtnReadProperty = new System.Windows.Forms.Button();
            this.LblReadProperty_Result = new System.Windows.Forms.Label();
            this.TxtReadProperty_Result = new System.Windows.Forms.TextBox();
            this.LblExample_EnumTitle = new System.Windows.Forms.Label();
            this.TxtGetCommandEnumeration_Result = new System.Windows.Forms.TextBox();
            this.TabMain.SuspendLayout();
            this.TpgGetObjectIdentifier.SuspendLayout();
            this.TlpGetObjectIdentifier.SuspendLayout();
            this.TpgGetObjects.SuspendLayout();
            this.TlpGetObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetObjects)).BeginInit();
            this.TpgGetCommands.SuspendLayout();
            this.TlpGetCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommands_RetrieveEnumValues)).BeginInit();
            this.TpgGetCommandEnumeration.SuspendLayout();
            this.TlpGetCommandEnumeration.SuspendLayout();
            this.TpgReadProperty.SuspendLayout();
            this.TlpReadProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetObjectIdentifier);
            this.TabMain.Controls.Add(this.TpgGetObjects);
            this.TabMain.Controls.Add(this.TpgGetCommands);
            this.TabMain.Controls.Add(this.TpgGetCommandEnumeration);
            this.TabMain.Controls.Add(this.TpgReadProperty);
            this.TabMain.ItemSize = new System.Drawing.Size(58, 25);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(975, 590);
            this.TabMain.TabIndex = 0;
            // 
            // TpgGetObjectIdentifier
            // 
            this.TpgGetObjectIdentifier.Controls.Add(this.TlpGetObjectIdentifier);
            this.TpgGetObjectIdentifier.Location = new System.Drawing.Point(4, 29);
            this.TpgGetObjectIdentifier.Name = "TpgGetObjectIdentifier";
            this.TpgGetObjectIdentifier.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetObjectIdentifier.Size = new System.Drawing.Size(967, 557);
            this.TpgGetObjectIdentifier.TabIndex = 0;
            this.TpgGetObjectIdentifier.Text = "GetObjectidentifier";
            this.TpgGetObjectIdentifier.UseVisualStyleBackColor = true;
            // 
            // TlpGetObjectIdentifier
            // 
            this.TlpGetObjectIdentifier.ColumnCount = 4;
            this.TlpGetObjectIdentifier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjectIdentifier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetObjectIdentifier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetObjectIdentifier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjectIdentifier.Controls.Add(this.LblGetObjectIdentifier_ObjectFQR, 1, 1);
            this.TlpGetObjectIdentifier.Controls.Add(this.TxtGetObjectIdentifier_ObjectFQR, 2, 1);
            this.TlpGetObjectIdentifier.Controls.Add(this.BtnGetObjectIdentifier, 2, 2);
            this.TlpGetObjectIdentifier.Controls.Add(this.LblGetObjectIdentifier_Result, 1, 3);
            this.TlpGetObjectIdentifier.Controls.Add(this.TxtGetObjectIdentifier_Result, 2, 3);
            this.TlpGetObjectIdentifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetObjectIdentifier.Location = new System.Drawing.Point(3, 3);
            this.TlpGetObjectIdentifier.Name = "TlpGetObjectIdentifier";
            this.TlpGetObjectIdentifier.RowCount = 6;
            this.TlpGetObjectIdentifier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjectIdentifier.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetObjectIdentifier.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetObjectIdentifier.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetObjectIdentifier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetObjectIdentifier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjectIdentifier.Size = new System.Drawing.Size(961, 551);
            this.TlpGetObjectIdentifier.TabIndex = 0;
            // 
            // LblGetObjectIdentifier_ObjectFQR
            // 
            this.LblGetObjectIdentifier_ObjectFQR.AutoSize = true;
            this.LblGetObjectIdentifier_ObjectFQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetObjectIdentifier_ObjectFQR.Location = new System.Drawing.Point(23, 23);
            this.LblGetObjectIdentifier_ObjectFQR.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetObjectIdentifier_ObjectFQR.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetObjectIdentifier_ObjectFQR.Name = "LblGetObjectIdentifier_ObjectFQR";
            this.LblGetObjectIdentifier_ObjectFQR.Size = new System.Drawing.Size(100, 20);
            this.LblGetObjectIdentifier_ObjectFQR.TabIndex = 0;
            this.LblGetObjectIdentifier_ObjectFQR.Text = "Object FQR:";
            this.LblGetObjectIdentifier_ObjectFQR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetObjectIdentifier_ObjectFQR
            // 
            this.TxtGetObjectIdentifier_ObjectFQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetObjectIdentifier_ObjectFQR.Location = new System.Drawing.Point(129, 23);
            this.TxtGetObjectIdentifier_ObjectFQR.Name = "TxtGetObjectIdentifier_ObjectFQR";
            this.TxtGetObjectIdentifier_ObjectFQR.Size = new System.Drawing.Size(809, 20);
            this.TxtGetObjectIdentifier_ObjectFQR.TabIndex = 1;
            // 
            // BtnGetObjectIdentifier
            // 
            this.BtnGetObjectIdentifier.Location = new System.Drawing.Point(129, 49);
            this.BtnGetObjectIdentifier.MinimumSize = new System.Drawing.Size(130, 0);
            this.BtnGetObjectIdentifier.Name = "BtnGetObjectIdentifier";
            this.BtnGetObjectIdentifier.Size = new System.Drawing.Size(130, 23);
            this.BtnGetObjectIdentifier.TabIndex = 2;
            this.BtnGetObjectIdentifier.Text = "GetObjectIdentifier";
            this.BtnGetObjectIdentifier.UseVisualStyleBackColor = true;
            this.BtnGetObjectIdentifier.Click += new System.EventHandler(this.BtnGetObjectIdentifier_Click);
            // 
            // LblGetObjectIdentifier_Result
            // 
            this.LblGetObjectIdentifier_Result.AutoSize = true;
            this.LblGetObjectIdentifier_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetObjectIdentifier_Result.Location = new System.Drawing.Point(23, 78);
            this.LblGetObjectIdentifier_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetObjectIdentifier_Result.Name = "LblGetObjectIdentifier_Result";
            this.LblGetObjectIdentifier_Result.Size = new System.Drawing.Size(100, 20);
            this.LblGetObjectIdentifier_Result.TabIndex = 3;
            this.LblGetObjectIdentifier_Result.Text = "Result:";
            this.LblGetObjectIdentifier_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetObjectIdentifier_Result
            // 
            this.TxtGetObjectIdentifier_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetObjectIdentifier_Result.Location = new System.Drawing.Point(129, 78);
            this.TxtGetObjectIdentifier_Result.Name = "TxtGetObjectIdentifier_Result";
            this.TxtGetObjectIdentifier_Result.ReadOnly = true;
            this.TxtGetObjectIdentifier_Result.Size = new System.Drawing.Size(809, 20);
            this.TxtGetObjectIdentifier_Result.TabIndex = 4;
            // 
            // TpgGetObjects
            // 
            this.TpgGetObjects.Controls.Add(this.TlpGetObjects);
            this.TpgGetObjects.Location = new System.Drawing.Point(4, 29);
            this.TpgGetObjects.Name = "TpgGetObjects";
            this.TpgGetObjects.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetObjects.Size = new System.Drawing.Size(967, 557);
            this.TpgGetObjects.TabIndex = 1;
            this.TpgGetObjects.Text = "GetObjects";
            this.TpgGetObjects.UseVisualStyleBackColor = true;
            // 
            // TlpGetObjects
            // 
            this.TlpGetObjects.ColumnCount = 4;
            this.TlpGetObjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetObjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetObjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjects.Controls.Add(this.LblGetObjects_ParentID, 1, 1);
            this.TlpGetObjects.Controls.Add(this.TxtGetObjects_ParentID, 2, 1);
            this.TlpGetObjects.Controls.Add(this.BtnGetObjects, 2, 2);
            this.TlpGetObjects.Controls.Add(this.DgvGetObjects, 2, 3);
            this.TlpGetObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetObjects.Location = new System.Drawing.Point(3, 3);
            this.TlpGetObjects.Name = "TlpGetObjects";
            this.TlpGetObjects.RowCount = 5;
            this.TlpGetObjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjects.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetObjects.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetObjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetObjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetObjects.Size = new System.Drawing.Size(961, 551);
            this.TlpGetObjects.TabIndex = 0;
            // 
            // LblGetObjects_ParentID
            // 
            this.LblGetObjects_ParentID.AutoSize = true;
            this.LblGetObjects_ParentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetObjects_ParentID.Location = new System.Drawing.Point(23, 23);
            this.LblGetObjects_ParentID.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetObjects_ParentID.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetObjects_ParentID.Name = "LblGetObjects_ParentID";
            this.LblGetObjects_ParentID.Size = new System.Drawing.Size(100, 20);
            this.LblGetObjects_ParentID.TabIndex = 0;
            this.LblGetObjects_ParentID.Text = "Parent ID (GUID):";
            this.LblGetObjects_ParentID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetObjects_ParentID
            // 
            this.TxtGetObjects_ParentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetObjects_ParentID.Location = new System.Drawing.Point(129, 23);
            this.TxtGetObjects_ParentID.Name = "TxtGetObjects_ParentID";
            this.TxtGetObjects_ParentID.Size = new System.Drawing.Size(809, 20);
            this.TxtGetObjects_ParentID.TabIndex = 1;
            // 
            // BtnGetObjects
            // 
            this.BtnGetObjects.Location = new System.Drawing.Point(129, 49);
            this.BtnGetObjects.MinimumSize = new System.Drawing.Size(130, 0);
            this.BtnGetObjects.Name = "BtnGetObjects";
            this.BtnGetObjects.Size = new System.Drawing.Size(130, 23);
            this.BtnGetObjects.TabIndex = 2;
            this.BtnGetObjects.Text = "GetObjects";
            this.BtnGetObjects.UseVisualStyleBackColor = true;
            this.BtnGetObjects.Click += new System.EventHandler(this.BtnGetObjects_Click);
            // 
            // DgvGetObjects
            // 
            this.DgvGetObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetObjects.Location = new System.Drawing.Point(129, 78);
            this.DgvGetObjects.Name = "DgvGetObjects";
            this.DgvGetObjects.Size = new System.Drawing.Size(809, 450);
            this.DgvGetObjects.TabIndex = 3;
            // 
            // TpgGetCommands
            // 
            this.TpgGetCommands.Controls.Add(this.TlpGetCommands);
            this.TpgGetCommands.Location = new System.Drawing.Point(4, 29);
            this.TpgGetCommands.Name = "TpgGetCommands";
            this.TpgGetCommands.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetCommands.Size = new System.Drawing.Size(967, 557);
            this.TpgGetCommands.TabIndex = 2;
            this.TpgGetCommands.Text = "GetCommands";
            this.TpgGetCommands.UseVisualStyleBackColor = true;
            // 
            // TlpGetCommands
            // 
            this.TlpGetCommands.ColumnCount = 4;
            this.TlpGetCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommands.Controls.Add(this.LblGetCommands_ObjectId, 1, 1);
            this.TlpGetCommands.Controls.Add(this.TxtGetCommands_ObjectId, 2, 1);
            this.TlpGetCommands.Controls.Add(this.BtnGetCommands, 2, 2);
            this.TlpGetCommands.Controls.Add(this.DgvGetCommands, 2, 3);
            this.TlpGetCommands.Controls.Add(this.BtnGetCommands_RetrieveEnumValues, 2, 4);
            this.TlpGetCommands.Controls.Add(this.DgvGetCommands_RetrieveEnumValues, 2, 5);
            this.TlpGetCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetCommands.Location = new System.Drawing.Point(3, 3);
            this.TlpGetCommands.Name = "TlpGetCommands";
            this.TlpGetCommands.RowCount = 7;
            this.TlpGetCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpGetCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommands.Size = new System.Drawing.Size(961, 551);
            this.TlpGetCommands.TabIndex = 0;
            // 
            // LblGetCommands_ObjectId
            // 
            this.LblGetCommands_ObjectId.AutoSize = true;
            this.LblGetCommands_ObjectId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetCommands_ObjectId.Location = new System.Drawing.Point(23, 23);
            this.LblGetCommands_ObjectId.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetCommands_ObjectId.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetCommands_ObjectId.Name = "LblGetCommands_ObjectId";
            this.LblGetCommands_ObjectId.Size = new System.Drawing.Size(100, 20);
            this.LblGetCommands_ObjectId.TabIndex = 0;
            this.LblGetCommands_ObjectId.Text = "Object ID (GUID):";
            this.LblGetCommands_ObjectId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetCommands_ObjectId
            // 
            this.TxtGetCommands_ObjectId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetCommands_ObjectId.Location = new System.Drawing.Point(129, 23);
            this.TxtGetCommands_ObjectId.Name = "TxtGetCommands_ObjectId";
            this.TxtGetCommands_ObjectId.Size = new System.Drawing.Size(809, 20);
            this.TxtGetCommands_ObjectId.TabIndex = 1;
            // 
            // BtnGetCommands
            // 
            this.BtnGetCommands.Location = new System.Drawing.Point(129, 49);
            this.BtnGetCommands.MinimumSize = new System.Drawing.Size(130, 0);
            this.BtnGetCommands.Name = "BtnGetCommands";
            this.BtnGetCommands.Size = new System.Drawing.Size(130, 23);
            this.BtnGetCommands.TabIndex = 2;
            this.BtnGetCommands.Text = "GetCommands";
            this.BtnGetCommands.UseVisualStyleBackColor = true;
            this.BtnGetCommands.Click += new System.EventHandler(this.BtnGetCommands_Click);
            // 
            // DgvGetCommands
            // 
            this.DgvGetCommands.AllowUserToAddRows = false;
            this.DgvGetCommands.AllowUserToDeleteRows = false;
            this.DgvGetCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvGetCommands_Title,
            this.DgvGetCommands_CommandId,
            this.DgvGetCommands_TitleEnumerationKey});
            this.DgvGetCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetCommands.Location = new System.Drawing.Point(129, 78);
            this.DgvGetCommands.Name = "DgvGetCommands";
            this.DgvGetCommands.Size = new System.Drawing.Size(809, 207);
            this.DgvGetCommands.TabIndex = 3;
            // 
            // DgvGetCommands_Title
            // 
            this.DgvGetCommands_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvGetCommands_Title.HeaderText = "Title";
            this.DgvGetCommands_Title.Name = "DgvGetCommands_Title";
            this.DgvGetCommands_Title.Width = 52;
            // 
            // DgvGetCommands_CommandId
            // 
            this.DgvGetCommands_CommandId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvGetCommands_CommandId.HeaderText = "CommandId";
            this.DgvGetCommands_CommandId.Name = "DgvGetCommands_CommandId";
            this.DgvGetCommands_CommandId.Width = 88;
            // 
            // DgvGetCommands_TitleEnumerationKey
            // 
            this.DgvGetCommands_TitleEnumerationKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvGetCommands_TitleEnumerationKey.HeaderText = "TitleEnumerationKey";
            this.DgvGetCommands_TitleEnumerationKey.Name = "DgvGetCommands_TitleEnumerationKey";
            this.DgvGetCommands_TitleEnumerationKey.Width = 129;
            // 
            // BtnGetCommands_RetrieveEnumValues
            // 
            this.BtnGetCommands_RetrieveEnumValues.Location = new System.Drawing.Point(129, 291);
            this.BtnGetCommands_RetrieveEnumValues.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetCommands_RetrieveEnumValues.Name = "BtnGetCommands_RetrieveEnumValues";
            this.BtnGetCommands_RetrieveEnumValues.Size = new System.Drawing.Size(260, 23);
            this.BtnGetCommands_RetrieveEnumValues.TabIndex = 4;
            this.BtnGetCommands_RetrieveEnumValues.Text = "Retrieve Enumeration Values";
            this.BtnGetCommands_RetrieveEnumValues.UseVisualStyleBackColor = true;
            this.BtnGetCommands_RetrieveEnumValues.Click += new System.EventHandler(this.BtnGetCommands_RetrieveEnumValues_Click);
            // 
            // DgvGetCommands_RetrieveEnumValues
            // 
            this.DgvGetCommands_RetrieveEnumValues.AllowUserToAddRows = false;
            this.DgvGetCommands_RetrieveEnumValues.AllowUserToDeleteRows = false;
            this.DgvGetCommands_RetrieveEnumValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetCommands_RetrieveEnumValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvCommandEnum_TitleEnumerationKey});
            this.DgvGetCommands_RetrieveEnumValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetCommands_RetrieveEnumValues.Location = new System.Drawing.Point(129, 320);
            this.DgvGetCommands_RetrieveEnumValues.Name = "DgvGetCommands_RetrieveEnumValues";
            this.DgvGetCommands_RetrieveEnumValues.Size = new System.Drawing.Size(809, 207);
            this.DgvGetCommands_RetrieveEnumValues.TabIndex = 5;
            // 
            // DgvCommandEnum_TitleEnumerationKey
            // 
            this.DgvCommandEnum_TitleEnumerationKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DgvCommandEnum_TitleEnumerationKey.HeaderText = "TitleEnumerationKey";
            this.DgvCommandEnum_TitleEnumerationKey.Name = "DgvCommandEnum_TitleEnumerationKey";
            this.DgvCommandEnum_TitleEnumerationKey.Width = 129;
            // 
            // TpgGetCommandEnumeration
            // 
            this.TpgGetCommandEnumeration.Controls.Add(this.TlpGetCommandEnumeration);
            this.TpgGetCommandEnumeration.Location = new System.Drawing.Point(4, 29);
            this.TpgGetCommandEnumeration.Name = "TpgGetCommandEnumeration";
            this.TpgGetCommandEnumeration.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetCommandEnumeration.Size = new System.Drawing.Size(967, 557);
            this.TpgGetCommandEnumeration.TabIndex = 3;
            this.TpgGetCommandEnumeration.Text = "GetCommandEnumeration";
            this.TpgGetCommandEnumeration.UseVisualStyleBackColor = true;
            // 
            // TlpGetCommandEnumeration
            // 
            this.TlpGetCommandEnumeration.ColumnCount = 5;
            this.TlpGetCommandEnumeration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommandEnumeration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetCommandEnumeration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetCommandEnumeration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetCommandEnumeration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommandEnumeration.Controls.Add(this.LblGetCommandEnumeration_EnumTitle, 1, 1);
            this.TlpGetCommandEnumeration.Controls.Add(this.TxtGetCommandEnumeration_EnumTitle, 2, 1);
            this.TlpGetCommandEnumeration.Controls.Add(this.BtnGetCommandEnumeration, 2, 2);
            this.TlpGetCommandEnumeration.Controls.Add(this.LblExample_EnumTitle, 3, 1);
            this.TlpGetCommandEnumeration.Controls.Add(this.TxtGetCommandEnumeration_Result, 2, 3);
            this.TlpGetCommandEnumeration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetCommandEnumeration.Location = new System.Drawing.Point(3, 3);
            this.TlpGetCommandEnumeration.Name = "TlpGetCommandEnumeration";
            this.TlpGetCommandEnumeration.RowCount = 6;
            this.TlpGetCommandEnumeration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommandEnumeration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetCommandEnumeration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetCommandEnumeration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetCommandEnumeration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetCommandEnumeration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetCommandEnumeration.Size = new System.Drawing.Size(961, 551);
            this.TlpGetCommandEnumeration.TabIndex = 0;
            // 
            // LblGetCommandEnumeration_EnumTitle
            // 
            this.LblGetCommandEnumeration_EnumTitle.AutoSize = true;
            this.LblGetCommandEnumeration_EnumTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetCommandEnumeration_EnumTitle.Location = new System.Drawing.Point(23, 23);
            this.LblGetCommandEnumeration_EnumTitle.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetCommandEnumeration_EnumTitle.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetCommandEnumeration_EnumTitle.Name = "LblGetCommandEnumeration_EnumTitle";
            this.LblGetCommandEnumeration_EnumTitle.Size = new System.Drawing.Size(100, 20);
            this.LblGetCommandEnumeration_EnumTitle.TabIndex = 0;
            this.LblGetCommandEnumeration_EnumTitle.Text = "Enum Title (String):";
            this.LblGetCommandEnumeration_EnumTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetCommandEnumeration_EnumTitle
            // 
            this.TxtGetCommandEnumeration_EnumTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetCommandEnumeration_EnumTitle.Location = new System.Drawing.Point(129, 23);
            this.TxtGetCommandEnumeration_EnumTitle.Name = "TxtGetCommandEnumeration_EnumTitle";
            this.TxtGetCommandEnumeration_EnumTitle.Size = new System.Drawing.Size(698, 20);
            this.TxtGetCommandEnumeration_EnumTitle.TabIndex = 1;
            // 
            // BtnGetCommandEnumeration
            // 
            this.BtnGetCommandEnumeration.Location = new System.Drawing.Point(129, 49);
            this.BtnGetCommandEnumeration.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetCommandEnumeration.Name = "BtnGetCommandEnumeration";
            this.BtnGetCommandEnumeration.Size = new System.Drawing.Size(260, 23);
            this.BtnGetCommandEnumeration.TabIndex = 2;
            this.BtnGetCommandEnumeration.Text = "GetCommandEnumeration";
            this.BtnGetCommandEnumeration.UseVisualStyleBackColor = true;
            this.BtnGetCommandEnumeration.Click += new System.EventHandler(this.BtnGetCommandEnumeration_Click);
            // 
            // TpgReadProperty
            // 
            this.TpgReadProperty.Controls.Add(this.TlpReadProperty);
            this.TpgReadProperty.Location = new System.Drawing.Point(4, 29);
            this.TpgReadProperty.Name = "TpgReadProperty";
            this.TpgReadProperty.Padding = new System.Windows.Forms.Padding(3);
            this.TpgReadProperty.Size = new System.Drawing.Size(967, 557);
            this.TpgReadProperty.TabIndex = 4;
            this.TpgReadProperty.Text = "ReadProperty";
            this.TpgReadProperty.UseVisualStyleBackColor = true;
            // 
            // TlpReadProperty
            // 
            this.TlpReadProperty.ColumnCount = 4;
            this.TlpReadProperty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpReadProperty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpReadProperty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpReadProperty.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpReadProperty.Controls.Add(this.LblReadProperty_ObjectId, 1, 1);
            this.TlpReadProperty.Controls.Add(this.TxtReadProperty_ObjectId, 2, 1);
            this.TlpReadProperty.Controls.Add(this.TxtReadProperty, 2, 2);
            this.TlpReadProperty.Controls.Add(this.LblReadProperty, 1, 2);
            this.TlpReadProperty.Controls.Add(this.BtnReadProperty, 2, 3);
            this.TlpReadProperty.Controls.Add(this.LblReadProperty_Result, 1, 4);
            this.TlpReadProperty.Controls.Add(this.TxtReadProperty_Result, 2, 4);
            this.TlpReadProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpReadProperty.Location = new System.Drawing.Point(3, 3);
            this.TlpReadProperty.Name = "TlpReadProperty";
            this.TlpReadProperty.RowCount = 7;
            this.TlpReadProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpReadProperty.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpReadProperty.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpReadProperty.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpReadProperty.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpReadProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpReadProperty.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpReadProperty.Size = new System.Drawing.Size(961, 551);
            this.TlpReadProperty.TabIndex = 0;
            // 
            // LblReadProperty_ObjectId
            // 
            this.LblReadProperty_ObjectId.AutoSize = true;
            this.LblReadProperty_ObjectId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblReadProperty_ObjectId.Location = new System.Drawing.Point(23, 23);
            this.LblReadProperty_ObjectId.Margin = new System.Windows.Forms.Padding(3);
            this.LblReadProperty_ObjectId.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblReadProperty_ObjectId.Name = "LblReadProperty_ObjectId";
            this.LblReadProperty_ObjectId.Size = new System.Drawing.Size(100, 20);
            this.LblReadProperty_ObjectId.TabIndex = 0;
            this.LblReadProperty_ObjectId.Text = "Object ID (GUID):";
            this.LblReadProperty_ObjectId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtReadProperty_ObjectId
            // 
            this.TxtReadProperty_ObjectId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtReadProperty_ObjectId.Location = new System.Drawing.Point(129, 23);
            this.TxtReadProperty_ObjectId.Name = "TxtReadProperty_ObjectId";
            this.TxtReadProperty_ObjectId.Size = new System.Drawing.Size(809, 20);
            this.TxtReadProperty_ObjectId.TabIndex = 1;
            // 
            // TxtReadProperty
            // 
            this.TxtReadProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtReadProperty.Location = new System.Drawing.Point(129, 49);
            this.TxtReadProperty.Name = "TxtReadProperty";
            this.TxtReadProperty.Size = new System.Drawing.Size(809, 20);
            this.TxtReadProperty.TabIndex = 2;
            this.TxtReadProperty.Text = "presentValue";
            // 
            // LblReadProperty
            // 
            this.LblReadProperty.AutoSize = true;
            this.LblReadProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblReadProperty.Location = new System.Drawing.Point(23, 49);
            this.LblReadProperty.Margin = new System.Windows.Forms.Padding(3);
            this.LblReadProperty.Name = "LblReadProperty";
            this.LblReadProperty.Size = new System.Drawing.Size(100, 20);
            this.LblReadProperty.TabIndex = 3;
            this.LblReadProperty.Text = "Property Key:";
            this.LblReadProperty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnReadProperty
            // 
            this.BtnReadProperty.Location = new System.Drawing.Point(129, 75);
            this.BtnReadProperty.MinimumSize = new System.Drawing.Size(130, 0);
            this.BtnReadProperty.Name = "BtnReadProperty";
            this.BtnReadProperty.Size = new System.Drawing.Size(130, 23);
            this.BtnReadProperty.TabIndex = 4;
            this.BtnReadProperty.Text = "ReadProperty";
            this.BtnReadProperty.UseVisualStyleBackColor = true;
            this.BtnReadProperty.Click += new System.EventHandler(this.BtnReadProperty_Click);
            // 
            // LblReadProperty_Result
            // 
            this.LblReadProperty_Result.AutoSize = true;
            this.LblReadProperty_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblReadProperty_Result.Location = new System.Drawing.Point(23, 104);
            this.LblReadProperty_Result.Margin = new System.Windows.Forms.Padding(3);
            this.LblReadProperty_Result.Name = "LblReadProperty_Result";
            this.LblReadProperty_Result.Size = new System.Drawing.Size(100, 20);
            this.LblReadProperty_Result.TabIndex = 5;
            this.LblReadProperty_Result.Text = "Result:";
            this.LblReadProperty_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtReadProperty_Result
            // 
            this.TxtReadProperty_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtReadProperty_Result.Location = new System.Drawing.Point(129, 104);
            this.TxtReadProperty_Result.Name = "TxtReadProperty_Result";
            this.TxtReadProperty_Result.ReadOnly = true;
            this.TxtReadProperty_Result.Size = new System.Drawing.Size(809, 20);
            this.TxtReadProperty_Result.TabIndex = 6;
            // 
            // LblExample_EnumTitle
            // 
            this.LblExample_EnumTitle.AutoSize = true;
            this.LblExample_EnumTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblExample_EnumTitle.Location = new System.Drawing.Point(833, 23);
            this.LblExample_EnumTitle.Margin = new System.Windows.Forms.Padding(3);
            this.LblExample_EnumTitle.Name = "LblExample_EnumTitle";
            this.LblExample_EnumTitle.Size = new System.Drawing.Size(105, 20);
            this.LblExample_EnumTitle.TabIndex = 4;
            this.LblExample_EnumTitle.Text = "e.g. \"Set 1 Enabled\"";
            this.LblExample_EnumTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtGetCommandEnumeration_Result
            // 
            this.TxtGetCommandEnumeration_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetCommandEnumeration_Result.Location = new System.Drawing.Point(129, 78);
            this.TxtGetCommandEnumeration_Result.Name = "TxtGetCommandEnumeration_Result";
            this.TxtGetCommandEnumeration_Result.ReadOnly = true;
            this.TxtGetCommandEnumeration_Result.Size = new System.Drawing.Size(698, 20);
            this.TxtGetCommandEnumeration_Result.TabIndex = 5;
            // 
            // Objects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 614);
            this.Controls.Add(this.TabMain);
            this.Name = "Objects";
            this.Text = "Objects";
            this.TabMain.ResumeLayout(false);
            this.TpgGetObjectIdentifier.ResumeLayout(false);
            this.TlpGetObjectIdentifier.ResumeLayout(false);
            this.TlpGetObjectIdentifier.PerformLayout();
            this.TpgGetObjects.ResumeLayout(false);
            this.TlpGetObjects.ResumeLayout(false);
            this.TlpGetObjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetObjects)).EndInit();
            this.TpgGetCommands.ResumeLayout(false);
            this.TlpGetCommands.ResumeLayout(false);
            this.TlpGetCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetCommands_RetrieveEnumValues)).EndInit();
            this.TpgGetCommandEnumeration.ResumeLayout(false);
            this.TlpGetCommandEnumeration.ResumeLayout(false);
            this.TlpGetCommandEnumeration.PerformLayout();
            this.TpgReadProperty.ResumeLayout(false);
            this.TlpReadProperty.ResumeLayout(false);
            this.TlpReadProperty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgGetObjectIdentifier;
        private System.Windows.Forms.TabPage TpgGetObjects;
        private System.Windows.Forms.TabPage TpgGetCommands;
        private System.Windows.Forms.TableLayoutPanel TlpGetObjectIdentifier;
        private System.Windows.Forms.Label LblGetObjectIdentifier_ObjectFQR;
        private System.Windows.Forms.TextBox TxtGetObjectIdentifier_ObjectFQR;
        private System.Windows.Forms.Button BtnGetObjectIdentifier;
        private System.Windows.Forms.Label LblGetObjectIdentifier_Result;
        private System.Windows.Forms.TextBox TxtGetObjectIdentifier_Result;
        private System.Windows.Forms.TableLayoutPanel TlpGetObjects;
        private System.Windows.Forms.Label LblGetObjects_ParentID;
        private System.Windows.Forms.TextBox TxtGetObjects_ParentID;
        private System.Windows.Forms.Button BtnGetObjects;
        private System.Windows.Forms.DataGridView DgvGetObjects;
        private System.Windows.Forms.TableLayoutPanel TlpGetCommands;
        private System.Windows.Forms.Label LblGetCommands_ObjectId;
        private System.Windows.Forms.TextBox TxtGetCommands_ObjectId;
        private System.Windows.Forms.Button BtnGetCommands;
        private System.Windows.Forms.DataGridView DgvGetCommands;
        private System.Windows.Forms.Button BtnGetCommands_RetrieveEnumValues;
        private System.Windows.Forms.DataGridView DgvGetCommands_RetrieveEnumValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCommandEnum_TitleEnumerationKey;
        private System.Windows.Forms.TabPage TpgGetCommandEnumeration;
        private System.Windows.Forms.TableLayoutPanel TlpGetCommandEnumeration;
        private System.Windows.Forms.Label LblGetCommandEnumeration_EnumTitle;
        private System.Windows.Forms.TextBox TxtGetCommandEnumeration_EnumTitle;
        private System.Windows.Forms.Button BtnGetCommandEnumeration;
        private System.Windows.Forms.TabPage TpgReadProperty;
        private System.Windows.Forms.TableLayoutPanel TlpReadProperty;
        private System.Windows.Forms.Label LblReadProperty_ObjectId;
        private System.Windows.Forms.TextBox TxtReadProperty_ObjectId;
        private System.Windows.Forms.TextBox TxtReadProperty;
        private System.Windows.Forms.Label LblReadProperty;
        private System.Windows.Forms.Button BtnReadProperty;
        private System.Windows.Forms.Label LblReadProperty_Result;
        private System.Windows.Forms.TextBox TxtReadProperty_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvGetCommands_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvGetCommands_CommandId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvGetCommands_TitleEnumerationKey;
        private System.Windows.Forms.Label LblExample_EnumTitle;
        private System.Windows.Forms.TextBox TxtGetCommandEnumeration_Result;
    }
}