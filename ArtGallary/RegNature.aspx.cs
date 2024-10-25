using ArtGallary.Controllers;
using ArtGallary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class RegNature : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (int.TryParse(number.Value, out int numberOfPeople))
            {
                // Create a new booking
                Booking newBooking = new Booking(name.Value, email.Value, phone.Value, DateTime.Now, numberOfPeople, "Nature", password.Value);
                bool bookingInserted = aga.insertBookings(newBooking);

                if (bookingInserted)
                {
                    // Display success message
                    lblSuccessMessage.Text = "You have successfully registered for the exhibition! An email will be sent with the full details of the event.";
                    lblSuccessMessage.Visible = true;

                    // TODO: Implement email sending logic here
                    // Example: SendEmail(newBooking);

                    // Optionally redirect after a short delay if required
                    // Response.Redirect("./CurrentExhibition.aspx");
                }
                else
                {
                    // Handle booking insertion failure
                    lblSuccessMessage.Text = "There was an error processing your registration. Please try again.";
                    lblSuccessMessage.Visible = true;
                }
            }
            else
            {
                // Handle invalid number input
                lblSuccessMessage.Text = "Please enter a valid number of people attending.";
                lblSuccessMessage.Visible = true;
            }
        }

        // Example method to send an email (to be implemented)
        private void SendEmail(Booking booking)
        {
            // Implement email sending logic here
        }

    }
}