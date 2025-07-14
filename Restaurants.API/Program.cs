using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extentions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
namespace Resturants.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();

        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
            );


        var app = builder.Build();

        var scoope = app.Services.CreateScope();
        var seeder = scoope.ServiceProvider.GetRequiredService<IRestaurantSeeders>();
        await seeder.Seed();

        app.UseSerilogRequestLogging();


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
