using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCoreApi.Accessor.Interface;
using TestCoreApi.Models;
using TestCoreApi.Models.Entity.Northwind;
using TestCoreApi.Service.Interface;

namespace TestCoreApi.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryAccessor _categoryAccessor;
        public CategoryService(ICategoryAccessor categoryAccessor,)
        {
            _categoryAccessor = categoryAccessor;
        }

        Category ICategoryService.GetCategoryByID(int id)
            => _categoryAccessor.GetCategoryByID(id);

        (long,IEnumerable<CategoryInfo>) ICategoryService.GetCategories(PageRequest<object> request)
        {
           (long totalCount, IEnumerable<Category> datas) = _categoryAccessor.GetCategories(request);
            return (totalCount, datas.Select(item => new CategoryInfo
            {
                CategoryID = item.CategoryID,
                CategoryName = item.CategoryName,
                Description = item.Description,
                Picture = item.Picture,
            }));
        }

        int ICategoryService.AddActegory(AddCategoryRequest request)
        {
            using (var streamReader = new StreamReader(request.File.OpenReadStream()))
            {
                return _categoryAccessor.AddCategory(new Category
                {
                    CategoryName = request.CategoryName,
                    Description = request.Description,
                    Picture = Convert.FromBase64String(streamReader.ReadToEnd())
                });
            }
        }

        bool ICategoryService.UpdateCategory(int id, UpdateCategoryRequest request)
        {
            using (var streamReader = new StreamReader(request.File.OpenReadStream()))
            {
                return _categoryAccessor.UpdateCategory(new Category
                {
                    CategoryID = id,
                    CategoryName = request.CategoryName,
                    Description = request.Description,
                    Picture = Convert.FromBase64String(streamReader.ReadToEnd())
                });
            }
        }

        bool ICategoryService.DeleteCategory(int id)
            => _categoryAccessor.DeleteCategory(id);
    }
}
