using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1.pagecode
{

    public partial class pagecode_request_absence : System.Web.UI.UserControl
    {

        static int numdays1;
        static DataTable dtable1, dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["nrp1"]==null || Session["nrp1"].ToString()=="")
            {
                Response.Redirect("login.aspx");
            }
            if (Page.IsPostBack == false)
            {
                loadAbsenceType();
                UpdateSaldoCuti();
            }
        }

        void UpdateSaldoCuti()
        {
            dl1 = getSaldoCuti(Session["nrp1"].ToString());
            gvcuti1.DataSource = dl1;
            gvcuti1.DataBind();
        }

        static DataTable getSaldoCuti(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstsaldocutipernrp/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.listSaldoCutiResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("abscode1");
                dtable1.Columns.Add("jumlah1");
                dtable1.Columns.Add("begda1");
                dtable1.Columns.Add("endda1");
                dtable1.Columns.Add("nrp1");
                dtable1.Columns.Add("remain1");

                for (int i = 0; i <= result1.listSaldoCutiperNRP1Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.listSaldoCutiperNRP1Result[i].absencecode1,
                        result1.listSaldoCutiperNRP1Result[i].jumlah1,
                        result1.listSaldoCutiperNRP1Result[i].begda1,
                        result1.listSaldoCutiperNRP1Result[i].endda1,
                        result1.listSaldoCutiperNRP1Result[i].nrp1,
                        result1.listSaldoCutiperNRP1Result[i].remain1);
                }

                return dtable1;
            }

        }

        //public bool IsValidDate(string thedate)
        //{
        //    Regex checkdate =
        //     new Regex(@"^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]\d{4}");

        //    return checkdate.IsMatch(thedate);
        //}

        protected void cmdSubmitAbs_Click(object sender, EventArgs e)
        {
            Boolean flgValidCICO;
            Boolean validDateTime1 = DateTime.TryParse(txtDateAbs1.Text.Trim() + " " + "00:00:00"
                    , out DateTime dt1);

            Boolean validDateTime2 = DateTime.TryParse(txtDateAbs2.Text.Trim() + " " + "00:00:00"
                    , out DateTime dt2);

            if (txtDateAbs1.Text.Trim() == null || txtDateAbs1.Text.Trim() == "" || 
                txtDateAbs2.Text.Trim() == null || txtDateAbs2.Text.Trim() == "")
            {
                popUpMsgBox("Semua field harus diisi");
            }
            else
            {

                if ( validDateTime1==false || validDateTime2 == false)
                {
                    popUpMsgBox("Tolong cek lagi data yang anda entry");
                }
                else
                {

                    if (Convert.ToDateTime(txtDateAbs1.Text.Trim()).Date > Convert.ToDateTime(txtDateAbs2.Text.Trim()).Date)
                    {
                        popUpMsgBox("Tanggal pertama lebih besar daripada tanggal kedua");
                    }
                    else
                    {
                            flgValidCICO = cekSubmitABS((string)Session["nrp1"], txtDateAbs1.Text.Trim(), txtDateAbs2.Text.Trim());
                            if (flgValidCICO == true)
                            {
                                popUpMsgBox("Sudah ada transaksi CI/CO atau Absence atau Attendance pada tanggal tersebut");
                            }
                            else
                            {

                                Session.Add("datereqabs1", txtDateAbs1.Text.Trim());
                                Session.Add("datereqabs2", txtDateAbs2.Text.Trim());
                                Session.Add("typereqabs1", ddlTypeAbsence.SelectedValue);
                                Session.Add("textreqabs1", ddlTypeAbsence.SelectedItem.Text);
                                Session.Add("numdaysreqabs1", numdays1);
                                Response.Redirect("request_absence_confirm.aspx");

                            }
                    }
                    
                }
            }
        }


        static Boolean cekSubmitABS(string nrp1,string date1,string date2)
        {
            Boolean flg1;
            date1 = date1.Replace("-", "_");
            date2 = date2.Replace("-", "_");
            
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekonleave/" + nrp1 + "/" + date1 + "/" + date2;
            Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<cekOnleaveResult1>(jsonstr);
                flg1 = Convert.ToBoolean(result1.cekOnleaveResult[0].flgTrx);
                numdays1 = Convert.ToInt16(result1.cekOnleaveResult[0].numOnleave);
            }
            return flg1;
        }

        public class cekOnleaveResult1
        {
            public List<onleave1> cekOnleaveResult { get; set; }
        }

        public class onleave1
        {
            public string flgTrx { get; set; }
            public string numOnleave { get; set; }
        }


        public class ListAbsenceType1
        {
            public List<abstype1> getabstypeResult { get; set; }
        }

        public class abstype1
        {
            public string absencecode1 { get; set; }
            public string absencetype1 { get; set; }
        }

        void loadAbsenceType()
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getabstype";
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);

                var result1 = JsonConvert.DeserializeObject<ListAbsenceType1>(jsonstr);
                ddlTypeAbsence.Items.Add(new ListItem("", ""));

                if (result1.getabstypeResult[0].absencecode1.ToString() != "")
                {
                    for (int i = 0; i <= result1.getabstypeResult.Count - 1; i++)
                    {
                        ddlTypeAbsence.Items.Add(new ListItem(result1.getabstypeResult[i].absencetype1,
                            result1.getabstypeResult[i].absencecode1));
                    }
                }
                reader.Close();
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
    }
}