using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Resturants;
public interface IRestaurantService
{
    Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
    Task<RestaurantDTO?> GetById(int id);
}