using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Data;
internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Resturants { get; set; }

    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
                    .OwnsOne(x => x.Address);

        modelBuilder.Entity<Restaurant>()
                    .HasMany(x => x.Dishes)
                    .WithOne()
                    .HasForeignKey(x => x.RestaurantId);
    }
}
