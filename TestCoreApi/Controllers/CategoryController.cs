using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public GetCategoryByIDResponse GetCategoryByID([FromQuery] int id)
        {
            if (id <= 0)
                return default(GetCategoryByIDResponse);
            var category = _categoryService.GetCategoryByID(id);
            return new GetCategoryByIDResponse
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }

        [HttpGet]
        public PageResponse<CategoryInfo> GetCategories(PageRequest<object> request)
        {
            (long totalCount, IEnumerable<CategoryInfo> datas) = _categoryService.GetCategories(request);
            return new PageResponse<CategoryInfo>
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Data = datas
            };
        }

        [HttpPost]
        public int AddCategory([FromBody] AddCategoryRequest request)
        {
            return _categoryService.AddActegory(request);
        }

        [HttpPut("{id}")]
        public bool UpdateCategory(int id, [FromBody] UpdateCategoryRequest request)
        {
            return _categoryService.UpdateCategory(id, request);
        }

        [HttpDelete("{id}")]
        public bool DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}
