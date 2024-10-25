using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallary.Models
{
    public class Artwork
    {
        public int artID { get; set; }
        public string ArtName { get; set; }
        public string Genre { get; set; }
        public string ArtType { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int ID { get; set; }
        public int AdminID { get; set; }  // Nullable to allow for optional foreign key

        public Artwork() { }
        public Artwork( string artName, string genre, string artType, byte[] image, string description, int iD, int adminID)
        {
           
            ArtName = artName;
            Genre = genre;
            ArtType = artType;
            Description = description;
            Image = image;
            ID = iD;
            AdminID = adminID;
        }
        public Artwork(int artID, string artName, string genre, string artType, byte[] image, string description, int iD, int adminID)
        {
            this.artID = artID;
            ArtName = artName;
            Genre = genre;
            ArtType = artType;
            Description = description;
            Image = image;
            ID = iD;
            AdminID = adminID;
        }
    }
}