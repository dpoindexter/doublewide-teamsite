using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Doublewide.Web.Models;
using Doublewide.Application.Services.Contracts;

namespace Doublewide.Web.Modules
{
    public class PlayerModule : NancyModule
    {
        private readonly IPlayerService _playerService;

        public PlayerModule(IPlayerService playerService) : base("/players")
        {
            var model = _playerService.GetAllPlayers();

            Get["/"] = parameters => View["default.cshtml", model];
        }
    }
}