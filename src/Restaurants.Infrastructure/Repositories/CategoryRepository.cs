using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;
using System.Linq.Expressions;

namespace Restaurants.Infrastructure.Repositories;
internal class CategoryRepository(RestaurantDbContext context) : ICategoryRepository
{
    public async Task<int> CreateAsync(Category entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task DeleteAsync(Category entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    => await context.Categories.ToListAsync();

    public async Task<(IEnumerable<Category>, int)> GetAllMathchingAsync
        (string? searchPhrase,
        int pageNumber,
        int pageSize,
        string? sortBy,
        SortDirection direction)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var baseQuery = context
            .Categories
            .Where(d => searchPhraseLower == null || (d.Name.ToLower().Contains(searchPhraseLower)
                                                   || d.Description!.ToLower().Contains(searchPhraseLower)));

        var totalCount = await baseQuery.CountAsync();

        if (sortBy != null)
        {
            var columnsSelector = new Dictionary<string, Expression<Func<Category, object>>>
            {
                { nameof(Category.Name), d => d.Name },
                { nameof(Category.Description), d => d.Description! },
            };

            var selectedColumn = columnsSelector[sortBy];

            baseQuery = direction == SortDirection.Ascending
                ? baseQuery.OrderBy(selectedColumn)
                : baseQuery.OrderByDescending(selectedColumn);
        }

        var categories = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (categories, totalCount);
    }

    public async Task<Category?> GetByIdAsync(int id)
    => await context.Categories.FindAsync(id);


    public async Task<Category?> GetByNameAsync(string name)
    => await context.Categories.FirstOrDefaultAsync(c => c.Name == name);


    public async Task SaveChangesAsync()
    => await context.SaveChangesAsync();

}
