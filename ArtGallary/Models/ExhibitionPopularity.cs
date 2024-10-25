using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallary.Models
{
    public class ExhibitionPopularity
    {
        public string ExhibitionName { get; set; }
        public int Count { get; set; }
        public string Popularity { get; set; }

        // Method to display exhibition popularity
        public void DisplayPopularity()
        {
            Console.WriteLine($"Exhibition Name: {ExhibitionName}");
            Console.WriteLine($"Number of Registrations: {Count}");
            Console.WriteLine($"Popularity: {Popularity}");
            Console.WriteLine(); // New line for better readability
        }

        // Static method to display a list of exhibition popularity
        public static void DisplayExhibitionsPopularity(List<ExhibitionPopularity> exhibitions)
        {
            foreach (var exhibition in exhibitions)
            {
                exhibition.DisplayPopularity();
            }
        }
    }
}
