using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallary.Models
{
    public class Booking
    {
        // Properties corresponding to the columns in the 'bookings' table
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public string ExhibitionName { get; set; }
        public string Password { get; set; }
        // Default constructor
        public Booking()
        {
        }

        // Constructor with parameters
        public Booking(int bookingID, string name, string email, string phone, DateTime date, int numberOfPeople, string exhibitionName, string password)
        {
            BookingID = bookingID;
            Name = name;
            Phone = phone;
            Email = email;
            Date = date;
            NumberOfPeople = numberOfPeople;
            ExhibitionName = exhibitionName;
            Password = password;
        }

        // Constructor without BookingID (e.g., for inserting new records)
        public Booking(string name, string email, string phone, DateTime date, int numberOfPeople, string exhibitionName, string password)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Date = date;
            NumberOfPeople = numberOfPeople;
            ExhibitionName = exhibitionName;
            Password = password;
        }
    }
}