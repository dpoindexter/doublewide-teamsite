using System.Data;
using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Entities.Contracts;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Doublewide.Application.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
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

        public abstract TEntity Get(TId id);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract void Create(TEntity entity);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
    }
}