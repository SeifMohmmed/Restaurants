using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;

namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantsRepository(RestaurantDbContext context)
        : IRestaurantsRepository
{
    public async Task<int> CreateAsync(Restaurant entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task DeleteAsync(Restaurant entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await context.Restaurants.ToListAsync();
        return restaurants;
    }
    public async Task<IEnumerable<Restaurant>> GetAllMathchingAsync(string? searchPhrase)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var restaurants = await context
            .Restaurants
            .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
                                                          || r.Description.ToLower().Contains(searchPhraseLower)))
            .ToListAsync();

        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await context.Restaurants
                                                .Include(r => r.Dishes)
                                                .FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }

    public async Task SaveChangesAsync()
    => await context.SaveChangesAsync();
}
