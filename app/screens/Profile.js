import React from 'react';
import { View, Image, StyleSheet, Text, Button } from 'react-native';
import styles from '../Styles'
import { ApolloClient, HttpLink, InMemoryCache } from 'apollo-boost';
import { ApolloProvider, graphql, Mutation } from 'react-apollo';
import gql from 'graphql-tag';
import '../global'

const client = new ApolloClient({
  link: new HttpLink({
    uri: 'http://172.16.60.59:5000/graphql',
  }),
  cache: new InMemoryCache()
});

const userQuery = gql`
  query{
    user (userId:${global.userId}){
      email
      userId
      lastName
      firstName
      accountLimit
    }
  }
`;

const UserInfo = graphql(userQuery)(props => {
  const { error, user } = props.data;
  if (error) {
    return <Text>{error}</Text>;
  }
  if (user) {
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <View style={{ flex: 1, alignItems: 'center', flexDirection: 'column' }}>
          <View style={{ paddingTop: 60, flex: 1, alignItems: 'center' }}>
            <Image style={{ width: 200, height: 200 }} source={require('../assets/greenlogo.png')}></Image>
          </View>
          <View style={{ flex: 2, flexDirection: 'column', width: 300, justifyContent: 'space-around' }}>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>First Name: </Text>
              <Text style={styles.indentedAnswer}>{user.firstName}</Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>Last Name:  </Text>
              <Text style={styles.indentedAnswer}>{user.lastName}</Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>Email: </Text>
              <Text style={styles.indentedAnswer}>{user.email}</Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.smalltitle}>Account Limit:  </Text>
              <Text style={styles.indentedAnswer}>{user.accountLimit}</Text>
            </View>
          </View>
        </View>
      </View>
    );
  }

  return <Text>  </Text>;
});

function Profile() {
  return (
    <ApolloProvider client={client}>
      <UserInfo />
    </ApolloProvider>
  );
}

export default Profile; 