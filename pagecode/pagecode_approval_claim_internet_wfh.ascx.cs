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
    public partial class pagecode_approval_claim_internet_wfh : System.Web.UI.UserControl
    {
        static DataTable dtable1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                UpdateDList();
            }
        }

        void UpdateDList()
        {
            DataTable dl1 = getApprovalClaimData((string)Session["nrp1"]);
            dlClaimInternet1.DataSource = dl1;
            dlClaimInternet1.DataBind();
        }

        void updateClaimInternet(string idtrx1, string act1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/approveclaiminternet/" + idtrx1 + "/" + act1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }

        }

        static DataTable getApprovalClaimData(string nrp1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listclaiminternet/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetListTrxClaimInternetResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrx1");
                dtable1.Columns.Add("fullname1");
                dtable1.Columns.Add("dateclaim1");
                dtable1.Columns.Add("dateclaim2");
                dtable1.Columns.Add("mailhour1");
                dtable1.Columns.Add("saphour1");
                dtable1.Columns.Add("teamshour1");

                if (String.IsNullOrEmpty(result1.GetListTrxClaimInternetResult[0].idtrx1) == false)
                {
                    for (int i = 0; i <= result1.GetListTrxClaimInternetResult.Count - 1; i++)
                    {
                        dtable1.Rows.Add(result1.GetListTrxClaimInternetResult[i].idtrx1,
                            result1.GetListTrxClaimInternetResult[i].fullname1,
                            result1.GetListTrxClaimInternetResult[i].dateclaim1,
                            result1.GetListTrxClaimInternetResult[i].dateclaim2,
                            result1.GetListTrxClaimInternetResult[i].mailhour1,
                            result1.GetListTrxClaimInternetResult[i].saphour1,
                            result1.GetListTrxClaimInternetResult[i].teamshour1);
                    }
                }

                return dtable1;
            }

        }

        public class GetListTrxClaimInternetResult1
        {
            public List<empClaim> GetListTrxClaimInternetResult { get; set; }
        }

        public class empClaim
        {
            public string dateclaim1 { get; set; }
            public string dateclaim2 { get; set; }
            public string fullname1 { get; set; }
            public string idtrx1 { get; set; }
            public string mailhour1 { get; set; }
            public string saphour1 { get; set; }
            public string teamshour1 { get; set; }
        }

        protected void dlClaimInternet1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxIDClaim");
            string idtrx = hidval11.Value;

            if (e.CommandName == "cmdApprove")
            {
                updateClaimInternet(idtrx, "1");
            }

            if (e.CommandName == "cmdReject")
            {
                updateClaimInternet(idtrx, "0");
            }

            if (e.CommandName == "cmdEdit")
            {
                Response.Redirect("claiminternet_edit.aspx?i=" + idtrx);
            }
            UpdateDList();
            updPanelListClaimInternet1.Update();
        }

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateClaimInternet(row1["idtrx1"].ToString(), "1");

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
                    updateClaimInternet(row1["idtrx1"].ToString(), "0");

                }
                UpdateDList();
            }
        }
    }
}