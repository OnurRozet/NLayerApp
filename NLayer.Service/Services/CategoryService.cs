using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
	public class CategoryService : Service<Category>, ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;


		public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository) : base(unitOfWork, repository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<CustomResponseDto<CategoryWithProductDto>> GetCategoryByIdWithProducts(int categoryId)
		{
			var category=await _categoryRepository.GetCategoryByIdWithProducts(categoryId);
			var categoryDto= _mapper.Map<CategoryWithProductDto>(category);
			return CustomResponseDto<CategoryWithProductDto>.Success(200,categoryDto);
		}
	}
}
