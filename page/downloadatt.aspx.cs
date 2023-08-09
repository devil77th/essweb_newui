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
using WebApplication1.class1;

namespace WebApplication1.page
{
    public partial class downloadatt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["typef"] == "template")
            {
                downloadDataTemp(Request["type1"].ToString());
            }
            else if (Request["typef"] == "upload")
            {
                downloadDataUpload(Request["id1"].ToString(), Request["type1"].ToString());
            }

        }

        void downloadDataTemp(string type1)
        {
                string jsonstr, filename1 = "", filestr64 = "";
                var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/getfile_ess/" + type1;
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {

                    var result = reader.ReadToEnd();
                    jsonstr = Convert.ToString(result);
                    var result1 = JsonConvert.DeserializeObject<dataclass1.filetemplateresign>(jsonstr);
                    filename1 = result1.getfile_essResult.filename1.ToString();
                    filestr64 = result1.getfile_essResult.filebin64.ToString();

                    filename1 = filename1.Replace(" ", "");
                    byte[] filedecode64 = Convert.FromBase64String(filestr64);
                    Stream fStream = new MemoryStream(filedecode64);
                    MemoryStream mStream = new MemoryStream();
                    fStream.CopyTo(mStream);

                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename1);
                    Response.AddHeader("Content-Length", mStream.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    mStream.WriteTo(Response.OutputStream);
                    Response.End();
                }
        }

        void downloadDataUpload(string id1,string type1)
        {
            string jsonstr, filename1 = "", filestr64 = "";
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/ess/getfile_trxresign/" + id1  + "/" + type1;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                var result = reader.ReadToEnd();
                jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<dataclass1.fileuploadresign>(jsonstr);
                filename1 = result1.GetUploadFile_TrxResign1Result.filename1.ToString();
                filestr64 = result1.GetUploadFile_TrxResign1Result.filebin64.ToString();

                filename1 = filename1.Replace(" ", "");
                byte[] filedecode64 = Convert.FromBase64String(filestr64);
                Stream fStream = new MemoryStream(filedecode64);
                MemoryStream mStream = new MemoryStream();
                fStream.CopyTo(mStream);

                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename1);
                Response.AddHeader("Content-Length", mStream.Length.ToString());
                Response.ContentType = "application/octet-stream";
                mStream.WriteTo(Response.OutputStream);
                Response.End();
            }
        }
    }
}