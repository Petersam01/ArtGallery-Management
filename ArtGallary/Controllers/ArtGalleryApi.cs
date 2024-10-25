using ArtGallary.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ArtGallary.Controllers
{
    public class ArtGalleryApi
    {
        //Admin things i want to handle
        private ArtAdmin initAdmins(MySqlDataReader reader)
        {

            return new ArtAdmin
            {
                AdminID = Convert.ToInt32(reader["AdminID"]),
                Name = reader["Name"].ToString(),
                Surname = reader["Surname"].ToString(),
                Email = reader["Email"].ToString(),
                Position = reader["Position"].ToString(),
                AdminType = reader["AdminType"].ToString(),
                Password = reader["Password"].ToString(),

            };
        }

        public bool CreateAdmin(ArtAdmin newAdmin)
        {
            bool isCreated = false;
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                string sql = "INSERT INTO Admins(Name, Surname, Email,Position,AdminType, Password) " +
                    "VALUES(@Name, @Surname, @Email,@Position,@AdminType, @Password)";


                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", newAdmin.Name);
                    cmd.Parameters.AddWithValue("@Surname", newAdmin.Surname);
                    cmd.Parameters.AddWithValue("@Email", newAdmin.Email);
                    cmd.Parameters.AddWithValue("@Password", newAdmin.Position);
                    cmd.Parameters.AddWithValue("@AdminType", newAdmin.AdminType);
                    cmd.Parameters.AddWithValue("@Password", newAdmin.Password);


                    if (cmd != null)
                    {
                        isCreated = true;
                    }
                    cmd.ExecuteNonQuery();


                }
            }

            return isCreated;
        }

        public List<ArtAdmin> GetAllAdmins()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Admins";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<ArtAdmin> admins = new List<ArtAdmin>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admins.Add(initAdmins(reader));
                        }
                    }
                    connection.Close();
                    return admins;
                }
            }
        }


        public ArtAdmin GetAdminById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Admins " +
                    "WHERE AdminID =" + id + ";";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    ArtAdmin admins = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admins = initAdmins(reader);

                        }
                    }
                    connection.Close();
                    return admins;
                }
            }

        }
        public string GetAdminTypeById(int id)
        {
            string AdminType = "";
            string SQL_QUERY = "SELECT * FROM Admins " +
            "WHERE AdminID =" + id + ";";


            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {

                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    ArtAdmin admin = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string name, string surname, string email, string contacts, string DOB, string userType, string status, string password)
                            admin = new ArtAdmin
                            {
                                AdminID = Convert.ToInt32(reader["AdminID"]),
                                AdminType = reader["AdminType"].ToString(),


                            };

                        }
                    }
                    connection.Close();
                    return admin.AdminType;
                }
            }

        }



        public ArtAdmin GetAdminByEmail(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Admins " +
                    "WHERE Email ='" + email + "';";

                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    ArtAdmin admin = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admin = initAdmins(reader);

                        }
                    }
                    connection.Close();
                    return admin;
                }
            }
        }

        public ArtAdmin UpdateAdmin(ArtAdmin updateAdmin)
        {

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_UPDATE = "UPDATE Admins " +
                    " SET Name=@Name, Surname=@Surname, Email=@Email, Position=@Position, AdminType=@AdminType, Password=@Password" +
                    "WHERE AdminID=@AdminID";

                ArtAdmin tmpAdmin = GetAdminByEmail(updateAdmin.Email);
                int ID = 0;
                if (tmpAdmin == null)
                {
                    return null;
                }
                else
                {
                    ID = GetAdminByEmail(updateAdmin.Email).AdminID;
                }


                using (MySqlCommand cmd = new MySqlCommand(SQL_UPDATE, connection))
                {
                    cmd.Parameters.AddWithValue("@AdminID", ID);
                    cmd.Parameters.AddWithValue("@Name", updateAdmin.Name);
                    cmd.Parameters.AddWithValue("@Surname", updateAdmin.Surname);
                    cmd.Parameters.AddWithValue("@Email", updateAdmin.Email);
                    cmd.Parameters.AddWithValue("@Position", updateAdmin.Position);
                    cmd.Parameters.AddWithValue("@AdminType", updateAdmin.AdminType);
                    cmd.Parameters.AddWithValue("@Password", updateAdmin.Password);

                    cmd.ExecuteNonQuery();
                }
            }
            return updateAdmin;
        }


        public ArtAdmin AdminLogin(string email, string passwd)
        {
            string SQL_USER = "SELECT * FROM Admins Where Email = '" + email + "' and Password = '" + passwd + "';";
            ArtAdmin admin = null;

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {

                //Login for the admin
                using (MySqlCommand cmd = new MySqlCommand(SQL_USER, connection))
                {

                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admin = initAdmins(reader);

                        }
                    }

                    connection.Close();
                    return admin;
                }


            }



        }

        public bool CheckIfAdminEmailExists(string email)
        {
            using (MySqlConnection conn = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Admins WHERE Email = @Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //authentication admin
        public bool Authenticate(string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string sql = "SELECT COUNT(*) FROM Admins WHERE Email = @Email AND Password = @Password";


                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);


                    connection.Open();
                    //int count = (int)command.ExecuteScalar();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    // If the count is greater than zero, authentication is successful
                    return count > 0;
                }
            }
        }

        //functions to create Artists
        private Artist initArtist(MySqlDataReader reader)
        {
            byte[] profilePicture = null;
            // Check and assign the profile picture if not DBNull
            if (!Convert.IsDBNull(reader["ProfileImage"]))
            {
                profilePicture = (byte[])reader["ProfileImage"];
            }

            // Create and return a new Artist object with data from the reader
            return new Artist
            {
                ID = Convert.ToInt32(reader["ID"]),
                Name = reader["Name"].ToString(),
                Surname = reader["Surname"].ToString(),
                Email = reader["Email"].ToString(),
                Country = reader["Country"].ToString(),
                ProfilePicture = profilePicture,
                Status = reader["Status"].ToString(),
                AdminID = Convert.ToInt32(reader["AdminID"]),
            };

        }


        public bool InsertArtist(Artist newArtist)
        {
            bool isCreated = false;

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var sql = "INSERT INTO Artists (Name, Surname, Email, Country, ProfileImage,  Status, AdminID) " +
              "VALUES (@Name, @Surname, @Email, @Country, @ProfileImage, @Status, @AdminID)";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", newArtist.Name);
                    command.Parameters.AddWithValue("@Surname", newArtist.Surname);
                    command.Parameters.AddWithValue("@Email", newArtist.Email);
                    command.Parameters.AddWithValue("@Country", newArtist.Country);
                    command.Parameters.AddWithValue("@ProfileImage", newArtist.ProfilePicture);
                    command.Parameters.AddWithValue("@Status", newArtist.Status);
                    command.Parameters.AddWithValue("@AdminID", newArtist.AdminID);
                    if (command != null)
                    {
                        isCreated = true;
                    }

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return isCreated;
        }

        public List<Artist> GetAllArtists()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Artists";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<Artist> artist = new List<Artist>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artist.Add(initArtist(reader));
                        }
                    }
                    connection.Close();
                    return artist;
                }
            }
        }

       

        //public Bed GetBedCart
        public Artist GetArtistById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Artists " +
                    "WHERE ID =" + id + ";";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    Artist artist = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artist = initArtist(reader);

                        }
                    }
                    connection.Close();
                    return artist;
                }
            }

        }

        public string GetArtistTypeById(int id)
        {
            string bedType = "";

            // Connect to the database
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a MySqlCommand object
                MySqlCommand command = new MySqlCommand("SELECT Genres FROM Artists WHERE ID = @ID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@ID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    bedType = reader["Genres"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return bedType;
        }

        public void DeleteArtistById(int Id)
        {

            Artist updateBed = GetArtistById(Id);
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_UPDATE = "DELETE FROM Artists WHERE ID=@ID;";

                using (MySqlCommand cmd = new MySqlCommand(SQL_UPDATE, connection))
                {


                    cmd.Parameters.AddWithValue("@ID", Id);


                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public bool UpdateArtistStatus(int artistId, string newStatus)
        {
            bool isUpdated = false;

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var sql = "UPDATE Artists SET Status = @Status WHERE ID = @ID";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@ID", artistId);

                    int rowsAffected = command.ExecuteNonQuery();
                    isUpdated = rowsAffected > 0;
                }
                connection.Close();
            }
            return isUpdated;
        }



        public bool IsArtistCompatible(int artistID, string exhibitionGenre, string exhibitionArtType)
        {
            bool isCompatible = false;

            string query = "SELECT COUNT(*) FROM Artworks WHERE artID = @artistID AND Genre = @exhibitionGenre AND ArtType = @exhibitionArtType";

            using (MySqlConnection conn = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@artistID", artistID);
                    cmd.Parameters.AddWithValue("@exhibitionGenre", exhibitionGenre);
                    cmd.Parameters.AddWithValue("@exhibitionArtType", exhibitionArtType);

                    conn.Open();

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        isCompatible = true;
                    }
                }
            }

            return isCompatible;
        }


        //functions for Artwork
        private Artwork initArtwork(MySqlDataReader reader)
        {
            byte[] image = null;
            // Check and assign the profile picture if not DBNull
            if (!Convert.IsDBNull(reader["Image"]))
            {
                image = (byte[])reader["Image"];
            }

            // Create and return a new Artist object with data from the reader
            return new Artwork
            {
                artID = Convert.ToInt32(reader["artID"]),
                ArtName = reader["ArtName"].ToString(),
                Genre = reader["Genre"].ToString(),
                ArtType = reader["ArtType"].ToString(),
                Image = image,
                Description = reader["Description"].ToString(),
                ID = Convert.ToInt32(reader["ID"]),
                AdminID = Convert.ToInt32(reader["AdminID"]),
            };

        }


        public bool InsertArtwork(Artwork newArt)
        {
            bool isCreated = false;

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var sql = "INSERT INTO Artworks (ArtName, Genre, ArtType, Image, Description,  ID, AdminID) " +
              "VALUES (@ArtName, @Genre, @ArtType, @Image, @Description, @ID, @AdminID)";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ArtName", newArt.ArtName);
                    command.Parameters.AddWithValue("@Genre", newArt.Genre);
                    command.Parameters.AddWithValue("@ArtType", newArt.ArtType);
                    command.Parameters.AddWithValue("@Image", newArt.Image);
                    command.Parameters.AddWithValue("@Description", newArt.Description);
                    command.Parameters.AddWithValue("@ID", newArt.ID);
                    command.Parameters.AddWithValue("@AdminID", newArt.AdminID);
                    if (command != null)
                    {
                        isCreated = true;
                    }

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return isCreated;
        }



        public List<Artwork> GetArtworksById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Artworks WHERE ID = @id;";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    // Use parameterized query to avoid SQL injection
                    sqlCmd.Parameters.AddWithValue("@id", id);
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();

                    List<Artwork> artworks = new List<Artwork>();

                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Artwork artwork = initArtwork(reader);
                            artworks.Add(artwork);
                        }
                    }

                    connection.Close();
                    return artworks;
                }
            }
        }

        public Artwork GetArtwork2ById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Artworks " +
                    "WHERE artID =" + id + ";";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    Artwork artist = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artist = initArtwork(reader);

                        }
                    }
                    connection.Close();
                    return artist;
                }
            }

        }

        public string GetArtworkTypeById(int id)
        {
            string bedType = "";

            // Connect to the database
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a MySqlCommand object
                MySqlCommand command = new MySqlCommand("SELECT Genre FROM Artworks WHERE artID = @artID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@artID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    bedType = reader["Genre"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return bedType;
        }

        public void DeleteArtworkById(int Id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_DELETE = "DELETE FROM Artworks WHERE ID = @ID;";

                using (MySqlCommand cmd = new MySqlCommand(SQL_DELETE, connection))
                {
                    // Use the correct parameter name matching the query
                    cmd.Parameters.AddWithValue("@ID", Id);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        //end of  function

        // functions to handle exhibition
        private Exhibition initExhibition(MySqlDataReader reader)
        {
            byte[] profilePicture = null;
            byte[] artPicture = null;

            // Check and assign the profile picture if not DBNull
            if (!Convert.IsDBNull(reader["ProfileImage"]))
            {
                profilePicture = (byte[])reader["ProfileImage"];
            }

            // Check and assign the art picture if not DBNull
            if (!Convert.IsDBNull(reader["ArtImage"]))
            {
                artPicture = (byte[])reader["ArtImage"];
            }

            // Create and return a new Artist object with data from the reader
            return new Exhibition
            {
                ExID = Convert.ToInt32(reader["ExID"]),
                Name = reader["Name"].ToString(),
                Surname = reader["Surname"].ToString(),
                ArtName = reader["ArtName"].ToString(),
                Genre = reader["Genre"].ToString(),
                ArtType = reader["ArtType"].ToString(),
                ProfileImage = profilePicture,
                ArtImage = artPicture,
                AdminID = Convert.ToInt32(reader["AdminID"]),
            };
        }

        public bool CreatExhibition(Exhibition newExhibit)
        {
            bool isCreated = false;
                using (MySqlConnection conn = new MySqlConnection(Settings.CONNECTION_STRING))
                {
                conn.Open();
                var query = "INSERT INTO Exhibitions (Name, Surname, ArtName, Genre, ArtType, ProfileImage, ArtImage, AdminID) " +
                              "VALUES (@Name, @Surname, @ArtName, @Genre, @ArtType, @ProfileImage, @ArtImage, @AdminID);";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", newExhibit.Name);
                        cmd.Parameters.AddWithValue("@Surname", newExhibit.Surname);
                        cmd.Parameters.AddWithValue("@ArtName", newExhibit.ArtName);
                        cmd.Parameters.AddWithValue("@Genre", newExhibit.Genre);
                        cmd.Parameters.AddWithValue("@ArtType", newExhibit.ArtType);
                        cmd.Parameters.AddWithValue("@ProfileImage", newExhibit.ProfileImage);
                        cmd.Parameters.AddWithValue("@ArtImage", newExhibit.ArtImage);
                        cmd.Parameters.AddWithValue("@AdminID", newExhibit.AdminID);

                    if (cmd != null)
                         {
                          isCreated = true;
                         }
                       cmd.ExecuteNonQuery();
                    }
                conn.Close();
                }

            return isCreated;
        }

        public List<Exhibition> GetArtistsByGenreNature()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibitions WHERE Genre = 'Nature'";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<Exhibition> exhi = new List<Exhibition>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi.Add(initExhibition(reader));
                        }
                    }
                    connection.Close();
                    return exhi;
                }
            }
        }
        public List<Exhibition> GetArtistsByGenreHistoric()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibitions WHERE Genre = 'Historic'";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<Exhibition> exhi = new List<Exhibition>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi.Add(initExhibition(reader));
                        }
                    }
                    connection.Close();
                    return exhi;
                }
            }
        }

        public List<Exhibition> GetArtistsByGenreAnimal()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibitions WHERE Genre = 'Animal'";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<Exhibition> exhi = new List<Exhibition>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi.Add(initExhibition(reader));
                        }
                    }
                    connection.Close();
                    return exhi;
                }
            }
        }

        public List<Exhibition> GetArtistsByGenreAbstract()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibitions WHERE Genre = 'Abstract'";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<Exhibition> exhi = new List<Exhibition>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi.Add(initExhibition(reader));
                        }
                    }
                    connection.Close();
                    return exhi;
                }
            }
        }
        public List<Exhibition> GetArtistsByGenre(string genre)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                // Use parameterized query to prevent SQL injection and handle special characters
                string SQL_QUERY = "SELECT * FROM Exhibitions WHERE Genre = @Genre";

                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    // Add parameter to the command
                    cmd.Parameters.AddWithValue("@Genre", genre);

                    List<Exhibition> exhi = new List<Exhibition>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi.Add(initExhibition(reader));
                        }
                    }

                    connection.Close();
                    return exhi;
                }
            }
        }

        public Exhibition GetExhibitionsById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibitions " +
                    "WHERE ExID =" + id + ";";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    Exhibition exhi = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi = initExhibition(reader);

                        }
                    }
                    connection.Close();
                    return exhi;
                }
            }

        }

        public Exhibition GetArtistExhiByGenre(string genre)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibitions WHERE Genre = @Genre;";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    // Use a parameterized query
                    sqlCmd.Parameters.AddWithValue("@Genre", genre);

                    Exhibition exhi = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi = initExhibition(reader);
                        }
                    }
                    connection.Close();
                    return exhi;
                }
            }
        }


        //m actually deleting an exhibition not the content inside
        public void DeleteExhibitionById(int Id)
        {

            Exhibits updateBed = GetExhibitById(Id);
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_UPDATE = "DELETE FROM Exhibit WHERE ID=@ID;";

                using (MySqlCommand cmd = new MySqlCommand(SQL_UPDATE, connection))
                {


                    cmd.Parameters.AddWithValue("@ID", Id);


                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        public void DeleteArtistFromExhibition(string genre)
        {

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_UPDATE = "DELETE FROM Exhibitions WHERE Genre=@Genre;";

                using (MySqlCommand cmd = new MySqlCommand(SQL_UPDATE, connection))
                {


                    cmd.Parameters.AddWithValue("@Genre", genre);


                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

        }


        //end of functions

        //functions to handle bookings

        private Booking initBookings(MySqlDataReader reader)
        {

            return new Booking
            {
                BookingID = Convert.ToInt32(reader["BookingID"]),
                Name = reader["Name"].ToString(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"].ToString(),
                Date = Convert.ToDateTime(reader["Date"]),
                NumberOfPeople = Convert.ToInt32(reader["NumberOfPeople"]),
                ExhibitionName = reader["ExhibitionName"].ToString(),
                Password = reader["Password"].ToString(),
            };

        }

        public bool insertBookings(Booking newBooking)
        {
            bool isCreated = false;
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                string sql = "INSERT INTO Bookings (Name, Email, Phone,Date, NumberOfPeople, ExhibitionName, Password) " +
                             "VALUES (@Name, @Email, @Phone,@Date, @NumberOfPeople, @ExhibitionName, @Password)";

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    // Adding parameters with corresponding values
                    cmd.Parameters.AddWithValue("@Name", newBooking.Name);
                    cmd.Parameters.AddWithValue("@Email", newBooking.Email);
                    cmd.Parameters.AddWithValue("@Phone", newBooking.Phone);
                    cmd.Parameters.AddWithValue("@Date", newBooking.Date);
                    cmd.Parameters.AddWithValue("@NumberOfPeople", newBooking.NumberOfPeople);
                    cmd.Parameters.AddWithValue("@ExhibitionName", newBooking.ExhibitionName);
                    cmd.Parameters.AddWithValue("@Password", newBooking.Password);

                    // Execute the command
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isCreated = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log the error)
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                connection.Close();
            }

            return isCreated;

        }

        public List<Booking> GetAllBookings()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Bookings";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<Booking> book = new List<Booking>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book.Add(initBookings(reader));
                        }
                    }
                    connection.Close();
                    return book;
                }
            }
        }


        public Booking GetBookingsById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Bookings " +
                    "WHERE BookingID =" + id + ";";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    Booking book = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book = initBookings(reader);

                        }
                    }
                    connection.Close();
                    return book;
                }
            }

        }
        public string GetBookingsTypeById(int id)
        {
            string AdminType = "";
            string SQL_QUERY = "SELECT * FROM Bookings " +
            "WHERE BookingID =" + id + ";";


            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {

                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    Booking book = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string name, string surname, string email, string contacts, string DOB, string userType, string status, string password)
                            book = new Booking
                            {
                                BookingID = Convert.ToInt32(reader["BookingID"]),
                                ExhibitionName = reader["ExhibitionName"].ToString(),


                            };

                        }
                    }
                    connection.Close();
                    return book.ExhibitionName;
                }
            }

        }


        public string GetBookingsByExhibitionName(string exhibitionName)
        {
            string exhibition = "";
            string SQL_QUERY = "SELECT * FROM Bookings " +
                               "WHERE ExhibitionName = @ExhibitionName;";

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ExhibitionName", exhibitionName); // Use parameterized query to avoid SQL injection

                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Read only one record
                        {
                            exhibition = reader["ExhibitionName"].ToString();
                        }
                    }
                    connection.Close();
                }
            }
            return exhibition;
        }


        public int GetTotalNumberOfPeopleForExhibition(string exhibitionName)
        {
            int totalNumberOfPeople = 0;
            string SQL_QUERY = "SELECT SUM(NumberOfPeople) AS TotalPeople " +
                               "FROM Bookings " +
                               "WHERE ExhibitionName = @ExhibitionName;";

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ExhibitionName", exhibitionName); // Use parameterized query to avoid SQL injection

                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["TotalPeople"] != DBNull.Value)
                        {
                            totalNumberOfPeople = Convert.ToInt32(reader["TotalPeople"]);
                        }
                    }
                    connection.Close();
                }
            }
            return totalNumberOfPeople;
        }

        //counts the registration for an exhibition 
        public int GetTotalRegistrationForExhibition(string exhibitionName)
        {
            int totalNumberOfRegistrations = 0;
            string SQL_QUERY = "SELECT COUNT(*) AS TotalReg " +
                               "FROM Bookings " +
                               "WHERE ExhibitionName = @ExhibitionName;";

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ExhibitionName", exhibitionName); // Use parameterized query to avoid SQL injection

                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["TotalReg"] != DBNull.Value)
                        {
                            totalNumberOfRegistrations = Convert.ToInt32(reader["TotalReg"]);
                        }
                    }
                    connection.Close();
                }
            }
            return totalNumberOfRegistrations;
        }


        public ExhibitionPopularity GetPopularity(string exhibitionName)
        {
            //string connectionString = Settings.CONNECTION_STRING;
            string query = @"
        SELECT ExhibitionName, COUNT(*) AS Count 
        FROM Bookings 
        WHERE ExhibitionName IN ('Abstract', 'Animal', 'Historic', 'Nature') 
        GROUP BY ExhibitionName";

            List<ExhibitionPopularity> exhibitions = new List<ExhibitionPopularity>();

            using (MySqlConnection conn = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    exhibitions.Add(new ExhibitionPopularity
                    {
                        ExhibitionName = reader["ExhibitionName"].ToString(),
                        Count = Convert.ToInt32(reader["Count"])
                    });
                }
            }

            // Sort exhibitions by count (descending)
            var sortedExhibitions = exhibitions.OrderByDescending(e => e.Count).ToList();

            // Rank the exhibitions and assign popularity descriptions
            for (int i = 0; i < sortedExhibitions.Count; i++)
            {
                if (i == 0)
                {
                    sortedExhibitions[i].Popularity = "Most popular";
                }
                else if (i == 1)
                {
                    sortedExhibitions[i].Popularity = "Second most popular";
                }
                else if (i == 2)
                {
                    sortedExhibitions[i].Popularity = "Not popular - consider changing advertising style";
                }
                else if (i == 3)
                {
                    sortedExhibitions[i].Popularity = "Not popular - consider canceling the exhibition";
                }
            }

            // Find the specific exhibition based on the input
            var specificExhibition = sortedExhibitions.FirstOrDefault(e => e.ExhibitionName == exhibitionName);

            if (specificExhibition == null)
            {
                return new ExhibitionPopularity
                {
                    ExhibitionName = exhibitionName,
                    Count = 0,
                    Popularity = "No data available for this exhibition"
                };
            }

            return specificExhibition;
        }


        public List<DateTime> GetBookingDatesByExhibition(string exhibitionName)
        {
            var dates = new List<DateTime>();

            string query = "SELECT DISTINCT Date FROM Bookings WHERE ExhibitionName = @ExhibitionName";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExhibitionName", exhibitionName);
                        connection.Open();

                        Console.WriteLine($"Querying dates for exhibition: {exhibitionName}");

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    dates.Add(reader.GetDateTime(0));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBookingDatesByExhibition: {ex.Message}");
            }

            return dates;
        }

        public int GetRegistrationCountByExhibitionAndDate(string exhibitionName, DateTime date)
        {
            int count = 0;

            string query = "SELECT COUNT(*) FROM Bookings WHERE ExhibitionName = @ExhibitionName AND Date = @Date";

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExhibitionName", exhibitionName);
                    command.Parameters.AddWithValue("@Date", date);
                    connection.Open();

                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return count;
        }


        public int GetTotalRegistrationsByDate(string exhibitionName, DateTime date)
        {
            int totalNumberOfRegistrations = 0;
            string SQL_QUERY = "SELECT COUNT(*) AS TotalReg " +
                               "FROM Bookings " +
                               "WHERE ExhibitionName = @ExhibitionName AND DATE(Date) = @Date";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ExhibitionName", exhibitionName);
                        cmd.Parameters.AddWithValue("@Date", date.Date); // Ensure only date portion is used

                        Console.WriteLine($"Querying registrations for {exhibitionName} on {date.ToString("yyyy-MM-dd")}");

                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader["TotalReg"] != DBNull.Value)
                            {
                                totalNumberOfRegistrations = Convert.ToInt32(reader["TotalReg"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTotalRegistrationsByDate: {ex.Message}");
            }

            return totalNumberOfRegistrations;
        }




        //end of functions

        //Add exhibition functions
        private Exhibits initExhibits(MySqlDataReader reader)
        {
            byte[] image = null;

            // Check and assign the profile picture if not DBNull
            if (!Convert.IsDBNull(reader["Image"]))
            {
                image = (byte[])reader["Image"];
            }

            return new Exhibits
            {
                ID = Convert.ToInt32(reader["ID"]),
                ExhibitDate = reader["ExhibitDate"].ToString(),
                Type = reader["Type"].ToString(),
                About = reader["About"].ToString(),
                Image = image,
                AdminID = Convert.ToInt32(reader["AdminID"])
            };
        }

        public bool insertExhibit( Exhibits newExhibits)
        {
            bool isCreated = false;
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                string sql = "INSERT INTO Exhibit(ExhibitDate, Type, About,Image,AdminID) " +
                    "VALUES(@ExhibiTDate, @Type, @About,@Image,@AdminID)";


                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@ExhibitDate", newExhibits.ExhibitDate);
                    cmd.Parameters.AddWithValue("@Type", newExhibits.Type);
                    cmd.Parameters.AddWithValue("@About", newExhibits.About);
                    cmd.Parameters.AddWithValue("@Image", newExhibits.Image);
                    cmd.Parameters.AddWithValue("@AdminID", newExhibits.AdminID);


                    if (cmd != null)
                    {
                        isCreated = true;
                    }
                    cmd.ExecuteNonQuery();


                }
            }

            return isCreated;
        }


        public List<Exhibits> GetAllExhibits()
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibit";
                using (MySqlCommand cmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    List<Exhibits> artist = new List<Exhibits>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artist.Add(initExhibits(reader));
                        }
                    }
                    connection.Close();
                    return artist;
                }
            }
        }


        public Exhibits GetExhibitById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Exhibit " +
                    "WHERE ID =" + id + ";";

                using (MySqlCommand sqlCmd = new MySqlCommand(SQL_QUERY, connection))
                {
                    Exhibits exhi = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (MySqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exhi = initExhibits(reader);

                        }
                    }
                    connection.Close();
                    return exhi;
                }
            }

        }

        public string GetExhibitTypeById(int id)
        {
            string type = "";

            // Connect to the database
            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a MySqlCommand object
                MySqlCommand command = new MySqlCommand("SELECT Type FROM Exhibit WHERE ID = @ID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@ID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    type = reader["Type"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return type;
        }

        public List<Exhibits> GetExhibitsByType(string type)
        {
            List<Exhibits> exhibitsList = new List<Exhibits>();

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Exhibit WHERE Type = @Type", connection);
                command.Parameters.AddWithValue("@Type", type);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Exhibits exhibit = new Exhibits
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        ExhibitDate = reader["ExhibitDate"].ToString(),
                        Type = reader["Type"].ToString(),
                        Image = (byte[])reader["Image"]
                    };
                    exhibitsList.Add(exhibit);
                }

                reader.Close();
                connection.Close();
            }

            return exhibitsList;
        }


        //boookings
        public int CountDate(string exhibitionName, DateTime date)
        {
            int count = 0;

            string query = "SELECT COUNT(*) FROM Bookings WHERE ExhibitionName = @ExhibitionName AND DATE(Date) = @Date";

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExhibitionName", exhibitionName);
                    command.Parameters.AddWithValue("@Date", date.Date);
                    connection.Open();

                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return count;
        }


        public int CountTotalBookings()
        {
            int count = 0;

            string query = "SELECT COUNT(*) FROM Bookings";

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return count;
        }
        //deleting users with the same genre
        public void DeleteUserFromBookings(string genre)
        {

            using (MySqlConnection connection = new MySqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_UPDATE = "DELETE FROM Bookings WHERE ExhibitionName=@ExhibitionName;";

                using (MySqlCommand cmd = new MySqlCommand(SQL_UPDATE, connection))
                {


                    cmd.Parameters.AddWithValue("@ExhibitionName", genre);


                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

    }
}