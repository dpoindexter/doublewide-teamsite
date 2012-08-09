using Nancy;

namespace Doublewide.Web.Modules.Api
{
    public class TournamentApiModule : NancyModule
    {
        public TournamentApiModule() : base("/api/tournaments")
        {
            Get["/"] = parameters => "GET tournaments";

            Get["/{id}"] = parameters => "GET player by id";

            Put["/"] = parameters => "PUT player";

            Post["/{id}"] = parameters => "POST player by id";

            Delete["/{id}"] = parameters => "DELETE player by id";
        }
    }
}