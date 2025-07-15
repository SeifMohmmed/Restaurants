using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IDishesRepository
{
    Task<IEnumerable<Dish>> GetAllAsync();
    Task<Dish?> GetByIdAsync(int id);
    Task<int> CreateAsync(Dish entity);
    Task DeleteAsync(Dish entity);
    Task SaveChangesAsync();
}
