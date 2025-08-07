using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Ratings.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Ratings.Queries.GetRatingById;
public class GetRatingByIdQueryHandler(ILogger<GetRatingByIdQuery> logger,
    IMapper mapper,
    IRatingsRepository ratingsRepository) : IRequestHandler<GetRatingByIdQuery, RatingDTO>
{
    public async Task<RatingDTO> Handle(GetRatingByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting rating {RatingId}", request.Id);

        var ratings = await ratingsRepository.GetByIdWithIncluded(request.Id)
         ?? throw new NotFoundException(nameof(Rating), request.Id.ToString());

        var ratingDTO = mapper.Map<RatingDTO>(ratings);

        return ratingDTO;
    }
}
