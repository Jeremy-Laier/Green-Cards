
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data.InMemory
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players = new List<Player> {
            new Player() { Id = 1, Name = "Connor McDavid" }
        };

        public Task<Player> Get(int id)
        {
            return Task.FromResult(_players.FirstOrDefault(p => p.Id == id));
        }

        public Task<Player> GetRandom()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Player>> All()
        {
            throw new System.NotImplementedException();
        }

        public Task<Player> Add(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
