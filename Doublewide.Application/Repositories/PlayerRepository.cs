using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Team;
using ServiceStack.OrmLite;

namespace Doublewide.Application.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        public override Player Get(int id)
        {
            return _db.GetById<Player>(id);
        }

        public override IEnumerable<Player> GetAll()
        {
            return _db.Select<Player>();
        }

        public override void Create(Player player)
        {
            _db.Insert(player);
        }

        public override void Save(Player player)
        {
            _db.Save(player);
        }

        public override void Update(Player player)
        {
            _db.Update(player);
        }

        public override void Delete(Player player)
        {
            _db.Delete(player);
        }
    }
}