﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Projections.Authors;
using Dish_Discovery.Core.Projections.Types;

namespace Dish_Discovery.Core.Projections.Recipes
{
    public record RecipeGeneralInfoProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Instruction { get; init; }
        public required string Ingredients { get; init; }
        public required string Time { get; init; }
        public required string Servings { get; init; }
        public required string Calories { get; init; }
        public required AuthorMinifiedProjection Author { get; init; }
        public required IEnumerable<TypeMinifiedProjection> Types { get; init; }

    }
}
