import React from 'react';
import { View, StyleSheet, Text } from 'react-native';
import {Header} from 'react-native-elements';

export default class Overview extends React.Component {
  render() {
    return (
      <View>
        <Header
          centerComponent={{ text: 'Account Overview', style: { fontWeight: 'bold', fontSize: 16, color: '#fff' } }}
        />
      </View>
    );
  }
}
