using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
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

		[HttpGet]

		public async Task<IActionResult> All()
		{
			var categories=await _categoryService.GetAllAsync();
			var categoryDto=_mapper.Map<List<CategoryDto>>(categories);
			return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200,categoryDto));
			
		}


		[HttpGet("{id}")]

		public async Task<IActionResult> GetById(int id)
		{
			var category = await _categoryService.GetByIdAsync(id);
			var categoryDto = _mapper.Map<CategoryDto>(category);
			return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));

		}


		[HttpPost]

		public async Task<IActionResult> Save(CategoryDto category)
		{
			var addedCategory=await _categoryService.AddAsync(_mapper.Map<Category>(category));
			var categoryDto = _mapper.Map<CategoryDto>(addedCategory);
			return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDto));

		}


		[HttpPut]

		public async Task<IActionResult> Update(CategoryDto category)
		{
			var updatedCategory = await _categoryService.AddAsync(_mapper.Map<Category>(category));
			var categoryDto = _mapper.Map<CategoryDto>(updatedCategory);
			return CreateActionResult(CustomResponseDto<CustomNoContentResponseDto>.Success(204));

		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> Delete(int id)
		{
			var deletedCategory = await _categoryService.GetByIdAsync(id);
			var categoryDto = _mapper.Map<CategoryDto>(deletedCategory);
			return CreateActionResult(CustomResponseDto<CustomNoContentResponseDto>.Success(204));

		}
	}
}
