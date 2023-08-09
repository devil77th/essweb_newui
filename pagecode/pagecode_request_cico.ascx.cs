using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_cico : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool IsValidTime(string thetime)
        {
            Regex checktime =
             new Regex(@"^(([0-1][0-9])|([2][0-3])):([0-5][0-9])");

            return checktime.IsMatch(thetime);
        }

        public static Boolean getValidCICO(string date1,string hour1)
        {
            Boolean flg1 = false;
            date1 = date1.Replace("-", "_");
            hour1 = hour1.Replace(":", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/validdatecico/" + date1 + "/" + hour1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<dateNow1>(jsonstr);
                flg1 = Convert.ToBoolean(result1.validDateforCICOResult);
            }

            return flg1;
        }

        protected void cmdSubmitCICO_Click(object sender, EventArgs e)
        {
            Boolean flgTime = IsValidTime(txtTimeCICO.Text.Trim());
            Boolean flgValidCICO,statusws;
            if (flgTime == false)
            {
                popUpMsgBox("Format jam yang anda masukkan salah");
            }
            else
            {
                if (txtDateCICO.Text.Trim() == null || txtDateCICO.Text.Trim() == ""
                    || txtTimeCICO.Text.Trim() == null || txtTimeCICO.Text.Trim() == "")
                {
                    popUpMsgBox("Field Tanggal / Jam harus diisi");
                }
                else
                {
                    flgValidCICO = DateTime.TryParse(txtDateCICO.Text.Trim() + " " + txtTimeCICO.Text.Trim(), out DateTime result1);
                    if (flgValidCICO == false)
                    {
                        popUpMsgBox("Tolong cek lagi data yang anda entry");

                    }
                    else
                    {
                        Boolean flg1 = getValidCICO(txtDateCICO.Text.Trim(),txtTimeCICO.Text.Trim());

                        if (flg1 == false)
                        {
                            popUpMsgBox("Anda tidak bisa melakukan request yang melebihi jam sekarang / tanggal hari ini");
                        }
                        else
                        {
                            flgValidCICO = cekSubmitCICO((string)Session["nrp1"], txtDateCICO.Text.Trim(), ddlTypeCICO.SelectedValue);
                            if (flgValidCICO == true)
                            {
                                popUpMsgBox("Sudah ada transaksi CI-CO WFO-WFH/Absence/Attendance pada tanggal yang dimasukkan " +
                                    "atau sudah melewati tanggal Cut Off Request yang sudah ditentukan oleh HRD");
                            }
                            else
                            {
                                //statusws = cekWS((string)Session["nrp1"], txtDateCICO.Text.Trim());
                                statusws = true;
                                if (statusws == false)
                                {
                                    popUpMsgBox("Request anda tidak bisa disubmit karena jadwal anda pada hari tersebut adalah : WFH");
                                }
                                else
                                {
                                    Session.Add("datereqcico1", txtDateCICO.Text.Trim());
                                    Session.Add("typereqcico1", ddlTypeCICO.SelectedValue);
                                    Session.Add("timereqcico1", txtTimeCICO.Text.Trim());
                                    Session.Add("notereqcico1", txtReason1.Text.Trim());
                                    Response.Redirect("request_cico_confirm.aspx");
                                }
                            }
                        }
                    }
                }
            }

        }


        static Boolean cekSubmitCICO(string nrp1,string date1,string type1)
        {
            Boolean flg1;
            flg1 = true;
            date1 = date1.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekcico/" + nrp1 + "/" + date1 + "/" + type1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<strJson>(jsonstr);
                flg1 = Convert.ToBoolean(result1.cekCicoResult);
            }
            return flg1;
        }

        public class strJson
        {
            public string cekCicoResult;
        }

        public class subCico1
        {
            public string subCicoResult;
        }

        public class dateNow1
        {
            public string validDateforCICOResult;
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("')};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        static Boolean cekWS(string nrp1, string date1)
        {
            Boolean flg1;
            string status1="";
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

                if(status1=="WFH")
                {
                    flg1 = false;
                }
            }
            return flg1;
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


    }
}