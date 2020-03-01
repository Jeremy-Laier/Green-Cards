
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private List<Item> myItems;

        public ItemRepository(GREEN_CARDContext db)
        {
            myItems =  new List<Item>();
            Item i1 = new Item();
            Item i2 = new Item();
            Item i3 = new Item();
            i1.Price = 20.00;
            i2.Price = 1.2;
            i3.Price = 3.3;
            i1.ReceiptId = 0;
            i2.ReceiptId = 0;
            i3.ReceiptId = 1;
            i1.ProductCategory = "organicFood";
            i2.ProductCategory = "corn";
            i3.ProductCategory = "fertillize";
            i1.CO2Impact = 12.1;
            i2.CO2Impact = 1.1;
            i2.CO2Impact = 30.1;
            myItems.Add(i1);
            myItems.Add(i2);
        }

        public async Task<List<Item>> Get(int receiptId)
        {
            return myItems;
        }
    }
}