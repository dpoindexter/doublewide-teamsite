using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Season;
using ServiceStack.OrmLite;

namespace Doublewide.Application.Repositories
{
    public class TournamentRepository : BaseRepository<Tournament, int>, ITournamentRepository
    {
        public TournamentRepository(IDbConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }
    }
}