
using System.Threading.Tasks;
using System.Collections.Generic;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Core.Data
{
    public interface ISkaterStatisticRepository
    {
        Task<List<SkaterStatistic>> Get(int playerId);
    }
}
