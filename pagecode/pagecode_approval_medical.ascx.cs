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
    public partial class pagecode_approval_medical : System.Web.UI.UserControl
    {
        static DataTable dtable1,dtable2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
            {
                GetListPersonalCode();
                listTrxMed((string)Session["nrp1"]);
                //listTrxMed("4581");
            }
        }

        void listTrxMed(string nrp1)
        {
            DataTable dl1 = getApprovalMedData(nrp1);
            dlMed1.DataSource = dl1;
            dlMed1.DataBind();
        }

        static DataTable getApprovalMedData(string nrp1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmed/" + nrp1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<ApprovalListMed>(jsonstr);

                dtable1 = new DataTable();
                dtable1.Columns.Add("idtrx1");
                dtable1.Columns.Add("fullnamereq1");
                dtable1.Columns.Add("namapasien1");
                dtable1.Columns.Add("amount1");
                dtable1.Columns.Add("diagnosa1");
                dtable1.Columns.Add("receiptdate1");
                dtable1.Columns.Add("createdate1");


                for (int i = 0; i <= result1.GetListTrxMedResult.Count - 1; i++)
                {
                    dtable1.Rows.Add(result1.GetListTrxMedResult[i].idtrx,
                        result1.GetListTrxMedResult[i].fullname,
                        result1.GetListTrxMedResult[i].namapasien,
                        String.Format("{0:n0}",Convert.ToDouble(result1.GetListTrxMedResult[i].amount)),
                        result1.GetListTrxMedResult[i].diagnosa,
                        result1.GetListTrxMedResult[i].receiptdate,
                        result1.GetListTrxMedResult[i].createdate
                        );
                }

                return dtable1;
            }

        }

        static DataTable getApprovalMedDataPOST(string parnrp1,string parnrpreq1,string parpatientname1,string parpcode1,string parpsubcode1)
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/listmedpost";
            object input = new
            {
                userid = parnrp1,
                nrpreq1 = parnrpreq1,
                patientname1 = parpatientname1,
                pcode1 = parpcode1,
                psubcode1 = parpsubcode1
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

            dtable2 = new DataTable();
            dtable2.Columns.Add("idtrx1");
            dtable2.Columns.Add("fullnamereq1");
            dtable2.Columns.Add("namapasien1");
            dtable2.Columns.Add("amount1");
            dtable2.Columns.Add("diagnosa1");
            dtable2.Columns.Add("receiptdate1");
            dtable2.Columns.Add("createdate1");

            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (var reader1 = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = reader1.ReadToEnd();
                    jsonstr = Convert.ToString(result);
                    var result1 = JsonConvert.DeserializeObject<ApprovalListMedPOST>(jsonstr);

                    for (int i = 0; i <= result1.GetListTrxMedPostResult.Count - 1; i++)
                    {
                        dtable2.Rows.Add(result1.GetListTrxMedPostResult[i].idtrx,
                            result1.GetListTrxMedPostResult[i].fullname,
                            result1.GetListTrxMedPostResult[i].namapasien,
                            String.Format("{0:n0}", Convert.ToDouble(result1.GetListTrxMedPostResult[i].amount)),
                            result1.GetListTrxMedPostResult[i].diagnosa,
                            result1.GetListTrxMedPostResult[i].receiptdate,
                            result1.GetListTrxMedPostResult[i].createdate
                            );
                    }

                }
            }
            return dtable2;
        }


        public class ApprovalListMed
        {
            public List<trxMed> GetListTrxMedResult { get; set; }
        }

        public class trxMed
        {
            public string amount { get; set; }
            public string createdate { get; set; }
            public string diagnosa { get; set; }
            public string fullname { get; set; }
            public string idtrx { get; set; }
            public string namapasien { get; set; }
            public string sisaamount { get; set; }
            public string receiptdate { get; set; }
            

        }

        public class ApprovalListMedPOST
        {
            public List<trxMedPost> GetListTrxMedPostResult { get; set; }
        }

        public class trxMedPost
        {
            public string amount { get; set; }
            public string createdate { get; set; }
            public string diagnosa { get; set; }
            public string fullname { get; set; }
            public string idtrx { get; set; }
            public string namapasien { get; set; }
            public string sisaamount { get; set; }
            public string receiptdate { get; set; }


        }

        void GetListPersonalCode()
        {
            string jsonstr;
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getpersonelareacode";
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<ListPersonalCode>(jsonstr);

                ddlPersonnelArea.Items.Add(new ListItem("",""));
                for (int i = 0; i <= result1.getPersonelAreaCodeResult.Count - 1; i++)
                {
                    ddlPersonnelArea.Items.Add(new ListItem(Base64Decode1(result1.getPersonelAreaCodeResult[i].pcdesc1.ToString()),
                        Base64Decode1(result1.getPersonelAreaCodeResult[i].pccode1.ToString())));
                }

            }
        }

        public class ListPersonalCode
        {
            public List<personalCode> getPersonelAreaCodeResult { get; set; }
        }

        public class personalCode
        {
            public string pccode1 { get; set; }
            public string pcdesc1 { get; set; }

        }

        void GetListPersonalSubCode(string code1)
        {
            string jsonstr;
            ddlSubPersonnelArea.Items.Clear();
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/getpersonelsubareacode/" + code1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<ListPersonalSubCode>(jsonstr);

                ddlSubPersonnelArea.Items.Add(new ListItem("", ""));
                for (int i = 0; i <= result1.getSubPersonelAreaCodeResult.Count - 1; i++)
                {
                    ddlSubPersonnelArea.Items.Add(new ListItem(Base64Decode1(result1.getSubPersonelAreaCodeResult[i].pcsubdesc1.ToString()),
                        Base64Decode1(result1.getSubPersonelAreaCodeResult[i].pcsubcode1.ToString())));
                }

            }
        }

        public class ListPersonalSubCode
        {
            public List<personalSubCode> getSubPersonelAreaCodeResult { get; set; }
        }

        public class personalSubCode
        {
            public string pcsubcode1 { get; set; }
            public string pcsubdesc1 { get; set; }

        }


        protected void dlMed1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hidval11 = (HiddenField)e.Item.FindControl("lbltrxMed");
            string idtrx = hidval11.Value;

            if (e.CommandName == "cmdSelect")
            {
                Response.Redirect("approval_medical_detail.aspx?id1=" + idtrx);
            }
        }

        public static string Base64Decode1(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode1(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected void ddlPersonnelArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetListPersonalSubCode(ddlPersonnelArea.SelectedValue);
            updddlSubPersonnelArea.Update();
        }

        protected void cmdFilter_Click(object sender, EventArgs e)
        {
            DataTable dl1 = getApprovalMedDataPOST((string)Session["nrp1"],txtFilterNRP.Text.Trim(),txtFilterNama.Text.Trim(),
                ddlPersonnelArea.SelectedValue,ddlSubPersonnelArea.SelectedValue);
            //DataTable dl1 = getApprovalMedDataPOST("4581", txtFilterNRP.Text.Trim(), txtFilterNama.Text.Trim(),
            //    ddlPersonnelArea.SelectedValue, ddlSubPersonnelArea.SelectedValue);
            dlMed1.DataSource = dl1;
            dlMed1.DataBind();
            updDataListMed1.Update();
        }
    }
}