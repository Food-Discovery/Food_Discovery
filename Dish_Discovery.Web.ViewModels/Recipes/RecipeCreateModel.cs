using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Recipes
{
    public record RecipeCreateModel
    {
        public required string Name { get; init; }
        public string Instruction { get; init; }
        public string Ingredients { get; init; }
        public string Time { get; init; }
        public int Servings { get; init; }
        public string Calories { get; init; }
        public required Guid Author { get; init; }
        public required Guid[] Types { get; init; }
    }
}
