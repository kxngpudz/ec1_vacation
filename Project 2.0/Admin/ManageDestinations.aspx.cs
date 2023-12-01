using Project_2._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace Project_2._0.Admin
{
    public partial class ManageDestinations : System.Web.UI.Page
    {
        Helpers helpers = new Helpers();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["UserEmail"] == null || Session["UserRole"].ToString()!= "ADMIN")
                {
                    Response.Redirect("~/UserAuth/userLogin.aspx");
                }
                

                List<Destinations> destinations = helpers.GetDestinationsFromDatabase();

                Repeater1.DataSource = destinations;
                Repeater1.DataBind();
            }

        }


        public static string SaveDestination(string title, string description, string price, HttpPostedFile file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var imagePath = HttpContext.Current.Server.MapPath("~/Images/") + fileName;
                    file.SaveAs(imagePath);

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Destinations (Id , Title, Description, Price, ImageURL, isDeleted) VALUES (@Id, @Title, @Description, @Price, @ImageURL, 0)", con))
                        {
                            cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                            cmd.Parameters.AddWithValue("@Title", title);
                            cmd.Parameters.AddWithValue("@Description", description);
                            cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(price));
                            cmd.Parameters.AddWithValue("@ImageURL", "~/Images/" + fileName);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    return "success";
                }
                else
                {
                    return "No file in the request";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }


        protected void btnAddDestination_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string price = txtPrice.Text;
            HttpPostedFile file = fileBookImage.PostedFile;

            string result = SaveDestination(title, description, price, file);

            if (result == "success")
            {
                lblMessage.Text = "Destination added successfully.";
            }
            else if (result == "No file in the request")
            {
                lblMessage.Text = "Please select an image.";
            }
            else
            {
                lblMessage.Text = "Error saving destination.";
            }
        }
    }
}
