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
            String objectId = TxtGetTrendedAttributes_ObjectID.Text.Trim();
            if (! String.IsNullOrEmpty(objectId))
            {
                DgvGetTrendedAttributes.DataSource = null;
                List<MetasysAttribute> result;
                Guid id = new Guid(objectId);
                result = _client.Trends.GetTrendedAttributes(id);
                DgvGetTrendedAttributes.DataSource = result;
            } else
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
    }
}
