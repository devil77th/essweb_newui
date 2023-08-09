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
    public partial class pagecode_request_klaim_kacamata_detail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                LoadData1(Request["id1"].ToString());
            }
        }

        protected void cmdDelClaimKM_Click(object sender, EventArgs e)
        {
            delClaimKM(Request["id1"].ToString());
            Response.Redirect("request_klaim_kacamata.aspx");
        }

        void delClaimKM(String parid1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delclaimkm";
            object input = new
            {
                id1 = parid1
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
        }

        public void LoadData1(string idkm1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getclaimkm/" + idkm1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<getClaimKm1Result1>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                lblclaimant1.Text = result1.getClaimKmDetail1Result.claimant1.ToString() 
                                    + " - " + result1.getClaimKmDetail1Result.claimantname1.ToString();
                lbldateclaim1.Text = result1.getClaimKmDetail1Result.dateclaim1.ToString();

                if (string.IsNullOrEmpty(result1.getClaimKmDetail1Result.frameprice1.ToString()) == false)
                {
                    lblframedetail1.Text = result1.getClaimKmDetail1Result.framedesc1.ToString()
                                        + " - " + String.Format("{0:n0}", Double.Parse(result1.getClaimKmDetail1Result.frameprice1.ToString()));
                }

                if (string.IsNullOrEmpty(result1.getClaimKmDetail1Result.lensprice1.ToString()) == false)
                {
                    lbllensadetail1.Text = result1.getClaimKmDetail1Result.lensdesc1.ToString()
                                    + " - " + String.Format("{0:n0}", Double.Parse(result1.getClaimKmDetail1Result.lensprice1.ToString()));
                }


                lblStatus1.Text = result1.getClaimKmDetail1Result.statusclaim1.ToString();
                lblReject1.Text = result1.getClaimKmDetail1Result.reason1.ToString();
                lbldescclaim1.Text = result1.getClaimKmDetail1Result.descklaimkm1.ToString();
                hidMedTrx1.Value = result1.getClaimKmDetail1Result.id1.ToString();

                if(lblStatus1.Text == "Waiting for Approval")
                {
                    cmdDelClaimKM.Visible = true;
                }
                else
                {
                    cmdDelClaimKM.Visible = false;
                }


            }
        }

        public class getClaimKm1Result1
        {
            public dataClaimKM1 getClaimKmDetail1Result { get; set; }
        }

        public class dataClaimKM1
        {
            public string id1 { get; set; }
            public string kodeklaim1 { get; set; }
            public string statusclaim1 { get; set; }
            public string claimant1 { get; set; }
            public string claimantname1 { get; set; }
            public string dateclaim1 { get; set; }
            public string framedesc1 { get; set; }
            public string frameprice1 { get; set; }
            public string lensdesc1 { get; set; }
            public string lensprice1 { get; set; }
            public string reason1 { get; set; }
            public string descklaimkm1 { get; set; }
        }


    }
}