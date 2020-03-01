using System.Collections.Generic;
using System.Threading.Tasks;
using GREEN_CARD.Core.Models;
using System;

namespace GREEN_CARD.Core.Data
{
    public interface IItemRepository
    {
        Task<Item> Get(int ReceiptId);
    }
}