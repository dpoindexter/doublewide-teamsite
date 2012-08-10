using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Team;
using System.Linq;
using ServiceStack.OrmLite;

namespace Doublewide.Application.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        public override System.Collections.Generic.IEnumerable<Player> GetAll()
        {
            var result = base.GetAll();
            return result.OrderBy(x => x.JerseyNumber);
        }

        public Player GetPlayerByName(string firstName, string lastName)
        {
            var test = _db.QuerySingle<Player>(new { firstName, lastName });
            return test;
        }
    }
}