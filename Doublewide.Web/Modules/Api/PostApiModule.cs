using Nancy;

namespace Doublewide.Web.Modules.Api
{
    public class PostApiModule : NancyModule
    {
        public PostApiModule() : base("/api/posts")
        {
            Get["/"] = parameters => "GET posts";

            Get["/{id}"] = parameters => "GET player by id";

            Put["/"] = parameters => "PUT player";

            Post["/{id}"] = parameters => "POST player by id";

            Delete["/{id}"] = parameters => "DELETE player by id";            
        }
    }
}