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
    public partial class pagecode_request_cico_wfh_confirm : System.Web.UI.UserControl
    {
        static string typeCICOWFH1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string typeCICO1;
                if (string.IsNullOrEmpty(Session["datereqcicowfh1"] as string) == true ||
                    string.IsNullOrEmpty(Session["timereqcicowfh1"] as string) == true ||
                    string.IsNullOrEmpty(Session["typereqcicowfh1"] as string) == true)
                {
                    popUpMsgBox("Mohon maaf terjadi kesalahan pada sistem. Silahkan melakukan request ulang");
                }
                else
                {

                    lblDateCICOWFH.Text = Session["datereqcicowfh1"].ToString();
                    lblTimeCICOWFH.Text = Session["timereqcicowfh1"].ToString();
                    typeCICOWFH1 = Session["typereqcicowfh1"].ToString();
                    if (Session["typereqcicowfh1"].ToString() == "TRXCC_01")
                    {
                        typeCICO1 = "Clock In";
                    }
                    else
                    {
                        typeCICO1 = "Clock Out";
                    }
                    lblTypeCICOWFH.Text = typeCICO1;
                }
            }
        }

        protected void cmdSubmitCICOWFH_Click(object sender, EventArgs e)
        {
            Boolean flg1 = submitCICOWFH(Session["nrp1"].ToString(), lblDateCICOWFH.Text, lblTimeCICOWFH.Text
                ,typeCICOWFH1, "Request_CICO_WFH_by_MobileWeb");

            if (flg1 == true)
            {
                popUpMsgBox("Request anda sukses tersubmit ke server");
            }
        }

        protected void cmdCancelWFH_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_menu_wfh.aspx");
        }

        static Boolean submitCICOWFH(string nrp1, string date1, string time1, string type1, string note1)
        {
            Boolean flg1;
            flg1 = true;
            if (note1 == null || note1 == "")
            {
                note1 = "Request_CICO_WFH_by_MobileWeb";
            }
            else
            {
                note1 = note1.Replace(" ", "_");
                note1 = note1.Replace("/", "#");
            }

            note1 = HttpUtility.UrlEncode(note1);
            date1 = date1.Replace("-", "_");
            time1 = time1.Replace(":", "");

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subreqcicowfh/" + nrp1 + "/" + date1 + "/"
                + time1 + "/" + note1 + "/" + type1;

            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<subCico1>(jsonstr);
                flg1 = Convert.ToBoolean(result1.subReqCicoWFHResult);
            }

            return flg1;

        }

        public class subCico1
        {
            public string subReqCicoWFHResult;
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='request_menu_wfh.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }
    }
}