import React from 'react';
import { View, StyleSheet, Dimensions, Text, TouchableOpacity, Image, Picker } from 'react-native';
import * as Permissions from 'expo-permissions';
import { Camera } from 'expo-camera';
import { createStackNavigator } from '@react-navigation/stack';


import { Ionicons } from '@expo/vector-icons';

const TabIcon = (props) => (
  <Ionicons
    name={'md-apps'}
    size={35}
    color={props.focused ? 'grey' : 'darkgrey'}
  />
)

const Stack = createStackNavigator();
export default function CameraScan() {
  return (
    <Stack.Navigator initialRouteName="Scan" screenOptions={{ headerShown: false }} >
      <Stack.Screen name="Scan" component={Scan} />
      <Stack.Screen name="ImageView" component={ImageView} />
    </ Stack.Navigator>
  );
}


export class Scan extends React.Component {
  camera = null;

  state = {
    hasCameraPermission: null,
  };

  static navigationOptions = {
    title: "Scan",
    headerStyle: {
      height: 50,
      backgroundColor: '#f4511e',
    }
  }

  constructor(props) {
    super(props);
  }

  async componentDidMount() {
    const camera = await Permissions.askAsync(Permissions.CAMERA);
    const hasCameraPermission = (camera.status === 'granted');

    this.setState({ hasCameraPermission });
  };

  async snap() {
    if (this.camera) {
      let photo = await this.camera.takePictureAsync();
      await setTimeout(() => {
        this.showImage(photo);
      }, 300);
    }
  }

  showImage(img) {
    this.props.navigation.push("ImageView", { img: img });
  }

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

        </TouchableOpacity>
      </View>
    );
  }
}


export class ImageView extends React.Component {

  img = null;

  state = {
    language: ''
  }

  static navigationOptions = {
    title: "Scan",
    headerStyle: {
      height: 50,
      backgroundColor: '#f4511e',
    }
  }

  constructor(props) {
    super(props);

  }

  createFormData = (photo) => {
    const data = new FormData();
    console.log(photo.uri);
    data.append("files", {
      type: 'image/jpeg',
      name: 'temp',
      uri: photo.uri
    });

    return data;
  };

  handleUploadPhoto = () => {
    fetch("http://172.16.60.59:5000/api/receipt", {
      method: "POST",
      body: this.createFormData(this.img)
    })
      .then(response => response.json())
      .then(response => {
        console.log("upload success", response);
        alert("Upload success!");
        this.setState({ photo: null });
      })
      .catch(error => {
        console.log("upload error", error);
        alert("Upload failed!");
      });
  };

  render() {
    this.img = this.props.route.params.img;
    return (
      <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
        <Image
          style={{ width: '80%', height: '80%' }}
          source={{ uri: this.img.uri }}
        />
        <View style={{
          marginTop: 10,
          width: winWidth,
          backgroundColor: 'red',
          height: 300,
          alignItems: 'center',
        }}>
          <Text style={{ fontSize: 25 }}>Select Date: </Text>
          <Picker
            selectedValue={this.state.language}
            style={{ top: -50, height: 20, width: '100%' }}
            onValueChange={(itemValue, itemIndex) =>
              this.setState({ language: itemValue })
            }>
            <Picker.Item label="Java" value="java" />
            <Picker.Item label="JavaScript" value="js" />
          </Picker>
          <TouchableOpacity style={{
            backgroundColor: '#DDDDDD',
            padding: 10,
            top: 110
          }} onPress={() => { this.handleUploadPhoto(); }}>
            <Text>Send</Text>
          </TouchableOpacity>
        </View>
      </View >
    );
  }
}
// function MyStack() {
//   return (
//     <NavigationContainer>
//       <Stack.Navigator>
//         <Stack.Screen
//           name="Scan"
//           component={Scan}
//           options={{ title: 'Works' }}
//         />
//         <Stack.Screen name="ImageView" component={ImageView} />
//       </Stack.Navigator>
//     </NavigationContainer>
//   );
// }

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