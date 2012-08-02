using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Entities.Team;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Doublewide.Application.Repositories
{
    public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
    {
        public PlayerRepository(string connectionString) : base(connectionString)
        {
        }

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
            _db.Insert<Player>(player);
        }

        public override void Save(Player player)
        {
            _db.Save<Player>(player);
        }

        public override void Update(Player player)
        {
            _db.Update<Player>(player);
        }

        public override void Delete(Player player)
        {
            _db.Delete<Player>(player);
        }
    }
}