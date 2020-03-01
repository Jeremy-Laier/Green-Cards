using System.Collections.Generic;
using System.Threading.Tasks;
using GREEN_CARD.Core.Models;
using System;

namespace GREEN_CARD.Core.Data
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> Get(int userId, DateTime begin, DateTime end, int pageSize, int pageNumber);

    }
}