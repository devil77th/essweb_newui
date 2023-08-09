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
    public partial class pagecode_request_attendance_confirm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(Page.IsPostBack==false)
            {
                lblDateAttendance.Text = Session["datereqattendance1"].ToString();
                lblTimeAttendance1.Text = Session["timereqattendance1"].ToString();
                lblTimeAttendance2.Text = Session["timereqattendance2"].ToString();
                //lblReasonAttendance.Text = Session["notereqattendance1"].ToString();
                lblTypeAttendance.Text  = Session["typetxtreqattendance1"].ToString();
                hid1.Value = Session["typevalreqattendance1"].ToString();
            }
            
        }

        protected void cmdSubmitAttendance_Click(object sender, EventArgs e)
        {
            Boolean flgSubmit = submitAttendance(lblDateAttendance.Text, lblTimeAttendance1.Text,
                lblTimeAttendance2.Text, hid1.Value, Session["nrp1"].ToString());
            if (flgSubmit == true)
            {
                popUpMsgBox("Request anda sukses tersubmit ke server");
            }
        }

        static Boolean submitAttendance(string date1,string time1,string time2,string type1,string nrp1)
        {
            Boolean flg1;
            flg1 = true;

            DateTime datefrom = Convert.ToDateTime(date1);
            date1 = datefrom.ToShortDateString();
            date1 = date1.Replace("/", "");
            time1 = time1.Replace(":", "");
            time2 = time2.Replace(":", "");

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subattend/" + nrp1 + "/" + date1 + "/"
                + time1 + "/" + time2 + "/" + type1;

            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<subAttendance1>(jsonstr);
                flg1 = Convert.ToBoolean(result1.subAttendanceResult);
            }
            
            return flg1;
        }

        public class subAttendance1
        {
            public string subAttendanceResult;
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_attendance.aspx");
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='request_attendance.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }
    }
}