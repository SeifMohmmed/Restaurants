using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Resturants;

namespace Resturants.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResturantsController(IRestaurantService restaurantService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantService.GetAllRestaurants();

        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var restaurant = await restaurantService.GetById(id);

        if (restaurant is null)
            return NotFound();


        return Ok(restaurant);
    }
}
