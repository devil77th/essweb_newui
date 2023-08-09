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
    public partial class pagecode_request_absence_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                loadData(Request["trx1"].ToString());
            }
        }

        void loadData(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstabsdetail/" + idtrx1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<dataclass1.listReqAbsDetailResult1>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                lblTipe1.Text = result1.listAbsDetail1Result.absname1.ToString();
                lblStatus1.Text = result1.listAbsDetail1Result.status1.ToString();
                lblTglAbsence1.Text = result1.listAbsDetail1Result.begda1.ToString() + " - " + result1.listAbsDetail1Result.endda1.ToString();
                lblCreda1.Text = result1.listAbsDetail1Result.creda1.ToString();
            }
            if (lblStatus1.Text == "Waiting for Approval")
            {
                cmdDeleteAbsTrx1.Visible = true;
            }
            else
            {
                cmdDeleteAbsTrx1.Visible = false;
            }
        }

        protected void cmdDeleteAbsTrx1_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delreqabs/" + Request["trx1"].ToString();
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
            Response.Redirect("request_absence_list.aspx");
        }
    }
}