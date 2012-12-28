using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;

namespace Doublewide.Web.Extensions
{
    public static class EnumerableExtensions
    {
         public static IEnumerable<TModel> MapToInjectedModel<TEntity, TModel>(this IEnumerable<TEntity> entities)
            where TEntity : class
            where TModel : new()
         {
             return entities.Select(x =>
             {
                 var m = new TModel();
                 m.InjectFrom(x);
                 return m;
             });
         }
    }
}