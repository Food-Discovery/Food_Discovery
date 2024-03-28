using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Dish_Discovery.Core.Tests.Utilities.Fixtures;


namespace Dish_Discovery.Core.Tests.Utilities.Collections
{
    [CollectionDefinition(Name)]
    public class MySqlDatabaseCollection : ICollectionFixture<MySqlDatabaseFixture>
    {
        public const string Name = "my_sql_database";
    }
}
