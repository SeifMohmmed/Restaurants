using Resturants.Domain.Entities;
using Resturants.Infrastructure.Data;

namespace Resturants.Infrastructure.Seeders;
internal class ResturantSeeders(RestaurantDbContext context) : IResturantSeeders
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.Resturants.Any())
            {
                var resturants = GetResturants();

                context.Resturants.AddRange(resturants);

                await context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetResturants()
    {
        var resturants = new List<Restaurant>()
        {
            new ()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description =
                        "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new ()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Description = "Crispy, juicy chicken seasoned with bold Nashville spices and served with pickles for a fiery Southern kick.",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Description = "Tender, bite-sized pieces of seasoned chicken, golden-fried to perfection and served with your choice of dipping sauce.",
                            Price = 5.30M,
                        },
                    },
                    Address = new ()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
            new ()
                {
                    Name = "McDonald Szewska",
                    Category = "Fast Food",
                    Description =
                        "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Szewska 2",
                        PostalCode = "30-001"
                    }
                }

        };

        return resturants;
    }

}
