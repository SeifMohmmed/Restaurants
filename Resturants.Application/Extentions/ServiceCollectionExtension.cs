using Microsoft.Extensions.DependencyInjection;
using Resturants.Application.Resturants;

namespace Resturants.Application.Extentions;
public static class ServiceCollectionExtentions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantService, RestaurantService>();
    }
}

