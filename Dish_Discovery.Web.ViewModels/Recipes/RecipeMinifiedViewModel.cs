using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Recipes
{
    public record RecipeMinifiedViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
