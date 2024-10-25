using ArtGallary.Controllers;
using ArtGallary.Models;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class ViewStats : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();
        protected void Page_Load(object sender, EventArgs e)
        {
            getExhData();
            getExhData2();
            countRegistrations();
        }

        protected string ItemsPieData
        {
            get
            {
                // Fetch data from the database
                var labels = new List<string>();
                var bookings = new List<int>();

                using (MySqlConnection connection = new MySqlConnection(Controllers.Settings.CONNECTION_STRING))
                {
                    connection.Open();
                    // Update query to sum up NumberOfPeople for each ExhibitionName
                    using (MySqlCommand command = new MySqlCommand(
                        "SELECT ExhibitionName, SUM(NumberOfPeople) AS TotalPeople " +
                        "FROM Bookings " +
                        "WHERE ExhibitionName IN ('Abstract', 'Animal', 'Historic', 'Nature') " +
                        "GROUP BY ExhibitionName", connection))
                    {
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            labels.Add(reader.GetString(0)); // ExhibitionName
                            bookings.Add(reader.GetInt32(1)); // TotalPeople
                        }
                    }
                }

                // Convert the data to JSON for the chart
                var data = new
                {
                    labels = labels,
                    datasets = new[]
                    {
                new
                {
                    data = bookings,
                    backgroundColor = new[]
                    {
                        "rgba(255, 99, 132, 0.5)",
                        "rgba(75, 192, 192, 0.5)",
                        "rgba(255, 206, 86, 0.5)",
                        "rgba(150, 77, 66, 0.5)"
                    }
                }
            }
                };

                return new JavaScriptSerializer().Serialize(data);
            }
        }


        protected string ItemsData
        {
            get
            {
                var labels = new List<string>();
                var numTimesOrdered = new List<int>();

                using (MySqlConnection connection = new MySqlConnection(Controllers.Settings.CONNECTION_STRING))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT ExhibitionName, COUNT(*) AS Count FROM Bookings GROUP BY ExhibitionName", connection))
                    {
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            labels.Add(reader.GetString(0));
                            numTimesOrdered.Add(reader.GetInt32(1));
                        }
                    }
                }

                var data = new
                {
                    labels = labels,
                    datasets = new[]
                    {
                new
                {
                    label = "Number Of bookings per exhibitions",
                    data = numTimesOrdered,
                    backgroundColor = "rgba(75, 192, 192, 0.2)",
                    borderColor = "rgba(75, 192, 192, 1)",
                    borderWidth = 1
                }
            }
                };

                return new JavaScriptSerializer().Serialize(data);
            }
        }

      

        public void getExhData()
        {
            string lines = "";

            try
            {
                // counting th number of people who will attend
                string name = Request.QueryString["Abstract"] ?? "Abstract";
                string name2 = Request.QueryString["Animal"] ?? "Animal";
                string name3 = Request.QueryString["Historic"] ?? "Historic";
                string name4 = Request.QueryString["Nature"] ?? "Nature";

                int abstractt = aga.GetTotalNumberOfPeopleForExhibition(name);
                int animal = aga.GetTotalNumberOfPeopleForExhibition(name2);
                int history = aga.GetTotalNumberOfPeopleForExhibition(name3);
                int nature = aga.GetTotalNumberOfPeopleForExhibition(name4);

                //for registrations
                int abs = aga.GetTotalRegistrationForExhibition(name);
                int anim = aga.GetTotalRegistrationForExhibition(name2);
                int his = aga.GetTotalRegistrationForExhibition(name3);
                int nat = aga.GetTotalRegistrationForExhibition(name4);

                //popularity
                ExhibitionPopularity exPopAbs = aga.GetPopularity(name);
                ExhibitionPopularity exPopAnim = aga.GetPopularity(name2);
                ExhibitionPopularity exPopHis = aga.GetPopularity(name3);
                ExhibitionPopularity exPopNat = aga.GetPopularity(name4);

                // Begin table HTML
                lines += " <h3>Popular Exhibitions by Registrations</h3> ";
                lines += " <table class='table table-striped table-bordered'> ";
                lines += " <thead> ";
                lines += " <tr> ";
                lines += " <th>Exhibition Name</th>";
                lines += " <th>Number of Registrations</th> ";
                lines += " <th>Number of People registered</th> ";
                lines += " <th>Popularity</th> ";
                lines += " </tr> ";
                lines += " </thead> ";
                lines += " <tbody> ";

                // First row (Abstract)
                lines += " <tr> ";
                lines += " <td>Abstract</td> ";
                lines += $" <td>{abs}</td> ";
                lines += $" <td>{abstractt} </td> ";  // You can change this to dynamic data
                lines += $" <td>{exPopAbs.ExhibitionName}: {exPopAbs.Count}: {exPopAbs.Popularity}</td> ";
                lines += " </tr> ";

                // Second row (Animal)
                lines += " <tr> ";
                lines += " <td>Animal</td> ";
                lines += $" <td>{anim}</td> ";
                lines += $" <td>{animal}</td> ";  // You can change this to dynamic data
                lines += $" <td>{exPopAnim.ExhibitionName}: {exPopAnim.Count}: {exPopAnim.Popularity}</td> ";
                lines += " </tr> ";

                // third row (Animal)
                lines += " <tr> ";
                lines += " <td>Historic</td> ";
                lines += $" <td>{his}</td> ";
                lines += $" <td>{history}</td> ";  // You can change this to dynamic data
                lines += $" <td>{exPopHis.ExhibitionName}: {exPopHis.Count}: {exPopHis.Popularity}</td> ";
                lines += " </tr> ";

                // last row (Animal)
                lines += " <tr> ";
                lines += " <td>Nature</td> ";
                lines += $" <td>{nat}</td> ";
                lines += $" <td>{nature}</td> ";  // You can change this to dynamic data
                lines += $" <td>{exPopNat.ExhibitionName}: {exPopNat.Count}: {exPopNat.Popularity}</td> ";
                lines += " </tr> ";

                lines += " </tbody> ";
                lines += " </table> ";

                // Set the inner HTML of the div
                exdata.InnerHtml = lines;
            }
            catch (Exception ex)
            {
                // Add error handling and debug output
                exdata.InnerHtml = "Error: " + ex.Message;
            }
        }

        //for daily decision
        public void getExhData2()
        {
            string lines = "";

            // Exhibition names
            string name = Request.QueryString["Abstract"] ?? "Abstract";
            string name2 = Request.QueryString["Animal"] ?? "Animal";
            string name3 = Request.QueryString["Historic"] ?? "Historic";
            string name4 = Request.QueryString["Nature"] ?? "Nature";

            // Get booking dates for each exhibition
            List<DateTime> absDate = aga.GetBookingDatesByExhibition(name);
            List<DateTime> animDate = aga.GetBookingDatesByExhibition(name2);
            List<DateTime> hisDate = aga.GetBookingDatesByExhibition(name3);
            List<DateTime> natDate = aga.GetBookingDatesByExhibition(name4);

            // Count the number of registrations for each date (aggregated by day)
            var absCountByDate = CountRegistrationsByDate(absDate);
            var animCountByDate = CountRegistrationsByDate(animDate);
            var hisCountByDate = CountRegistrationsByDate(hisDate);
            var natCountByDate = CountRegistrationsByDate(natDate);

            // Build the HTML table
            lines += "<h3>Number of Bookings Per Day for Each Exhibition</h3>";
            lines += "<table class='table table-striped table-bordered'>";
            lines += "<thead>";
            lines += "<tr>";
            lines += "<th>Exhibition Name</th>";
            lines += "<th>Booking Date</th>";
            lines += "<th>Number of Bookings</th>";
            lines += "</tr>";
            lines += "</thead>";
            lines += "<tbody>";

            // Generate rows for Abstract
            lines += GenerateHtmlRows("Abstract", absCountByDate);

            // Generate rows for Animal
            lines += GenerateHtmlRows("Animal", animCountByDate);

            // Generate rows for Historic
            lines += GenerateHtmlRows("Historic", hisCountByDate);

            // Generate rows for Nature
            lines += GenerateHtmlRows("Nature", natCountByDate);

            lines += "</tbody>";
            lines += "</table>";

            exdata2.InnerHtml = lines;
        }

        // Helper method to count registrations by date (grouping by day only)
        private Dictionary<DateTime, int> CountRegistrationsByDate(List<DateTime> dates)
        {
            var dateCount = new Dictionary<DateTime, int>();

            foreach (var date in dates)
            {
                DateTime dayOnly = date.Date;  // Remove time component and keep only the date part

                if (dateCount.ContainsKey(dayOnly))
                {
                    dateCount[dayOnly]++;
                }
                else
                {
                    dateCount[dayOnly] = 1;
                }
            }

            return dateCount;
        }

        // Helper method to generate HTML rows for each exhibition's dates and counts
        private string GenerateHtmlRows(string exhibitionName, Dictionary<DateTime, int> countByDate)
        {
            string rows = "";

            foreach (var entry in countByDate)
            {
                rows += "<tr>";
                rows += $"<td>{exhibitionName}</td>";
                rows += $"<td>{entry.Key.ToString("yyyy-MM-dd")}</td>";
                rows += $"<td>{entry.Value}</td>";
                rows += "</tr>";
            }
            return rows;
        }


        public void countRegistrations()
        {
            string lines = "";
            int countReg = aga.CountTotalBookings();

            lines += "  <center><h2>Total Registrations</h2></center> ";
            lines += " <div class='container justify-content-center number-box' style='margin-top:2%;width:100px;height: 100px;background-color: deepskyblue; color: white;display: flex;justify-content:center;align-items:center;font-size: 2em;border-radius:10px;'> ";

            lines += $" <h3>{countReg}</h3> ";
            lines += " </div> ";

            count.InnerHtml = lines;
        }
    }
}