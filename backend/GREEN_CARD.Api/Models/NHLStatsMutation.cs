 

using GraphQL.Types;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Api.Models
{
    public class GREEN_CARDMutation : ObjectGraphType
    {
        public GREEN_CARDMutation(ContextServiceLocator contextServiceLocator)
        {
            Name = "CreatePlayerMutation";

            Field<PlayerType>(
                "createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> { Name = "player" }
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Player>("player");
                    return contextServiceLocator.PlayerRepository.Add(player);
                });
        }
    }
}
