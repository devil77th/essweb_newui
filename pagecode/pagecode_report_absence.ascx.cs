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
    public partial class pagecode_report_absence : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillddlYear();
        }

        public void FillddlYear()
        {
            ddlYearAbsence.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
            ddlYearAbsence.Items.Add(new ListItem(DateTime.Now.AddYears(-1).Year.ToString(), DateTime.Now.AddYears(-1).Year.ToString()));
        }

        protected void cmdReqReportAbsence_Click(object sender, EventArgs e)
        {
            reqReport(Session["nrp1"].ToString(), ddlYearAbsence.SelectedValue, ddlMonthAbsence.SelectedValue);
        }

        public void reqReport(string nrp1,string year1,string month1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/formnewuser/" + nrp1 + "/" + month1 + "/" + year1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.GetResponseAsync();

            //using (var response = webrequest.GetResponse())
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{

            //}

            cmdReqReportAbsence.Enabled = false;
            lblInfo.Text = "Report Absensi anda akan dikirimkan ke alamat E-Mail anda";
        }
    }
}