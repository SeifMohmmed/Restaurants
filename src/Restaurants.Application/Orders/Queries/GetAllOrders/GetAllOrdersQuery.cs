using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.Orders.DTO;
using Restaurants.Domain.Constants;

namespace Restaurants.Application.Orders.Queries.GetAllOrders;
public class GetAllOrdersQuery : IRequest<PagedResult<OrderDTO>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
