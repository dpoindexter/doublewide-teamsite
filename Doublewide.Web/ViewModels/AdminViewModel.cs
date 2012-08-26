using System.Collections.Generic;
using Doublewide.Web.Models;

namespace Doublewide.Web.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<BlogPostModel> Posts { get; set; } 
        public IEnumerable<TournamentModel> Tournaments { get; set; }
    }
}