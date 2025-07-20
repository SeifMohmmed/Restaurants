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
    public async Task<(IEnumerable<Restaurant>, int)> GetAllMathchingAsync(string? searchPhrase, int pageNumber, int pageSize)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var baseQuery = context
            .Restaurants
            .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
                                                          || r.Description.ToLower().Contains(searchPhraseLower)));


        var totalCount = await baseQuery.CountAsync();

        var restaurants = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (restaurants, totalCount);
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
