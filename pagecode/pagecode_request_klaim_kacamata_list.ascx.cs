using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_klaim_kacamata_list : System.Web.UI.UserControl
    {
        static DataTable dtable1, dl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                UpdateDList();
            }
        }

        void UpdateDList()
        {
            //DataTable dl1 = getListOVTData(Session["nrp"].ToString());
            dl1 = getListClaimKM(Session["nrp1"].ToString());
            gvkm1.DataSource = dl1;
            gvkm1.DataBind();
        }

        static DataTable getListClaimKM(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getlistclaimkm/" + nrp1;
            var webrequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<getListClaimKm1Result1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("id1");
                dtable1.Columns.Add("createdate1");
                dtable1.Columns.Add("kodeklaim1");
                dtable1.Columns.Add("claimant1");
                dtable1.Columns.Add("claimantname1");
                dtable1.Columns.Add("framecode1");
                dtable1.Columns.Add("frameamt1");
                dtable1.Columns.Add("framedesc1");
                dtable1.Columns.Add("lensacode1");
                dtable1.Columns.Add("lensaamt1");
                dtable1.Columns.Add("lensdesc1");
                dtable1.Columns.Add("statuspengajuan1");


                for (int i = 0; i <= result1.getListClaimKm1Result.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.getListClaimKm1Result[i].id1,
                        result1.getListClaimKm1Result[i].dateclaim1,
                        result1.getListClaimKm1Result[i].kodeklaim1,
                        result1.getListClaimKm1Result[i].claimant1,
                        result1.getListClaimKm1Result[i].claimantname1,
                        result1.getListClaimKm1Result[i].framecode1,
                        result1.getListClaimKm1Result[i].frameprice1,
                        result1.getListClaimKm1Result[i].framedesc1,
                        result1.getListClaimKm1Result[i].lenscode1,
                        result1.getListClaimKm1Result[i].lensprice1,
                        result1.getListClaimKm1Result[i].lensdesc1,
                        result1.getListClaimKm1Result[i].statusclaim1
                        );
                }

                return dtable1;
            }

        }

        public class getListClaimKm1Result1
        {
            public List<dataClaimKM1> getListClaimKm1Result { get; set; }
        }


        public class dataClaimKM1
        {
            public string id1 { get; set; }
            public string kodeklaim1 { get; set; }
            public string statusclaim1 { get; set; }
            public string claimant1 { get; set; }
            public string claimantname1 { get; set; }
            public string dateclaim1 { get; set; }
            public string framecode1 { get; set; }
            public string frameprice1 { get; set; }
            public string framedesc1 { get; set; }
            public string lenscode1 { get; set; }
            public string lensprice1 { get; set; }
            public string lensdesc1 { get; set; }
        }

        protected void gvkm1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvkm1.PageIndex = e.NewPageIndex;
            gvkm1.DataSource = dl1;
            gvkm1.DataBind();
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_klaim_kacamata_add.aspx");
        }

        protected void gvkm1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.ToString() == "cmdKmSelect")
            {
                Response.Redirect("request_klaim_kacamata_detail.aspx?id1=" + e.CommandArgument.ToString());
            }

        }
    }
}