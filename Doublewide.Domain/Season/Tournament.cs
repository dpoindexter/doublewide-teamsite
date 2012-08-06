using System.Collections.Generic;
using Doublewide.Domain.Entities;

namespace Doublewide.Domain.Season
{
    public class Tournament : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}