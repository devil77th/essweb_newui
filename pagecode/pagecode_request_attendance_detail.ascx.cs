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
using WebApplication1.class1;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_attendance_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                loadData(Request["trx1"].ToString());
            }
        }

        void loadData(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstattdetail/" + idtrx1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<dataclass1.lstReqAttDetail>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                lblTipe1.Text = result1.listAttDetail1Result.attname1.ToString();
                lblStatus1.Text = result1.listAttDetail1Result.status1.ToString();
                lblTglAtt1.Text = result1.listAttDetail1Result.begda1.ToString() + " - " + result1.listAttDetail1Result.endda1.ToString();
                if (String.IsNullOrEmpty(result1.listAttDetail1Result.creda1) == false)
                {
                    lblCreda1.Text = result1.listAttDetail1Result.creda1.ToString();
                }
                else
                {
                    lblCreda1.Text = "";
                }
            }
            if (lblStatus1.Text == "Waiting Approval")
            {
                cmdDeleteAttTrx1.Visible = true;
            }
            else
            {
                cmdDeleteAttTrx1.Visible = false;
            }
        }

        protected void cmdDeleteAttTrx1_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delreqatt/" + Request["trx1"].ToString();
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
            Response.Redirect("request_attendance_list.aspx");
        }
    }
}