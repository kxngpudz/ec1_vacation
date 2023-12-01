using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_2._0.UserAuth
{
    public partial class userLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;
                if (AuthenticateUser(email, password))
                {
                    string role = GetUserRole(email);

                    StoreUserInfoInSession(email, role);
                    if (Session["UserRole"].ToString() == "USER")
                    {
                        Response.Redirect("~/User/BookDestination.aspx");
                    }
                    else if (Session["UserRole"].ToString() == "ADMIN")
                    {
                        Response.Redirect("~/Admin/userRequests.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private bool AuthenticateUser(string email, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT Id, Email, Password FROM UserRigistrations WHERE Email = @Email;", con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Session["Uid"] = reader["Id"].ToString();
                                string storedPassword = reader["Password"].ToString();

                                return email.ToLower() == reader["Email"].ToString().ToLower() && password == storedPassword;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        private string GetUserRole(string email)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Role FROM UserRigistrations WHERE Email = @Email;", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            return role;
                        }
                    }
                }
            }
            return null;
        }

        private void StoreUserInfoInSession(string email, string role)
        {
            Session["UserEmail"] = email;
            Session["UserRole"] = role;
        }
    }
}