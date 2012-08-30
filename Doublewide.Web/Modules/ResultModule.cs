using Doublewide.Application.Services.Contracts;
using Doublewide.Web.Models;
using Doublewide.Web.ViewModels;
using Nancy;
using System.Linq;

namespace Doublewide.Web.Modules
{
    public class ResultModule : NancyModule
    {
        private readonly ISeasonService _seasonService;

        public ResultModule(ISeasonService seasonService) : base("results")
        {
            //Injection
            _seasonService = seasonService;

            //Routes
            Get["/"] = parameters => Default(parameters);
        }

        private Response Default(dynamic parameters)
        {
            var tournaments = _seasonService
                .GetAllTournamentsForSeason()
                .Select(x => new TournamentModel().ToModel(x));

            var viewModel = new ResultsViewModel {Tournaments = tournaments};

            return View["default.cshtml", viewModel];
        }
    }
}