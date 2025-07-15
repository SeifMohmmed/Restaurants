using FluentValidation;

namespace Restaurants.Application.Dishes.DTOs.Command.CreateDish;
public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(c => c.Price)
             .GreaterThanOrEqualTo(0)
             .WithMessage("Price must be a non-negative number.");

        RuleFor(c => c.KiloCalories)
             .GreaterThanOrEqualTo(0)
             .WithMessage("KiloCalories must be a non-negative number.");


    }
}
