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
    public partial class CurrentExhibition : System.Web.UI.Page
    {

        ArtGalleryApi aga = new ArtGalleryApi();
        protected void Page_Load(object sender, EventArgs e)
        {
            funcArtists();
            funcArtists2();
            funcArtists3();
            funcArtists4();
        }

        public void funcArtists()
        {
            string lines = "";
            string exhibitType = Request.QueryString["Animal"];

            foreach (Exhibits exhibit in aga.GetExhibitsByType("Animal"))
            {
               
                lines += $" <a href='AnimalExhibitions.aspx?EXHIBIT={exhibit.ID}'><img src='{Util.ByteArrayToImage(exhibit.Image)}' alt='' class='w-100 h-50'></a> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Type: {exhibit.Type}</h5> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Date: {exhibit.ExhibitDate}</h5> ";
                lines += " <div class='py-1'></div> ";
                lines += $" <a href='AnimalExhibitions.aspx?EXHIBIT={exhibit.ID}' class='btn btn-outline-primary btn-md'>More Info</a> ";
               
            }

            loadExhibits.InnerHtml = lines;
        }

        public void funcArtists2()
        {
            string lines = "";
            string exhibitType = Request.QueryString["Abstract"];

            foreach (Exhibits exhibit in aga.GetExhibitsByType("Abstract"))
            {
               
                lines += $" <a href='AbstractExhibitions.aspx?EXHIBIT={exhibit.ID}'><img src='{Util.ByteArrayToImage(exhibit.Image)}' alt='' class='w-100 h-50'></a> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Type: {exhibit.Type}</h5> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Date: {exhibit.ExhibitDate}</h5> ";
                lines += " <div class='py-1'></div> ";
                lines += $" <a href='AbstractExhibitions.aspx?EXHIBIT={exhibit.ID}' class='btn btn-outline-primary btn-md'>More Info</a> ";
                
            }

            loadExhibits2.InnerHtml = lines;
        }

        public void funcArtists3()
        {
            string lines = "";
            string exhibitType = Request.QueryString["Historic"];

            foreach (Exhibits exhibit in aga.GetExhibitsByType("Historic"))
            {
                lines += $" <a href='HistoricalExhibition.aspx?EXHIBIT={exhibit.ID}'><img src='{Util.ByteArrayToImage(exhibit.Image)}' alt='' class='w-100 h-50'></a> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Type: {exhibit.Type}</h5> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Date: {exhibit.ExhibitDate}</h5> ";
                lines += " <div class='py-1'></div> ";
                lines += $" <a href='HistoricalExhibition.aspx?EXHIBIT={exhibit.ID}' class='btn btn-outline-primary btn-md'>More Info</a> ";
               
            }

            loadExhibits3.InnerHtml = lines;
        }

        public void funcArtists4()
        {
            string lines = "";
            string exhibitType = Request.QueryString["Nature"];

            foreach (Exhibits exhibit in aga.GetExhibitsByType("Nature"))
            {
                lines += $" <a href='NatureExhibitions.aspx?EXHIBIT={exhibit.ID}'><img src='{Util.ByteArrayToImage(exhibit.Image)}' alt='' class='w-100 h-50'></a> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Type: {exhibit.Type}</h5> ";
                lines += $" <h5 class='my-2 text-dark'>Exhibition Date: {exhibit.ExhibitDate}</h5> ";
                lines += " <div class='py-1'></div> ";
                lines += $" <a href='NatureExhibitions.aspx?EXHIBIT={exhibit.ID}' class='btn btn-outline-primary btn-md'>More Info</a> ";
               
            }

            loadExhibits4.InnerHtml = lines;
        }
        private int getExhibit()
        {
            int Id = 0;

            using (MySqlConnection sqlCon = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string query = "SELECT ID FROM Exhibit LIMIT 1"; // Added LIMIT 1 to ensure a single result
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