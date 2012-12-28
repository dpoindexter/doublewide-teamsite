using System.Collections.Generic;

namespace Doublewide.Web.Models
{
    public class TournamentModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dates { get; set; }
        public string Location { get; set; }
        public IEnumerable<GameModel> Games { get; set; }
    }
}