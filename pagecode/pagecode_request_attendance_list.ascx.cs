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
    public partial class pagecode_request_attendance_list : System.Web.UI.UserControl
    {
        static DataTable dtable1, dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                updateAttList(Session["nrp1"].ToString());
            }
        }

        protected void gvatt1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvatt1.PageIndex = e.NewPageIndex;
            gvatt1.DataSource = dl1;
            gvatt1.DataBind();
        }

        protected void gvatt1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string temp1 = e.CommandName.ToString();
            if (temp1 == "cmdTrxSelect")
            {
                Response.Redirect("request_attendance_detail.aspx?trx1=" + e.CommandArgument.ToString());
            }
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_attendance.aspx");
        }

        void updateAttList(string nrp1)
        {
            dl1 = getListAtt(nrp1);
            gvatt1.DataSource = dl1;
            gvatt1.DataBind();
        }

        static DataTable getListAtt(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstreqattpernrp/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.lstReqAttResultPerNRP>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrx1");
                dtable1.Columns.Add("attcode1");
                dtable1.Columns.Add("attname1");
                dtable1.Columns.Add("begda1");
                dtable1.Columns.Add("creda1");
                dtable1.Columns.Add("endda1");
                dtable1.Columns.Add("nrp1");
                dtable1.Columns.Add("status1");

                for (int i = 0; i <= result1.listReqAttperNRP1Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.listReqAttperNRP1Result[i].id1,
                        result1.listReqAttperNRP1Result[i].attcode1,
                        result1.listReqAttperNRP1Result[i].attname1,
                        result1.listReqAttperNRP1Result[i].begda1,
                        result1.listReqAttperNRP1Result[i].creda1,
                        result1.listReqAttperNRP1Result[i].endda1,
                        result1.listReqAttperNRP1Result[i].nrp1,
                        result1.listReqAttperNRP1Result[i].status1);
                }

                return dtable1;
            }

        }
    }
}