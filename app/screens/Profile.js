import React from 'react';
import { View, Image, StyleSheet, Text, Button } from 'react-native';
import styles from '../Styles'
import { ApolloClient, HttpLink, InMemoryCache } from 'apollo-boost';
import { ApolloProvider, graphql, Mutation } from 'react-apollo';
import gql from 'graphql-tag';

const client = new ApolloClient({
  link: new HttpLink({
    uri: 'http://localhost:8080',
  }),
  cache: new InMemoryCache()
});

const userQuery = gql`
  query {
    dogs {
      name
      type
    }
  }
`;

const UserInfo = graphql(userQuery)(props => {
  const { error, users } = props.data;
  if (error) {
    return <Text>{error}</Text>;
  }
  if (users) {
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <View style={{ flex: 1, alignItems: 'center', flexDirection: 'column' }}>
          <View style={{ paddingTop: 60, flex: 1, alignItems: 'center' }}>
            <Image style={{ width: 200, height: 200 }} source={require('../assets/person.jpg')}></Image>
          </View>
          <View style={{ flex: 2, flexDirection: 'column', width: 300, justifyContent: 'space-around' }}>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>First Name: </Text>
              <Text style={styles.indentedAnswer}> hi hi </Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>Last Name:  </Text>
              <Text style={styles.indentedAnswer}> hi hi </Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>Email: </Text>
              <Text style={styles.indentedAnswer}> hi hi </Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>Last Name:  </Text>
              <Text style={styles.indentedAnswer}> hi hi </Text>
            </View>
          </View>
        </View>
      </View>
    );
  }

  return <Text>Loading...</Text>;
});

function Profile() {
  return (
    <ApolloProvider client={client}>
      <UserInfo />
    </ApolloProvider>
  );
}

export default Profile; 