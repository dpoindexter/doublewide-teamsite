using System.Collections.Generic;

namespace Doublewide.Web.Models
{
    public class AdminViewModel
    {
        public IEnumerable<BlogPostModel> Posts { get; set; } 
        public IEnumerable<TournamentModel> Tournaments { get; set; }
    }
}