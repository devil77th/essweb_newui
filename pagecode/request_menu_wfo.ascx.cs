using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class request_menu_wfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void requestCICO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_cico_wfo_list.aspx");
        }

        protected void requestAbsence_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_absence_list.aspx");
        }

        protected void requestReportAbsence_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_report_absence.aspx");
        }

        protected void requestAttendance_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_attendance_list.aspx");
        }

        protected void cicowfo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cico_fg.aspx");
        }

        protected void requestOvertime_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_overtime_list.aspx");
        }

        protected void claimmedical_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_medical_list.aspx");
        }
    }
}