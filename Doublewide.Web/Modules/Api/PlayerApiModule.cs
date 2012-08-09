using Nancy;

namespace Doublewide.Web.Modules.Api
{
    public class PlayerApiModule : NancyModule
    {
        public PlayerApiModule() : base("/api/players")
        {
            Get["/"] = parameters => "GET players";

            Get["/{id}"] = parameters => "GET player by id";

            Put["/"] = parameters => "PUT player";

            Post["/{id}"] = parameters => "POST player by id";

            Delete["/{id}"] = parameters => "DELETE player by id";
        }
    }
}