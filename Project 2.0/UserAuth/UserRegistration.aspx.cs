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
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtFullName.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;
                string gender = ddlGender.SelectedValue;

                if (password != confirmPassword)
                {
                    return;
                }
                string hashedPassword = password;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                {
                    con.Open();
                    Guid userId = Guid.NewGuid();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO UserRigistrations (Id, FullName, Email, Password, Gender, Role) VALUES (@Id, @FullName, @Email, @Password, @Gender, @Role)", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", userId);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Role", "USER");

                        cmd.ExecuteNonQuery();
                        Response.Redirect("userLogin.aspx");
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}