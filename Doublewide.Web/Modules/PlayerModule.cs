using System.Collections.Generic;
using System.Linq;
using Doublewide.Domain.Team;
using Doublewide.Web.ViewModels;
using Nancy;
using Doublewide.Web.Models;
using Doublewide.Application.Services.Contracts;
using Omu.ValueInjecter;
using Doublewide.Web.Extensions;

namespace Doublewide.Web.Modules
{
    public class PlayerModule : NancyModule
    {
        private readonly IPlayerService _playerService;

        public PlayerModule(IPlayerService playerService) 
            : base("/players")
        {
            //Injection
            _playerService = playerService;

            //Routes
            Get["/"] = parameters => Default(parameters);

            Get[@"/(?<name>[A-Za-z]+\-[A-Za-z]+)"] = parameters => Player(parameters);
        }

        //Responses
        private Response Default(dynamic parameter)
        {
            var players = _playerService.GetAllPlayers().ToList();

            var selectedPlayer = new PlayerDetailsModel();
            selectedPlayer.InjectFrom(players.FirstOrDefault());

            var viewModel = new PlayerViewModel
                                {
                                    Players = GetPlayerList(players), 
                                    SelectedPlayer = selectedPlayer
                                };

            return View["default.cshtml", viewModel];            
        }

        private Response Player(dynamic parameters)
        {
            var nameParam = (string)parameters.name.Value;
            var selectedPlayer = _playerService.GetPlayerByName(nameParam);

            var selectedPlayerModel = new PlayerDetailsModel();
            selectedPlayerModel.InjectFrom(selectedPlayer);

            var viewModel = new PlayerViewModel
                                {
                                    Players = GetPlayerList(), 
                                    SelectedPlayer = selectedPlayerModel
                                };

            return View["default.cshtml", viewModel];
        }

        //Helpers
        private IEnumerable<PlayerListModel> GetPlayerList(IEnumerable<Player> players = null)
        {
            return (players ?? _playerService.GetAllPlayers())
                .MapToInjectedModel<Player, PlayerListModel>()
                .ToList();
        }
    }
}