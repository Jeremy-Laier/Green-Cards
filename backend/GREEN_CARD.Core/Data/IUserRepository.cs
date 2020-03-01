
using System.Collections.Generic;
using System.Threading.Tasks;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Core.Data
{
    public interface IUserRepository
    {
        Task<Player> Get(int id);
        Task<Player> GetRandom();

    }
}