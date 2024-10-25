import React from 'react';
import { NativeAppEventEmitter, SafeAreaView, StyleSheet, Text, View } from 'react-native';
import HomeScreen from '../Artmobile/src/Screens/HomeScreen'
import ExhibitionScreen from '../Artmobile/src/Screens/ExhibitionScreen'
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { NavigationContainer } from '@react-navigation/native';
import AbstractScreen from './src/Screens/AbstractScreen';
import NatureScreen from './src/Screens/NatureScreen';
import { Icon } from 'react-native-vector-icons/Ionicons';
import AnimalScreen from './src/Screens/AnimalScreen';
import HistoricScreen from './src/Screens/HistoricScreen';
import { createStackNavigator } from '@react-navigation/stack';
import RegAbstractScreen from './src/Screens/RegAbstractScreen';
import RegAnimalScreen from './src/Screens/RegAnimalScreen';
import RegHistoricScreen from './src/Screens/RegHistoricScreen';
import RegNatureScreen from './src/Screens/RegNatureScreen';
import LoginScreen from './src/Screens/LoginScreen';
import ProfileScreen from './src/Screens/ProfileScreen';

const App = () => {
  const TabNav=createBottomTabNavigator();
  const StackNav = createStackNavigator();

  function TabNavigator() {
    return (
      <TabNav.Navigator screenOptions={({ route }) => ({
        tabBarStyle: {
          backgroundColor: 'white', // Lime Green color
        },
        tabBarActiveTintColor: 'blue', // Black color for active tab
        tabBarInactiveTintColor: '#00000', // White color for inactive tabs
        headerShown: false, // Hide headers if needed
      })} >
        <TabNav.Screen name="Home" component={HomeScreen} options={{ headerShown: false }} />
        <TabNav.Screen name="Exhibition" component={ExhibitionScreen} options={{ headerShown: false }} />
        <TabNav.Screen 
        name="Abstract" 
        component={AbstractScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />
       <TabNav.Screen 
        name="Animal" 
        component={AnimalScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />

<TabNav.Screen 
        name="Historic" 
        component={HistoricScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />
       <TabNav.Screen 
        name="Nature" 
        component={NatureScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />

<TabNav.Screen 
        name="RegAbstract" 
        component={RegAbstractScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />

<TabNav.Screen 
        name="RegAnimal" 
        component={RegAnimalScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />

<TabNav.Screen 
        name="RegHistoric" 
        component={RegHistoricScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />
<TabNav.Screen 
        name="RegNature" 
        component={RegNatureScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />
      <TabNav.Screen 
        name="Login" 
        component={LoginScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />
      <TabNav.Screen 
        name="Profile" 
        component={ProfileScreen} 
        options={{ 
          headerShown: false, 
          tabBarButton: () => null, // Hide the tab button
        }} 
      />

      </TabNav.Navigator>

    );
  }
  return (
   /* <SafeAreaView style={styles.container}>
      <View>
        <HomeScreen/>
      </View>
    </SafeAreaView>*/
    <NavigationContainer>
      <StackNav.Navigator>
        {/* Tab Navigator */}
        <StackNav.Screen name="Tabs" component={TabNavigator} options={{ headerShown: false }} />

        {/* Abstract Screen (not in bottom navigation) */}
        <StackNav.Screen name="Abstract" component={AbstractScreen} options={{ headerShown: false }} />
        <StackNav.Screen name="Animal" component={AnimalScreen} options={{ headerShown: false }} />
        <StackNav.Screen name="Historic" component={HistoricScreen} options={{ headerShown: false }} />
        <StackNav.Screen name="Nature" component={NatureScreen} options={{ headerShown: false }} />
        <StackNav.Screen name="RegAbstract" component={RegAbstractScreen} options={{ headerShown: false }} />
        <StackNav.Screen name="RegAnimal" component={RegAnimalScreen} options={{headerShown: false}} />
        <StackNav.Screen name="RegHistoric" component={RegHistoricScreen} options={{headerShown: false}} />
        <StackNav.Screen name="RegNature" component={RegNatureScreen} options={{headerShown: false}} />
        <StackNav.Screen name="Login" component={LoginScreen} options={{headerShown: false}} />
        <StackNav.Screen name="Profile" component={ProfileScreen} options={{headerShown: false}} />
      </StackNav.Navigator>
    </NavigationContainer>

  );
};

export default App;
