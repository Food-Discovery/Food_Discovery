using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Core.Projections.Types;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Data.Repositories;
using Dish_Discovery.Data.Sorting;
using System.Linq.Expressions;

namespace Dish_Discovery.Core.Services
{
    public class TypeService : BaseService<Data.Models.Type>, ITypeService
    {
        public TypeService(IRepository<Data.Models.Type> repository)
            : base(repository)
        {
        }

        public IEnumerable<TypeGeneralInfoProjection> GetAll()
        {
            var nameOrderClause = new OrderClause<Data.Models.Type> { Expression = g => g.Name };
            return this.Repository.GetMany(
                _ => true,
                this.GetGeneralInfoProjection(),
                new[] { nameOrderClause });
        }

        public IEnumerable<TypeMinifiedProjection> GetAllMinified()
        {
            var nameOrderClause = new OrderClause<Data.Models.Type> { Expression = g => g.Name };
            return this.Repository.GetMany(
                _ => true,
                this.GetMinifiedProjection(),
                new[] { nameOrderClause });
        }

        public TypeGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                this.GetGeneralInfoProjection());
        }

        public TypeMinifiedProjection? GetOneMinified(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                this.GetMinifiedProjection());
        }

        public TypeEditProjection? GetOneEdit(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                g => new TypeEditProjection
                {
                    Id = g.Id,
                    Name = g.Name
                });
        }

        private Expression<Func<Data.Models.Type, TypeGeneralInfoProjection>> GetGeneralInfoProjection()
        {
            return g => new TypeGeneralInfoProjection
            {
                Id = g.Id,
                Name = g.Name,
                AuthorsCount = g.Recipes.Select(s => s.AuthorId).Distinct().LongCount(),
                RecipesCount = g.Recipes.LongCount()
            };
        }

        private Expression<Func<Data.Models.Type, TypeMinifiedProjection>> GetMinifiedProjection()
        {
            return g => new TypeMinifiedProjection
            {
                Id = g.Id,
                Name = g.Name,
            };
        }
    }
}
