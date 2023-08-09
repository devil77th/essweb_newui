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
    public partial class pagecode_request_overtime_list : System.Web.UI.UserControl
    {
        static DataTable dtable1,dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                if (string.IsNullOrEmpty(Session["gol"].ToString()) == false)
                {
                    if(Session["gol"].ToString()=="IV" || Session["gol"].ToString() == "II" || Session["gol"].ToString() == "III")
                    {
                        cmdAdd1.Visible = true;
                        UpdateDList();
                    }
                    else
                    {
                        cmdAdd1.Visible = false;
                    }
                }
                
            }
        }

        void UpdateDList()
        {
            dl1 = getListOVTData(Session["nrp1"].ToString());
            //dl1 = getListOVTData("2000");
            gvovt1.DataSource = dl1;
            gvovt1.DataBind();
        }

        public class ListOvertimeByNRPResult1
        {
            public List<dataOVT> ListOvertimeByNRPResult { get; set; }
        }

        public class dataOVT
        {
            public string id1 { get; set; }
            public string nrp1 { get; set; }
            public string statusovt1 { get; set; }
            public string timeovt1 { get; set; }
            public string timeovt2 { get; set; }
            public string reasonovt1 { get; set; }
            public string createdateovt1 { get; set; }
        }

        static DataTable getListOVTData(string nrp1)
        {
            string jsonstr,reason1;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listdataovt/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<ListOvertimeByNRPResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrxOVT1");
                dtable1.Columns.Add("nrp1");
                dtable1.Columns.Add("timeOVT1");
                dtable1.Columns.Add("timeOVT2");
                dtable1.Columns.Add("statusOVT1");
                dtable1.Columns.Add("reasonOVT1");
                dtable1.Columns.Add("createdateOVT1");

                for (int i = 0; i <= result1.ListOvertimeByNRPResult.Count - 1; i++)
                {
                    if(result1.ListOvertimeByNRPResult[i].statusovt1=="WFSTS_01")
                    {
                        reason1 = "Waiting for approval";
                    }
                    else if(result1.ListOvertimeByNRPResult[i].statusovt1 == "WFSTS_02")
                    {
                        reason1 = "Approved";
                    }
                    else if(result1.ListOvertimeByNRPResult[i].statusovt1 == "WFSTS_03")
                    {
                        reason1 = "Rejected";
                    }
                    else
                    {
                        reason1 = "";
                    }

                    dtable1.Rows.Add(result1.ListOvertimeByNRPResult[i].id1,
                        result1.ListOvertimeByNRPResult[i].nrp1,
                        result1.ListOvertimeByNRPResult[i].timeovt1,
                        result1.ListOvertimeByNRPResult[i].timeovt2,
                        reason1,
                        result1.ListOvertimeByNRPResult[i].reasonovt1,
                        result1.ListOvertimeByNRPResult[i].createdateovt1);
                }

                return dtable1;
            }

        }

        protected void gvovt1_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i <= gvovt1.Rows.Count - 1; i++)
            {
                Label lblparent = (Label)gvovt1.Rows[i].FindControl("lblstatus1");
                if (lblparent.Text == "Approved" || lblparent.Text == "Rejected")
                {
                    gvovt1.Rows[i].Cells[5].Enabled = false;
                }
                else
                {
                    gvovt1.Rows[i].Cells[5].Enabled = true;
                }
            }
        }

        protected void gvovt1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delreqovt/" + e.CommandArgument.ToString();
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
            UpdateDList();
        }

        protected void cmdAdd1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_overtime_add.aspx");
        }

        protected void gvovt1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvovt1.PageIndex = e.NewPageIndex;
            gvovt1.DataSource = dl1;
            gvovt1.DataBind();
        }
    }
}