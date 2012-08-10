using System.Collections.Generic;
using System.Linq;
using Doublewide.Domain.Team;
using Nancy;
using Doublewide.Web.Models;
using Doublewide.Application.Services.Contracts;
using Omu.ValueInjecter;

namespace Doublewide.Web.Modules
{
    public class PlayerModule : NancyModule
    {
        private readonly IPlayerService _playerService;

        public PlayerModule(IPlayerService playerService) : base("/players")
        {
            _playerService = playerService;

            Get["/"] = parameters =>
            {
                var players = _playerService.GetAllPlayers();

                var playerModels = players.Select(p =>
                                                      {
                                                          var m = new PlayerListModel();
                                                          m.InjectFrom(p);
                                                          return m;
                                                      });

                var selectedPlayer = new PlayerDetailsModel();
                selectedPlayer.InjectFrom(players.FirstOrDefault());

                var viewModel = new PlayerViewModel {Players = playerModels, SelectedPlayer = selectedPlayer};

                return View["default.cshtml", viewModel];
            };

            Get[@"/(?<name>[A-Za-z]+\-[A-Za-z]+)"] = parameters =>
            {
                var nameParam = (string)parameters.name.Value;
                var selectedPlayer = _playerService.GetPlayerByName(nameParam);

                var players = _playerService.GetAllPlayers();

                var playerModels = players.Select(p =>
                {
                    var m = new PlayerListModel();
                    m.InjectFrom(p);
                    return m;
                });

                var selectedPlayerModel = new PlayerDetailsModel();
                selectedPlayerModel.InjectFrom(selectedPlayer);

                var viewModel = new PlayerViewModel { Players = playerModels, SelectedPlayer = selectedPlayerModel };              

                return View["default.cshtml", viewModel];
            };
        }
    }
}