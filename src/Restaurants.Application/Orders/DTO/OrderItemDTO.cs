namespace Restaurants.Application.Orders.DTO;
public class OrderItemDTO
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public int DishId { get; set; }
    public string DishName { get; set; } = default!;
}
