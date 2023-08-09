using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class request_menu_wfh : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void requestCICOWFH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cico_wfh.aspx");
        }

        protected void requestAbsenceWFH_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_cico_wfh_list.aspx");
        }

        protected void requestClaimInternet_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("request_claim_internet_wfh.aspx");
        }
    }
}