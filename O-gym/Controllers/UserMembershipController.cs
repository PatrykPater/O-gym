using Microsoft.AspNetCore.Mvc;
using O_gym.Application.Features.UserMembership.Commands;
using O_gym.Contracts.V1;
using System.Threading;
using System.Threading.Tasks;

namespace O_gym.Controllers
{
    public class UserMembershipController : ApiControllerBase
    {
        [HttpPost(ApiRoutes.UserMemberShip.AddMembership)]
        public async Task<IActionResult> AddMembership(AddMembershipCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost(ApiRoutes.UserMemberShip.ExtendMembership)]
        public async Task<IActionResult> ExtendMembership(ExtendMembershipCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost(ApiRoutes.UserMemberShip.CancelMembership)]
        public async Task<IActionResult> CancelMembership(CancelMembershipCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
