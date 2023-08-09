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
    public partial class pagecode_request_cico_confirm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string typeCICO1;
                if (string.IsNullOrEmpty(Session["datereqcico1"] as string) == true ||
                    string.IsNullOrEmpty(Session["timereqcico1"] as string) == true ||
                    string.IsNullOrEmpty(Session["typereqcico1"] as string) == true)
                {
                    popUpMsgBox("Mohon maaf terjadi kesalahan pada sistem. Silahkan melakukan request ulang");
                }
                else
                {
                    lblDateCICO.Text = Session["datereqcico1"].ToString();
                    lblTimeCICO.Text = Session["timereqcico1"].ToString();
                    if (Session["typereqcico1"].ToString() == "TRXCC_01")
                    {
                        typeCICO1 = "Clock In";
                    }
                    else
                    {
                        typeCICO1 = "Clock Out";
                    }
                    lblTypeCICO.Text = typeCICO1;
                }
                
            }
        }

        static Boolean submitCICO(string nrp1, string date1, string time1, string type1, string note1)
        {
            Boolean flg1;
            flg1 = true;
            if(note1==null || note1 == "")
            {
                note1 = "Request_CICO_by_MobileWeb";
            }
            else
            {
                note1 = note1.Replace(" ", "_");
                note1 = note1.Replace("/", "#");
            }
            
            note1 = HttpUtility.UrlEncode(note1);
            date1 = date1.Replace("-", "_");
            time1 = time1.Replace(":", "");

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subcico/" + nrp1 + "/" + date1 + "/"
                + time1 + "/" + note1 + "/" + type1;

            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<subCico1>(jsonstr);
                flg1 = Convert.ToBoolean(result1.subCicoResult);
            }

            return flg1;

        }

        public class subCico1
        {
            public string subCicoResult;
        }

        static Boolean submitCICOSOAP(string nrp1, string date1, string time1, string type1, string note1)
        {
            Boolean flg1;
            flg1 = true;
            if (note1 == null || note1 == "")
            {
                note1 = "Request_CICO_by_MobileWeb";
            }
            else
            {
                note1 = note1.Replace(" ", "_");
            }

            
            date1 = date1.Replace("-", "_");
            time1 = time1.Replace(":", "");

            var ws = new ws1.Service1();
            try
            {
                ws.subCico1(nrp1, date1, time1, type1, note1, out flg1, out _);
            }
            catch(Exception ex1)
            {

            }
            //var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subcico/" + nrp1 + "/" + date1 + "/"
            //    + time1 + "/" + note1 + "/" + type1;

            //var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            //using (var response = webrequest.GetResponse())
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{
            //    var result = reader.ReadToEnd();
            //    string jsonstr = Convert.ToString(result);
            //    var result1 = JsonConvert.DeserializeObject<subCico1>(jsonstr);
            //    flg1 = Convert.ToBoolean(result1.subCicoResult);
            //}

            return flg1;

        }

        protected void cmdSubmitCICO_Click(object sender, EventArgs e)
        {
            Boolean flg1 = submitCICOSOAP(Session["nrp1"].ToString(), Session["datereqcico1"].ToString(), Session["timereqcico1"].ToString()
                , Session["typereqcico1"].ToString(), Session["notereqcico1"].ToString());

            if(flg1==true)
            {
                popUpMsgBox("Request anda sukses tersubmit ke server");
            }
            
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='request_cico.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_cico.aspx");
        }

        public static string Base64Encode1(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}