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
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Alarms()
        {
            InitializeComponent();
            //Load the combobox using the values from 'SpaceTypesEnum'
            CmbEditAlarm_Action.DataSource = Enum.GetValues(typeof(ActivityManagementStatusEnum))
             .Cast<Enum>()
             .Select(value => new {
                 (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                 value
             })
            .OrderBy(item => item.value)
            .ToList();
            CmbEditAlarm_Action.DisplayMember = "Description";
            CmbEditAlarm_Action.ValueMember = "value";

        }
        public void InitForm(MetasysClient client, TabPage container)
        {
            _client = client;

            TabMain.Visible = false;
            TabMain.Parent = container;
            TabMain.Dock = DockStyle.Fill;
            TabMain.Visible = true;
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            DgvGet.DataSource = null;
            bool noFilters = ChkGet_NoFilters.Checked;
            DateTime startTime = DtpGet_StartTime.Value;
            DateTime endTime = DtpGet_EndTime.Value;
            bool excludeAcknowledged = ChkGet_ExcludeAcknowledged.Checked;
            bool excludeDiscarded = ChkGet_ExcludeDiscarded.Checked;

            if (_client != null )
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
                // call the method
                PagedResult<Alarm> result = _client.Alarms.Get(alarmFilter);
                if (result != null)
                {
                    if (result.PageCount > 0)
                    {
                        DgvGet.DataSource = result.Items;
                    }
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
            TxtEditAlarm_Result.Text = String.Empty;
            String alarmId = TxtEditAlarm_AlarmId.Text;
            ActivityManagementStatusEnum action = (ActivityManagementStatusEnum)Enum.Parse(typeof(ActivityManagementStatusEnum), CmbEditAlarm_Action.Text, true); // case insensitive
            String annotationText = TxtEditAlarm_AnnotationText.Text;
            if (alarmId.Length > 0)
            {
                Guid alarmGuid = new Guid(alarmId);
                try
                {
                     _client.Alarms.EditAlarm(alarmGuid, action, annotationText);
                    TxtEditAlarm_Result.Text = "OK, done";
                }
                catch (MetasysHttpException ex)
                {
                    TxtEditAlarm_Result.Text = "Error: " + ex.Message;
                }
            }
        }



    }
}
