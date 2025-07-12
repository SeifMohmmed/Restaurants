using Restaurants.Domain.Entities;

namespace Restaurants.Application.Resturants;
public interface IRestaurantService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> GetById(int id);
}