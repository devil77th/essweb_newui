using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_overtime_edit : System.Web.UI.UserControl
    {
        string idtrx1;
        protected void Page_Load(object sender, EventArgs e)
        {
            idtrx1 = Request["i"].ToString();
            if(Page.IsPostBack==false)
            {
                LoadData(idtrx1);
            }
        }

        string decData(string str1)
        {
            byte xorConstant = 0x53;
            string input = str1;
            byte[] data = Convert.FromBase64String(input);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            string plainText = Encoding.UTF8.GetString(data);
            return plainText;
        }

        public void LoadData(string idovt)
        {
            string reason1, actci1, actco1, timeovt1, timeovt2,nrp1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getdataovt/" + idovt;
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.GetDataTrxOVTResult1>(jsonstr);
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
                reason1 = result1.getDataOvt1Result[0].reason.ToString();
                actci1 = result1.getDataOvt1Result[0].actci.ToString();
                actco1 = result1.getDataOvt1Result[0].actco.ToString();
                timeovt1 = result1.getDataOvt1Result[0].timefrom.ToString();
                timeovt2 = result1.getDataOvt1Result[0].timeto.ToString();
                nrp1 = result1.getDataOvt1Result[0].nrp.ToString();
            }
            lblCICO.Text = actci1 + " - " + actco1;
            lblReasonOvertime.Text = reason1;
            lblTimeOvt1.Text = timeovt1;
            lblTimeOvt2.Text = timeovt2;
            nrpreq1.Value = nrp1;

            txtOvtDate1.Text = DateTime.Parse(timeovt1.ToString()).ToString("dd-MMM-yyyy");
            txtOvtHour1.Text = DateTime.Parse(timeovt1.ToString()).ToString("HH:mm");

            txtOvtDate2.Text = DateTime.Parse(timeovt2.ToString()).ToString("dd-MMM-yyyy");
            txtOvtHour2.Text = DateTime.Parse(timeovt2.ToString()).ToString("HH:mm");

        }

      


        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("approval_overtime.aspx?token1=" + Request["token1"]);
        }

        int cekApprover(string nrp1, string by1)
        {
            int i = 0;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekapp/" + nrp1 + "/" + by1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.GetCekAppOvt1>(jsonstr);
                i = Convert.ToInt16(result1.CekApproverResult);
            }
            return i;
        }

        protected void cmdSubmitCICO_Click(object sender, EventArgs e)
        {
            int a;
            a = cekApprover(nrpreq1.Value, decData(Request["token1"]));

            if (a == 1)
            {
                Boolean validDateTime1 = DateTime.TryParse(txtOvtDate1.Text.Trim() + " " + txtOvtHour1.Text.Trim()
                       , out DateTime dt1);

                Boolean validDateTime2 = DateTime.TryParse(txtOvtDate2.Text.Trim() + " " + txtOvtHour2.Text.Trim()
                        , out DateTime dt2);

                if (IsValidTime(txtOvtHour1.Text.Trim()) == false || IsValidTime(txtOvtHour2.Text.Trim()) == false)
                {
                    popUpMsgBox("Jam yang anda masukkan salah");
                }
                else
                {
                    if (validDateTime1 == false || validDateTime2 == false)
                    {
                        popUpMsgBox("Tolong cek kembali data yang anda masukkan");
                    }
                    else
                    {
                        if (dt1 > dt2)
                        {
                            popUpMsgBox("Waktu Overtime Mulai lebih besar daripada Waktu Overtime Selesai");
                        }
                        else
                        {
                            string dateovtedit1, dateovtedit2, hourovtedit1, hourovtedit2;
                            string decStr1 = decData(Request["token1"]);
                            dateovtedit1 = txtOvtDate1.Text.Replace("-", "_").Trim();
                            dateovtedit2 = txtOvtDate2.Text.Replace("-", "_").Trim();
                            hourovtedit1 = txtOvtHour1.Text.Replace(":", "_").Trim();
                            hourovtedit2 = txtOvtHour2.Text.Replace(":", "_").Trim();

                            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/editovt/" + idtrx1 + "/" + dateovtedit1 +
                                "/" + dateovtedit2 + "/" + hourovtedit1 + "/" + hourovtedit2 + "/" + decStr1;
                            //Console.WriteLine(url.ToString());
                            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                            using (var response = webrequest.GetResponse())
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                var result = reader.ReadToEnd();
                                string jsonstr = Convert.ToString(result);

                            }
                            Response.Redirect("approval_overtime.aspx?token1=" + Request["token1"]);
                        }
                    }
                }
            }
            else
            {
                popUpMsgBox("Approval tidak bisa dilakukan. Mohon menghubungi HRD disertakan dengan screenshot layar ini");
            }
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

        public bool IsValidTime(string thetime)
        {
            Regex checktime =
             new Regex(@"^(([0-1][0-9])|([2][0-3])):([0-5][0-9])");

            return checktime.IsMatch(thetime);
        }
    }
}