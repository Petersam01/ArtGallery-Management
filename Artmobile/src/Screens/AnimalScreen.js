import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { SafeAreaView, StyleSheet,View,Text, Image,Button,ScrollView, ActivityIndicator } from 'react-native';

const AImage = require('../assets/images/logo1.jpg');
const AnimalScreen = ({navigation}) => {
  const [exhibition, setExhibition] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchAnimal = () =>{
    axios.get('http://10.0.2.2:3000/exhibition/animal')
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
       fetchAnimal();

       // Polling to fetch data every 30 seconds
       const interval = setInterval(() => {
        fetchAnimal();
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
        <Text style={styles.bannerText}>Animal Exhibition</Text>
       </View>
       <ScrollView>
       { /*start of screen items */}
      <View style={styles.innerText}>
        <Image source={AImage} style={styles.image}/>
      </View>
      <View>
        <Text style={styles.atext}>An animal art exhibition celebrates the beauty and diversity of wildlife through various artistic mediums,
           showcasing paintings, sculptures, and photography that capture the essence of animals in nature. These exhibitions often highlight 
           the connection between humans and the animal world, offering viewers a chance to appreciate the intricate details, grace, and power of different species.
        </Text>
      </View>
      {/* Display the artist for exhibition */}
      <View>
        <Text style={styles.artText}>Artist on exhibition</Text>
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
          <Button title="Register Exhibition" onPress={() => navigation.navigate('RegAnimal')} />
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
export default AnimalScreen;
