using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_personnel_menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgResign_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("trxresign.aspx");
        }
    }
}