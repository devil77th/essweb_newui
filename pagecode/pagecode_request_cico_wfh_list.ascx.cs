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
using static WebApplication1.pagecode.pagecode_request_medical_list;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_cico_wfh_list : System.Web.UI.UserControl
    {
        static DataTable dtable1,dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                loadData(Session["nrp1"].ToString());
            }
        }

        void loadData (string nrp1)
        {
            dl1 = getListCICOWFH(nrp1);
            gvcicowfh1.DataSource = dl1;
            gvcicowfh1.DataBind();
        }

        static DataTable getListCICOWFH(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstcicowfhpernrp/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.lstCICOWFHperNRPResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrx1");
                dtable1.Columns.Add("tipe1");
                dtable1.Columns.Add("time1");
                dtable1.Columns.Add("tipesubmit1");
                dtable1.Columns.Add("status1");

                for (int i = 0; i <= result1.listCICOWFHperNRP1Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.listCICOWFHperNRP1Result[i].idtrx1,
                        result1.listCICOWFHperNRP1Result[i].type1,
                        result1.listCICOWFHperNRP1Result[i].time1,
                        result1.listCICOWFHperNRP1Result[i].submittype1,
                        result1.listCICOWFHperNRP1Result[i].approvalstatus1);
                }

                return dtable1;
            }

        }

        protected void gvcicowfh1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvcicowfh1.PageIndex = e.NewPageIndex;
            gvcicowfh1.DataSource = dl1;
            gvcicowfh1.DataBind();
        }

        protected void gvcicowfh1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string temp1 = e.CommandName.ToString();
            if(temp1 == "cmdTrxSelect")
            {
                Response.Redirect("request_cico_wfh_detail.aspx?trx1=" + e.CommandArgument.ToString());
            }

        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_cico_wfh.aspx");
        }
    }
}