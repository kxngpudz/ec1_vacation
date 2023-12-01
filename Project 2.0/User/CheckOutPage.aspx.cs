using Project_2._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_2._0.User
{
    public partial class CheckOutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null)
            {
                if (!IsPostBack)
                {
                   if(Session["flightId"]==null || Session["destinationId"] == null)
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            int numberOfPeople = Convert.ToInt32(txtNumberOfPeople.Text);
            int noOfDays = Convert.ToInt32(txtNoOfDays.Text);
            string phoneNumber = txtPhoneNumber.Text;
            SaveCheckoutData(email, numberOfPeople, noOfDays, phoneNumber);
            lblMessage.Text = "Checkout successful!";
        }

        private void SaveCheckoutData(string email, int numberOfPeople, int noOfDays, string phoneNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO CheckOut (Id, email, NumberOfPeople, NoOfDays, PhoneNumber,DestinationId,FlightId,isApproved) VALUES (@Id, @Email, @NumberOfPeople, @NoOfDays, @PhoneNumber,@DestinationId,@FlightId,@isApproved);", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@NumberOfPeople", numberOfPeople);
                        cmd.Parameters.AddWithValue("@NoOfDays", noOfDays);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        Guid DestinationId = Guid.Parse(Session["destinationId"].ToString());
                        Guid flightId = Guid.Parse(Session["flightId"].ToString());
                        cmd.Parameters.AddWithValue("@DestinationId", DestinationId);
                        cmd.Parameters.AddWithValue("@FlightId", flightId);
                        cmd.Parameters.AddWithValue("@isApproved", false);

                        cmd.ExecuteNonQuery();

                        Response.Redirect("~/User/BookDestination.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error during checkout. Please try again.";
            }
        }
    }
}