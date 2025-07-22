using Restaurants.API.Extensions;
using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extentions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
namespace Resturants.API;

public partial class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.AddPresentation();

        builder.Services.AddApplication();

        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        var scoope = app.Services.CreateScope();
        var seeder = scoope.ServiceProvider.GetRequiredService<IRestaurantSeeders>();
        await seeder.Seed();

        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseMiddleware<RequestTimeLoggingMiddleware>();

        app.UseSerilogRequestLogging();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGroup("api/identity")
            .WithTags("Identity")
            .MapIdentityApi<ApplicationUser>();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
