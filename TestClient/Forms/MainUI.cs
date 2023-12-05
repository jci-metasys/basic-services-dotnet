using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;
using MetasysServices_TestClient.Forms;

namespace MetasysServices_TestClient
{
    public partial class MainUI : Form
    {
        private MetasysClient _client;

        private Boolean _enableTabs = false;
        private readonly Activities _frmActivities = new Activities();
        private readonly Alarms _frmAlarms = new Alarms();
        private readonly Audits _frmAudits = new Audits();
        private readonly Enumerations _frmEnumerations = new Enumerations();
        private readonly Equipments _frmEquipments = new Equipments();
        private readonly NetworkDevices _frmNetworkDevices = new NetworkDevices();
        private readonly Objects _frmObjects = new Objects();
        private readonly Streams _frmStreams = new Streams();
        private readonly Spaces _frmSpaces = new Spaces();
        private readonly Trends _frmTrends = new Trends();
        private readonly Miscellanea _frmMiscellanea = new Miscellanea();

        public MainUI()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            txtHost.Text = PubConstants.HOST_IP;
            txtUsername.Text = PubConstants.USER_NAME;
            txtPassword.Text = PubConstants.PASSWORD;
            cmbVersion.SelectedIndex = 0;

            ToolTip.SetToolTip(btnLogin, "Use method: 'TryLogin(username, password)'");
            ToolTip.SetToolTip(BtnRefresh, "Use method: 'Refresh()'");
            ToolTip.SetToolTip(BtnGetAccessToken, "Use method: 'GetAccessToken()'");

            _frmActivities.InitForm(_client, TpgActivity);
            _frmAlarms.InitForm(_client, TpgAlarm);
            _frmAudits.InitForm(_client, TpgAudit);
            _frmEnumerations.InitForm(_client, TpgEnumeration);
            _frmEquipments.InitForm(_client, TpgEquipment);
            _frmNetworkDevices.InitForm(_client, TpgNetworkDevice);
            _frmObjects.InitForm(_client, TpgObject);
            _frmStreams.InitForm(_client, TpgStream);
            _frmSpaces.InitForm(_client, TpgSpace);
            _frmTrends.InitForm(_client, TpgTrend);
            _frmMiscellanea.InitForm(_client, TpgMiscellanea);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Define the 'language' to use 
            CultureInfo culture = new CultureInfo("en-US");
            //Create a new 'client' object
            ApiVersion version = (ApiVersion)Enum.Parse(typeof(ApiVersion), cmbVersion.Text);
            int timeout; 
            _ = int.TryParse(TxtTimeout.Text.ToString(), out timeout);
            _client = new MetasysClient(txtHost.Text, true, version, culture,timeout: timeout != 0 ? timeout: 300);
            if (_client != null)
            {
                _frmActivities.Client = _client;
                _frmAlarms.Client = _client;
                _frmAudits.Client = _client;
                _frmEnumerations.Client = _client;
                _frmEquipments.Client = _client;
                _frmNetworkDevices.Client = _client;
                _frmObjects.Client = _client;
                _frmStreams.Client = _client;
                _frmSpaces.Client = _client;
                _frmTrends.Client = _client;
                _frmMiscellanea.Client = _client;

                _frmSpaces.LoadComboBox();
                //_frmNetworkDevices.LoadComboBox();

                //Do the login using the credentials got from the UI
                var token = _client.TryLogin(txtUsername.Text, txtPassword.Text);
                if (token != null)
                {
                    //Show the token
                    rcbToken.Text = token.ToString();
                    //enables the controls to get the Alarms
                    _enableTabs = true;
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                //Do the login using the credentials got from the UI
                var token = _client.Refresh();
                if (token != null)
                {
                    //Show the token
                    rcbToken.Text = token.ToString();
                    //enables the controls to get the Alarms
                }
            }
        }

        private void BtnGetAccessToken_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                var token = _client.GetAccessToken();
                if (token != null)
                {
                    //Show the token
                    rcbToken.Text = token.ToString();
                    //enables the controls to get the Alarms
                }
            }
        }

        private void TabMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_enableTabs)
            {
                e.Cancel = true;
                MessageBox.Show("You must Login before to change 'Tab'!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private static string FormatJson(object obj)
        //{
        //    //dynamic parsedJson = JsonConvert.DeserializeObject(json);
        //    return JsonConvert.SerializeObject(obj, Formatting.Indented);
        //}
    }
}
