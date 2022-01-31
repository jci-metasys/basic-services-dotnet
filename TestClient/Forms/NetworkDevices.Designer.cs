
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LblFindById_NetworkDeviceID = new System.Windows.Forms.Label();
            this.TxtFindById_NetworkDeviceID = new System.Windows.Forms.TextBox();
            this.BtnFindById = new System.Windows.Forms.Button();
            this.PrgFindById = new System.Windows.Forms.PropertyGrid();
            this.TabMain.SuspendLayout();
            this.TpgGet.SuspendLayout();
            this.TlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGet)).BeginInit();
            this.TpgGetTypes.SuspendLayout();
            this.TlpGetTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetTypes)).BeginInit();
            this.TpgFindById.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGet);
            this.TabMain.Controls.Add(this.TpgGetTypes);
            this.TabMain.Controls.Add(this.TpgFindById);
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
            this.TpgFindById.Controls.Add(this.tableLayoutPanel1);
            this.TpgFindById.Location = new System.Drawing.Point(4, 29);
            this.TpgFindById.Name = "TpgFindById";
            this.TpgFindById.Padding = new System.Windows.Forms.Padding(3);
            this.TpgFindById.Size = new System.Drawing.Size(933, 569);
            this.TpgFindById.TabIndex = 1;
            this.TpgFindById.Text = "FindById";
            this.TpgFindById.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LblFindById_NetworkDeviceID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtFindById_NetworkDeviceID, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnFindById, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.PrgFindById, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 563);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LblFindById_NetworkDeviceID;
        private System.Windows.Forms.TextBox TxtFindById_NetworkDeviceID;
        private System.Windows.Forms.Button BtnFindById;
        private System.Windows.Forms.PropertyGrid PrgFindById;
    }
}