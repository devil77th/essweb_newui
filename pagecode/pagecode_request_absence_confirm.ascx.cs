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
    public partial class pagecode_request_absence_confirm : System.Web.UI.UserControl
    {
        static string _5000,_5001,date1,date2;

       

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Page.IsPostBack==false)
            {
                lblTypeAbsence1.Text = Session["textreqabs1"].ToString();
                lblDateAbsence1.Text = Session["datereqabs1"].ToString() + " - " + Session["datereqabs2"].ToString();
                lblNumDaysAbsence1.Text = Session["numdaysreqabs1"].ToString();
                hidValTypeAbs1.Value = Session["typereqabs1"].ToString();
                _5000 = Session["5000"].ToString();
                _5001 = Session["5001"].ToString();
                date1 = Session["datereqabs1"].ToString();
                date2 = Session["datereqabs2"].ToString();
            }
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_absence_list.aspx");
        }

        static void SubmitAbsence(string nrp1,string type1,string datefrom,string dateto,string num1,string sisa1)
        {
            datefrom = datefrom.Replace("-", "_");
            dateto = dateto.Replace("-", "_");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subonleave/" + nrp1 + "/" + type1 + "/" + datefrom +
                "/" + dateto + "/" + num1 + "/" + sisa1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                //var result1 = JsonConvert.DeserializeObject<cekOnleaveResult1>(jsonstr);
                //flg1 = Convert.ToBoolean(result1.cekOnleaveResult[0].flgTrx);
                //numdays1 = Convert.ToInt16(result1.cekOnleaveResult[0].numOnleave);
            }
            
        }

        protected void cmdSubmitCICO_Click(object sender, EventArgs e)
        {
            string sisa1;
            if(hidValTypeAbs1.Value=="5000")
            {
                sisa1 = _5000;
            }
            else if(hidValTypeAbs1.Value=="5001")
            {
                sisa1 = _5001;
            }
            else
            {
                sisa1 = "1";
            }
            SubmitAbsence(Session["nrp1"].ToString(), hidValTypeAbs1.Value,
                date1, date2, lblNumDaysAbsence1.Text, sisa1);
            popUpMsgBox("Request anda sukses tersubmit ke server");
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='request_absence_list.aspx';};");
            sb.Append("");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }
    }
}