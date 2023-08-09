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
    public partial class pagecode_request_medical_confirm : System.Web.UI.UserControl
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
            lblKuida.Text = Session["datekuida1_" + Session["nrp1"].ToString()].ToString();
            lblDiagnosa.Text =  Session["diagnosa1_" + Session["nrp1"].ToString()].ToString();
            string amt1 = Session["amount1_" + Session["nrp1"].ToString()].ToString();
            lblJumlahKlaim.Text = String.Format("{0:#,#}", Convert.ToDouble(amt1));
            lblNamaPasien.Text = Session["namapasien1_" + Session["nrp1"].ToString()].ToString();
        }

        protected void cmdSubmitMedical_Click(object sender, EventArgs e)
        {
            SubmitDataMedical(Session["nrp1"].ToString(), DateTime.Now.Year.ToString(), lblJumlahKlaim.Text.Replace(",",""), lblKuida.Text,
                lblDiagnosa.Text, lblNamaPasien.Text);
        }

        void SubmitDataMedical(String parnrp1,string paryear1,string paramount1,string parkuida1,string pardiag1,string parnamapasien1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/savetrxmed1";
            object input = new
            {
                nrp1 = parnrp1,
                year1 = paryear1,
                amount1 = paramount1,
                kuida1 = parkuida1,
                diagnosa1 = pardiag1,
                namapasien1 = parnamapasien1
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
                    lblinfo1.Text = "Kode Klaim Rawat Jalan anda :";
                    lblcodeklaim1.Font.Bold = true;
                    lblcodeklaim1.Font.Size = 12;
                    lblcodeklaim1.Text = jsonConvResult1.saveTrxMedResult.ToString();
                }
            }
        }

        protected void cmdCancelMedical_Click(object sender, EventArgs e)
        {
            Session.Remove("datekuida1_" + Session["nrp1"].ToString());
            Session.Remove("diagnosa1_" + Session["nrp1"].ToString());
            Session.Remove("amount1_" + Session["nrp1"].ToString());
            Session.Remove("namapasien1_" + Session["nrp1"].ToString());
            Response.Redirect("request_medical_list.aspx");
        }

        public class CodeKlaimResult
        {
            public string saveTrxMedResult { get; set; }
        }

        protected void cmdClosePanel1_Click(object sender, EventArgs e)
        {
            Session.Remove("datekuida1_" + Session["nrp1"].ToString());
            Session.Remove("diagnosa1_" + Session["nrp1"].ToString());
            Session.Remove("amount1_" + Session["nrp1"].ToString());
            Session.Remove("namapasien1_" + Session["nrp1"].ToString());
            Response.Redirect("request_medical_list.aspx");
        }
    }
}