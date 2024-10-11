namespace MetasysServices_TestClient
{
    partial class MainUI
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
            this.components = new System.ComponentModel.Container();
            this.rcbToken = new System.Windows.Forms.RichTextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblHostExample = new System.Windows.Forms.Label();
            this.lblUsernameExample = new System.Windows.Forms.Label();
            this.lblPasswordExample = new System.Windows.Forms.Label();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblVersionExample = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.TpgLogin = new System.Windows.Forms.TabPage();
            this.LblTimeoutExample = new System.Windows.Forms.Label();
            this.LblTimeout = new System.Windows.Forms.Label();
            this.TxtTimeout = new System.Windows.Forms.TextBox();
            this.LblLogin_Title1 = new System.Windows.Forms.Label();
            this.BtnGetAccessToken = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.TpgActivity = new System.Windows.Forms.TabPage();
            this.TpgAlarm = new System.Windows.Forms.TabPage();
            this.TpgAudit = new System.Windows.Forms.TabPage();
            this.TpgEnumeration = new System.Windows.Forms.TabPage();
            this.TpgEquipment = new System.Windows.Forms.TabPage();
            this.TpgNetworkDevice = new System.Windows.Forms.TabPage();
            this.TpgObject = new System.Windows.Forms.TabPage();
            this.TpgSpace = new System.Windows.Forms.TabPage();
            this.TpgTrend = new System.Windows.Forms.TabPage();
            this.TpgStream = new System.Windows.Forms.TabPage();
            this.TpgMiscellanea = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TabMain.SuspendLayout();
            this.TpgLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // rcbToken
            // 
            this.rcbToken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rcbToken.Location = new System.Drawing.Point(100, 218);
            this.rcbToken.Name = "rcbToken";
            this.rcbToken.ReadOnly = true;
            this.rcbToken.Size = new System.Drawing.Size(972, 222);
            this.rcbToken.TabIndex = 15;
            this.rcbToken.Text = "";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(102, 189);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "TryLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(38, 104);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(102, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(38, 75);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 13);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "User name:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 72);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(102, 43);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 9;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(13, 46);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(86, 13);
            this.lblHost.TabIndex = 8;
            this.lblHost.Text = "Host name or IP:";
            // 
            // lblHostExample
            // 
            this.lblHostExample.AutoSize = true;
            this.lblHostExample.Location = new System.Drawing.Point(208, 46);
            this.lblHostExample.Name = "lblHostExample";
            this.lblHostExample.Size = new System.Drawing.Size(162, 13);
            this.lblHostExample.TabIndex = 16;
            this.lblHostExample.Text = "Example: ADX-01 or 10.121.34.5";
            // 
            // lblUsernameExample
            // 
            this.lblUsernameExample.AutoSize = true;
            this.lblUsernameExample.Location = new System.Drawing.Point(208, 75);
            this.lblUsernameExample.Name = "lblUsernameExample";
            this.lblUsernameExample.Size = new System.Drawing.Size(133, 13);
            this.lblUsernameExample.TabIndex = 17;
            this.lblUsernameExample.Text = "Example: metasyssysagent";
            // 
            // lblPasswordExample
            // 
            this.lblPasswordExample.AutoSize = true;
            this.lblPasswordExample.Location = new System.Drawing.Point(208, 104);
            this.lblPasswordExample.Name = "lblPasswordExample";
            this.lblPasswordExample.Size = new System.Drawing.Size(184, 13);
            this.lblPasswordExample.TabIndex = 18;
            this.lblPasswordExample.Text = "Example: ChangeThi$Pa$$w0rdN0w!";
            // 
            // cmbVersion
            // 
            this.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Items.AddRange(new object[] {
            "v5",
            "v4",
            "v3",
            "v2"});
            this.cmbVersion.Location = new System.Drawing.Point(102, 127);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(100, 21);
            this.cmbVersion.TabIndex = 23;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(49, 130);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersionExample
            // 
            this.lblVersionExample.AutoSize = true;
            this.lblVersionExample.Location = new System.Drawing.Point(208, 130);
            this.lblVersionExample.Name = "lblVersionExample";
            this.lblVersionExample.Size = new System.Drawing.Size(65, 13);
            this.lblVersionExample.TabIndex = 25;
            this.lblVersionExample.Text = "Example: v5";
            // 
            // lblToken
            // 
            this.lblToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(53, 218);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(41, 13);
            this.lblToken.TabIndex = 26;
            this.lblToken.Text = "Token:";
            this.lblToken.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TabMain
            // 
            this.TabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabMain.Controls.Add(this.TpgLogin);
            this.TabMain.Controls.Add(this.TpgActivity);
            this.TabMain.Controls.Add(this.TpgAlarm);
            this.TabMain.Controls.Add(this.TpgAudit);
            this.TabMain.Controls.Add(this.TpgEnumeration);
            this.TabMain.Controls.Add(this.TpgEquipment);
            this.TabMain.Controls.Add(this.TpgNetworkDevice);
            this.TabMain.Controls.Add(this.TpgObject);
            this.TabMain.Controls.Add(this.TpgSpace);
            this.TabMain.Controls.Add(this.TpgTrend);
            this.TabMain.Controls.Add(this.TpgStream);
            this.TabMain.Controls.Add(this.TpgMiscellanea);
            this.TabMain.ItemSize = new System.Drawing.Size(43, 30);
            this.TabMain.Location = new System.Drawing.Point(12, 12);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(1088, 488);
            this.TabMain.TabIndex = 28;
            this.TabMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabMain_Selecting);
            // 
            // TpgLogin
            // 
            this.TpgLogin.BackColor = System.Drawing.SystemColors.Control;
            this.TpgLogin.Controls.Add(this.LblTimeoutExample);
            this.TpgLogin.Controls.Add(this.LblTimeout);
            this.TpgLogin.Controls.Add(this.TxtTimeout);
            this.TpgLogin.Controls.Add(this.LblLogin_Title1);
            this.TpgLogin.Controls.Add(this.BtnGetAccessToken);
            this.TpgLogin.Controls.Add(this.BtnRefresh);
            this.TpgLogin.Controls.Add(this.txtHost);
            this.TpgLogin.Controls.Add(this.lblToken);
            this.TpgLogin.Controls.Add(this.lblHost);
            this.TpgLogin.Controls.Add(this.rcbToken);
            this.TpgLogin.Controls.Add(this.lblVersionExample);
            this.TpgLogin.Controls.Add(this.txtUsername);
            this.TpgLogin.Controls.Add(this.lblVersion);
            this.TpgLogin.Controls.Add(this.lblUsername);
            this.TpgLogin.Controls.Add(this.cmbVersion);
            this.TpgLogin.Controls.Add(this.txtPassword);
            this.TpgLogin.Controls.Add(this.lblPasswordExample);
            this.TpgLogin.Controls.Add(this.lblPassword);
            this.TpgLogin.Controls.Add(this.lblUsernameExample);
            this.TpgLogin.Controls.Add(this.btnLogin);
            this.TpgLogin.Controls.Add(this.lblHostExample);
            this.TpgLogin.Location = new System.Drawing.Point(4, 34);
            this.TpgLogin.Name = "TpgLogin";
            this.TpgLogin.Padding = new System.Windows.Forms.Padding(3);
            this.TpgLogin.Size = new System.Drawing.Size(1080, 450);
            this.TpgLogin.TabIndex = 4;
            this.TpgLogin.Text = "AUTHENTICATION";
            // 
            // LblTimeoutExample
            // 
            this.LblTimeoutExample.AutoSize = true;
            this.LblTimeoutExample.Location = new System.Drawing.Point(208, 157);
            this.LblTimeoutExample.Name = "LblTimeoutExample";
            this.LblTimeoutExample.Size = new System.Drawing.Size(209, 13);
            this.LblTimeoutExample.TabIndex = 32;
            this.LblTimeoutExample.Text = "Example: 100 (optional, default is 300 sec.)";
            // 
            // LblTimeout
            // 
            this.LblTimeout.AutoSize = true;
            this.LblTimeout.Location = new System.Drawing.Point(3, 157);
            this.LblTimeout.Name = "LblTimeout";
            this.LblTimeout.Size = new System.Drawing.Size(91, 13);
            this.LblTimeout.TabIndex = 31;
            this.LblTimeout.Text = "Request Timeout:";
            this.LblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtTimeout
            // 
            this.TxtTimeout.Location = new System.Drawing.Point(103, 154);
            this.TxtTimeout.Name = "TxtTimeout";
            this.TxtTimeout.Size = new System.Drawing.Size(98, 20);
            this.TxtTimeout.TabIndex = 30;
            // 
            // LblLogin_Title1
            // 
            this.LblLogin_Title1.AutoSize = true;
            this.LblLogin_Title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLogin_Title1.Location = new System.Drawing.Point(7, 7);
            this.LblLogin_Title1.Name = "LblLogin_Title1";
            this.LblLogin_Title1.Size = new System.Drawing.Size(331, 16);
            this.LblLogin_Title1.TabIndex = 29;
            this.LblLogin_Title1.Text = "Functions: TryLogin, Refresh, GetAccessToken";
            // 
            // BtnGetAccessToken
            // 
            this.BtnGetAccessToken.Location = new System.Drawing.Point(326, 189);
            this.BtnGetAccessToken.Name = "BtnGetAccessToken";
            this.BtnGetAccessToken.Size = new System.Drawing.Size(114, 23);
            this.BtnGetAccessToken.TabIndex = 28;
            this.BtnGetAccessToken.Text = "GetAccessToken";
            this.BtnGetAccessToken.UseVisualStyleBackColor = true;
            this.BtnGetAccessToken.Click += new System.EventHandler(this.BtnGetAccessToken_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(210, 189);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(99, 23);
            this.BtnRefresh.TabIndex = 27;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // TpgActivity
            // 
            this.TpgActivity.BackColor = System.Drawing.SystemColors.Control;
            this.TpgActivity.Location = new System.Drawing.Point(4, 34);
            this.TpgActivity.Name = "TpgActivity";
            this.TpgActivity.Padding = new System.Windows.Forms.Padding(3);
            this.TpgActivity.Size = new System.Drawing.Size(1080, 450);
            this.TpgActivity.TabIndex = 12;
            this.TpgActivity.Text = "ACTIVITIES";
            // 
            // TpgAlarm
            // 
            this.TpgAlarm.BackColor = System.Drawing.SystemColors.Control;
            this.TpgAlarm.Location = new System.Drawing.Point(4, 34);
            this.TpgAlarm.Name = "TpgAlarm";
            this.TpgAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.TpgAlarm.Size = new System.Drawing.Size(1080, 450);
            this.TpgAlarm.TabIndex = 0;
            this.TpgAlarm.Text = "ALARMS";
            // 
            // TpgAudit
            // 
            this.TpgAudit.BackColor = System.Drawing.SystemColors.Control;
            this.TpgAudit.Location = new System.Drawing.Point(4, 34);
            this.TpgAudit.Name = "TpgAudit";
            this.TpgAudit.Padding = new System.Windows.Forms.Padding(3);
            this.TpgAudit.Size = new System.Drawing.Size(1080, 450);
            this.TpgAudit.TabIndex = 3;
            this.TpgAudit.Text = "AUDITS";
            // 
            // TpgEnumeration
            // 
            this.TpgEnumeration.BackColor = System.Drawing.SystemColors.Control;
            this.TpgEnumeration.Location = new System.Drawing.Point(4, 34);
            this.TpgEnumeration.Name = "TpgEnumeration";
            this.TpgEnumeration.Padding = new System.Windows.Forms.Padding(3);
            this.TpgEnumeration.Size = new System.Drawing.Size(1080, 450);
            this.TpgEnumeration.TabIndex = 7;
            this.TpgEnumeration.Text = "ENUMERATIONS";
            // 
            // TpgEquipment
            // 
            this.TpgEquipment.BackColor = System.Drawing.SystemColors.Control;
            this.TpgEquipment.Location = new System.Drawing.Point(4, 34);
            this.TpgEquipment.Name = "TpgEquipment";
            this.TpgEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.TpgEquipment.Size = new System.Drawing.Size(1080, 450);
            this.TpgEquipment.TabIndex = 8;
            this.TpgEquipment.Text = "EQUIPMENTS";
            // 
            // TpgNetworkDevice
            // 
            this.TpgNetworkDevice.BackColor = System.Drawing.SystemColors.Control;
            this.TpgNetworkDevice.Location = new System.Drawing.Point(4, 34);
            this.TpgNetworkDevice.Name = "TpgNetworkDevice";
            this.TpgNetworkDevice.Padding = new System.Windows.Forms.Padding(3);
            this.TpgNetworkDevice.Size = new System.Drawing.Size(1080, 450);
            this.TpgNetworkDevice.TabIndex = 9;
            this.TpgNetworkDevice.Text = "NETWORK DEVICES";
            // 
            // TpgObject
            // 
            this.TpgObject.BackColor = System.Drawing.SystemColors.Control;
            this.TpgObject.Location = new System.Drawing.Point(4, 34);
            this.TpgObject.Name = "TpgObject";
            this.TpgObject.Padding = new System.Windows.Forms.Padding(3);
            this.TpgObject.Size = new System.Drawing.Size(1080, 450);
            this.TpgObject.TabIndex = 5;
            this.TpgObject.Text = "OBJECTS";
            // 
            // TpgSpace
            // 
            this.TpgSpace.BackColor = System.Drawing.SystemColors.Control;
            this.TpgSpace.Location = new System.Drawing.Point(4, 34);
            this.TpgSpace.Name = "TpgSpace";
            this.TpgSpace.Padding = new System.Windows.Forms.Padding(3);
            this.TpgSpace.Size = new System.Drawing.Size(1080, 450);
            this.TpgSpace.TabIndex = 10;
            this.TpgSpace.Text = "SPACES";
            // 
            // TpgTrend
            // 
            this.TpgTrend.BackColor = System.Drawing.SystemColors.Control;
            this.TpgTrend.Location = new System.Drawing.Point(4, 34);
            this.TpgTrend.Name = "TpgTrend";
            this.TpgTrend.Padding = new System.Windows.Forms.Padding(3);
            this.TpgTrend.Size = new System.Drawing.Size(1080, 450);
            this.TpgTrend.TabIndex = 1;
            this.TpgTrend.Text = "TRENDS (SAMPLES)";
            // 
            // TpgStream
            // 
            this.TpgStream.BackColor = System.Drawing.SystemColors.Control;
            this.TpgStream.Location = new System.Drawing.Point(4, 34);
            this.TpgStream.Name = "TpgStream";
            this.TpgStream.Padding = new System.Windows.Forms.Padding(3);
            this.TpgStream.Size = new System.Drawing.Size(1080, 450);
            this.TpgStream.TabIndex = 11;
            this.TpgStream.Text = "STREAMS";
            // 
            // TpgMiscellanea
            // 
            this.TpgMiscellanea.BackColor = System.Drawing.SystemColors.Control;
            this.TpgMiscellanea.Location = new System.Drawing.Point(4, 34);
            this.TpgMiscellanea.Name = "TpgMiscellanea";
            this.TpgMiscellanea.Padding = new System.Windows.Forms.Padding(3);
            this.TpgMiscellanea.Size = new System.Drawing.Size(1080, 450);
            this.TpgMiscellanea.TabIndex = 6;
            this.TpgMiscellanea.Text = "MISCELLANEA";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 512);
            this.Controls.Add(this.TabMain);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metasys Services: Test Client";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.TabMain.ResumeLayout(false);
            this.TpgLogin.ResumeLayout(false);
            this.TpgLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rcbToken;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblHostExample;
        private System.Windows.Forms.Label lblUsernameExample;
        private System.Windows.Forms.Label lblPasswordExample;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVersionExample;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TpgAlarm;
        private System.Windows.Forms.TabPage TpgTrend;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage TpgAudit;
        private System.Windows.Forms.TabPage TpgLogin;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnGetAccessToken;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TabPage TpgObject;
        private System.Windows.Forms.TabPage TpgMiscellanea;
        private System.Windows.Forms.TabPage TpgEnumeration;
        private System.Windows.Forms.TabPage TpgEquipment;
        private System.Windows.Forms.TabPage TpgNetworkDevice;
        private System.Windows.Forms.TabPage TpgSpace;
        private System.Windows.Forms.Label LblLogin_Title1;
        private System.Windows.Forms.TabPage TpgStream;
        private System.Windows.Forms.TabPage TpgActivity;
        private System.Windows.Forms.Label LblTimeoutExample;
        private System.Windows.Forms.Label LblTimeout;
        private System.Windows.Forms.TextBox TxtTimeout;
    }
}

