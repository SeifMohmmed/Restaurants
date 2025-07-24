using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Categories.Command.CreateCategory;
using Restaurants.Application.Categories.Command.DeleteCategory;
using Restaurants.Application.Categories.Command.UpdateCategory;
using Restaurants.Application.Categories.DTO;
using Restaurants.Application.Categories.Queries.GetAllCategories;
using Restaurants.Application.Categories.Queries.GetCategoryById;
using Restaurants.Application.Categories.Queries.GetCategoryByName;

namespace Restaurants.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll([FromQuery] GetAllCategoriesQuery query)
    {
        var categories = await mediator.Send(query);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<CategoryDTO?>>> GetById([FromRoute] int id)
    {
        var categories = await mediator.Send(new GetCategoryByIdQuery(id));
        return Ok(categories);
    }


    [HttpGet("Name{name}")]
    public async Task<ActionResult<IEnumerable<CategoryDTO?>>> GetById([FromRoute] string name)
    {
        var categories = await mediator.Send(new GetCategoryByNameQuery(name));
        return Ok(categories);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryCommand command)
    {
        command.Id = id;

        await mediator.Send(command);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = UserRoles.Owner)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

}
