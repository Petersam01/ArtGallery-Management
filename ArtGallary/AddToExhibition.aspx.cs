using ArtGallary.Controllers;
using ArtGallary.Models;
using System;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ArtGallary
{
    public partial class AddToExhibition : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Load artist information
            getArtist();
        }

        public void getArtist()
        {
            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            int iD2 = Convert.ToInt32(Request.QueryString["ARTWORK"]);
            Artist artist = aga.GetArtistById(iD);
            Artwork artwork = aga.GetArtwork2ById(iD2);

            if (artist != null && artwork != null)
            {
                string artistInfo = $@"
                    <div class='form-group'>
                        <label for='name'><strong>Name:</strong></label>
                        <p id='name'>{artist.Name}</p>
                    </div>
                    <div class='form-group'>
                        <label for='surname'><strong>Surname:</strong></label>
                        <p id='surname'>{artist.Surname}</p>
                    </div>
                    <div class='form-group'>
                        <label for='email'><strong>Art Name:</strong></label>
                        <p id='email'>{artwork.ArtName}</p>
                    </div>
                    <div class='form-group'>
                        <label for='genre'><strong>Genre:</strong></label>
                        <p id='genre'>{artwork.Genre}</p>
                    </div>
                    <div class='form-group'>
                        <label for='arttype'><strong>Art Type:</strong></label>
                        <p id='arttype'>{artwork.ArtType}</p>
                    </div>";

                loadArtist.InnerHtml = artistInfo;
            }
            else
            {
                loadArtist.InnerHtml = "<p>Artist not found.</p>";
            }
        }
        protected void check_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ensure this logic runs during postback
                return;
            }

            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            int iD2 = Convert.ToInt32(Request.QueryString["ARTWORK"]);
            var artist = aga.GetArtistById(iD);
            var artwork = aga.GetArtwork2ById(iD2);

            if (artist != null && artwork != null)
            {
                // Accessing the TextBox values correctly
                string exhibitionGenre = selectGenre.Text;
                string exhibitionArtType = selectArtType.Text;

                bool isCompatible = IsArtistCompatible(iD, exhibitionGenre, exhibitionArtType);
                string compatibilityMessage;
                string recommendationMessage;

                if (isCompatible)
                {
                    compatibilityMessage = "The artist is 100% compatible with the exhibition.";
                    recommendationMessage = "Proceed with adding the artist to the exhibition.";
                }
                else
                {
                    compatibilityMessage = "The artist is not compatible with the exhibition.";
                    recommendationMessage = "Consider selecting artworks more aligned with the exhibition's theme.";
                }

                // Update labels
                CompatibilityStatusLabel.Text = compatibilityMessage;
                suggestion.Text = recommendationMessage;
            }
            else
            {
                CompatibilityStatusLabel.Text = "Artist not found.";
                suggestion.Text = "";
            }
        }



        // Function to check artist compatibility with exhibition based on genre and art type
        public bool IsArtistCompatible(int artistID, string exhibitionGenre, string exhibitionArtType)
        {
            bool isCompatible = false;

            string query = "SELECT COUNT(*) FROM Artworks WHERE ID = @artistID AND Genre = @exhibitionGenre AND ArtType = @exhibitionArtType";

            using (MySqlConnection conn = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@artistID", artistID);
                    cmd.Parameters.AddWithValue("@exhibitionGenre", exhibitionGenre);
                    cmd.Parameters.AddWithValue("@exhibitionArtType", exhibitionArtType);

                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    int count = result != null ? Convert.ToInt32(result) : 0;

                    if (count > 0)
                    {
                        isCompatible = true;
                    }
                }
            }

            return isCompatible;
        }

        protected void add_Click(object sender, EventArgs e)
        {
            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            int iD2 = Convert.ToInt32(Request.QueryString["ARTWORK"]);
            Artist artist = aga.GetArtistById(iD);
            Artwork artwork = aga.GetArtwork2ById(iD2);

            if (artist != null && artwork != null)
            {
                // Update the artist's status to "Active"
                bool statusUpdated = aga.UpdateArtistStatus(iD, "Active");

                if (statusUpdated)
                {
                    Exhibition newExhi = new Exhibition(artist.Name, artist.Surname, artwork.ArtName, artwork.Genre, artwork.ArtType, artist.ProfilePicture, artwork.Image, artist.AdminID);
                    bool exhibitionCreated = aga.CreatExhibition(newExhi);

                    if (exhibitionCreated)
                    {
                        // Show success message and link to view the exhibition
                        lblMessage.Text = "Artist has been successfully added to the exhibition!";
                        lblMessage.Visible = true;

                        // Assuming you have a way to get the exhibition ID or name to include in the URL
                        // For demonstration purposes, we'll assume the ID is being returned
                       // int exhibitionID = aga.GetLatestExhibitionID(); // Add this method in your API to fetch the latest exhibition ID

                        hlViewExhibition.NavigateUrl = "CurrentExhibition.aspx";
                        hlViewExhibition.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "Failed to create the exhibition.";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Failed to update artist status.";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                lblMessage.Text = "Artist not found.";
                lblMessage.Visible = true;
            }
        }


    }
}
