namespace TestCoreApi.Models
{
    public class PageRequest<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public T Condition { get; set; }
    }
}
