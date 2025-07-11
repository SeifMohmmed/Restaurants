using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entities;

namespace Resturants.Infrastructure.Data;
internal class ResturantsDbContext(DbContextOptions<ResturantsDbContext> options) : DbContext(options)
{
    internal DbSet<Resturant> Resturants { get; set; }

    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Resturant>()
                    .OwnsOne(x => x.Address);

        modelBuilder.Entity<Resturant>()
                    .HasMany(x => x.Dishes)
                    .WithOne()
                    .HasForeignKey(x => x.ResturantId);
    }
}
