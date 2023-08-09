using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_approval_overtime_hr : System.Web.UI.UserControl
    {
        static DataTable dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string nrp1 = Session["nrp1"].ToString();
                if (nrp1.ToString() == "1138" || nrp1.ToString() == "1099")
                {

                }
                else
                {
                    Response.Redirect("approval_menu.aspx");
                }
            }
        }

        protected void cmdFilter_Click(object sender, EventArgs e)
        {
            dl1 = LoadDataOvt(txtfilterNRPreq.Text.Trim(), txtfilterNRPapp.Text.Trim(),
                                        txtfilterDate1.Text.Trim(), txtfilterDate2.Text.Trim(), ddlStatus1.SelectedValue);
            gvovt1.DataSource = dl1;
            gvovt1.DataBind();
            updDataListOvertime1.Update();
        }

        static DataTable LoadDataOvt(String nrpreq1, String nrpapprover1, string sdate1, string edate1, string parstatus1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/lstovthr";
            object input = new
            {
                nrpreq = nrpreq1,
                nrpapprover = nrpapprover1,
                sdate = sdate1,
                edate = edate1,
                status1 = parstatus1
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
                    jsonstr = (new StreamReader(stream)).ReadToEnd();
                    var result1 = JsonConvert.DeserializeObject<class1.dataclass1.lstOvtHRResult>(jsonstr);
                    dtable1 = new DataTable();
                    dtable1.Columns.Add("idtrx1");
                    dtable1.Columns.Add("fullname1");
                    dtable1.Columns.Add("nrp1");
                    dtable1.Columns.Add("timefrom1");
                    dtable1.Columns.Add("timeapp1");
                    dtable1.Columns.Add("status1");
                    dtable1.Columns.Add("nameapprover1");
                    
                    for (int i = 0; i <= result1.listapproval_ovt_hrResult.Count - 1; i++)
                    {
                        dtable1.Rows.Add
                            (
                                result1.listapproval_ovt_hrResult[i].idtrx.ToString(),
                                result1.listapproval_ovt_hrResult[i].fullname.ToString(),
                                result1.listapproval_ovt_hrResult[i].nrp1.ToString(),
                                result1.listapproval_ovt_hrResult[i].timefrom.ToString() + " - " +
                                result1.listapproval_ovt_hrResult[i].timeto.ToString(),
                                result1.listapproval_ovt_hrResult[i].timefromapp.ToString() + " - " +
                                result1.listapproval_ovt_hrResult[i].timetoapp.ToString(),
                                result1.listapproval_ovt_hrResult[i].status1.ToString(),
                                result1.listapproval_ovt_hrResult[i].nameapprover1.ToString()
                            ) ;
                    }
                }
            }
            return dtable1;
        }

        protected void gvovt1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvovt1.PageIndex = e.NewPageIndex;
            gvovt1.DataSource = dl1;
            gvovt1.DataBind();
            updDataListOvertime1.Update();
        }

        protected void gvovt1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="cmdOvtSelect")
            {
                Response.Redirect("overtime_edit_hr.aspx?id1=" + e.CommandArgument);
            }
        }
    }
}