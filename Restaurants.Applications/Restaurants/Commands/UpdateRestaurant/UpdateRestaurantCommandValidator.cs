using FluentValidation;

namespace Restaurants.Applications.Restaurants.Commands.UpdateRestaurant
{
    internal class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(Command => Command.Name)
                .Length(3, 100);
        }
    }
}
