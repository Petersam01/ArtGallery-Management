import React, { useEffect, useState } from 'react';
import { SafeAreaView, StyleSheet, Text, View, Image, ScrollView, TouchableOpacity, ActivityIndicator } from 'react-native';
import axios from 'axios';

const ExhibitionScreen = ({ navigation }) => {
  const [exhibitions, setExhibitions] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchExhibitions = () =>{
    axios.get('http://10.0.2.2:3000/exhibit')
          .then(response =>{
            setExhibitions(response.data); 
            setLoading(false);
          })
            .catch(error => {
              console.error('Error fetching exhibitions:', error);
              setLoading(false);
            });
        };

  useEffect(() => {
    // Initial fetch on component mount
    fetchExhibitions();

    // Polling to fetch data every 30 seconds
    const interval = setInterval(() => {
      fetchExhibitions();
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
      {/* Top Banner */}
      <View style={styles.banner}>
        <Text style={styles.bannerText}>Welcome to the Exhibition</Text>
      </View>
      
      <ScrollView contentContainerStyle={styles.scrollContainer}>

      <View>
        <Image  source={require('../assets/images/logo1.jpg')} style={styles.topImage}/>
        <Text style={styles.exhibitionName}>Select the exhibition which picks your interest</Text>
      </View>

        {/* Exhibition Boxes */}
        <View style={styles.exhibitionContainer}>
          {exhibitions.map(exhibition => (
            <View style={styles.exhibitionBox} key={exhibition.ID}>
              <Image 
                style={styles.exhibitionImage} 
                source={{ uri: `data:image/jpeg;base64,${exhibition.image}` }} 
              />
              <Text style={styles.exhibitionName}>{exhibition.type}</Text>
              <Text style={styles.exhibitionDate}>{exhibition.date}</Text>
              <Text style={styles.exhibitionAbout}>{exhibition.about}</Text>
              <TouchableOpacity 
                style={styles.exhibitionButton} 
                onPress={() => navigation.navigate(exhibition.type)}
              >
                <Text style={styles.buttonText}>View Exhibiton</Text>
              </TouchableOpacity>
            </View>
          ))}
        </View>
      </ScrollView>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f5f5f5', // Light background
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
  topImage: {
    width: 120,
    height: 120, // Adjust the size of the image
    resizeMode: 'cover', // Adjust how the image scales
    justifyContent: 'center',
    marginTop: 15,
    marginBottom: 10,
    alignSelf: 'center',
    borderRadius: 50
  },
  exhibitionContainer: {
    flex: 1,
    flexDirection: 'row',
    flexWrap: 'wrap',
    justifyContent: 'space-around',
    padding: 10,
  },
  exhibitionBox: {
    width: '45%', // 45% of screen width for two boxes per row
    alignItems: 'center',
    marginBottom: 20,
    backgroundColor: '#fff',
    borderRadius: 10,
    padding: 10,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.3,
    shadowRadius: 2,
    elevation: 3, // For Android shadow
  },
  exhibitionImage: {
    width: '100%',
    height: 150,
    borderRadius: 10,
  },
  exhibitionName: {
    marginTop: 10,
    fontSize: 18,
    fontWeight: 'bold',
    color: '#333',
    alignItems: 'center',
    justifyContent: 'center',
    marginBottom: 10,
    alignSelf: 'center'
  },
  exhibitionDate: {
    marginTop: 5,
    fontSize: 14,
    color: '#666',
  },
  exhibitionAbout: {
    marginTop: 5,
    fontSize: 12,
    color: '#666',
    textAlign: 'center',
  },
  exhibitionButton: {
    marginTop: 10,
    backgroundColor: '#6200EE',
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 5,
  },
  buttonText: {
    color: 'white',
    fontWeight: 'bold',
  },
});

export default ExhibitionScreen;
