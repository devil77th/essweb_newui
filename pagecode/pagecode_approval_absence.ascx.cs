using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_approval_absence : System.Web.UI.UserControl
    {
        static DataTable dtable1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                UpdateDListAbsence();
            }
            if (dtable1.Rows.Count > 0)
            {
                cmdApproveAll.Enabled = true;
                cmdRejectAll.Enabled = true;
            }
            else
            {
                cmdApproveAll.Enabled = false;
                cmdRejectAll.Enabled = false;
            }
        }

        static DataTable getDataAbsence(string nrp1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listapprovalabs/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetListTrxAbsenceResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("datefromAbsence1");
                dtable1.Columns.Add("datetoAbsence1");
                dtable1.Columns.Add("fullnameAbsence1");
                dtable1.Columns.Add("idtrxAbsence1");
                dtable1.Columns.Add("numdaysAbsence1");
                dtable1.Columns.Add("absenceTypeName1");


                for (int i = 0; i <= result1.GetListApprovalResult.Count-1; i++)
                {

                    dtable1.Rows.Add(result1.GetListApprovalResult[i].cdatefrom,
                        result1.GetListApprovalResult[i].cdateto,
                        result1.GetListApprovalResult[i].fullname,
                        result1.GetListApprovalResult[i].idtrx,
                        result1.GetListApprovalResult[i].numdays,
                        result1.GetListApprovalResult[i].absencetypename);
                }

                return dtable1;
            }
        }

        void UpdateDListAbsence()
        {
            DataTable dl1 = getDataAbsence((string)Session["nrp1"]);
            dlAbsence1.DataSource = dl1;
            dlAbsence1.DataBind();
        }

        void updateAbsence(string idtrx1, string act1, string nrp1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/subapprovalabs/" + idtrx1 + "/" + act1 + "/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        public class GetListTrxAbsenceResult1
        {
            public List<empAbsence> GetListApprovalResult { get; set; }
        }

        public class empAbsence
        {
            public string cdatefrom { get; set; }
            public string cdateto { get; set; }
            public string fullname { get; set; }
            public string idtrx { get; set; }
            public string numdays { get; set; }
            public string absencetypename { get; set; }
        }

        protected void dlAbsence1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxAbsence");
            string idtrx = hidval11.Value;

            if (e.CommandName == "cmdApprove")
            {
                updateAbsence(idtrx, "1", (string)Session["nrp1"]);
            }

            if (e.CommandName == "cmdReject")
            {
                updateAbsence(idtrx, "0", (string)Session["nrp1"]);
            }
            UpdateDListAbsence();
            updDataListAbsence1.Update();
        }

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateAbsence(row1["idtrxAbsence1"].ToString(), "1", (string)Session["nrp1"]);

                }
                UpdateDListAbsence();
            }
        }

        protected void cmdRejectAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateAbsence(row1["idtrxAbsence1"].ToString(), "0", (string)Session["nrp1"]);

                }
                UpdateDListAbsence();
            }
        }
    }
    
}