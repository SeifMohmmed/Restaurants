using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Resturants;

namespace Restaurants.Application.Extentions;
public static class ServiceCollectionExtentions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantService, RestaurantService>();
    }
}

