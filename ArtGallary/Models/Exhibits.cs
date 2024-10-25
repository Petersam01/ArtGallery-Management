using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallary.Models
{
    public class Exhibits
    {
        public int ID { get; set; }
        public string ExhibitDate { get; set; }
        public string Type { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }
        public int AdminID { get; set; }

        public Exhibits() { }
        public Exhibits( string exhibitDagte, string type, string about, byte[] image, int adminID)
        {
            ExhibitDate = exhibitDagte;
            Type = type;
            About = about;
            Image = image;
            AdminID = adminID;
        }
        public Exhibits(int iD, string exhibitDagte, string type, string about, byte[] image, int adminID)
        {
            ID = iD;
            ExhibitDate = exhibitDagte;
            Type = type;
            About = about;
            Image = image;
            AdminID = adminID;
        }
    }
}