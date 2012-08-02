using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doublewide.Domain.Entities.Contracts
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
