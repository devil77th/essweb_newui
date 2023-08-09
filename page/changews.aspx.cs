using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.page
{
    public partial class changews : System.Web.UI.Page
    {
        static string tgl1, nrp1, nrp2, ciwfo1, cowfo1, ciwfh1, cowfh1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                changews1();
            }
        }

        static string cekWS(string nrp1, string date1)
        {
            string status1 = "";
            date1 = date1.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getworksched_date/" + nrp1 + "/" + date1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listreportschedule>(jsonstr);

                for (int i = 0; i <= result1.GetWorkSchedule_DateResult.Count - 1; i++)
                {
                    status1 = result1.GetWorkSchedule_DateResult[i].status1;
                    ciwfo1 = result1.GetWorkSchedule_DateResult[i].ciwfo1;
                    cowfo1 = result1.GetWorkSchedule_DateResult[i].cowfo1;
                }

            }
            return status1;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

       void changews1()
        {
            string nrp1 = Base64Decode(Request["id1"]);
            string date1 = Base64Decode(Request["id2"]);
            date1 = date1.Replace("_", "-");
            string status1 = cekWS(nrp1, date1);
            if (status1 == "WFO")
            {
                InsertWFH(nrp1, date1, ciwfo1, cowfo1);
                lblstatus.Text = "Work Schedule sudah berubah dari WFO -> WFH";
            }
            else
            {
                delWFH(nrp1, date1);
                lblstatus.Text = "Work Schedule sudah berubah dari WFH -> WFO";
            }
        }

        void InsertWFH(string nrp1, string date1, string time1, string time2)
        {
            date1 = date1.Replace("-", "_");
            time1 = time1.Replace(":", "_");
            time2 = time2.Replace(":", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/insertwfhsched/" + nrp1 + "/" + date1 + "/" +
                time1 + "/" + time2;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        void delWFH(string nrp1, string date1)
        {
            date1 = date1.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delwfhsched/" + nrp1 + "/" + date1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        public class listreportschedule
        {
            public List<reportschedule> GetWorkSchedule_DateResult { get; set; }
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
    }
}