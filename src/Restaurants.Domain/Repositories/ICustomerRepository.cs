using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface ICustomerRepository
{
    Task<(IEnumerable<Customer>, int)> GetAllMathchingAsync(string? searchPhrase, int pageNumber, int pageSize, string? sortBy, SortDirection direction);
    Task<Customer?> GetByIdAsync(int id);
}
