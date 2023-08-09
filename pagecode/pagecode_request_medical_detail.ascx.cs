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
    public partial class pagecode_request_medical_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idmedtrx = Request["trx1"];
            if(Page.IsPostBack==false)
            {
                LoadData1(idmedtrx);
                if(lblStatus1.Text=="Waiting for Approval")
                {
                    cmdDeleteMedTrx1.Visible = true;
                }
                else
                {
                    cmdDeleteMedTrx1.Visible = false;
                }

                if(String.IsNullOrEmpty(hidAppRejDa1.Value)==false)
                {
                    cmdDeleteMedTrx1.Visible = false;
                }
                else
                {
                    cmdDeleteMedTrx1.Visible = true;
                }

            }
        }

        public void LoadData1(string idmedtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmeddetail/" + idmedtrx1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetDataTrxMedResult1>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                lblDiagnosa1.Text = result1.GetListTrxMedDetailResult[0].diagnosa.ToString();
                lblJumlah1.Text = String.Format("{0:n0}", Double.Parse(result1.GetListTrxMedDetailResult[0].amount.ToString()));
                lblKuiDa1.Text = result1.GetListTrxMedDetailResult[0].receiptdate.ToString();
                lblPasien1.Text = result1.GetListTrxMedDetailResult[0].namapasien.ToString();
                lblReject1.Text = result1.GetListTrxMedDetailResult[0].reason1.ToString();
                string apprejda1 = result1.GetListTrxMedDetailResult[0].tglapproval1.ToString();
                string statusapp1 = result1.GetListTrxMedDetailResult[0].statusapproval.ToString();
                hidAppRejDa1.Value = apprejda1;
                if(statusapp1=="WFSTS_01")
                {
                    lblStatus1.Text = "Waiting for Approval";
                }
                else if(statusapp1=="WFSTS_02")
                {
                    lblStatus1.Text = "Approved";
                }
                else if(statusapp1 == "WFSTS_03")
                {
                    lblStatus1.Text = "Rejected";
                }
            }
        }

        protected void cmdDeleteMedTrx1_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delmedtrx/" + Request["trx1"];
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                
            }

            popUpMsgBox("Request Klaim Rawat Jalan dihapus");
        }

        public class GetDataTrxMedResult1
        {
            public List<trxMed> GetListTrxMedDetailResult { get; set; }
        }

        public class trxMed
        {
            public string namapasien { get; set; }
            public string diagnosa { get; set; }
            public string idtrx { get; set; }
            public string receiptdate { get; set; }
            public string amount { get; set; }
            public string statusapproval { get; set; }
            public string reason1 { get; set; }
            public string tglapproval1 { get; set; }
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='request_medical_list.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }
    }
}