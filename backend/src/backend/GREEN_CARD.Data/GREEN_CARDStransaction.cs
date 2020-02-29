using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace abc
{
    public class TransactiontRepository{
        private DbSet<Transaction> transactions;
        private SMSDbContext dbContext;
        public TransactionRepository(){
            string connectionString = "";
            dbContext = SMSDbContextFactory.Create(connectionString);

            DbSet<Transaction> transactions = dbContext.Transaction;
        }
        public List<Transaction> Get(int UserId, Enum sortT ype, DateTime beginning, DateTime end){
            return transactions.Where(( s => s.UserId == Transaction.userId) &&
            (DateTime.Compare(Transaction.Date, beginning) >= 0) &&
            (DateTime.Compare(Transaction.Date, end) <= 0)).OrderBy(sortType).ToList();
        }
    }
}
