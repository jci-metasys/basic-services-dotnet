using JohnsonControls.Metasys.BasicServices;
using System;
using System.Windows.Forms;

namespace MetasysServices_TestClient.Forms
{
    public partial class Trends : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Trends()
        {
            InitializeComponent();
            DtpGetSamples_StartTime.Value = DateTime.Now.AddDays(-2);
            DtpGetSamples_EndTime.Value = DateTime.Now;
        }
        public void InitForm(MetasysClient client, TabPage container)
        {
            _client = client;
            TabMain.Visible = false;
            TabMain.Parent = container;
            TabMain.Dock = DockStyle.Fill;
            TabMain.Visible = true;
        }

        private void BtnGetTrendedAttributes_Click(object sender, EventArgs e)
        {
            DgvGetTrendedAttributes.DataSource = null;
            String objectId = TxtGetTrendedAttributes_ObjectID.Text.Trim();
            if (!String.IsNullOrEmpty(objectId))
            {
                Guid id = new Guid(objectId);
                var result = _client.Trends.GetTrendedAttributes(id);
                DgvGetTrendedAttributes.DataSource = result;
            }
            else
            {
                MessageBox.Show("The parameter 'Object ID' is mandatory!", "Warning");
            }
        }

        private void BtnGetSamples_Click(object sender, EventArgs e)
        {
            String strObjectId = TxtGetSamples_ObjectID.Text.Trim();
            if (!String.IsNullOrEmpty(strObjectId))
            {
                DgvGetSamples.DataSource = null;
                PagedResult<Sample> result;
                Guid objectId = new Guid(strObjectId);
                int attributeId = (int)NudGetSamples_AttributeID.Value;
                TimeFilter filter = new TimeFilter { StartTime = DtpGetSamples_StartTime.Value, EndTime = DtpGetSamples_EndTime.Value };
                result = _client.Trends.GetSamples(objectId, attributeId, filter);
                if (result != null)
                {
                    if (result.PageCount > 0)
                    {
                        DgvGetSamples.DataSource = result.Items;
                    }
                }
            }
            else
            {
                MessageBox.Show("The parameter 'Object ID' is mandatory!", "Warning");
            }
        }

        private void BtnGetNetDevTrendedAttributes_Click(object sender, EventArgs e)
        {
            DgvGetNetDevTrendedAttributes.DataSource = null;
            String networkDeviceId = TxtGetNetDeTrendedAttributes_NetDevID.Text.Trim();
            if (!String.IsNullOrEmpty(networkDeviceId))
            {
                Guid networkDeviceGuid = new Guid(networkDeviceId);
                var result = _client.Trends.GetNetDevTrendedAttributes(networkDeviceGuid);
                DgvGetNetDevTrendedAttributes.DataSource = result;
            }
            else
            {
                MessageBox.Show("The parameter 'Network Device ID' is mandatory!", "Warning");
            }

        }

        private void CmbGetNetDevSamples_AttributeID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnGetNetDevSamples_Click(object sender, EventArgs e)
        {
            DgvGetNetDevSamples.DataSource = null;
            String networkDeviceId = TxtGetNetDevSamples_NetDevID.Text.Trim();
            String attributeId = CmbGetNetDevSamples_AttributeID.Text;
            if (!String.IsNullOrEmpty(networkDeviceId) && int.TryParse(attributeId, out int attributeInt))
            {
                Guid networkdeviceGuid = new Guid(networkDeviceId);
                TimeFilter filter = new TimeFilter { StartTime = DtpGetNetDevSamples_StartTime.Value, EndTime = DtpGetNetDevSamples_EndTime.Value };
                var result = _client.Trends.GetNetDevSamples(networkdeviceGuid, attributeInt, filter);
                if (result != null)
                {
                    if (result.PageCount > 0)
                    {
                        DgvGetNetDevSamples.DataSource = result.Items;
                    }
                }
            }
            else
            {
                MessageBox.Show("The parameter 'Object ID' is mandatory!", "Warning");
            }
        }
    }
}
