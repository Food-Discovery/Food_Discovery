using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Types
{
    public  record TypeViewModel
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }

        [DisplayName("Count of authors")]
        public required long AuthorsCount { get; init; }

        [DisplayName("Count of recipes")]
        public required long RecipesCount { get; init; }
    }
}
