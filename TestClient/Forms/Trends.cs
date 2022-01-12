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
            List<MetasysAttribute> result;
            Guid objectId = new Guid(TxtGetTrendedAttributes_ObjectID.Text);
            result = _client.Trends.GetTrendedAttributes(objectId);
            DgvGetTrendedAttributes.DataSource = result;
        }

        private void BtnGetSamples_Click(object sender, EventArgs e)
        {
            PagedResult<Sample> result;
            Guid objectId = new Guid(TxtGetSamples_ObjectID.Text);
            int attributeId = (int)NudGetSamples_AttributeID.Value;
            TimeFilter filter = new TimeFilter {StartTime = DtpGetSamples_StartTime.Value, EndTime = DtpGetSamples_EndTime.Value};
            result = _client.Trends.GetSamples(objectId, attributeId,filter);
            DgvGetSamples.DataSource = null;
            if (result != null)
            {
                if (result.PageCount > 0)
                {
                    DgvGetSamples.DataSource = result.Items;
                }
            }

        }
    }
}
