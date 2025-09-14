using FluentValidation;
using Restaurants.Applications.Restaurants.DTO;

namespace Restaurants.Applications.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
    {
        private int[] allowedPageSizes = [ 5, 10, 20 ];
        private string[] allowedSortByColumns = [nameof(RestaurantDto.Name) , nameof(RestaurantDto.Description),nameof(RestaurantDto.Category)];
        public GetAllRestaurantsQueryValidator()
        {
            RuleFor(x => x.pageNumber)
                .GreaterThan(1).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.pageSize)
                .Must(x => allowedPageSizes.Contains(x))
                .WithMessage($"Page size must be one of the following values: {string.Join(", ", allowedPageSizes)}");

            RuleFor(x => x.SortBy)
                .Must(x => allowedSortByColumns.Contains(x))
                .When(q=>q.SortBy!=null)
                .WithMessage($"Sort by must be one of the following values: {string.Join(", ", allowedSortByColumns)}");

        }
    }
}
