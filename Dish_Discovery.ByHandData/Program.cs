using Dish_Discovery.Core.Services;
using Dish_Discovery.Data;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Core.Projections.Recipes;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Dish_Discovery.ByHandData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost;Database=recipe;Uid=root;Pwd=1030110716;";
            using Dish_DbContext dbContext = InitializeDatabase(connectionString);

            IRepository<Recipe> recipeRepository = new Repository<Recipe>(dbContext);
            IRecipeService recipeService = new RecipeService(recipeRepository);

            IRepository<Data.Models.Type> typeRepository = new Repository<Data.Models.Type>(dbContext);
            ITypeService typeService = new TypeService(typeRepository);

            IRepository<Author> authorRepository = new Repository<Author>(dbContext);
            IAuthorService authorService = new AuthorService(authorRepository);

            bool continueProcessingInput = true;
            while (continueProcessingInput)
            {
                dbContext.ChangeTracker.Clear();

                PrintMenu();
                string input = Console.ReadLine().Trim();

                if (input == "1") CreateRecipe(recipeService, typeService);
                else if (input == "2") GetAllRecipes(recipeService);
                else if (input == "3") CreateAuthor(authorService);
                else if (input == "4") GetAllAuthors(authorService);
                else if (input == "5") CreateType(typeService);
                else if (input == "6") GetAllTypes(typeService);
                else if (input == "0") continueProcessingInput = false;
                else Console.WriteLine("Invalid input!");

                Console.WriteLine();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Create recipe");
            Console.WriteLine("2. Get all recipes");
            Console.WriteLine("3. Create author");
            Console.WriteLine("4. Get all authors with their recipes");
            Console.WriteLine("5. Create type");
            Console.WriteLine("6. Get all types");
            Console.WriteLine("0. Exit");
        }

        private static Dish_DbContext InitializeDatabase(string connectionString)
        {
            DbContextOptionsBuilder<Dish_DbContext> optionsBuilder = new DbContextOptionsBuilder<Dish_DbContext>();

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

            optionsBuilder.LogTo(Console.WriteLine, minimumLevel: LogLevel.Information);
            optionsBuilder.UseMySQL(connectionString);

            Dish_DbContext dbContext = new Dish_DbContext(optionsBuilder.Options);
            // dbContext.Database.EnsureDeleted();
            // dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            return dbContext;
        }

        private static void CreateRecipe(IRecipeService recipeService, ITypeService typeService)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Author ID: ");
            Guid authorId = Guid.Parse(Console.ReadLine());

            Console.Write("Type IDs (separated by ', '): ");
            Guid[] typeIds = Console.ReadLine().Split(", ").Select(Guid.Parse).ToArray();

            Data.Models.Type[] types = typeService.GetByIds(typeIds).ToArray();
            if (types.Length != typeIds.Length)
            {
                Console.WriteLine("Some of the types could not be found. The recipe will not be created.");
                return;
            }

            Recipe recipeToCreate = new Recipe { Name = name, AuthorId = authorId, Types = types };

            recipeService.Create(recipeToCreate);

            Console.WriteLine($"Recipe was created successfully! ID: {recipeToCreate.Id}");
        }
        private static void GetAllRecipes(IRecipeService recipeService)
        {
            List<RecipeGeneralInfoProjection> allRecipes = recipeService.GetAll().ToList();
            foreach (var recipe in allRecipes)
                Console.WriteLine($"{recipe.Id}: \"{recipe.Name}\", {recipe.Author.Nickname}");
        }

        private static void CreateAuthor(IAuthorService authorService)
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();

            Author authorToCreate = new Author { FirstName = firstName, LastName = lastName, Nickname = nickname, };
            authorService.Create(authorToCreate);

            Console.WriteLine($"Author was created successfully! ID: {authorToCreate.Id}");
        }
        private static void GetAllAuthors(IAuthorService authorService)
        {
            var allAuthors = authorService.GetAll();

            foreach (var author in allAuthors)
            {
                Console.WriteLine($"{author.Id}: {author.Nickname} ({author.FirstName} {author.LastName})");
                foreach (var recipe in author.Recipes)
                    Console.WriteLine($"--> {recipe.Id}: {recipe.Name}");
            }
        }

        private static void CreateType(ITypeService typeService)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Data.Models.Type typeToCreate = new Data.Models.Type { Name = name };
            typeService.Create(typeToCreate);

            Console.WriteLine($"Type was created successfully! ID: {typeToCreate.Id}");
        }

        private static void GetAllTypes(ITypeService typeService)
        {
            var alltypes = typeService.GetAll();

            foreach (var type in alltypes)
                Console.WriteLine($"{type.Id}: {type.Name}");
        }
    }
}
