using Microsoft.EntityFrameworkCore;
using Dish_Discovery.Core.Configuration;
using Dish_Discovery.Data;
using System.Reflection;

namespace Dish_Discovery.Web.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            RegisterDbContext(builder);
            builder.Services.RegisterServices();
            RegisterAutoMapper(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterDbContext(WebApplicationBuilder builder)
        {
            // TODO: Read from appsettings.json!
            const string connectionString = "Server=localhost;Database=recipe;Uid=root;Pwd=1030110716;";

            builder.Services.AddDbContext<Dish_DbContext>(options =>
            {
#if DEBUG
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
#endif

                options.UseMySQL(connectionString);
            });
        }

        private static void RegisterAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
