using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Orders.DTO;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Queries.GetAllOrders;
public class GetAllOrdersQueryHandler(ILogger<GetAllOrdersQueryHandler> logger,
    IOrdersRepository ordersRepository,
    IMapper mapper) : IRequestHandler<GetAllOrdersQuery, PagedResult<OrderDTO>>
{
    public async Task<PagedResult<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all orders");

        var (orders, totalCount) = await ordersRepository.GetAllMatchingAsync(request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);

        var ordersDtos = mapper.Map<IEnumerable<OrderDTO>>(orders);

        var result = new PagedResult<OrderDTO>(ordersDtos, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
