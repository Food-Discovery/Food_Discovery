using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Core.Projections.Authors;
using Dish_Discovery.Core.Projections.Types;
using Dish_Discovery.Core.Projections.Recipes;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Data.Repositories;
using Dish_Discovery.Data.Sorting;
using System.Linq.Expressions;

namespace Dish_Discovery.Core.Services
{
    public class RecipeService : BaseService<Recipe>, IRecipeService
    {
        public RecipeService(IRepository<Recipe> repository)
            : base(repository)
        {
        }

        public IEnumerable<RecipeGeneralInfoProjection> GetAll()
        {
            var nameOrderClause = new OrderClause<Recipe> { Expression = s => s.Name };
            var artistOrderClause = new OrderClause<Recipe> { Expression = s => s.Author.Nickname };
            return this.Repository.GetMany(
                _ => true,
                this.GetGeneralInfoProjection(),
                new[] { nameOrderClause, artistOrderClause });
        }

        public RecipeGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                s => s.Id == id,
                this.GetGeneralInfoProjection());
        }

        public RecipeEditProjection? GetOneEdit(Guid id)
        {
            return this.Repository.Get(
                s => s.Id == id,
                s => new RecipeEditProjection
                {
                    Id = s.Id,
                    Name = s.Name,
                    AuthorId = s.AuthorId,
                    TypeIds = s.Types.Select(g => g.Id)
                });
        }

        public RecipeMinifiedProjection? GetOneMinified(Guid id)
        {
            return this.Repository.Get(
                s => s.Id == id,
                s => new RecipeMinifiedProjection
                {
                    Id = s.Id,
                    Name = s.Name
                });
        }

        private Expression<Func<Recipe, RecipeGeneralInfoProjection>> GetGeneralInfoProjection()
        {
            return s => new RecipeGeneralInfoProjection
            {
                Id = s.Id,
                Name = s.Name,
                Author = new AuthorMinifiedProjection
                {
                    Id = s.Author.Id,
                    Nickname = s.Author.Nickname
                },
                Types = s.Types.Select(g => new TypeMinifiedProjection
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()
            };
        }
    }
}
