using System.Collections.Generic;
using Doublewide.Domain.Entities.Contracts;

namespace Doublewide.Application.Repositories.Contracts
{
    public interface IRepository<TEntity,TId> where TEntity : IEntity<TId>
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
