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
    public partial class pagecode_delete_record_wfh : System.Web.UI.UserControl
    {
        static DataTable dtable1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdCheckWFH_Click(object sender, EventArgs e)
        {
            UpdateDList();
        }

        void UpdateDList()
        {
            DataTable dl1 = getApprovalCICOData(txtNRP.Text.Trim(),txtDateCICOWFH.Text.Trim());
            dlCICO1.DataSource = dl1;
            dlCICO1.DataBind();
        }

        protected void dlCICO1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxCICO");
            string idtrx = hidval11.Value;

            if (e.CommandName == "cmdDelete")
            {
                delCICOWFH(idtrx);
            }
            UpdateDList();
            updDataListCICO1.Update();
        }

        void delCICOWFH(string idtrx1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/delcicowfh/" + idtrx1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        static DataTable getApprovalCICOData(string nrp1,string date1)
        {
            date1 = date1.Replace("-", "_");
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listcicowfh_nrpdate/" + nrp1 + "/" + date1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var settings1 = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result1 = JsonConvert.DeserializeObject<GetListTrxCICOResult1>(jsonstr,settings1);

                dtable1 = new DataTable();
                dtable1.Columns.Add("clockCICOWFH1");
                dtable1.Columns.Add("dateCICOWFH1");
                dtable1.Columns.Add("fullnameCICOWFH1");
                dtable1.Columns.Add("idtrxCICOWFH1");
                dtable1.Columns.Add("typeCICOWFH1");

                if (result1.GetListTrxCICOWFH_NRPDateResult.Count > 0)
                {
                    if (result1.GetListTrxCICOWFH_NRPDateResult[0].idtrx1 != "")
                    {
                        for (int i = 0; i <= result1.GetListTrxCICOWFH_NRPDateResult.Count - 1; i++)
                        {
                            dtable1.Rows.Add(result1.GetListTrxCICOWFH_NRPDateResult[i].clockCICO1,
                                result1.GetListTrxCICOWFH_NRPDateResult[i].dateCICO1,
                                result1.GetListTrxCICOWFH_NRPDateResult[i].fullname1,
                                result1.GetListTrxCICOWFH_NRPDateResult[i].idtrx1,
                                result1.GetListTrxCICOWFH_NRPDateResult[i].typeCICO1);
                        }
                    }

                }
                return dtable1;
            }
        }

        public class GetListTrxCICOResult1
        {
            public List<empCICO> GetListTrxCICOWFH_NRPDateResult { get; set; }
        }

        public class empCICO
        {
            public string clockCICO1 { get; set; }
            public string dateCICO1 { get; set; }
            public string fullname1 { get; set; }
            public string idtrx1 { get; set; }
            public string typeCICO1 { get; set; }
        }
    }
}