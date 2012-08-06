using System.Collections.Generic;

namespace Doublewide.Web.Models
{
    public class SeasonEditingModel
    {
        public IEnumerable<TournamentModel> Tournaments { get; set; }
    }
}