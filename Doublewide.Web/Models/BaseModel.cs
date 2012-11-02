using Omu.ValueInjecter;

namespace Doublewide.Web.Models
{
    public abstract class BaseModel
    {
        public virtual TModel ToModel<TEntity, TModel>(TEntity entity)
            where TEntity : class
            where TModel : BaseModel
        {
            this.InjectFrom(entity);
            return (TModel)this;
        }
    }
}