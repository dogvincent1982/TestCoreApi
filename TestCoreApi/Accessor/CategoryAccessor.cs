using System.Collections.Generic;
using System.Linq;
using TestCoreApi.Accessor.Interface;
using TestCoreApi.Context;
using TestCoreApi.Models;
using TestCoreApi.Models.Entity.Northwind;

namespace TestCoreApi.Accessor
{
    public class CategoryAccessor: ICategoryAccessor
    {
        private NorthwindContext _northwindContext;
        public CategoryAccessor(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        Category ICategoryAccessor.GetCategoryByID(int id)
            => _northwindContext.Categories.FirstOrDefault(item => item.CategoryID == id);

        (long totalCount, IEnumerable<Category> datas) ICategoryAccessor.GetCategories(PageRequest<object> request)
        {
            var query = _northwindContext.Categories;
            var totalCount = _northwindContext.Categories.LongCount();
            var datas = _northwindContext.Categories
                        .Skip(request.PageSize * request.PageIndex)
                        .Take(request.PageSize).ToList();
            return (totalCount, datas);
        }

        int ICategoryAccessor.AddCategory(Category category)
        {
            category = _northwindContext.Categories.Add(category).Entity;
            _northwindContext.SaveChanges();
            return category.CategoryID;
        }

        bool ICategoryAccessor.UpdateCategory(Category category)
        {
            _northwindContext.Categories.Update(category);
            return _northwindContext.SaveChanges() > 0;
        }

        bool ICategoryAccessor.DeleteCategory(int id)
        {
            var category = _northwindContext.Categories.FirstOrDefault(item => item.CategoryID == id);
            if (category == default(Category))
                throw new System.Exception("Data Not Exist");
            _northwindContext.Categories.Remove(category);
            return _northwindContext.SaveChanges() > 0;
        }
    }
}
