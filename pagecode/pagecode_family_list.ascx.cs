using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_family_list : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                FillData1();
            }
        }

        void FillData1()
        {
            DataTable dl1 = getListFamilyMember(Session["nrp1"].ToString());
            gvfamily1.DataSource = dl1;
            gvfamily1.DataBind();
        }

        public static string Base64Decode1(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        static DataTable getListFamilyMember(string nrp1)
        {
            string jsonstr;
            DataTable dtable1;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listfamilymember/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webrequest.Timeout = 10000;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<listfamily1>(jsonstr);
                String status2="";
                dtable1 = new DataTable();
                dtable1.Columns.Add("idfamily1");
                dtable1.Columns.Add("jeniskelamin1");
                dtable1.Columns.Add("nama1");
                dtable1.Columns.Add("negarakelahiran1");
                dtable1.Columns.Add("status1");
                dtable1.Columns.Add("tempatlahir1");
                dtable1.Columns.Add("tgllahir1");

                for (int i = 0; i <= result1.GetListFamilyMemberByNRPResult.Count - 1; i++)
                {
                    if (Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].status1) == "1")
                    {
                        status2 = "Suami/Istri";
                    }
                    else if(Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].status1) == "2")
                    {
                        status2 = "Anak";
                    }
                    else if (Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].status1) == "3")
                    {
                        status2 = "Istri";
                    }

                    dtable1.Rows.Add
                        (
                        result1.GetListFamilyMemberByNRPResult[i].idfamily1,
                        Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].jeniskelamin1),
                        Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].nama1),
                        Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].negarakelahiran1),
                        status2,
                        Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].tempatlahir1),
                        Convert.ToDateTime(Base64Decode1(result1.GetListFamilyMemberByNRPResult[i].tgllahir1)).ToString("dd-MMM-yyyy")
                        );
                }
                return dtable1;
            }

        }

        public class listfamily1
        {
            public List<family1> GetListFamilyMemberByNRPResult { get; set; }
        }

        public class family1
        {
            public string idfamily1 { get; set; }
            public string jeniskelamin1 { get; set; }
            public string nama1 { get; set; }
            public string negarakelahiran1 { get; set; }
            public string status1 { get; set; }
            public string tempatlahir1 { get; set; }
            public string tgllahir1 { get; set; }

        }

        protected void gvfamily1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Redirect("family_list_edit.aspx?id1=" + e.CommandArgument.ToString());
        }

        protected void cmdAdd1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("family_list_add.aspx");
        }
    }
}