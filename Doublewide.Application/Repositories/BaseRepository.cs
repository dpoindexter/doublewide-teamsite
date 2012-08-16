using System.Data;
using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Entities.Contracts;
using ServiceStack.OrmLite;

namespace Doublewide.Application.Repositories
{
    public class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>, new()
    {
        protected readonly IDbConnectionFactory _connectionFactory;

        protected BaseRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public virtual TEntity Get(TId id)
        {
            TEntity result;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                result = db.GetById<TEntity>(id);
            }
            return result;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> result;
            using (var db = _connectionFactory.OpenDbConnection())
            {
                result = db.Select<TEntity>();
            }
            return result;
        }

        public virtual void Create(TEntity entity)
        {
            using (var db = _connectionFactory.OpenDbConnection())
            {
                db.Insert(entity); 
            }
        }

        public virtual void Save(TEntity entity)
        {
            using (var db = _connectionFactory.OpenDbConnection())
            {
                db.Save(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var db = _connectionFactory.OpenDbConnection())
            {
                db.Update(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var db = _connectionFactory.OpenDbConnection())
            {
                db.Delete(entity);
            }
        }
    }
}