 # Green Card, Come get your Green Card!
 
 
 ## What?
 
 
<a> This is how we reimagine banking. A bank for people who care about their bottom line as well as their envirmoent and society. Green Card is a new way to save the environment! </a>

<a> For every environmentally friendly purchase you make, you get cash back! Use it just like your normal credit card or scan your reciepts using our deep learning techonolgy for even more, specialized cash back rewards! </a>

## What we used:

> Reactive Native, GraphQL, Postgrsql, .net, Python

## Backend

Our backend is compose mainly of graphQL for anything that is Json based, and a standar Restfull API enpoints for non-Json data.
The features that the backend supports are the avility tho query past transactions, user data, process receipts, and look at their envirmental footprint that their credit data implies. Our main features allow the user to submit a receipt to their rewards card. On the back end we process the image and decide which puchoces count for rewards.

## GraphQL API and PostgrSQL

On our back end we are running a live database with the information of the costumers. The database is set up with PostgrSQL on a GoogleCloud Machine. The schema of the database was writen in C#. This database is connected with the overall API with an Entity Framework Library. 

Using the Dotnet GraphQL our server is able to communicate with our clients with this innovative tool. To get this server working we have had to generate a schema for the data that the front end cosumes.
