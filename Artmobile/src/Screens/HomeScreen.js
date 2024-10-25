import React from 'react';
import { SafeAreaView, StyleSheet, Text, View, ImageBackground, Button } from 'react-native';

const image = require('../assets/images/logo3.jpg');

const HomeScreen = ({navigation}) => {

  return (
    <SafeAreaView style={styles.container}>
      <ImageBackground source={image} resizeMode="cover" style={styles.image}>
        <View style={styles.overlay}>
          <Text style={styles.text}>Welcome To Petersam's Art Gallery</Text>
          <Text style={styles.text2}>
            Where art comes to life and proving you acces to the most talented exhebitors of this generation
          </Text>
          <View style={styles.buttonContainer}>
            <Button title="View Exhibitions" onPress={() => navigation.navigate('Exhibition')} />
           
          </View>
          <View  style={styles.btn2}>
            <Button title="Profile" onPress={() => navigation.navigate('Login')}/>
          </View>
        </View>
      </ImageBackground>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  btn2: {
    marginBottom: 10,
    width: '30%',
    paddingHorizontal: 20,
     paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 5,
  },
  image: {
    flex: 1,
    width: '100%',
    height: '100%',
    justifyContent: 'center',
    resizeMode: 'cover', // Ensures image keeps aspect ratio without stretching
  },
  overlay: {
    flex: 1,
    justifyContent: 'flex-end', // Moves content to the bottom
    alignItems: 'center',
    backgroundColor: 'rgba(0, 0, 0, 0.5)', // Optional: Adds a transparent overlay
    paddingBottom: 50, // Adds space at the bottom
  },
  text: {
    fontSize: 40, // Adjusted font size
    textAlign: 'center',
    color: 'white',
    fontWeight: 'bold',
    marginBottom: 110, // Space between text and button
  },
  text2: {
    fontSize: 25,
    textAlign: 'center',
    fontWeight: 'bold',
    marginBottom: 50,
    color: 'gray', // Space between description and button
  },
  buttonContainer: {
    width: '50%',
    paddingHorizontal: 20,
    marginBottom: 20, // Adjust as needed for more space from the bottom
    color: '#666',
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 5,
  },
});

export default HomeScreen;
