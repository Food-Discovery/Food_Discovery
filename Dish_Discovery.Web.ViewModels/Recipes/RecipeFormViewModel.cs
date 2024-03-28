using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Web.ViewModels.Authors;
using Dish_Discovery.Web.ViewModels.Types;

namespace Dish_Discovery.Web.ViewModels.Recipes
{
    public record RecipeFormViewModel<TInputModel>
    {
        public required IEnumerable<AuthorMinifiedViewModel> Authors { get; init; }
        public required IEnumerable<TypeMinifiedViewModel> Types { get; init; }
        public TInputModel? InputModel { get; init; }
    }
}
