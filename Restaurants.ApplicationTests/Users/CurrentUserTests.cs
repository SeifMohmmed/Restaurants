using FluentAssertions;
using Restaurants.Domain.Constants;

namespace Restaurants.Application.Users.Tests;

[TestClass()]
public class CurrentUserTests
{
    //TestMethod_Scenario_ExpectResult 
    [Theory()]

    public void IsInRole_WithMatchingRole_ShouldReturnTrue(string roleName)
    {
        //arrange

        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);

        //act

        var isInRole = currentUser.IsInRole(UserRoles.Admin);

        //assert

        isInRole.Should().BeTrue();

    }

    [TestMethod()]
    public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        //arrange

        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);

        //act

        var isInRole = currentUser.IsInRole(UserRoles.Owner);

        //assert

        isInRole.Should().BeFalse();

    }

    [TestMethod()]
    public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        //arrange

        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);

        //act

        var isInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

        //assert

        isInRole.Should().BeFalse();

    }
}