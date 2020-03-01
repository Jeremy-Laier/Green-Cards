
using GraphQL.Types;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Core.Data;


namespace GREEN_CARD.Api.Models
{
    public class GREEN_CARDQuery : ObjectGraphType
    {
        public GREEN_CARDQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => contextServiceLocator.PlayerRepository.Get(context.GetArgument<int>("id")));

            Field<PlayerType>(
                "randomPlayer",
                resolve: context => contextServiceLocator.PlayerRepository.GetRandom());

            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => contextServiceLocator.PlayerRepository.All());

            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "userId" }),
                resolve: context => contextServiceLocator.UserRepository.Get(context.GetArgument<int>("userId")));


            Field<ListGraphType<TransactionType>>(
                "transactions",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TransactionInputType>> { Name = "filter" }),
                resolve: context =>
                {
                    var input = context.GetArgument<TransactionInput>("filter");
                    return contextServiceLocator.TransactionRepository.Get(input.userId, input.startDate, input.endDate, input.pageSize, input.pageNumber);
                });

            Field<ItemType>(
                "item",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "itemId" }),
                resolve: context => contextServiceLocator.ItemRepository.Get(context.GetArgument<int>("itemId")));
        }
    }
}


