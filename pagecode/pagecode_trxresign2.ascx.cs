using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.class1;
using static WebApplication1.class1.dataclass1;

namespace WebApplication1.pagecode
{
    public partial class pagecode_trxresign2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                linkFiletemplate();
                getUploadData2();

                if(function1.Base64Decode1(Request["cf1"].ToString()) == "1")
                {
                    cmdSubmitResign1.Enabled = false;
                }
                else
                {
                    cmdSubmitResign1.Enabled = true; 
                }

            }
        }

        void linkFiletemplate()
        {
            hy_ClrSheet.NavigateUrl = "~/page/downloadatt.aspx?type1=02&typef=template";
            hy_ExitSurvey.NavigateUrl = "~/page/downloadatt.aspx?type1=03&typef=template";
            hy_FormKoperasi.NavigateUrl = "~/page/downloadatt.aspx?type1=04&typef=template";
            hy_FormPensiun.NavigateUrl = "~/page/downloadatt.aspx?type1=05&typef=template";
            hy_KlaimDPLK.NavigateUrl = "~/page/downloadatt.aspx?type1=07&typef=template";
            hy_SuratKuasa.NavigateUrl = "~/page/downloadatt.aspx?type1=09&typef=template";
        }

        void getUploadData2()
        {
            updateLinkUpload01();
            updateLinkUpload02();
            updateLinkUpload03();
            updateLinkUpload04();
            updateLinkUpload05();
            updateLinkUpload06();
            updateLinkUpload07();
        }

        void updateLinkUpload01()
        {
            dataclass1.essbin essbin01 = new dataclass1.essbin();  
            essbin01 = getUploadData(Request["idr"].ToString(), "01");
            if(string.IsNullOrEmpty (essbin01.filename1) == false) 
            { 
                hyUpd_ResignLetter.Text = essbin01.filename1;
                hyUpd_ResignLetter.NavigateUrl = "~/page/downloadatt.aspx?id1=" + Request["idr"].ToString() + "&type1=01&typef=upload";
                cmdUpload_ResignLetter1.Enabled = false;
            }
            else
            {
                hyUpd_ResignLetter.Text = "";
                hyUpd_ResignLetter.NavigateUrl = "";
                cmdUpload_ResignLetter1.Enabled = true;
            }
            upd_ResignLetter2.Update();
        }

        void updateLinkUpload02()
        {
            dataclass1.essbin essbin02 = new dataclass1.essbin();
            essbin02 = getUploadData(Request["idr"].ToString(), "02");
            if (string.IsNullOrEmpty(essbin02.filename1) == false)
            {
                hyUpd_ClrSheet.Text = essbin02.filename1;
                hyUpd_ClrSheet.NavigateUrl = "~/page/downloadatt.aspx?id1=" + Request["idr"].ToString() + "&type1=02&typef=upload";
                cmdUpload_ClrSheet1.Enabled = false;
            }
            else
            {
                hyUpd_ClrSheet.Text = "";
                hyUpd_ClrSheet.NavigateUrl = "";
                cmdUpload_ClrSheet1.Enabled = true;
            }
            upd_ClrSheet2.Update();
        }

        void updateLinkUpload03()
        {
            dataclass1.essbin essbin03 = new dataclass1.essbin();
            essbin03 = getUploadData(Request["idr"].ToString(), "03");
            if (string.IsNullOrEmpty(essbin03.filename1) == false)
            {
                hyUpd_ExitSurvey.Text = essbin03.filename1;
                hyUpd_ExitSurvey.NavigateUrl = "~/page/downloadatt.aspx?id1=" + Request["idr"].ToString() + "&type1=03&typef=upload";
                cmdUpload_ExitSurvey1.Enabled = false;
            }
            else
            {
                hyUpd_ExitSurvey.Text = "";
                hyUpd_ExitSurvey.NavigateUrl = "";
                cmdUpload_ExitSurvey1.Enabled = true;
            }
            upd_ExitSurvey.Update();
        }

        void updateLinkUpload04()
        {
            dataclass1.essbin essbin04 = new dataclass1.essbin();
            essbin04 = getUploadData(Request["idr"].ToString(), "04");
            if (string.IsNullOrEmpty(essbin04.filename1) == false)
            {
                hyUpd_FormKoperasi.Text = essbin04.filename1;
                hyUpd_FormKoperasi.NavigateUrl = "~/page/downloadatt.aspx?id1=" + Request["idr"].ToString() + "&type1=04&typef=upload";
                cmdUpload_AnggotaKoperasi1.Enabled = false;
            }
            else
            {
                hyUpd_FormKoperasi.Text = "";
                hyUpd_FormKoperasi.NavigateUrl = "";
                cmdUpload_AnggotaKoperasi1.Enabled = true;
            }
            upd_FormKoperasi.Update();
        }

        void updateLinkUpload05()
        {
            dataclass1.essbin essbin05 = new dataclass1.essbin();
            essbin05 = getUploadData(Request["idr"].ToString(), "05");
            if (string.IsNullOrEmpty(essbin05.filename1) == false)
            {
                hyUpd_FormPensiun.Text = essbin05.filename1;
                hyUpd_FormPensiun.NavigateUrl = "~/page/downloadatt.aspx?id1=" + Request["idr"].ToString() + "&type1=05&typef=upload";
                cmdUpload_ManfaatPensiun1.Enabled = false;
            }
            else
            {
                hyUpd_FormPensiun.Text = "";
                hyUpd_FormPensiun.NavigateUrl = "";
                cmdUpload_ManfaatPensiun1.Enabled = true;
            }
            upd_FormPensiun.Update();
        }

        void updateLinkUpload06()
        {
            dataclass1.essbin essbin06 = new dataclass1.essbin();
            essbin06 = getUploadData(Request["idr"].ToString(), "06");
            if (string.IsNullOrEmpty(essbin06.filename1) == false)
            {
                hyUpd_KTPNPWP.Text = essbin06.filename1;
                hyUpd_KTPNPWP.NavigateUrl = "~/page/downloadatt.aspx?id1=" + Request["idr"].ToString() + "&type1=06&typef=upload";
                cmdUpload_KTPNPWP.Enabled = false;
            }
            else
            {
                hyUpd_KTPNPWP.Text = "";
                hyUpd_KTPNPWP.NavigateUrl = "";
                cmdUpload_KTPNPWP.Enabled= true;
            }
            upd_KTPNPWP.Update();
        }

        void updateLinkUpload07()
        {
            dataclass1.essbin essbin07 = new dataclass1.essbin();
            essbin07 = getUploadData(Request["idr"].ToString(), "07");
            if (string.IsNullOrEmpty(essbin07.filename1) == false)
            {
                hyUpd_KlaimDPLK.Text = essbin07.filename1;
                hyUpd_KlaimDPLK.NavigateUrl = "~/page/downloadatt.aspx?id1=" + Request["idr"].ToString() + "&type1=07&typef=upload";
                cmdUpload_DPLK1.Enabled = false;
            }
            else
            {
                hyUpd_KlaimDPLK.Text = "";
                hyUpd_KlaimDPLK.NavigateUrl = "";
                cmdUpload_DPLK1.Enabled = true;
            }
            upd_KlaimDPLK.Update();
        }

        public dataclass1.essbin getUploadData(string id1,string type1)
        {
            dataclass1.essbin essbin1 = new dataclass1.essbin();
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/getfile_trxresign/" + id1 + "/" + type1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<class1.dataclass1.fileuploadresign>(jsonstr);

                if (String.IsNullOrEmpty(result1.GetUploadFile_TrxResign1Result.filename1) == false)
                {
                    essbin1.filename1 = result1.GetUploadFile_TrxResign1Result.filename1.ToString();
                }
            }
            return essbin1;
        }

        protected void cmdUpload_ResignLetter1_Click(object sender, EventArgs e)
        {
            if (fu_ResignLetter1.HasFile == true)
            {
                uploadData(Request["idr"].ToString(), "01", fu_ResignLetter1.FileName, Convert.ToBase64String(fu_ResignLetter1.FileBytes),
                    function1.Base64Encode(Session["username1"].ToString()));
                updateLinkUpload01();
            }
        }

        void uploadData(string partrxid1, string partype1, string parfilename1,string parfilebin64,string parusername1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/uploadfile_trxresign";
            object input = new
            {
                trxid1 = partrxid1,
                type1 = partype1,
                filename1 = parfilename1,
                filebin64 = parfilebin64,
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
                    //hidID1.Value = (new StreamReader(stream)).ReadToEnd();
                }
            }
        }

        protected void cmdUpload_ClrSheet1_Click(object sender, EventArgs e)
        {
            if (fu_ClrSheet1.HasFile == true)
            {
                uploadData(Request["idr"].ToString(), "02", fu_ClrSheet1.FileName, Convert.ToBase64String(fu_ClrSheet1.FileBytes),
                   function1.Base64Encode(Session["username1"].ToString()));
                updateLinkUpload02();
            }
        }

        protected void cmdUpload_ExitSurvey1_Click(object sender, EventArgs e)
        {
            if (fu_ExitSurvey1.HasFile == true)
            {
                uploadData(Request["idr"].ToString(), "03", fu_ExitSurvey1.FileName, Convert.ToBase64String(fu_ExitSurvey1.FileBytes),
                   function1.Base64Encode(Session["username1"].ToString()));
                updateLinkUpload03();
            }
        }

        protected void cmdUpload_AnggotaKoperasi1_Click(object sender, EventArgs e)
        {
            if (fu_AnggotaKoperasi1.HasFile == true)
            {
                uploadData(Request["idr"].ToString(), "04", fu_AnggotaKoperasi1.FileName, Convert.ToBase64String(fu_AnggotaKoperasi1.FileBytes),
                   function1.Base64Encode(Session["username1"].ToString()));
                updateLinkUpload04();
            }
        }

        protected void cmdDeleteDokResign1_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/delfile_dokresign/" + Request["idr"].ToString();
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

            }
            getUploadData2();
        }

        protected void cmdUpload_ManfaatPensiun1_Click(object sender, EventArgs e)
        {
            if (fu_ManfaatPensiun1.HasFile == true)
            {
                uploadData(Request["idr"].ToString(), "05", fu_ManfaatPensiun1.FileName, Convert.ToBase64String(fu_ManfaatPensiun1.FileBytes),
                   function1.Base64Encode(Session["username1"].ToString()));
                updateLinkUpload05();
            }
        }

        protected void cmdUpload_KTPNPWP_Click(object sender, EventArgs e)
        {
            if (fu_KTPNPWP.HasFile == true)
            {
                uploadData(Request["idr"].ToString(), "06", fu_KTPNPWP.FileName, Convert.ToBase64String(fu_KTPNPWP.FileBytes),
                   function1.Base64Encode(Session["username1"].ToString()));
                updateLinkUpload06();
            }
        }

        protected void cmdUpload_DPLK1_Click(object sender, EventArgs e)
        {
            if (fu_DPLK1.HasFile == true)
            {
                uploadData(Request["idr"].ToString(), "07", fu_DPLK1.FileName, Convert.ToBase64String(fu_DPLK1.FileBytes),
                   function1.Base64Encode(Session["username1"].ToString()));
                updateLinkUpload07();
            }
        }

        protected void cmdDeleteDokDPA_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/delfile_dokdpa/" + Request["idr"].ToString();
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

            }
            getUploadData2();
        }

        protected void cmdSubmitResign1_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/updstatus_trxresign_emp/" + Request["idr"].ToString();
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

            }
            Response.Redirect("trxresign.aspx");
        }
    }
}