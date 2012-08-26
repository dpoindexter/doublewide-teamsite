using System.Collections.Generic;
using Doublewide.Web.Models;

namespace Doublewide.Web.ViewModels
{
    public class PlayerViewModel
    {
        public IEnumerable<PlayerListModel> Players { get; set; }
        public PlayerDetailsModel SelectedPlayer { get; set; }
    }
}