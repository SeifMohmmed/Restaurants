using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;
using System.Linq.Expressions;

namespace Restaurants.Infrastructure.Repositories;
internal class CustomerRepository(RestaurantDbContext context) : ICustomerRepository
{
    public async Task<(IEnumerable<Customer>, int)> GetAllMathchingAsync(string? searchPhrase, int pageNumber, int pageSize, string? sortBy, SortDirection direction)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var baseQuery = context
            .Customers
            .AsNoTracking()
            .Where(d => searchPhraseLower == null || (d.FullName.ToLower().Contains(searchPhraseLower)
                                                   || d.Email!.ToLower().Contains(searchPhraseLower))
                                                   || d.PhoneNumber!.ToLower().Contains(searchPhraseLower));

        var totalCount = await baseQuery.CountAsync();

        if (sortBy != null)
        {
            var columnsSelector = new Dictionary<string, Expression<Func<Customer, object>>>
            {
                { nameof(Customer.FullName), d => d.FullName },
                { nameof(Customer.Email), d => d.Email! },
            };

            var selectedColumn = columnsSelector[sortBy];

            baseQuery = direction == SortDirection.Ascending
                ? baseQuery.OrderBy(selectedColumn)
                : baseQuery.OrderByDescending(selectedColumn);
        }

        var customers = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

        return (customers, totalCount);
    }

    public async Task<Customer?> GetByIdAsync(int id)
     => await context.Customers.FindAsync(id);

}
