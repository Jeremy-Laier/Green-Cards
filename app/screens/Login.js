import React, { Component } from "react";
import { View, Text, ScrollView, StyleSheet } from "react-native";
import colors from "../styles/color";
export default class Login extends Component {
  render() {
    return (
      <View style={styles.wrapper}>
        <ScrollView>
          <Text>Login</Text>
        </ScrollView>
      </View>
    );
  }
}
const styles = StyleSheet.create({
  wrapper: {
    display: "flex",
    flex: 1,
    backgroundColor: colors.green01
  }
});