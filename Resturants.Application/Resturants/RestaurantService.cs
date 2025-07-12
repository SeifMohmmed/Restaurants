using Microsoft.Extensions.Logging;
using Resturants.Domain.Entities;
using Resturants.Domain.Repositories;

namespace Resturants.Application.Resturants;
internal class RestaurantService(IRestaurantsRepository restaurantsRepository,
              ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Getting All Restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();

        return restaurants;
    }

    public async Task<Restaurant?> GetById(int id)
    {
        logger.LogInformation($"Getting Restaurant With Id ({id})");

        var restaurant = await restaurantsRepository.GetByIdAsync(id);

        return restaurant;
    }
}
