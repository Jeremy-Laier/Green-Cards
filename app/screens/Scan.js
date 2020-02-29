import React from 'react';
import { View, StyleSheet, Dimensions, Text, Alert, TouchableOpacity } from 'react-native';
import * as Permissions from 'expo-permissions';
import { Camera } from 'expo-camera';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import { Ionicons } from '@expo/vector-icons';

const TabIcon = (props) => (
  <Ionicons
    name={'md-apps'}
    size={35}
    color={props.focused ? 'grey' : 'darkgrey'}
  />
)

export default class Scan extends React.Component {

  camera = null;

  state = {
    hasCameraPermission: null,
  };

  // static navigationOptions = {
  //   title: "Scan"
  // }

  constructor(props) {
    super(props);
    // MyStack();
  }

  async componentDidMount() {
    const camera = await Permissions.askAsync(Permissions.CAMERA);
    const hasCameraPermission = (camera.status === 'granted');

    this.setState({ hasCameraPermission });
  };

  async snap() {
    if (this.camera) {
      let photo = await this.camera.takePictureAsync();
      setTimeout(() => {
        this.showImage();
      }, 300);
    }
  }

  showImage() {
    this.props.navigation.navigate("ImageView");
  }

  static navigationOptions = {
    tabBarIcon: TabIcon
  };

  render() {
    const { hasCameraPermission } = this.state;

    if (hasCameraPermission === null) {
      return <View />;
    } else if (hasCameraPermission === false) {
      return <Text>Access to camera has been denied.</Text>;
    }

    return (
      <View style={styles.layout}>
        <Camera
          style={styles.preview}
          ref={camera => this.camera = camera}
        />
        {/* <Button title="Press me" onPress={() => {
          this.snap();
        }} /> */}
        <TouchableOpacity
          style={{
            borderWidth: 4,
            borderColor: 'rgba(0,0,0,0.2)',
            alignItems: 'center',
            justifyContent: 'center',
            width: 60,
            height: 60,
            backgroundColor: '#fff',
            borderRadius: 30,
          }}
          onPress={() => {
            this.snap();
          }}
        >
          {/* <Icon name={"chevron-right"} size={30} color="#01a699" /> */}
        </TouchableOpacity>
      </View>
    );
  }
}

export class ImageView extends React.Component {



  static navigationOptions = {
    title: "ImageView"
  }

  constructor(props) {
    super(props);
  }

  render() {
    return (
      <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
        <Text>Details Screen</Text>
        <Button
          title="Go to Details... again"
          onPress={() => navigation.push('Details')}
        />
      </View >
    );
  }
}

const Stack = createStackNavigator();
function MyStack() {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen
          name="Scan"
          component={Scan}
          options={{ title: 'Works' }}
        />
        <Stack.Screen name="ImageView" component={ImageView} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

const { width: winWidth, height: winHeight } = Dimensions.get('window');

const styles = StyleSheet.create({
  preview: {
    height: winHeight,
    width: winWidth,
    position: 'absolute',
    left: 0,
    top: 0,
    right: 0,
    bottom: 0
  },
  layout: {
    flex: 1,
    justifyContent: 'flex-end',
    alignItems: 'center',
    marginBottom: 30
  }
});
// const styles = StyleSheet.create({
//   container: {
//     flex: 1,
//     alignItems: 'center',
//     justifyContent: 'center',
//   },
// });