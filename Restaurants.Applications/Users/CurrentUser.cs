namespace Restaurants.Applications.User
{
    public record CurrentUser( string Id, string Email, string Password, IEnumerable<string> Roles)
    {
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
