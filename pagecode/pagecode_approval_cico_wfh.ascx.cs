using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_approval_cico_wfh : System.Web.UI.UserControl
    {
        static DataTable dtable1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                UpdateDList();
            }
            if (dtable1.Rows.Count > 0)
            {
                cmdApproveAll.Enabled = true;
                cmdRejectAll.Enabled = true;
            }
            else
            {
                cmdApproveAll.Enabled = false;
                cmdRejectAll.Enabled = false;
            }
        }

        void UpdateDList()
        {
            DataTable dl1 = getApprovalCICOData((string)Session["nrp1"]);
            dlCICO1.DataSource = dl1;
            dlCICO1.DataBind();
        }

        static DataTable getApprovalCICOData(string nrp1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listcicowfh/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetListTrxCICOResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("clockCICOWFH1");
                dtable1.Columns.Add("dateCICOWFH1");
                dtable1.Columns.Add("fullnameCICOWFH1");
                dtable1.Columns.Add("idtrxCICOWFH1");
                dtable1.Columns.Add("reasonCICOWFH1");
                dtable1.Columns.Add("typeCICOWFH1");


                for (int i = 0; i <= result1.GetListTrxCICOWFHResult.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.GetListTrxCICOWFHResult[i].clockCICO,
                        result1.GetListTrxCICOWFHResult[i].dateCICO,
                        result1.GetListTrxCICOWFHResult[i].fullname,
                        result1.GetListTrxCICOWFHResult[i].idtrx,
                        result1.GetListTrxCICOWFHResult[i].reasonCICO,
                        result1.GetListTrxCICOWFHResult[i].typeCICO);
                }

                return dtable1;
            }

        }

        void updateCICOWFH(string idtrx1, string act1, string nrp1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subapprovalcicowfh/" + idtrx1 + "/" + act1 + "/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        protected void dlCICO1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxCICO");
            string idtrx = hidval11.Value;

            if (e.CommandName == "cmdApprove")
            {
                updateCICOWFH(idtrx, "1", (string)Session["nrp1"]);
            }

            if (e.CommandName == "cmdReject")
            {
                updateCICOWFH(idtrx, "0", (string)Session["nrp1"]);
            }
            UpdateDList();
            updDataListCICO1.Update();
        }

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateCICOWFH(row1["idtrxCICOWFH1"].ToString(), "1", (string)Session["nrp1"]);

                }
                UpdateDList();
            }

        }

        protected void cmdRejectAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateCICOWFH(row1["idtrxCICOWFH1"].ToString(), "0", (string)Session["nrp1"]);

                }
                UpdateDList();
            }
        }

        public class GetListTrxCICOResult1
        {
            public List<empCICO> GetListTrxCICOWFHResult { get; set; }
        }

        public class empCICO
        {
            public string clockCICO { get; set; }
            public string dateCICO { get; set; }
            public string fullname { get; set; }
            public string idtrx { get; set; }
            public string reasonCICO { get; set; }
            public string typeCICO { get; set; }
        }
    }
}