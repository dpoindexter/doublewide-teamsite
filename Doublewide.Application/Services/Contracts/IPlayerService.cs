using System.Collections.Generic;
using Doublewide.Domain.Team;

namespace Doublewide.Application.Services.Contracts
{
    public interface IPlayerService
    {
        Player GetPlayerById(int id);
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerByName(string nameFromRoute);
        Player GetPlayerByName(string firstName, string lastName);
    }
}
