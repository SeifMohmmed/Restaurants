using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Resturants;

namespace Restaurants.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RestaurantsController(IRestaurantService restaurantService) : ControllerBase
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
