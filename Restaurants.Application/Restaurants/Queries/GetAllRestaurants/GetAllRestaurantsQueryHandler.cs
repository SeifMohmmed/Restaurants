﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQuery> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDTO>>
{
    public async Task<PagedResult<RestaurantDTO>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting All Restaurants");

        var (restaurants, totalCount) = await restaurantsRepository.GetAllMathchingAsync(request.SearchPhrase,
            request.PageNumber,
            request.PageSize);

        var restaurantDTOs = mapper.Map<IEnumerable<RestaurantDTO>?>(restaurants);

        var result = new PagedResult<RestaurantDTO>(restaurantDTOs, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
