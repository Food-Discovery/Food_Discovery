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
    public class AuthorServiceTests : BaseTest
    {
            public AuthorServiceTests(MySqlDatabaseFixture databaseFixture, ITestOutputHelper outputHelper)
                : base(databaseFixture, outputHelper)
            {
            }

            [Fact]
            public void CreateAuthorShouldWorkCorrectly()
            {
                // Arrange
                var author = new Author { FirstName = RandomizationHelper.GetRandomString() , LastName = RandomizationHelper.GetRandomString() , Nickname = RandomizationHelper.GetRandomString()};

                // Act
                var create = this.AuthorService.Create(author);

                // Assert
                Assert.True(create, "Author was not created successfully - it may be invalid.");
                Assert.NotEqual(default, author.Id);
            }

            [Fact]
            public void GetAuthorsShouldReturnEmptyCollectionIfNoAuthorsAreCreated()
            {
                // Arrange
                // Act
                var allAuthors = this.AuthorService.GetAll();

                // Assert
                Assert.NotNull(allAuthors);
                Assert.Empty(allAuthors);
            }
    }
}
