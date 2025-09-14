using FluentValidation;

namespace Restaurants.Applications.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
    {
        private int[] allowedPageSizes = [ 5, 10, 20 ];
        public GetAllRestaurantsQueryValidator()
        {
            RuleFor(x => x.pageNumber)
                .GreaterThan(1).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.pageSize)
                .Must(x => allowedPageSizes.Contains(x))
                .WithMessage($"Page size must be one of the following values: {string.Join(", ", allowedPageSizes)}");
        }
    }
}
