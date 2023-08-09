using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_request_attendance : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSubmitAttendance_Click(object sender, EventArgs e)
        {
            bool flgValidAtt1 = DateTime.TryParse(txtDateAttendance1.Text.Trim() + " " + txtTimeAttendance1.Text.Trim(), out DateTime att1);
            bool flgValidAtt2 = DateTime.TryParse(txtDateAttendance1.Text.Trim() + " " + txtTimeAttendance2.Text.Trim(), out DateTime att2);

            if (txtDateAttendance1.Text.Trim()=="" || txtTimeAttendance1.Text.Trim()=="" || txtTimeAttendance2.Text.Trim()==""
                || txtDateAttendance1.Text.Trim() == null || txtTimeAttendance1.Text.Trim() == null || txtTimeAttendance2.Text.Trim() == null)
            {
                popUpMsgBox("Field Tanggal / Jam harus diisi");
            }
            else
            {
                if(IsValidTime(txtTimeAttendance1.Text)==false || IsValidTime(txtTimeAttendance2.Text)==false)
                {
                    popUpMsgBox("Format Jam yang anda masukkan salah");
                }
                else
                {
                    if (flgValidAtt1 == false || flgValidAtt2 == false)
                    {
                        popUpMsgBox("Tolong cek kembali data yang anda masukkan");
                    }
                    else
                    {
                        if (att1 > att2)
                        {
                            popUpMsgBox("Waktu pertama lebih besar daripada waktu kedua");
                        }
                        else
                        {
                            bool flg1 = cekSubmitAttendance((string)Session["nrp1"], att1.ToShortDateString(), att2.ToShortDateString());
                            if(flg1==false)
                            {
                                Session.Add("datereqattendance1", txtDateAttendance1.Text.Trim());
                                Session.Add("timereqattendance1", txtTimeAttendance1.Text.Trim());
                                Session.Add("timereqattendance2", txtTimeAttendance2.Text.Trim());
                                Session.Add("typevalreqattendance1", ddlTypeAttendance.SelectedValue);
                                Session.Add("typetxtreqattendance1", ddlTypeAttendance.SelectedItem.Text);
                                //Session.Add("notereqattendance1", txtReason1.Text.Trim());
                                Response.Redirect("request_attendance_confirm.aspx");
                            }
                            else
                            {
                                popUpMsgBox("Sudah ada transaksi CI/CO atau Absence atau Attendance pada tanggal yang dimasukkan");
                            }
                        }
                    }
                }
            }
        }

        public bool IsValidTime(string thetime)
        {
            Regex checktime =
             new Regex(@"^(([0-1][0-9])|([2][0-3])):([0-5][0-9])");

            return checktime.IsMatch(thetime);
        }

        static Boolean cekSubmitAttendance(string nrp1, string date1, string date2)
        {
            Boolean flg1;
            flg1 = true;
            date1 = date1.Replace("/", "");
            date2 = date2.Replace("/", "");
            var url = ConfigurationManager.AppSettings.Get("wsURL1") + "/rest/cekattend/" + nrp1 + "/" + date1 + "/" + date2;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                string jsonstr = Convert.ToString(result);
                var result1 = JsonConvert.DeserializeObject<strJson>(jsonstr);
                flg1 = Convert.ToBoolean(result1.cekAttendanceResult);
            }
            return flg1;
        }

        public class strJson
        {
            public string cekAttendanceResult;
        }

        void popUpMsgBox(string msg1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("')};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }


    }
}