using GraphQL.Types;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Api.Models
{
    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.ItemId);
            Field(x => x.ReceiptId, true);
            Field(x => x.ProductCategory);
            Field(x => x.CO2Impact);
            Field(x => x.Price);
            Field(x => x.QRCode);
        }
    }
}