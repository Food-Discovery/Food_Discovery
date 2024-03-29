using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Data.Models
{
    public class Recipe : IIdentifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public int Servings { get; set; }
        public string Calories { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;  // Navigation property

        public ICollection<Type> Types { get; set; } = new List<Type>();
    }
}
