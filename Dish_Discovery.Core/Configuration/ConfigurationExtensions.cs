using Dish_Discovery.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Core.Services;
using Dish_Discovery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Core.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IRepository<Author>, Repository<Author>>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IRepository<Data.Models.Type>, Repository<Data.Models.Type>>();
            services.AddScoped<ITypeService, TypeService>();

            services.AddScoped<IRepository<Recipe>, Repository<Recipe>>();
            services.AddScoped<IRecipeService, RecipeService>();
        }
    }
}
