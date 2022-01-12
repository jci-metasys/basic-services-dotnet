using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;

namespace MetasysServices_TestClient
{
    public partial class MainUI : Form
    {
        private MetasysClient _client;

        private Boolean _enableTabs = false;
        private Guid _alarmId = Guid.Empty;
        private AlarmAnnotation _firstAnnotation = null;
        private IEnumerable<AlarmAnnotation> _annotations = null;
        private Guid _networkDeviceId = Guid.Empty;
        private Guid _objectId = Guid.Empty;

        private Forms.Equipments _frmEquipments;
        private Forms.Streams _frmStreams;
        private Forms.Spaces _frmSpaces;
        private Forms.Trends _frmTrends;

        #region "Public Method"
        public MainUI()
        {
            InitializeComponent();


        }
        #endregion


        #region "Private Methods"

        // ==========================================================================================================================
        // ALARMS
        private void Alarms_Get(DateTime startTime, DateTime endTime, Boolean excludeAcknowledged, Boolean excludeDiscarded, Boolean noFilters)
        {
            AlarmFilter alarmFilter;
            if (!noFilters)
            {
                alarmFilter = new AlarmFilter
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    ExcludeAcknowledged = excludeAcknowledged,
                    ExcludeDiscarded = excludeDiscarded
                };
            }
            else
            {
                alarmFilter = new AlarmFilter { };
            };
            PagedResult<Alarm> alarmPages = _client.Alarms.Get(alarmFilter);
            if (alarmPages != null)
            {
                if (alarmPages.PageCount > 0)
                {
                    TxtAlarm_Total.Text = alarmPages.Total.ToString();
                    DgvAlarm.DataSource = alarmPages.Items;
                }
            }
        }
        private void Alarms_FindByID(string guid)
        {
            if (_client != null)
            {
                //Define the 'language' to use 
                Guid alarmGuid = new Guid(guid);

                var alarm = _client.Alarms.FindById(alarmGuid);
                if (alarm != null)
                {
                    PrgAlarm_FindByID.SelectedObject = alarm;
                    RtbAlarm.Text = FormatJson(alarm);
                }
            }
        }
        private void Alarms_GetForNetworkDevice(string networkDeviceId,
                                                DateTime startTime,
                                                DateTime endTime,
                                                Boolean excludeAcknowledged,
                                                Boolean excludeDiscarded,
                                                Boolean noFilters)
        {
            AlarmFilter alarmFilter;
            if (!noFilters)
            {
                alarmFilter = new AlarmFilter
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    ExcludeAcknowledged = excludeAcknowledged,
                    ExcludeDiscarded = excludeDiscarded
                };
            }
            else
            {
                alarmFilter = new AlarmFilter { };
            };

            _networkDeviceId = new Guid(networkDeviceId);
            PagedResult<Alarm> alarmPages = _client.Alarms.GetForNetworkDevice(_networkDeviceId, alarmFilter);
            if (alarmPages != null)
            {
                if (alarmPages.PageCount > 0)
                {
                    TxtAlarm_GFND_Total.Text = alarmPages.Total.ToString();
                    DgvAlarm_GFND.DataSource = alarmPages.Items;
                }
            }
        }
        private void Alarms_GetForObject(string objectId,
                                        DateTime startTime,
                                        DateTime endTime,
                                        Boolean excludeAcknowledged,
                                        Boolean excludeDiscarded,
                                        Boolean noFilters)
        {
            AlarmFilter alarmFilter;
            if (!noFilters)
            {
                alarmFilter = new AlarmFilter
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    ExcludeAcknowledged = excludeAcknowledged,
                    ExcludeDiscarded = excludeDiscarded
                };
            }
            else
            {
                alarmFilter = new AlarmFilter { };
            };

            _objectId = new Guid(objectId);
            PagedResult<Alarm> alarmPages = _client.Alarms.GetForObject(_objectId, alarmFilter);
            if (alarmPages != null)
            {
                if (alarmPages.PageCount > 0)
                {
                    TxtAlarm_GFO_Total.Text = alarmPages.Total.ToString();
                    DgvAlarm_GFO.DataSource = alarmPages.Items;
                }
            }
        }
        private void Alarms_GetAnnotations(string guid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                _alarmId = new Guid(guid);
            }

            if (_alarmId != Guid.Empty)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }


        // ==================================================================================================================
        // AUDITS
        private PagedResult<Audit> Audits_Get(DateTime startTime, DateTime endTime, Boolean excludeDiscarded, Boolean noFilters)
        {
            PagedResult<Audit> res;
            AuditFilter auditFilter;
            if (!noFilters)
            {
                auditFilter = new AuditFilter
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    ExcludeDiscarded = excludeDiscarded
                };
            }
            else
            {
                auditFilter = new AuditFilter { };
            };

            res = _client.Audits.Get(auditFilter);
            return res;
        }
        private Audit Audits_FindByID(string guid)
        {
            Audit res = null;
            if (_client != null)
            {
                Guid auditGuid = new Guid(guid);
                res = _client.Audits.FindById(auditGuid);
            }
            return res;
        }
        private PagedResult<Audit> Audits_GetForObject(string objectId,
                                                        DateTime startTime,
                                                        DateTime endTime,
                                                        Boolean excludeDiscarded,
                                                        Boolean noFilters)
        {
            PagedResult<Audit> res;
            AuditFilter auditFilter;
            if (!noFilters)
            {
                auditFilter = new AuditFilter
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    ExcludeDiscarded = excludeDiscarded
                };
            }
            else
            {
                auditFilter = new AuditFilter { };
            };

            _objectId = new Guid(objectId);
            res = _client.Audits.GetForObject(_objectId, auditFilter);
            return res;
        }
        private IEnumerable<AuditAnnotation> Audits_GetAnnotations(string guid)
        {
            IEnumerable<AuditAnnotation> res = null;
            if (_client != null)
            {
                Guid auditGuid = new Guid(guid);
                res = _client.Audits.GetAnnotations(auditGuid);
            }
            return res;
        }

        // =======================================================================================================================
        // MISCELLANEA
        private DateTime GetServerTime()
        {
            DateTime res = new DateTime();
            if (_client != null)
            {
                var serverDateTime = _client.GetServerTime();
                if (serverDateTime != null)
                {
                    res = serverDateTime;
                }
            }
            return res;
        }

        #endregion

        #region "Form Events"
        private void MainUI_Load(object sender, EventArgs e)
        {
            txtHost.Text = PubConstants.HOST_IP;
            txtUsername.Text = PubConstants.USER_NAME;
            txtPassword.Text = PubConstants.PASSWORD;
            cmbVersion.SelectedIndex = 0;

            DtpAlarm_StartTime.Value = DateTime.Now.AddDays(-2);
            DtpAlarm_EndTime.Value = DateTime.Now;
            DtpAudit_StartTime.Value = DateTime.Now.AddDays(-2);
            DtpAudit_EndTime.Value = DateTime.Now;

            ToolTip.SetToolTip(btnLogin, "Use method: 'TryLogin(username, password)'");
            ToolTip.SetToolTip(BtnRefresh, "Use method: 'Refresh()'");
            ToolTip.SetToolTip(BtnGetAccessToken, "Use method: 'GetAccessToken()'");

            _frmEquipments = new Forms.Equipments();
            _frmEquipments.InitForm(_client, TpgEquipment);

            _frmStreams = new Forms.Streams();
            _frmStreams.InitForm(_client, TpgStream);

            _frmSpaces = new Forms.Spaces();
            _frmSpaces.InitForm(_client, TpgSpace);

            _frmTrends = new Forms.Trends();
            _frmTrends.InitForm(_client, TpgTrend);

        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Define the 'language' to use 
            CultureInfo culture = new CultureInfo("en-US");
            //Create a new 'client' object
            ApiVersion version = (ApiVersion)Enum.Parse(typeof(ApiVersion), cmbVersion.Text);
            _client = new MetasysClient(txtHost.Text, true, version, culture);
            if (_client != null)
            {
                _frmEquipments.Client = _client;
                _frmStreams.Client = _client;
                _frmSpaces.Client = _client;
                _frmTrends.Client = _client;

                //Do the login using the credentials got from the UI
                var token = _client.TryLogin(txtUsername.Text, txtPassword.Text);
                if (token != null)
                {
                    //Show the token
                    rcbToken.Text = token.ToString();
                    //enables the controls to get the Alarms
                    GrbGetAlarms.Enabled = true;
                    grbReadProperty.Enabled = true;
                    _enableTabs = true;
                }
            }
        }
        private void BtlAlarm_Get_Click(object sender, EventArgs e)
        {
            DgvAlarm.DataSource = null;
            Alarms_Get(DtpAlarm_StartTime.Value, DtpAlarm_EndTime.Value, chkAlarm_ExcludeAcknowledged.Checked, chkAlarm_ExcludeDiscarded.Checked, ChkAlarm_NoFilter.Checked);
        }
        private void ChkAlarm_NoFilter_CheckedChanged(object sender, EventArgs e)
        {
            GrbAlarm_Filter.Enabled = !ChkAlarm_NoFilter.Checked;
        }


        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _annotations = _client.Alarms.GetAnnotations(_alarmId);
            _firstAnnotation = _annotations.FirstOrDefault();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_firstAnnotation != null)
            {
                string res = "";
                string nl = System.Environment.NewLine;
                foreach (AlarmAnnotation ann in _annotations)
                    {
                    if (res.Length > 0) { res += nl; };
                    res += ann.Text;
                    }
                TxtAlarms_Annotations.Text = res;
            }
            else
            {
                TxtAlarms_Annotations.Text = "No Alarm Annotation";
            }
        }
        #endregion

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                //Do the login using the credentials got from the UI
                var token = _client.Refresh();
                if (token != null)
                {
                    //Show the token
                    rcbToken.Text = token.ToString();
                    //enables the controls to get the Alarms
                    GrbGetAlarms.Enabled = true;
                    grbReadProperty.Enabled = true;
                }
            }
        }

        private void BtnGetAccessToken_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                var token = _client.GetAccessToken();
                if (token != null)
                {
                    //Show the token
                    rcbToken.Text = token.ToString();
                    //enables the controls to get the Alarms
                    GrbGetAlarms.Enabled = true;
                    grbReadProperty.Enabled = true;
                }
            }
        }

        private void BtnGetObjectIdentifier_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                var guid = _client.GetObjectIdentifier(TxtGetObjectIdentifier_FQR.Text);
                if (guid != null)
                {
                    //Show the GUID
                    TxtObjectIdentifier_GUID.Text = guid.ToString();
                }
            }
        }

        private void BtnMisc_GetServerTime_Click(object sender, EventArgs e)
        {
            TxtMisc_ServerTime.Text = GetServerTime().ToString();
        }

        private void BtnEnum_Localize_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                //Define the 'language' to use 
                CultureInfo culture = new CultureInfo(CmbMisc_Localize_CultureInfo.Text);

                var localizedText = _client.Localize(TxtEnum_SourceText.Text, culture);
                if (localizedText != null)
                {
                    TxtEnum_LocalizedText.Text = localizedText;
                }
            }
        }

        private void BtnAlarm_FindByID_Click(object sender, EventArgs e)
        {
            string guid = TxtAlarm_FindByID_GUID.Text;
            Alarms_FindByID(guid);
        }

        private void BtnAlarm_GetForNetworkDevice_Click(object sender, EventArgs e)
        {
            DgvAlarm_GFND.DataSource = null;
            Alarms_GetForNetworkDevice(TxtAlarm_GFND_GUID.Text,
                                        dtpAlarm_GFND_StartTime.Value,
                                        dtpAlarm_GFND_EndTime.Value,
                                        chkAlarm_GFND_ExcludeAcknowledged.Checked, 
                                        chkAlarm_GFND_ExcludeDiscarded.Checked,
                                        chkAlarm_GFND_NoFilter.Checked);

        }

        private void BtnGetAlarmAnnotation_Click(object sender, EventArgs e)
        {
            Alarms_GetAnnotations(TxtAlarmGUID.Text);
        }

        private void BtnAlarm_GetForObject_Click(object sender, EventArgs e)
        {
            DgvAlarm_GFO.DataSource = null;
            Alarms_GetForObject(TxtAlarm_GFO_GUID.Text,
                                DtpAlarm_GFO_StartTime.Value,
                                dtpAlarm_GFO_EndTime.Value,
                                chkAlarm_GFO_ExcludeAcknowledged.Checked,
                                chkAlarm_GFO_ExcludeDiscarded.Checked,
                                chkAlarm_GFO_NoFilter.Checked);
        }

        private void BtlAudit_Get_Click(object sender, EventArgs e)
        {
            DgvAudit.DataSource = null;

            AuditFilter auditFilter;
            if (!ChkAudit_NoFilter.Checked)
            {
                //Build the OrigiApplication' filter
                OriginApplicationsEnum originApplicationFilter = (ChkAudit_AlarmEvent.Checked ? OriginApplicationsEnum.AlarmEvent : 0) 
                                                                    | (ChkAudit_AuditTrails.Checked ? OriginApplicationsEnum.AuditTrails : 0) 
                                                                    | (ChkAudit_DeviceServices.Checked ? OriginApplicationsEnum.DeviceServices : 0) 
                                                                    | (ChkAudit_MCE.Checked ? OriginApplicationsEnum.MCE : 0) 
                                                                    | (ChkAudit_SiteServices.Checked ? OriginApplicationsEnum.SiteServices : 0);

                //Build the ActionTypes' filter
                ActionTypeEnum actionTypesFilter = (ChkAudit_ActionType_Write.Checked ? ActionTypeEnum.Write : 0)
                                                                    | (ChkAudit_ActionType_Command.Checked ? ActionTypeEnum.Command : 0)
                                                                    | (ChkAudit_ActionType_Create.Checked ? ActionTypeEnum.Create : 0)
                                                                    | (ChkAudit_ActionType_Delete.Checked ? ActionTypeEnum.Delete : 0)
                                                                    | (ChkAudit_ActionType_Error.Checked ? ActionTypeEnum.Error : 0)
                                                                    | (ChkAudit_ActionType_Subsystem.Checked ? ActionTypeEnum.Subsystem : 0);

                auditFilter = new AuditFilter
                {
                    StartTime = DtpAudit_StartTime.Value,
                    EndTime = DtpAudit_EndTime.Value,
                    ExcludeDiscarded = ChkAudit_ExcludeDiscarded.Checked,
                    OriginApplications = originApplicationFilter,
                    ActionTypes = actionTypesFilter
                };
            }
            else
            {
                auditFilter = new AuditFilter { };
            };
            //Get the Audits
            PagedResult<Audit> res = _client.Audits.Get(auditFilter);

            if ((res != null) && (res.PageCount > 0)) 
            {
                DgvAudit.DataSource = res.Items;
                TxtAudit_Total.Text = res.Total.ToString();
            }
        }

        private void ChkAudit_NoFilter_CheckedChanged(object sender, EventArgs e)
        {
            GrbAudit_Filter.Enabled = !ChkAudit_NoFilter.Checked;
        }

        private void BtnAudit_FindByID_Click(object sender, EventArgs e)
        {
            string guid = TxtAudit_FindByID_GUID.Text;
            PrgAudit_FindByID.SelectedObject = Audits_FindByID(guid);
        }

        private void BtnAudit_GetForObject_Click(object sender, EventArgs e)
        {
            DgvAudit_GFO.DataSource = null;
            PagedResult<Audit> res = Audits_GetForObject(TxtAudit_GFO_GUID.Text,
                                                         DtpAudit_GFO_StartTime.Value,
                                                         DtpAudit_GFO_EndTime.Value,
                                                         chkAudit_GFO_ExcludeDiscarded.Checked,
                                                         chkAudit_GFO_NoFilter.Checked);
            if ((res != null) && (res.PageCount > 0))
            {
                DgvAudit_GFO.DataSource = res.Items;
                TxtAudit_GFO_Total.Text = res.Total.ToString();
            }

        }

        private void BtnAudit_GetAnnotations_Click(object sender, EventArgs e)
        {
            string guid = TxtAudit_GetAnnotations_GUID.Text;
            IEnumerable<AuditAnnotation>  res = Audits_GetAnnotations(guid);
            if (res.FirstOrDefault() != null)
            {
                string txt = "";
                string nl = System.Environment.NewLine;
                foreach (AuditAnnotation ann in res)
                {
                    if (txt.Length > 0) { txt += nl; };
                    txt += ann.Text;
                }
                TxtAudits_Annotations.Text = txt;
            }
            else
            {
                TxtAudits_Annotations.Text = "No Audit Annotations";
            }

        }

        private void BtnAudit_AddAnnotation_Click(object sender, EventArgs e)
        {
            string auditId = TxtAudit_AddAnnotation_GUID.Text;
            string annotationText = TxtAudit_AddAnnotation_Text.Text;
                
            if (_client != null && auditId.Length >0 && annotationText.Length>0)
            {
                Guid auditGuid = new Guid(auditId);
                _client.Audits.AddAnnotation(auditGuid, annotationText);
            }
        }

        private void BtnAudit_Discard_Click(object sender, EventArgs e)
        {
            string auditId = TxtAudit_Discard_GUID.Text;
            string discardText = TxtAudit_Discard_Text.Text;

            if (_client != null && auditId.Length > 0 && discardText.Length > 0)
            {
                Guid auditGuid = new Guid(auditId);
                _client.Audits.Discard(auditGuid, discardText);
            }
        }

        private void BtnAudit_AddAnnotationMultiple_Click(object sender, EventArgs e)
        {
            string auditId1 = TxtAudit_AddAnnotationMulti_GUID1.Text;
            string annotationText1 = TxtAudit_AddAnnotationMulti_Text1.Text;

            if (_client != null && auditId1.Length > 0 && annotationText1.Length > 0)
            {
                var batchRequests = new List<BatchRequestParam>();
                Guid auditGuid1 = new Guid(auditId1);
                BatchRequestParam batchReq1 = new BatchRequestParam { ObjectId = auditGuid1, Resource = annotationText1 };
                batchRequests.Add(batchReq1);

                string auditId2 = TxtAudit_AddAnnotationMulti_GUID2.Text;
                string annotationText2 = TxtAudit_AddAnnotationMulti_Text2.Text;

                if (auditId2.Length > 0 && annotationText2.Length > 0)
                {
                    Guid auditGuid2 = new Guid(auditId2);
                    BatchRequestParam batchReq2 = new BatchRequestParam { ObjectId = auditGuid2, Resource = annotationText2 };
                    batchRequests.Add(batchReq2);
                }
                _client.Audits.AddAnnotationMultiple(batchRequests);
            }
        }

        private void BtnAudit_DiscardMultiple_Click(object sender, EventArgs e)
        {
            string auditId1 = TxtAudit_DiscardMulti_GUID1.Text;
            string annotationText1 = TxtAudit_DiscardMulti_Text1.Text;

            if (_client != null && auditId1.Length > 0 && annotationText1.Length > 0)
            {
                var batchRequests = new List<BatchRequestParam>();
                Guid auditGuid1 = new Guid(auditId1);
                BatchRequestParam batchReq1 = new BatchRequestParam { ObjectId = auditGuid1, Resource = annotationText1 };
                batchRequests.Add(batchReq1);

                string auditId2 = TxtAudit_DiscardMulti_GUID2.Text;
                string annotationText2 = TxtAudit_DiscardMulti_Text2.Text;

                if (auditId2.Length > 0 && annotationText2.Length > 0)
                {
                    Guid auditGuid2 = new Guid(auditId2);
                    BatchRequestParam batchReq2 = new BatchRequestParam { ObjectId = auditGuid2, Resource = annotationText2 };
                    batchRequests.Add(batchReq2);
                }
                _client.Audits.DiscardMultiple(batchRequests);
            }

        }

        private void BtnGetEquipment_Click(object sender, EventArgs e)
        {
        }

        private void BtnGetNetworkDeviceTypes_Click(object sender, EventArgs e)
        {
            DgvGetNetworkDeviceTypes.DataSource = null;
            if (_client != null)
            {
                var res = _client.GetNetworkDeviceTypes();
                DgvGetNetworkDeviceTypes.DataSource = res;
            }
        }

        private void BtnGetNetworkDevices_Click(object sender, EventArgs e)
        {
            DgvGetNetworkDevices.DataSource = null;
            if (_client != null)
            {
                string type = TxtGetNetworkDevices_Type_ID.Text;
                IEnumerable<MetasysObject> result;
                if (type.Length>0)
                {
                    result = _client.GetNetworkDevices(type);
                } else
                {
                    result = _client.GetNetworkDevices();
                }
                DgvGetNetworkDevices.DataSource = result;
            }
        }

        private void BtnGetCommands_Click(object sender, EventArgs e)
        {
            DgvGetCommands.DataSource = null;
            string guid = TxtObjects_GetCommands_GUID.Text;
            if (_client != null && guid.Length>0)
            {
                Guid id = new Guid(guid);
                List<Command> res = _client.GetCommands(id).ToList();

                DgvGetCommands.Rows.Clear();
                foreach (Command c in res)
                {
                    int i = DgvGetCommands.Rows.Add();
                    DgvGetCommands.Rows[i].Cells["DgvCommand_Title"].Value = c.Title;
                    DgvGetCommands.Rows[i].Cells["DgvCommand_TitleEnumerationKey"].Value = c.TitleEnumerationKey;
                    DgvGetCommands.Rows[i].Cells["DgvCommand_CommandId"].Value = c.CommandId;
                    DgvGetCommands.Rows[i].Tag = c;
                }
            }
        }

        private void BtnGetCommandEnumeration_Click(object sender, EventArgs e)
        {
            {
                DgvGetCommandEnumeration.DataSource = null;
                string resource = TxtObjects_GetCommandEnum_ID.Text;
                if (_client != null && resource.Length > 0)
                {
                    var res = _client.GetCommandEnumeration(resource);
                    DgvGetCommandEnumeration.DataSource = res;
                }
            }
        }

        private void BtnGetCommandEnums_Click(object sender, EventArgs e)
        {
            DgvGetCommandEnums.Rows.Clear();
            DataGridViewRow dgvr = null;
            if (DgvGetCommands.SelectedRows.Count > 0)
            {
                dgvr = DgvGetCommands.SelectedRows[0];
            }

            if (dgvr != null)
            {
                Command boundItem = (Command)dgvr.Tag;
                if (boundItem != null)
                {
                    if ((boundItem.Items != null) && (boundItem.Items.Count() > 0))
                    {
                        Command.Item itm = boundItem.Items.First();
                        if (itm.EnumerationValues != null)
                        {
                            foreach (Command.EnumerationItem ev in itm.EnumerationValues)
                            {
                                int i = DgvGetCommandEnums.Rows.Add();
                                DgvGetCommandEnums.Rows[i].Cells["DgvCommandEnum_TitleEnumerationKey"].Value = ev.TitleEnumerationKey;
                                DgvGetCommandEnums.Rows[i].Tag = ev;
                            }
                        }
                    }
                }
            }

        }

        private void BtnReadProperty_Click_1(object sender, EventArgs e)
        {
            Guid itemGUID = _client.GetObjectIdentifier(txtObjectFQR.Text);
            Variant response = _client.ReadProperty(itemGUID, txtPropertyName.Text);
            TxtObject_PropertyValue.Text = response.StringValue;
        }

        private void TabMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_enableTabs)
            {
                e.Cancel = true;
                MessageBox.Show("You must Login before to change 'Tab'!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private static string FormatJson(object obj)
        {
            //dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }





    }
}
