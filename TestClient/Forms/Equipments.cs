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
    public partial class Equipments : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }
        public void InitForm(MetasysClient client, TabPage container)
        {
            _client = client;

            TabMain.Visible = false;
            TabMain.Parent = container;
            TabMain.Dock = DockStyle.Fill;
            TabMain.Visible = true;
        }

        public Equipments()
        {
            InitializeComponent();
        }

        private void BtnGetEquipment_Click(object sender, EventArgs e)
        {
            DgvGetEquipment.DataSource = null;
            var result = _client.GetEquipment();
            DgvGetEquipment.DataSource = result;
        }

        private void BtnGetEuipmentPoints_Click(object sender, EventArgs e)
        {
            DgvGetEquipmentPoints.DataSource = null;
            String equipmentId = TxtGetEquipmentPoints_EquipID.Text.Trim();
            bool readAttributeValue = ChkReadAttributeValue.Checked;
            if (equipmentId.Length > 0)
            {
                Guid equipmentGuid = new Guid(equipmentId);
                var result = _client.GetEquipmentPoints(equipmentGuid, readAttributeValue);
                DgvGetEquipmentPoints.DataSource = result;
            }
        }

        private void BtnGetSingleEquipemnt_Click(object sender, EventArgs e)
        {
            PrgGetFindById.SelectedObject = null;
            String equipmentId = TxtFindById_EquipmentId.Text.Trim();
            if (equipmentId.Length > 0)
            {
                Guid equipmentGuid = new Guid(equipmentId);
                var result = _client.Equipments.FindById(equipmentGuid);
                PrgGetFindById.SelectedObject = result;
            }
        }

        private void BtnGetSpaceEquipment_Click(object sender, EventArgs e)
        {
            DgvGetSpaceEquipment.DataSource = null;
            String spaceId = TxtGetSpaceEquipment_SpaceID.Text.Trim();
            if (spaceId.Length > 0)
            {
                Guid spaceGuid = new Guid(spaceId);
                var result = _client.GetSpaceEquipment(spaceGuid);
                DgvGetSpaceEquipment.DataSource = result;
            }
        }

        private void BtnGetHostedByNetworkDevice_Click(object sender, EventArgs e)
        {
            DgvGetHostedByNetworkDevice.DataSource = null;
            String networkDeviceId = TxtGetHostedByNetworkDevice_NetDevID.Text.Trim();
            if (networkDeviceId.Length > 0)
            {
                Guid networkDeviceGuid = new Guid(networkDeviceId);
                var result = _client.Equipments.GetHostedByNetworkDevice(networkDeviceGuid);
                DgvGetHostedByNetworkDevice.DataSource = result;
            }
        }

        private void BtnGetServedByEquipment_Click(object sender, EventArgs e)
        {
            DgvGetServedByEquipment.DataSource = null;
            String equipmentId = TxtGetServedByEquipment_EquipmentID.Text.Trim();
            if (equipmentId.Length > 0)
            {
                Guid equipmentGuid = new Guid(equipmentId);
                var result = _client.Equipments.GetServedByEquipment(equipmentGuid);
                DgvGetServedByEquipment.DataSource = result;
            }
        }

        private void BtnGetServingAnEquipment_Click(object sender, EventArgs e)
        {
            DgvGetServingAnEquipment.DataSource = null;
            String equipmentId = TxtGetServingAnEquipment_EquipmentID.Text.Trim();
            if (equipmentId.Length > 0)
            {
                Guid equipmentGuid = new Guid(equipmentId);
                var result = _client.Equipments.GetServedByEquipment(equipmentGuid);
                DgvGetServingAnEquipment.DataSource = result;
            }
        }
    }
}
