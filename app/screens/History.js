import React from 'react';
import { View, StyleSheet, Text, ScrollView } from 'react-native';
import { Header } from 'react-native-elements';
import styles from '../Styles'
import { ApolloClient, HttpLink, InMemoryCache } from 'apollo-boost';
import { ApolloProvider, graphql, Mutation } from 'react-apollo';
import gql from 'graphql-tag';
import '../global';


const client = new ApolloClient({
  link: new HttpLink({
    uri: global.baseUri + '/graphql',
  }),
  cache: new InMemoryCache()
});

const transactionQuery = gql`
  query{
    transactions (filter: {
      userId: ${global.userId}
    }) {
      amount
      date
      haveReceipt
      location
      receipt {
        items {
          price
          productCategory
        }
      }
      transactionId
    }
  }
`;

const TransactionsInfo = graphql(transactionQuery)(props => {
  const { error, transactions } = props.data;
  if (error) {
    return <Text>{error}</Text>;
  }
  if (transactions) {
    let items = (itemsArray) => {
      let list = itemsArray.map((s, i) => {
        return (
          <View key={i}>
            <Text>    Item: {s.productCategory}</Text>
            <Text>    Price: ${s.price}</Text>
          </View>
        )
      });
      return list;
    }
    let transactionItems = transactions.map((s, i) => {
      return (
        <View key={i} style={{ backgroundColor: '#cccccc', marginVertical: 10, padding: 30 }}>
          <Text style={{ fontSize: 30 }}>Transaction {s.transactionId}:</Text>
          <Text style={{ fontSize: 18 }} > Cost: ${s.amount}</Text>
          <Text style={{ fontSize: 18 }} > Date: {s.date}</ Text>
          <Text style={{ fontSize: 18 }} > Location: {s.location}</Text>
          <Text style={{ fontSize: 18 }} > Have Receipt: {(s.haveReceipt) ? 'true' : 'false'}</ Text>
          {items(s.receipt.items)}
        </View>
      )
    });
    return (
      <View>
        {transactionItems}
      </View>
    );
  }

  return <Text>  </Text>;
});

export default class History extends React.Component {

  render() {
    return (
      <View>
        <Header
          centerComponent={{ text: 'Transection for Past 30 Days', style: { fontWeight: 'bold', fontSize: 16, color: '#fff' } }}
        />
        <ScrollView style={{ marginBottom: 80 }} contentContainerStyle={{ alignItems: 'center' }}>
          <ApolloProvider client={client}>
            <TransactionsInfo />
          </ApolloProvider>
        </ScrollView>
      </View>
    );
  }
}
