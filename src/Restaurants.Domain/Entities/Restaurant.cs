using System.ComponentModel.DataAnnotations;

namespace Restaurants.Domain.Entities;
public class Restaurant
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = default!;

    [MaxLength(500)]
    public string Description { get; set; } = default!;

    [MaxLength(100)]
    public string Category { get; set; } = default!;

    public bool HasDelivery { get; set; }

    [EmailAddress, MaxLength(100)]
    public string? ContactEmail { get; set; }

    public string? ContactNumber { get; set; }


    public Address? Address { get; set; }

    public List<Dish> Dishes { get; set; } = [];

    public ICollection<Rating> Ratings { get; set; } = [];

    public ApplicationUser Owner { get; set; } = default!;

    public string OwnerId { get; set; } = default!;

}
