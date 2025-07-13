using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extentions;
using Restaurants.Infrastructure.Seeders;
namespace Resturants.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplication();

            builder.Services.AddInfrastructure(builder.Configuration);


            var app = builder.Build();

            var scoope = app.Services.CreateScope();
            var seeder = scoope.ServiceProvider.GetRequiredService<IRestaurantSeeders>();
            await seeder.Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
