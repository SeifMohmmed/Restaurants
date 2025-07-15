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

    public async Task DeleteAsync(IEnumerable<Dish> entities)
    {
        context.Dishes.RemoveRange(entities);

        await context.SaveChangesAsync();
    }
}
