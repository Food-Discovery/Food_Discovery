using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Authors
{
    public record AuthorCreateModel
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string NickName { get; init; }


    }
}
