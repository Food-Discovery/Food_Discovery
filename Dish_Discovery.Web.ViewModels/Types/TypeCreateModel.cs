using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Web.ViewModels.Types
{
    public record TypeCreateModel
    {
        public required string Name { get; init; }  
    }
}
