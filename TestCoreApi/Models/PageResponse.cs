using System.Collections.Generic;

namespace TestCoreApi.Models
{
    public class PageResponse<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
