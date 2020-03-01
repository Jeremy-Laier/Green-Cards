 
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
        private User user1;

        public UserRepository(GREEN_CARDContext db)
        {
            user = new User();
            user1 = new User();
            user.Email = "efa29@uic.edu";
            user1.Email = "dfkjd@iit.edu";
            user.AccountNumber = 32323;
            user1.AccountNumber = 32435;
            user.AccountLimit = 350000.00;
            user1.AccountLimit = 67000.0;
            user.LastName = "Osha";
            user1.LastName = "Laier";
            user.FirstName = "Daniel";
            user1.FirstName = "Shuke";
            user.PhoneNumber = "3234568915";
            user1.PhoneNumber = "2315678902";
              
        }

        public async  Task<User> Get(int userId)
        {
            if(userId == 0)
                return user;
            else
                return user1;
        }

        public async Task<User> GetRandom()
        {
            return user;
        }
    }
}