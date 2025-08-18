namespace Restaurants.Applications.User
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}