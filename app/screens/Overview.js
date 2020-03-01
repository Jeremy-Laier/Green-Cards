import React from 'react';
import { View, Image, Text } from 'react-native';
import { Header } from 'react-native-elements';
import styles from '../Styles'
import '../global'

export default class Overview extends React.Component {
  
  render() {
    console.log(global.image);
    return (
      <View style={{ flex: 1 }}>
        <Header
          centerComponent={{ text: 'Account Overview', style: { fontWeight: 'bold', fontSize: 16, color: '#fff' } }}
        />

        <View style={{ flex: 1, backgroundColor: 'white'}}>
          <View style={{ flex: 4, flexDirection: 'row', justifyContent: 'center', paddingTop: 40}}>
              <Image style = {{width: 380, height: 260}} source={require('../assets/2.png')} />
          </View>
          <View style={{ flex: 5, justifyContent: 'space-around', borderRadius: 40, paddingLeft: 60, paddingBottom: 40}}>
            <View><Text style={styles.smalltitle}>Total CO2 Impact:  </Text></View>
            <View><Text style={styles.smalltitle}>Total Spending: </Text><Text> hello </Text></View>
          </View>
        </View>
      </View>
    );
  }
}
