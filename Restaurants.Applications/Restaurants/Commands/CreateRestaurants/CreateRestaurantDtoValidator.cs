using FluentValidation;

namespace Restaurants.Applications.Restaurants.Commands.CreateRestaurants;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = new List<string>
    {
        "Italian", "Chinese", "Indian", "Mexican", "American", "French", "Japanese"
    };

    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(3, 100).WithMessage("Name must be between 3 and 100 characters");
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(dto => dto.Category)
            .Must(category => validCategories.Contains(category))
            .WithMessage($"Category must be one of the following: {string.Join(", ", validCategories)}");
        // .Custom((value, context) =>
        // {
        //     var isValidCategory = validCategories.Contains(value);
        //     if (!isValidCategory)
        //     {
        //         context.AddFailure("Category", $"Category must be one of the following: {string.Join(", ", validCategories)}");
        //     }
        // });

        RuleFor(dto => dto.ContactNumber)
            .NotEmpty().WithMessage("Contact number is required")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Enter valid phone number");
        RuleFor(dto => dto.ContactEmail)
            .NotEmpty().WithMessage("Contact email is required")
            .EmailAddress().WithMessage("Enter valid email address");
        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}(-\d{2})?$").WithMessage("Enter valid postal code")
            .WithMessage("Postal code is optional but must be valid if provided");
    }
}
