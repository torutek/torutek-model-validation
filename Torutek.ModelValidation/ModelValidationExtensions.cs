using Microsoft.AspNetCore.Mvc;

namespace Torutek.ModelValidation
{
	/// <summary>
	/// Provides AlwaysValidateModels
	/// </summary>
	public static class ModelValidationExtensions
	{
		/// <summary>
		/// Validates models, returning an BadRequestObjectResult(ErrorResponse) if they fail instead of calling the Controller.Action
		/// </summary>
		public static void AlwaysValidateModels(this MvcOptions options)
		{
			options.Conventions.Insert(0, new AlwaysValidateModelsConvention());
		}
	}
}