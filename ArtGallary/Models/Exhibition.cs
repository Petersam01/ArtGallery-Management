using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallary.Models
{
    public class Exhibition
    {
        public int ExID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ArtName { get; set; }
        public string Genre { get; set; }
        public string ArtType { get; set; }
        public byte[] ProfileImage { get; set; }
        public byte[] ArtImage { get; set; }
        public int AdminID { get; set; }

        // Default constructor
        public Exhibition()
        {
        }

        public Exhibition( string name, string surname, string artname, string genre, string artType, byte[] profileImage, byte[] artImage, int adminID)
        {
            Name = name;
            Surname = surname;
            ArtName = artname;
            Genre = genre;
            ArtType = artType;
            ProfileImage = profileImage;
            ArtImage = artImage;
            AdminID = adminID;
        }
        // Parameterized constructor
        public Exhibition(int exID, string name, string surname, string artname, string genre, string artType, byte[] profileImage, byte[] artImage, int adminID)
        {
            ExID = exID;
            Name = name;
            Surname = surname;
            ArtName = artname;
            Genre = genre;
            ArtType = artType;
            ProfileImage = profileImage;
            ArtImage = artImage;
            AdminID = adminID;
        }
    }
}