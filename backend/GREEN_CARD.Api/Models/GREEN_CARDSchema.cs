 
using GraphQL;
using GraphQL.Types;

namespace GREEN_CARD.Api.Models
{
    public class GREEN_CARDSchema : Schema
    {
        public GREEN_CARDSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<GREEN_CARDQuery>();
            // Mutation = resolver.Resolve<GREEN_CARDMutation>();
        }
    }
}


 