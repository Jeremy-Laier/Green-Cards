import React from 'react';
import { View, StyleSheet, Text } from 'react-native';
import { Header } from 'react-native-elements'

export default class History extends React.Component {

  render() {
    return (
      <View>
        <Header
          centerComponent={{ text: 'Transection for Past 30 Days', style: { fontWeight: 'bold', fontSize: 16, color: '#fff' } }}
        />
      </View>
    );
  }
}
