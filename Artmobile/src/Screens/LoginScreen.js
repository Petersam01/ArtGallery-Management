import React, { useEffect, useState } from 'react';
import { SafeAreaView, StyleSheet, Text, View, Image, Button, ScrollView, TextInput, Alert, ImageBackground } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

const image = require('../assets/images/logo2.jpeg');

const LoginScreen = ({ navigation }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async () => {
    const data = {
      email,
      password,
    };

    try {
      const response = await fetch('http://10.0.2.2:3000/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data), // Assuming data includes email and password
      });
    
      if (response.ok) {
        const responseData = await response.json(); // Get response data
    
        console.log('response.json() ->', responseData); // Log the response data
    
        // You may extract other user information from the responseData if needed
        const tempUserId = responseData.userId || email; // Use userId from response or fallback to email
    
        await AsyncStorage.setItem('userId', tempUserId); // Store userId to fetch profile
        Alert.alert('Success', 'Login successful');
        navigation.navigate('Profile'); // Navigate to Profile screen after login
      } else {
        Alert.alert('Error', 'Login failed');
      }
    } catch (error) {
      console.error('Error:', error);
      Alert.alert('Error', 'An error occurred. Please try again.');
    }
    
  }

  return (
    <SafeAreaView style={styles.container}>
      <ImageBackground source={image} resizeMode="cover" style={styles.image}>
        <View style={styles.overlay}>
          <Text style={styles.text}>Welcome To Petersam's Art Gallery</Text>
          <Text style={styles.text2}>
            Login to view your bookings
          </Text>
          <View>
            <Text style={styles.fromText}>Email</Text>
            <TextInput style={styles.txtInput} value={email} onChangeText={setEmail} keyboardType="email-address" />
            <Text style={styles.fromText}>Password</Text>
            <TextInput style={styles.txtInput} value={password} onChangeText={setPassword} secureTextEntry />
            <View style={styles.buttonContainer}>
              <Button title="Login" onPress={handleSubmit} />
            </View>
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
  buttonContainer: {
    width: '30%',
    paddingHorizontal: 20,
    marginBottom: 20, // Adjust as needed for more space from the bottom
    alignSelf: 'center',
    justifyContent: 'center'
  },
  fromText: {
    marginTop: 20,
    fontSize: 20,
    fontWeight: 'bold',
    textAlign: 'center'
  },
  txtInput: {
    width: '70%',
    height: 40,
    borderColor: 'green',
    alignItems: 'center',
    alignSelf: 'center',
    borderWidth: 2,
    paddingHorizontal: 15,
    marginBottom: 14,
    borderRadius: 20,
  },
  text: {
    fontSize: 40, // Adjusted font size
    textAlign: 'center',
    color: 'white',
    fontWeight: 'bold',
    marginBottom: 100, // Space between text and button
  },
  text2: {
    fontSize: 25,
    textAlign: 'center',
    fontWeight: 'bold',
    marginBottom: 30,
    color: 'blue', // Space between description and button
  },
  image: {
    flex: 1,
    width: '100%',
    height: '100%',
    justifyContent: 'center',
    resizeMode: 'cover', // Ensures image keeps aspect ratio without stretching
  },
});

export default LoginScreen;
