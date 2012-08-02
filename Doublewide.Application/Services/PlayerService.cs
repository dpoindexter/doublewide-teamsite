using System.Collections.Generic;
using Doublewide.Application.Services.Contracts;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Entities.Team;

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
    }
}