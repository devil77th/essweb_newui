using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_claim_menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void requestClaimMedical_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_medical_list.aspx");
        }

        protected void requestClaimInternet_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_claim_internet_wfh.aspx");
        }

        protected void requestClaimKacamata_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("request_klaim_kacamata.aspx");
        }
    }
}