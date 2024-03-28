using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Data.Models;


namespace Dish_Discovery.Core.Interfaces.Services
{
    public interface IService<TEntity>
        where TEntity : class, IIdentifiable
    {
        // According to the "Interface segregation" principle, this method could be moved to a separate interface.
        // Moreover, it `increases` the constraints over the `TEntity` generic parameter.
        IEnumerable<TEntity> GetByIds(IEnumerable<Guid> ids);

        TEntity? GetById(Guid id);
        TEntity? GetByIdComplete(Guid id);
        TEntity? GetByIdWithNavigations(Guid id, IEnumerable<string> navigations);

        bool Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Guid id);
    }
}
