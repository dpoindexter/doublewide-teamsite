using Doublewide.Domain.Entities;

namespace Doublewide.Domain.Season
{
    public class Game : Entity
    {
        public string Opponent { get; set; }
        public int DoublewideScore { get; set; }
        public int OpponentScore { get; set; }
    }
}