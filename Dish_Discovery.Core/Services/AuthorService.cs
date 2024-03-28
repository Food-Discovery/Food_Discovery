using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Core.Projections.Authors;
using Dish_Discovery.Core.Projections.Recipes;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Data.Repositories;
using Dish_Discovery.Data.Sorting;


namespace Dish_Discovery.Core.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(IRepository<Author> repository)
            : base(repository)
        {
        }

        public IEnumerable<AuthorGeneralInfoProjection> GetAll()
        {
            var nicknameOrderClause = new OrderClause<Author> { Expression = a => a.Nickname };

            return this.Repository.GetMany(
                _ => true,
                a => new AuthorGeneralInfoProjection
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Nickname = a.Nickname,
                    Recipes = a.Recipes
                        .Select(s => new RecipeMinifiedProjection
                        {
                            Id = s.Id,
                            Name = s.Name
                        })
                        .OrderBy(s => s.Name)
                        .ToArray()
                },
                new[] { nicknameOrderClause });
        }

        public IEnumerable<AuthorMinifiedProjection> GetAllMinified()
        {
            var nicknameOrderClause = new OrderClause<Author> { Expression = a => a.Nickname };

            return this.Repository.GetMany(
                _ => true,
                a => new AuthorMinifiedProjection
                {
                    Id = a.Id,
                    Nickname = a.Nickname
                },
                new[] { nicknameOrderClause });
        }
    }
}
