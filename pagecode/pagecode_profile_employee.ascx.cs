using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.pagecode
{
    public partial class pagecode_profile_employee : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNama.Text = Session["fullname1"].ToString();
            lblEmail.Text = Session["emailadd1"].ToString();
        }

        protected void cmdEditAlamat_Click(object sender, EventArgs e)
        {
            //Response.Redirect("employee_address_edit.aspx");
        }

        protected void cmdEditKeluarga_Click(object sender, EventArgs e)
        {
            //Response.Redirect("family_list.aspx");
        }
    }
}