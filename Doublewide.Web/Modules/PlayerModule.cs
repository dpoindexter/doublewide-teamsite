using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                var model = _playerService.GetAllPlayers().Select(x =>
                {
                    var m = new PlayerModel();
                    m.InjectFrom(x);
                    return m;
                });

                return View["default.cshtml", model];
            };
        }
    }
}