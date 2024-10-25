const express = require('express');
const session = require('express-session');  // Import express-session here
const mysql = require('mysql');
const cors = require('cors');

const app = express();
const port = 3000;
const dbPort = 3306;

// Middleware setup
app.use(express.json({ limit: '50mb' }));
app.use(express.urlencoded({ limit: '50mb' }));
app.use(cors({ origin: '*' }));
// Configure session middleware
app.use(session({
  secret: 'users', // Replace with a secure secret
  resave: false,
  saveUninitialized: true,
  cookie: { secure: true } // Use `true` if using HTTPS
}));


const connection = mysql.createPool({
    host: 'localhost',
    port: dbPort,
    user: 'root',
    password: '',
    database: 'art',
    connectionLimit: 10, // limit number of connections in the pool
    connectTimeout: 10000, // 10 seconds
    acquireTimeout: 30000, // 30 seconds
    ssl: {
        rejectUnauthorized: false,
    }
});

connection.getConnection((err, connection) => {
    if (err) {
        console.error('Error connecting to the database:', err);
        return;
    }
    console.log('Connected to database with thread ID:', connection.threadId);
    connection.release(); // release the connection back to the pool
});


// General function to retrieve exhibitions
async function getExhibitions() {
  return new Promise((resolve, reject) => {
    const query = 'SELECT ID, ExhibitDate, Type, About, Image, AdminID FROM exhibit';
    connection.query(query, (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }

      // Map and format the results
      const exhibitions = results.map(row => ({
        ID: row.ID,
        date: row.ExhibitDate,
        type: row.Type,
        about: row.About,
        image: row.Image ? row.Image.toString('base64') : null,  // Convert image to base64
        AdminId: row.AdminID,
      }));

      resolve(exhibitions);
    });
  });
}

// API endpoint to get exhibitions
app.get('/exhibit', async (req, res) => {
  try {
    const exhibits = await getExhibitions();
    res.json(exhibits);  // Send the exhibitions as JSON response
  } catch (err) {
    res.status(500).send('Error retrieving exhibitions');
  }
});

//function to get artist by type= abstract
async function getArtistsByType() {
  return new Promise((resolve, reject) => {
    const query = `
      SELECT ExID, Name, Surname,ArtName, ArtType, ArtImage 
      FROM exhibitions 
      WHERE Genre = 'Abstract' `;

    connection.query(query, (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }

      // Map and format the results
      const artists = results.map(row => ({
        ID: row.ExID,
        name: row.Name,
        surname: row.Surname,
        artname: row.ArtName,
        arttype: row.ArtType,
        artImage: row.ArtImage ? row.ArtImage.toString('base64') : null  // Convert image to base64 if exists
      }));

      resolve(artists);
    });
  });
}

// API endpoint to get artists of type "Abstract"
app.get('/exhibition/abstract', async (req, res) => {
  try {
    const artists = await getArtistsByType();  // No need to pass type, as it's hardcoded to "Abstract"
    res.json(artists);  // Send the artists as JSON response
  } catch (err) {
    console.error('Error retrieving artists:', err);
    res.status(500).send('Error retrieving artists');
  }
});

//create get function which gets animal exhibition data
async function getArtistsAnimal(){
  return new Promise((resolve, reject) =>{
    const query = `
    SELECT ExID, Name, Surname, ArtName, ArtType, ArtImage 
    FROM exhibitions 
    WHERE Genre = 'Animal' `;

    connection.query(query, (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }

      // Map and format the results
     // Map and format the results
     const artists = results.map(row => ({
      ID: row.ExID,
      name: row.Name,
      surname: row.Surname,
      artname: row.ArtName,
      arttype: row.ArtType,
      artImage: row.ArtImage ? row.ArtImage.toString('base64') : null  // Convert image to base64 if exists
    }));


      resolve(artists);
    });
  });
}

app.get('/exhibition/animal', async (req, res) => {
  try {
    const artists = await getArtistsAnimal();  // No need to pass type, as it's hardcoded to "Animal"
    res.json(artists);  // Send the artists as JSON response
  } catch (err) {
    console.error('Error retrieving artists:', err);
    res.status(500).send('Error retrieving artists');
  }
});

//function to retreave historic
async function getArtistsHistoric(){
  return new Promise((resolve, reject) =>{
    const query = `
    SELECT ExID, Name, Surname, ArtName, ArtType, ArtImage 
    FROM exhibitions 
    WHERE Genre = 'Historic' `;

    connection.query(query, (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }

      // Map and format the results
      // Map and format the results
      const artists = results.map(row => ({
        ID: row.ExID,
        name: row.Name,
        surname: row.Surname,
        artname: row.ArtName,
        arttype: row.ArtType,
        artImage: row.ArtImage ? row.ArtImage.toString('base64') : null  // Convert image to base64 if exists
      }));


      resolve(artists);
    });
  });
}

app.get('/exhibition/historic', async (req, res) => {
  try {
    const artists = await getArtistsHistoric();  // No need to pass type, as it's hardcoded to "Animal"
    res.json(artists);  // Send the artists as JSON response
  } catch (err) {
    console.error('Error retrieving artists:', err);
    res.status(500).send('Error retrieving artists');
  }
});

//reteaving artist of type nature
async function getArtistsNature(){
  return new Promise((resolve, reject) =>{
    const query = `
    SELECT ExID, Name, Surname, ArtName, ArtType, ArtImage 
    FROM exhibitions 
    WHERE Genre = 'Nature' `;

    connection.query(query, (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }

      // Map and format the results
     // Map and format the results
     const artists = results.map(row => ({
      ID: row.ExID,
      name: row.Name,
      surname: row.Surname,
      artname: row.ArtName,
      arttype: row.ArtType,
      artImage: row.ArtImage ? row.ArtImage.toString('base64') : null  // Convert image to base64 if exists
    }));


      resolve(artists);
    });
  });
}

app.get('/exhibition/nature', async (req, res) => {
  try {
    const artists = await getArtistsNature();  // No need to pass type, as it's hardcoded to "Animal"
    res.json(artists);  // Send the artists as JSON response
  } catch (err) {
    console.error('Error retrieving artists:', err);
    res.status(500).send('Error retrieving artists');
  }
});


//function to handle bookings
/*async function bookings(name, email, phone, numberOfPeople,exhibitionName, password) {
  return new Promise((resolve, reject) => {
    // SQL query to insert the user into the database
    const query = `
      INSERT INTO Bookings (Name, Email, Phone, NumberOfPeople, ExhibitionName, Password)
      VALUES (?, ?, ?, ?, ?, ?)
    `;

    // Parameters to be inserted into the query
    const values = [name, email, phone, numberOfPeople, exhibitionName, password];

    // Execute the query
    connection.query(query, values, (err, result) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err); // Reject with error
      }
      // Resolve the promise if the query was successful
      resolve({
        message: 'User registered successfully',
        BookingID: result.insertId, // Return the ID of the newly inserted user
      });
    });
  });
}
// Define an endpoint for registration
app.post('/booking', async (req, res) => {
  const { name, email, phone, numberOfPeople, exhibitionName, password} = req.body;

  try {
    // Call the registerUser function to insert user into the database
    const result = await bookings(name, email, phone, numberOfPeople, exhibitionName, password);
    
    res.status(200).json({ message: 'User registered successfully', userId: result.userId });
  } catch (error) {
    res.status(500).json({ message: 'Registration failed', error: error.message });
  }
}); */

async function bookings(name, email, phone, numberOfPeople, exhibitionName, password) {
  return new Promise((resolve, reject) => {
    const currentDate = new Date(); // Get the current date and time
    const formattedDate = `${currentDate.getFullYear()}-${String(currentDate.getMonth() + 1).padStart(2, '0')}-${String(currentDate.getDate()).padStart(2, '0')} ${String(currentDate.getHours()).padStart(2, '0')}:${String(currentDate.getMinutes()).padStart(2, '0')}:${String(currentDate.getSeconds()).padStart(2, '0')}`;

    const query = `
      INSERT INTO Bookings (Name, Email, Phone, Date, NumberOfPeople, ExhibitionName, Password)
      VALUES (?, ?, ?, ?, ?, ?, ?)
    `;

    const values = [name, email, phone, formattedDate, numberOfPeople, exhibitionName, password];

    connection.query(query, values, (err, result) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }
      // Resolve the promise including BookingID and BookingDate
      resolve({
        message: 'User registered successfully',
        BookingID: result.insertId,
        BookingDate: formattedDate // Include the booking date and time in the response
      });
    });
  });
}

app.post('/booking', async (req, res) => {
  console.log("Request Body:", req.body); // Log the request body

  const { name, email, phone, numberOfPeople, exhibitionName, password } = req.body;

  if (!name || !email || !phone || !numberOfPeople || !password) {
    return res.status(400).json({ message: 'All fields are required' });
  }

  try {
    const result = await bookings(name, email, phone, numberOfPeople, exhibitionName, password);

    res.status(200).json({
      message: 'User registered successfully',
      BookingID: result.BookingID,
      BookingDate: result.BookingDate
    });
  } catch (error) {
    res.status(500).json({ message: 'Registration failed', error: error.message });
  }
});




//login function
// Function to handle user login
async function login(email, password) {
  return new Promise((resolve, reject) => {
    // SQL query to find the user by email and password
    const query = `SELECT * FROM Bookings WHERE Email = ? AND Password = ?`;

    // Parameters for the query
    const values = [email, password];

    // Execute the query
    connection.query(query, values, (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err); // Reject with error
      }

      // Check if any result was found
      if (results.length > 0) {
        resolve({
          message: 'Login successful',
          user: results[0], // Return the user data
        });
      } else {
        reject(new Error('Invalid email or password')); // Reject if no match
      }
    });
  });
}

// Define an endpoint for login
/*app.post('/login', async (req, res) => {
  const { email, password } = req.body;

  try {
    // Call the login function to authenticate the user
    const result = await login(email, password);

    res.status(200).json({
      message: result.message,
      user: result.user, // Returning user data on successful login
    });
  } catch (error) {
    res.status(401).json({
      message: 'Login failed',
      error: error.message, // Provide the error message
    });
  }
}); */
app.post('/login', async (req, res) => {
  const { email, password } = req.body;

  try {
    // Call the login function to authenticate the user
    const result = await login(email, password);

    // If authentication is successful, store user data in session
    req.session.user = result.user;

    res.status(200).json({
      message: result.message,
      user: result.user, // Returning user data on successful login
    });
  } catch (error) {
    res.status(401).json({
      message: 'Login failed',
      error: error.message, // Provide the error message
    });
  }
});



//function which gets booking for the user
/*async function getUserBooking(userId){
  return new Promise((resolve, reject) => {
    const query = `SELECT BookingID, Name, Email, Phone, NumberOfPeople, ExhibitionName FROM Bookings WHERE BookingID = ${userId}`;
    connection.query(query, [userId], (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }

      // Map and format the results
      const book = results.map(row => ({
        id: row.BookingID,
        name: row.Name,
        email: row.Email,
        phone: row.Phone,
        numberOfPeople: row.NumberOfPeople,  // Convert image to base64
        exhibitionName: row.ExhibitionName,
      }));

      resolve(book);
    });
  });
}*/
/*app.get('/profile', async (req, res) => {
  try {
    const book = await getUserBooking();
    res.json(book);  // Send the exhibitions as JSON response
  } catch (err) {
    res.status(500).send('Error retrieving profile');
  }
});*/

async function getUserBooking(userId) {
  return new Promise((resolve, reject) => {
    const query = 'SELECT BookingID, Name, Email, Phone, NumberOfPeople, ExhibitionName FROM Bookings WHERE Email = ?';
    connection.query(query, [userId], (err, results) => {
      if (err) {
        console.error('Error executing query:', err);
        return reject(err);
      }

     
      const book = results.length > 0 ? results[0] : null;
      resolve(book);
    });
  });
}
app.get('/profile/:userId', async (req, res) => {
  const userId = req.params.userId;
  try {
    const book = await getUserBooking(userId);
    if (book) {
      res.json(book);  // Send the profile as JSON response
    } else {
      res.status(404).send('Profile not found');
    }
  } catch (err) {
    res.status(500).send('Error retrieving profile');
  }
});








// Logout function - POST request
app.post('/logout', (req, res) => {
  req.session.destroy((err) => {
    if (err) {
      return res.status(500).send('Error occurred during logout');
    }
    res.clearCookie('connect.sid'); // This is the default session cookie
    return res.status(200).send('Logged out successfully');
  });
});

// Sample route to check session status
app.get('/status', (req, res) => {
  if (req.session.user) {
    return res.send(`Logged in as ${req.session.user.username}`);
  }
  res.send('Not logged in');
});

// Start the server
app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});
