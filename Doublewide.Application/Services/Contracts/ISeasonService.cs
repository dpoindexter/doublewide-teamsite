using System.Collections.Generic;
using Doublewide.Domain.Season;

namespace Doublewide.Application.Services.Contracts
{
    public interface ISeasonService
    {
        Tournament GetTournamentById(int id);
        IEnumerable<Tournament> GetAllTournamentsForSeason();
        void SaveTournament(Tournament tournament);
    }
}
