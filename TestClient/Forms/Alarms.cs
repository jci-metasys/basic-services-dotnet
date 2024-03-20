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


namespace MetasysServices_TestClient.Forms
{
    public partial class Alarms : Form
    {
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }      
        }
        private MetasysClient _client;


        public Alarms()
        {
            InitializeComponent();
        }
        public void InitForm(MetasysClient client, TabPage container)
        {
            _client = client;
            
            TabMain.Visible = false;
            TabMain.Parent = container;
            TabMain.Dock = DockStyle.Fill;
            TabMain.Visible = true;
            DtpGet_StartTime.Value = DateTime.Now.AddDays(-1);
            DtpGet_EndTime.Value = DateTime.Now;
            if (Client != null)
            {
                // The following params are validy only for v2 or v3
                ChkGet_ExcludeAcknowledged.Visible = (_client.Version == ApiVersion.v2 || _client.Version == ApiVersion.v3);
                ChkGet_ExcludeDiscarded.Visible = (_client.Version == ApiVersion.v2 || _client.Version == ApiVersion.v3);
                // The following params are validy only from v4 on
                LblGet_IncludeDiscarded.Visible = (_client.Version > ApiVersion.v3);
                CmbGet_IncludeDiscarded.Visible = (_client.Version > ApiVersion.v3);
                LblGet_IncludeAcknowledged.Visible = (_client.Version > ApiVersion.v3);
                CmdGet_IncludeAcknowledged.Visible = (_client.Version > ApiVersion.v3);
            }        
                
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            DgvGet.DataSource = null;
            bool noFilters = ChkGet_NoFilters.Checked;

            DateTime startTime = DtpGet_StartTime.Value;
            DateTime endTime = DtpGet_EndTime.Value;

            int page;
            if (!int.TryParse(TxtGet_Page.Text, out page))
                page = -1;

            int pageSize;
            if (!int.TryParse(TxtGet_PageSize.Text, out pageSize))
                pageSize = -1;


            PagedResult<Alarm> result;

            if (_client != null )
            {
                if (_client.Version == ApiVersion.v2 || _client.Version == ApiVersion.v3)
                {
                    AlarmFilter alarmFilter = new AlarmFilter { };
                    if (!noFilters)
                    {
                        alarmFilter.StartTime = startTime;
                        alarmFilter.EndTime = endTime;
                        alarmFilter.ExcludeAcknowledged = ChkGet_ExcludeAcknowledged.Checked;
                        alarmFilter.ExcludeDiscarded = ChkGet_ExcludeDiscarded.Checked;

                        if (page > 0) alarmFilter.Page = page;
                        if (pageSize > 0) alarmFilter.PageSize = pageSize;
                    }
                    // call the method
                    result = _client.Alarms.Get(alarmFilter);
                } else
                {
                    AlarmFilterV4Plus alarmFilterV4Plus = new AlarmFilterV4Plus { }; ;
                    if (!noFilters)
                    {
                        alarmFilterV4Plus.StartTime = startTime;
                        alarmFilterV4Plus.EndTime = endTime;

                        if (CmbGet_IncludeDiscarded.SelectedIndex > 0)
                            alarmFilterV4Plus.IncludeDiscarded = (CmbGet_IncludeDiscarded.SelectedIndex == 2);

                        if (CmdGet_IncludeAcknowledged.SelectedIndex > 0)
                            alarmFilterV4Plus.IncludeDiscarded = (CmdGet_IncludeAcknowledged.SelectedIndex == 2);

                        if (page > 0) alarmFilterV4Plus.Page = page;
                        if (pageSize > 0) alarmFilterV4Plus.PageSize = pageSize;
                    }

                    // call the method
                    result = _client.Alarms.Get(alarmFilterV4Plus);
                }

                if (result != null)
                {
                    if (result.PageCount > 0)
                    {
                        DgvGet.DataSource = result.Items;
                        LblGet_ItemCounter.Text = "Items: " + result.Items.Count.ToString();
                    } else
                        LblGet_ItemCounter.Text = "Items: 0";
                }
            }
        }

        private void BtnFindById_Click(object sender, EventArgs e)
        {
            PrgFindById.SelectedObject = null;
            String alarmId = TxtFindById_AlarmId.Text;

            if (_client != null && alarmId.Length > 0)
            {
                Guid alarmGuid = new Guid(alarmId);
                // call the method
                var alarm = _client.Alarms.FindById(alarmGuid);
                if (alarm != null)
                {
                    PrgFindById.SelectedObject = alarm;
                    //RtbAlarm.Text = FormatJson(alarm);
                }
            }
        }

        private void BtnGetForNetworkDevice_Click(object sender, EventArgs e)
        {
            DgvGetForNetworkDevice.DataSource = null;
            String networkDeviceId = TxtGetForNetworkDevice_DeviceId.Text;
            bool noFilters = ChkGetForNetworkDevice_NoFilters.Checked;
            DateTime startTime = DtpGetForNetworkDevice_StartTime.Value;
            DateTime endTime = DtpGetForNetworkDevice_EndTime.Value;
            bool excludeAcknowledged = ChkGetForNetworkDevice_ExcludeAcknowledged.Checked;
            bool excludeDiscarded = ChkGetForNetworkDevice_ExcludeDiscarded.Checked;

            if (_client != null && networkDeviceId.Length > 0)
            {
                AlarmFilter alarmFilter;
                if (!noFilters)
                {
                    alarmFilter = new AlarmFilter
                    {
                        StartTime = startTime,
                        EndTime = endTime,
                        ExcludeAcknowledged = excludeAcknowledged,
                        ExcludeDiscarded = excludeDiscarded
                    };
                }
                else
                {
                    alarmFilter = new AlarmFilter { };
                };

                Guid networkDeviceGuid = new Guid(networkDeviceId);
                // call the method
                PagedResult<Alarm> alarmPages = _client.Alarms.GetForNetworkDevice(networkDeviceGuid, alarmFilter);
                if (alarmPages != null)
                {
                    if (alarmPages.PageCount > 0)
                    {
                        DgvGetForNetworkDevice.DataSource = alarmPages.Items;
                    }
                }
            }
        }

        private void BtnGetForObject_Click(object sender, EventArgs e)
        {
            DgvGetForObject.DataSource = null;
            String objectId = TxtGetForObject_ObjectId.Text;
            bool noFilters = ChkGetForObject_NoFilters.Checked;
            DateTime startTime = DtpGetForObject_StartTime.Value;
            DateTime endTime = DtpGetForObject_EndTime.Value;
            bool excludeAcknowledged = ChkGetForObject_ExcludeAcknowledged.Checked;
            bool excludeDiscarded = ChkGetForObject_ExcludeDiscarded.Checked;

            if (_client != null && objectId.Length > 0)
            {
                AlarmFilter alarmFilter;
                if (!noFilters)
                {
                    alarmFilter = new AlarmFilter
                    {
                        StartTime = startTime,
                        EndTime = endTime,
                        ExcludeAcknowledged = excludeAcknowledged,
                        ExcludeDiscarded = excludeDiscarded
                    };
                }
                else
                {
                    alarmFilter = new AlarmFilter { };
                };

                Guid objectGuid = new Guid(objectId);
                PagedResult<Alarm> alarmPages = _client.Alarms.GetForObject(objectGuid, alarmFilter);
                if (alarmPages != null)
                {
                    if (alarmPages.PageCount > 0)
                    {
                        //TxtAlarm_GFO_Total.Text = alarmPages.Total.ToString();
                        DgvGetForObject.DataSource = alarmPages.Items;
                    }
                }
            }
        }

        private void BtnGetAnnotations_Click(object sender, EventArgs e)
        {
            TxtGetAnnotations_Result.Text = String.Empty;
            String alarmId = TxtGetAnnotations_AlarmId.Text;

            if (alarmId.Length > 0)
            {
                Guid alarmGuid = new Guid(alarmId);
                // call the method
                var result = _client.Alarms.GetAnnotations(alarmGuid);
                if (result != null && result.Count() > 0)
                {
                    foreach (AlarmAnnotation a in result)
                    {
                        TxtGetAnnotations_Result.Text += a.Text + "\r\n";
                    }
                }
            }
        }

        private void BtnEditAlarm_Click(object sender, EventArgs e)
        {
            TxtAckAlarm_Result.Text = String.Empty;
            String alarmId = TxtAckAlarm_AlarmId.Text;
            String annotationText = TxtAckAlarm_AnnotationText.Text;
            if (alarmId.Length > 0)
            {
                Guid alarmGuid = new Guid(alarmId);
                try
                {
                     _client.Alarms.Acknowledge(alarmGuid,  annotationText);
                    TxtAckAlarm_Result.Text = "OK, done";
                }
                catch (MetasysHttpException ex)
                {
                    TxtAckAlarm_Result.Text = "Error: " + ex.Message;
                }
            }
        }

        private void ChkGet_NoFilters_CheckedChanged(object sender, EventArgs e)
        {
            TlpGet_Filters.Enabled = !ChkGet_NoFilters.Checked;
        }

        private void BtnDiscardAlarm_Click(object sender, EventArgs e)
        {
            TxtDiscardAlarm_Result.Text = String.Empty;
            String alarmId = TxtDiscardAlarm_AlarmId.Text;
            String annotationText = TxtDiscardAlarm_AnnotationText.Text;
            if (alarmId.Length > 0)
            {
                Guid alarmGuid = new Guid(alarmId);
                try
                {
                    _client.Alarms.Discard(alarmGuid, annotationText);
                    TxtDiscardAlarm_Result.Text = "OK, done";
                }
                catch (MetasysHttpException ex)
                {
                    TxtDiscardAlarm_Result.Text = "Error: " + ex.Message;
                }
            }

        }
    }
}
