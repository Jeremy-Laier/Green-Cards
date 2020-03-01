 
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
        private Receipt receipt0;
        private Receipt receipt1;

        public ReceiptRepository(GREEN_CARDContext db)
        {
            receipt0 = new Receipt();
            receipt1 = new Receipt();
            receipt0.ReceiptId = 0;
            receipt1.ReceiptId = 1;
            receipt0.TransactionId = 1;
            receipt1.TransactionId = 3;
            receipt0.ReceiptCode = "dfhiu32";
            receipt1.ReceiptCode = "f32hta2";
            receipt0.Rewards = 123.00;
            receipt1.Rewards = 300.00;
            receipt0.CO2Impact = 12.0;
            receipt1.CO2Impact = 32.0;
        }

        public async Task<Receipt> Get(int transactionId)
        {
            if (transactionId == 0)
                return receipt0;
            return receipt1;
        }
    }
}