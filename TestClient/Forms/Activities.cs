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
    public partial class Activities : Form
    {
        private string filter_Type;
        private string filter_originApplication;


        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Activities()
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

            CmbGet_ActivityType.SelectedIndex = 0;
            CmbGet_Sort.SelectedIndex = 0;
            CmbGet_IncludeDiscarded.SelectedIndex = 0;
            CmdGet_IncludeAcknowledged.SelectedIndex = 0;
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            DgvGet.DataSource = null;
            ActivityFilter activityFilter;
            if (!ChkGet_NoFilters.Checked)
            { 
                activityFilter = new ActivityFilter();

                activityFilter.ActivityType = CmbGet_ActivityType.Text;
                activityFilter.StartTime = DtpGet_StartTime.Value;
                activityFilter.EndTime = DtpGet_EndTime.Value;

                if (CmbGet_Sort.Text.Length > 0) { activityFilter.Sort = CmbGet_Sort.Text; };
                switch (CmbGet_IncludeDiscarded.SelectedIndex)
                {
                    case 1:
                        activityFilter.IncludeDiscarded = false;
                        break;
                    case 2:
                        activityFilter.IncludeDiscarded = true;
                        break;
                }
                switch (CmdGet_IncludeAcknowledged.SelectedIndex)
                {
                    case 1:
                        activityFilter.IncludeAcknowledged = false;
                        break;
                    case 2:
                        activityFilter.IncludeAcknowledged = true;
                        break;
                }
                // Only in case of 'alarm'
                if (activityFilter.ActivityType == "alarm")
                {
                    activityFilter.IncludeAcknowledgementRequired = ChkGet_IncludeAcknowledmentRequired.Checked;
                    activityFilter.IncludeAcknowledgementNotRequired = ChkGet_IncludeAcknowledgementNotRequired.Checked;
                }
                //if (filter_Type.Length > 0) { activityFilter.Type = filter_Type.Split(','); };
                //if (filter_originApplication.Length > 0) { activityFilter.OriginApplication = filter_originApplication.Split(','); };
            }
            else
            {
                activityFilter = new ActivityFilter { };
            };
            //Get the Audits
            PagedResult<Activity> result = _client.Activities.Get(activityFilter);
            if ((result != null) && (result.PageCount > 0))
            {
                DgvGet.DataSource = result.Items;
                LblGet_ItemCounter.Text = "Items: " + result.Items.Count.ToString();
            } else
                LblGet_ItemCounter.Text = "Items: 0";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            filter_Type = "";
            var frm = new EnumSelectMulti(_client, "alarmValueEnumSet");
            if (frm.ShowDialog() == DialogResult.OK) 
            {
                filter_Type = frm.SelectionResult;
            };
            TxtGet_SelType.Text = filter_Type;
        }

        private void BtnGet_SelOriginApp_Click(object sender, EventArgs e)
        {
            filter_originApplication = "";
            var frm = new EnumSelectMulti(_client, "auditOriginAppEnumSet");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                filter_originApplication = frm.SelectionResult;
            };
            TxtGet_SelOriginApp.Text = filter_originApplication;
        }

        private void BtnActionMultiple_Click(object sender, EventArgs e)
        {
            TxtActionMultiple_Result.Text = "";
            if (DgvActionMultiple_Params.Rows.Count > 0)
            {
                var batchRequests = new List<BatchRequestParam>();
                foreach (DataGridViewRow dr in DgvActionMultiple_Params.Rows)
                {
                    String objectID = dr.Cells[DgvActionMultiple_ObjectId.Name].Value.ToString();
                    string activityType = dr.Cells[DgvActionMultiple_ActivityType.Name].Value.ToString();
                    string activityManagementStatus = dr.Cells[DgvActionMultiple_ActivityManagementStatus.Name].Value.ToString();
                    String resource = dr.Cells[DgvActionMultiple_Resource.Name].Value.ToString();

                    if (objectID.Length > 0 && activityType.Length > 0 && activityManagementStatus.Length > 0)
                    {
                        Guid objectGuid = new Guid(objectID);
                        BatchRequestParam batchReq = new BatchRequestParam { ObjectId = objectGuid, Resource = resource, ActivityType = activityType, ActivityManagementStatus = activityManagementStatus };
                        batchRequests.Add(batchReq);
                    }
                }

                if (batchRequests.Count > 0)
                {
                    try
                    {
                        _client.Activities.ActionMultiple(batchRequests);
                        TxtActionMultiple_Result.Text = "OK, done.";
                    }
                    catch (MetasysHttpException ex)
                    {
                        TxtActionMultiple_Result.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        private void ChkGet_NoFilters_CheckedChanged(object sender, EventArgs e)
        {
            TlpGet_Filters.Enabled = !ChkGet_NoFilters.Checked;
        }
    }
}
