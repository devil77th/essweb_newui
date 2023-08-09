using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_approval_medical_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                LoadDataKlaim(Request["id1"].ToString());
            }
        }

        void LoadDataKlaim(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmeddetail/" + idtrx1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetDataTrxMedResult1>(jsonstr);
                hidMedTrx1.Value  = result1.GetListTrxMedDetailResult[0].idtrx.ToString();
                lblDiagnosa1.Text = result1.GetListTrxMedDetailResult[0].diagnosa.ToString();
                lblJumlah1.Text = String.Format("{0:n0}", Double.Parse(result1.GetListTrxMedDetailResult[0].amount.ToString()));
                lblKuiDa1.Text = result1.GetListTrxMedDetailResult[0].receiptdate.ToString();
                lblPasien1.Text = result1.GetListTrxMedDetailResult[0].namapasien.ToString();
                string apprejda1 = result1.GetListTrxMedDetailResult[0].tglapproval1.ToString();
                string statusapp1 = result1.GetListTrxMedDetailResult[0].statusapproval.ToString();
                string apprejda2 = result1.GetListTrxMedDetailResult[0].tglapproval2.ToString();
                lblRequester.Text = result1.GetListTrxMedDetailResult[0].fullname.ToString();
                hidAppRejDa1.Value = apprejda1;
                hidAppRejDa2.Value = apprejda2;
                hidStepID1.Value = result1.GetListTrxMedDetailResult[0].step1.ToString();
            }
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
            public string tglapproval2 { get; set; }
            public string fullname { get; set; }
            public string step1 { get; set; }
        }

        void popUpMsgBox_Redirect(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='approval_medical.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }


        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            string stepid1 = hidStepID1.Value,status1=ddlStatus.SelectedValue;
            Boolean flg1 = false;

            if (ddlStatus.SelectedValue != "")
            {

                if (stepid1 == "1" && string.IsNullOrEmpty(hidAppRejDa1.Value) == true)
                {
                    flg1 = true;
                }
                else if (stepid1 == "1" && string.IsNullOrEmpty(hidAppRejDa1.Value) == false)
                {
                    flg1 = false;
                }

                if (stepid1 == "2" && string.IsNullOrEmpty(hidAppRejDa1.Value) == false)
                {
                    flg1 = true;
                }
                else if (stepid1 == "2" && string.IsNullOrEmpty(hidAppRejDa1.Value) == true)
                {
                    flg1 = false;
                }

                if (flg1 == true)
                {
                    var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/appmedtrx_post";
                    object input = new
                    {
                        refcodemed = Request["id1"].ToString(),
                        stepid = stepid1,
                        nrp = Session["nrp1"].ToString(),
                        status = status1,
                        reasonRej = txtReject.Text.Trim(),
                    };

                    string inputJson = JsonConvert.SerializeObject(input);

                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    httpRequest.Accept = "application/json";
                    httpRequest.ContentType = "application/json";
                    httpRequest.Method = "POST";

                    byte[] bytes = Encoding.UTF8.GetBytes(inputJson);

                    using (Stream stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Close();
                    }

                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                    {
                        using (Stream stream = httpResponse.GetResponseStream())
                        {
                            //hidID1.Value = (new StreamReader(stream)).ReadToEnd();
                        }
                    }

                    popUpMsgBox_Redirect("Data Submitted");
                }
                else
                {
                    popUpMsgBox("Step approval tidak sesuai");
                }
            }
            else
            {
                popUpMsgBox("Anda belum memilih status klaim ini");
            }
        }

    }
}