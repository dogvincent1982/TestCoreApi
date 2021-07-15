using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TestCoreApi.Models;

namespace TestCoreApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(
                    JsonConvert.ToString(
                        new ApiResponse<object>(Enums.StatusCode.UnknowError, "Unknow Error")));
            }
        }
    }
}
