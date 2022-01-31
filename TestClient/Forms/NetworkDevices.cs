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
    public partial class NetworkDevices : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public NetworkDevices()
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

        private void BtnGet_Click(object sender, EventArgs e)
        {
            DgvGet.DataSource = null;
            if (_client != null)
            {
                string type = TxtGetTypes_TypeID.Text;
                IEnumerable<MetasysObject> result;
                if (type.Length > 0)
                {
                    result = _client.GetNetworkDevices(type);
                }
                else
                {
                    result = _client.GetNetworkDevices();
                }
                DgvGet.DataSource = result;
            }
        }

        private void BtnGetTypes_Click(object sender, EventArgs e)
        {
            DgvGetTypes.DataSource = null;
            if (_client != null)
            {
                var res = _client.GetNetworkDeviceTypes();
                DgvGetTypes.DataSource = res;
            }

        }

        private void BtnFindById_Click(object sender, EventArgs e)
        {
            PrgFindById.SelectedObject = null;
            String networkDevideId = TxtFindById_NetworkDeviceID.Text;

            if (_client != null && networkDevideId.Length > 0)
            {
                Guid networkDeviceGuid = new Guid(networkDevideId);
                // call the method
                var networkDevice = _client.NetworkDevices.FindById(networkDeviceGuid);
                if (networkDevice != null)
                {
                    PrgFindById.SelectedObject = networkDevice;
                }
            }
        }


    }
}
