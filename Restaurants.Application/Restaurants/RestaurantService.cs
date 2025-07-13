using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Resturants;
internal class RestaurantService(IRestaurantsRepository restaurantsRepository,
              ILogger<RestaurantService> logger, IMapper mapper) : IRestaurantService
{
    public async Task<int> Create(CreateRestaurantDTO dto)
    {
        logger.LogInformation(message: "Creating a new restaurant");

        var restaurant = mapper.Map<Restaurant>(dto);

        int id = await restaurantsRepository.Create(restaurant);

        return id;
    }

    public async Task<IEnumerable<RestaurantDTO?>> GetAllRestaurants()
    {
        logger.LogInformation("Getting All Restaurants");
        IEnumerable<Restaurant>? restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantDTOs = mapper.Map<IEnumerable<RestaurantDTO>?>(restaurants);

        return restaurantDTOs!;
    }

    public async Task<RestaurantDTO?> GetById(int id)
    {
        logger.LogInformation($"Getting Restaurant With Id ({id})");

        var restaurant = await restaurantsRepository.GetByIdAsync(id);

        var restaurantDTO = mapper.Map<RestaurantDTO?>(restaurant);

        return restaurantDTO;
    }
}
