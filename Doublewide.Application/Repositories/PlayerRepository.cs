using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Team;
using System.Linq;
using ServiceStack.OrmLite;

namespace Doublewide.Application.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        public PlayerRepository(IDbConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public override System.Collections.Generic.IEnumerable<Player> GetAll()
        {
            var result = base.GetAll();
            return result.OrderBy(x => x.JerseyNumber);
        }

        public Player GetPlayerByName(string firstName, string lastName)
        {
            Player result;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                result = db.QuerySingle<Player>(new { firstName, lastName });
            }
            return result;
        }
    }
}