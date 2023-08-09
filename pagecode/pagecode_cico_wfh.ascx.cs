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
    public partial class pagecode_cico_wfh : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
            Boolean flg1;
            string datetimeServ1;
            string empLocation1;
            if (Page.IsPostBack == false)
            {
                cmdRedir.Visible = false;
                string nrp1 = Session["nrp1"].ToString();
                datetimeServ1 = getDateFromServ();
                empLocation1 = getEmpLocation(nrp1);

                if(empLocation1=="WITA")
                {
                    datetimeServ1 = Convert.ToDateTime(datetimeServ1).AddHours(1).ToString();
                }

                if (empLocation1 == "WIT")
                {
                    datetimeServ1 = Convert.ToDateTime(datetimeServ1).AddHours(2).ToString();
                }

                lblTimeServer.Text = Convert.ToDateTime(datetimeServ1).ToString("dd-MMM-yyyy HH:mm:ss") + " - " + empLocation1;
                lblLastActivity.Text = getLastActCicoF1(nrp1);
                //flg1 = fgValid(nrp1);
                flg1 = true;
                if (flg1 == false)
                {
                    cmdClockIn.Visible = false;
                    cmdClockOut.Visible = false;
                }
                else
                {
                    cmdClockIn.Visible = true;
                    cmdClockOut.Visible = true;
                    //nextAct();
                }

                //Boolean wsFlg = cekWS(nrp1, DateTime.Now.ToString("dd-MMM-yyyy"));
                Boolean wsFlg = true;
                if(wsFlg==false)
                {
                    cmdClockIn.Visible = false;
                    cmdClockOut.Visible = false;
                    lblStatus.Text = "Jadwal kerja anda hari ini adalah : WFO";
                }
                
            }
        }

        public string getDateFromServ()
        {
            string dateserv1 = "",dateserv2="";
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
                //if (dateserv1.Contains(".") == true)
                //{
                //    dateserv2 = dateserv1.Replace(".", ":").ToString();
                //}
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
            }
            return dateserv1;
        }

        public string getEmpLocation(string nrp1)
        {
            string empLocation1 = "";
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/checkemploc/" + nrp1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<empLocation>(jsonstr);
                empLocation1 = result1.CheckEmployeeLocation1Result.ToString();
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
            }
            return empLocation1;
        }

        public string getLastActCicoF1(string nrp1)
        {
            string lastAct1 = "";
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getlastactcicowfh/" + nrp1;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
               
                var result1 = JsonConvert.DeserializeObject<GetLastActCICO1>(jsonstr);
                if (result1.GetLastActCICOWFHResult[0].idtrx1.ToString() != "")
                {
                    lastAct1 = result1.GetLastActCICOWFHResult[0].actwfh1.ToString() + " - "
                        + result1.GetLastActCICOWFHResult[0].timecicowfh1.ToString();
                    //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                    hidLastAct1.Value = result1.GetLastActCICOWFHResult[0].actwfh1.ToString();
                    hidLastActTime1.Value = result1.GetLastActCICOWFHResult[0].timecicowfh1.ToString();
                }
                else
                {
                    lastAct1 = "-";
                }


            }
            return lastAct1;
        }

        static Boolean submitCICOWFH(string nrp1, string date1, string time1, string type1)
        {
            Boolean flg1;
            flg1 = true;

            date1 = date1.Replace("-", "_");
            time1 = time1.Replace(":", "");
            time1 = time1.Substring(0, 4);

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cicowfh/" + nrp1 + "/" + date1 + "/"
                + time1 + "/" + type1;

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
            sb.Append("');window.location='cico_wfh.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }


        public class empLocation
        {
            public string CheckEmployeeLocation1Result { get; set; }
        }

        public class dateServJson
        {
            public string GetDateFromServerResult { get; set; }
        }

        public class GetLastActCICO1
        {
            public List<LastActCico1> GetLastActCICOWFHResult { get; set; }
        }

        public class LastActCico1
        {
            public string actwfh1 { get; set; }
            public string timecicowfh1 { get; set; }
            public string idtrx1 { get; set; }
        }

        protected void cmdRefreshTimeServer_Click(object sender, EventArgs e)
        {
            string datetimeServ1;
            string empLocation1;
            string nrp1 = Session["nrp1"].ToString();
            datetimeServ1 = getDateFromServ();
            empLocation1 = getEmpLocation(nrp1);

            if (empLocation1 == "WITA")
            {
                datetimeServ1 = Convert.ToDateTime(datetimeServ1).AddHours(1).ToString();
            }

            if (empLocation1 == "WIT")
            {
                datetimeServ1 = Convert.ToDateTime(datetimeServ1).AddHours(2).ToString();
            }

            lblTimeServer.Text = Convert.ToDateTime(datetimeServ1).ToString("dd-MMM-yyyy HH:mm:ss") + " - " + empLocation1;
            
            //lblTimeServer.Text = getDateFromServ();
        }

        protected void cmdClockIn_Click(object sender, EventArgs e)
        {
            Boolean flgValidCICO=false;
            if (string.IsNullOrEmpty(Session["nrp1"].ToString()) == false)
            {
                string[] datetime1 = lblTimeServer.Text.Split(' ');
                string date1 = datetime1[0].ToString();
                string time1 = datetime1[1].ToString();
                flgValidCICO = cekSubmitCICO2((string)Session["nrp1"], date1, "TRXCC_01");
                if (flgValidCICO == true)
                {
                    popUpMsgBox("Sudah ada transaksi Clock In WFH hari ini");
                }
                else
                {
                    submitCICOWFH(Session["nrp1"].ToString(), date1, time1, "TRXCC_01");
                    popUpMsgBox("Clock In berhasil");
                }
            }
        }

        protected void cmdClockOut_Click(object sender, EventArgs e)
        {
            Boolean flgValidCICO,flgValidCICO2;
            if (string.IsNullOrEmpty(Session["nrp1"].ToString()) == false)
            {
                string[] datetime1 = lblTimeServer.Text.Split(' ');
               
                string date1 = datetime1[0].ToString();
                string time1 = datetime1[1].ToString();
                //flgValidCICO = cekSubmitCICO((string)Session["nrp1"], date1 + " " + time1 , hidLastActTime1.Value, "TRXCC_02");
                flgValidCICO = true;
                flgValidCICO2 = cekWFH((string)Session["nrp1"], date1, "TRXCC_02");
                //flgValidCICO3 = cekWFH((string)Session["nrp1"], date1, "TRXCC_02");

                if (flgValidCICO == false)
                {
                    popUpMsgBox("Anda tidak bisa melakukan Clock Out Actual karena sudah melewati hari dari Clock In Terakhir anda. " +
                        "Silahkan melakukan Request Clock Out.");
                }
                else
                {
                    if (flgValidCICO2 == false)
                    {
                        lblinfo1.Text = "Anda sudah melakukan Clock Out hari ini pada jam : " + hidTimeCICO1.Value 
                            + ". Apakah anda mau melakukan Clock Out ulang?";
                        mdlCO1.Show();
                    }
                    else
                    {
                        submitCICOWFH(Session["nrp1"].ToString(), date1, time1, "TRXCC_02");
                        popUpMsgBox("Clock Out berhasil");
                    }
                }
            }
        }

        public void nextAct()
        {
            if (lblLastActivity.Text.Contains("Clock In"))
            {
                cmdClockIn.Visible = false;
                cmdClockOut.Visible = true;
            }
            else if (lblLastActivity.Text.Contains("Clock Out"))
            {
                cmdClockIn.Visible = true;
                cmdClockOut.Visible = false;
            }
        }

        static Boolean cekSubmitCICO2(string nrp1, string date1, string type1)
        {
            Boolean flg1;
            flg1 = true;
            date1 = date1.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekcicowfh/" + nrp1 + "/" + date1 + "/" + type1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<strJson>(jsonstr);
                flg1 = Convert.ToBoolean(result1.cekCicoWFHResult);
            }
            return flg1;
        }

        static Boolean cekSubmitCICO(string nrp1, string date1,string date2, string type1)
        {
            Boolean flg1 = true;
            if(Convert.ToDateTime(date1).Date != Convert.ToDateTime(date2).Date)
            {
                flg1 = false;
            }
            return flg1;
        }

        public class strJson
        {
            public string cekCicoWFHResult;
        }

        static Boolean cekWS(string nrp1, string date1)
        {
            Boolean flg1;
            string status1 = "";
            flg1 = true;
            date1 = date1.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getworksched_date/" + nrp1 + "/" + date1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listreportschedule>(jsonstr);

                for (int i = 0; i <= result1.GetWorkSchedule_DateResult.Count - 1; i++)
                {
                    status1 = result1.GetWorkSchedule_DateResult[i].status1;
                }

                if (status1 == "WFO")
                {
                    flg1 = false;
                }
            }
            return flg1;
        }

        public Boolean cekWFH(string nrp1, string date1,string type1)
        {
            Boolean flg1;
            //string status1 = "";
            flg1 = true;
            //date1 = date1.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekcicowfh3/" + nrp1 + "/" + date1 + "/" + type1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listCekCICOWFH3>(jsonstr);

                if(string.IsNullOrEmpty(result1.cekCicoWFH3Result.idtrx1)==false)
                {
                    flg1 = false;
                    hidTimeCICO1.Value = result1.cekCicoWFH3Result.clockCICO1.ToString();
                    hididTrxCICO1.Value = result1.cekCicoWFH3Result.idtrx1.ToString();
                }
                else
                {
                    flg1 = true;
                }
                
            }
            return flg1;
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

        public class listreportschedule
        {
            public List<reportschedule> GetWorkSchedule_DateResult { get; set; }
        }

        public class reportschedule
        {
            public string ciwfh1 { get; set; }
            public string ciwfo1 { get; set; }
            public string cowfh1 { get; set; }
            public string cowfo1 { get; set; }
            public string hari1 { get; set; }
            public string liburwfo1 { get; set; }
            public string tgl1 { get; set; }
            public string status1 { get; set; }

        }

        public class listCekCICOWFH3
        {
            public cekCicoWFH3 cekCicoWFH3Result { get; set; }
        }

        public class cekCicoWFH3
        {
            public string clockCICO1 { get; set; }
            public string dateCICO1 { get; set; }
            public string fullname1 { get; set; }
            public string idtrx1 { get; set; }
            public string typeCICO1 { get; set; }
        }

        protected void cmdOverwrite1_Click(object sender, EventArgs e)
        {
            string[] datetime1 = lblTimeServer.Text.Split(' ');
            string date1 = datetime1[0].ToString();
            string time1 = datetime1[1].ToString();
            cmdOverwrite1.Visible = false;
            cmdOverwrite2.Visible = false;
            delCICOWFH(hididTrxCICO1.Value);
            submitCICOWFH(Session["nrp1"].ToString(), date1, time1, "TRXCC_02");
            //mdlCO1.Hide();
            lblinfo1.Text = "Overwrite Clock Out berhasil";
            cmdRedir.Visible = true;
            
        }

        protected void cmdRedir_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_menu_wfh.aspx");
        }
    }
}