 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private User user;

        public UserRepository(GREEN_CARDContext db)
        {
            user = new User();
            user.Email = "efa29@uic.edu";
            user.AccountNumber = 32323;
            user.AccountLimit = 350000.00;
            user.LastName = "Osha";
            user.FirstName = "Daniel";
            user.PhoneNumber = "3234568915";
              
        }

        public async  Task<User> Get(int userId)
        {
            return user;
        }

        public async Task<User> GetRandom()
        {
            return user;
        }
    }
}