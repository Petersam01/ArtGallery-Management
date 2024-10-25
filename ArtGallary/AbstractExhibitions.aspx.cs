using ArtGallary.Controllers;
using ArtGallary.Models;
using DocumentFormat.OpenXml.Bibliography;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class AbstractExhibitions : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool exhibitionsExist = funcArtists();

            int id = getArtist();

            //Session["Genre"] = aga.GetArtistTypeById(id);
            Session["ID"] = id;

            if (Session["AdminID"] != null)
            {
                delete.Visible = true;
              
            }else if (Session["AdminID"] == null)
            {
                delete.Visible = false;
            }
        }


        public bool funcArtists()
        {
            string lines = "";
            bool exhibitionsFound = false;

            int Id = Convert.ToInt32(Request.QueryString["ID"]);

            foreach (Exhibition exhi in aga.GetArtistsByGenreAbstract())
            {
                exhibitionsFound = true;
                lines += "<div class='col-md-3 my-3'>";
                lines += $"<a href='#'><img src='{Util.ByteArrayToImage(exhi.ArtImage)}' alt='' class='w-100 h-50'></a>";
                lines += $"<h5 class='my-2 text-dark'>Artist name: {exhi.Name}</h5>";
                lines += $"<h5 class='my-2 text-dark'>Art Type: {exhi.ArtName}</h5>";
                lines += $"<h5 class='my-2 text-dark'>Art Type: {exhi.ArtType}</h5>";
                lines += "</div>";
            }

            if (!exhibitionsFound)
            {
                lines = "<p class='text-danger'>Exhibition empty</p>";
            }

            loadArtists.InnerHtml = lines;

            return exhibitionsFound;
        }


        private int getArtist()
        {
            int Id = 0;

            using (MySqlConnection sqlCon = new MySqlConnection(Controllers.Settings.CONNECTION_STRING))
            {
                string query = "SELECT ID FROM Artists"; // Added LIMIT 1 to ensure a single result
                using (MySqlCommand sqlcmd = new MySqlCommand(query, sqlCon))
                {
                    sqlCon.Open(); // Ensure the connection is open

                    object result = sqlcmd.ExecuteScalar();

                    // Check if the result is null
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        Id = id;
                    }
                    else
                    {
                        Id = -1; // Or some other default value to indicate no result
                    }
                }
            }

            return Id;
        }

        protected void register_Click(object sender, EventArgs e)
        {
            // Call funcArtists() to check if exhibitions exist
            bool exhibitionsExist = funcArtists();
            int iD = Convert.ToInt32(Request.QueryString["EXHIBIT"]);

            if (exhibitionsExist)
            {
                // Proceed to the registration page if exhibitions exist
                Response.Redirect($"RegAbstract.aspx?EXHIBIT={iD}");
            }
            else
            {
                // Show a message or take alternative action if no exhibitions exist
                // Example: Show a message on the same page
                loadArtists.InnerHtml = "<p class='text-danger'>Exhibition empty. Cannot register.</p>";
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            int iD = Convert.ToInt32(Request.QueryString["EXHIBIT"]);
            Exhibits exhi = aga.GetExhibitById(iD);

            string genre = "Abstract";
            Exhibition exhibi = aga.GetArtistExhiByGenre(genre);

            string book = aga.GetBookingsByExhibitionName("Abstract");


            aga.DeleteArtistFromExhibition(genre);
            aga.DeleteUserFromBookings(book);
            aga.DeleteExhibitionById(iD);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('you successfully  removed an Artist');", true);
            Response.Redirect("CurrentExhibition.aspx");
        }
    }
}