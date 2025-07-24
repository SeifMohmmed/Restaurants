using MediatR;
using Restaurants.Application.Orders.DTO;

namespace Restaurants.Application.Orders.Queries.GetOrderById;
public class GetOrderByIdQuery(int id) : IRequest<OrderDTO>
{
    public int Id { get; } = id;
}
