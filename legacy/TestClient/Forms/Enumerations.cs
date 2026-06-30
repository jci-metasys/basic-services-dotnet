using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MetasysServices_TestClient.Forms
{
    public partial class Enumerations : Form
    {
        private MetasysClient _client;
        public MetasysClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Enumerations()
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

        private void BtnGetEnumerations_Click(object sender, EventArgs e)
        {
            DgvGetSiteEnumerations.DataSource = null;
            var result = _client.Enumerations.Get();
            DgvGetSiteEnumerations.DataSource = result;
        }

        private void BtnGetEnumValues_Click(object sender, EventArgs e)
        {
            DgvGetEnumValues.DataSource = null;
            String id = TxtGetEnumValues_Id.Text.Trim();
            if (id.Length > 0)
            {
                var result = _client.Enumerations.GetValues(id);
                DgvGetEnumValues.DataSource = result;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TxtDeleted_Result.Text = String.Empty;
            String id = TxtDelete_Id.Text;
            if (id.Length > 0)
            {
                try
                {
                    _client.Enumerations.Delete(id);
                    TxtDeleted_Result.Text = "OK, done";
                }
                catch (MetasysHttpException ex)
                {
                    TxtDeleted_Result.Text = "Error: " + ex.Message;
                }
            }

        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            TxtCreate_Result.Text = "";
            String name = TxtCreate_Name.Text;
            if (name.Length > 0 && DgvCreate_Values.Rows.Count > 1)
            {
                var values = new List<String>();
                foreach (DataGridViewRow dr in DgvCreate_Values.Rows)
                {
                    String value = (dr.Cells[0].Value != null) ? dr.Cells[0].Value.ToString() : "";
                    if (value.Length > 0)
                    {
                        values.Add(value);
                    }
                }

                if (values.Count > 0)
                {
                    try
                    {
                        _client.Enumerations.Create(name, values);
                        TxtCreate_Result.Text = "OK, done.";
                    }
                    catch (MetasysHttpException ex)
                    {
                        TxtCreate_Result.Text = "Error: " + ex.Message;
                    }
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TxtEdit_Result.Text = "";
            String id = TxtEdit_Id.Text;
            String name = TxtEdit_Name.Text;
            if (id.Length > 0 && name.Length > 0 && DgvEdit_Values.Rows.Count > 1)
            {
                var values = new List<String>();
                foreach (DataGridViewRow dr in DgvEdit_Values.Rows)
                {
                    String value = (dr.Cells[0].Value != null) ? dr.Cells[0].Value.ToString() : "";
                    if (value.Length > 0)
                    {
                        values.Add(value);
                    }
                }

                if (values.Count > 0)
                {
                    try
                    {
                        _client.Enumerations.Edit(id, name, values);
                        TxtEdit_Result.Text = "OK, done.";
                    }
                    catch (MetasysHttpException ex)
                    {
                        TxtEdit_Result.Text = "Error: " + ex.Message;
                    }
                }
            }

        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            TxtReplace_Result.Text = "";
            String id = TxtReplace_Id.Text;
            String name = TxtReplace_Name.Text;
            if (id.Length > 0 && name.Length > 0 && DgvReplace_Values.Rows.Count > 1)
            {
                var values = new List<String>();
                foreach (DataGridViewRow dr in DgvReplace_Values.Rows)
                {
                    String value = (dr.Cells[0].Value != null) ? dr.Cells[0].Value.ToString() : "";
                    if (value.Length > 0)
                    {
                        values.Add(value);
                    }
                }

                if (values.Count > 0)
                {
                    try
                    {
                        _client.Enumerations.Replace(id, name, values);
                        TxtReplace_Result.Text = "OK, done.";
                    }
                    catch (MetasysHttpException ex)
                    {
                        TxtReplace_Result.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
    }
}
