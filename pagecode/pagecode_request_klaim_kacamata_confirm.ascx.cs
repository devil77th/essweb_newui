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
    public partial class pagecode_request_klaim_kacamata_confirm : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                loadData1();
            }
        }

        void loadData1()
        {
            double frameamt1=0,lensaamt1=0,totalamt1=0;
            if (String.IsNullOrEmpty(Session["framename1_" + Session["nrp1"].ToString()].ToString()) == false)
            {
                lblFrame1.Text = Session["framename1_" + Session["nrp1"].ToString()].ToString();
            }

            if (String.IsNullOrEmpty(Session["lensaname1_" + Session["nrp1"].ToString()].ToString()) == false)
            {
                lblLensa1.Text = Session["lensaname1_" + Session["nrp1"].ToString()].ToString();
            }
            
            if (String.IsNullOrEmpty(Session["frameamount1_" + Session["nrp1"].ToString()].ToString()) == false)
            {
               frameamt1 = Convert.ToDouble(Session["frameamount1_" + Session["nrp1"].ToString()].ToString());
            }
            if (String.IsNullOrEmpty(Session["lensaamount1_" + Session["nrp1"].ToString()].ToString()) == false)
            {
                lensaamt1 = Convert.ToDouble(Session["lensaamount1_" + Session["nrp1"].ToString()].ToString());
            }
            
            totalamt1 = frameamt1 + lensaamt1;
            lblJumlahKlaim.Text = String.Format("{0:#,#}", totalamt1);
            lblFrameAmt1.Text = String.Format("{0:#,#}", frameamt1);
            lblLensaAmt1.Text = String.Format("{0:#,#}", lensaamt1);
            lblNamaPeserta.Text = Session["lblpeserta1_" + Session["nrp1"].ToString()].ToString();
            lblKeterangan1.Text = Session["txtketerangan1_" + Session["nrp1"].ToString()].ToString();
            //peserta1 = Session["peserta1_" + Session["nrp1"].ToString()].ToString();

        }

        protected void cmdSubmitClaimKM_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(lblFrame1.Text)==false)
            {
                addItemClaimKM1(Session["nrp1"].ToString(), DateTime.Today.ToString("dd-MMM-yyyy"), 
                    Session["peserta1_" + Session["nrp1"].ToString()].ToString(),
                    Session["framename1_" + Session["nrp1"].ToString()].ToString(), Session["frameamount1_" + Session["nrp1"].ToString()].ToString());

            }

            if (String.IsNullOrEmpty(lblLensa1.Text) == false)
            {
                addItemClaimKM1(Session["nrp1"].ToString(), DateTime.Today.ToString("dd-MMM-yyyy"),
                    Session["peserta1_" + Session["nrp1"].ToString()].ToString(),
                    Session["lensaname1_" + Session["nrp1"].ToString()].ToString(), Session["lensaamount1_" + Session["nrp1"].ToString()].ToString());

            }

            submitClaimKM1(Session["nrp1"].ToString(), 
                           Session["peserta1_" + Session["nrp1"].ToString()].ToString(), 
                           lblNamaPeserta.Text,
                           Session["lastclaimframe1_" + Session["nrp1"].ToString()].ToString(), 
                           Session["lastclaimlensa1_" + Session["nrp1"].ToString()].ToString(),
                           Session["frame1_" + Session["nrp1"].ToString()].ToString(), 
                           Session["frameamount1_" + Session["nrp1"].ToString()].ToString(),
                           Session["lensa1_" + Session["nrp1"].ToString()].ToString(), 
                           Session["lensaamount1_" + Session["nrp1"].ToString()].ToString(),
                           Session["txtketerangan1_" + Session["nrp1"].ToString()].ToString());
        }

        protected void cmdCancelClaimKM_Click(object sender, EventArgs e)
        {
            Session.Remove("peserta1_" + Session["nrp1"].ToString());
            Session.Remove("lblpeserta1_" + Session["nrp1"].ToString());
            Session.Remove("frame1_" + Session["nrp1"].ToString());
            Session.Remove("framename1_" + Session["nrp1"].ToString());
            Session.Remove("frameamount1_" + Session["nrp1"].ToString());
            Session.Remove("lensa1_" + Session["nrp1"].ToString());
            Session.Remove("lensaname1_" + Session["nrp1"].ToString());
            Session.Remove("lensaamount1_" + Session["nrp1"].ToString());
            Session.Remove("txtketerangan1_" + Session["nrp1"].ToString());
            Session.Remove("lastclaimframe1_" + Session["nrp1"].ToString());
            Session.Remove("lastclaimlensa1_" + Session["nrp1"].ToString());
            Response.Redirect("request_klaim_kacamata.aspx");
        }

        void submitClaimKM1(String parnrp1, String parclaimant1, string parclaimantname1, string parlastclaimframe1, 
                            string parlastclaimlensa1,string parframecode1,string parframeamt1,string parlensacode1,string parlensaamt1,
                            string ket1)
        {
            double frameamt1 = 0, lensaamt1 = 0, totalamt1 = 0;
            if (String.IsNullOrEmpty(Session["frameamount1_" + Session["nrp1"].ToString()].ToString()) == false)
            {
                frameamt1 = Convert.ToDouble(Session["frameamount1_" + Session["nrp1"].ToString()].ToString());
            }
            if (String.IsNullOrEmpty(Session["lensaamount1_" + Session["nrp1"].ToString()].ToString()) == false)
            {
                lensaamt1 = Convert.ToDouble(Session["lensaamount1_" + Session["nrp1"].ToString()].ToString());
            }
            totalamt1 = frameamt1 + lensaamt1;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/submitclaimkm";
            object input = new
            {
                nrp1 = parnrp1,
                claimant1 = parclaimant1,
                claimantname1 = parclaimantname1,
                lastclaimframe1 = parlastclaimframe1,
                lastclaimlensa1 = parlastclaimlensa1,
                framecode1 = parframecode1,
                frameamount1 = parframeamt1,
                lensacode1 = parlensacode1,
                lensaamount1 = parlensaamt1,
                totalamount1 = totalamt1,
                keterangan1 = ket1
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
                    var result1 = (new StreamReader(stream)).ReadToEnd();
                    string codeKlaim1 = Convert.ToString(result1);
                    var jsonConvResult1 = JsonConvert.DeserializeObject<CodeKlaimResult>(codeKlaim1);
                    mdlCO1.Show();
                    lblinfo1.Text = "Kode Klaim Kacamata/Lensa anda :";
                    lblcodeklaim1.Font.Bold = true;
                    lblcodeklaim1.Font.Size = 12;
                    lblcodeklaim1.Text = jsonConvResult1.submitClaimKM1Result.ToString();
                }
            }
        }

        public class CodeKlaimResult
        {
            public string submitClaimKM1Result { get; set; }
        }


        void addItemClaimKM1(String parnrp1, String pardateoforigin1, string parclaimant1, string parwagetype1, string paramount1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/additemclaimkm";
            object input = new
            {
                nrp1 = parnrp1,
                dateoforigin1 = pardateoforigin1,
                claimant1 = parclaimant1,
                wagetype1 = parwagetype1,
                amount1 = paramount1
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

        protected void cmdClosePanel1_Click(object sender, EventArgs e)
        {
            Session.Remove("peserta1_" + Session["nrp1"].ToString());
            Session.Remove("lblpeserta1_" + Session["nrp1"].ToString());
            Session.Remove("frame1_" + Session["nrp1"].ToString());
            Session.Remove("framename1_" + Session["nrp1"].ToString());
            Session.Remove("frameamount1_" + Session["nrp1"].ToString());
            Session.Remove("lensa1_" + Session["nrp1"].ToString());
            Session.Remove("lensaname1_" + Session["nrp1"].ToString());
            Session.Remove("lensaamount1_" + Session["nrp1"].ToString());
            Session.Remove("txtketerangan1_" + Session["nrp1"].ToString());
            Session.Remove("lastclaimframe1_" + Session["nrp1"].ToString());
            Session.Remove("lastclaimlensa1_" + Session["nrp1"].ToString());
            Response.Redirect("request_klaim_kacamata.aspx");
        }
    }
}