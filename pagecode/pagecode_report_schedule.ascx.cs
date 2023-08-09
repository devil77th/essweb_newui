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
    public partial class pagecode_report_schedule : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
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

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
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

        static DataTable GetWorkSchedule(string nrp1, string mon1, string year1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getworksched/" + nrp1 + "/" + mon1 + "/" + year1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.Timeout = 60000;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listreportschedule>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("tgl1");
                dtable1.Columns.Add("hari1");
                dtable1.Columns.Add("ciwfo1");
                dtable1.Columns.Add("cowfo1");
                dtable1.Columns.Add("ciwfh1");
                dtable1.Columns.Add("cowfh1");
                dtable1.Columns.Add("liburwfo1");
                dtable1.Columns.Add("status1");


                for (int i = 0; i <= result1.GetWorkScheduleResult.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.GetWorkScheduleResult[i].tgl1,
                        result1.GetWorkScheduleResult[i].hari1,
                        result1.GetWorkScheduleResult[i].ciwfo1,
                        result1.GetWorkScheduleResult[i].cowfo1,
                        result1.GetWorkScheduleResult[i].ciwfh1,
                        result1.GetWorkScheduleResult[i].cowfh1,
                        result1.GetWorkScheduleResult[i].liburwfo1,
                        result1.GetWorkScheduleResult[i].status1);
                }
                return dtable1;
            }
        }

        protected void gvws1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmdarg1 = e.CommandArgument.ToString();
            cmdarg1 = cmdarg1.Replace(" ", "_");
            Response.Redirect("report_workschedule_edit.aspx?tgl=" + cmdarg1.ToString() + "&nrp=" + 
                Base64Encode(ddlSubordinate.SelectedValue));
        }

        public class listreportschedule
        {
            public List<reportschedule> GetWorkScheduleResult { get; set; }
        }

        public class reportschedule
        {
            public string ciwfh1 { get; set; }
            public string ciwfo1 { get; set; }
            public string cowfh1 { get; set; }
            public string cowfo1 { get; set; }
            public string hari1 { get; set; }
            public string liburwfo1 { get; set; }
            public string tgl1 { get; set; }
            public string status1 { get; set; }

        }

        void UpdateDList()
        {
            DataTable dl1 = GetWorkSchedule(ddlSubordinate.SelectedValue, ddlMonth.SelectedValue, ddlYear.SelectedValue);
            gvws1.DataSource = dl1;
            gvws1.DataBind();
        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            if (ddlSubordinate.SelectedValue != "" && ddlMonth.SelectedValue != "" & ddlYear.SelectedValue != "")
            {
                cmdSearch.Enabled = false;
                UpdateDList();
                cmdSearch.Enabled = true;
            }
        }
    }
}