using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Projections.Recipes;
using Dish_Discovery.Data.Models;

namespace Dish_Discovery.Core.Interfaces.Services
{
    public interface IRecipeService : IService<Recipe>
    {
        IEnumerable<RecipeGeneralInfoProjection> GetAll();
        RecipeGeneralInfoProjection? GetOne(Guid id);

        RecipeMinifiedProjection? GetOneMinified(Guid id);

        RecipeEditProjection? GetOneEdit(Guid id);
    }
}
