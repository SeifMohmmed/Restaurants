namespace Restaurants.Application.Customers.DTO;
public class CustomerDTO
{
    public int Id { get; set; }

    public string FullName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

}
