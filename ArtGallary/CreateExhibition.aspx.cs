using ArtGallary.Controllers;
using ArtGallary.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class CreateExhibition : System.Web.UI.Page
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
                picture.PostedFile.SaveAs(Server.MapPath("~/img/exhi/") + fileName);

            }


            imgPath = "~/img/exhi/" + fileName.ToString();
            FileStream stream = new FileStream(Server.MapPath(imgPath), FileMode.Open, FileAccess.Read);
            byte[] pic = new byte[stream.Length];
            stream.Read(pic, 0, pic.Length);
            int adminID = Convert.ToInt32(Session["AdminID"]);
            Exhibits newArtist = new Exhibits(date.Value, type.Value, about.Value,pic, adminID);


            aga.insertExhibit(newArtist);
            Response.Redirect("./CurrentExhibition.aspx");
        }
    }
}