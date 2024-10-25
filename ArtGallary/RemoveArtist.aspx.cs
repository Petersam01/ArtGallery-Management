using ArtGallary.Controllers;
using ArtGallary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class RemoveArtist : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();
        Artist artist;
        protected void Page_Load(object sender, EventArgs e)
        {
            getArtist();
            int Id = Convert.ToInt32(Request.QueryString["ID"]);
        }

        public void getArtist()
        {
            string lines = "";
            User user = new User();
            //Bed bed = new Bed();
            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            artist = aga.GetArtistById(iD);
            List<Artwork> artworks = aga.GetArtworksById(iD);

            lines += " <div class='col-md-4 my-4'> ";

                lines += " <h4 class='Container text-light text-center' style='background-color: rgb(6, 76, 143);  border-radius: 0%;'>Artist Information</h4> ";
                lines += " <ul class='text-center'> ";
                lines += $" <li class='text-center'><b>Name:  </b>{artist.Name}</li> ";
                lines += $" <li><b>Surname:  </b>{artist.Surname}</li> ";
                lines += $" <li><b>Email:  </b>{artist.Email}</li> ";
                lines += " </ul> ";

                lines += " <h4 class='Container text-light text-center' style='background-color: rgb(6, 76, 143);  border-radius: 0%;'>Display Information</h4> ";
                lines += " <ul class='text-center'> ";
                lines += $" <li class='text-center'><b>Exhibition Status:  </b> {artist.Status}</li> ";
                lines += " </ul> ";

                lines += " <div class='py-3'></div> ";


                lines += " </div> ";

          
            foreach (var artwork in artworks)
            {
                
                lines += " <div class='col-md-6 my-6'> ";
                // Assuming artwork.Image is a byte array storing the image data.
                lines += $" <a href='AddToExhibition.aspx?ARTIST={artist.ID}&ARTWORK={artwork.artID}'>";
                lines += $"<img src='{Util.ByteArrayToImage(artwork.Image)}' alt='' style='width: 20rem; height: 10rem; margin-left: 10%;'></a> ";


                // Display art name, genre, and art type below the image.
                lines += $" <div style='text-align: center; margin-top: 10px;'> ";
                lines += $" <h5>{artwork.ArtName}</h5> ";  // Display art name.
                lines += $" <p>Genre: {artwork.Genre}</p> ";  // Display genre.
                lines += $" <p>Type: {artwork.ArtType}</p> ";  // Display art type.
                lines += " </div> ";

                lines += " </div> ";
            }

            loadArtist.InnerHtml = lines;

        }

        protected void remove_Click(object sender, EventArgs e)
         {
            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            artist = aga.GetArtistById(iD);

            aga.DeleteArtworkById(iD);
            aga.DeleteArtistById(iD);
           
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('you successfully  removed an Artist');", true);
            Response.Redirect("RemoveArtAndArtist.aspx");
        }

      /* protected void add_Click(object sender, EventArgs e)
         {
            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            Artist artist = aga.GetArtistById(iD);
            Response.Redirect($"AddToExhibition.aspx?ARTIST={iD}"); 

           // Response.Redirect($"addExhibition.aspx?ARTIST={iD}");
        }*/

        protected void addArt_Click(object sender, EventArgs e)
        {
            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            Artist artist = aga.GetArtistById(iD);
            Response.Redirect($"AddArt.aspx?ARTIST={iD}");
        }
        /* protected void add_Click(object sender, EventArgs e)
{
int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
Artist artist = aga.GetArtistById(iD);

if (artist != null)
{
  // Update the artist's status to "Active"
  bool statusUpdated = aga.UpdateArtistStatus(iD, "Active");

  if (statusUpdated)
  {
      Exhibition newExhi = new Exhibition(artist.Name, artist.Surname, artist.Email, artist.Genres, artist.ArtType, artist.ProfilePicture, artist.ArtPicture, artist.AdminID, artist.ID);
      aga.CreatExhibition(newExhi);
      Response.Redirect("./CurrentExhibition.aspx");
  }
  else
  {
      // Handle the case where the status update failed
      Response.Write("Failed to update artist status.");
  }
}
else
{
  // Handle the case where the artist is not found
  Response.Write("Artist not found.");
}
}
*/


    }

}