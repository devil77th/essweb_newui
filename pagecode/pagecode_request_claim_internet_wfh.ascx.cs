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
    public partial class pagecode_request_claim_internet_wfh : System.Web.UI.UserControl
    {
        public static string nrp1;
        static DataTable dtable1;
        DateTime vartest1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1); 
        DateTime vartest2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                nrp1 = Session["nrp1"].ToString();
                
                ddlMonth1.Items.Add(new ListItem(vartest1.ToString("MM") + "-" + vartest1.ToString("yyyy")));
                ddlMonth1.Items.Add(new ListItem(vartest2.ToString("MM") + "-" + vartest2.ToString("yyyy")));
            }
        }

        protected void cmdSearchCICOWFH_Click(object sender, ImageClickEventArgs e)
        {
            mdlPopUpCICO.Show();
        }

        protected void cmdSearchData_Click(object sender, ImageClickEventArgs e)
        {
            string[] var1;
            var1 = ddlMonth1.SelectedItem.Text.Split('-');
            gvcicowfh.DataSource = getApprovalCICOData(nrp1, var1[0].ToString(), var1[1].ToString());
            gvcicowfh.DataBind();
        }

        protected void cmdSubmitCICO_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmailHour.Text.Trim()) == true || String.IsNullOrEmpty(txtSAPHour.Text.Trim()) == true
                || String.IsNullOrEmpty(txtTeamsHour.Text.Trim()) == true)
            {
                popUpMsgBox("Data penggunaan internet yang dimasukkan salah");
            }
            else
            {

                if (isValidNumber(txtEmailHour.Text) == false || isValidNumber(txtSAPHour.Text) == false
                    || isValidNumber(txtTeamsHour.Text) == false)
                {
                    popUpMsgBox("Data penggunaan internet yang dimasukkan salah");
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(lblCICOWFHin.Text) == true)
                    {
                        popUpMsgBox("Anda belum memilih tanggal WFH");
                    }
                    else
                    {
                        if(Convert.ToInt16(txtEmailHour.Text) > Convert.ToInt16(lblWorkHour.Text) ||
                            Convert.ToInt16(txtSAPHour.Text) > Convert.ToInt16(lblWorkHour.Text) ||
                            Convert.ToInt16(txtTeamsHour.Text) > Convert.ToInt16(lblWorkHour.Text))
                        {
                            popUpMsgBox("Klaim penggunaan tidak boleh lebih dari lama jam kerja");
                        }

                        else
                        {
                            Boolean flg1 = cekClaimWFHinternet(nrp1, lblCICOWFHin.Text.Substring(0,20));
                            if(flg1 == true)
                            {
                                Session.Add("tglcicowfhin", lblCICOWFHin.Text);
                                Session.Add("tglcicowfhout", lblCICOWFHout.Text);
                                Session.Add("emailhour", txtEmailHour.Text);
                                Session.Add("saphour", txtSAPHour.Text);
                                Session.Add("teamshour", txtTeamsHour.Text);
                                Response.Redirect("request_claim_internet_wfh_confirm.aspx");
                            }
                            else
                            {
                                popUpMsgBox("Anda sudah pernah melakukan claim pada tanggal tersebut");
                            }
                        }
                       
                    }
                }
            }
        }

        
        static DataTable getApprovalCICOData(string nrp2,string month1,string year1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/wfhclaiminternet/" + nrp2 + "/" + month1 + "/" + year1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetReportAbsensiWFHClaimInternetResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("dateCICO1");
                dtable1.Columns.Add("clockinCICO1");
                dtable1.Columns.Add("clockoutCICO1");


                for (int i = 0; i <= result1.GetReportAbsensiWFHClaimInternetResult.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.GetReportAbsensiWFHClaimInternetResult[i].dateCICOWFH1,
                        result1.GetReportAbsensiWFHClaimInternetResult[i].clockinWFH1,
                        result1.GetReportAbsensiWFHClaimInternetResult[i].clockoutWFH1);
                }

                return dtable1;
            }
        }

        public Boolean isValidNumber(string text1)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            return regex.IsMatch(text1);
        }

        public class GetReportAbsensiWFHClaimInternetResult1
        {
            public List<cicoWFH> GetReportAbsensiWFHClaimInternetResult { get; set; }
        }

        public class cicoWFH
        {
            public string dateCICOWFH1 { get; set; }
            public string clockinWFH1 { get; set; }
            public string clockoutWFH1 { get; set; }
           
        }

        protected void gvcicowfh_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmdarg1 = e.CommandArgument.ToString();
            string[] cmdarg2 = cmdarg1.Split('#');
            lblCICOWFHin.Text = cmdarg2[0].ToString();
            lblCICOWFHout.Text = cmdarg2[1].ToString();
            mdlPopUpCICO.Hide();
            updPanel2.Update();

            DateTime date1, date2;
            date1 = Convert.ToDateTime(lblCICOWFHin.Text.Substring(0, 20));
            date2 = Convert.ToDateTime(lblCICOWFHout.Text.Substring(0, 20));

            int dayDiff = ((TimeSpan)(date2 - date1)).Hours;
            lblWorkHour.Text = dayDiff.ToString();
            updPanel3.Update();
        }

        Boolean cekClaimWFHinternet(string nrp1,string date1)
        {
            string jsonstr;
            Boolean flg1=false;
            DateTime date2 = DateTime.Parse(date1);
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekclaiminternet/" + nrp1 + "/" + date2.ToString("dd-MMM-yyyy");
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<cekClaimWFH>(jsonstr);
                if(result1.CekWFHClaimInternetResult == true)
                {
                    flg1 = true;
                }
                else
                {
                    flg1 = false;
                }
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
            sb.Append("')};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        public class cekClaimWFH
        {
            public Boolean CekWFHClaimInternetResult { get; set; }
        }
    }
}