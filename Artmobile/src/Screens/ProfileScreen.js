import React, { useState, useEffect } from 'react';
import { SafeAreaView, StyleSheet, Text, View, Button, ImageBackground, ActivityIndicator, ScrollView } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import axios from 'axios';

const backgroundImage = require('../assets/images/logo3.jpg');

const ProfileScreen = ({ navigation }) => {
  const [profile, setProfile] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const handleLogout = async () => {
    try {
      const token = await AsyncStorage.getItem('userToken');

      const response = await fetch('http://10.0.2.2:3000/logout', {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${token}`,
        },
      });
      {/**
        if (response.ok) {
        await AsyncStorage.clear();
        navigation.navigate('Login');
      } else {
        console.error('Logout failed:', response.statusText);
      } */}

      if (response.ok) {
        try {
          const allKeys = await AsyncStorage.getAllKeys();
          console.log('Before clearing:', allKeys); // Log keys before clearing
          
          await AsyncStorage.clear();
          console.log('Storage cleared');
        
          const clearedKeys = await AsyncStorage.getAllKeys();
          console.log('After clearing:', clearedKeys); // Log keys after clearing
          
          navigation.navigate('Login'); // Only navigate after storage is cleared
        } catch (e) {
          console.error('Failed to clear AsyncStorage:', e);
        }
        
      } else {
        console.error('Logout failed:', response.statusText);
      }
     
    } catch (error) {
      console.error('Error during logout:', error);
    }
  };
  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const userId = await AsyncStorage.getItem('userId');
  
        if (!userId) {
          throw new Error('User ID is missing');
        }
  
        // Make a request to fetch profile data without using a token
        const response = await axios.get(`http://10.0.2.2:3000/profile/${userId}`);
  
        // Log the full response to inspect its structure
        console.log('Full response:', response);
  
        if (response.status === 200) {
          console.log('Profile data:', response.data); // Log the profile data
          setProfile(response.data); // Set the profile data directly
        } else {
          throw new Error(`Failed to fetch profile data: ${response.statusText}`);
        }
      } catch (error) {
        console.error('Error fetching profile:', error.message);
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };
  
    fetchProfile();
  }, []);
  
  

  if (loading) {
    return (
      <SafeAreaView style={styles.container}>
        <ActivityIndicator size="large" color="#6200EE" />
      </SafeAreaView>
    );
  }

  if (error) {
    return (
      <SafeAreaView style={styles.container}>
        <Text style={styles.errorText}>{`Error loading profile data: ${error}`}</Text>
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.container}>
      <ImageBackground source={backgroundImage} resizeMode="cover" style={styles.image}>
        <ScrollView>
        <View style={styles.overlay}>
        {profile && (
              <View style={styles.profileContainer}>
                <Text style={styles.heading}>Profile Page</Text>

                <View style={styles.profileItem}>
                  <Text style={styles.label}>Name:</Text>
                  <Text style={styles.value}>{profile.Name || 'N/A'}</Text>
                </View>

                <View style={styles.profileItem}>
                  <Text style={styles.label}>Phone Number:</Text>
                  <Text style={styles.value}>{profile.Phone || 'N/A'}</Text>
                </View>

                <View style={styles.profileItem}>
                  <Text style={styles.label}>Email Address:</Text>
                  <Text style={styles.value}>{profile.Email || 'N/A'}</Text>
                </View>

                <View style={styles.profileItem}>
                  <Text style={styles.label}>Number of People Attending:</Text>
                  <Text style={styles.value}>{profile.NumberOfPeople || 'N/A'}</Text>
                </View>

                <View style={styles.profileItem}>
                  <Text style={styles.label}>Exhibition Name:</Text>
                  <Text style={styles.value}>{profile.ExhibitionName || 'N/A'}</Text>
                </View>

                <View style={styles.logoutButton}>
                  <Button title="Logout" onPress={handleLogout} />
                </View>
              </View>
            )}
        </View>
        </ScrollView>
      </ImageBackground>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  image: {
    flex: 1,
    justifyContent: 'center',
  },
  overlay: {
    flex: 1,
    backgroundColor: 'rgba(0, 0, 0, 0.5)', // Darken the background image for better text visibility
    justifyContent: 'center',
    padding: 20,
    marginTop: 180,
  },
  profileContainer: {
    backgroundColor: 'rgba(255, 255, 255, 0.8)', // Semi-transparent white background
    padding: 20,
    borderRadius: 10,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.3,
    shadowRadius: 5,
    elevation: 5,
  },
  heading: {
    fontSize: 24,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 20,
  },
  profileItem: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginBottom: 15,
  },
  label: {
    fontWeight: 'bold',
    fontSize: 16,
  },
  value: {
    fontSize: 16,
  },
  logoutButton: {
    marginTop: 30,
    alignSelf: 'center',
  },
  errorText: {
    color: 'red',
    fontSize: 18,
    textAlign: 'center',
    marginTop: 20,
  },
});

export default ProfileScreen;
