using System;
using System.Collections.Generic;

namespace Doublewide.Web.Models
{
    public class TournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; }
        public IEnumerable<GameModel> Games { get; set; }
    }
}