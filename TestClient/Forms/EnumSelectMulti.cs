using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MetasysServices_TestClient.Forms
{
    public partial class EnumSelectMulti : Form
    {
        private string _enumSetName = "";
        private MetasysClient _client;

        public string SelectionResult { get; set; }


        public EnumSelectMulti(MetasysClient client, string enumerationSetName)
        {
            InitializeComponent();
            _enumSetName = enumerationSetName;
            _client = client;
        }

        private void EnumSelectMulti_Load(object sender, EventArgs e)
        {


            LoadList();

        }

        private void LoadList()
        {
            CklEnum.Items.Clear();

            IEnumerable<MetasysEnumValue> itemList = _client.Enumerations.GetValues(_enumSetName);
            if (itemList != null && itemList.Count() > 0)
            {
                foreach (MetasysEnumValue i in itemList)
                {
                    CklEnum.Items.Add(i.Key, false);
                }
            }

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (CklEnum.CheckedItems.Count > 0)
            {
                string tmp = "";
                foreach (var chk in CklEnum.CheckedItems)
                {
                    if (tmp.Length > 0) { tmp += ","; }
                    tmp += chk.ToString();
                }
                SelectionResult = tmp;
            }
        }
    }
}
