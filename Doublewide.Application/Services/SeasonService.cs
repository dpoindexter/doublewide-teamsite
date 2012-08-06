using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Application.Services.Contracts;
using Doublewide.Domain.Season;

namespace Doublewide.Application.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ITournamentRepository _tournamentRepository;

        public SeasonService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public Tournament GetTournamentById(int id)
        {
            return _tournamentRepository.Get(id);
        }

        public IEnumerable<Tournament> GetAllTournamentsForSeason()
        {
            return _tournamentRepository.GetAll();
        }

        public void SaveTournament(Tournament tournament)
        {
            throw new System.NotImplementedException();
        }
    }
}