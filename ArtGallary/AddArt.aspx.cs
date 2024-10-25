using ArtGallary.Controllers;
using ArtGallary.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class AddArt : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();
        ArtAdmin admin = new ArtAdmin();
        Artist artist = new Artist();
        private static string imgPath;
        private static string fileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("./Login.aspx");
            }

            int adminID = (int)Session["AdminID"];
        }

        protected void addArtwork_Click(object sender, EventArgs e)
        {
            if (picture.HasFile)
            {
                fileName = Path.GetFileName(picture.PostedFile.FileName);
                picture.PostedFile.SaveAs(Server.MapPath("~/img/art/") + fileName);
            }



            imgPath = "~/img/art/" + fileName.ToString();
            FileStream stream = new FileStream(Server.MapPath(imgPath), FileMode.Open, FileAccess.Read);
            byte[] pic = new byte[stream.Length];
            stream.Read(pic, 0, pic.Length);
            stream.Close();

            int adminID = Convert.ToInt32(Session["AdminID"]);
            int iD = Convert.ToInt32(Request.QueryString["ARTIST"]);
            Artist artist = aga.GetArtistById(iD);

            Artwork newArtwork = new Artwork(artname.Value, genre.Value, arttype.Value, pic, discription.Value, iD, adminID);

            aga.InsertArtwork(newArtwork);

            // Update UI to show success message and link
            lblMessage.Text = "Artwork has been added successfully!";
            lblMessage.Visible = true;

            // Assuming you have a way to get the artist ID or name to include in the URL
            // For demonstration purposes, we'll assume the ID is being returned
            // int artistID = aga.GetLatestArtistID(); // Add this method in your API to fetch the latest artist ID

            hlViewArtist.NavigateUrl = "RemoveArtAndArtist.aspx";
            hlViewArtist.Visible = true;
        }
    }
}