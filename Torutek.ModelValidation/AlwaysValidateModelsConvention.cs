using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Torutek.ModelValidation
{
	internal class AlwaysValidateModelsConvention : IApplicationModelConvention
	{
		public void Apply(ApplicationModel application)
		{
			var filter = new ValidateModelAttribute();

			foreach (var action in application.Controllers.SelectMany(c => c.Actions))
			{
				action.Filters.Add(filter);
			}
		}
	}
}