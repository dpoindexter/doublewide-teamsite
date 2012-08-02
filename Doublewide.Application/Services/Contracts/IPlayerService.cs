using System.Collections.Generic;
using Doublewide.Domain.Entities.Team;

namespace Doublewide.Application.Services.Contracts
{
    public interface IPlayerService
    {
        Player GetPlayerById(int Id);
        IEnumerable<Player> GetAllPlayers();
    }
}
