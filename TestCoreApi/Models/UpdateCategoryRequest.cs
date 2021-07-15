using Microsoft.AspNetCore.Http;

namespace TestCoreApi.Models
{
    public class UpdateCategoryRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
