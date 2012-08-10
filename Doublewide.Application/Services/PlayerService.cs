using System.Collections.Generic;
using Doublewide.Application.Services.Contracts;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Team;

namespace Doublewide.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player GetPlayerById(int id)
        {
            return _playerRepository.Get(id);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll();
        }

        public Player GetPlayerByName(string nameFromRoute)
        {
            var names = nameFromRoute.Split('-');
            return GetPlayerByName(names[0], names[1]);
        }

        public Player GetPlayerByName(string firstName, string lastName)
        {
            return _playerRepository.GetPlayerByName(firstName, lastName);
        }
    }
}