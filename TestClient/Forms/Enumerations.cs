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
    public partial class Enumerations : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Enumerations()
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
        }

        private void BtnGetEnumerations_Click(object sender, EventArgs e)
        {
            DgvGetSiteEnumerations.DataSource = null;
            if (_client != null)
            {
                var result = _client.GetSiteEnumerations();
                DgvGetSiteEnumerations.DataSource = result;
            }
        }

        private void BtnGetEnumValues_Click(object sender, EventArgs e)
        {
            DgvGetEnumValues.DataSource = null;
            if (_client != null)
            {
                String enumerationKey = TxtGetEnumValues_EnumKey.Text;
                var result = _client.GetEnumValues(enumerationKey);
                DgvGetEnumValues.DataSource = result;
            }
        }
    }
}
