using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.page
{
    public partial class login : System.Web.UI.Page
    {
        public static string jsonstr,nrp1,emailadd1,displayname1,sisacutibesar1,sisacutitahunan1,gol;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            string userName1, password1;
            Boolean flgLogin;
            userName1 = txtUsername.Text.Trim().ToLower();
            password1 = txtPassword.Text.Trim();
            password1 = Base64Encode1(password1);
            //password1 = HttpUtility.UrlEncode(password1);
            var ws = new ws1.Service1();
            ws.authUser64(userName1, password1, out flgLogin, out _);
            if(flgLogin==false)
            {
                ShowMessage("Username / password yang anda masukkan salah", MessageType1.Error);
            }
            else
            {
                getPersonalData(userName1);
                //getPersonalData("trac\\bayu008646");
                if(String.IsNullOrEmpty(nrp1)==false || String.IsNullOrEmpty(emailadd1)==false)
                {
                    Session.Add("username1", userName1);
                    //Session.Add("username1", "ida005121");
                    Session.Add("nrp1", nrp1);
                    //Session.Add("nrp1", "3982");
                    Session.Add("emailadd1", emailadd1);
                    Session.Add("fullname1", displayname1);
                    Session.Add("5000", sisacutitahunan1);
                    Session.Add("5001", sisacutibesar1);
                    Session.Add("gol", gol);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    ShowMessage("Mohon maaf , terjadi kesalahan pada sistem. Silahkan mencoba lagi dalam beberapa menit", MessageType1.Info);
                }
               
            }
        }

        public enum MessageType1 { Success, Error, Info, Warning };

        

        protected void ShowMessage(string Message, MessageType1 type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        void getPersonalData(string userid1)
        {
            //userid1 = "rap";
            if(userid1.Trim().Contains("trac\\")==true || userid1.Trim().Contains("TRAC\\")==true ||
                userid1.Trim().Contains("Trac\\")==true)
            {
                userid1 = userid1.Substring(5);
            }

            if(userid1.Trim().Contains("@"))
            {
                int idx1 = userid1.Trim().IndexOf("@");
                userid1 = userid1.Substring(0, idx1);
            }
            //userid1 = "SBT00006215";

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/profile/" + userid1.Trim(); 
            

            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetEmpProfileResult1>(jsonstr);
                nrp1=result1.GetEmpProfileResult[0].nrp.ToString();
                emailadd1 = result1.GetEmpProfileResult[0].emailadd.ToString();
                displayname1 = result1.GetEmpProfileResult[0].displayname.ToString();
                sisacutibesar1 = result1.GetEmpProfileResult[0].remaincutibesar.ToString();
                sisacutitahunan1 = result1.GetEmpProfileResult[0].remaincutitahunan.ToString();
                gol = result1.GetEmpProfileResult[0].gol.ToString();
            }

        }

        public static string Base64Encode1(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public class GetEmpProfileResult1
        {
            public List<empData> GetEmpProfileResult { get; set; }
        }

        public class empData
        {
            public string displayname { get; set; }
            public string emailadd { get; set; }
            public string nrp { get; set; }
            public string remaincutibesar { get; set; }
            public string remaincutitahunan { get; set; }
            public string location { get; set; }
            public string gol { get; set; }
        }



    }
}