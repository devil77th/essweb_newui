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
    public partial class pagecode_cico_fg : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean flg1;
            
            if(Page.IsPostBack==false)
            {
                string nrp1 = Session["nrp1"].ToString();
                //string nrp1 = "1138";
                lblTimeServer.Text = getDateFromServ();
                lblLastActivity.Text = getLastActCicoF1(nrp1);
                //flg1 = fgValid(nrp1);
                flg1 = true;
                if(flg1==false)
                {
                    cmdClockIn.Visible = false;
                    cmdClockOut.Visible = false;
                }
                else
                {
                    cmdClockIn.Visible= true;
                    cmdClockOut.Visible = true;
                    nextAct();
                }
            }
        }


        protected void cmdRefreshTimeServer_Click(object sender, EventArgs e)
        {
            lblTimeServer.Text = getDateFromServ();
        }

        protected void cmdClockIn_Click(object sender, EventArgs e)
        {
            Boolean flg1;
            if (string.IsNullOrEmpty(hidlat1.Value) == false || String.IsNullOrEmpty(hidlon1.Value)==false )
            {
                if (string.IsNullOrEmpty(Session["nrp1"].ToString()) == false)
                {
                    string[] datetime1 = lblTimeServer.Text.Split(' ');
                    string date1 = datetime1[0].ToString();
                    string time1 = datetime1[1].ToString();
                    //flg1 = cekDiffDate(date1, DateTime.Now.ToString());
                    submitCICOfg(Session["nrp1"].ToString(), date1, time1, "TRXCC_01", hidlat1.Value, hidlon1.Value);
                    popUpMsgBox("Clock In berhasil");
                }
            }
            else
            {
                popUpMsgBox2("Lokasi anda belum didapatkan");
            }
        }

        protected void cmdClockOut_Click(object sender, EventArgs e)
        {
            Boolean flg1;
            if (string.IsNullOrEmpty(hidlat1.Value) == false || String.IsNullOrEmpty(hidlon1.Value)== false)
            {
                if (string.IsNullOrEmpty(Session["nrp1"].ToString()) == false)
                {
                    string[] datetime1 = lblTimeServer.Text.Split(' ');
                    string date1 = datetime1[0].ToString();
                    string time1 = datetime1[1].ToString();
                    flg1 = cekDiffDate(hidLastActTime1.Value, date1 + " " + time1);
                    if (flg1 == true)
                    {
                        submitCICOfg(Session["nrp1"].ToString(), date1, time1, "TRXCC_02", hidlat1.Value, hidlon1.Value);
                        popUpMsgBox("Clock Out berhasil");
                    }
                    else
                    {
                        popUpMsgBox2("Anda tidak bisa melakukan Clock Out Actual karena sudah melewati hari dari Clock In Terakhir anda. " +
                        "Silahkan melakukan Request Clock Out");
                    }
                }
            }
            else
            {
                popUpMsgBox2("Lokasi anda belum didapatkan");
            }

        }

        public void nextAct()
        {
            if(lblLastActivity.Text.Contains("Clock In"))
            {
                cmdClockIn.Visible = false;
                cmdClockOut.Visible = true;
            }
            else if(lblLastActivity.Text.Contains("Clock Out"))
            {
                cmdClockIn.Visible = true;
                cmdClockOut.Visible = false;
            }
        }

        

        public string getDateFromServ()
        {
            string dateserv1="";
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/dateserv";
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<dateServJson>(jsonstr);
                dateserv1 = result1.GetDateFromServerResult.ToString();
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
            }
            return dateserv1;
        }

        public string getLastActCicoF1(string nrp1)
        {
            string lastAct1 = "";
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getlastactcico/" + nrp1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetLastActCICO1>(jsonstr);
                lastAct1 = result1.GetLastActCICOResult[0].act1.ToString() + " - "
                    + result1.GetLastActCICOResult[0].datecico1.ToString();
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                hidLastAct1.Value = result1.GetLastActCICOResult[0].act1.ToString();
                hidLastActTime1.Value = result1.GetLastActCICOResult[0].datecico1.ToString();
            }
            return lastAct1;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        static Boolean submitCICOfg(string nrp1, string date1, string time1, string type1,string lat1,string lon1)
        {
            Boolean flg1;
            flg1 = true;
            date1 = date1.Replace("-", "_");
            time1 = time1.Replace(":", "");
            time1 = time1.Substring(0, 4);
            lat1 = Base64Encode(lat1);
            lon1 = Base64Encode(lon1);
            
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subcicofg/" + nrp1 + "/" + date1 + "/"
                + time1 + "/" + type1 + "/" + lat1 + "/" + lon1 ;

            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
            return flg1;
        }


        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='request_menu.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        void popUpMsgBox2(string msg1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg1 +"')", true);
        }

        public Boolean fgValid(string nrp1)
        {
            Boolean fgvalid1 = false;
            string tempResult="";
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/fgvalid/" + nrp1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<validFG1>(jsonstr);
                tempResult = result1.fgValidResult[0].ToString();
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                if(tempResult=="t")
                {
                    fgvalid1 = true;
                }
                else
                {
                    fgvalid1 = false;
                }
            }
            return fgvalid1;
        }

        static Boolean cekDiffDate(string date1, string date2)
        {
            Boolean flg1 = true;
            if (Convert.ToDateTime(date1).Date != Convert.ToDateTime(date2).Date)
            {
                flg1 = false;
            }
            return flg1;
        }

        public class validFG1
        {
            public string fgValidResult { get; set; }
        }


        public class dateServJson
        {
            public string GetDateFromServerResult { get; set; }
        }

        public class GetLastActCICO1
        {
            public List<LastActCico1> GetLastActCICOResult { get; set; }
        }
        
        public class LastActCico1
        {
            public string act1 { get; set; }
            public string datecico1 { get; set; }
            public string idtrx1 { get; set; }
        }

       
    }
}