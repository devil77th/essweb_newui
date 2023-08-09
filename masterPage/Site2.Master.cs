using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.masterPage
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["nrp1"] as string)==true)
            {
                    Response.Redirect("login.aspx");
            }

            
            
        }

        String encData(string str1)
        {
            byte xorConstant = 0x53;

            string input = str1;
            byte[] data = Encoding.UTF8.GetBytes(input);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            string output = Convert.ToBase64String(data);
            return output;
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

        protected void cmdBack_Click(object sender, EventArgs e)
        {
            string url1 = HttpContext.Current.Request.Url.AbsoluteUri;
            if(url1.Contains("request_cico.aspx"))
            {
                Response.Redirect("request_menu_wfo.aspx");
            }

            if (url1.Contains("request_absence_detail.aspx"))
            {
                Response.Redirect("request_absence_list.aspx");
            }

            if (url1.Contains("request_absence.aspx"))
            {
                Response.Redirect("request_absence_list.aspx");
            }

            if (url1.Contains("request_absence_list.aspx"))
            {
                Response.Redirect("request_menu_wfo.aspx");
            }



            if (url1.Contains("Default.aspx"))
            {
                Response.Redirect("Default.aspx");
            }

            if (url1.Contains("approval_menu.aspx"))
            {
                Response.Redirect("Default.aspx");
            }

            if (url1.Contains("request_menu.aspx"))
            {
                Response.Redirect("Default.aspx");
            }

            if (url1.Contains("claim_menu.aspx"))
            {
                Response.Redirect("Default.aspx");
            }

            if (url1.Contains("link_menu.aspx"))
            {
                Response.Redirect("Default.aspx");
            }


            if (url1.Contains("approval_cico.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("approval_absence.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("approval_overtime_hr.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("approval_overtime.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("approval_claiminternet_wfh.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("overtime_edit_hr.aspx"))
            {
                Response.Redirect("approval_overtime_hr.aspx");
            }


            if (url1.Contains("overtime_edit.aspx"))
            {
                Response.Redirect("approval_overtime.aspx?token1=" + encData(Session["nrp1"].ToString()));
            }

            if (url1.Contains("report_absence.aspx"))
            {
                Response.Redirect("request_menu.aspx");
            }

            if (url1.Contains("request_attendance_list.aspx"))
            {
                Response.Redirect("request_menu_wfo.aspx");
            }

            if (url1.Contains("request_attendance_detail.aspx"))
            {
                Response.Redirect("request_attendance_list.aspx");
            }


            if (url1.Contains("request_attendance.aspx"))
            {
                Response.Redirect("request_attendance_list.aspx");
            }


            if (url1.Contains("approval_attendance.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("approval_cico_wfh.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("approval_medical.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }

            if (url1.Contains("approval_medical_detail.aspx"))
            {
                Response.Redirect("approval_medical.aspx");
            }

            if (url1.Contains("request_claim_internet_wfh.aspx"))
            {
                Response.Redirect("claim_menu.aspx");
            }


            if (url1.Contains("request_cico_wfh.aspx"))
            {
                Response.Redirect("request_cico_wfh_list.aspx");
            }

            if (url1.Contains("request_cico_wfh_detail.aspx"))
            {
                Response.Redirect("request_cico_wfh_list.aspx");
            }

            if (url1.Contains("request_cico_wfh_list.aspx"))
            {
                Response.Redirect("request_menu_wfh.aspx");
            }




            if (url1.Contains("request_cico.aspx"))
            {
                Response.Redirect("request_cico_wfo_list.aspx");
            }

            if (url1.Contains("request_cico_wfo_detail.aspx"))
            {
                Response.Redirect("request_cico_wfo_list.aspx");
            }

            if (url1.Contains("request_cico_wfo_list.aspx"))
            {
                Response.Redirect("request_menu_wfo.aspx");
            }



            if (url1.Contains("delcico_wfh.aspx"))
            {
                Response.Redirect("approval_menu.aspx");
            }


            if (url1.Contains("cico_wfh.aspx"))
            {
                Response.Redirect("request_menu_wfh.aspx");
            }

            if (url1.Contains("request_report_wfh.aspx"))
            {
                Response.Redirect("request_menu.aspx");
            }


            if (url1.Contains("request_menu_wfh.aspx"))
            {
                Response.Redirect("Default.aspx");
            }

            if (url1.Contains("request_menu_wfo.aspx"))
            {
                Response.Redirect("Default.aspx");
            }

            if (url1.Contains("report_absence_subordinate.aspx"))
            {
                Response.Redirect("Default.aspx");
            }

            if (url1.Contains("report_workschedule.aspx"))
            {
                Response.Redirect("request_menu.aspx");
            }

            if (url1.Contains("cico_fg.aspx"))
            {
                Response.Redirect("request_menu.aspx");
            }

            if (url1.Contains("profile_employee.aspx"))
            {
                Response.Redirect("Default.aspx");
            }


            if (url1.Contains("employee_address_edit.aspx"))
            {
                Response.Redirect("profile_employee.aspx");
            }



            if (url1.Contains("family_list_edit.aspx"))
            {
                Response.Redirect("family_list.aspx");
            }

            if (url1.Contains("family_list_add.aspx"))
            {
                Response.Redirect("family_list.aspx");
            }

            if (url1.Contains("family_list.aspx"))
            {
                Response.Redirect("profile_employee.aspx");
            }

            if (url1.Contains("request_medical_list.aspx"))
            {
                Response.Redirect("claim_menu.aspx");
            }

            if (url1.Contains("request_overtime_list.aspx"))
            {
                Response.Redirect("request_menu_wfo.aspx");
            }

            if (url1.Contains("request_overtime_add.aspx"))
            {
                Response.Redirect("request_overtime_list.aspx");
            }

            if (url1.Contains("request_medical_detail.aspx"))
            {
                Response.Redirect("request_medical_list.aspx");
            }

            if (url1.Contains("request_medical_add.aspx"))
            {
                Response.Redirect("request_medical_list.aspx");
            }

            if (url1.Contains("request_klaim_kacamata.aspx"))
            {
                Response.Redirect("claim_menu.aspx");
            }

            if (url1.Contains("request_klaim_kacamata_detail.aspx"))
            {
                Response.Redirect("request_klaim_kacamata.aspx");
            }

            if (url1.Contains("request_klaim_kacamata_add.aspx"))
            {
                Response.Redirect("request_klaim_kacamata.aspx");
            }

            if (url1.Contains("trxresign2.aspx"))
            {
                Response.Redirect("trxresign.aspx");
            }

            if (url1.Contains("trxresign.aspx"))
            {
                Response.Redirect("personnel_menu.aspx");
            }
        }
    }
}