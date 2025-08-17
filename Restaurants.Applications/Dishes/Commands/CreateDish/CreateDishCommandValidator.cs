using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Applications.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish=>dish.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");

            RuleFor(Dishes=> Dishes.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("KiloCalories must be greater than or equal to zero if provided.");

        }
    }
}
