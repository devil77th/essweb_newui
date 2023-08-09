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
    public partial class pagecode_request_claim_internet_wfh_confirm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                lblDateCICOWFHin.Text = Session["tglcicowfhin"].ToString().Substring(0,20).Trim();
                lblDateCICOWFHout.Text = Session["tglcicowfhout"].ToString().Substring(0,20).Trim();
                lblEmailHour.Text = Session["emailhour"].ToString();
                lblSAPHour.Text = Session["saphour"].ToString();
                lblTeamsHour.Text = Session["teamshour"].ToString();
            }
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("tglcicowfh");
            Session.Remove("emailhour");
            Session.Remove("saphour");
            Session.Remove("teamshour");
            Response.Redirect("claim_menu.aspx");
        }

        static void submitClaimInternetWFH(string nrp1, string date1, string date2,string mailhour1, string saphour1, string teamshour1)
        {
            Boolean flg1;
            flg1 = true;

            date1 = date1.Replace(" ", "_");
            date2 = date2.Replace(" ", "_");


            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/submitclaiminternet/" + nrp1 + "/" + date1 + "/" + date2 + "/"
                + mailhour1 + "/" + saphour1 + "/" + teamshour1;

            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                //var result1 = JsonConvert.DeserializeObject<subCico1>(jsonstr);
                //flg1 = Convert.ToBoolean(result1.subReqCicoWFHResult);
            }
        }

        public class subCico1
        {
            public string subReqCicoWFHResult;
        }

        protected void cmdSubmitClaimInternet_Click(object sender, EventArgs e)
        {
            string nrp1 = Session["nrp1"].ToString();
            submitClaimInternetWFH(nrp1, lblDateCICOWFHin.Text,lblDateCICOWFHout.Text, 
                lblEmailHour.Text, lblSAPHour.Text, lblTeamsHour.Text);
            popUpMsgBox("Request anda sukses tersubmit ke server");
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='claim_menu.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }
    }
}