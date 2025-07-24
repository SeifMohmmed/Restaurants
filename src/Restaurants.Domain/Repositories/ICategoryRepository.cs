using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<(IEnumerable<Category>, int)> GetAllMathchingAsync(string? searchPhrase, int pageNumber, int pageSize, string? sortBy, SortDirection direction);
    Task<Category?> GetByIdAsync(int id);
    Task<int> CreateAsync(Category entity);
    Task DeleteAsync(Category entity);
    Task SaveChangesAsync();

    Task<Category?> GetByNameAsync(string name);

}
