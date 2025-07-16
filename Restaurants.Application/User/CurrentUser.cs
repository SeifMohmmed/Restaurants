namespace Restaurants.Application.User;
public record CurrentUser(string Id, string Email, IEnumerable<string> Roles)
{
    public bool IsRole(string role) => Roles.Contains(role);
}
