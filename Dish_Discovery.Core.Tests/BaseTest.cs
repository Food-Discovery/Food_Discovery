using Dish_Discovery.Core.Tests.Utilities.Collections;
using Dish_Discovery.Core.Tests.Utilities.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Dish_Discovery.Core.Configuration;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;

namespace Dish_Discovery.Core.Tests
{
    [Collection(MySqlDatabaseCollection.Name)]
    public class BaseTest : IDisposable
    {
        private ServiceProvider _rootServiceProvider;
        private IServiceScope _scope;
        private bool disposedValue;

        public BaseTest(MySqlDatabaseFixture databaseFixture, ITestOutputHelper testOutputHelper)
        {
            this.TestOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));

            var services = new ServiceCollection();
            services.RegisterServices();
            services.AddDbContext<Dish_DbContext>(options =>
            {
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
                options.LogTo(this.TestOutputHelper.WriteLine, minimumLevel: LogLevel.Information);
                options.UseMySQL(databaseFixture.ConnectionString);
            });

            var serviceProviderOptions = new ServiceProviderOptions { ValidateScopes = true, ValidateOnBuild = true };
            this._rootServiceProvider = services.BuildServiceProvider(serviceProviderOptions);
            this._scope = this._rootServiceProvider.CreateScope();
        }

        protected ITestOutputHelper TestOutputHelper { get; }
        protected ITypeService TypeService => this._scope.ServiceProvider.GetRequiredService<ITypeService>();
        protected IAuthorService AuthorService => this._scope.ServiceProvider.GetRequiredService<IAuthorService>();
        protected IRecipeService RecipeService => this._scope.ServiceProvider.GetRequiredService<IRecipeService>();

        protected Dish_DbContext DbContext => this._scope.ServiceProvider.GetRequiredService<Dish_DbContext>();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.DbContext.Types.ExecuteDelete();
                    this.DbContext.Recipes.ExecuteDelete();
                    this.DbContext.Authors.ExecuteDelete();
                    this.DbContext.SaveChanges();

                    this._scope.Dispose();
                    this._rootServiceProvider.Dispose();
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
