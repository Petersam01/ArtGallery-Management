import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { SafeAreaView, StyleSheet,View,Text, Image,Button, ActivityIndicator } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';

const AImage = require('../assets/images/logo1.jpg');
const HistoricScreen = ({navigation}) => {
  const [exhibition, setExhibition] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchHistoric = () =>{
    axios.get('http://10.0.2.2:3000/exhibition/historic')
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
       fetchHistoric();

       // Polling to fetch data every 30 seconds
       const interval = setInterval(() => {
        fetchHistoric();
       }, 30000); // 30 seconds interval
   
       // Cleanup interval on component unmount
       return () => clearInterval(interval);
  }, []);

  if(loading){
    return(
      <SafeAreaView style={styles.container}>
        <ActivityIndicator size="large" color="#6200EE"/>
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.container}>
       
       { /*Top banner */}
       <View style={styles.banner}>
        <Text style={styles.bannerText}>Historic Exhibition</Text>
       </View>
       <ScrollView>
       { /*start of screen items */}
      <View style={styles.innerText}>
        <Image source={AImage} style={styles.image}/>
      </View>
      <View>
        <Text style={styles.atext}>Historic exhibitions showcase artifacts, artworks, and documents from significant periods in history, 
          offering a glimpse into past civilizations, cultures, and events. These exhibitions often highlight key moments in history, 
          such as ancient empires, wars, revolutions, or cultural renaissances, through carefully curated displays. Visitors can explore 
          the evolution of art, technology, and society by viewing original relics, manuscripts, and masterpieces that shaped the course of history.
        </Text>
      </View>
      {/* Display the artist for exhibition */}
      <View>
        <Text style={styles.artText}>Artist on exhibition for Historic</Text>
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
          <Button title="Register Exhibition" onPress={() => navigation.navigate('RegHistoric')} />
          </View>

      </ScrollView>
    </SafeAreaView>
  );
};

const styles =StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#f5f5f5',
    },
    image: {
        width: '100%',
        height: 300, // Adjust the size of the image
        resizeMode: 'cover', // Adjust how the image scales
      },
      banner: {
        width: '100%',
        height: '12%',
        backgroundColor: 'skyblue', // Banner background color
        padding: 15,
        alignItems: 'center',
      },
      bannerText: {
        fontSize: 24,
        color: 'white',
        fontWeight: 'bold',
        justifyContent: 'center',
      },
    innerText:{
        fontSize: 24,
        fontWeight: 'bold',
        justifyContent: 'center',
        textAlign: 'center'
    },
    artText:{
      marginTop: 30,
      fontSize: 24,
      fontWeight: 'bold',
      color: 'black',
       textAlign: 'center'
    },
    atext:{
      marginTop: 30,
      fontSize1: 16,
    },
    imageContainer: {        // Take full space
      justifyContent: 'center', // Centers vertically
      alignItems: 'center',    // Centers horizontally
    },
    artistImage: {
      marginTop: 30,
      height: 200,
      width: 350,
      resizeMode: 'cover',
      justifyContent: 'center',
      alignItems: 'center',
    },
    buttonContainer: {
      width: '50%',
      paddingHorizontal: 20,
      marginBottom: 20, // Adjust as needed for more space from the bottom
      alignItems: 'center',
      marginTop: 30,
      alignSelf: 'center',
    },

});
export default HistoricScreen;
