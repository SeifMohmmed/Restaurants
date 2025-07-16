using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.Users;

/// <summary>
/// Provides an abstraction for retrieving the currently authenticated user.
/// </summary>
public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

/// <summary>
/// Allows injection of the user context into any handler or service within the application.
/// It retrieves the user context information containing values for the user ID claim,
/// email claim, and the roles of a given user.
/// </summary>
/// <param name="httpContextAccessor">
/// Provides access to the current <see cref="HttpContext"/> to extract user claims.
/// </param>
public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        // Retrieves the current authenticated user's context information from the HTTP context.
        var user = httpContextAccessor?.HttpContext?.User;

        if (user is null)
            throw new InvalidOperationException("User context is not present");

        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return null;

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

        return new CurrentUser(userId, email, roles);

    }
}
