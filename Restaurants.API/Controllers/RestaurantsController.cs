using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.DTOs;
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
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await restaurantService.GetById(id);

        if (restaurant is null)
            return NotFound();


        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDTO dto)
    {
        int id = await restaurantService.Create(dto);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
