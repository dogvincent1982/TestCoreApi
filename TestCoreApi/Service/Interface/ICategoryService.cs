using System.Collections.Generic;
using TestCoreApi.Models;
using TestCoreApi.Models.Entity.Northwind;

namespace TestCoreApi.Service.Interface
{
    public interface ICategoryService
    {
        Category GetCategoryByID(int id);
        (long, IEnumerable<CategoryInfo>) GetCategories(PageRequest<object> request);
        int AddActegory(AddCategoryRequest request);
        bool UpdateCategory(int id, UpdateCategoryRequest request);
        bool DeleteCategory(int id);
    }
}
