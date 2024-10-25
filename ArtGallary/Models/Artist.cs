using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallary.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Status { get; set; }
        public int AdminID { get; set; }  // Nullable to allow for optional foreign key

        // Parameterless constructor
        public Artist() { }

        // Constructor with parameters excluding AdminID
        public Artist(string name, string surname, string email, string country, byte[] profilePicture, string status, int adminID)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Country = country;
            ProfilePicture = profilePicture;
            Status = status;
            AdminID = adminID;
        }

        // Constructor with parameters including AdminID
        public Artist(int id, string name, string surname, string email, string country, byte[] profilePicture, string status,  int adminID)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
            Country = country;
            ProfilePicture = profilePicture;
            Status = status;
            AdminID = adminID;
        }
    }
}