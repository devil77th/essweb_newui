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
    public partial class pagecode_request_cico_wfh_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                LoadData1(Request["trx1"].ToString());
            }
        }

        protected void cmdDeleteCICOWFHTrx1_Click(object sender, EventArgs e)
        {
            delCICOWFH(Request["trx1"].ToString());
            Response.Redirect("request_cico_wfh_list.aspx");
        }

        void delCICOWFH(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delcicowfh/" + idtrx1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        public void LoadData1(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstcicowfhdetail/" + idtrx1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<dataclass1.lstCICOWFHDetailResult1>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                lblTipe1.Text = result1.listCICOWFHDetail1Result.type1.ToString();
                lblStatus1.Text = result1.listCICOWFHDetail1Result.approvalstatus1.ToString(); 
                lblTime1.Text = result1.listCICOWFHDetail1Result.time1.ToString();
                lblTipeSubmit1.Text = result1.listCICOWFHDetail1Result.submittype1.ToString();
            }
            if(lblStatus1.Text== "Waiting for Approval")
            {
                cmdDeleteCICOWFHTrx1.Visible = true;
            }
            else 
            { 
                cmdDeleteCICOWFHTrx1.Visible = false;   
            }
            
        }
    }
}