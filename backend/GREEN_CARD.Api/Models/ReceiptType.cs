using GraphQL.Types;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Api.Models
{
    public class ReceiptType : ObjectGraphType<Receipt>
    {
        public ReceiptType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.ReceiptId);
            Field(x => x.TransactionId, true);
            Field(x => x.ReceiptCode);
            Field(x => x.Rewards);
            Field(x => x.Company);
            Field(x => x.CO2Impact);
            Field<ListGraphType<ItemType>>(
                "items",
                resolve: x => contextServiceLocator.ItemRepository.Get(x.Source.TransactionId));
        }
    }
}