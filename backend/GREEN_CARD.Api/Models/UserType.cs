using GraphQL.Types;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Api.Models
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.UserId);
            Field(x => x.Email, true);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.RewardsTotal);
            Field(x => x.AccountLimit);
            Field(x => x.AccountNumber);
        }
    }
}