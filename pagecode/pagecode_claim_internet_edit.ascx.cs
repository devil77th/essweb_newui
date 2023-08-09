using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_claim_internet_edit : System.Web.UI.UserControl
    {
        static string idtrx1;
        protected void Page_Load(object sender, EventArgs e)
        {
            idtrx1 = Request["i"].ToString();
            if (Page.IsPostBack == false)
            {
                LoadData(idtrx1);
            }
        }

        public void LoadData(string idclaim1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getdataclaiminternet/" + idclaim1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetDataTrxClaimInternetResult1>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                lblDateClaim1.Text = result1.GetDataTrxClaimInternetResult[0].dateclaim1.ToString();
                lblDateClaim2.Text = result1.GetDataTrxClaimInternetResult[0].dateclaim2.ToString();
                txtMailHour.Text = result1.GetDataTrxClaimInternetResult[0].mailhour1.ToString();
                txtSAPHour.Text = result1.GetDataTrxClaimInternetResult[0].saphour1.ToString();
                txtMSTeams.Text = result1.GetDataTrxClaimInternetResult[0].teamshour1.ToString();
                hidvalNRP.Value = result1.GetDataTrxClaimInternetResult[0].fullname1.ToString();
            }
           
        }

        public class GetDataTrxClaimInternetResult1
        {
            public List<empClaimInternet> GetDataTrxClaimInternetResult { get; set; }
        }

        public class empClaimInternet
        {
            public string idtrx1 { get; set; }
            public string dateclaim1 { get; set; }
            public string dateclaim2 { get; set; }
            public string mailhour1 { get; set; }
            public string saphour1 { get; set; }
            public string teamshour1 { get; set; }
            public string fullname1 { get; set; }

        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("approval_claiminternet_wfh.aspx");
        }

        protected void cmdSubmitClaim_Click(object sender, EventArgs e)
        {
            string time1, time2;
            time1 = lblDateClaim1.Text.Replace("-", "_");
            time2 = lblDateClaim2.Text.Replace("-", "_");

            if (isValidNumber(txtMailHour.Text.Trim()) == true && isValidNumber(txtSAPHour.Text.Trim()) == true
                && isValidNumber(txtMSTeams.Text.Trim()) == true)
            {

                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/editclaiminternet/" + idtrx1 + "/" +
                    txtMailHour.Text.Trim() + "/" + txtSAPHour.Text.Trim() + "/" + txtMSTeams.Text.Trim() + "/" +
                    hidvalNRP.Value + "/" + time1 + "/" + time2;
                //Console.WriteLine(url.ToString());
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    string jsonstr = Convert.ToString(result);
                }
                popUpMsgBox("Edit Claim Internet berhasil");
            }
            else
            {
                popUpMsgBox2("Mohon diisi dengan data yang benar");
            }
        }

        public Boolean isValidNumber(string text1)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            return regex.IsMatch(text1);
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='approval_claiminternet_wfh.aspx';};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        void popUpMsgBox2(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("')};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }
    }
}