using Project_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_2._0.User
{
    public partial class BookDestination : System.Web.UI.Page
    {
        Helpers helpers = new Helpers();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserEmail"] != null)
            {
                if (!IsPostBack)
                {
                    List<Destinations> destinations = helpers.GetDestinationsFromDatabase();
                    Repeater1.DataSource = destinations;
                    Repeater1.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/UserAuth/userLogin.aspx");
            }

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "BookDestination")
            {
                string destinationId = e.CommandArgument.ToString();
                Session["destinationId"] = destinationId;
                Response.Redirect("~/User/BookFlight.aspx");
            }
        }
    }
}
