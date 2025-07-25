using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Customers.DTO;
using Restaurants.Application.Customers.Queries.GetAllCustomerQuery;
using Restaurants.Application.Customers.Queries.GetCustomerById;

namespace Restaurants.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll([FromQuery] GetAllCustomerQuery query)
    {
        var customers = await mediator.Send(query);
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<CustomerDTO?>>> GetById([FromRoute] int id)
    {
        var customer = await mediator.Send(new GetCustomerByIdQuery(id));
        return Ok(customer);
    }
}
