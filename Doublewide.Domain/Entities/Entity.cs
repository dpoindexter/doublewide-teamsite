using Doublewide.Domain.Entities.Contracts;
using ServiceStack.DataAnnotations;

namespace Doublewide.Domain.Entities
{
    public class Entity : IEntity<int>
    {
        [AutoIncrement]
        public int Id { get; set; }
    }
}