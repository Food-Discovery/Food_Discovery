using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Core.Projections.Recipes
{
    public record RecipeEditProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public  required string Instruction { get; init; }
        public required string Ingredients { get; init; }
        public required string Time { get; init; }
        public required string Servings { get; init; }
        public required string Calories { get; init; }
        public required Guid AuthorId { get; init; }
        public required IEnumerable<Guid> TypeIds { get; init; }
    }
}
