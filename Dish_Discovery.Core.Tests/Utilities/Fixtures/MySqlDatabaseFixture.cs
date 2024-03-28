using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Data;
using TryAtSoftware.Randomizer.Core.Helpers;

namespace Dish_Discovery.Core.Tests.Utilities.Fixtures
{
    public sealed class MySqlDatabaseFixture : IDisposable
    {
        private readonly Dish_DbContext _dbContext;
        private bool disposedValue;

        public MySqlDatabaseFixture()
        {
            var randomName = RandomizationHelper.GetRandomString(10, RandomizationHelper.LOWER_CASE_LETTERS);
            this.ConnectionString = $"Server=localhost;Database=test_{randomName};Uid=root;Pwd=1030110716;";

            DbContextOptionsBuilder<Dish_DbContext> optionsBuilder = new DbContextOptionsBuilder<Dish_DbContext>();
            optionsBuilder.UseMySQL(this.ConnectionString);

            this._dbContext = new Dish_DbContext(optionsBuilder.Options);
            this._dbContext.Database.EnsureCreated();
        }

        public string ConnectionString { get; }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._dbContext.Database.EnsureDeleted();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
