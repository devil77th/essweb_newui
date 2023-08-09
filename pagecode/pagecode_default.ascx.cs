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
    public partial class pagecode_default : System.Web.UI.UserControl
    {
        string strdpsession1, emailadd1,strdp64_1,errFlg="";

        protected void imgApproval1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_menu.aspx");
        }

        protected void imgRequest1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_menu.aspx");
        }

        protected void rptabsencesub_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("report_absence_subordinate.aspx");
        }

        protected void imgWFH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_menu_wfh.aspx");
        }

        protected void imgWFO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_menu_wfo.aspx");
        }


        protected void imgClaim_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("claim_menu.aspx");
        }

        protected void imgLink_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("link_menu.aspx");
        }

        protected void imgProfile1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("profile_employee.aspx");
        }

        protected void imgPersonnel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("personnel_menu.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           if (Page.IsPostBack == false)
            {
                strdpsession1 = (string)Session["strdp64"];
                emailadd1 = (string)Session["emailadd1"];
                if(String.IsNullOrEmpty(strdpsession1)==true)
                {
                    getProfileDP();
                }
                else
                {
                    strdp64_1 = strdpsession1;
                }
                
                if(errFlg=="" || errFlg == null)
                {
                    imgProfile1.ImageUrl = String.Format(@"data:image/jpeg;base64,{0}", strdp64_1);
                }
                else
                {
                    imgProfile1.ImageUrl =  "~/img/blankprofile.png";
                }
                lblFullname.Text = (string)Session["fullname1"];
                lblEmail.Text = (string)Session["emailadd1"];
            }
        }

        void getProfileDP()
        {
                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/profiledp/" + emailadd1.Trim();
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                webrequest.Timeout = 15000;
                string jsonstr;
                try
                {
                    using (var response = webrequest.GetResponse())
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var result = reader.ReadToEnd();
                        jsonstr = Convert.ToString(result);
                        var result1 = JsonConvert.DeserializeObject<strdp64>(jsonstr);
                        strdp64_1 = result1.GetEmpProfileDPResult.ToString();
                        Session.Add("strdp64", strdp64_1);
                    }
                }
                catch (Exception ex)
                {
                    errFlg = ex.ToString();
                }
            }
           
        

        public class strdp64
        {
            public string GetEmpProfileDPResult;
        }
    }
}