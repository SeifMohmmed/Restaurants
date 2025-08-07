using MediatR;
using Restaurants.Application.Ratings.DTOs;

namespace Restaurants.Application.Ratings.Queries.GetRatingById;
public class GetRatingByIdQuery(int id) : IRequest<RatingDTO>
{
    public int Id { get; } = id;

}
