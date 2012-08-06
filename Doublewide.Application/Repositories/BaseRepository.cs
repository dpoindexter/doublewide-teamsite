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
        protected readonly IDbConnectionFactory _connectionFactory;
        protected readonly IDbConnection _db;

        protected BaseRepository()
        {
            _connectionString =
                @"Data Source=.\SQLEXPRESS;initial catalog=Doublewide;user id=doublewide_user;password=welln@styh00p!";

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