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
    public partial class pagecode_request_klaim_kacamata_add : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                fillDataPeserta(Session["nrp1"].ToString());
                //fillDataPeserta("376");
                fillItemClaim();
                hidClaimant1.Value = "";
                hidframeelig1.Value = "";
                hidframeyear1.Value = "";
                hidlensaelig1.Value = "";
                hidlensayear1.Value = "";
                hidlimitframe1.Value = "";
                hidlimitlensa1.Value = "";
                updhid1.Update();
            }
        }

        void fillDataPeserta(string nrp1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listclaimantkm/" + nrp1;
            //var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpatient/" + "6386";
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);

                var result1 = JsonConvert.DeserializeObject<listClaimant1>(jsonstr);
                ddlPeserta1.Items.Add(new ListItem("Pilih Peserta", ""));

                if (result1.getListClaimantName1Result[0].claimant1.ToString() != "")
                {
                    for (int i = 0; i <= result1.getListClaimantName1Result.Count - 1; i++)
                    {
                            ddlPeserta1.Items.Add(new ListItem(result1.getListClaimantName1Result[i].claimantname1,
                                result1.getListClaimantName1Result[i].claimant1));                        
                    }
                }
            }
        }

        void fillItemClaim()
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listitemclaimkm";
            //var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpatient/" + "6386";
            //Console.WriteLine(url.ToString());
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);

                var result1 = JsonConvert.DeserializeObject<listItemClaim1>(jsonstr);
                ddlItemClaimFrame.Items.Add(new ListItem("", ""));
                ddlItemClaimLensa.Items.Add(new ListItem("", ""));
                

                if (result1.getListItemClaimKM1Result[0].codeess1.ToString() != "")
                {
                    for (int i = 0; i <= result1.getListItemClaimKM1Result.Count - 1; i++)
                    {
                        if (result1.getListItemClaimKM1Result[i].codeess1.ToString() == "KCM_FB01")
                        {
                            ddlItemClaimFrame.Items.Add(new ListItem(result1.getListItemClaimKM1Result[i].desc1.ToString(),
                                result1.getListItemClaimKM1Result[i].codeess1.ToString()));
                        }
                        else
                        {
                            ddlItemClaimLensa.Items.Add(new ListItem(result1.getListItemClaimKM1Result[i].desc1.ToString(),
                                result1.getListItemClaimKM1Result[i].codeess1.ToString()));

                        }
                    }
                }
            }
        }

        String lastItemClaim(string itemtype1,string nrp1,string claimant1)
        {

            String strclaimdate1 = "";

            if (string.IsNullOrEmpty(claimant1) == false)
            {

                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getlastclaimkm/" + itemtype1 + "/" + nrp1 + "/" + claimant1;
                //var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpatient/" + "6386";
                //Console.WriteLine(url.ToString());
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    string jsonstr = Convert.ToString(result);

                    var result1 = JsonConvert.DeserializeObject<lastClaimDate1>(jsonstr);

                    if (String.IsNullOrEmpty(result1.getLastItemClaimKMResult.ToString()) == false)
                    {
                        strclaimdate1 = result1.getLastItemClaimKMResult.ToString();
                    }
                }
            }

            return strclaimdate1;
        }

        public class lastClaimDate1
        {
            public string getLastItemClaimKMResult { get; set; }
        }

        public class listClaimant1
        {
            public List<GetListClaimant1> getListClaimantName1Result { get; set; }
        }

        public class GetListClaimant1
        {
            public string claimant1 { get; set; }
            public string claimantname1 { get; set; }

        }

        public class listItemClaim1
        {
            public List<GetListItemClaim1> getListItemClaimKM1Result { get; set; }
        }

        public class GetListItemClaim1
        {
            public string codeess1 { get; set; }
            public string desc1 { get; set; }

        }

        protected void cmdSubmitClaimKM_Click(object sender, EventArgs e)
        {
            string errorMsg1 = "";
            
            if(string.IsNullOrEmpty(errorMsg1=validPeserta())==true)
            {
                if(string.IsNullOrEmpty(errorMsg1=validClaimFrame()) == true)
                {
                    if (string.IsNullOrEmpty(errorMsg1=validClaimLensa()) == true)
                    {
                        errorMsg1 = "";
                    }
                }
            }
            
            if (String.IsNullOrEmpty(errorMsg1) == false)
            {
                popUpMsgBox(errorMsg1);
            }
            else
            {
                Session.Add("peserta1_" + Session["nrp1"].ToString(), ddlPeserta1.SelectedValue.ToString());
                Session.Add("lblpeserta1_" + Session["nrp1"].ToString(), ddlPeserta1.SelectedItem.Text.ToString());
                Session.Add("frame1_" + Session["nrp1"].ToString(), ddlItemClaimFrame.SelectedValue.ToString());
                Session.Add("framename1_" + Session["nrp1"].ToString(), ddlItemClaimFrame.SelectedItem.Text.ToString());
                Session.Add("frameamount1_" + Session["nrp1"].ToString(), txtItemAmtClaimFrame.Text.Trim());
                Session.Add("lensa1_" + Session["nrp1"].ToString(), ddlItemClaimLensa.SelectedValue.ToString());
                Session.Add("lensaname1_" + Session["nrp1"].ToString(), ddlItemClaimLensa.SelectedItem.Text.ToString());
                Session.Add("lensaamount1_" + Session["nrp1"].ToString(), txtItemAmtClaimLensa.Text.Trim());
                Session.Add("txtketerangan1_" + Session["nrp1"].ToString(), txtKeterangan1.Text.Trim());
                Session.Add("lastclaimframe1_" + Session["nrp1"].ToString(), lbllastclaimframe.Text);
                Session.Add("lastclaimlensa1_" + Session["nrp1"].ToString(), lbllastclaimlens.Text);
                Response.Redirect("request_klaim_kacamata_confirm.aspx");
            }
        }

        protected void ddlPeserta1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lastclaimlensa = lastItemClaim("lensa", Session["nrp1"].ToString(), ddlPeserta1.SelectedValue.ToString());
            string lastclaimframe = lastItemClaim("frame", Session["nrp1"].ToString(), ddlPeserta1.SelectedValue.ToString());
            //string lastclaimlensa = lastItemClaim("lensa", "376", ddlPeserta1.SelectedValue.ToString());
            //string lastclaimframe = lastItemClaim("frame", "376", ddlPeserta1.SelectedValue.ToString());
            lbllastclaimframe.Text = lastclaimframe;
            lbllastclaimlens.Text = lastclaimlensa;
            hidClaimant1.Value = ddlPeserta1.SelectedValue.ToString();
            updlblframe.Update();
            updlbllens.Update();
            updhid1.Update();
        }


        String validPeserta()
        {
            String errorMsg = "";
            if(String.IsNullOrEmpty(ddlPeserta1.SelectedValue)==false)
            {
                if (getClaimKMElig1(Session["nrp1"].ToString()) == false)
                {
                    errorMsg = "Masa kepegawaian anda belum mencapai 1 tahun / belum dijadikan karyawan tetap";
                }
            }
            else
            {
                errorMsg = "Anda belum memilih peserta";
            }
            return errorMsg;
        }

        String validClaimFrame()
        {
            String errorMsg = "";
            String datetimeserv = Convert.ToDateTime(getDateFromServ()).ToString("dd-MMM-yyyy");

            if (ddlItemClaimLensa.SelectedValue == "KCM_LC01" && String.IsNullOrEmpty(ddlItemClaimFrame.SelectedValue) == false)
            {
                errorMsg = "Anda tidak bisa mengajukan klaim frame bersama dengan klaim lensa kontak";
            }

            if (ddlItemClaimLensa.SelectedValue == "KCM_LC02" && String.IsNullOrEmpty(ddlItemClaimFrame.SelectedValue) == false)
            {
                errorMsg = "Anda tidak bisa mengajukan klaim frame bersama dengan klaim lensa kontak";
            }

            if (String.IsNullOrEmpty(ddlItemClaimFrame.SelectedValue) == true && String.IsNullOrEmpty(ddlItemClaimLensa.SelectedValue) == true)
            {
                errorMsg = "Anda belum memilih jenis frame/lensa yang diajukan";
            }

            if (String.IsNullOrEmpty(ddlItemClaimFrame.SelectedValue) == false
                 && string.IsNullOrEmpty(txtItemAmtClaimFrame.Text) == true)
            {
                errorMsg = "Anda belum memasukkan jumlah klaim frame yang diajukan";
            }

            if (string.IsNullOrEmpty(ddlItemClaimFrame.SelectedValue) == false)
            {
                if (Convert.ToDateTime(datetimeserv) <= Convert.ToDateTime(hidframeelig1.Value) &&
                    String.IsNullOrEmpty(lbllastclaimframe.Text) == false)
                {
                    errorMsg = "Klaim frame anda hanya bisa dilakukan " + hidframeyear1.Value
                               + " tahun sekali. Silahkan mengajukan lagi pada tanggal : "
                               + hidframeelig1.Value;
                }
            }

            if(isValidNumber(txtItemAmtClaimFrame.Text.Trim())==false)
            {
                errorMsg = "Cek kembali jumlah klaim anda";
            }

            if (string.IsNullOrEmpty(txtItemAmtClaimFrame.Text.Trim()) == false)
            {
                if (Convert.ToDouble(txtItemAmtClaimFrame.Text.Trim()) > Convert.ToDouble(hidlimitframe1.Value))
                {
                    errorMsg = "Jumlah klaim anda melebihi limit";
                }
            }

            return errorMsg;
        }

        String validClaimLensa()
        {
            string errorMsg = "";
            String datetimeserv = Convert.ToDateTime(getDateFromServ()).ToString("dd-MMM-yyyy");

            if (ddlItemClaimLensa.SelectedValue == "KCM_LC01" && String.IsNullOrEmpty(ddlItemClaimFrame.SelectedValue) == false)
            {
                errorMsg = "Anda tidak bisa mengajukan klaim frame bersama dengan klaim lensa kontak";
            }

            if (ddlItemClaimLensa.SelectedValue == "KCM_LC02" && String.IsNullOrEmpty(ddlItemClaimFrame.SelectedValue) == false)
            {
                errorMsg = "Anda tidak bisa mengajukan klaim frame bersama dengan klaim lensa kontak";
            }

            if (String.IsNullOrEmpty(ddlItemClaimLensa.SelectedValue) == false
                && string.IsNullOrEmpty(txtItemAmtClaimLensa.Text) == true)
            {
               errorMsg = "Anda belum memasukkan jumlah klaim lensa yang diajukan";
            }

            if (string.IsNullOrEmpty(ddlItemClaimLensa.SelectedValue) == false)
            {
                if (Convert.ToDateTime(datetimeserv) <= Convert.ToDateTime(hidlensaelig1.Value) && 
                    String.IsNullOrEmpty (lbllastclaimlens.Text) == false)
                {
                    errorMsg = "Klaim lensa/lensa kontak anda hanya bisa dilakukan " + hidlensayear1.Value
                                + " tahun sekali. Silahkan mengajukan lagi pada tanggal : "
                                + hidlensaelig1.Value;
                }
            }

            if (isValidNumber(txtItemAmtClaimFrame.Text.Trim()) == false)
            {
                errorMsg = "Cek kembali jumlah klaim anda";
            }

            if (string.IsNullOrEmpty(txtItemAmtClaimLensa.Text.Trim()) == false)
            {

                if (Convert.ToDouble(txtItemAmtClaimLensa.Text.Trim()) > Convert.ToDouble(hidlimitlensa1.Value))
                {
                    errorMsg = "Jumlah claim anda melebihi limit";
                }
            }

            return errorMsg;
        }

        public Boolean isValidNumber(string text1)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            return regex.IsMatch(text1);
        }


        String getLimitClaimKM1(String parnrp1, String paritemcode1)
        {
            String strlimitclaim1 = "";

            if (string.IsNullOrEmpty(parnrp1) == false)
            {

                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getclaimlimitkm/" + parnrp1 + "/" + paritemcode1;
                //var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpatient/" + "6386";
                //Console.WriteLine(url.ToString());
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    string jsonstr = Convert.ToString(result);

                    var result1 = JsonConvert.DeserializeObject<ItemLimitClaim1>(jsonstr);

                    if (String.IsNullOrEmpty(result1.getClaimLimitKM1Result.ToString()) == false)
                    {
                        strlimitclaim1 = "Limit Claim : " 
                            + String.Format("{0:#,0}", Convert.ToDouble(result1.getClaimLimitKM1Result.amount1.ToString()));

                        if(paritemcode1== "KCM_FB01")
                        {
                            hidframeyear1.Value = result1.getClaimLimitKM1Result.yearclaimlimit1.ToString();
                            hidlimitframe1.Value = result1.getClaimLimitKM1Result.amount1.ToString();
                        }
                        else
                        {
                            hidlensayear1.Value = result1.getClaimLimitKM1Result.yearclaimlimit1.ToString();
                            hidlimitlensa1.Value = result1.getClaimLimitKM1Result.amount1.ToString();
                        }
                        updhid1.Update();
                    }
                }
            }

            return strlimitclaim1;
        }

        Boolean getClaimKMElig1(String parnrp1)
        {
            Boolean claimElig1 = false;

            if (string.IsNullOrEmpty(parnrp1) == false)
            {

                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/claimkmelig/" + parnrp1;
                //var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpatient/" + "6386";
                //Console.WriteLine(url.ToString());
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    string jsonstr = Convert.ToString(result);

                    var result1 = JsonConvert.DeserializeObject<ClaimKMElig1>(jsonstr);

                    if (String.IsNullOrEmpty(result1.getClaimKMElig1Result.ToString()) == false)
                    {
                        claimElig1 = Convert.ToBoolean(result1.getClaimKMElig1Result.ToString());
                    }
                }
            }

            return claimElig1;
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
                var result1 = JsonConvert.DeserializeObject<dateserver1>(jsonstr);
                dateserv1 = result1.GetDateFromServerResult.ToString();
                //if (dateserv1.Contains(".") == true)
                //{
                //    dateserv2 = dateserv1.Replace(".", ":").ToString();
                //}
                //idtrx1 = result1.getDataOvt1Result[0].idtrx.ToString();
            }
            return dateserv1;
        }

        public class dateserver1
        {
            public string GetDateFromServerResult { get; set; }
        }

        public class ClaimKMElig1
        {
            public Boolean getClaimKMElig1Result { get; set; }
        }

        public class ItemLimitClaim1
        {
            public GetClaimLimit1 getClaimLimitKM1Result { get; set; }
        }

        public class GetClaimLimit1
        {
            public string amount1 { get; set; }
            public string kmitemcode1 { get; set; }
            public string yearclaimlimit1 { get; set; }

        }

        protected void ddlItemClaimFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemClaimFrame.SelectedValue != "")
            {
                txtItemAmtClaimFrame.Enabled = true;
                txtItemAmtClaimFrame.BackColor = System.Drawing.Color.White;
                lblLimitClaimFrame.Text = getLimitClaimKM1(Session["nrp1"].ToString(), ddlItemClaimFrame.SelectedValue);
                if (String.IsNullOrEmpty(lbllastclaimframe.Text) == false)
                {
                    hidframeelig1.Value = Convert.ToDateTime(lbllastclaimframe.Text).AddYears(Convert.ToInt16(hidframeyear1.Value)).ToString("dd-MMM-yyyy");
                }
                else
                {
                    hidframeelig1.Value = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                }
                updhid1.Update();
                updlimitframe1.Update();
                updamtframe1.Update();
            }
            else
            {
                lblLimitClaimFrame.Text = "";
                hidframeelig1.Value = "";
                txtItemAmtClaimFrame.Text = "";
                txtItemAmtClaimFrame.Enabled = false;
                txtItemAmtClaimFrame.BackColor = System.Drawing.Color.DarkGray;
                updhid1.Update();
                updlimitframe1.Update();
                updamtframe1.Update();
            }
        }

        protected void ddlItemClaimLensa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemClaimLensa.SelectedValue != "")
            {
                txtItemAmtClaimLensa.Enabled = true;
                txtItemAmtClaimLensa.BackColor = System.Drawing.Color.White;
                lblLimitClaimLensa.Text = getLimitClaimKM1(Session["nrp1"].ToString(), ddlItemClaimLensa.SelectedValue);
                if (String.IsNullOrEmpty(lbllastclaimlens.Text) == false)
                {
                    hidlensaelig1.Value = Convert.ToDateTime(lbllastclaimlens.Text).AddYears(Convert.ToInt16(hidlensayear1.Value)).ToString("dd-MMM-yyyy");
                }
                else
                {
                    hidlensaelig1.Value =  DateTime.Now.Date.ToString("dd-MMM-yyyy");
                }
                updhid1.Update();
                updlimitlensa1.Update();
                updamtlensa1.Update();
            }
            else
            {
                lblLimitClaimLensa.Text = "";
                hidlensaelig1.Value = "";
                txtItemAmtClaimLensa.Text = "";
                txtItemAmtClaimLensa.Enabled = false;
                txtItemAmtClaimLensa.BackColor = System.Drawing.Color.DarkGray;
                updhid1.Update();
                updlimitlensa1.Update();
                updamtlensa1.Update();
            }
        }

        String convertToEssCode(string code1)
        {
            string codereturn1 = "";

            switch (code1.Trim())
            {
                case "KCM_LB01": codereturn1 = "Claim Lensa MFc Biasa";break;
                case "KCM_LB02": codereturn1 = "Claim Lensa MFc Silindris";break;
                case "KCM_LB03": codereturn1 = "Claim Lensa BFc Biasa";break;
                case "KCM_LB04": codereturn1 = "Claim Lensa BFc Silindris"; break;
                case "KCM_LB05": codereturn1 = "Claim Len Kontak Biasa"; break;
                case "KCM_LB06": codereturn1 = "Claim LenKontak Silindris"; break;
                default: codereturn1 = "";break;
            }
            return codereturn1;
        }

        void popUpMsgBox(string msg1)
        {
            StringBuilder sb = new StringBuilder();
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