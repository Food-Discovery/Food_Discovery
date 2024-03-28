using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Core.Projections.Recipes
{
    public record RecipeMinifiedProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
