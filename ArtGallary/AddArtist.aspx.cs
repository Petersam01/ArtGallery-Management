using ArtGallary.Controllers;
using ArtGallary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class AddArtist : System.Web.UI.Page
    {

        ArtGalleryApi aga = new ArtGalleryApi();
        ArtAdmin admin = new ArtAdmin();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (picture.HasFile)
            {
                fileName = Path.GetFileName(picture.PostedFile.FileName);
                picture.PostedFile.SaveAs(Server.MapPath("~/img/profile/") + fileName);
            }

           

            imgPath = "~/img/profile/" + fileName.ToString();
            FileStream stream = new FileStream(Server.MapPath(imgPath), FileMode.Open, FileAccess.Read);
            byte[] pic = new byte[stream.Length];
            stream.Read(pic, 0, pic.Length);
            stream.Close();

          

            int adminID = Convert.ToInt32(Session["AdminID"]);

            Artist newArtist = new Artist(name.Value, surname.Value, email.Value, country.Value, pic,  "Inactive",  adminID);

            aga.InsertArtist(newArtist);

            // Update UI to show success message and link
            lblMessage.Text = "Artist has been added successfully!";
            lblMessage.Visible = true;

            // Assuming you have a way to get the artist ID or name to include in the URL
            // For demonstration purposes, we'll assume the ID is being returned
           // int artistID = aga.GetLatestArtistID(); // Add this method in your API to fetch the latest artist ID

            hlViewArtist.NavigateUrl = "RemoveArtAndArtist.aspx";
            hlViewArtist.Visible = true;
        }

    }
}