using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
	
	public class CategoriesController : CustomBaseController
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoriesController(IMapper mapper, ICategoryService categoryService)
		{
			_mapper = mapper;
			_categoryService = categoryService;
		}

		[HttpGet("GetCategoriesByIdWithProduct/{categoryId}")]


		public async Task<IActionResult> GetCategoriesByIdWithProduct(int categoryId)
		{
			return CreateActionResult(await _categoryService.GetCategoryByIdWithProducts(categoryId));
		}
	}
}
