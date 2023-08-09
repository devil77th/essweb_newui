using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.class1;

namespace WebApplication1.pagecode
{
    public partial class pagecode_trxresign : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                loadData(Session["nrp1"].ToString());
                cekTrxResign1(Session["nrp1"].ToString());
              
            }
        }

        void loadData(string nrp1)
        {

            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getempprofile/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.empProfileResult2>(jsonstr);

                if (String.IsNullOrEmpty(result1.getempprofile3Result.nrp1) == false)
                {
                    lblNRP1.Text = result1.getempprofile3Result.nrp1.ToString();
                    lblJoinDate1.Text = result1.getempprofile3Result.joinDate1.ToString();
                    lblNama1.Text = result1.getempprofile3Result.fullname1.ToString();
                    lblPosisi1.Text = result1.getempprofile3Result.posName1.ToString();
                    lblStatus1.Text = result1.getempprofile3Result.status1.ToString();

                }
            }
        }

        void cekTrxResign1(string nrp1)
        {

            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/cektrxresign/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.trxResign1>(jsonstr);

                if (String.IsNullOrEmpty(result1.cektrxResign1Result.nrp1) == false)
                {
                    txtDateResign1.Text = result1.cektrxResign1Result.resigndt1.ToString();
                    hidID1.Value = result1.cektrxResign1Result.id1.ToString();
                    
                    if(result1.cektrxResign1Result.ishrdconfirm1.ToString() == "False")
                    {
                        lblHRConfirm.Text = "Not Confirmed";
                    }
                    else
                    {
                        lblHRConfirm.Text = "Confirmed";
                    }
                    
                    upd_hidid1.Update();
                    if(string.IsNullOrEmpty(result1.cektrxResign1Result.iskaryconfirm1.ToString()) == false)
                    {
                        if(result1.cektrxResign1Result.iskaryconfirm1.ToString() == "True")
                        {
                            txtDateResign1.Enabled = false;
                        }
                        else
                        {
                            txtDateResign1.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        txtDateResign1.Enabled =true;   
                    }
                    
                }
            }
        }

        protected void cmdNext_Click(object sender, EventArgs e)
        {
            string cf1 = "";
            if(txtDateResign1.Enabled==false)
            {
                cf1 = function1.Base64Encode("1");
            }
            else
            {
                cf1 = function1.Base64Encode("0");
            }

            if (function1.datediff1(DateTime.Now, Convert.ToDateTime(txtDateResign1.Text)) < 30)
            {
                function1.popUpMsgBox("Tanggal resign minimal 30 hari ke depan dari hari ini", this.Page, this);
            }
            else
            {
                if (string.IsNullOrEmpty(hidID1.Value) == false)
                {
                    Response.Redirect("trxresign2.aspx?idr=" + hidID1.Value.ToString()
                        + "&dt1=" + function1.Base64Encode(txtDateResign1.Text) + "&cf1=" + cf1);
                    //Session.Add("trxResignID1", hidID1.Value);
                }
                else
                {
                    SaveTrxResignHeader(lblNRP1.Text, lblNama1.Text, lblJoinDate1.Text, lblPosisi1.Text, lblStatus1.Text, txtDateResign1.Text.Trim(),
                        Session["username1"].ToString());
                    Response.Redirect("trxresign2.aspx?idr=" + hidID1.Value.ToString()
                        + "&dt1=" + function1.Base64Encode(txtDateResign1.Text) + "&cf1=" + cf1);
                    //Session.Add("trxResignID1", Guid.NewGuid().ToString());
                }
            }

        }

        public string SaveTrxResignHeader(string parnrp1,string parnama1,string parjoindate1,string parpos1,string parcontracttype1,
            string parresigndt1,string parusername1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/savetrxresign";
            object input = new
            {
                nrp1 = parnrp1,
                nama1 = parnama1,
                joindate1 = parjoindate1,
                pos1 = parpos1,
                contracttype1 = parcontracttype1,
                resigndt1 = parresigndt1,
                username1 = parusername1
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
                    hidID1.Value = (new StreamReader(stream)).ReadToEnd();
                }
            }
            return hidID1.Value;
        }

        
    }
}