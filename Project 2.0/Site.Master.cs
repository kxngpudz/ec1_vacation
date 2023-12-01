using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_2._0
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session["UserEmail"] = null;
            Session["UserRole"] = null;
            Session["destinationId"] = null;
            Session["flightId"] = null;
            Response.Redirect("~/UserAuth/userLogin.aspx");
        }
    }
}