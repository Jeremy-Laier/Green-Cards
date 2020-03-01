 
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
        private List<Transaction> transactions;

        public TransactionRepository(GREEN_CARDContext db)
        {
            transactions =  new List<Transaction>();
            Transaction t0 = new Transaction();
            Transaction t1 = new Transaction(); 
            Transaction t2 = new Transaction();
            Transaction t3 = new Transaction();
            t0.TransactionId = 0;
            t1.TransactionId = 1;
            t2.TransactionId = 2;
            t3.TransactionId = 3;
            t0.UserId = 0;
            t1.UserId = 0;
            t2.UserId = 0;
            t3.UserId = 0;
            t0.Date = new DateTime();
            t1.Date = new DateTime();
            t2.Date = new DateTime();
            t3.Date = new DateTime();
            t0.Location = "Chicago";
            t1.Location = "Chicago";
            t2.Location = "Chicago";
            t3.Location = "Chicago";
            t0.HaveReceipt = false;
            t1.HaveReceipt = true;
            t2.HaveReceipt = false;
            t3.HaveReceipt = true;
            t0.Amount = 20.00;
            t1.Amount = 100.0;
            t2.Amount = 200.00;
            t3.Amount = 3000.0;
            transactions.Add(t0);
            transactions.Add(t1);
            transactions.Add(t2);
            transactions.Add(t3);
        }

        public async Task<List<Transaction>> Get(int userId, DateTime begin, DateTime end, int pageSize, int pageNumber)
        {
            return transactions;
        }
    }
}