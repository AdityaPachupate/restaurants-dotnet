namespace Restaurants.Applications.User
{
    public record CurrentUser( string Id, string Email, string Password, IEnumerable<string> Roles,string? Nationality,DateOnly?DateOfBirth)
    {
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
