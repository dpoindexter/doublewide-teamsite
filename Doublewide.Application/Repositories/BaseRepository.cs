using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Doublewide.Application.Repositories.Contracts;
using Doublewide.Domain.Entities.Contracts;
using ServiceStack.Common.Utils;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace Doublewide.Application.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        protected readonly string _connectionString;
        protected readonly IDbConnectionFactory _connectionFactory;
        protected readonly IDbConnection _db;

        public BaseRepository() : this(string.Empty)
        {
        }

        public BaseRepository(string connectionString)
        {
            _connectionString = (!String.IsNullOrEmpty(connectionString))
                ? connectionString
                : ConfigurationManager.ConnectionStrings["DoublewideContext"].ConnectionString;

            _connectionFactory = new OrmLiteConnectionFactory(_connectionString, SqlServerOrmLiteDialectProvider.Instance);
            _db = _connectionFactory.OpenDbConnection();
        }

        public abstract TEntity Get(TId Id);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract void Create(TEntity entity);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
    }
}