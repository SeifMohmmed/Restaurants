using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Command;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    public async Task<IActionResult> UpdateUser(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }
}
