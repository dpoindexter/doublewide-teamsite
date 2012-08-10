using System.Data;
using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Entities.Contracts;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Doublewide.Application.Repositories
{
    public class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>, new()
    {
        protected readonly string _connectionString;
        protected readonly OrmLiteConnectionFactory _connectionFactory;
        protected readonly IDbConnection _db;

        protected BaseRepository()
        {
            //_connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=Doublewide;user id=doublewide_user;password=welln@styh00p!";
            _connectionString =
                @"Server=7358298a-476c-448c-877e-a0a900913153.sqlserver.sequelizer.com;Database=db7358298a476c448c877ea0a900913153;User ID=yuuofpcpodiynufp;Password=eF6yuRUVqUJLcwGR7CVMoGiKat7XJYYmwEbdWKrpdbrzbCHkJLacaGwEwtybS6my;";

            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, SqlServerOrmLiteDialectProvider.Instance);
            _db = _connectionFactory.OpenDbConnection();
        }

        public virtual TEntity Get(TId id)
        {
            return _db.GetById<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _db.Select<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            _db.Insert(entity);
        }

        public virtual void Save(TEntity entity)
        {
            _db.Save(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _db.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _db.Delete(entity);
        }
    }
}