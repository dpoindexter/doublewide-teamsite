namespace Doublewide.Web.Models
{
    public class GameModel : BaseModel
    {
        public string Opponent { get; set; }
        public int DoublewideScore { get; set; }
        public int OpponentScore { get; set; }
    }
}