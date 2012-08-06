using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Season;

namespace Doublewide.Application.Repositories
{
    public class TournamentRepository : BaseRepository<Tournament, int>, ITournamentRepository
    {
    }
}