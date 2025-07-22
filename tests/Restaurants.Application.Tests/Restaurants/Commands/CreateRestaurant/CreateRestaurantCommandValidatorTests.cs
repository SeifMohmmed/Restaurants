using FluentValidation.TestHelper;
using Xunit;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant.Tests;

public class CreateRestaurantCommandValidatorTests
{
    [Fact()]
    public void Validator_ForVaildCommand_SHouldNotHaveValidationErrors()
    {
        //arrange
        var command = new CreateRestaurantCommand()
        {
            Name = "Test",
            Category = "Italian",
            ContactEmail = "test@test.com",
            PostalCode = "12-545"
        };

        var validator = new CreateRestaurantCommandValidator();

        //act

        var result = validator.TestValidate(command);

        //assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact()]
    public void Validator_ForInVaildCommand_SHouldHaveValidationErrors()
    {
        //arrange
        var command = new CreateRestaurantCommand()
        {
            Name = "Te",
            Category = "Ita",
            ContactEmail = "@test.com",
            PostalCode = "12545"
        };

        var validator = new CreateRestaurantCommandValidator();

        //act

        var result = validator.TestValidate(command);

        //assert
        result.ShouldHaveValidationErrorFor(r => r.Name);
        result.ShouldHaveValidationErrorFor(r => r.Category);
        result.ShouldHaveValidationErrorFor(r => r.ContactEmail);
        result.ShouldHaveValidationErrorFor(r => r.PostalCode);
    }

    [Theory()]
    [InlineData("Italian")]
    [InlineData("Mexican")]
    [InlineData("Japanese")]
    [InlineData("American")]
    [InlineData("Indian")]
    public void Validator_ForValidCategory_ShouldNotHaveValidationErrorsForCategoryProperty(string category)
    {
        //arrange
        var validator = new CreateRestaurantCommandValidator();
        var command = new CreateRestaurantCommand { Category = category };

        //act

        var result = validator.TestValidate(command);

        //assert
        result.ShouldNotHaveValidationErrorFor(c => c.Category);
    }

    [Theory()]
    [InlineData("10220")]
    [InlineData("102-20")]
    [InlineData("10 220")]
    [InlineData("10-2 20")]
    public void Validator_ForInvalidPostalCode_ShouldHaveValidationErrorsForPostalCodeProperty(string postalCode)
    {
        // arrange
        var validator = new CreateRestaurantCommandValidator();
        var command = new CreateRestaurantCommand { PostalCode = postalCode };

        // act

        var result = validator.TestValidate(command);

        // assert
        result.ShouldHaveValidationErrorFor(c => c.PostalCode);
    }
}