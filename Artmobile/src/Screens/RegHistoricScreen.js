import React, { useState } from 'react';
import { SafeAreaView, StyleSheet, Text, View, Image, Button, ScrollView, TextInput, Alert } from 'react-native';

const RegHistoricScreen = ({ navigation }) => {
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [email, setEmail] = useState('');
  const [numberOfPeople, setNumberOfPeople] = useState('');
  const [password, setPassword] = useState('');
  const [successMessage, setSuccessMessage] = useState(''); // State to hold the success message

  // Email validation function
  const validateEmail = (email) => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      Alert.alert("Invalid Email", "Please enter a valid email address.");
    }
  };

  const handleSubmit = async () => {
    if (!name || !phone || !email || !numberOfPeople || !password) {
      Alert.alert("Error", "All fields must be filled out");
      return;
    }

    const exhibitionName = 'Historic';
    const data = {
      name,
      phone,
      email,
      numberOfPeople,
      exhibitionName,
      password,
    };

    try {
      const response = await fetch('http://10.0.2.2:3000/booking', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });

      if (response.ok) {
        Alert.alert('Success', 'registration successful');
        setSuccessMessage('Registration successful!'); // Show success message
        // Optional: Clear the form fields after successful registration
        setName('');
        setPhone('');
        setEmail('');
        setNumberOfPeople('');
        setPassword('');
      } else {
        Alert.alert('Error', 'Registration failed');
      }
    } catch (error) {
      console.error('Error:', error);
      Alert.alert('Error', 'An error occurred. Please try again.');
    }
  };

  const handleSubmit1 = async () => {
    navigation.navigate('Login');
  };

  return (
    <SafeAreaView style={styles.container}>
      {/* Banner */}
      <View style={styles.banner}>
        <Text style={styles.text}>Register for the History Exhibition</Text>
      </View>

      {/* Forms */}
      <ScrollView>
        <View>
          <Image source={require('../assets/images/logo.jpeg')} style={styles.topImage} />
          <Text style={styles.exhibitionName}>Fill in your details</Text>
        </View>

        <View>
          <Text style={styles.fromText}>Name/Company</Text>
          <TextInput style={styles.txtInput} value={name} onChangeText={setName} />

          <Text style={styles.fromText}>Phone</Text>
          <TextInput style={styles.txtInput} value={phone} onChangeText={setPhone} keyboardType="phone-pad" />

          <Text style={styles.fromText}>Email</Text>
          <TextInput
        style={styles.txtInput}
        value={email}
        onChangeText={(value) => setEmail(value)} // Set the email state whenever the text changes
        onBlur={() => validateEmail(email)} // Validate only when the input loses focus
        keyboardType="email-address"
        placeholder="Enter your email"
      />

          <Text style={styles.fromText}>Number of people</Text>
          <TextInput style={styles.txtInput} value={numberOfPeople} onChangeText={setNumberOfPeople} keyboardType="numeric" />

          {/* Exhibition Name is set by default */}
          <Text style={styles.fromText}>Exhibition Name</Text>
          <TextInput style={styles.txtInput} value="Historic" editable={false} />

          <Text style={styles.fromText}>Password</Text>
          <TextInput style={styles.txtInput} value={password} onChangeText={setPassword} secureTextEntry />

          <View style={styles.buttonContainer}>
            <Button title="Register Exhibition" onPress={handleSubmit} />
          </View>
        </View>

        {/* Success Message */}
        {successMessage ? (
          <Text style={styles.successMessage}>{successMessage}</Text>
        ) : null}

          {/* login */} 
          <View style={styles.buttonContainer}>
            <Button title="Login" onPress={handleSubmit1} />
          </View>
      </ScrollView>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  banner: {
    width: '100%',
    height: 80, // Adjusted height for better appearance
    backgroundColor: 'skyblue', // Banner background color
    padding: 15,
    alignItems: 'center',
    justifyContent: 'center', // Center text vertically
  },
  text: {
    fontSize: 20,
    fontWeight: 'bold',
    textAlign: 'center',
  },
  fromText: {
    marginTop: 20,
    fontSize: 20,
    fontWeight: 'bold',
    textAlign: 'center',
  },
  txtInput: {
    width: '70%',
    height: 40,
    borderColor: 'gray',
    alignItems: 'center',
    alignSelf: 'center',
    borderWidth: 2,
    paddingHorizontal: 15,
    marginBottom: 14,
    borderRadius: 20,
  },
  buttonContainer: {
    width: '50%',
    paddingHorizontal: 20,
    marginBottom: 20, // Adjust as needed for more space from the bottom
    alignItems: 'center',
    marginTop: 30,
    alignSelf: 'center',
  },
  exhibitionName: {
    marginTop: 10,
    fontSize: 18,
    fontWeight: 'bold',
    color: '#333',
    alignItems: 'center',
    justifyContent: 'center',
    marginBottom: 10,
    alignSelf: 'center',
  },
  topImage: {
    width: 120,
    height: 120, // Adjust the size of the image
    resizeMode: 'cover', // Adjust how the image scales
    justifyContent: 'center',
    marginTop: 15,
    marginBottom: 10,
    alignSelf: 'center',
    borderRadius: 50,
  },
  successMessage: {
    color: 'green',
    fontSize: 18,
    fontWeight: 'bold',
    textAlign: 'center',
    marginTop: 20,
    marginBottom: 20,
  },
});

export default RegHistoricScreen;
