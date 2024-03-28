using Dish_Discovery.Core.Tests.Utilities.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Data.Models;
using TryAtSoftware.Randomizer.Core.Helpers;
using Xunit.Abstractions;
using Xunit;

namespace Dish_Discovery.Core.Tests
{
    public class TypeServiceTests : BaseTest
    {
            public TypeServiceTests(MySqlDatabaseFixture databaseFixture, ITestOutputHelper outputHelper)
                : base(databaseFixture, outputHelper)
            {
            }

            [Fact]
            public void CreateTypeShouldWorkCorrectly()
            {
                // Arrange
                var type = new Data.Models.Type { Name = RandomizationHelper.GetRandomString() };

                // Act
                var create = this.TypeService.Create(type);

                // Assert
                Assert.True(create, "Type was not created successfully - it may be invalid.");
                Assert.NotEqual(default, type.Id);
            }

            [Fact]
            public void GetTypesShouldReturnEmptyCollectionIfNoTypesAreCreated()
            {
                // Arrange
                // Act
                var allTypes = this.TypeService.GetAll();

                // Assert
                Assert.NotNull(allTypes);
                Assert.Empty(allTypes);
            }
    }
}
