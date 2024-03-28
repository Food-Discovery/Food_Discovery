using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Core.Projections.Types
{
    public record TypeGeneralInfoProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required long AuthorsCount { get; init; }
        public required long RecipesCount { get; init; }
    }
}
