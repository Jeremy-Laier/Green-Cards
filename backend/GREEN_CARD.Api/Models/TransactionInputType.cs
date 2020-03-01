using GraphQL.Types;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;
using System;

namespace GREEN_CARD.Api.Models
{
    public class TransactionInputType : InputObjectGraphType<TransactionInput>
    {
        public TransactionInputType()
        {
            Name = "TransactionInput";
            Field<NonNullGraphType<IdGraphType>>("userId");
            Field<DateGraphType>("startDate");
            Field<DateGraphType>("endDate");
            Field<IntGraphType>("pageSize");
            Field<IntGraphType>("pageNumber");
        }
    }
    public class TransactionInput{
        public int userId{get;set;}
        public DateTime startDate{get;set;}
        public DateTime endDate {get;set;}
        public int pageSize{get;set;}
        public int pageNumber{get;set;}
    }
}