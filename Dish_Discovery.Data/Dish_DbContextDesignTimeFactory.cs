using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Data
{
    public class Dish_DbContextDesignTimeFactory : IDesignTimeDbContextFactory<Dish_DbContext>
    {
        public Dish_DbContext CreateDbContext(string[] args)
        {
            //if (args.Length != 1) throw new InvalidOperationException("You need to pass the connection string to use as the only argument.");
            string connectionString = "Server=localhost;Database=recipe;Uid=root;Pwd=1030110716;";

            DbContextOptionsBuilder<Dish_DbContext> optionsBuilder = new DbContextOptionsBuilder<Dish_DbContext>();

            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
            optionsBuilder.UseMySQL(connectionString);

            Dish_DbContext dbContext = new Dish_DbContext(optionsBuilder.Options);
            return dbContext;
        }
    }
}
