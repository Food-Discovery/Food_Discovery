using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Projections.Recipes;


namespace Dish_Discovery.Core.Projections.Authors
{
    public record AuthorGeneralInfoProjection
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Nickname { get; init; }
        public required RecipeMinifiedProjection[] Recipes { get; init; }
    }
}
