using ArtGallary.Controllers;
using ArtGallary.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class RemoveArtAndArtist : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();
        protected void Page_Load(object sender, EventArgs e)
        {

            funcArtists();

            int id = getArtist();

           // Session["Genre"] = aga.GetArtistTypeById(id);
            Session["ID"] = id;

            int Id = Convert.ToInt32(Request.QueryString["ID"]);
        }

        public void funcArtists()
        {
            string lines = "";
            // User user = new User();
            //string generes = "Size";
            //Bed bed = new Bed();
            int Id = Convert.ToInt32(Request.QueryString["ID"]);

            foreach (Artist art in aga.GetAllArtists())
            {
                lines += " <div class='col-md-3 my-3'> ";
                lines += $" <a href='RemoveArtist.aspx?ARTIST={art.ID}'><img src='{Util.ByteArrayToImage(art.ProfilePicture)}' alt='' class='w-100 h-50'></a> ";
                lines += $" <h5 class='my-2 text-dark'>{art.Name}</h5> ";
                lines += " <div class='py-1'></div> ";
                lines += $" <a href='RemoveArtist.aspx?ARTIST={art.ID}' class='btn btn-outline-primary btn-md'>More Info</a> ";
                lines += " </div> ";

                loadArtists.InnerHtml = lines;
                // loadBeds.DataSource = bed;
                // loadBeds.DataBind();
                Artist currentArt = aga.GetArtistById(Id);
            }
        }

        private int getArtist()
        {
            int Id = 0;

            using (MySqlConnection sqlCon = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string query = "SELECT ID FROM Artists LIMIT 1"; // Added LIMIT 1 to ensure a single result
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

    }
}