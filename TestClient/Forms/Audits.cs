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

    public partial class Audits : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }
        public Audits()
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
            AuditFilter auditFilter;
            if (!ChkGet_NoFilters.Checked)
            {
                //Build the OrigiApplication' filter
                OriginApplicationsEnum originApplicationFilter = (ChkGet_AlarmEvent.Checked ? OriginApplicationsEnum.AlarmEvent : 0)
                                                                    | (ChkGet_AuditTrails.Checked ? OriginApplicationsEnum.AuditTrails : 0)
                                                                    | (ChkGet_DeviceServices.Checked ? OriginApplicationsEnum.DeviceServices : 0)
                                                                    | (ChkGet_MCE.Checked ? OriginApplicationsEnum.MCE : 0)
                                                                    | (ChkGet_SiteServices.Checked ? OriginApplicationsEnum.SiteServices : 0);

                //Build the ActionTypes' filter
                ActionTypeEnum actionTypesFilter = (ChkGet_Write.Checked ? ActionTypeEnum.Write : 0)
                                                                    | (ChkGet_Command.Checked ? ActionTypeEnum.Command : 0)
                                                                    | (ChkGet_Create.Checked ? ActionTypeEnum.Create : 0)
                                                                    | (ChkGet_Delete.Checked ? ActionTypeEnum.Delete : 0)
                                                                    | (ChkGet_Error.Checked ? ActionTypeEnum.Error : 0)
                                                                    | (ChkGet_Subsystem.Checked ? ActionTypeEnum.Subsystem : 0);

                auditFilter = new AuditFilter
                {
                    StartTime = DtpGet_StartTime.Value,
                    EndTime = DtpGet_EndTime.Value,
                    ExcludeDiscarded = ChkGet_ExcludeDiscarded.Checked,
                    OriginApplications = originApplicationFilter,
                    ActionTypes = actionTypesFilter
                };
            }
            else
            {
                auditFilter = new AuditFilter { };
            };
            //Get the Audits
            PagedResult<Audit> result = _client.Audits.Get(auditFilter);
            if ((result != null) && (result.PageCount > 0))
            {
                DgvGet.DataSource = result.Items;
            }
        }

        private void ChkGet_NoFilters_CheckedChanged(object sender, EventArgs e)
        {
            TlpGet_Filters.Enabled = !ChkGet_NoFilters.Checked;
        }

        private void BtnFindById_Click(object sender, EventArgs e)
        {
            PrgFindById.SelectedObject = null;
            String auditId = TxtFindById_AuditID.Text.Trim();
            if (auditId.Length > 0)
            {
                Guid auditGuid = new Guid(auditId);
                var result = _client.Audits.FindById(auditGuid);
                PrgFindById.SelectedObject = result;
            }
        }

        private void BtnGetForObject_Click(object sender, EventArgs e)
        {
            DgvGetForObject.DataSource = null;
            AuditFilter auditFilter;
            if (!ChkGetForObject_NoFilters.Checked)
            {
                auditFilter = new AuditFilter
                {
                    StartTime = DtpGetForObject_StartTime.Value,
                    EndTime = DtpGetForObject_EndTime.Value,
                    ExcludeDiscarded = ChGetForObject_ExcludeDiscarded.Checked
                };
            }
            else
            {
                auditFilter = new AuditFilter { };
            };

            String objectID = TxtGetForObject_ObjectID.Text;
            if (objectID.Length > 0)
            {
                Guid objectGuid = new Guid(objectID);
                var result = _client.Audits.GetForObject(objectGuid, auditFilter);
                if ((result != null) && (result.PageCount > 0))
                {
                    DgvGetForObject.DataSource = result.Items;
                }
            }
        }

        private void BtnGetAnnotations_Click(object sender, EventArgs e)
        {
            string auditID = TxtGetAnnotations_AuditID.Text;
            if (auditID.Length > 0)
            {
                Guid auditGuid = new Guid(auditID);
                var result = _client.Audits.GetAnnotations(auditGuid);
                if (result.FirstOrDefault() != null)
                {
                    string txt = "";
                    string nl = System.Environment.NewLine;
                    foreach (AuditAnnotation ann in result)
                    {
                        if (txt.Length > 0) { txt += nl; };
                        txt += ann.Text;
                    }
                    TxtGetAnnotations_Result.Text = txt;
                }
                else
                {
                    TxtGetAnnotations_Result.Text = "No Audit Annotations";
                }
            }
        }

        private void BtnAddAnnotation_Click(object sender, EventArgs e)
        {
            TxtAddAnnotation_Result.Text = "";
            string auditId = TxtAddAnnotation_AuditID.Text;
            string annotationText = TxtAddAnnotations_AnnotationText.Text;
            if (auditId.Length > 0 && annotationText.Length > 0)
            {
                Guid auditGuid = new Guid(auditId);
                try
                {
                    _client.Audits.AddAnnotation(auditGuid, annotationText);
                    TxtAddAnnotation_Result.Text = "OK, done.";
                }
                catch (MetasysHttpException ex)
                {
                    TxtAddAnnotation_Result.Text = "Error: " + ex.Message;
                }
            }
        }

        private void BtnAddAnnotationMultiple_Click(object sender, EventArgs e)
        {
            TxtAddAnnotationMultiple_Result.Text = "";
            if (DgvAddAnnotationMultiple_Params.Rows.Count > 0)
            {
                var batchRequests = new List<BatchRequestParam>();
                foreach (DataGridViewRow dr in DgvAddAnnotationMultiple_Params.Rows)
                {
                    String auditID = dr.Cells[DgvAddAnnotationMultiple_AuditID.Name].Value.ToString();
                    String annotationText = dr.Cells[DgvAddAnnotationMultiple_AnnotationText.Name].Value.ToString();

                    if (auditID.Length > 0 && annotationText.Length > 0)
                    {
                        Guid auditGuid = new Guid(auditID);
                        BatchRequestParam batchReq = new BatchRequestParam { ObjectId = auditGuid, Resource = annotationText };
                        batchRequests.Add(batchReq);
                    }
                }

                if (batchRequests.Count > 0)
                {
                    try
                    {
                        _client.Audits.AddAnnotationMultiple(batchRequests);
                        TxtAddAnnotationMultiple_Result.Text = "OK, done.";
                    }
                    catch (MetasysHttpException ex)
                    {
                        TxtAddAnnotationMultiple_Result.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
        private void BtnDiscard_Click(object sender, EventArgs e)
        {
            string auditId = TxtDiscard_AuditID.Text;
            string discardText = TxtDiscard_AnnotationText.Text;

            if (auditId.Length > 0 && discardText.Length > 0)
            {
                Guid auditGuid = new Guid(auditId);
                try
                {
                    _client.Audits.Discard(auditGuid, discardText);
                    TxtDiscard_Result.Text = "OK, done.";
                }
                catch (MetasysHttpException ex)
                {
                    TxtDiscard_Result.Text = "Error: " + ex.Message;
                }
            }

        }

        private void BtnDiscardMultiple_Click(object sender, EventArgs e)
        {
            TxtDiscardMultiple_Result.Text = "";
            if (DgvDiscardMultiple_Params.Rows.Count > 0)
            {
                var batchRequests = new List<BatchRequestParam>();
                foreach (DataGridViewRow dr in DgvDiscardMultiple_Params.Rows)
                {
                    String auditID = dr.Cells[DgvDiscardMultiple_AuditID.Name].Value.ToString();
                    String annotationText = dr.Cells[DgvDiscardMultiple_AnnotationText.Name].Value.ToString();

                    if (auditID.Length > 0 && annotationText.Length > 0)
                    {
                        Guid auditGuid = new Guid(auditID);
                        BatchRequestParam batchReq = new BatchRequestParam { ObjectId = auditGuid, Resource = annotationText };
                        batchRequests.Add(batchReq);
                    }
                }

                if (batchRequests.Count > 0)
                {
                    try
                    {
                        _client.Audits.DiscardMultiple(batchRequests);
                        TxtDiscardMultiple_Result.Text = "OK, done.";
                    }
                    catch (MetasysHttpException ex)
                    {
                        TxtDiscardMultiple_Result.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
    }
}
