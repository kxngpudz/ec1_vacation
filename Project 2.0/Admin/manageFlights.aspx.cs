using Project_2._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_2._0.Admin
{
    public partial class manageFlights : System.Web.UI.Page
    {
        Helpers helpers = new Helpers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserEmail"] != null)
                {
                    if (!IsPostBack)
                    {
                        if (Session["UserEmail"] == null || Session["UserRole"].ToString() != "ADMIN")
                        {
                            Response.Redirect("~/UserAuth/userLogin.aspx");
                        }
                        else
                        {
                            PopulateDestinationDropdown();
                            populateGrid();
                            GridViewFlights.Visible = GridViewFlights.Rows.Count > 0;
                        }
                    }
                }
            }
        }

        private void PopulateDestinationDropdown()
        {
            List<Destinations> destinations = helpers.GetDestinationsFromDatabase();

            ddlDestination.DataSource = destinations;
            ddlDestination.DataTextField = "Title"; 
            ddlDestination.DataValueField = "Id";   
            ddlDestination.DataBind();
        }

        private void populateGrid()
        {
            List<FlightsDetails> flights = helpers.GetFlightsFromDatabase();
            GridViewFlights.DataSource = flights;
            GridViewFlights.DataBind();
        }
        protected void btnAddFlight_Click(object sender, EventArgs e)
        {
            string destinationName = txtDestinationName.Text;
            DateTime flightTime = DateTime.Parse(txtTime.Text);
            Guid destinationId = Guid.Parse(ddlDestination.SelectedValue);
            string leavingLocation = txtLeavingFrom.Text;

            SaveFlight(destinationName, flightTime, destinationId,leavingLocation);
        }

        private void SaveFlight(string destinationName, DateTime flightTime, Guid destinationId,string leavingFrom)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Flights (Id, DestinationName, Time, DestinationId, LeavingFrom) VALUES (@Id, @DestinationName, @Time, @DestinationId,@LeavingFrom)", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@DestinationName", destinationName);
                        cmd.Parameters.AddWithValue("@Time", flightTime);
                        cmd.Parameters.AddWithValue("@DestinationId", destinationId);
                        cmd.Parameters.AddWithValue("@LeavingFrom", leavingFrom);


                        cmd.ExecuteNonQuery();
                        populateGrid();
                    }
                }


            }
            catch (Exception ex)
            {
                
            }
        }

        private void DeleteFlight(Guid flightId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Flights WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", flightId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            Guid flightId = new Guid(btnDelete.CommandArgument);
            DeleteFlight(flightId);
            populateGrid();
        }
    }
}