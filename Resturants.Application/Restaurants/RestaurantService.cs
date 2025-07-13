using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Resturants;
internal class RestaurantService(IRestaurantsRepository restaurantsRepository,
              ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<IEnumerable<RestaurantDTO?>> GetAllRestaurants()
    {
        logger.LogInformation("Getting All Restaurants");
        IEnumerable<Restaurant>? restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantDTOs = restaurants.Select(RestaurantDTO.FromEntity);

        return restaurantDTOs!;
    }

    public async Task<RestaurantDTO?> GetById(int id)
    {
        logger.LogInformation($"Getting Restaurant With Id ({id})");

        var restaurant = await restaurantsRepository.GetByIdAsync(id);

        var restaurantDTO = RestaurantDTO.FromEntity(restaurant);

        return restaurantDTO;
    }
}
