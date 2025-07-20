using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQuery> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDTO>>
{
    public async Task<IEnumerable<RestaurantDTO>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Getting All Restaurants");
        IEnumerable<Restaurant>? restaurants = await restaurantsRepository.GetAllMathchingAsync(request.SearchPhrase);

        var restaurantDTOs = mapper.Map<IEnumerable<RestaurantDTO>?>(restaurants);

        return restaurantDTOs!;
    }
}
