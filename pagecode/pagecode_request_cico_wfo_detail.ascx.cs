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
    public partial class pagecode_request_cico_wfo_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                LoadData1(Request["trx1"].ToString());
            }
        }

        

        public void LoadData1(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstcicowfodetail/" + idtrx1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<dataclass1.lstCICOWFODetailResult1>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                lblTipe1.Text = result1.listCICOWFODetail1Result.type1.ToString();
                lblStatus1.Text = result1.listCICOWFODetail1Result.approvalstatus1.ToString();
                lblTime1.Text = result1.listCICOWFODetail1Result.time1.ToString();
                lblTipeSubmit1.Text = result1.listCICOWFODetail1Result.submittype1.ToString();
            }
            if (lblStatus1.Text == "Waiting for Approval")
            {
                cmdDeleteCICOWFOTrx1.Visible = true;
            }
            else
            {
                cmdDeleteCICOWFOTrx1.Visible = false;
            }

        }

        void delCICOWFO(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delcicowfo/" + idtrx1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        protected void cmdDeleteCICOWFOTrx1_Click(object sender, EventArgs e)
        {
            delCICOWFO(Request["trx1"].ToString());
            Response.Redirect("request_cico_wfo_list.aspx");
        }
    }
}