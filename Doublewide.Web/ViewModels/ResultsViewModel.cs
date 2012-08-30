using System.Collections.Generic;
using Doublewide.Web.Models;

namespace Doublewide.Web.ViewModels
{
    public class ResultsViewModel
    {
        public IEnumerable<TournamentModel> Tournaments { get; set; }
    }
}