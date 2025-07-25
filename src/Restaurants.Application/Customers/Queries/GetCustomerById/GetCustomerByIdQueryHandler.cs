using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Customers.DTO;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Customers.Queries.GetCustomerById;
public class GetCustomerByIdQueryHandler(ILogger<GetCustomerByIdQueryHandler> logger,
    ICustomerRepository customerRepository,
    IMapper mapper) : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
{
    public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Customer with id : {CustomerId}", request.Id);

        var customer = await customerRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Customer), request.Id.ToString());

        var result = mapper.Map<CustomerDTO>(customer);

        return result;
    }
}
