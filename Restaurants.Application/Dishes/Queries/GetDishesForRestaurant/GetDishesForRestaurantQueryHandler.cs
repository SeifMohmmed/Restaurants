using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
public class GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDTO>>
{
    public async Task<IEnumerable<DishDTO>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dishes for restaurant with id: {RestaurantId}", request.RestaurantId);

        var restaurants = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

        if (restaurants is null)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var results = mapper.Map<IEnumerable<DishDTO>>(restaurants.Dishes);

        return results;
    }
}
