using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;
using System.Linq.Expressions;

namespace Restaurants.Infrastructure.Repositories;
internal class RatingsRepository(RestaurantDbContext context) : IRatingsRepository
{
    public async Task<int> CreateAsync(Rating entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task DeleteAsync(Rating entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Rating>> GetAllAsync()
    {
        var ratings = await context.Ratings.ToListAsync();

        return ratings;
    }

    public async Task<(IEnumerable<Rating>, int)> GetAllMathchingAsync(string? searchPhrase, int pageNumber, int pageSize, string? sortBy, SortDirection direction)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        bool isInt = int.TryParse(searchPhraseLower, out int star);
        bool isDate = DateTime.TryParse(searchPhrase, out DateTime date);

        var baseQuery = context
            .Ratings
            .AsNoTracking()
            .Include(r => r.Restaurant)
            .Include(r => r.Dish)
            .Include(r => r.Customer)
            .Where(r =>
                    searchPhraseLower == null ||
                    r.Comment!.ToLower().Contains(searchPhraseLower) ||
                    (isInt && r.Stars == star) ||
                    (isDate && r.CreatedAt.Date == date.Date));

        var totalCount = await baseQuery.CountAsync();


        if (sortBy is not null)
        {
            var columnsSelector = new Dictionary<string, Expression<Func<Rating, object>>>
            {
                { nameof(Rating.Comment), r => r.Comment! },
                { nameof(Rating.Stars), r => r.Stars },
                { nameof(Rating.CreatedAt), r => r.CreatedAt },
            };

            var selectedColumn = columnsSelector[sortBy];

            baseQuery = direction == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);

        }

        var ratings = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (ratings, totalCount);
    }


    public async Task<Rating?> GetByIdWithIncluded(int id)
    {
        var ratings = await context.Ratings.AsNoTracking()
                     .Include(r => r.Restaurant)
                     .Include(r => r.Dish)
                     .Include(r => r.Customer)
                     .FirstOrDefaultAsync(r => r.Id == id);

        return ratings;
    }

    public async Task SaveChangesAsync()
    => await context.SaveChangesAsync();

}
