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
    public partial class pagecode_request_absence_list : System.Web.UI.UserControl
    {
        static DataTable dtable1, dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                UpdateDList();
            }
        }

        protected void gvabs1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvabs1.PageIndex = e.NewPageIndex;
            gvabs1.DataSource = dl1;
            gvabs1.DataBind();
        }

        protected void gvabs1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string temp1 = e.CommandName.ToString();
            if (temp1 == "cmdAbsSelect")
            {
                Response.Redirect("request_absence_detail.aspx?trx1=" + e.CommandArgument.ToString());
            }
        }

        void UpdateDList()
        {
            //DataTable dl1 = getListOVTData(Session["nrp"].ToString());
            dl1 = getListAbsence(Session["nrp1"].ToString());
            //dl1 = getListAbsence("1099");
            gvabs1.DataSource = dl1;
            gvabs1.DataBind();
        }

        static DataTable getListAbsence(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstreqabspernrp/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.listReqAbsperNRP1Result1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("id1");
                dtable1.Columns.Add("creda1");
                dtable1.Columns.Add("begda1");
                dtable1.Columns.Add("endda1");
                dtable1.Columns.Add("absname1");
                dtable1.Columns.Add("status1");

                for (int i = 0; i <= result1.listReqAbsperNRP1Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.listReqAbsperNRP1Result[i].id1,
                        result1.listReqAbsperNRP1Result[i].creda1,
                        result1.listReqAbsperNRP1Result[i].begda1,
                        result1.listReqAbsperNRP1Result[i].endda1,
                        result1.listReqAbsperNRP1Result[i].absname1,
                        result1.listReqAbsperNRP1Result[i].status1);
                }

                return dtable1;
            }

        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_absence.aspx");
        }
    }
}