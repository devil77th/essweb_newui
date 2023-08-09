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

namespace WebApplication1.pagecode
{
    public partial class pagecode_report_schedule_edit : System.Web.UI.UserControl
    {
        static string tgl1,nrp1,nrp2,ciwfo1,cowfo1,ciwfh1,cowfh1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                tgl1 = Request["tgl"];
                nrp2 = Base64Decode(Request["nrp"]);
                tgl1 = tgl1.Replace("_", "-");
                lbldate1.Text = tgl1;
                nrp1 = Session["nrp1"].ToString();
                if (nrp1 == nrp2)
                {
                    lblStatus.Text = "Anda tidak bisa mengubah jadwal diri sendiri. " +
                        "Hubungi atasan langsung anda untuk mengubah jadwal kerja anda";
                    string defaultddl = cekWS(nrp1, tgl1);
                    ddlTypeCICO.SelectedValue = defaultddl;
                    cmdSubmit.Enabled = false;
                }
                else
                {
                    string defaultddl = cekWS(nrp1, tgl1);
                    ddlTypeCICO.SelectedValue = defaultddl;
                    cmdSubmit.Enabled = true;
                    //    if(CekDate(tgl1)==false)
                    //    {
                    //        lblStatus.Text = "Anda tidak bisa mengubah jadwal kerja pada tanggal yang sudah lewat dari tanggal sekarang";
                    //        cmdSubmit.Enabled = false;
                    //    }
                    //    else
                    //    {
                    //        string defaultddl = cekWS(nrp1, tgl1);
                    //        ddlTypeCICO.SelectedValue = defaultddl;
                    //        cmdSubmit.Enabled = true;
                    //    }
                    //}
                }
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        static Boolean CekDate(string date1)
        {
            Boolean flg1=true;
            date1 = date1.Replace("_", "-");
            if(DateTime.Now > Convert.ToDateTime(date1))
            {
                flg1 = false;
            }
            return flg1;
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            if(ddlTypeCICO.SelectedValue=="WFH")
            {
                InsertWFH(nrp2, tgl1, ciwfo1, cowfo1);
                popUpMsgBox("Schedule WFH sudah disubmit");
                
            }
            else
            {
                delWFH(nrp1, tgl1);
                popUpMsgBox("Schedule WFH sudah dihapus");
            }
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("report_workschedule.aspx");
        }

        protected void lbChange_Click(object sender, EventArgs e)
        {
            reqChangeWFH(nrp1, tgl1);
        }

        void InsertWFH(string nrp1,string date1,string time1,string time2)
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

        void delWFH(string nrp1,string date1)
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

        void reqChangeWFH(string nrp1, string date1)
        {
            date1 = date1.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/mailchangewfhsched/" + nrp1 + "/" + date1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
            popUpMsgBox("Request perubahan jadwal sudah disampaikan ke atasan langsung anda");
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

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='report_workschedule.aspx';};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
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