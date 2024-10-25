import { AppRegistry } from 'react-native';
import App from '../Artmobile';
import { name as appName } from './app.json';

import HomeScreen from '../Artmobile/src/Screens/HomeScreen'

AppRegistry.registerComponent(appName, () => HomeScreen);
