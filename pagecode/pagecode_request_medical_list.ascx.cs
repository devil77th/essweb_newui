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
    public partial class pagecode_request_medical_list : System.Web.UI.UserControl
    {
        static DataTable dtable1,dl1;
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
            dl1 = getListMedData(Session["nrp1"].ToString());
            gvmed1.DataSource = dl1;
            gvmed1.DataBind();
        }

        static DataTable getListMedData(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmednrp/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<ListMedicalTrxByNRPResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrx1");
                dtable1.Columns.Add("createdate1");
                dtable1.Columns.Add("namapasien1");
                dtable1.Columns.Add("tglkuitansi1");
                dtable1.Columns.Add("diagnosa1");
                dtable1.Columns.Add("kodeklaim1");
                dtable1.Columns.Add("statuspengajuan1");
                dtable1.Columns.Add("tglapproval1");

                for (int i = 0; i <= result1.GetListTrxMedByNRPResult.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.GetListTrxMedByNRPResult[i].idtrx,
                        result1.GetListTrxMedByNRPResult[i].createdate,
                        result1.GetListTrxMedByNRPResult[i].namapasien,
                        result1.GetListTrxMedByNRPResult[i].receiptdate,
                        result1.GetListTrxMedByNRPResult[i].diagnosa,
                        result1.GetListTrxMedByNRPResult[i].kodeklaim,
                        result1.GetListTrxMedByNRPResult[i].statusapproval,
                        result1.GetListTrxMedByNRPResult[i].tglapproval1);
                }

                return dtable1;
            }

        }

        public class ListMedicalTrxByNRPResult1
        {
            public List<dataMed1> GetListTrxMedByNRPResult { get; set; }
        }

        public class dataMed1
        {
            public string idtrx { get; set; }
            public string createdate { get; set; }
            public string namapasien { get; set; }
            public string receiptdate { get; set; }
            public string diagnosa { get; set; }
            public string kodeklaim { get; set; }
            public string statusapproval { get; set; }
            public string tglapproval1 { get; set; }
        }

      

        protected void gvmed1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string temp1 = e.CommandName.ToString();
            if(temp1=="cmdMedSelect")
            {
                Response.Redirect("request_medical_detail.aspx?trx1=" + e.CommandArgument.ToString());
            }
        }

        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_medical_add.aspx");
        }

        protected void gvmed1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmed1.PageIndex = e.NewPageIndex;
            gvmed1.DataSource = dl1;
            gvmed1.DataBind();
        }
    }
}