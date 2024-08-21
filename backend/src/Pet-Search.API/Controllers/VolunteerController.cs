using Microsoft.AspNetCore.Mvc;
using Pet_Search.API.Extensions;
using Pet_Search.API.Response;
using Pet_Search.Application.Volunteers.CreateVolunteer;

namespace Pet_Search.API.Controllers
{
	public class VolunteerController : ApplicationController
	{
		[HttpPost]
		public async Task<ActionResult<Guid>> Create(
			[FromServices] CreateVolunteerHandler handler,
			[FromBody] CreateVolunteerRequest request,
			CancellationToken cancellationToken = default)
		{
			var result = await handler.HandleAsync(request, cancellationToken);

			return result.ToResponse();
		}
	}
}
