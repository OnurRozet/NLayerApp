using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Filters
{
	public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
	{

		// Servis katmalarımızda istenilen id bulunamaz ise bloklara girmeden evvel kontrolun sağlanması için oluşturuldu.

		private readonly IService<T> _service;

		public NotFoundFilter(IService<T> service)
		{
			_service = service;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var idValue=context.ActionArguments.Values.FirstOrDefault();

			if (idValue == null)
			{
				await next.Invoke();
				return;
			}

			var id=(int)idValue;

			var anyEntity = await _service.AnyAsync(x => x.Id == id);

			if (anyEntity)
			{
				await next.Invoke();
				return;
			}

			context.Result = new NotFoundObjectResult(CustomResponseDto<CustomNoContentResponseDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));
		}
	}
}
