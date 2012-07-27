using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doublewide.Domain.Entities.Contracts;

namespace Doublewide.Domain.Entities
{
    public class Entity : IEntity<int>
    {
        public int Id { get; set; }
    }
}