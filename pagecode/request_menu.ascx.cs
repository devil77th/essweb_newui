using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class request_menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void requestReportAbsence_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_report_absence.aspx");
        }

       
        protected void imgWFH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_menu_wfh.aspx");
        }

        protected void imgreqcico_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_cico.aspx");
        }

        protected void imgreqabsence_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_absence.aspx");
        }

        protected void imgreqattendance_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_attendance.aspx");
        }


        protected void requestReportInternet_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void requestReportAbsenceWFH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_report_wfh.aspx");
        }

        protected void cicowfo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cico_fg.aspx");
        }

        protected void imgWFO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_menu_wfo.aspx");
        }

        protected void imgWS_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("report_workschedule.aspx");
        }
    }
}