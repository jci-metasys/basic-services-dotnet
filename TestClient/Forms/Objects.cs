using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MetasysServices_TestClient.Forms
{
    public partial class Objects : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Objects()
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

        private void BtnGetObjectIdentifier_Click(object sender, EventArgs e)
        {
            TxtGetObjectIdentifier_Result.Text = String.Empty;
            String objectFQR = TxtGetObjectIdentifier_ObjectFQR.Text.Trim();
            if (objectFQR.Length > 0)
            {
                var result = _client.GetObjectIdentifier(objectFQR);
                TxtGetObjectIdentifier_Result.Text = result.ToString();
            }
        }

        private void BtnGetObjects_Click(object sender, EventArgs e)
        {
            DgvGetObjects.DataSource = null;
            string guid = TxtGetObjects_ParentID.Text;
            int levels = (int)NupGetObject_Levels.Value;
            bool includeExtensions = ChkGetObjects_IncludeExtensions.Checked;
            bool includeInternalObjects = ChkGetObjects_IncludeInternalObjects.Checked;
            if (guid.Length > 0)
            {
                Guid parentId = new Guid(guid);
                var result = _client.GetObjects(parentId, levels, includeInternalObjects, includeExtensions);
                DgvGetObjects.DataSource = result;
            }
        }

        private void BtnGetCommands_Click(object sender, EventArgs e)
        {
            DgvGetCommands.DataSource = null;
            string guid = TxtGetCommands_ObjectId.Text;
            if (guid.Length > 0)
            {
                Guid id = new Guid(guid);
                //List<Command> res = _client.GetCommands(id).ToList();
                var res = _client.GetCommands(id);
                DgvGetCommands.Rows.Clear();
                foreach (Command c in res)
                {
                    int i = DgvGetCommands.Rows.Add();
                    DgvGetCommands.Rows[i].Cells["DgvGetCommands_Title"].Value = c.Title;
                    DgvGetCommands.Rows[i].Cells["DgvGetCommands_TitleEnumerationKey"].Value = c.TitleEnumerationKey;
                    DgvGetCommands.Rows[i].Cells["DgvGetCommands_CommandId"].Value = c.CommandId;
                    DgvGetCommands.Rows[i].Tag = c;
                }
            }
        }

        private void BtnGetCommands_RetrieveEnumValues_Click(object sender, EventArgs e)
        {
            DgvGetCommands_RetrieveEnumValues.Rows.Clear();
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
                                int i = DgvGetCommands_RetrieveEnumValues.Rows.Add();
                                DgvGetCommands_RetrieveEnumValues.Rows[i].Cells["DgvCommandEnum_TitleEnumerationKey"].Value = ev.TitleEnumerationKey;
                                DgvGetCommands_RetrieveEnumValues.Rows[i].Tag = ev;
                            }
                        }
                    }
                }
            }
        }

        private void BtnGetCommandEnumeration_Click(object sender, EventArgs e)
        {
            {
                TxtGetCommandEnumeration_Result.Text = String.Empty;
                string resource = TxtGetCommandEnumeration_EnumTitle.Text;
                if (resource.Length > 0)
                {
                    var response = _client.GetCommandEnumeration(resource);
                    TxtGetCommandEnumeration_Result.Text = response.ToString();
                }
            }
        }

        private void BtnReadProperty_Click(object sender, EventArgs e)
        {
            TxtReadProperty_Result.Text = "";
            String objectId = TxtReadProperty_ObjectId.Text;
            String attributeName = TxtReadProperty_AttributeName.Text;
            if (objectId.Length > 0 && attributeName.Length > 0)
            {
                Guid id = new Guid(objectId);
                Variant response = _client.ReadProperty(id, attributeName);
                TxtReadProperty_Result.Text = response.StringValue;
            }
        }

        private void BtnSendCommand_Click(object sender, EventArgs e)
        {
            TxtSendCommand_Result.Text = "";
            String objectId = TxtSendCommand_ObjectId.Text;
            String command = TxtSendCommand_Command.Text;
            String values = TxtSendCommand_Values.Text;
            if (objectId.Length > 0 && objectId.Length > 0)
            {
                Guid id = new Guid(objectId);
                try
                {
                    if (values.Trim().Length == 0)
                    {
                        _client.SendCommand(id, command);
                    }
                    else
                    {
                        List<object> objValues = new List<object>();
                        if (double.TryParse(values, out double numericValue))
                        {
                            objValues.Add(numericValue);
                        }
                        else
                        {
                            objValues.Add(values);
                        }

                        _client.SendCommand(id, command, objValues);
                    }

                    TxtSendCommand_Result.Text = "OK";
                }
                catch (MetasysHttpException ex)
                {
                    TxtSendCommand_Result.Text = "Error: " + ex.Message;
                }
            }
        }

        private void BtnReadPropertyMultiple_Click(object sender, EventArgs e)
        {
            DgvReadPropertyMultiple_Result.DataSource = null;
            if (DgvReadPropertyMultiple_Ids.Rows.Count > 0 && DgvReadPropertyMultiple_Attrs.Rows.Count > 0)
            {
                // Prepare the list of Ids
                var ids = new List<ObjectId>();
                foreach (DataGridViewRow dr in DgvReadPropertyMultiple_Ids.Rows)
                {
                    var id = dr.Cells[DgvReadPropertyMultiple_Ids_Id.Name].Value;
                    if (id != null && id.ToString().Length > 0)
                    {
                        ids.Add(id.ToString());
                    }
                }
                // Prepare the list of Attributes
                var attributes = new List<string>();
                foreach (DataGridViewRow dr in DgvReadPropertyMultiple_Attrs.Rows)
                {
                    var attribute = dr.Cells[DgvReadPropertyMultiple_Attrs_Attribute.Name].Value;
                    if (attribute != null && attribute.ToString().Length > 0)
                    {
                        attributes.Add(attribute.ToString());
                    }
                }
                // Check if the lists are not empty
                if (ids.Count > 0 && attributes.Count > 0)
                {
                    try
                    {
                        var result = _client.ReadPropertyMultiple(ids, attributes);
                        List<Variant> values = new List<Variant>();

                        foreach (var i in result)
                        {
                            foreach (Variant v in i.Values)
                            {
                                values.Add(v);
                            }
                        }
                        DgvReadPropertyMultiple_Result.DataSource = values;
                    }
                    catch (MetasysHttpException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void BtnWriteProperty_Click(object sender, EventArgs e)
        {
            TxtWriteProperty_Result.Text = "";
            String objectId = TxtWriteProperty_ObjectId.Text;
            String attributeName = TxtWriteProperty_AttributeName.Text;
            var newValue = TxtWriteProperty_NewValue.Text;
            if (objectId.Length > 0 && attributeName.Length > 0)
            {
                Guid id = new Guid(objectId);

                try
                {
                    _client.WriteProperty(id, attributeName, newValue);
                    TxtWriteProperty_Result.Text = "OK";
                }
                catch (Exception ex)
                {
                    TxtSendCommand_Result.Text = "Error: " + ex.Message;
                }
            }
        }

        private void BtnWritePropertyMultiple_Click(object sender, EventArgs e)
        {
            TxtWritePropertyMultiple_Result.Text = "";
            if (DgvWritePropertyMultiple_Ids.Rows.Count > 0 && DgvWritePropertyMultiple_Attrs.Rows.Count > 0)
            {
                // Prepare the list of Ids
                var ids = new List<ObjectId>();
                foreach (DataGridViewRow dr in DgvWritePropertyMultiple_Ids.Rows)
                {
                    var id = dr.Cells[DgvWritePropertyMultiple_Ids_Id.Name].Value;
                    if (id != null && id.ToString().Length > 0)
                    {
                        ids.Add(id.ToString());
                    }
                }
                // Prepare the list of Attributes
                var attributes = new Dictionary<string, object>();
                foreach (DataGridViewRow dr in DgvWritePropertyMultiple_Attrs.Rows)
                {
                    var attrName = dr.Cells[DgvWritePropertyMultiple_Attrs_Name.Name].Value;
                    var attrValue = dr.Cells[DgvWritePropertyMultiple_Attrs_Value.Name].Value;
                    if (attrName != null && attrName.ToString().Length > 0 && attrValue != null && attrValue.ToString().Length > 0)
                    {
                        attributes.Add(attrName.ToString(), attrValue);
                    }
                }
                // Check if the lists are not empty
                if (ids.Count > 0 && attributes.Count > 0)
                {
                    try
                    {
                        _client.WritePropertyMultiple(ids, attributes);
                        TxtWritePropertyMultiple_Result.Text = "OK";
                    }
                    catch (MetasysHttpException ex)
                    {
                        TxtWritePropertyMultiple_Result.Text = "Error: " + ex.Message;
                    }
                }
            }

        }
    }
}
