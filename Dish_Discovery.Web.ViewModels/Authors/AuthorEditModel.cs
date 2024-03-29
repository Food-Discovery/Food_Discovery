using Dish_Discovery.Web.ViewModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Authors
{
    public record AuthorEditModel : AuthorCreateModel 
    {
        public required Guid Id { get; init; }
    }
}
