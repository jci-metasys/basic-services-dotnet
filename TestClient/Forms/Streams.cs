using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private List<Point> _points;

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
                        _client.Streams.HeartBeatOccurred += HeartBeat_Occurred;
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
            _covValues = _client.Streams.GetCOVList();
            _covValue = _covValues?.FirstOrDefault();

            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValues_RequestID.Text = requestId.ToString();
            DgvCOVValues.DataSource = _covValues.ToList();
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
        private void HeartBeat_Occurred(object sender, EventArgs e)
        {
            TxtCOVValues_Heartbeat.Text = DateTime.Now.ToString();
        }

        #endregion

        private void BtnCOVValue_StartReadingValue_Click(object sender, EventArgs e)
        {
            var id = new Guid(TxtCOVValue_ObjectID.Text);
            _client.Streams.StartReadingCOVAsync(id);
            TmrRefreshCOVValue.Enabled = true;
        }

        private void BtnCOVValue_StopReadingCOVValue_Click(object sender, EventArgs e)
        {
            var requestid = new Guid(TxtCOVValue_RequestID.Text);
            _client.Streams.StopReadingCOV(requestid);
        }

        private void BtnCOVValue_GetCOVValues_Click(object sender, EventArgs e)
        {
            _covValues = _client.Streams.GetCOVList();
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
            // Prepare the list of Ids
            var ids = new List<Guid>();
            foreach (DataGridViewRow dr in DgvCOVValues_Params.Rows)
            {
                var id = dr.Cells[DgvCOVValues_Params_Id.Name].Value;
                if (id != null && id.ToString().Length > 0)
                {
                    Guid guid = new Guid(id.ToString());
                    ids.Add(guid);
                }
            }
            if (ids.Count > 0 )
            {
                _client.Streams.StartReadingCOVAsync(ids);
                TxtCOVValues_StartTime.Text = DateTime.Now.ToString();
            }
        }

        private void TmrRefreshCOVValues_Tick(object sender, EventArgs e)
        {
            var requestId = _client.Streams.GetRequestIds().FirstOrDefault();
            TxtCOVValues_RequestID.Text = requestId.ToString();

            DgvCOVValues.DataSource = null;
            DgvCOVValues.DataSource = _covValues;
        }

        private void BtnCOVValues_StopReadingCOVValues_Click(object sender, EventArgs e)
        {
            String requestId = TxtCOVValues_RequestID.Text;
            if (requestId.Length > 0)
            {
                Guid id = new Guid(requestId);
                _client.Streams.StopReadingCOV(id);
            }
        }

        private void BtnAlarmEvent_StartCollectingAlarms_Click(object sender, EventArgs e)
        {
            int maxNumber = int.Parse(TxtAlarmEvents_MaxNumber.Text);
            _ = _client.Streams.StartCollectingAlarmsAsync(maxNumber);
        }

        private void TmrRefreshAlarmEvents_Tick(object sender, EventArgs e)
        {
        }

        private void BtnAuditEvent_StartCollectingAudits_Click(object sender, EventArgs e)
        {
            int maxNumber = int.Parse(TxtAuditEvents_MaxNumber.Text);
            _ = _client.Streams.StartCollectingAuditsAsync(maxNumber);
        }
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private void BtnAlarmEvent_StopCollectingAlarms_Click(object sender, EventArgs e)
        {
            String requestId = TxtAlarmEvents_RequestID.Text;
            if (requestId.Length > 0)
            {
                Guid id = new Guid(requestId);
                _client.Streams.StopCollectingAlarms(id);
            }
        }

        private void BtnAuditEvent_StopCollectingAudits_Click(object sender, EventArgs e)
        {
            String requestId = TxtAuditEvents_RequestID.Text;
            if (requestId.Length > 0)
            {
                Guid id = new Guid(requestId);
                _client.Streams.StopCollectingAudits(id);
            }
        }

        private void BtnCOVValues_KeepAlive_Click(object sender, EventArgs e)
        {
            AccessToken accessToken = _client.GetAccessToken();
            try
            {
                _client.Streams.KeepAlive(accessToken);
                MessageBox.Show("OK");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnGetPointsID_Click(object sender, EventArgs e)
        {
            _points = new List<Point>();
            string modbusPath = "EEC-ADX-13:SNE00108D0B84B3/Modbus.";
            string controllerName = "Controller";
            string pointPrefixes = "TT,SP,Window,Light,STS,MOD";
            string[] prefix = pointPrefixes.Split(',');
            string itemReference = "";


            for (int c = 1; c <=16; c++)
            {
                string cnum = c.ToString();
                if (c < 10) cnum = "0" + cnum;

                foreach (string pre in prefix)
                {
                    for (int i = 1; i<=15; i++)
                    {
                        string idx = i.ToString();
                        if (i<10) idx = "0" + idx;

                        itemReference = modbusPath + controllerName + cnum + "." + pre + idx;

                        Guid id = _client.GetObjectIdentifier(itemReference);
                        if (id != null)
                        {
                            _points.Add(new Point(){Name= pre + idx, Id = id, ItemReference = itemReference });
                            Thread.Sleep(100);
                        }
                    }
                }
                Thread.Sleep(200);
            }
            //Assigh the list of points to the datagridview
            DgvTestUtilsPoints.DataSource = _points;


        }

        private void BtnGenerateConfigFile_Click(object sender, EventArgs e)
        {
            if (_points != null)
            {
                Newtonsoft.Json.Linq.JArray arrayOfRequests = new Newtonsoft.Json.Linq.JArray();

                foreach (Point p in _points)
                {
                    Newtonsoft.Json.Linq.JObject pnt = new Newtonsoft.Json.Linq.JObject();
                    pnt.Add(propertyName: "id", value: p.ItemReference);
                    pnt.Add(propertyName: "relativeUrl", value: p.Id.ToString() + "/attributes/presentValue");

                    arrayOfRequests.Add(pnt);
                }

                Newtonsoft.Json.Linq.JObject body = new Newtonsoft.Json.Linq.JObject();
                body.Add(propertyName: "Method", value: "GET");
                body.Add(propertyName: "requests", value: arrayOfRequests);

                Newtonsoft.Json.Linq.JObject subscription = new Newtonsoft.Json.Linq.JObject();
                subscription.Add(propertyName: "RelativeUrl", value: "api/v5/objects/batch");
                subscription.Add(propertyName: "Method", value: "POST");
                subscription.Add(propertyName: "Params", value: null);
                subscription.Add(propertyName: "Body", value: body);

                Newtonsoft.Json.Linq.JArray arrayOfSubscriptions = new Newtonsoft.Json.Linq.JArray();
                arrayOfSubscriptions.Add(subscription);

                Newtonsoft.Json.Linq.JObject configFile = new Newtonsoft.Json.Linq.JObject();
                configFile.Add(propertyName: "Subscriptions", value: arrayOfSubscriptions);

                File.WriteAllText(@"c:\Temp\SubscriptionConfig1440.json", configFile.ToString());
            }
        }
    }
}
