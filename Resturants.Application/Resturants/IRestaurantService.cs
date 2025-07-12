using Resturants.Domain.Entities;

namespace Resturants.Application.Resturants;
public interface IRestaurantService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> GetById(int id);
}