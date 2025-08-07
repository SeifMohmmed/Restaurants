using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Ratings.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Ratings.Queries.GetAllRatings;
public class GetAllRatingsQueryHandler(ILogger<GetAllRatingsQueryHandler> logger,
    IMapper mapper,
    IRatingsRepository ratingsRepository) : IRequestHandler<GetAllRatingsQuery, PagedResult<RatingDTO>>
{
    public async Task<PagedResult<RatingDTO>> Handle(GetAllRatingsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all Ratings");

        var (ratings, totalCount) = await ratingsRepository.GetAllMathchingAsync(request.SearchPhrase,
                request.PageSize,
                request.PageNumber,
                request.SortBy,
                request.SortDirection);

        var ratingDtos = mapper.Map<IEnumerable<RatingDTO>>(ratings);

        var result = new PagedResult<RatingDTO>(ratingDtos, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
