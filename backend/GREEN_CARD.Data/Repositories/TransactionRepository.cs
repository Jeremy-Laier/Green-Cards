
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly GREEN_CARDContext _db;

        public TransactionRepository(GREEN_CARDContext db)
        {
            _db = db;
        }

        public async Task<List<Transaction>> Get(int id, DateTime inDate, DateTime outDate, int pageS, int pageN)
        {

            return await _db.Transactions.Where(t => t.UserId == id)
                                        .Where(t => t.Date >= inDate)
                                        .Where(t => t.Date <= outDate).Skip(pageN).Take(pageS).ToListAsync();
        }
    }
}
