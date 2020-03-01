using GraphQL.Types;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Api.Models
{
    public class TransactionType : ObjectGraphType<Transaction>
    {
        public TransactionType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.TransactionId);
            Field(x => x.Date);
            Field(x => x.Location);
            Field(x => x.Amount);
            Field(x => x.HaveReceipt);
            Field<ReceiptType>( 
                "receipt", 
                resolve: x => contextServiceLocator.ReceiptRepository.Get(x.Source.TransactionId));
        }
    }
}