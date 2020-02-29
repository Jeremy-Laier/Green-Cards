import * as React from 'react';
import { Text, View } from 'react-native';
import { Ionicons } from '@expo/vector-icons';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Profile from './screens/Profile'
import Overview from './screens/Overview'
import History from './screens/History'
import CameraScan from './screens/CameraScan'

function IconWithBadge({ name, badgeCount, color, size }) {
  return (
    <View style={{ width: 24, height: 24, margin: 5 }}>
      <Ionicons name={name} size={size} color={color} />
      {badgeCount > 0 && (
        <View
          style={{
            // On React Native < 0.57 overflow outside of parent will not work on Android, see https://git.io/fhLJ8
            position: 'absolute',
            right: -6,
            top: -3,
            backgroundColor: 'red',
            borderRadius: 6,
            width: 12,
            height: 12,
            justifyContent: 'center',
            alignItems: 'center',
          }}
        >
          <Text style={{ color: 'white', fontSize: 10, fontWeight: 'bold' }}>
            {badgeCount}
          </Text>
        </View>
      )}
    </View>
  );
}

function HomeIconWithBadge(props) {
  // You should pass down the badgeCount in some other ways like React Context API, Redux, MobX or event emitters.
  return <IconWithBadge {...props} badgeCount={3} />;
}

const Tab = createBottomTabNavigator();

export default function App() {
  return (
    <Tab.Navigator
      screenOptions={({ route }) => ({
        tabBarIcon: ({ focused, color, size }) => {
          if (route.name === 'Profile') {
            return (
              <Ionicons
                name='ios-contact'
                size={size}
                color={color}
              />
            );
          } else if (route.name === 'History') {
            return (
              <Ionicons
                name='ios-list'
                size={size}
                color={color}
              />
            );
          } else if (route.name === 'CameraScan') {
            return (
              <Ionicons
                name='ios-camera'
                size={size}
                color={color}
              />
            );
          } else if (route.name === 'Overview') {
            return (
              <Ionicons
                name='ios-analytics'
                size={size}
                color={color}
              />
            );
          }
        },
      })}
      tabBarOptions={{
        activeTintColor: 'tomato',
        inactiveTintColor: 'gray',
      }}
    >
      <Tab.Screen name="Overview" component={Overview} />
      <Tab.Screen name="History" component={History} />
      <Tab.Screen name="CameraScan" component={CameraScan} />
      <Tab.Screen name="Profile" component={Profile} />

    </Tab.Navigator>
  );
}
