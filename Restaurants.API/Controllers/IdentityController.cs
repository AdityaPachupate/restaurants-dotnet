using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Applications.User.Commands;
using Restaurants.Applications.Users.Commands.AssignUserRole;

namespace Restaurants.API.Controllers
{

    [ApiController]
    [Route("api/identity")]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPatch("userDetails")]
        
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand updateUserDetailsCommand)
        {
            await mediator.Send(updateUserDetailsCommand);
            return NoContent();
        }

        [HttpPost("userRole")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand assignUserRoleCommand)
        {
            await mediator.Send(assignUserRoleCommand);
            return NoContent();
        }

    }
}
