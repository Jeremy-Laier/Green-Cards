
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly GREEN_CARDContext _db;

        public ReceiptRepository(GREEN_CARDContext db)
        {
            _db = db;
        }
        // Gets the ReceiptId by the TransactionId. 
        public Task<Receipt> Get(int TranId)
        {
            return _db.Receipts.FirstOrDefaultAsync(r => r.TransactionId == TranId);
        }

    }
}