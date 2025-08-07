using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IRatingsRepository
{
    Task<IEnumerable<Rating>> GetAllAsync();
    Task<(IEnumerable<Rating>, int)> GetAllMathchingAsync(string? searchPhrase, int pageNumber, int pageSize, string? sortBy, SortDirection direction);
    Task<Rating?> GetByIdWithIncluded(int id);
    Task<int> CreateAsync(Rating entity);
    Task DeleteAsync(Rating entity);
    Task SaveChangesAsync();
}
