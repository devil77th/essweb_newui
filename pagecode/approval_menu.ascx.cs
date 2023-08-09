using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class approval_menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["nrp1"] as string) == false)
            {
                string nrp1 = Session["nrp1"].ToString();
                if(nrp1 == "4581" || nrp1 == "319" || nrp1 == "1138" || nrp1 == "1099")
                {
                    deletecicowfh.Visible = true;
                    lbldeletecicowfh.Visible = true;
                    
                }
                else
                {
                    deletecicowfh.Visible = false;
                    lbldeletecicowfh.Visible = false;
                    
                }

                if(nrp1 == "1138" || nrp1 == "1099")
                {
                    approvalovthr.Visible = true;
                    lblapprovalovthr.Visible = true;
                }
                else
                {
                    approvalovthr.Visible = false;
                    lblapprovalovthr.Visible = false;
                }
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

        protected void approvalCICO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_cico.aspx");
        }

        protected void approvalAbsence_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_absence.aspx");
        }

        protected void approvalOvertime_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_overtime.aspx?token1=" + encData(Session["nrp1"].ToString()));
        }

        protected void approvalAttendance_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_attendance.aspx?token1=" + encData(Session["nrp1"].ToString()));
        }

        protected void approval_cicowfh_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_cico_wfh.aspx");
        }

        protected void deletecicowfh_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("delcico_wfh.aspx");
        }

        protected void approvalClaimInternet_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_claiminternet_wfh.aspx");
        }

        protected void rptabsencesub_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("report_absence_subordinate.aspx");
        }

        protected void imgapprovalmedical_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_medical.aspx");
        }

        protected void approvalovthr_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("approval_overtime_hr.aspx");
        }
    }
}