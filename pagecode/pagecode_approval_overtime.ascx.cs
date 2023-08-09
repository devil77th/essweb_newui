using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_approval_overtime : System.Web.UI.UserControl
    {
        static DataTable dtable1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                UpdateDList();
            }
        }

        string decData(string str1)
        {
            byte xorConstant = 0x53;
            string input = str1;
            byte[] data = Convert.FromBase64String(input);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            string plainText = Encoding.UTF8.GetString(data);
            return plainText;
        }

        public class GetListTrxOVTResult1
        {
            public List<empOVT> GetListTrxOVTResult { get; set; }
        }

        public class empOVT
        {
            public string fullname { get; set; }
            public string reason { get; set; }
            public string idtrx { get; set; }
            public string timefrom { get; set; }  
            public string timeto { get; set; }
            public string nrp1 { get; set; }
        }

        public class GetCekAppOvt1
        {
            public string CekApproverResult { get; set; }
        }

        static DataTable getApprovalOVTData(string nrp1)
        {
            string jsonstr;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listovt/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetListTrxOVTResult1>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrxOVT1");
                dtable1.Columns.Add("fullnameOVT1");
                dtable1.Columns.Add("reasonOVT1");
                dtable1.Columns.Add("timeFromOVT1");
                dtable1.Columns.Add("timeToOVT1");
                dtable1.Columns.Add("nrp1");


                for (int i = 0; i <= result1.GetListTrxOVTResult.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.GetListTrxOVTResult[i].idtrx,
                        result1.GetListTrxOVTResult[i].fullname,
                        result1.GetListTrxOVTResult[i].reason,
                        result1.GetListTrxOVTResult[i].timefrom,
                        result1.GetListTrxOVTResult[i].timeto,
                        result1.GetListTrxOVTResult[i].nrp1);
                }

                return dtable1;
            }

        }

        void UpdateDList()
        {
            string decStr1 = Request["token1"];
            DataTable dl1 = getApprovalOVTData(decData(decStr1));
            //DataTable dl1 = getApprovalOVTData("748");
            dlOvertime1.DataSource = dl1;
            dlOvertime1.DataBind();
        }

        void updateOVT(string idtrx1, string act1, string nrpapprover1,string nrprequester1)
        {
            int i = cekApprover(nrprequester1,nrpapprover1);
            //int i = 1;
            if (i == 1)
            {
                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/approvalovt/" + idtrx1 + "/" + act1 + "/" + nrpapprover1;
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    string jsonstr = Convert.ToString(result);
                }
            }
                
        }

        int cekApprover(string nrp1,string by1)
        {
            int i = 0;

            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekapp/" + nrp1 + "/" + by1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<GetCekAppOvt1>(jsonstr);
                i = Convert.ToInt16(result1.CekApproverResult);
            }
            return i;
        }

        protected void dlOvertime1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxOVT");
            HiddenField nrpuser1 = (HiddenField)e.Item.FindControl("lblnrp1");
            string idtrx = hidval11.Value;
            string decStr1 = decData(Request["token1"]);

            if (e.CommandName == "cmdApprove")
            {
                updateOVT(idtrx, "1", decStr1,nrpuser1.Value);
            }

            if (e.CommandName == "cmdReject")
            {
                updateOVT(idtrx, "0", decStr1,nrpuser1.Value);
            }

            if (e.CommandName == "cmdEdit")
            {
                Response.Redirect("overtime_edit.aspx?i=" + idtrx + "&token1=" + Request["token1"]);
            }
            UpdateDList();
            updDataListOvertime1.Update();
        }

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            string decStr1 = decData(Request["token1"]);
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateOVT(row1["idtrxOVT1"].ToString(), "1", decStr1, row1["nrp1"].ToString());

                }
                UpdateDList();
            }
        }

        protected void cmdRejectAll_Click(object sender, EventArgs e)
        {
            string decStr1 = decData(Request["token1"]);
            if (dtable1.Rows.Count > 0)
            {
                foreach (DataRow row1 in dtable1.Rows)
                {
                    updateOVT(row1["idtrxOVT1"].ToString(), "0", decStr1,row1["nrp1"].ToString());

                }
                UpdateDList();
            }
        }
    }
}