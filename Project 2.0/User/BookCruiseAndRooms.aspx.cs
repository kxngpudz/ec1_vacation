using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_2._0.Models;

namespace Project_2._0.User
{
    public partial class BookCruiseAndRooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null)
            {
                if (!IsPostBack)
                {
                    LoadCruiseData();
                }
            }
            else
            {
                Response.Redirect("~/UserAuth/userLogin.aspx");
            }
        }

        private void LoadCruiseData()
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Destination, SailingDuration, Room, isBooked FROM BookCruise WHERE isBooked = 0", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewCruises.DataSource = dt;
                    GridViewCruises.DataBind();
                }
            }
        }



        protected void btnBook_Click(object sender, EventArgs e)
        {
            Button btnBook = (Button)sender;
            string cruiseId = btnBook.CommandArgument;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Room, isBooked FROM BookCruise WHERE Id = @Id", con))
                {

                    cmd.Parameters.AddWithValue("@Id", cruiseId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session["rooms"] = reader["Room"].ToString();
                        }
                    }
                }
            }

            int rooms = Convert.ToInt32(Session["rooms"].ToString())-1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE BookCruise SET Room = @Room WHERE Id = @Id", con))
                {

                    cmd.Parameters.AddWithValue("@Id", cruiseId);
                    cmd.Parameters.AddWithValue("@Room", rooms);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session["rooms"] = reader["Room"].ToString();
                        }
                    }
                }
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open(); 
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Bookings (Id,Uid,CruiseId,Rooms) VALUES (@Id , @Uid , @CruiseId , @Rooms)", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@Uid", Guid.Parse(Session["Uid"].ToString()));
                    cmd.Parameters.AddWithValue("@CruiseId", cruiseId);
                    cmd.Parameters.AddWithValue("@Rooms", 1);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadCruiseData();
            Response.Redirect("~/User/BookDestination.aspx");
        }
    }
}
