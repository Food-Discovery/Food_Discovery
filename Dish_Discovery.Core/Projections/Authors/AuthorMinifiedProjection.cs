using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Core.Projections.Authors
{
    public record AuthorMinifiedProjection
    {
        public required Guid Id { get; init; }
        public required string Nickname { get; init; }
    }
}
