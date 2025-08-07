using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.Ratings.DTOs;
using Restaurants.Domain.Constants;

namespace Restaurants.Application.Ratings.Queries.GetAllRatings;
public class GetAllRatingsQuery : IRequest<PagedResult<RatingDTO>>
{
    public string? SearchPhrase { get; set; }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public string? SortBy { get; set; }

    public SortDirection SortDirection { get; set; }

}
