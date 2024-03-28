using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Data.Models
{
    public interface IIdentifiable
    {
        Guid Id { get; } 
    }
}
