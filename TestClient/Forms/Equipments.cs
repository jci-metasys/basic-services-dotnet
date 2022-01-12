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
            if (_client != null)
            {
                var result = _client.GetEquipment();
                DgvGetEquipment.DataSource = result;
            }
        }

        private void BtnGetEuipmentPoints_Click(object sender, EventArgs e)
        {
            DgvGetEquipmentPoints.DataSource = null;
            if (_client != null)
            {
                Guid equipmentId = new Guid(TxtGetEquipmentPoints_EquipID.Text);
                var result = _client.GetEquipmentPoints(equipmentId,ChkReadAttributeValue.Checked);
                DgvGetEquipmentPoints.DataSource = result;
            }
        }
    }
}
