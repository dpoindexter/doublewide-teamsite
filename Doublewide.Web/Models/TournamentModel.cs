using System.Collections.Generic;
using System.Linq;
using Doublewide.Domain.Season;
using Omu.ValueInjecter;

namespace Doublewide.Web.Models
{
    public class TournamentModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dates { get; set; }
        public string Location { get; set; }
        public IEnumerable<GameModel> Games { get; set; }

        public TournamentModel ToModel(Tournament tournament)
        {
            this.InjectFrom(tournament);
            Games = tournament.Games.Select(x => new GameModel().ToModel<Game, GameModel>(x));
            return this;
        }
    }
}