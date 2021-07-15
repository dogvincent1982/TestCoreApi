using System.Collections.Generic;
using TestCoreApi.Models;
using TestCoreApi.Models.Entity.Northwind;

namespace TestCoreApi.Accessor.Interface
{
    public interface ICategoryAccessor
    {
        Category GetCategoryByID(int id);
        (long totalCount, IEnumerable<Category> datas) GetCategories(PageRequest<object> request);
        int AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
