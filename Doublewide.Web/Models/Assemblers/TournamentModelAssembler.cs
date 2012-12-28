using System.Linq;
using Doublewide.Domain.Season;
using Omu.ValueInjecter;

namespace Doublewide.Web.Models.Assemblers
{
    public static class TournamentModelAssembler
    {
        public static TournamentModel ToModel(this Tournament tournament)
        {
            var model = new TournamentModel();
            model.InjectFrom(tournament);
            model.Games = tournament.Games.Select(x => new GameModel().ToModel<Game, GameModel>(x));
            return model;
        }
    }
}