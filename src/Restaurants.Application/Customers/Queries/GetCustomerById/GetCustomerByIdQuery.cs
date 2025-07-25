using MediatR;
using Restaurants.Application.Customers.DTO;

namespace Restaurants.Application.Customers.Queries.GetCustomerById;
public class GetCustomerByIdQuery(int id) : IRequest<CustomerDTO>
{
    public int Id { get; } = id;

}
