using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Authors
{
    public record AuthorMinifiedViewModel
    {
        public required Guid Id { get; init; }
        public required string Nickname { get; init; }
    }
}
