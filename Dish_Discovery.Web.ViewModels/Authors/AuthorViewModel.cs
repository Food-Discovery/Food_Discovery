using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Authors
{
    public  record AuthorViewModel
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string NickName { get; init; }

        [DisplayName("Count of types")]
        public required long TypesCount { get; init; }

        [DisplayName("Count of recipes")]
        public required long RecipesCount { get; init; }
    }
}
