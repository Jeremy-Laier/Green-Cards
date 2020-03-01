
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data.Repositories
{
    public class SkaterStatisticRepository : ISkaterStatisticRepository
    {
        private readonly GREEN_CARDContext _db;

        public SkaterStatisticRepository(GREEN_CARDContext db)
        {
            _db = db;
        }

        public async Task<List<SkaterStatistic>> Get(int playerId)
        {
            return await _db.SkaterStatistics.Include(ss=>ss.Season).Include(ss=>ss.League).Include(ss=>ss.Team).Where(ss => ss.PlayerId == playerId).ToListAsync();
        }
    }
}
