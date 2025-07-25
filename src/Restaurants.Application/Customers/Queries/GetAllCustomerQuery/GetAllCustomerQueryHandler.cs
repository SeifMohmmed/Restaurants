using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Customers.DTO;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Customers.Queries.GetAllCustomerQuery;
public class GetAllCustomerQueryHandler(ILogger<GetAllCustomerQueryHandler> logger,
    ICustomerRepository customerRepository,
    IMapper mapper) : IRequestHandler<GetAllCustomerQuery, PagedResult<CustomerDTO>>
{
    public async Task<PagedResult<CustomerDTO>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all customers");
        var (customers, totalCount) = await customerRepository.GetAllMathchingAsync(request.SearchPhrase,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);

        var customersDTO = mapper.Map<IEnumerable<CustomerDTO>>(customers);

        var result = new PagedResult<CustomerDTO>(customersDTO, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
