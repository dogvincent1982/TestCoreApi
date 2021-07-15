using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestCoreApi.Models;
using TestCoreApi.Service.Interface;

namespace TestCoreApi.Controllers
{
    [ApiController]
    [Route("Api/Category")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public ApiResponse<GetCategoryByIDResponse> GetCategoryByID([FromQuery] int id)
        {
            if (id <= 0)
                return new ApiResponse<GetCategoryByIDResponse>(default(GetCategoryByIDResponse));
            var category = _categoryService.GetCategoryByID(id);
            return new ApiResponse<GetCategoryByIDResponse>(new GetCategoryByIDResponse
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            });
        }

        [HttpGet]
        public ApiResponse<PageResponse<CategoryInfo>> GetCategories(PageRequest<object> request)
        {
            (long totalCount, IEnumerable<CategoryInfo> datas) = _categoryService.GetCategories(request);
            return new ApiResponse<PageResponse<CategoryInfo>>(new PageResponse<CategoryInfo>
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Result = datas
            });
        }

        [HttpPost]
        public ApiResponse<int> AddCategory([FromBody] AddCategoryRequest request)
        {
            return new ApiResponse<int>(_categoryService.AddActegory(request));
        }

        [HttpPut("{id}")]
        public ApiResponse<bool> UpdateCategory(int id, [FromBody] UpdateCategoryRequest request)
        {
            return new ApiResponse<bool>(_categoryService.UpdateCategory(id, request));
        }

        [HttpDelete("{id}")]
        public ApiResponse<bool> DeleteCategory(int id)
        {
            return new ApiResponse<bool>(_categoryService.DeleteCategory(id));
        }
    }
}
