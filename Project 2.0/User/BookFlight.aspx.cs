using Project_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_2._0.User
{
    public partial class BookFlight : System.Web.UI.Page
    {
        Helpers helpers = new Helpers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["destinationId"] != null)
                    {
                        populateGrid();
                    }
                    else
                    {
                        Response.Redirect("~/User/BookDestination.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/UserAuth/userLogin.aspx");
            }
        }


        protected void btnBook_Click(object sender, EventArgs e)
        {
            Button btnBook = (Button)sender;
            int rowIndex = ((GridViewRow)btnBook.NamingContainer).RowIndex;
            Guid flightId = (Guid)GridViewFlights.DataKeys[rowIndex].Value;
            Session["flightId"] = flightId;
            Response.Redirect("~/User/CheckOutPage.aspx");
        }

        private void populateGrid()
        {
            List<FlightsDetails> flights = helpers.GetFlightsFromDatabase();
            GridViewFlights.DataSource = flights;
            GridViewFlights.DataBind();
        }

    }
}