using System.Collections.Generic;

namespace Doublewide.Web.Models
{
    public class PlayerViewModel
    {
        public IEnumerable<PlayerListModel> Players { get; set; }
        public PlayerDetailsModel SelectedPlayer { get; set; }
    }
}