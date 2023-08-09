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
    public partial class pagecode_report_absence_sub : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                loadDataMember(Session["nrp1"].ToString());
                FillddlYear();
            }
        }

        void loadDataMember(string nrp1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listallsub/" + nrp1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);

                var result1 = JsonConvert.DeserializeObject<listSubordinate1>(jsonstr);
                ddlSubordinate.Items.Add(new ListItem("Select Employee", ""));

                if (result1.GetAllSubordinateResult[0].nrp.ToString() != "")
                {
                    for (int i = 0; i <= result1.GetAllSubordinateResult.Count - 1; i++)
                    {
                        ddlSubordinate.Items.Add(new ListItem(result1.GetAllSubordinateResult[i].fullname,
                            result1.GetAllSubordinateResult[i].nrp));
                    }
                }
            }

        }

        public class listSubordinate1
        {
            public List<GetlistSubordinate1> GetAllSubordinateResult { get; set; }
        }

        public class GetlistSubordinate1
        {
            public string nrp { get; set; }
            public string fullname { get; set; }
        }

        public void FillddlYear()
        {
            ddlYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
            ddlYear.Items.Add(new ListItem(DateTime.Now.AddYears(-1).Year.ToString(), DateTime.Now.AddYears(-1).Year.ToString()));
        }

        void UpdateDList()
        {
            DataTable dl1 = getApprovalCICOData(ddlSubordinate.SelectedValue, ddlMonth.SelectedValue, ddlYear.SelectedValue);
            //DataTable dl1 = getApprovalCICOData("5963", ddlMonth.SelectedValue, ddlYear.SelectedValue);
            gvcico1.DataSource = dl1;
            gvcico1.DataBind();
        }
        static DataTable getApprovalCICOData(string nrp1, string mon1, string year1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getreportabsv2/" + nrp1 + "/" + mon1 + "/" + year1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.Timeout = 60000;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listreportabsv2>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("tgl1");
                dtable1.Columns.Add("hari1");
                dtable1.Columns.Add("ciwfo1");
                dtable1.Columns.Add("cowfo1");
                dtable1.Columns.Add("ciwfh1");
                dtable1.Columns.Add("cowfh1");
                dtable1.Columns.Add("abswfo1");
                dtable1.Columns.Add("attwfo1");
                dtable1.Columns.Add("reqmailhour1");
                dtable1.Columns.Add("reqsaphour1");
                dtable1.Columns.Add("reqteamshour1");
                dtable1.Columns.Add("statusreqclaim1");
                dtable1.Columns.Add("liburwfo1");
                dtable1.Columns.Add("wsin1");
                dtable1.Columns.Add("wsout1");



                for (int i = 0; i <= result1.GetReportAbsv2Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.GetReportAbsv2Result[i].tgl1,
                        result1.GetReportAbsv2Result[i].hari1,
                        result1.GetReportAbsv2Result[i].ciwfo1,
                        result1.GetReportAbsv2Result[i].cowfo1,
                        result1.GetReportAbsv2Result[i].ciwfh1,
                        result1.GetReportAbsv2Result[i].cowfh1,
                        result1.GetReportAbsv2Result[i].abswfo1,
                        result1.GetReportAbsv2Result[i].attwfo1,
                        result1.GetReportAbsv2Result[i].reqmailhour1,
                        result1.GetReportAbsv2Result[i].reqsaphour1,
                        result1.GetReportAbsv2Result[i].reqteamshour1,
                        result1.GetReportAbsv2Result[i].statusreqclaim1,
                        result1.GetReportAbsv2Result[i].liburwfo1,
                        result1.GetReportAbsv2Result[i].wsin1,
                        result1.GetReportAbsv2Result[i].wsout1);
                }
                return dtable1;
            }

        }

        public class listreportabsv2
        {
            public List<reportabsv2> GetReportAbsv2Result { get; set; }
        }

        public class reportabsv2
        {
            public string abswfo1 { get; set; }
            public string attwfo1 { get; set; }
            public string ciwfh1 { get; set; }
            public string ciwfo1 { get; set; }
            public string cowfh1 { get; set; }
            public string cowfo1 { get; set; }
            public string hari1 { get; set; }
            public string liburwfo1 { get; set; }
            public string tgl1 { get; set; }
            public string reqmailhour1 { get; set; }
            public string reqteamshour1 { get; set; }
            public string reqsaphour1 { get; set; }
            public string statusreqclaim1 { get; set; }
            public string wsin1 { get; set; }
            public string wsout1 { get; set; }

        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            if(ddlMonth.SelectedValue != "" && ddlSubordinate.SelectedValue != "")
            {
                cmdSearch.Enabled = false;
                UpdateDList();
                cmdSearch.Enabled = true;
            }
        }
    }
}