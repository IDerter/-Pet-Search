using Microsoft.AspNetCore.Mvc;
using Pet_Search.API.Extensions;
using Pet_Search.Application.Volunteers.CreateVolunteer;

namespace Pet_Search.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VolunteerController : ControllerBase
	{
		[HttpPost]
		public async Task<ActionResult<Guid>> Create(
			[FromServices] CreateVolunteerHandler handler,
			[FromBody] CreateVolunteerRequest request,
			CancellationToken cancellationToken = default)
		{
			var result = await handler.HandleAsync(request, cancellationToken);

			if (result.IsFailure)
			{
				return result.Error.ToResponse();
			}

			return Ok(result.Value);
		}
	}
}
