using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;
using System.Security.Claims;

namespace Restaurants.Infrastructure.Authorization;
/// <summary>
/// A custom ClaimsPrincipalFactory for ApplicationUser that adds additional claims 
/// such as Nationality and DateOfBirth to the user's ClaimsPrincipal.
/// </summary>
public class RestaurantsUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>(userManager, roleManager, options)
{

    /// <summary>
    /// Creates a <see cref="ClaimsPrincipal"/> for the specified <see cref="ApplicationUser"/>.
    /// as well as custom claims such as Nationality and DateOfBirth if available.
    /// </summary>
    public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
    {
        // Generate the default ClaimsIdentity with standard claims (Name, Roles, etc.)
        var id = await GenerateClaimsAsync(user);

        if (user.Nationality is not null)
        {
            id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));
        }

        if (user.DateOfBirth is not null)
        {
            id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));

        }

        return new ClaimsPrincipal(id);
    }
}
