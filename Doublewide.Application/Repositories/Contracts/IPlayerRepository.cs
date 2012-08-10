using Doublewide.Domain.Team;

namespace Doublewide.Application.Repositories.Contracts
{
    public interface IPlayerRepository : IRepository<Player, int>
    {
        Player GetPlayerByName(string firstName, string lastName);
    }
}
