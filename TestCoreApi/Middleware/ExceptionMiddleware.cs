using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
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
                LogManager.GetLogger("ExceptionMiddleware").Error(ex);
                await context.Response.WriteAsync(
                    JsonConvert.ToString(
                        new ApiResponse<object>(Enums.StatusCode.UnknowError, "Unknow Error")));
            }
        }
    }
}
