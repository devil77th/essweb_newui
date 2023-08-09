using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_overtime_add : System.Web.UI.UserControl
    {
        public static string nrp1,error1;
        static DataTable dtable1;
        DateTime varmon1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
        DateTime varmon2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                nrp1 = Session["nrp1"].ToString();
                //nrp1 = "2000";
                ddlMonth1.Items.Add(new ListItem(varmon1.ToString("MM") + "-" + varmon1.ToString("yyyy")));
                ddlMonth1.Items.Add(new ListItem(varmon2.ToString("MM") + "-" + varmon2.ToString("yyyy")));
            }
        }

        protected void cmdSearchCICOWFO_Click(object sender, ImageClickEventArgs e)
        {
            mdlPopUpCICO.Show();
        }

        static DataTable getApprovalCICOData(string nrp2, string month1, string year1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/getwfoclaimot_v2/" + nrp2 + "/" + month1 + "/" + year1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<cicoWFO_ClaimOT1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("dateCICO1");
                dtable1.Columns.Add("wsin1");
                dtable1.Columns.Add("wsout1");
                dtable1.Columns.Add("clockinCICO1");
                dtable1.Columns.Add("clockoutCICO1");


                for (int i = 0; i <= result1.GetReportAbsensiWFOClaimOT2Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(
                        result1.GetReportAbsensiWFOClaimOT2Result[i].dateCICOWFO1,
                        result1.GetReportAbsensiWFOClaimOT2Result[i].wsin1,
                        result1.GetReportAbsensiWFOClaimOT2Result[i].wsout1,
                        result1.GetReportAbsensiWFOClaimOT2Result[i].clockinWFO1,
                        result1.GetReportAbsensiWFOClaimOT2Result[i].clockoutWFO1);
                }

                return dtable1;
            }
        }

        public class GetReportAbsensiWFOHClaimOTResult1
        {
            public List<cicoWFO> GetReportAbsensiWFOClaimOTResult { get; set; }
        }

        public class cicoWFO
        {
            public string dateCICOWFO1 { get; set; }
            public string clockinWFO1 { get; set; }
            public string clockoutWFO1 { get; set; }
        }

        public class cicoWFO_ClaimOT1
        {
            public List<cicoWFO_ClaimOT2> GetReportAbsensiWFOClaimOT2Result { get; set; }
        }

        public class cicoWFO_ClaimOT2
        {
            public string dateCICOWFO1 { get; set; }
            public string clockinWFO1 { get; set; }
            public string clockoutWFO1 { get; set; }
            public string wsin1 { get; set; }
            public string wsout1 { get; set; }
        }

        public class wsheader1
        {
            public wsdetail1 GetWorkSchedulePerDate1Result { get; set; }
        }

        public class cekclaimot1
        {
            public Boolean CekClaimOT_v2Result { get; set; }
        }

        public class wsdetail1
        {
            public string ciwfo1 { get; set; }
            public string cowfo1 { get; set; }
        }

        protected void cmdSearchData_Click(object sender, ImageClickEventArgs e)
        {
            string[] var1;
            var1 = ddlMonth1.SelectedItem.Text.Split('-');
            gvcicowfo.DataSource = getApprovalCICOData(nrp1, var1[0].ToString(), var1[1].ToString());
            gvcicowfo.DataBind();
        }

        protected void cmdSubmitOT_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOTIn.Text.Trim()) == true || string.IsNullOrEmpty(txtOTOut.Text.Trim()) == true
                    || string.IsNullOrEmpty(txtReason.Text.Trim()) == true || string.IsNullOrEmpty(lblCICOWFOin.Text)==true
                    || string.IsNullOrEmpty(ddl_dtOvt1.SelectedItem.Value) == true)
            {
                popUpMsgBox("Semua field harus diisi");
            }
            else
            {
                if (IsValidTime(txtOTIn.Text.Trim()) == false || IsValidTime(txtOTOut.Text.Trim()) == false)
                {
                    popUpMsgBox("Cek lagi entry Jam Overtime Start/End");
                }
                else
                {
                    Boolean flg1 = cekvalidOT(ddl_dtOvt1.SelectedItem.Text);
                    if (flg1 == true)
                    {
                        Session.Add("datereqot_" + nrp1, ddl_dtOvt1.SelectedItem.Text);
                        Session.Add("timereqot1_" + nrp1, ddl_dtOvt1.SelectedItem.Text + " " + txtOTIn.Text.Trim());
                        Session.Add("timereqot2_" + nrp1, ddl_dtOvt1.SelectedItem.Text + " " + txtOTOut.Text.Trim());
                        Session.Add("reasonot_" + nrp1, txtReason.Text.Trim());
                        Response.Redirect("request_overtime_confirm.aspx");
                    }

                    else
                    {
                        if (error1 == "JamOToutlebihbesar")
                        {
                            popUpMsgBox("Jam Request Overtime End anda lebih besar daripada jam Clock Out / Jadwal Kerja anda");
                        }
                        if (error1 == "JamOTinlebihkecildaripadaWS")
                        {
                            popUpMsgBox("Jam Request Overtime In anda lebih kecil daripada jam Work Schedule Out anda");
                        }
                        if (error1 == "DoubleData")
                        {
                            popUpMsgBox("Sudah ada Request Overtime pada tanggal tersebut");
                        }
                        if(error1 == "awallebihbesar")
                        {
                            popUpMsgBox("Waktu awal lebih besar daripada waktu akhir");
                        }
                        if (error1 == "ReqInLebihKecilDariCICOIn")
                        {
                            popUpMsgBox("Jam Request lebih kecil daripada Clock In");
                        }
                        if (error1 == "JamReqMasukWS")
                        {
                            popUpMsgBox("Jam Request harus lebih besar / lebih kecil dari Jadwal Kerja anda");
                        }

                    }

                }
            }
        }

        protected void gvcicowfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmdarg1 = e.CommandArgument.ToString();
            string[] cmdarg2 = cmdarg1.Split('#');
            lblCICOWFOin.Text = cmdarg2[0].ToString();
            lblCICOWFOout.Text = cmdarg2[1].ToString();
            //string tglcicowfo = cmdarg2[2].ToString();
            //hidtglcicowfo.Value = cmdarg2[2].ToString();
            //getWS1(nrp1, hidtglcicowfo.Value);
            lblwsin1.Text = cmdarg2[2].ToString();
            lblwsout1.Text = cmdarg2[3].ToString();
            updws1.Update();

            ddl_dtOvt1.Items.Clear();
            string date1 = lblCICOWFOin.Text.Substring(0, 11);
            string date2 = lblCICOWFOout.Text.Substring(0, 11);

            if (date1 != date2)
            {
                ddl_dtOvt1.Items.Add(new ListItem("", ""));
                ddl_dtOvt1.Items.Add(new ListItem(date1,date1));
                ddl_dtOvt1.Items.Add(new ListItem(date2,date2));
            }
            else
            {
                ddl_dtOvt1.Items.Add(new ListItem("", ""));
                ddl_dtOvt1.Items.Add(new ListItem(date1,date1));
            }
            upd_ddl_dtOvt1.Update();

            mdlPopUpCICO.Hide();
            updPanel2.Update();
            
        }

        Boolean cekvalidOT(string date1)
        {
            Boolean flg1 = true;
            DateTime dateot1, dateot2,cico1,cico2,wsin1,wsout1;

            String ot1 = "", ot2 = "";
            
            cico1 = Convert.ToDateTime(lblCICOWFOin.Text.Substring(0, 20));
            cico2 = Convert.ToDateTime(lblCICOWFOout.Text.Substring(0, 20));
            wsin1 = Convert.ToDateTime(lblwsin1.Text);
            wsout1 = Convert.ToDateTime(lblwsout1.Text);
            

            string dateotreq1 = date1 + " " + txtOTIn.Text;
            string dateotreq2 = date1 + " " + txtOTOut.Text;
            DateTime.TryParse(dateotreq1,out dateot1);
            DateTime.TryParse(dateotreq2, out dateot2);

            if(ddl_dtOvt1.Items.Count >= 3)
            {
                if(dateot1.ToString("dd-MMM-yyyy") == wsin1.ToString("dd-MMM-yyyy"))
                {
                    ot1 = cico1.ToString();
                    ot2 = wsin1.ToString();
                }

                if (dateot1.ToString("dd-MMM-yyyy") == wsout1.ToString("dd-MMM-yyyy"))
                {
                    ot1 = wsout1.ToString();
                    ot2 = cico2.ToString();
                }

                if (dateot2 > Convert.ToDateTime(ot2))
                {
                    flg1 = false;
                    error1 = "JamOToutlebihbesar";
                }

                if (cekClaimOT(nrp1, dateot1.ToString("dd-MMM-yyyy HH:mm:ss"), dateot2.ToString("dd-MMM-yyyy HH:mm:ss")) == false)
                {
                    flg1 = false;
                    error1 = "DoubleData";
                }

                if (dateot1 > dateot2)
                {
                    flg1 = false;
                    error1 = "awallebihbesar";
                }

                if(dateot1 < cico1)
                {
                    flg1 = false;
                    error1 = "ReqInLebihKecilDariCICOIn";
                }

                if (dateot1 <= wsout1 && dateot2 >= wsin1)
                {
                    flg1 = false;
                    error1 = "JamReqMasukWS";
                }

                

            }
            else
            {
                ot1 = wsout1.ToString();
                ot2 = cico2.ToString();

                if (dateot2 > Convert.ToDateTime(ot2))
                {
                    flg1 = false;
                    error1 = "JamOToutlebihbesar";
                }

                if (cekClaimOT(nrp1, dateot1.ToString("dd-MMM-yyyy HH:mm:ss"), dateot2.ToString("dd-MMM-yyyy HH:mm:ss")) == false)
                {
                    flg1 = false;
                    error1 = "DoubleData";
                }

                if (dateot1 > dateot2)
                {
                    flg1 = false;
                    error1 = "awallebihbesar";
                }

                if (dateot1 < cico1)
                {
                    flg1 = false;
                    error1 = "ReqInLebihKecilDariCICOIn";
                }

                if (dateot1 <= wsout1 && dateot2 >= wsin1)
                {
                    flg1 = false;
                    error1 = "JamReqMasukWS";
                }
            }

            return flg1;
        }

        //void getWS1(string nrp1,string date1)
        //{
        //    string jsonstr;
        //    var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getwsperdate/" + nrp1 + "/" + date1;
        //    var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

        //    using (var response = webrequest.GetResponse())
        //    using (var reader = new StreamReader(response.GetResponseStream()))
        //    {

        //        var result = reader.ReadToEnd();
        //        jsonstr = Convert.ToString(result);
        //        var result1 = JsonConvert.DeserializeObject<wsheader1>(jsonstr);
        //        hidciwfo.Value = result1.GetWorkSchedulePerDate1Result.ciwfo1.ToString();
        //        hidcowfo.Value = result1.GetWorkSchedulePerDate1Result.cowfo1.ToString();
        //        lblwsin1.Text = result1.GetWorkSchedulePerDate1Result.ciwfo1.ToString();
        //        lblwsout1.Text = result1.GetWorkSchedulePerDate1Result.cowfo1.ToString();
        //        updws1.Update();
        //    }
        //}

        Boolean cekClaimOT(string parnrp1,string pardate1,string pardate2)
        {
            Boolean flg1 = false;   
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/cekclaimot_v2";
            object input = new
            {
               nrp1 = parnrp1,
               date1 = pardate1,
               date2 = pardate2
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
                    var jsonresult1 = (new StreamReader(stream)).ReadToEnd();
                    var result1 = JsonConvert.DeserializeObject<cekclaimot1>(jsonresult1);
                    flg1 = result1.CekClaimOT_v2Result;
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

        //protected void ddl_dtOvt1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string wsin1 = lblwsin1.Text;
        //    string wsout1 = lblwsout1.Text;
        //    string cicoin1 = lblCICOWFOin.Text;
        //    string cicoout1 = lblCICOWFOout.Text;
        //    cicoin1 = cicoin1.Substring(0, 20);
        //    cicoout1 = cicoout1.Substring(0, 20);

        //    if(ddl_dtOvt1.SelectedItem.Text == Convert.ToDateTime(wsin1).ToString("dd-MMM-yyyy"))
        //    {
        //        if(Convert.ToDateTime(cicoin1) < Convert.ToDateTime(wsin1))
        //        {
        //            hidot1.Value = cicoin1;
        //            hidot2.Value = wsin1;
        //        }
                
        //    }

        //    if (ddl_dtOvt1.SelectedItem.Text == Convert.ToDateTime(wsout1).ToString("dd-MMM-yyyy"))
        //    {

        //        if (Convert.ToDateTime(cicoout1) > Convert.ToDateTime(wsout1))
        //        {
        //            hidot1.Value = wsout1;
        //            hidot2.Value = cicoout1;
        //        }
        //    }

        //    upd_otinout1.Update();
        //}

        public bool IsValidTime(string thetime)
        {
            Regex checktime =
             new Regex(@"^(([0-1][0-9])|([2][0-3])):([0-5][0-9])");

            return checktime.IsMatch(thetime);
        }
    }
}