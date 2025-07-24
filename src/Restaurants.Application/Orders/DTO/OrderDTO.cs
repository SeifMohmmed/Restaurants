namespace Restaurants.Application.Orders.DTO;
public class OrderDTO
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public decimal TotalPrice { get; set; }

    public ICollection<OrderItemDTO> OrderItems { get; set; } = [];

}
