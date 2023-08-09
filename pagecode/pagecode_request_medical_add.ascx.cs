using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_medical_add : System.Web.UI.UserControl
    {
        string varlimitmedical1, varsisamedical1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                fillDataPatient(Session["nrp1"].ToString());
                getLimitMedical();
            }
        }

        protected void cmdSubmitTrxMed_Click(object sender, EventArgs e)
        {
            if (validClaimMed() == true)
            {
                Double amtsisa = Convert.ToDouble(hidSisa1.Value) - Convert.ToDouble(txtJumlah1.Text);
                if (amtsisa > 0)
                {
                    if (isValidNumber(txtJumlah1.Text) == true)
                    {

                        Session.Add("datekuida1_" + Session["nrp1"].ToString(), txtKuiDa1.Text.Trim());
                        Session.Add("diagnosa1_" + Session["nrp1"].ToString(), txtDiagnosa1.Text.Trim());
                        Session.Add("amount1_" + Session["nrp1"].ToString(), txtJumlah1.Text.Trim());
                        Session.Add("namapasien1_" + Session["nrp1"].ToString(), ddlPasien1.SelectedValue);
                        Response.Redirect("request_medical_confirm.aspx");
                    }
                    else
                    {
                        popUpMsgBox("Jumlah klaim harus berupa angka");
                    }
                }
                else
                {
                    popUpMsgBox("Klaim anda melebihi sisa limit medical anda");
                }
            }
            else
            {
                popUpMsgBox("Cek kembali tanggal kuitansi anda");
            }
        }

        void fillDataPatient(string nrp1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpatient/" + nrp1;
            //var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpatient/" + "6386";
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);

                var result1 = JsonConvert.DeserializeObject<listPatient1>(jsonstr);
                ddlPasien1.Items.Add(new ListItem("Pilih Pasien", ""));

                if (result1.GetListPatientResult[0].fullname.ToString() != "")
                {
                    for (int i = 0; i <= result1.GetListPatientResult.Count - 1; i++)
                    {
                        ddlPasien1.Items.Add(new ListItem(result1.GetListPatientResult[i].fullname,
                            result1.GetListPatientResult[i].fullname));
                    }
                }
            }
        }

        void getLimitMedical()
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getsisamed/" + Session["nrp1"].ToString() + "/" 
                + DateTime.Now.Year.ToString();
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetLimitMedical>(jsonstr);
                varlimitmedical1 = result1.GetSisaMedResult.limit1.ToString();
                varsisamedical1 = result1.GetSisaMedResult.sisa1.ToString();
                lbllimitmedical1.Text = "Limit Klaim Medical : " + String.Format("{0:#,0}", Convert.ToDouble(varlimitmedical1));
                lblsisamedical1.Text = "Sisa Klaim Medical : " + String.Format("{0:#,0}", Convert.ToDouble(varsisamedical1));
                hidSisa1.Value = varsisamedical1.ToString();
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
            }
        }

        public string getDateFromServ()
        {
            string dateserv1 = "";
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

        Boolean validClaimMed()
        {
            Boolean flg1 = false;
            if(dateClaimMedValid(txtKuiDa1.Text.Trim()) == true)
            {
                flg1 = true;
            }

            return flg1;
        }

        Boolean dateClaimMedValid(string dateKui1)
        {
            Boolean flg1 = false;
            String dateServ1 = getDateFromServ();
            DateTime dateServ2 = Convert.ToDateTime(dateServ1).Date;
            DateTime dateServ3 = Convert.ToDateTime(dateKui1).Date;
            double diffdays1 = (dateServ2 - dateServ3).TotalDays;
            if (dateServ3 <= dateServ2)
            {
                if (diffdays1 <= 30)
                {
                    flg1 = true;
                }
            }
            return flg1;
        }

        public Boolean isValidNumber(string text1)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            return regex.IsMatch(text1);
        }
        public class listPatient1
        {
            public List<GetListPatient1> GetListPatientResult { get; set; }
        }

        public class GetListPatient1
        {
            public string fullname { get; set; }
        }

        public class dateServJson
        {
            public string GetDateFromServerResult { get; set; }
        }

        public class GetLimitMedical
        {
            public limitmedical1 GetSisaMedResult { get; set; }
        }

        public class limitmedical1
        {
            public string limit1 { get; set; }
            public string onrequest1 { get; set; }
            public string sdhdigunakan1 { get; set; }
            public string sisa1 { get; set; }
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
    }
}