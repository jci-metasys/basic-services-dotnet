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
        private StreamMessage _covValue = null;
        private List<StreamMessage> _covValues;
        private StreamMessage _alarmEvent = null;
        private List<StreamMessage> _alarmEvents;
        private StreamMessage _auditEvent = null;
        private List<StreamMessage> _auditEvents;

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
                        //Add the events handler
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
            _covValues = _client.Streams.GetCOVValues();
            _covValue = _covValues?.FirstOrDefault();

            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValues_RequestID.Text = requestId.ToString();
            dataGridView1.DataSource = _covValues.ToList();
        }

        private void Alarm_Occurred(object sender, EventArgs e)
        {
            _alarmEvents = _client.Streams.GetAlarmEvents();
            _alarmEvent = _alarmEvents?.FirstOrDefault();

            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtAlarmEvents_RequestID.Text = requestId.ToString();
            DgvAlarmEvents.DataSource = null;
            DgvAlarmEvents.DataSource = _alarmEvents.ToList();
        }

        private void Audit_Occurred(object sender, EventArgs e)
        {
            _auditEvents = _client.Streams.GetAuditEvents();
            _auditEvent = _auditEvents?.FirstOrDefault();
            //TmrRefreshAuditEvents.Enabled = true;

            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtAuditEvents_RequestID.Text = requestId.ToString();
            DgvAuditEvents.DataSource = null;
            DgvAuditEvents.DataSource = _auditEvents.ToList();
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
            _covValues = _client.Streams.GetCOVValues();
            _covValue = _covValues?.FirstOrDefault();

            var str = (_covValue is null) ? String.Empty : _covValue.Data;
            MessageBox.Show(str);
            PrgCOVValue.SelectedObject = _covValue;
            RtbCOVValue.Text = str;
            DgvCOVValue.DataSource = null;
            DgvCOVValue.DataSource = _covValues;
        }

        private void TmrRefreshCOVValue_Tick(object sender, EventArgs e)
        {
            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValue_RequestID.Text = requestId.ToString();

            PrgCOVValue.SelectedObject = _covValue;
            RtbCOVValue.Text = (_covValue is null) ? String.Empty : FormatJson(_covValue.Data);

            DgvCOVValue.DataSource = null;
            DgvCOVValue.DataSource = _covValues.ToList();
        }

        private void BtnCOVValues_StartReadingCOVValues_Click(object sender, EventArgs e)
        {
            var ids = new List<Guid>();
            var id1 = new Guid(TxtCOVValues_ObjectID1.Text);
            ids.Add(id1);
            var id2 = new Guid(TxtCOVValues_ObjectID2.Text);
            ids.Add(id2);

            _ = _client.Streams.StartReadingCOVValuesAsync(ids);
        }

        private void TmrRefreshCOVValues_Tick(object sender, EventArgs e)
        {
            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValues_RequestID.Text = requestId.ToString();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _covValues;
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
