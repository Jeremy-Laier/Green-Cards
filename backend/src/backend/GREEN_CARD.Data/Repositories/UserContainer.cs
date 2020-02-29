using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data.Repositories
{
    public class UserRepository{
        private DbSet<User> users;
        private GREEN_CARDContext dbContext;
        private readonly GREEN_CARDContext _db;
        
        public UserRepository(GREEN_CARDContext db)
        {
            _db = db;
        }
        public User getUser(int id){
            return users.Where( s =>  s.UserId == id).Single();
        }

        public void addUser(User user){
            users.Add(user);
        }
    }
}