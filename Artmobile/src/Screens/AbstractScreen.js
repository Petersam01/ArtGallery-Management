import React, { useEffect, useState } from 'react';
import { SafeAreaView, StyleSheet, View, Text, Image, Button, ScrollView, ActivityIndicator } from 'react-native';
import axios from 'axios';

const AbstractScreen = ({ navigation }) => {
  const [exhibition, setExhibition] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchAbstract = () =>{
    axios.get('http://10.0.2.2:3000/exhibition/abstract')
          .then(response =>{
            setExhibition(response.data); 
            setLoading(false);
          })
            .catch(error => {
              console.error('Error fetching exhibitions:', error);
              setLoading(false);
            });
        };

  useEffect(() => {
      // Initial fetch on component mount
      fetchAbstract();

      // Polling to fetch data every 30 seconds
      const interval = setInterval(() => {
        fetchAbstract();
      }, 30000); // 30 seconds interval
  
      // Cleanup interval on component unmount
      return () => clearInterval(interval);
  }, []);

  if (loading) {
    return (
      <SafeAreaView style={styles.container}>
        <ActivityIndicator size="large" color="#6200EE" />
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.container}>
      {/* Top banner */}
      <View style={styles.banner}>
        <Text style={styles.bannerText}>Abstract Exhibition</Text>
      </View>

      <ScrollView contentContainerStyle={styles.scrollContainer}>
        {/* Screen content */}
        <View style={styles.innerText}>
          <Image source={require('../assets/images/logo1.jpg')} style={styles.image} />
        </View>

        <View>
          <Text style={styles.atext}>
          An abstract exhibition features artwork that explores shapes, colors, and forms in non-representational ways,
           encouraging viewers to interpret and engage with the art on a personal level. Without depicting specific objects or scenes, 
           abstract pieces evoke emotions and ideas through dynamic compositions and creative expression. 
          </Text>
        </View>

        {/* Display the artist for exhibition */}
        <View>
          <Text style={styles.artText}>Artists on Exhibition</Text>
        </View>

        <View style={styles.imageContainer}>
          {exhibition.map(artist => (
            <View style={styles.artistContainer} key={artist.ID}>
              <Image 
                style={styles.artistImage} 
                source={{ uri: `data:image/jpeg;base64,${artist.artImage}` }} 
              />
              <Text style={styles.artistName}>{artist.name}</Text>
              <Text style={styles.artistName}>{artist.surname}</Text>
              <Text style={styles.artistName}>{artist.artname}</Text>
              <Text style={styles.artistName}>{artist.arttype}</Text>
            </View>
          ))}
        </View>

        <View style={styles.buttonContainer}>
          <Button title="Register Exhibition" onPress={() => navigation.navigate('RegAbstract')} />
        </View>
      </ScrollView>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f5f5f5',
  },
  scrollContainer: {
    flexGrow: 1, // Allows ScrollView to take up available space
    padding: 20,
  },
  image: {
    width: '100%',
    height: 300, // Adjust the size of the image
    resizeMode: 'cover', // Adjust how the image scales
  },
  banner: {
    width: '100%',
    height: 80, // Adjusted height for better appearance
    backgroundColor: 'skyblue', // Banner background color
    padding: 15,
    alignItems: 'center',
    justifyContent: 'center', // Center text vertically
  },
  bannerText: {
    fontSize: 24,
    color: 'white',
    fontWeight: 'bold',
  },
  innerText: {
    fontSize: 24,
    fontWeight: 'bold',
    textAlign: 'center',
  },
  artText: {
    marginTop: 30,
    fontSize: 24,
    fontWeight: 'bold',
    color: 'black',
    textAlign: 'center',
  },
  atext: {
    marginTop: 30,
    fontSize: 16,
  },
  imageContainer: {
    justifyContent: 'center',
    alignItems: 'center',
  },
  artistContainer: {
    marginBottom: 20, // Added margin for spacing
  },
  artistImage: {
    height: 200,
    width: 350,
    resizeMode: 'cover',
    marginBottom: 10, // Space between image and text
    borderRadius: 10, // Optional: rounded corners
  },
  buttonContainer: {
    width: '50%',
    paddingHorizontal: 20,
    marginBottom: 20, // Adjust as needed for more space from the bottom
    alignItems: 'center',
    marginTop: 30,
    alignSelf: 'center',
  },
  artistName: {
    fontSize: 18,
    fontWeight: 'bold',
    color: '#333',
    textAlign: 'center', // Center text horizontally
  },
});

export default AbstractScreen;
