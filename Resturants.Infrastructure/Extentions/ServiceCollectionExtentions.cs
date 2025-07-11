using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resturants.Infrastructure.Data;
using Resturants.Infrastructure.Seeders;

namespace Resturants.Infrastructure.Extentions;
public static class ServiceCollectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<RestaurantDbContext>(option => option.UseSqlServer(connectionString));

        services.AddScoped<IResturantSeeders, ResturantSeeders>();
    }
}
