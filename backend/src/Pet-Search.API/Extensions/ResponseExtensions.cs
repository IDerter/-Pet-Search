﻿using Microsoft.AspNetCore.Mvc;
using Pet_Search.Domain.Shared;

namespace Pet_Search.API.Extensions;

public static class ResponseExtensions
{
	public static ActionResult ToResponse(this Error error)
	{
		var statusCode = error.Type switch
		{
			ErrorType.Validation => StatusCodes.Status400BadRequest,
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			ErrorType.Failure => StatusCodes.Status500InternalServerError,
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			_ => StatusCodes.Status500InternalServerError,
		};

		return new ObjectResult(error)
		{
			StatusCode = statusCode
		};
	}
}
