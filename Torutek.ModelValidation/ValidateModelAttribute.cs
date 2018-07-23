using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Torutek.ModelValidation
{
	internal class ValidateModelAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.ModelState.IsValid)
				return;

			var errors = context.ModelState.Values
				.SelectMany(x => x.Errors.Select(y => y.ErrorMessage != "" ? y.ErrorMessage : y.Exception?.ToString()))
				.ToArray();

			// If the model state is invalid but there were no validation errors, the model probably couldn't be created
			if (!errors.Any())
				context.Result = ErrorResponse.Result("The request is badly formed");

			context.Result = ErrorResponse.Result(errors);
		}
	}
}
