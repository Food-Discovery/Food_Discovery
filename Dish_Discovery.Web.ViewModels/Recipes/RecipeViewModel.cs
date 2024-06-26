﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Web.ViewModels.Authors;
using Dish_Discovery.Web.ViewModels.Types;

namespace Dish_Discovery.Web.ViewModels.Recipes
{
    public record RecipeViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Instruction { get; init; }
        public required string Ingredients { get; init; }
        public required string Time { get; init; }
        public required int Servings { get; init; }
        public required string Calories { get; init; }
        public required AuthorMinifiedViewModel Author { get; init; }
        public required IEnumerable<TypeMinifiedViewModel> Types { get; init; }
    }
}
