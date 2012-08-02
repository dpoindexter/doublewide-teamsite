using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Doublewide.Domain.Entities.Team;

namespace Doublewide.Application.Repositories.Contracts
{
    public interface IPlayerRepository : IRepository<Player, int>
    {
    }
}
