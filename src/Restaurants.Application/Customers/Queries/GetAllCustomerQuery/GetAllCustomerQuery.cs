using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.Customers.DTO;
using Restaurants.Domain.Constants;

namespace Restaurants.Application.Customers.Queries.GetAllCustomerQuery;
public class GetAllCustomerQuery : IRequest<PagedResult<CustomerDTO>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }

}
