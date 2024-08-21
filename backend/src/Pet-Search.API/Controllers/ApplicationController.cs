using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Pet_Search.API.Response;

namespace Pet_Search.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public abstract class ApplicationController : ControllerBase
	{
		public override OkObjectResult Ok([ActionResultObjectValue] object? value)
		{
			var envelope = Envelope.Ok(value);

			return new OkObjectResult(envelope);
		}
	}
}
