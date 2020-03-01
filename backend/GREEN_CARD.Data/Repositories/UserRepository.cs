
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
        private readonly GREEN_CARDContext _db;

        public UserRepository(GREEN_CARDContext db)
        {
            _db = db;
        }
        public async Task<User> Get(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public Task<User> GetRandom()
        {
            return _db.Users.FirstOrDefaultAsync();
        }

    }
}