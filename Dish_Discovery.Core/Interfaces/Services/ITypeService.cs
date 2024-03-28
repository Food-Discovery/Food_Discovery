using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Projections.Types;
using Dish_Discovery.Data.Models;

namespace Dish_Discovery.Core.Interfaces.Services
{
    public interface ITypeService : IService<Data.Models.Type>
    {
        IEnumerable<TypeGeneralInfoProjection> GetAll();
        TypeGeneralInfoProjection? GetOne(Guid id);

        IEnumerable<TypeMinifiedProjection> GetAllMinified();
        TypeMinifiedProjection? GetOneMinified(Guid id);

        TypeEditProjection? GetOneEdit(Guid id);
    }
}
