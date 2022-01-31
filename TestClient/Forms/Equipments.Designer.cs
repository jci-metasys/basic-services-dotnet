
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
            this.TpgGetSingleEquipment = new System.Windows.Forms.TabPage();
            this.TlpGetSingleEquipment = new System.Windows.Forms.TableLayoutPanel();
            this.LblGetSingleEquipment_EquipmentId = new System.Windows.Forms.Label();
            this.TxtGetSingleEquipment_EquipmentId = new System.Windows.Forms.TextBox();
            this.BtnGetSingleEquipemnt = new System.Windows.Forms.Button();
            this.PrgGetSingleEquipment = new System.Windows.Forms.PropertyGrid();
            this.TabMain.SuspendLayout();
            this.TpgGetEquipment.SuspendLayout();
            this.TlpGetEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipment)).BeginInit();
            this.TpgGetEquipmentPoints.SuspendLayout();
            this.TlpGetEquipmentpoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGetEquipmentPoints)).BeginInit();
            this.TpgGetSingleEquipment.SuspendLayout();
            this.TlpGetSingleEquipment.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabMain.Controls.Add(this.TpgGetEquipment);
            this.TabMain.Controls.Add(this.TpgGetEquipmentPoints);
            this.TabMain.Controls.Add(this.TpgGetSingleEquipment);
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
            this.TlpGetEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
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
            this.BtnGetEquipment.Location = new System.Drawing.Point(139, 23);
            this.BtnGetEquipment.Name = "BtnGetEquipment";
            this.BtnGetEquipment.Size = new System.Drawing.Size(130, 23);
            this.BtnGetEquipment.TabIndex = 0;
            this.BtnGetEquipment.Text = "GetEquipment";
            this.BtnGetEquipment.UseVisualStyleBackColor = true;
            this.BtnGetEquipment.Click += new System.EventHandler(this.BtnGetEquipment_Click);
            // 
            // DgvGetEquipment
            // 
            this.DgvGetEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetEquipment.Location = new System.Drawing.Point(139, 52);
            this.DgvGetEquipment.Name = "DgvGetEquipment";
            this.DgvGetEquipment.Size = new System.Drawing.Size(816, 444);
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
            this.LblGetEquipmentPoints_EquipID.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetEquipmentPoints_EquipID.Name = "LblGetEquipmentPoints_EquipID";
            this.LblGetEquipmentPoints_EquipID.Size = new System.Drawing.Size(110, 20);
            this.LblGetEquipmentPoints_EquipID.TabIndex = 0;
            this.LblGetEquipmentPoints_EquipID.Text = "Equipment ID (GUID):";
            this.LblGetEquipmentPoints_EquipID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetEquipmentPoints_EquipID
            // 
            this.TxtGetEquipmentPoints_EquipID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetEquipmentPoints_EquipID.Location = new System.Drawing.Point(139, 23);
            this.TxtGetEquipmentPoints_EquipID.Name = "TxtGetEquipmentPoints_EquipID";
            this.TxtGetEquipmentPoints_EquipID.Size = new System.Drawing.Size(816, 20);
            this.TxtGetEquipmentPoints_EquipID.TabIndex = 1;
            // 
            // BtnGetEuipmentPoints
            // 
            this.BtnGetEuipmentPoints.Location = new System.Drawing.Point(139, 75);
            this.BtnGetEuipmentPoints.Name = "BtnGetEuipmentPoints";
            this.BtnGetEuipmentPoints.Size = new System.Drawing.Size(130, 23);
            this.BtnGetEuipmentPoints.TabIndex = 2;
            this.BtnGetEuipmentPoints.Text = "GetEquipmentPoints";
            this.BtnGetEuipmentPoints.UseVisualStyleBackColor = true;
            this.BtnGetEuipmentPoints.Click += new System.EventHandler(this.BtnGetEuipmentPoints_Click);
            // 
            // DgvGetEquipmentPoints
            // 
            this.DgvGetEquipmentPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGetEquipmentPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvGetEquipmentPoints.Location = new System.Drawing.Point(139, 104);
            this.DgvGetEquipmentPoints.Name = "DgvGetEquipmentPoints";
            this.DgvGetEquipmentPoints.Size = new System.Drawing.Size(816, 392);
            this.DgvGetEquipmentPoints.TabIndex = 3;
            // 
            // LblReadAttributeValue
            // 
            this.LblReadAttributeValue.AutoSize = true;
            this.LblReadAttributeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblReadAttributeValue.Location = new System.Drawing.Point(23, 49);
            this.LblReadAttributeValue.Margin = new System.Windows.Forms.Padding(3);
            this.LblReadAttributeValue.Name = "LblReadAttributeValue";
            this.LblReadAttributeValue.Size = new System.Drawing.Size(110, 20);
            this.LblReadAttributeValue.TabIndex = 4;
            this.LblReadAttributeValue.Text = "Read Attribute Value";
            this.LblReadAttributeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChkReadAttributeValue
            // 
            this.ChkReadAttributeValue.AutoSize = true;
            this.ChkReadAttributeValue.Location = new System.Drawing.Point(139, 49);
            this.ChkReadAttributeValue.MinimumSize = new System.Drawing.Size(0, 20);
            this.ChkReadAttributeValue.Name = "ChkReadAttributeValue";
            this.ChkReadAttributeValue.Size = new System.Drawing.Size(15, 20);
            this.ChkReadAttributeValue.TabIndex = 5;
            this.ChkReadAttributeValue.UseVisualStyleBackColor = true;
            // 
            // TpgGetSingleEquipment
            // 
            this.TpgGetSingleEquipment.Controls.Add(this.TlpGetSingleEquipment);
            this.TpgGetSingleEquipment.Location = new System.Drawing.Point(4, 29);
            this.TpgGetSingleEquipment.Name = "TpgGetSingleEquipment";
            this.TpgGetSingleEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgGetSingleEquipment.Size = new System.Drawing.Size(984, 525);
            this.TpgGetSingleEquipment.TabIndex = 2;
            this.TpgGetSingleEquipment.Text = "GetSingleEquipment";
            this.TpgGetSingleEquipment.UseVisualStyleBackColor = true;
            // 
            // TlpGetSingleEquipment
            // 
            this.TlpGetSingleEquipment.ColumnCount = 4;
            this.TlpGetSingleEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSingleEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpGetSingleEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSingleEquipment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSingleEquipment.Controls.Add(this.LblGetSingleEquipment_EquipmentId, 1, 1);
            this.TlpGetSingleEquipment.Controls.Add(this.TxtGetSingleEquipment_EquipmentId, 2, 1);
            this.TlpGetSingleEquipment.Controls.Add(this.BtnGetSingleEquipemnt, 2, 2);
            this.TlpGetSingleEquipment.Controls.Add(this.PrgGetSingleEquipment, 2, 3);
            this.TlpGetSingleEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpGetSingleEquipment.Location = new System.Drawing.Point(3, 3);
            this.TlpGetSingleEquipment.Name = "TlpGetSingleEquipment";
            this.TlpGetSingleEquipment.RowCount = 5;
            this.TlpGetSingleEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSingleEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSingleEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpGetSingleEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpGetSingleEquipment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpGetSingleEquipment.Size = new System.Drawing.Size(978, 519);
            this.TlpGetSingleEquipment.TabIndex = 0;
            // 
            // LblGetSingleEquipment_EquipmentId
            // 
            this.LblGetSingleEquipment_EquipmentId.AutoSize = true;
            this.LblGetSingleEquipment_EquipmentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblGetSingleEquipment_EquipmentId.Location = new System.Drawing.Point(23, 23);
            this.LblGetSingleEquipment_EquipmentId.Margin = new System.Windows.Forms.Padding(3);
            this.LblGetSingleEquipment_EquipmentId.MinimumSize = new System.Drawing.Size(100, 0);
            this.LblGetSingleEquipment_EquipmentId.Name = "LblGetSingleEquipment_EquipmentId";
            this.LblGetSingleEquipment_EquipmentId.Size = new System.Drawing.Size(110, 20);
            this.LblGetSingleEquipment_EquipmentId.TabIndex = 0;
            this.LblGetSingleEquipment_EquipmentId.Text = "Equipment ID (GUID):";
            this.LblGetSingleEquipment_EquipmentId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtGetSingleEquipment_EquipmentId
            // 
            this.TxtGetSingleEquipment_EquipmentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGetSingleEquipment_EquipmentId.Location = new System.Drawing.Point(139, 23);
            this.TxtGetSingleEquipment_EquipmentId.Name = "TxtGetSingleEquipment_EquipmentId";
            this.TxtGetSingleEquipment_EquipmentId.Size = new System.Drawing.Size(816, 20);
            this.TxtGetSingleEquipment_EquipmentId.TabIndex = 1;
            // 
            // BtnGetSingleEquipemnt
            // 
            this.BtnGetSingleEquipemnt.Location = new System.Drawing.Point(139, 49);
            this.BtnGetSingleEquipemnt.MinimumSize = new System.Drawing.Size(260, 0);
            this.BtnGetSingleEquipemnt.Name = "BtnGetSingleEquipemnt";
            this.BtnGetSingleEquipemnt.Size = new System.Drawing.Size(260, 23);
            this.BtnGetSingleEquipemnt.TabIndex = 2;
            this.BtnGetSingleEquipemnt.Text = "GetSingleEquipment";
            this.BtnGetSingleEquipemnt.UseVisualStyleBackColor = true;
            this.BtnGetSingleEquipemnt.Click += new System.EventHandler(this.BtnGetSingleEquipemnt_Click);
            // 
            // PrgGetSingleEquipment
            // 
            this.PrgGetSingleEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrgGetSingleEquipment.HelpVisible = false;
            this.PrgGetSingleEquipment.Location = new System.Drawing.Point(139, 78);
            this.PrgGetSingleEquipment.Name = "PrgGetSingleEquipment";
            this.PrgGetSingleEquipment.Size = new System.Drawing.Size(816, 418);
            this.PrgGetSingleEquipment.TabIndex = 3;
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
            this.TpgGetSingleEquipment.ResumeLayout(false);
            this.TlpGetSingleEquipment.ResumeLayout(false);
            this.TlpGetSingleEquipment.PerformLayout();
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
        private System.Windows.Forms.TabPage TpgGetSingleEquipment;
        private System.Windows.Forms.TableLayoutPanel TlpGetSingleEquipment;
        private System.Windows.Forms.Label LblGetSingleEquipment_EquipmentId;
        private System.Windows.Forms.TextBox TxtGetSingleEquipment_EquipmentId;
        private System.Windows.Forms.Button BtnGetSingleEquipemnt;
        private System.Windows.Forms.PropertyGrid PrgGetSingleEquipment;
    }
}