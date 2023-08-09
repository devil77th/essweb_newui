using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_overtime_add_confirm : System.Web.UI.UserControl
    {
        static string nrp1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                nrp1 = Session["nrp1"].ToString();
                //nrp1 = "2000";
                lblDateOT.Text = Session["datereqot_" + nrp1].ToString();
                lblTimeOTIn.Text = Session["timereqot1_" + nrp1].ToString();
                lblTimeOTOut.Text = Session["timereqot2_" + nrp1].ToString();
                lblReasonOT.Text = Session["reasonot_" + nrp1].ToString();
            }
        }

        protected void cmdSubmitOT_Click(object sender, EventArgs e)
        {
            AddRequestOT(nrp1, lblTimeOTIn.Text, lblTimeOTOut.Text, lblReasonOT.Text);
            Session.Remove("datereqot_" + nrp1);
            Session.Remove("timereqot1_" + nrp1);
            Session.Remove("timereqot2_" + nrp1);
            Session.Remove("reasonot_" + nrp1);
            popUpMsgBox("Request anda sukses tersubmit ke server");
        }

        protected void cmdCancelOT_Click(object sender, EventArgs e)
        {
            Session.Remove("datereqot_" + nrp1);
            Session.Remove("timereqot1_" + nrp1);
            Session.Remove("timereqot2_" + nrp1);
            Session.Remove("reasonot_" + nrp1);
            Response.Redirect("request_overtime_list.aspx");
        }

        void AddRequestOT(string parnrp1,string pardateot1,string pardateot2,string parreason1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/inserttrxot";
            object input = new
            {
                nrp1 = parnrp1,
                dateot1 = pardateot1,
                dateot2 = pardateot2,
                reason1 = parreason1
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
                    
                }
            }
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='request_overtime_list.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

    }
}