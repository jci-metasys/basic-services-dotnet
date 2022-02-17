using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;

namespace MetasysServices_TestClient.Forms
{
    public partial class Streams : Form
    {
        private MetasysClient _client;

        private Guid _requestId = Guid.Empty;
        private StreamMessage _COVValue = null;
        private List<StreamMessage> _COVValues;
        private StreamMessage _AlarmEvent = null;
        private List<StreamMessage> _AlarmEvents;
        private StreamMessage _AuditEvent = null;
        private List<StreamMessage> _AuditEvents;

        public Streams()
        {
            InitializeComponent();


        }

        public MetasysClient Client
        {
            get { return _client; }
            set
            {
                _client = value;
                if (_client != null)
                {
                    if (_client.Version == ApiVersion.v4)
                    {
                        _client.Streams.COVValueChanged += COVValue_Changed;
                        _client.Streams.AlarmOccurred += Alarm_Occurred;
                        _client.Streams.AuditOccurred += Audit_Occurred;
                    }
                }
            }
        }

        public void InitForm(MetasysClient client, TabPage container)
        {
            _client = client;

            TabMain.Visible = false;
            TabMain.Parent = container;
            TabMain.Dock = DockStyle.Fill;
            TabMain.Visible = true;

        }

        #region "Event Handler" 
        private void COVValue_Changed(object sender, EventArgs e)
        {
            _COVValues = _client.Streams.GetCOVValues();
            _COVValue = _COVValues?.FirstOrDefault();

            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValues_RequestID.Text = requestId.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _COVValues;
        }

        private void Alarm_Occurred(object sender, EventArgs e)
        {
            _AlarmEvents = _client.Streams.GetAlarmEvents();
            _AlarmEvent = _AlarmEvents?.FirstOrDefault();

            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtAlarmEvents_RequestID.Text = requestId.ToString();
            DgvAlarmEvents.DataSource = null;
            DgvAlarmEvents.DataSource = _AlarmEvents;
        }

        private void Audit_Occurred(object sender, EventArgs e)
        {
            _AuditEvents = _client.Streams.GetAuditEvents();
            _AuditEvent = _AuditEvents?.FirstOrDefault();
            //TmrRefreshAuditEvents.Enabled = true;

            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtAuditEvents_RequestID.Text = requestId.ToString();
            DgvAuditEvents.DataSource = null;
            DgvAuditEvents.DataSource = _AuditEvents;
        }
        #endregion

        private void BtnCOVValue_StartReadingValue_Click(object sender, EventArgs e)
        {
            var id = new Guid(TxtCOVValue_ObjectID.Text);
            _ = _client.Streams.StartReadingCOVValueAsync(id);
            TmrRefreshCOVValue.Enabled = true;
        }

        private void BtnCOVValue_StopReadingCOVValue_Click(object sender, EventArgs e)
        {
            var requestid = new Guid(TxtCOVValue_RequestID.Text);
            _client.Streams.StopReadingCOVValues(requestid);
        }

        private void BtnCOVValue_GetCOVValues_Click(object sender, EventArgs e)
        {
            _COVValues = _client.Streams.GetCOVValues();
            _COVValue = _COVValues?.FirstOrDefault();

            var str = (_COVValue is null) ? String.Empty : _COVValue.Data;
            MessageBox.Show(str);
            PrgCOVValue.SelectedObject = _COVValue;
            RtbCOVValue.Text = str;
            DgvCOVValue.DataSource = null;
            DgvCOVValue.DataSource = _COVValues;
        }

        private void TmrRefreshCOVValue_Tick(object sender, EventArgs e)
        {
            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValue_RequestID.Text = requestId.ToString();

            PrgCOVValue.SelectedObject = _COVValue;
            RtbCOVValue.Text = (_COVValue is null) ? String.Empty : FormatJson(_COVValue.Data);

            DgvCOVValue.DataSource = null;
            DgvCOVValue.DataSource = _COVValues;
        }

        private void BtnStreamMulti_StartCollCOVStreamValue_Click(object sender, EventArgs e)
        {

        }

        private void BtnCOVValues_StartReadingCOVValues_Click(object sender, EventArgs e)
        {
            var ids = new List<Guid>();
            var id1 = new Guid(TxtCOVValues_ObjectID1.Text);
            ids.Add(id1);
            var id2 = new Guid(TxtCOVValues_ObjectID2.Text);
            ids.Add(id2);

            _ = _client.Streams.StartReadingCOVValuesAsync(ids);
            //TmrRefreshCOVValues.Enabled = true;
        }

        private void TmrRefreshCOVValues_Tick(object sender, EventArgs e)
        {
            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValues_RequestID.Text = requestId.ToString();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _COVValues;
        }

        private void BtnCOVValues_StopReadingCOVValues_Click(object sender, EventArgs e)
        {

        }

        private void BtnAlarmEvent_StartCollectingAlarms_Click(object sender, EventArgs e)
        {
            _ = _client.Streams.StartCollectingAlarmsAsync(3);
        }

        private void TmrRefreshAlarmEvents_Tick(object sender, EventArgs e)
        {
        }

        private void BtnAuditEvent_StartCollectingAudits_Click(object sender, EventArgs e)
        {
            _ = _client.Streams.StartCollectingAuditsAsync(3);
        }
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}
