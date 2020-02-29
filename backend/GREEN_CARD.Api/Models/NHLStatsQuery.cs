
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
        }
    }
}


 