using JohnsonControls.Metasys.BasicServices;
using System;
using System.Globalization;
using System.Windows.Forms;


namespace MetasysServices_TestClient.Forms
{
    public partial class Miscellanea : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Miscellanea()
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

        private void BtnGetServerTime_Click(object sender, EventArgs e)
        {
            TxtGetServerTime_Result.Text = "";
            try
            {
                var serverDateTime = _client.GetServerTime();
                if (serverDateTime != null)
                {
                    TxtGetServerTime_Result.Text = serverDateTime.ToString();
                }
                else
                {
                    TxtGetServerTime_Result.Text = "No date from the server";
                }
            }
            catch (MetasysHttpException ex)
            {
                TxtGetServerTime_Result.Text = "Error: " + ex.Message;
            }
        }

        private void BtnLocalize_Click(object sender, EventArgs e)
        {
            TxtLocalize_Result.Text = "";
            String resourceText = TxtLocalize_ResourceText.Text;
            String cultureInfo = CmbLocalize_CultureInfo.Text;
            if (resourceText.Length > 0 && cultureInfo.Length > 0)
            {
                CultureInfo culture = new CultureInfo(cultureInfo);
                var result = _client.Localize(resourceText, culture);
                TxtLocalize_Result.Text = result;
            }
        }
    }
}
