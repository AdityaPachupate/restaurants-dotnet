using MediatR;

namespace Restaurants.Applications.User.Commands
{
    public class UpdateUserDetailsCommand : IRequest
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Natinality { get; set; }
    }
}
