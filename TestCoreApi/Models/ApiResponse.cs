using TestCoreApi.Enums;

namespace TestCoreApi.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse(StatusCode statusCode, string message)
        {
            Status = (int)statusCode;
            Message = message;
            Data = default(T);
        }

        public ApiResponse(T data)
        {
            Status = (int)StatusCode.Success;
            Message = null;
            Data = data;
        }

        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
