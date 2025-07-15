using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;

namespace Restaurants.Infrastructure.Repositories;
internal class DishesRepository(RestaurantDbContext context) : IDishesRepository
{
    public async Task<int> CreateAsync(Dish entity)
    {
        await context.AddAsync(entity);

        await context.SaveChangesAsync();

        return entity.Id;
    }

    public Task DeleteAsync(Dish entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Dish>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
