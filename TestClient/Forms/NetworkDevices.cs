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
            string type = TxtGetTypes_TypeID.Text;
            if (_client != null)
            {
                var result = _client.NetworkDevices.Get((type.Length > 0) ? type : null) ;
                DgvGet.DataSource = result;
            }
        }

        private void BtnGetTypes_Click(object sender, EventArgs e)
        {
            DgvGetTypes.DataSource = null;
            if (_client != null)
            {
                var result = _client.NetworkDevices.GetTypes();
                DgvGetTypes.DataSource = result;
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
                PrgFindById.SelectedObject = networkDevice;
            }
        }

        private void BtnGetChildren_Click(object sender, EventArgs e)
        {
            DgvGetChildren.DataSource = null;
            String networkDevideId = TxtGetChildren_NetworkDeviceID.Text;
            if (_client != null && networkDevideId.Length > 0)
            {
                Guid networkDeviceGuid = new Guid(networkDevideId);
                // call the method
                var result = _client.NetworkDevices.GetChildren(networkDeviceGuid);
                DgvGetChildren.DataSource = result;
            }
        }

        private void BtnGetHostingAnEquipment_Click(object sender, EventArgs e)
        {
            DgvGetHostingAnEquipment.DataSource = null;
            String equipmentId = TxtGetHostingAnEquipment_EquipmentID.Text;
            if (_client != null && equipmentId.Length > 0)
            {
                Guid equipmentGuid = new Guid(equipmentId);
                // call the method
                var result = _client.NetworkDevices.GetHostingAnEquipment(equipmentGuid);
                DgvGetHostingAnEquipment.DataSource = result;
            }
        }

        private void BtnGetServingASpace_Click(object sender, EventArgs e)
        {
            DgvGetServingASpace.DataSource = null;
            String spaceId = TxtGetServingASpace_SpaceID.Text;
            if (_client != null && spaceId.Length > 0)
            {
                Guid spaceGuid = new Guid(spaceId);
                // call the method
                var result = _client.NetworkDevices.GetServingASpace(spaceGuid);
                DgvGetServingASpace.DataSource = result;
            }
        }
    }
}
