using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_2._0.Models;
using System.Configuration;

namespace Project_2._0.Admin
{
    public partial class userRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserEmail"] == null || Session["UserRole"].ToString() != "ADMIN")
                {
                    Response.Redirect("~/UserAuth/userLogin.aspx");
                }
                BindGridView();
            }
        }
        private void BindGridView()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id , email , NoOfDays ,PhoneNumber, NumberOfPeople, (SELECT Title FROM Destinations WHERE Id = DestinationId ) AS Destination, FlightId, Address, isApproved FROM CheckOut WHERE isApproved = 0", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewRequests.DataSource = dt;
                    GridViewRequests.DataBind();
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Button btnApprove = (Button)sender;
            string requestId = btnApprove.CommandArgument;
            UpdateRequest(Guid.Parse(requestId));
            BindGridView();
        }

        private void UpdateRequest(Guid requestId)
        {
            try {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE CheckOut SET isApproved = 1 WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", requestId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex) { }
        }
    }
}