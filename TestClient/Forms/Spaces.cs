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
    public partial class Spaces : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Spaces()
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

        public void LoadComboBox()
        {
            if (_client.Version > ApiVersion.v3)
            {
                // In case of API v4 load the combobox using the API that returns the values of an enumerated set
                IEnumerable<MetasysObjectType> result;
                result = _client.Spaces.GetTypes();
                if (result != null)
                {
                    CmbGetSpaces.DataSource = result;
                    CmbGetSpaces.DisplayMember = "DescriptionEnumerationKey";
                    CmbGetSpaces.ValueMember = "DescriptionEnumerationKey";
                }
            }
            else
            {
                // In case of API v2, v3 load the combobox using the values from 'SpaceTypesEnum'
                CmbGetSpaces.DataSource = Enum.GetValues(typeof(SpaceTypeEnum))
                 .Cast<Enum>()
                 .Select(value => new
                 {
                     (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                     value
                 })
                .OrderBy(item => item.value)
                .ToList();
                CmbGetSpaces.DisplayMember = "Description";
                CmbGetSpaces.ValueMember = "value";
            }

            CmbGetSpaces_Sort.SelectedIndex = 0;
        }

        private void BtnGetSpaces_Click(object sender, EventArgs e)
        {
            DgvGetSpaces.DataSource = null;
            LblSpaceNumberOfRows.Text = "";

            IEnumerable<MetasysObject> result;
            if (ChkGetSpaces.Checked)
            {
                result = _client.Spaces.Get();
            }
            else
            {
                int page = (int)NudSpacePage.Value;
                int pageSize = (int)NudSpacePageSize.Value;
                string sort = CmbGetSpaces_Sort.Text;
                if (sort.Length == 0) sort = null;
                if (_client.Version > ApiVersion.v3) 
                {
                    string spaceType = (string)CmbGetSpaces.SelectedValue;
                    result = _client.Spaces.Get(spaceType, page, pageSize, sort);
                }
                else
                {
                    SpaceTypeEnum spaceType = (SpaceTypeEnum)CmbGetSpaces.SelectedValue;
                    result = _client.Spaces.Get(spaceType, page, pageSize, sort);
                }
            }
            DgvGetSpaces.DataSource = result;

            LblSpaceNumberOfRows.Text = DgvGetSpaces.Rows.Count.ToString();
        }

        private void ChkGetSpaces_CheckedChanged(object sender, EventArgs e)
        {
            CmbGetSpaces.Enabled = !ChkGetSpaces.Checked;
        }

        private void BtnGetSpaceChildren_Click(object sender, EventArgs e)
        {
            IEnumerable<MetasysObject> result;
            Guid spaceId = new Guid(TxtGetSpaceChildren_SpaceID.Text);
            result = _client.GetSpaceChildren(spaceId);
            DgvGetSpaceChildren.DataSource = result;
        }

        private void BtnGetSpaceTypes_Click(object sender, EventArgs e)
        {
            IEnumerable<MetasysObjectType> result;
            result = _client.GetSpaceTypes();
            DgvGetSpaceTypes.DataSource = result;
        }

        private void BtnFindById_Click(object sender, EventArgs e)
        {
            PrgFindById.SelectedObject = null;
            String spaceId = TxtFindById_SpaceID.Text;
            if (_client != null && spaceId.Length > 0)
            {
                Guid spaceGuid = new Guid(spaceId);
                // call the method
                var networkDevice = _client.Spaces.FindById(spaceGuid);
                PrgFindById.SelectedObject = networkDevice;
            }
        }

        private void BtnGetServedByNetworkDevice_Click(object sender, EventArgs e)
        {
            DgvGetServedByNetworkDevice.DataSource = null;
            String networkDeviceId = TxtGetServedByNetworkDevice_NetworkDeviceID.Text;
            if (_client != null && networkDeviceId.Length > 0)
            {
                Guid networkDeviceGuid = new Guid(networkDeviceId);
                var result = _client.Spaces.GetServedByNetworkDevice(networkDeviceGuid);
                DgvGetServedByNetworkDevice.DataSource = result;
            }
        }

        private void BtnGetServedByEquipment_Click(object sender, EventArgs e)
        {
            DgvGetServedByEquipment.DataSource = null;
            String uquipmentId = TxtGetServedByEquipment_EquipmentID.Text;
            if (_client != null && uquipmentId.Length > 0)
            {
                Guid equipmentGuid = new Guid(uquipmentId);
                var result = _client.Spaces.GetServedByEquipment(equipmentGuid);
                DgvGetServedByEquipment.DataSource = result;
            }
        }

        private void Spaces_Load(object sender, EventArgs e)
        {

        }
    }
}
