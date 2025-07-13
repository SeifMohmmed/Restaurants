using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;

namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantsRepository(RestaurantDbContext context)
        : IRestaurantsRepository
{
    public async Task<int> Create(Restaurant entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await context.Resturants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await context.Resturants
                                                .Include(r => r.Dishes)
                                                .FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }
}
