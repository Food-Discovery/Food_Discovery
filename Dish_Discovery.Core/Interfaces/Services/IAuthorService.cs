using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Projections.Authors;
using Dish_Discovery.Data.Models;

namespace Dish_Discovery.Core.Interfaces.Services
{
    public interface IAuthorService : IService<Author>
    {
        IEnumerable<AuthorGeneralInfoProjection> GetAll();
        IEnumerable<AuthorMinifiedProjection> GetAllMinified();
    }
}
