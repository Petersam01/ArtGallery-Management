using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallary.Models
{
    public class ArtAdmin
    {
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string AdminType { get; set; }
        public string Password { get; set; }

        public ArtAdmin() { }

        public ArtAdmin(string name, string surname, string email, string position, string adminype, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Position = position;
            this.AdminType = adminype;
            this.Password = password;
        }
        public ArtAdmin(int adminID, string name, string surname, string email, string position, string adminype, string password)
        {
            this.AdminID = adminID;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Position = position;
            this.AdminType = adminype;
            this.Password = password;
        }
    }
}