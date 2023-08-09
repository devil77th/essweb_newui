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
    public partial class pagecode_approval_attendance : System.Web.UI.UserControl
    {
        static DataTable dtable1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                UpdateDListAttendance();
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

        public class GetListTrxAttendanceResult1
        {
            public List<empAttendance> GetListApprovalAttendanceResult { get; set; }
        }

        public class empAttendance
        {
            public string attendcode { get; set; }
            public string dateattend { get; set; }
            public string fullname { get; set; }
            public string timefrom { get; set; }
            public string timeto { get; set; }
            public string idtrx { get; set; }
        }

        static DataTable getDataAttendance(string nrp1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listattend/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetListTrxAttendanceResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("dateAttendance1");
                dtable1.Columns.Add("timeFrom1");
                dtable1.Columns.Add("timeTo1");
                dtable1.Columns.Add("idtrxAttendance1");
                dtable1.Columns.Add("fullName1");
                dtable1.Columns.Add("typeAttendance1");


                for (int i = 0; i <= result1.GetListApprovalAttendanceResult.Count - 1; i++)
                {

                    dtable1.Rows.Add(result1.GetListApprovalAttendanceResult[i].dateattend,
                       result1.GetListApprovalAttendanceResult[i].timefrom,
                       result1.GetListApprovalAttendanceResult[i].timeto,
                       result1.GetListApprovalAttendanceResult[i].idtrx,
                       result1.GetListApprovalAttendanceResult[i].fullname,
                       result1.GetListApprovalAttendanceResult[i].attendcode
                       );
                }

                return dtable1;
            }
        }

        void UpdateDListAttendance()
        {
            DataTable dl1 = getDataAttendance((string)Session["nrp1"]);
            dlAttendance1.DataSource = dl1;
            dlAttendance1.DataBind();
        }

        void updateAttendance(string idtrx1, string act1, string nrp1)
        {
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/approveatt/" + idtrx1 + "/" + nrp1 + "/" + act1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
            }
        }

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateAttendance(row1["idtrxAttendance1"].ToString(), "WFSTS_02", (string)Session["nrp1"]);

                }
                UpdateDListAttendance();
            }
        }

        protected void cmdRejectAll_Click(object sender, EventArgs e)
        {
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateAttendance(row1["idtrxAttendance1"].ToString(), "WFSTS_03", (string)Session["nrp1"]);

                }
                UpdateDListAttendance();
            }
        }

        protected void dlAttendance1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxAttendance");
            string idtrx = hidval11.Value;

            if (e.CommandName == "cmdApprove")
            {
                updateAttendance(idtrx, "WFSTS_02", (string)Session["nrp1"]);
            }

            if (e.CommandName == "cmdReject")
            {
                updateAttendance(idtrx, "WFSTS_03", (string)Session["nrp1"]);
            }
            UpdateDListAttendance();
            updDataListAttendance1.Update();
        }

        
    }
}