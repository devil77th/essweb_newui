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
    public partial class pagecode_request_cico_wfo_list : System.Web.UI.UserControl
    {
        static DataTable dtable1, dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                loadData(Session["nrp1"].ToString());
            }
        }

        void loadData(string nrp1)
        {
            dl1 = getListCICOWFO(nrp1);
            gvcicowfo1.DataSource = dl1;
            gvcicowfo1.DataBind();
        }

        static DataTable getListCICOWFO(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstcicowfopernrp/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.lstCICOWFOperNRPResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrx1");
                dtable1.Columns.Add("tipe1");
                dtable1.Columns.Add("time1");
                dtable1.Columns.Add("tipesubmit1");
                dtable1.Columns.Add("status1");

                for (int i = 0; i <= result1.listCICOWFOperNRP1Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.listCICOWFOperNRP1Result[i].idtrx1,
                        result1.listCICOWFOperNRP1Result[i].type1,
                        result1.listCICOWFOperNRP1Result[i].time1,
                        result1.listCICOWFOperNRP1Result[i].submittype1,
                        result1.listCICOWFOperNRP1Result[i].approvalstatus1);
                }

                return dtable1;
            }

        }

        protected void gvcicowfo1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvcicowfo1.PageIndex = e.NewPageIndex;
            gvcicowfo1.DataSource = dl1;
            gvcicowfo1.DataBind();
        }

        protected void gvcicowfo1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string temp1 = e.CommandName.ToString();
            if (temp1 == "cmdTrxSelect")
            {
                Response.Redirect("request_cico_wfo_detail.aspx?trx1=" + e.CommandArgument.ToString());
            }
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_cico.aspx");
        }
    }
}