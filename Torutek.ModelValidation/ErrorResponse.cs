using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Torutek.ModelValidation
{
	/// <summary>
	/// Contains details about error(s) that occured.
	/// </summary>
	public class ErrorResponse
	{
		/// <summary>
		/// The errors that occured.
		/// </summary>
		[Required]
		public IEnumerable<string> Errors { get; set; }

		/// <summary>
		/// For deserializing
		/// </summary>
		public ErrorResponse() { }

		/// <summary>
		/// Constructor for single error message.
		/// </summary>
		/// <param name="error"></param>
		public ErrorResponse(string error) => Errors = new List<string> { error };

		/// <summary>
		/// Constructor for multiple error messages.
		/// </summary>
		/// <param name="errors"></param>
		public ErrorResponse(IEnumerable<string> errors) => Errors = errors;

		/// <summary>
		/// Creates and returns an ErrorResponse with the given message wrapped in a BadRequestResult.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public static IActionResult Result(string error)
		{
			return new BadRequestObjectResult(new ErrorResponse(error));
		}

		/// <summary>
		/// Creates and returns an ErrorResponse with the given messages wrapped in a BadRequestResult.
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		public static IActionResult Result(IEnumerable<string> errors)
		{
			return new BadRequestObjectResult(new ErrorResponse(errors));
		}
	}
}
