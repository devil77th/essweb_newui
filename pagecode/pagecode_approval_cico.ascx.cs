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
    public partial class pagecode_approval_cico : System.Web.UI.UserControl
    {
        static DataTable dtable1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                UpdateDList();
            }
            if(dtable1.Rows.Count > 0)
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

        protected void dlCICO1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxCICO");
            string idtrx = hidval11.Value;
           
            if (e.CommandName == "cmdApprove")
            {
                updateCICO(idtrx, "1", (string)Session["nrp1"]);
            }

            if (e.CommandName == "cmdReject")
            {
                updateCICO(idtrx, "0", (string)Session["nrp1"]);
            }
            UpdateDList();
            updDataListCICO1.Update();
        }

        void updateCICO(string idtrx1,string act1,string nrp1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subapprovalcico/" + idtrx1 + "/" + act1 + "/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
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
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listcico/" + nrp1 ;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetListTrxCICOResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("clockCICO1");
                dtable1.Columns.Add("dateCICO1");
                dtable1.Columns.Add("fullnameCICO1");
                dtable1.Columns.Add("idtrxCICO1");
                dtable1.Columns.Add("reasonCICO1");
                dtable1.Columns.Add("typeCICO1");


                for (int i = 0; i<= result1.GetListTrxCICOResult.Count-1;i++)
                {
                    dtable1.Rows.Add(result1.GetListTrxCICOResult[i].clockCICO,
                        result1.GetListTrxCICOResult[i].dateCICO,
                        result1.GetListTrxCICOResult[i].fullname,
                        result1.GetListTrxCICOResult[i].idtrx,
                        result1.GetListTrxCICOResult[i].reasonCICO,
                        result1.GetListTrxCICOResult[i].typeCICO);
                }

                return dtable1;
            }

        }

        public class GetListTrxCICOResult1
        {
            public List<empCICO> GetListTrxCICOResult { get; set; }
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

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateCICO(row1["idtrxCICO1"].ToString(), "1", (string)Session["nrp1"]);

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
                    updateCICO(row1["idtrxCICO1"].ToString(), "0", (string)Session["nrp1"]);

                }
                UpdateDList();
            }
        }
    }
}