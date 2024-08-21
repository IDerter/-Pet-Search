using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Pet_Search.API.Response;
using Pet_Search.Domain.Shared;

namespace Pet_Search.API.Extensions;

public static class ResponseExtensions
{
	public static ActionResult ToResponse(this UnitResult<Error> result)
	{
		if (result.IsSuccess)
			return new OkResult();

		var statusCode = result.Error.Type switch
		{
			ErrorType.Validation => StatusCodes.Status400BadRequest,
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			ErrorType.Failure => StatusCodes.Status500InternalServerError,
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			_ => StatusCodes.Status500InternalServerError,
		};

		var envelope = Envelope.Error(result.Error);

		return new ObjectResult(envelope)
		{
			StatusCode = statusCode
		};
	}

	public static ActionResult<T> ToResponse<T>(this Error error)
	{
		var statusCode = error.Type switch
		{
			ErrorType.Validation => StatusCodes.Status400BadRequest,
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			ErrorType.Failure => StatusCodes.Status500InternalServerError,
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			_ => StatusCodes.Status500InternalServerError,
		};

		var envelope = Envelope.Error(error);

		return new ObjectResult(envelope)
		{
			StatusCode = statusCode
		};
	}
}
