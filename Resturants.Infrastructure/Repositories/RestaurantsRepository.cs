using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entities;
using Resturants.Domain.Repositories;
using Resturants.Infrastructure.Data;

namespace Resturants.Infrastructure.Repositories;
internal class RestaurantsRepository(RestaurantDbContext context)
        : IRestaurantsRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await context.Resturants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await context.Resturants.FindAsync(id);
        return restaurant;
    }
}
