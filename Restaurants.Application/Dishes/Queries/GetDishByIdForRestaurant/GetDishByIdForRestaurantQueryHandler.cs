using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;
public class GetDishByIdForRestaurantQueryHandler(ILogger<GetDishByIdForRestaurantQueryHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDTO>
{
    public async Task<DishDTO> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id: {RestaurantId}",
          request.DishId,
          request.RestaurantId);

        var restaurants = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

        if (restaurants is null)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = restaurants.Dishes.FirstOrDefault(d => d.Id == request.DishId);

        if (dish is null)
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());

        var results = mapper.Map<DishDTO>(dish);

        return results;
    }
}
