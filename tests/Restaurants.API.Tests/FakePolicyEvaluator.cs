using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.API.Tests;
/// <summary>
/// A fake implementation of <see cref="IPolicyEvaluator"/> for testing purposes.
/// </summary>
/// <remarks>
/// This class bypasses real authentication and authorization by always returning
/// a successful authentication result with a predefined user and granting access.
/// Useful for integration or unit tests where real authentication is not needed.
/// </remarks>

public class FakePolicyEvaluator : IPolicyEvaluator
{
    /// <summary>
    /// Simulates authentication by returning a fixed <see cref="ClaimsPrincipal"/> 
    /// with a predefined NameIdentifier and Admin role.
    /// </summary>
    public Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
    {
        var claimsPrincipal = new ClaimsPrincipal();

        claimsPrincipal.AddIdentity(new ClaimsIdentity(
            new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    new Claim(ClaimTypes.Role, "Admin"),
            }));

        var ticket = new AuthenticationTicket(claimsPrincipal, "Test");
        var result = AuthenticateResult.Success(ticket);
        return Task.FromResult(result);
    }

    /// <summary>
    /// Simulates authorization by always returning <see cref="PolicyAuthorizationResult.Success"/>.
    /// </summary>
    public Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy, AuthenticateResult authenticationResult, HttpContext context, object? resource)
    {
        var result = PolicyAuthorizationResult.Success();
        return Task.FromResult(result);
    }
}
