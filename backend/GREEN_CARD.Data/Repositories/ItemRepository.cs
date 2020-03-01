using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GREEN_CARD.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly GREEN_CARDContext _db;

        public ItemRepository(GREEN_CARDContext db)
        {
            _db = db;
        }
        // Gets the ReceiptID by the ReceiptId. 
        public async Task<List<Item>> Get(int RId)
        {
            return await _db.Items.Where(r => r.ReceiptId == RId).ToListAsync();
        }
    }
}