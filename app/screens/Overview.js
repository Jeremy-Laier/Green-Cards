import React from 'react';
import { View, Image, Text } from 'react-native';
import { Header } from 'react-native-elements';
import styles from '../Styles'
import '../global'
import { ApolloClient, HttpLink, InMemoryCache } from 'apollo-boost';
import { ApolloProvider, graphql, Mutation } from 'react-apollo';
import gql from 'graphql-tag';
import '../global'

const client = new ApolloClient({
  link: new HttpLink({
    uri: global.baseUri + '/graphql',
  }),
  cache: new InMemoryCache()
});

const transactionQuery = gql`
query{
  transactions (filter: {
    userId: 0
  }) {
    receipt {
      items{
        cO2Impact
        price
    }
  }
}
}
`;


const OverviewInfo = graphql(transactionQuery)(props => {
  const { error, transactions } = props.data;
  if (error) {
    return <Text>{error}</Text>;
  }
  if (transactions) {
    var totalco2 = 0;
    var totalSpending = 0;
    // console.log(transactions);
    transactions.forEach((transaction) => {

      transaction.receipt.items.forEach((item) => {
        totalco2 += item.cO2Impact;
        totalSpending += item.price;
      });
    });
    return (
      <View style={{ flex: 1, backgroundColor: 'white' }}>
        <View style={{ flex: 4, flexDirection: 'row', justifyContent: 'center', paddingTop: 40 }}>
          <Image style={{ width: 380, height: 260 }} source={require('../assets/2.png')} />
        </View>
        <View style={{ flex: 5, justifyContent: 'space-around', borderRadius: 40, paddingLeft: 60, paddingBottom: 40 }}>
          <View>
            <Text style={styles.smalltitle}>Total CO2 Impact: </Text>
            <Text style={{ color: 'green', fontSize: 70, paddingTop: 20, paddingLeft: 40 }}>{parseInt(totalco2)}</Text>
          </View>
          <View>
            <Text style={styles.smalltitle}>Total Spending: </Text>
            <Text style={{ fontSize: 70, color: 'red', paddingTop: 20, paddingLeft: 40 }}>{parseInt(totalSpending)}</Text>
          </View>
        </View>
      </View>
    );
  }

  return <Text>  </Text>;
});

export default class Overview extends React.Component {

  render() {
    return (
      <ApolloProvider client={client}>
        <View style={{ flex: 1 }}>
          <Header
            centerComponent={{ text: 'Account Overview', style: { fontWeight: 'bold', fontSize: 16, color: '#fff' } }}
          />
          <OverviewInfo />
        </View>
      </ApolloProvider>
    )
  };
}
