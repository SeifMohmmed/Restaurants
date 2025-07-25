namespace Restaurants.Application.Dishes.DTOs;
public class DishDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }

    public int RestaurantId { get; set; }

    public int? KiloCalories { get; set; }

    public string RestaurantName { get; set; } = default!;

    public string CategoryName { get; set; } = default!;


}
